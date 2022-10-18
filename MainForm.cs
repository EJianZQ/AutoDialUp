using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sunny.UI;
using AutoDialUp.Data;
using AutoDialUp.Crypt;
using Newtonsoft.Json;
using Application = System.Windows.Forms.Application;
using System.Windows.Threading;

namespace AutoDialUp
{
    public partial class MainForm : UIForm
    {
        RASDisplay ras = new RASDisplay();
        DialUpAccount savedaccount = new DialUpAccount();
        SoftwareConfig softwareConfig = null;
        int _autoConnectTimerLocker = -1;
        int _autoReConnectFlag = -1;//0是未联网，1是已联网
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            int pageIndex = 1000;
            TreeNode parent = Aside.CreateNode("状态", 61668, 30, pageIndex);
            parent = Aside.CreateNode("配置", 61573, 30, ++pageIndex);
            Aside.CreateChildNode(parent,"拨号", 61612,12, ++pageIndex);
            Aside.CreateChildNode(parent, "自动化", 61904, 12, ++pageIndex);
            Aside.CreateChildNode(parent, "热键", 361957, 12, ++pageIndex);
            parent = Aside.CreateNode("关于", 61638, 30, ++pageIndex);
            tabControl.Region = new Region(new RectangleF(tabPage_Status.Left, tabPage_Status.Top + 5, tabPage_Status.Width, tabPage_Status.Height + 5)); //隐藏tabcontrol的选项卡
            Thread netCheckThread = new Thread(() =>
            {
                switch (GetInternetConStatus.GetNetConStatus("baidu.com"))//GetInternetConStatus.GetNetConStatus("baidu.com")
                {
                    case 1: 
                        {
                            //网络未连接
                            uiTitlePanel_NetStatus.TitleColor = Color.DarkOrange;
                            uiTitlePanel_NetStatus.RectColor = Color.DarkOrange;
                            uiAvatar_NetStatus.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.Symbol = 61453;//×，未通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61453;
                            uiSymbolLabel_PingOK.Symbol = 61453;
                            uiSymbolLabel_ConnectCheck.Text = "网络未连接";
                            uiSymbolLabel_InternetDeviceType.Text = "上网类型未知";
                            uiSymbolLabel_PingOK.Text = "Ping失败";
                            break;
                        }
                    case 2: 
                        {
                            //采用调制解调器上网
                            uiTitlePanel_NetStatus.TitleColor = Color.FromArgb(80, 160, 255);
                            uiTitlePanel_NetStatus.RectColor = Color.FromArgb(80, 160, 255);
                            uiAvatar_NetStatus.ForeColor = Color.FromArgb(80, 160, 255);
                            //uiSymbolLabel_ConnectCheck.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.FromArgb(80, 160, 255);
                            //uiSymbolLabel_InternetDeviceType.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.FromArgb(80, 160, 255);
                            //uiSymbolLabel_PingOK.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_PingOK.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.Symbol = 61452;//钩，通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61452;
                            uiSymbolLabel_PingOK.Symbol = 61452;
                            uiSymbolLabel_ConnectCheck.Text = "网络已连接";
                            uiSymbolLabel_InternetDeviceType.Text = "调制解调器上网";
                            uiSymbolLabel_PingOK.Text = "Ping正常";
                            break;
                        }
                    case 3:
                        {
                            //采用网卡上网
                            uiTitlePanel_NetStatus.TitleColor = Color.FromArgb(80, 160, 255);
                            uiTitlePanel_NetStatus.RectColor = Color.FromArgb(80, 160, 255);
                            uiAvatar_NetStatus.ForeColor = Color.FromArgb(80, 160, 255);
                            //uiSymbolLabel_ConnectCheck.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.FromArgb(80, 160, 255);
                            //uiSymbolLabel_InternetDeviceType.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.FromArgb(80, 160, 255);
                            //uiSymbolLabel_PingOK.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_PingOK.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.Symbol = 61452;//钩，通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61452;
                            uiSymbolLabel_PingOK.Symbol = 61452;
                            uiSymbolLabel_ConnectCheck.Text = "网络已连接";
                            uiSymbolLabel_InternetDeviceType.Text = "使用网卡上网";
                            uiSymbolLabel_PingOK.Text = "Ping正常";
                            break;
                        }
                        case 4:
                        {
                            //采用调制解调器上网,但是联不通指定网络
                            uiTitlePanel_NetStatus.TitleColor = Color.DarkOrange;
                            uiTitlePanel_NetStatus.RectColor = Color.DarkOrange;
                            uiAvatar_NetStatus.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.Symbol = 61453;//×，未通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61453;
                            uiSymbolLabel_PingOK.Symbol = 61453;
                            uiSymbolLabel_ConnectCheck.Text = "网络未连接";
                            uiSymbolLabel_InternetDeviceType.Text = "调制解调器上网";
                            uiSymbolLabel_PingOK.Text = "Ping失败";
                            break;
                        }
                    case 5:
                        {
                            //采用网卡上网,但是联不通指定网络
                            uiTitlePanel_NetStatus.TitleColor = Color.DarkOrange;
                            uiTitlePanel_NetStatus.RectColor = Color.DarkOrange;
                            uiAvatar_NetStatus.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.Symbol = 61453;//×，未通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61453;
                            uiSymbolLabel_PingOK.Symbol = 61453;
                            uiSymbolLabel_ConnectCheck.Text = "网络未连接";
                            uiSymbolLabel_InternetDeviceType.Text = "使用网卡上网";
                            uiSymbolLabel_PingOK.Text = "Ping失败";
                            break;
                        }
                }
            });
            netCheckThread.Start();
            timer_AutoConnect.Enabled = true;
            Thread configCheckThread = new Thread(() =>
            {
                if(File.Exists("Account.json") == true)
                {
                    uiSymbolLabe_AccountConfigCheck.Text = "拨号配置正常";
                    savedaccount = JsonConvert.DeserializeObject<DialUpAccount>(File.ReadAllText(@"Account.json", Encoding.UTF8));
                    uiTextBox_DialUpName.Watermark = Decrypt.DES(savedaccount.Name, "latiaonb");
                    uiTextBox_DialUpAccount.Watermark = Decrypt.DES(savedaccount.Account, "latiaonb");
                    uiTextBox_DialUpPassword.Watermark = Decrypt.DES(savedaccount.Password, "latiaonb");
                    uiComboBox_DialUpType.SelectedIndex = uiComboBox_ConnectMethod.SelectedIndex = savedaccount.DialUpType;
                    uiSymbolButton_OneKeyConnect.Enabled = true;
                    if (File.Exists("Config.json") == true)
                    {
                        uiSymbolLabel_SoftConfigCheck.Text = "软件配置正常";
                        softwareConfig = JsonConvert.DeserializeObject<SoftwareConfig>(File.ReadAllText(@"Config.json", Encoding.UTF8));
                        if (softwareConfig.AutoConnect == 1)
                        {
                            _autoConnectTimerLocker = 1;//时钟检测到值的变化后进行自动连接
                            uiCheckBox_AutoConnect.Checked = true;
                        }
                        else
                            _autoConnectTimerLocker = 0;
                        if (softwareConfig.AutoStart == 1)
                            uiCheckBox_AutoStart.Checked = true;
                        if (softwareConfig.AutoReConnect == 1)
                            uiCheckBox_AutoReConnect.Checked = true;

                        uiSymbolButton_ResetConfig.Enabled = true;//只有2个配置文件都存在才能重置
                    }
                    else
                    {
                        uiTitlePanel_Config.TitleColor = Color.DarkOrange;
                        uiTitlePanel_Config.RectColor = Color.DarkOrange;
                        uiSymbolLabel_SoftConfigCheck.ForeColor = Color.DarkOrange;
                        uiSymbolLabel_SoftConfigCheck.SymbolColor = Color.DarkOrange;
                        uiSymbolLabel_SoftConfigCheck.Symbol = 61553;
                        uiSymbolLabel_SoftConfigCheck.Text = "软件配置不存在";
                        _autoConnectTimerLocker = 0;//时钟检测到值的变化后不进行自动连接
                    }
                }
                else
                {
                    uiTitlePanel_Config.TitleColor = Color.DarkOrange;
                    uiTitlePanel_Config.RectColor = Color.DarkOrange;
                    uiSymbolLabel_SoftConfigCheck.ForeColor = Color.DarkOrange;
                    uiSymbolLabel_SoftConfigCheck.SymbolColor = Color.DarkOrange;
                    uiSymbolLabel_SoftConfigCheck.Symbol = 61553;
                    uiComboBox_ConnectMethod.SelectedIndex = 0;
                    uiSymbolLabel_SoftConfigCheck.Text = "拨号配置不存在";
                    if (File.Exists("Config.json") == false)
                    {
                        uiTitlePanel_Config.TitleColor = Color.DarkOrange;
                        uiTitlePanel_Config.RectColor = Color.DarkOrange;
                        uiSymbolLabe_AccountConfigCheck.ForeColor = Color.DarkOrange;
                        uiSymbolLabe_AccountConfigCheck.SymbolColor = Color.DarkOrange;
                        uiSymbolLabe_AccountConfigCheck.Symbol = 61553;
                        uiSymbolLabe_AccountConfigCheck.Text = "软件配置不存在";
                    }
                    _autoConnectTimerLocker = 0;//时钟检测到值的变化后不进行自动连接
                }
            });
            configCheckThread.Start();
            timer_NetChecker.Enabled = true;
        }


        /// <summary>
        /// 选项卡切换的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Aside_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(Aside.SelectedNode.ToString());
            switch (Aside.SelectedNode.ToString())
            {
                case "TreeNode: 状态":
                    {
                        tabControl.SelectedIndex = 0;
                        break;
                    }
                case "TreeNode: 拨号":
                    {
                        tabControl.SelectedIndex = 1;
                        break;
                    }
                case "TreeNode: 自动化":
                    {
                        tabControl.SelectedIndex = 2;
                        break;
                    }
                case "TreeNode: 热键":
                    {
                        tabControl.SelectedIndex = 3;
                        break;
                    }
                case "TreeNode: 关于":
                    {
                        tabControl.SelectedIndex = 4;
                        break;
                    }
                default:
                    {
                        tabControl.SelectedIndex = 0;
                        break;
                    }
            }
        }

        /// <summary>
        /// 判断是否为管理员运行
        /// </summary>
        private bool IsUserAnAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// 拨号设置保存旁边的帮助按钮
        /// </summary>
        private void uiSymbolButton_AccountHelp_Click(object sender, EventArgs e)
        {
            UIMessageDialog.ShowMessageDialog("1.如何选择拨号方式\n校园普遍使用PPPoE的拨号方式，如果拿到的宽带信息中包含了账号密码信息则选择PPPoE方式。相反ADSL只需要填写宽带名\n\n2.宽带名要怎么填写\n一般填写为\"宽带连接\"即可，如果需要使用VPN则要将宽带名设置为英文\n\n3.无法连接\nA:可能需要在拨号设置里先新建一个拨号连接并成功连接一次，宽带名要和连接过的拨号连接名一样\nB:检查用户名或密码是否正确，以及拨号方式是否对应\n\n4.填写的账号密码安全吗\n信息只保存在电脑硬盘中，软件除手动检查更新外无任何联网行为且软件完全开源。保存在电脑中的信息采用目前业界主流DES加密方法，十分安全", "拨号设置帮助", false, Style);
        }

        /// <summary>
        /// 保存账号设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton_SaveAccountConfig_Click(object sender, EventArgs e)
        {
            if(File.Exists("Account.json") == false)
            {
                switch (uiComboBox_DialUpType.SelectedIndex)
                {
                    //PPPoE
                    case 0:
                        {
                            DialUpAccount saveaccount = new DialUpAccount(0, Encrypt.DES(uiTextBox_DialUpName.Text, "latiaonb"), Encrypt.DES(uiTextBox_DialUpAccount.Text, "latiaonb"), Encrypt.DES(uiTextBox_DialUpPassword.Text, "latiaonb"));
                            string json = JsonConvert.SerializeObject(saveaccount);
                            try
                            {
                                File.WriteAllText(@"Account.json", json);
                            }
                            catch(Exception ex)
                            {
                                ShowErrorDialog("异常捕获", string.Format("保存账号配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}",ex.Message,ex.Source));
                            }
                            finally
                            {
                                UIMessageDialog.ShowMessageDialog("已保存完毕，需要重启软件\n点击确认后软件自动重启", "提示", false, Style);
                                Application.Exit();
                                Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                            }
                            break;
                        }
                    //ADSL
                    case 1:
                        {
                            DialUpAccount saveaccount = new DialUpAccount(1, Encrypt.DES(uiTextBox_DialUpName.Text, "latiaonb"), "none","none");
                            string json = JsonConvert.SerializeObject(saveaccount);
                            try
                            {
                                File.WriteAllText(@"Account.json", json);
                            }
                            catch (Exception ex)
                            {
                                ShowErrorDialog("异常捕获", string.Format("保存账号配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}", ex.Message, ex.Source));
                            }
                            finally
                            {
                                UIMessageDialog.ShowMessageDialog("已保存完毕，需要重启软件\n点击确认后软件自动重启", "提示", false, Style);
                                notifyIcon_MainForm.Dispose();
                                Application.Exit();
                                Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                            }
                            break;
                        }
                    //没选
                    case -1:
                        {
                            ShowErrorDialog("错误","由于未选择拨号方式，保存账号配置失败\n请在选择拨号方式后重试");
                            break;
                        }
                }
            }
            else
            {
                if (ShowAskDialog("账号配置文件已经存在，是否需要以当前配置覆盖旧的账号配置？\n如果覆盖，旧的配置将永久失去"))
                {
                    switch (uiComboBox_DialUpType.SelectedIndex)
                    {
                        //PPPoE
                        case 0:
                            {
                                DialUpAccount saveaccount = new DialUpAccount(0, Encrypt.DES(uiTextBox_DialUpName.Text, "latiaonb"), Encrypt.DES(uiTextBox_DialUpAccount.Text, "latiaonb"), Encrypt.DES(uiTextBox_DialUpPassword.Text, "latiaonb"));
                                string json = JsonConvert.SerializeObject(saveaccount);
                                try
                                {
                                    File.WriteAllText(@"Account.json", json);
                                }
                                catch (Exception ex)
                                {
                                    ShowErrorDialog("异常捕获", string.Format("保存账号配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}", ex.Message, ex.Source));
                                }
                                finally
                                {
                                    UIMessageDialog.ShowMessageDialog("已保存完毕，需要重启软件\n点击确认后软件自动重启", "提示", false, Style);
                                    notifyIcon_MainForm.Dispose();
                                    Application.Exit();
                                    Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                }
                                break;
                            }
                        //ADSL
                        case 1:
                            {
                                DialUpAccount saveaccount = new DialUpAccount(1, Encrypt.DES(uiTextBox_DialUpName.Text, "latiaonb"), "none", "none");
                                string json = JsonConvert.SerializeObject(saveaccount);
                                try
                                {
                                    File.WriteAllText(@"Account.json", json);
                                }
                                catch (Exception ex)
                                {
                                    ShowErrorDialog("异常捕获", string.Format("保存账号配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}", ex.Message, ex.Source));
                                }
                                finally
                                {
                                    UIMessageDialog.ShowMessageDialog("已保存完毕，需要重启软件\n点击确认后软件自动重启", "提示", false, Style);
                                    Application.Exit();
                                    Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                }
                                break;
                            }
                        //没选
                        case -1:
                            {
                                ShowErrorDialog("错误", "由于未选择拨号方式，保存账号配置失败\n请在选择拨号方式后重试");
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// 根据配置文件一键连接
        /// </summary>
        private void uiSymbolButton_OneKeyConnect_Click(object sender, EventArgs e)
        {
            timer_AutoReConnect.Enabled = false;
            if (uiComboBox_ConnectMethod.SelectedIndex != -1)
            {
                if(savedaccount.DialUpType >= 0 && savedaccount.Name != "解密失败" && savedaccount.Account !="解密失败" && savedaccount.Password != "解密失败")
                {
                    uiSymbolButton_OneKeyConnect.Enabled = false;
                    uiProcessBar_ConectProcess.Visible = true;
                    switch (uiComboBox_ConnectMethod.SelectedIndex)
                    {
                        case 0:
                            {
                                Process p = new Process();//新建一个进程对象
                                uiProcessBar_ConectProcess.Value = 15;
                                p.StartInfo.FileName = "Rasdial.exe";//设置要启动的进程名字
                                uiProcessBar_ConectProcess.Value = 30;
                                p.StartInfo.Arguments = Decrypt.DES(savedaccount.Name, "latiaonb") + " " + Decrypt.DES(savedaccount.Account, "latiaonb") + " " + Decrypt.DES(savedaccount.Password, "latiaonb");//传递参数 格式 连接名字+空格+账号+空格+密码
                                uiProcessBar_ConectProcess.Value = 45;
                                //Console.WriteLine(p.StartInfo.Arguments);
                                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//设置执行时的控制台为隐藏的
                                uiProcessBar_ConectProcess.Value = 60;
                                p.Start();//开始执行
                                uiProcessBar_ConectProcess.Value = 75;
                                p.WaitForExit();//等待连接后自动退出
                                uiProcessBar_ConectProcess.Value = 90;
                                if (p.ExitCode == 0)//通过退出返回的代码判断连接是否成功
                                {
                                    Toast.ShowNotifiy("一键连接", String.Format("状态:宽带连接成功\n宽带名称:{0}\n宽带账号:{1}", Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb")), Notifications.Wpf.NotificationType.Success);
                                }
                                else
                                {
                                    Toast.ShowNotifiy("一键连接", String.Format("状态:宽带连接失败\n宽带名称:{0}\n宽带账号:{1}", Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb")), Notifications.Wpf.NotificationType.Error);
                                }
                                uiProcessBar_ConectProcess.Value = 100;
                                uiProcessBar_ConectProcess.Visible = false;
                                break;
                            }
                        case 1:
                            {
                                MessageBox.Show("尚未实现PPPoE，请等待更新");
                                break;
                            }
                    }
                    uiSymbolButton_OneKeyConnect.Enabled = true;
                }
                else
                {
                    ShowErrorDialog("错误", "拨号账号配置文件解密失败，请重置后重试");
                }
            }
            else
            {
                ShowErrorDialog("错误", "由于未选择拨号方式，连接网络失败\n请在选择拨号方式后重试");
            }
            timer_AutoReConnect.Enabled = true;
        }

        /// <summary>
        /// 时钟循环检查网络状态
        /// </summary>
        private void timer_NetChecker_Tick(object sender, EventArgs e)
        {
            Thread netCheckThread = new Thread(() =>
            {
                switch (GetInternetConStatus.GetNetConStatus("baidu.com"))//GetInternetConStatus.GetNetConStatus("baidu.com")
                {
                    case 1:
                        {
                            //网络未连接
                            uiTitlePanel_NetStatus.TitleColor = Color.DarkOrange;
                            uiTitlePanel_NetStatus.RectColor = Color.DarkOrange;
                            uiAvatar_NetStatus.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.Symbol = 61453;//×，未通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61453;
                            uiSymbolLabel_PingOK.Symbol = 61453;
                            uiSymbolLabel_ConnectCheck.Text = "网络未连接";
                            uiSymbolLabel_InternetDeviceType.Text = "上网类型未知";
                            uiSymbolLabel_PingOK.Text = "Ping失败";
                            _autoReConnectFlag = 0;
                            break;
                        }
                    case 2:
                        {
                            //采用调制解调器上网
                            uiTitlePanel_NetStatus.TitleColor = Color.FromArgb(80, 160, 255);
                            uiTitlePanel_NetStatus.RectColor = Color.FromArgb(80, 160, 255);
                            uiAvatar_NetStatus.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_PingOK.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_PingOK.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.Symbol = 61452;//钩，通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61452;
                            uiSymbolLabel_PingOK.Symbol = 61452;
                            uiSymbolLabel_ConnectCheck.Text = "网络已连接";
                            uiSymbolLabel_InternetDeviceType.Text = "调制解调器上网";
                            uiSymbolLabel_PingOK.Text = "Ping正常";
                            _autoReConnectFlag = 1;
                            break;
                        }
                    case 3:
                        {
                            //采用网卡上网
                            uiTitlePanel_NetStatus.TitleColor = Color.FromArgb(80, 160, 255);
                            uiTitlePanel_NetStatus.RectColor = Color.FromArgb(80, 160, 255);
                            uiAvatar_NetStatus.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_PingOK.ForeColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_PingOK.SymbolColor = Color.FromArgb(80, 160, 255);
                            uiSymbolLabel_ConnectCheck.Symbol = 61452;//钩，通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61452;
                            uiSymbolLabel_PingOK.Symbol = 61452;
                            uiSymbolLabel_ConnectCheck.Text = "网络已连接";
                            uiSymbolLabel_InternetDeviceType.Text = "使用网卡上网";
                            uiSymbolLabel_PingOK.Text = "Ping正常";
                            _autoReConnectFlag = 1;
                            break;
                        }
                    case 4:
                        {
                            //采用调制解调器上网,但是联不通指定网络
                            uiTitlePanel_NetStatus.TitleColor = Color.DarkOrange;
                            uiTitlePanel_NetStatus.RectColor = Color.DarkOrange;
                            uiAvatar_NetStatus.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.Symbol = 61453;//×，未通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61453;
                            uiSymbolLabel_PingOK.Symbol = 61453;
                            uiSymbolLabel_ConnectCheck.Text = "网络未连接";
                            uiSymbolLabel_InternetDeviceType.Text = "调制解调器上网";
                            uiSymbolLabel_PingOK.Text = "Ping失败";
                            _autoReConnectFlag = 0;
                            break;
                        }
                    case 5:
                        {
                            //采用网卡上网,但是联不通指定网络
                            uiTitlePanel_NetStatus.TitleColor = Color.DarkOrange;
                            uiTitlePanel_NetStatus.RectColor = Color.DarkOrange;
                            uiAvatar_NetStatus.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_InternetDeviceType.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.ForeColor = Color.DarkOrange;
                            uiSymbolLabel_PingOK.SymbolColor = Color.DarkOrange;
                            uiSymbolLabel_ConnectCheck.Symbol = 61453;//×，未通过
                            uiSymbolLabel_InternetDeviceType.Symbol = 61453;
                            uiSymbolLabel_PingOK.Symbol = 61453;
                            uiSymbolLabel_ConnectCheck.Text = "网络未连接";
                            uiSymbolLabel_InternetDeviceType.Text = "使用网卡上网";
                            uiSymbolLabel_PingOK.Text = "Ping失败";
                            _autoReConnectFlag = 0;
                            break;
                        }
                }
                Console.WriteLine("Timer NetCheck success");
            });
            netCheckThread.Start();
        }

        /// <summary>
        /// 保存软件设置
        /// 如果此前已有配置文件，那么看之前的配置文件的开机自启是开还是关，然后设置反，故与第一次设置不同
        /// </summary>
        private void uiSymbolButton_SaveSoftwareConfig_Click(object sender, EventArgs e)
        {
            if (File.Exists("Config.json") == false)
            {
                SoftwareConfig newSoftwareConfig = new SoftwareConfig()
                {
                    AutoStart = uiCheckBox_AutoStart.Checked == true ? 1 : 0,
                    AutoConnect = uiCheckBox_AutoConnect.Checked == true ? 1 : 0,
                    AutoReConnect = uiCheckBox_AutoReConnect.Checked == true ? 1 : 0,
                    ReConnectCount = uiIntegerUpDown_ReConnectCount.Value
                };
                string json = JsonConvert.SerializeObject(newSoftwareConfig);
                //MessageBox.Show(json);
                try
                {
                    if(uiCheckBox_AutoStart.Checked == true)
                    {
                        ShowWaitForm("正在设置开机自动启动...");
                        AutoStart start = new AutoStart();
                        start.SetMeAutoStart(true);
                        SetWaitFormDescription("开机自动启动设置成功");
                        Thread.Sleep(1000);
                        SetWaitFormDescription("正在保存配置文件...");
                        Thread.Sleep(1000);
                        File.WriteAllText(@"Config.json", json);
                        HideWaitForm();
                    }
                    else//不用设置开机自启 所以只需要写配置文件就好
                    {
                        File.WriteAllText(@"Config.json", json);
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorDialog("异常捕获", string.Format("保存软件配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}", ex.Message, ex.Source));
                }
                finally
                {
                    UIMessageDialog.ShowMessageDialog("已保存完毕，需要重启软件\n点击确认后软件自动重启", "提示", false, Style);
                    notifyIcon_MainForm.Dispose();
                    Application.Exit();
                    Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
            }
            else
            {
                if (ShowAskDialog("软件配置文件已经存在，是否需要以当前配置覆盖旧的账号配置？\n如果覆盖，旧的配置将永久失去"))
                {
                    if(softwareConfig != null)
                    {
                        SoftwareConfig newSoftwareConfig = new SoftwareConfig()
                        {
                            AutoStart = uiCheckBox_AutoStart.Checked == true ? 1 : 0,
                            AutoConnect = uiCheckBox_AutoConnect.Checked == true ? 1 : 0,
                            AutoReConnect = uiCheckBox_AutoReConnect.Checked == true ? 1 : 0,
                            ReConnectCount = uiIntegerUpDown_ReConnectCount.Value
                        };
                        string json = JsonConvert.SerializeObject(newSoftwareConfig);
                        try
                        {
                            File.Delete(@"Config.json");//先前已存在配置文件，需要先删除再重新写
                            File.WriteAllText(@"Config.json", json);
                        }
                        catch(Exception ex)
                        {
                            UIMessageDialog.ShowMessageDialog("软件无法覆盖先前保存的配置文件\n尝试将软件目录下的\"Config\"文件手动删除后进行保存配置\n点击确定后软件自动打开软件所在目录并定位配置文件", "提示", false, Style);
                            OpenFolder.OpenFolderAndSelectedFile(Environment.CurrentDirectory + @"\Config.json");
                            goto Final;
                        }
                        bool ifAutoStartBefore = softwareConfig.AutoStart == 1 ? true : false;
                        if(uiCheckBox_AutoStart.Checked != ifAutoStartBefore)
                        {
                            if(uiCheckBox_AutoStart.Checked == true)
                            {
                                ShowWaitForm("正在设置开机自动启动...");
                                AutoStart start = new AutoStart();
                                start.SetMeAutoStart(true);
                                SetWaitFormDescription("开机自动启动设置成功");
                                Thread.Sleep(1500);
                                HideWaitForm();
                            }
                            else
                            {
                                ShowWaitForm("正在取消开机自动启动...");
                                AutoStart start = new AutoStart();
                                start.SetMeAutoStart(false);
                                SetWaitFormDescription("开机自动启动已成功取消");
                                Thread.Sleep(1500);
                                HideWaitForm();
                            }
                        }
                    Final: Console.WriteLine("覆盖设置文件操作已完成");
                    }
                    else
                    {
                        UIMessageDialog.ShowMessageDialog("软件无法解析先前保存的配置文件\n尝试将软件目录下的\"Config\"文件手动删除后重新打开软件进行保存配置\n点击确定后软件自动关闭并打开软件所在目录并定位配置文件", "提示", false, Style);
                        //Process.Start(Environment.CurrentDirectory);
                        OpenFolder.OpenFolderAndSelectedFile(Environment.CurrentDirectory + @"\Config.json");
                        notifyIcon_MainForm.Dispose();
                        Application.Exit();
                    }
                }
            }
        }

        /// <summary>
        /// 利用时钟循环检测Locker来实现UI主线程操作来进行启动时自动连接网络，避开了Dispatcher的使用
        /// Locker值：1为设置了自动连接，0为没有设置，同时如果有10个周期都等于-1可能是线程出现问题，先把时钟终止了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_AutoConnect_Tick(object sender, EventArgs e)
        {
            if(_autoConnectTimerLocker == 1)
            {
                if (softwareConfig != null)
                {
                    if (File.Exists(@"Account.json") == true && savedaccount.DialUpType >= 0 && savedaccount.Name != "解密失败" && savedaccount.Account != "解密失败" && savedaccount.Password != "解密失败")//最后判断一下账号配置文件存不存在，存在再进行重连
                    {
                        timer_AutoConnect.Interval = 5201314;//先挂起时钟避免多次连接
                        if (PPPoE.Connect(Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb"), Decrypt.DES(savedaccount.Password, "latiaonb")) == 1)
                        {
                            Toast.ShowNotifiy("自动连接", String.Format("状态:宽带自动连接成功\n宽带名称:{0}\n宽带账号:{1}", Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb")), Notifications.Wpf.NotificationType.Success);
                        }
                        else
                        {
                            Toast.ShowNotifiy("自动连接", String.Format("状态:宽带自动连接失败\n宽带名称:{0}\n宽带账号:{1}", Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb")), Notifications.Wpf.NotificationType.Error);
                        }
                    }
                    else
                        Toast.ShowNotifiy("自动连接", "由于宽带配置文件缺失或内容有误，无法进行自动连接 - 2", Notifications.Wpf.NotificationType.Error);
                }
                else
                    Toast.ShowNotifiy("自动连接", "由于宽带配置文件缺失或内容有误，无法进行自动连接", Notifications.Wpf.NotificationType.Error);
                //Toast.ShowNotifiy("Title", "你设置了自动连接网络", Notifications.Wpf.NotificationType.Information);
                timer_AutoConnect.Enabled = false;//不管连没连上，只连一次
            }
            else
            {
                if (_autoConnectTimerLocker == 0)
                    timer_AutoConnect.Enabled = false;
                else
                {
                    //这里是等待线程里读取配置读好留的缓冲时间，如果10次都等不到那就把时钟关掉
                    _autoConnectTimerLocker = _autoConnectTimerLocker + 10;
                    if(_autoConnectTimerLocker >= 100)
                        timer_AutoConnect.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 使用持续检测断网并自动重新连接
        /// </summary>
        private void timer_AutoReConnect_Tick(object sender, EventArgs e)
        {
            if (timer_AutoReConnect.Interval == 60000) //连接成功后60秒后才会重新检测，如果是重新检测则把时钟恢复常态
                timer_AutoReConnect.Interval = 6000;
            if (softwareConfig != null)
            {
                if(softwareConfig.AutoReConnect == 1)//判断用户有没有启用自动重连功能 如果没有启用该功能则时钟自动禁用
                {
                    if (_autoReConnectFlag == 0)//检测网络状态是线程，无法直接操作时钟，通过Flag的Locker形式来间接操作时钟
                    {
                        if(File.Exists(@"Account.json") == true && savedaccount.DialUpType >= 0 && savedaccount.Name != "解密失败" && savedaccount.Account != "解密失败" && savedaccount.Password != "解密失败")//最后判断一下账号配置文件存不存在，存在再进行重连
                        {
                            Console.WriteLine("网络断开，需要连接");
                            int tempReConnectCount = 0;
                            timer_AutoReConnect.Interval = 5201314;//在重连的时候先挂起时钟避免重连两次
                            for (int i = 1; i <= softwareConfig.ReConnectCount; i++)
                            {
                                //Thread.Sleep(1000);
                                if (PPPoE.Connect(Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb"), Decrypt.DES(savedaccount.Password, "latiaonb")) == 1)
                                {
                                    Toast.ShowNotifiy("自动重连", "检测到网络断开，已自动重连成功", Notifications.Wpf.NotificationType.Success);
                                    _autoReConnectFlag = 1;//把tag置为1以免重复重连导致软件主线程阻塞时间变长
                                    timer_AutoReConnect.Interval = 60000;//重连成功后避免多次重连导致拨号故障，下一次重连设置为60秒后
                                    break;
                                }
                                else
                                {
                                    tempReConnectCount++;
                                    if (tempReConnectCount >= softwareConfig.ReConnectCount)
                                    {
                                        //这里需要做一个如果重连失败后就不再重连了，避免软件很卡，但是持续检测网络是在线程中进行，无法操作时钟，需要一个tag，在下次更新中进行实现
                                        //Toast.ShowNotifiy("自动重连", "检测到网络断开，且自动重连失败\n已临时关闭自动重连功能避免软件卡死，手动连接网络成功后自动重连功能会再次开启", Notifications.Wpf.NotificationType.Error);
                                        Toast.ShowNotifiy("自动重连", "检测到网络断开，且自动重连全部失败", Notifications.Wpf.NotificationType.Error);
                                        timer_AutoReConnect.Interval = 6000;//重连失败，继续重连，后期改
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("持续检测断网时钟已停用,原因是用户没有开启功能");
                    timer_AutoReConnect.Enabled = false;
                }
            }
            else
            {
                Console.WriteLine("持续检测断网时钟已停用,原因是软件配置不存在");
                timer_AutoReConnect.Enabled = false;//如果software是null则没有软件设置，直接把时钟停用
            }
                
        }

        /// <summary>
        /// 主窗口最小化时隐藏任务栏图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon_MainForm.Visible = true;
                //隐藏Alt+Tab中的窗口
                this.Visible = false;
                //更改Text为最小化运行中
                this.notifyIcon_MainForm.Text = "自动拨号器 - 后台运行中";
                软件状态ToolStripMenuItem.Text = "自动拨号器 - 后台运行中";//托盘菜单中的软件状态
                Toast.ShowNotifiy("自动拨号器 - 托盘","自动拨号器仍在后台运行中\n如需还原窗口请单击右下角托盘图标",Notifications.Wpf.NotificationType.Information);
            }
        }

        /// <summary>
        /// 单击托盘图标来还原窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //还原窗体显示
                    WindowState = FormWindowState.Normal;
                    //激活窗体并给予它焦点
                    this.Activate();
                    //任务栏区显示图标
                    this.ShowInTaskbar = true;
                    //显示Alt+Tab中的窗口
                    this.Visible = true;
                    //更改Text为运行中
                    this.notifyIcon_MainForm.Text = "自动拨号器 - 运行中";
                    软件状态ToolStripMenuItem.Text = "自动拨号器 - 运行中";//托盘菜单中的软件状态
                    Toast.ShowNotifiy("自动拨号器 - 托盘", "自动拨号器已恢复前台运行\n如需关闭软件请点击右上角退出", Notifications.Wpf.NotificationType.Success);
                }
            }
        }

        private void 一键连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiSymbolButton_OneKeyConnect_Click(new object(),new EventArgs());
        }

        private void 退出软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon_MainForm.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// 窗口关闭前释放托盘图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon_MainForm.Dispose();
        }

        private void uiSymbolButton_ProjectPage_Click(object sender, EventArgs e)
        {
            Process.Start("https://xn--e-5g8az75bbi3a.com/%E9%A1%B9%E7%9B%AE%E5%8F%91%E5%B8%83/10.html");
        }

        private void uiSymbolButton_SourceAddress_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/EJianZQ/AutoDialUp");
        }

        private void uiSymbolButton_CheckUpdate_Click(object sender, EventArgs e)
        {
            Process.Start("https://xn--e-5g8az75bbi3a.com/%E9%A1%B9%E7%9B%AE%E5%8F%91%E5%B8%83/10.html");
        }
    }
}