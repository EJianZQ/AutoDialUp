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
using AutoDialUp.Net;
using Newtonsoft.Json;
using Application = System.Windows.Forms.Application;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using static AutoDialUp.Data.TimePlan;
using System.Drawing.Text;
using System.Web.UI.Design;
using Version = AutoDialUp.Data.Version;

namespace AutoDialUp
{
    public enum CustomColor
    {
        Success,
        Information,
        Worring,
        Error
    }
    public partial class MainForm : UIForm
    {
        RASDisplay ras = new RASDisplay();
        DialUpAccount savedaccount = new DialUpAccount();
        HotKeyConfig hotkeyconfig = new HotKeyConfig();
        SoftwareConfig softwareConfig = null;
        int _autoConnectTimerLocker = -1;
        int _autoReConnectFlag = -1;//0是未联网，1是已联网
        int successConnectCount = 0;
        int _versionCheckLocker = 0;//获取网络上的版本信息只获取一次
        Thread _timePlanEveryDayRefreshThread;
        DateTime[] runTimeRecord = new DateTime[2];
        List<string> timePlanSourceData = new List<string>();
        OneDay Today = new OneDay(true);
        Version versionData = new Version();
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
            Aside.CreateChildNode(parent, "时间段", 61463, 12, ++pageIndex);
            parent = Aside.CreateNode("日志", 61747, 30, ++pageIndex);
            parent = Aside.CreateNode("关于", 61638, 30, ++pageIndex);
            tabControl.Region = new Region(new RectangleF(tabPage_Status.Left, tabPage_Status.Top + 5, tabPage_Status.Width, tabPage_Status.Height + 5)); //隐藏tabcontrol的选项卡
            runTimeRecord[0] = DateTime.Now;//记录开始运行的时间
            RegisterHotKey(Sunny.UI.ModifierKeys.None,Keys.Escape);
            RegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F5);
            RegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F7);
            RegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F8);
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
                            LogAppend(CustomColor.Error, "[线程检测网络]网络未连接 - 1");
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
                            _autoReConnectFlag = 1;
                            LogAppend(CustomColor.Success, "[线程检测网络]网络已连接 - 2");
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
                            _autoReConnectFlag = 1;
                            LogAppend(CustomColor.Success, "[线程检测网络]网络已连接 - 3");
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
                            LogAppend(CustomColor.Error, "[线程检测网络]网络未连接 - 4");
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
                            LogAppend(CustomColor.Error, "[线程检测网络]网络未连接 - 5");
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
                    LogAppend(CustomColor.Success, "账号配置文件解析完毕");
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
                        LogAppend(CustomColor.Success, "软件配置文件解析完毕");
                    }
                    else
                    {
                        uiTitlePanel_Config.TitleColor = Color.DarkOrange;
                        uiTitlePanel_Config.RectColor = Color.DarkOrange;
                        uiSymbolLabel_SoftConfigCheck.ForeColor = Color.DarkOrange;
                        uiSymbolLabel_SoftConfigCheck.SymbolColor = Color.DarkOrange;
                        uiSymbolLabel_SoftConfigCheck.Symbol = 61553;
                        uiSymbolLabel_SoftConfigCheck.Text = "软件配置不存在";
                        LogAppend(CustomColor.Worring, "软件配置文件不存在");
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
                    LogAppend(CustomColor.Worring, "拨号配置文件不存在");
                    if (File.Exists("Config.json") == false)
                    {
                        uiTitlePanel_Config.TitleColor = Color.DarkOrange;
                        uiTitlePanel_Config.RectColor = Color.DarkOrange;
                        uiSymbolLabe_AccountConfigCheck.ForeColor = Color.DarkOrange;
                        uiSymbolLabe_AccountConfigCheck.SymbolColor = Color.DarkOrange;
                        uiSymbolLabe_AccountConfigCheck.Symbol = 61553;
                        uiSymbolLabe_AccountConfigCheck.Text = "软件配置不存在";
                        LogAppend(CustomColor.Worring, "软件配置文件不存在");
                    }
                    _autoConnectTimerLocker = 0;//时钟检测到值的变化后不进行自动连接
                }
                //热键配置文件是独立检查的
                if(File.Exists(@"HotKey.json") == true)
                {
                    hotkeyconfig = JsonConvert.DeserializeObject<HotKeyConfig>(File.ReadAllText(@"HotKey.json", Encoding.UTF8));
                    uiCheckBox_HotKey_Esc.Checked = hotkeyconfig.Esc ==1 ? true : false;
                    uiCheckBox_HotKey_ShiftF5.Checked = hotkeyconfig.ShiftF5 == 1 ? true : false;
                    uiCheckBox_HotKey_ShiftF6.Checked = hotkeyconfig.ShiftF6 == 1 ? true : false;
                    uiCheckBox_HotKey_ShiftF7.Checked = hotkeyconfig.ShiftF7 == 1 ? true : false;
                    uiCheckBox_HotKey_ShiftF8.Checked = hotkeyconfig.ShiftF8 == 1 ? true : false;
                }
                else
                    LogAppend(CustomColor.Worring, "热键配置文件不存在");
                LogAppend(CustomColor.Success,"所有配置文件检查完毕");
            });
            configCheckThread.Start();
            timer_NetChecker.Enabled = true;
            Thread timePlanCheckThread = new Thread(() =>
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Mon.json"))
                {
                    DaysCollections.Mon = JsonConvert.DeserializeObject<OneDay>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Mon.json", Encoding.UTF8));
                    DaysCollections.Mon.Initialized = true;
                    timePlanSourceData.Add(String.Format("星期一 - 已设置 - {0} ~ {1}", DaysCollections.Mon.StartTime, DaysCollections.Mon.EndTime));
                }
                else
                {
                    DaysCollections.Mon = new OneDay(false);
                    timePlanSourceData.Add("星期一 - 未设置");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Tues.json"))
                {
                    DaysCollections.Tues = JsonConvert.DeserializeObject<OneDay>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Tues.json", Encoding.UTF8));
                    DaysCollections.Tues.Initialized = true;
                    timePlanSourceData.Add(String.Format("星期二 - 已设置 - {0} ~ {1}", DaysCollections.Tues.StartTime, DaysCollections.Tues.EndTime));
                }
                else
                {
                    DaysCollections.Tues = new OneDay(false);
                    timePlanSourceData.Add("星期二 - 未设置");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Wed.json"))
                {
                    DaysCollections.Wed = JsonConvert.DeserializeObject<OneDay>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Wed.json", Encoding.UTF8));
                    DaysCollections.Wed.Initialized = true;
                    timePlanSourceData.Add(String.Format("星期三 - 已设置 - {0} ~ {1}", DaysCollections.Wed.StartTime, DaysCollections.Wed.EndTime));
                }
                else
                {
                    DaysCollections.Wed = new OneDay(false);
                    timePlanSourceData.Add("星期三 - 未设置");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Thur.json"))
                {
                    DaysCollections.Thur = JsonConvert.DeserializeObject<OneDay>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Thur.json", Encoding.UTF8));
                    DaysCollections.Thur.Initialized = true;
                    timePlanSourceData.Add(String.Format("星期四 - 已设置 - {0} ~ {1}", DaysCollections.Thur.StartTime, DaysCollections.Thur.EndTime));
                }
                else
                {
                    DaysCollections.Thur = new OneDay(false);
                    timePlanSourceData.Add("星期四 - 未设置");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Fri.json"))
                {
                    DaysCollections.Fri = JsonConvert.DeserializeObject<OneDay>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Fri.json", Encoding.UTF8));
                    DaysCollections.Fri.Initialized = true;
                    timePlanSourceData.Add(String.Format("星期五 - 已设置 - {0} ~ {1}", DaysCollections.Fri.StartTime, DaysCollections.Fri.EndTime));
                }
                else
                {
                    DaysCollections.Fri = new OneDay(false);
                    timePlanSourceData.Add("星期五 - 未设置");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Sat.json"))
                {
                    DaysCollections.Sat = JsonConvert.DeserializeObject<OneDay>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Sat.json", Encoding.UTF8));
                    DaysCollections.Sat.Initialized = true;
                    timePlanSourceData.Add(String.Format("星期六 - 已设置 - {0} ~ {1}", DaysCollections.Sat.StartTime, DaysCollections.Sat.EndTime));
                }
                else
                {
                    DaysCollections.Sat = new OneDay(false);
                    timePlanSourceData.Add("星期六 - 未设置");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Sun.json"))
                {
                    DaysCollections.Sun = JsonConvert.DeserializeObject<OneDay>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TimePlan\\Sun.json", Encoding.UTF8));
                    DaysCollections.Sun.Initialized = true;
                    timePlanSourceData.Add(String.Format("星期日 - 已设置 - {0} ~ {1}", DaysCollections.Sun.StartTime, DaysCollections.Sun.EndTime));
                }
                else
                {
                    DaysCollections.Sun = new OneDay(false);
                    timePlanSourceData.Add("星期日 - 未设置");
                }

                if(timePlanSourceData.Count == 7)
                {
                    uiComboBox_SelectWhichDay.DataSource = timePlanSourceData;
                }

                switch (TimePlan.WhichDay())
                {
                    case 1:
                        {
                            Today = DaysCollections.Mon;
                            break;
                        }
                    case 2:
                        {
                            Today = DaysCollections.Tues;
                            break;
                        }
                    case 3:
                        {
                            Today = DaysCollections.Wed;
                            break;
                        }
                    case 4:
                        {
                            Today = DaysCollections.Thur;
                            break;
                        }
                    case 5:
                        {
                            Today = DaysCollections.Fri;
                            break;
                        }
                    case 6:
                        {
                            Today = DaysCollections.Sat;
                            break;
                        }
                    case 7:
                        {
                            Today = DaysCollections.Sun;
                            break;
                        }
                }
                //MessageBox.Show(Today.Check().ToString());
            });
            timePlanCheckThread.Start();
            Thread timePlanEveryDayRefreshThread = new Thread(() =>
            {
                //此线程的目的旨在每到新的一天程序就会自杀并重启，省去校验日期的麻烦，后期也可能会改
                for(; ; )
                {
                    if(DateTime.Now.DayOfWeek != runTimeRecord[0].DayOfWeek)
                    {
                        //先写出日志再释放图标最后重启
                        runTimeRecord[1] = DateTime.Now;
                        TimeSpan ts = runTimeRecord[1] - runTimeRecord[0];
                    Start: if (Directory.Exists("Log"))
                        {
                            try
                            {
                                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Log\\" + String.Format("{0}~{1}.txt", runTimeRecord[0].ToString("MM月dd日HH时mm分ss秒"), runTimeRecord[1].ToString("HH时mm分ss秒")), "此次总运行时间：" + ts.ToString() + Environment.NewLine + uiRichTextBox_Log.Text);
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                Directory.CreateDirectory("Log");
                                goto Start;
                            }
                            catch { }
                        }
                        Thread.Sleep(500);
                        notifyIcon_MainForm.Dispose();
                        Application.Exit();
                        Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    Thread.Sleep(60000);
                }
            });
            timePlanEveryDayRefreshThread.Start();
            _timePlanEveryDayRefreshThread = timePlanEveryDayRefreshThread;
            LogAppend(CustomColor.Information, "主窗口初始化事件处理完毕");
            #region 测试功能区
            /*OneDay testDay = new OneDay();
            MessageBox.Show(testDay.StartTime.ToString());*/
            #endregion
        }

        /// <summary>
        /// 向日志框添加日志
        /// </summary>
        /// <param name="text"></param>
        public void LogAppend(CustomColor customcolor,string text)
        {
            try
            {
                Color color = Color.Black;
                switch (customcolor)
                {
                    case CustomColor.Success:
                        {
                            color = Color.FromArgb(0, 139, 0);
                            break;
                        }
                    case CustomColor.Information:
                        {
                            color = Color.FromArgb(0, 46, 166);
                            break;
                        }
                    case CustomColor.Worring:
                        {
                            color = Color.FromArgb(255, 119, 15);
                            break;
                        }
                    case CustomColor.Error:
                        {
                            color = Color.FromArgb(215, 0, 15);
                            break;
                        }
                }
                uiRichTextBox_Log.SelectionColor = color;
                uiRichTextBox_Log.AppendText(string.Format("[{0:T}]:", DateTime.Now) + text + Environment.NewLine);
                //内容过多时防止内存溢出自动清理
                if (uiRichTextBox_Log.Text.Length >= 20000)
                {
                    uiRichTextBox_Log.Text = String.Empty;
                    LogAppend(CustomColor.Information, "由于日志内容过多，防止软件崩溃已自动清理");
                }
            }
            catch { }
        }

        private void VersionDataCheck()
        {
            try
            {
                versionData = JsonConvert.DeserializeObject<Version>(GetMethod.Get("https://data.xn--e-5g8az75bbi3a.com/AutoDialUp/Version.json"));
                uiLabel_SoftwareName.Text = versionData.SoftwareName;
                uiSymbolLabel_VersionNumber.Text = versionData.VersionNumber.ToString();
                uiSymbolButton_CheckUpdate.Enabled = true;
            }
            catch { }
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
                        LogAppend(CustomColor.Information, "用户切换到了状态页面");
                        break;
                    }
                case "TreeNode: 拨号":
                    {
                        tabControl.SelectedIndex = 1;
                        LogAppend(CustomColor.Information, "用户切换到了拨号设置页面");
                        break;
                    }
                case "TreeNode: 自动化":
                    {
                        tabControl.SelectedIndex = 2;
                        LogAppend(CustomColor.Information, "用户切换到了自动化软件设置页面");
                        break;
                    }
                case "TreeNode: 热键":
                    {
                        tabControl.SelectedIndex = 3;
                        LogAppend(CustomColor.Information, "用户切换到了热键设置页面");
                        break;
                    }
                case "TreeNode: 时间段":
                    {
                        tabControl.SelectedIndex = 4;
                        LogAppend(CustomColor.Information, "用户切换到了时间段设置页面");
                        break;
                    }
                case "TreeNode: 日志":
                    {
                        tabControl.SelectedIndex = 5;
                        LogAppend(CustomColor.Information, "用户切换到了日志页面");
                        break;
                    }
                case "TreeNode: 关于":
                    {
                        tabControl.SelectedIndex = 6;
                        LogAppend(CustomColor.Information, "用户切换到了关于页面");
                        break;
                    }
                default:
                    {
                        tabControl.SelectedIndex = 0;
                        LogAppend(CustomColor.Information, "用户切换到了未知页面，自动跳转到主页");
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
                                LogAppend(CustomColor.Error, "保存账号配置文件失败：写文件时异常");
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
                                LogAppend(CustomColor.Error, "保存账号配置文件失败：写文件时异常");
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
                                    LogAppend(CustomColor.Error, "保存账号配置文件失败：写文件时异常");
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
                                    LogAppend(CustomColor.Error, "保存账号配置文件失败：写文件时异常");
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
                    int tempNetChecker = GetInternetConStatus.GetNetConStatus("baidu.com");
                    if(tempNetChecker == 1 || tempNetChecker == 4 || tempNetChecker == 5)
                    {
                        uiProcessBar_ConectProcess.Visible = true;
                        LogAppend(CustomColor.Information, "开始一键连接");
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
                                        LogAppend(CustomColor.Information, "一键连接成功");
                                    }
                                    else
                                    {
                                        Toast.ShowNotifiy("一键连接", String.Format("状态:宽带连接失败\n宽带名称:{0}\n宽带账号:{1}", Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb")), Notifications.Wpf.NotificationType.Error);
                                        LogAppend(CustomColor.Error, "一键连接失败");
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
                    }
                    else
                        ShowErrorDialog("错误", "由于网络已处于连接状态，无须一键连接");
                    uiSymbolButton_OneKeyConnect.Enabled = true;
                }
                else
                {
                    ShowErrorDialog("错误", "拨号账号配置文件解密失败，请重置后重试");
                    LogAppend(CustomColor.Error, "一键连接失败：拨号账号配置文件解密失败");
                }
            }
            else
            {
                ShowErrorDialog("错误", "由于未选择拨号方式，连接网络失败\n请在选择拨号方式后重试");
                LogAppend(CustomColor.Error, "一键连接失败：未选择拨号方式");
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
                            LogAppend(CustomColor.Error, "[时钟检测网络]网络未连接 - 1");
                            successConnectCount = 0;
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
                            if(_versionCheckLocker == 0)
                            {
                                Thread checker = new Thread(VersionDataCheck);
                                checker.Start();
                                _versionCheckLocker++;
                            }
                            if (successConnectCount < 10)
                                successConnectCount++;
                            else
                            {
                                LogAppend(CustomColor.Success, "[时钟检测网络]网络已连接 - 2");
                                successConnectCount = 0;
                            }
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
                            if (_versionCheckLocker == 0)
                            {
                                Thread checker = new Thread(VersionDataCheck);
                                checker.Start();
                                _versionCheckLocker++;
                            }
                            if (successConnectCount < 10)
                                successConnectCount++;
                            else
                            {
                                LogAppend(CustomColor.Success, "[时钟检测网络]网络已连接 - 3");
                                successConnectCount = 0;
                            } 
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
                            LogAppend(CustomColor.Error, "[时钟检测网络]网络未连接 - 4");
                            successConnectCount = 0;
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
                            LogAppend(CustomColor.Error, "[时钟检测网络]网络未连接 - 5");
                            successConnectCount = 0;
                            break;
                        }
                }
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
                    if(uiCheckBox_AutoStart.Checked == true)//此处不用写日志，因为保存完成后会重启，所以只需要写保存失败的日志
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
                        LogAppend(CustomColor.Success, "保存软件配置文件成功");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorDialog("异常捕获", string.Format("保存软件配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}", ex.Message, ex.Source));
                    LogAppend(CustomColor.Error, "保存软件配置文件失败：写文件时异常");
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
                            LogAppend(CustomColor.Error, "保存软件配置文件失败：写文件时异常");
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
                                LogAppend(CustomColor.Success, "开机自动启动设置成功");
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
                        UIMessageDialog.ShowMessageDialog("已保存完毕，需要重启软件\n点击确认后软件自动重启", "提示", false, Style);
                        notifyIcon_MainForm.Dispose();
                        Application.Exit();
                        Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
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
            if(Today.Check() == true) 
            { 
                if(_autoConnectTimerLocker == 1)
                {
                    if (softwareConfig != null)
                    {
                        int tempNetChecker = GetInternetConStatus.GetNetConStatus("baidu.com");
                        if (tempNetChecker == 1 || tempNetChecker ==4 || tempNetChecker == 5)
                        {
                            try
                            {
                                if (File.Exists(@"Account.json") == true && savedaccount.DialUpType >= 0 && savedaccount.Name != "解密失败" && savedaccount.Account != "解密失败" && savedaccount.Password != "解密失败")//最后判断一下账号配置文件存不存在，存在再进行重连
                                {
                                    timer_AutoConnect.Interval = 5201314;//先挂起时钟避免多次连接
                                    if (PPPoE.Connect(Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb"), Decrypt.DES(savedaccount.Password, "latiaonb")) == 1)
                                    {
                                        Toast.ShowNotifiy("自动连接", String.Format("状态:宽带自动连接成功\n宽带名称:{0}\n宽带账号:{1}", Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb")), Notifications.Wpf.NotificationType.Success);
                                        LogAppend(CustomColor.Success, "启动时自动拨号连接成功");
                                    }
                                    else
                                    {
                                        Toast.ShowNotifiy("自动连接", String.Format("状态:宽带自动连接失败\n宽带名称:{0}\n宽带账号:{1}", Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb")), Notifications.Wpf.NotificationType.Error);
                                        LogAppend(CustomColor.Error, "启动时自动拨号连接失败");
                                    }
                                }
                                else
                                {
                                    Toast.ShowNotifiy("自动连接", "由于宽带配置文件缺失或内容有误，无法进行自动连接 - 2", Notifications.Wpf.NotificationType.Error);
                                    LogAppend(CustomColor.Error, "由于宽带配置文件缺失或内容有误，无法进行自动连接 - 2");
                                }
                            }
                            catch  { }
                        }
                        else
                        {
                            Toast.ShowNotifiy("自动连接", "由于网络已处于连接状态，启动时自动连接已取消", Notifications.Wpf.NotificationType.Information);
                            LogAppend(CustomColor.Information, "由于网络已处于连接状态，启动时自动连接已取消");
                        } 
                    }
                    else
                    {
                        Toast.ShowNotifiy("自动连接", "由于宽带配置文件缺失或内容有误，无法进行自动连接", Notifications.Wpf.NotificationType.Error);
                        LogAppend(CustomColor.Error, "由于宽带配置文件缺失或内容有误，无法进行自动连接");
                    }
                    //Toast.ShowNotifiy("Title", "你设置了自动连接网络", Notifications.Wpf.NotificationType.Information);
                    timer_AutoConnect.Enabled = false;//不管连没连上，只连一次
                }
                else
                {
                    try
                    {
                        if (_autoConnectTimerLocker == 0)
                        {
                            timer_AutoConnect.Enabled = false;
                            LogAppend(CustomColor.Worring, "启动时自动拨号连接功能未启用");
                        }
                        else
                        {
                            //这里是等待线程里读取配置读好留的缓冲时间，如果10次都等不到那就把时钟关掉
                            _autoConnectTimerLocker = _autoConnectTimerLocker + 10;
                            if (_autoConnectTimerLocker >= 100)
                            {
                                timer_AutoConnect.Enabled = false;
                                LogAppend(CustomColor.Worring, "启动时自动拨号连接功能检测超时");
                            }
                        }
                    }
                    catch { }
                }
            }
            else
            {
                Toast.ShowNotifiy("自动连接", "当前不在设置的时间段内，程序不进行自动连接", Notifications.Wpf.NotificationType.Information);
                timer_AutoConnect.Enabled = false;
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
                        if (Today.Check() == true)
                        {
                            try
                            {
                                if (File.Exists(@"Account.json") == true && savedaccount.DialUpType >= 0 && savedaccount.Name != "解密失败" && savedaccount.Account != "解密失败" && savedaccount.Password != "解密失败")//最后判断一下账号配置文件存不存在，存在再进行重连
                                {
                                    LogAppend(CustomColor.Worring, "检测到网络断开，正在重新连接");
                                    int tempReConnectCount = 0;
                                    timer_AutoReConnect.Interval = 5201314;//在重连的时候先挂起时钟避免重连两次
                                    for (int i = 1; i <= softwareConfig.ReConnectCount; i++)
                                    {
                                        //Thread.Sleep(1000);
                                        if (PPPoE.Connect(Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Account, "latiaonb"), Decrypt.DES(savedaccount.Password, "latiaonb")) == 1)
                                        {
                                            Toast.ShowNotifiy("自动重连", "检测到网络断开，已自动重连成功", Notifications.Wpf.NotificationType.Success);
                                            LogAppend(CustomColor.Success, "[自动重连]重连成功");
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
                                                Toast.ShowNotifiy("自动重连", "检测到网络断开但自动重连全部失败", Notifications.Wpf.NotificationType.Error);
                                                LogAppend(CustomColor.Error, "[自动重连]检测到网络断开但重连全部失败");
                                                timer_AutoReConnect.Interval = 6000;//重连失败，继续重连，后期改
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            Toast.ShowNotifiy("自动重连", "检测到网络断开，但当前不在设置的时间段内，程序不进行自动重连", Notifications.Wpf.NotificationType.Information);
                            timer_AutoReConnect.Interval = 600006666;//软件不在时段内就不进行操作，为防过度打扰，应当直接挂起时钟

                        }
                    }//
                }
                else
                {
                    LogAppend(CustomColor.Error, "[自动重连]功能已停用,原因是用户没有开启功能");
                    timer_AutoReConnect.Enabled = false;
                }
            }
            else
            {
                LogAppend(CustomColor.Error, "[自动重连]功能已停用,原因是软件配置不存在");
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
                //卸载掉注册的热键
                UnRegisterHotKey(Sunny.UI.ModifierKeys.None, Keys.Escape);
                UnRegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F5);
                UnRegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F7);
                UnRegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F8);
                //更改Text为最小化运行中
                this.notifyIcon_MainForm.Text = "自动拨号器 - 后台运行中";
                软件状态ToolStripMenuItem.Text = "自动拨号器 - 后台运行中";//托盘菜单中的软件状态
                LogAppend(CustomColor.Information, "用户已将软件最小化");
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
                    //重新注册需要的热键
                    RegisterHotKey(Sunny.UI.ModifierKeys.None, Keys.Escape);
                    RegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F5);
                    RegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F7);
                    RegisterHotKey(Sunny.UI.ModifierKeys.Shift, Keys.F8);
                    //更改Text为运行中
                    this.notifyIcon_MainForm.Text = "自动拨号器 - 运行中";
                    软件状态ToolStripMenuItem.Text = "自动拨号器 - 运行中";//托盘菜单中的软件状态
                    LogAppend(CustomColor.Information, "用户已将软件还原至正常窗口");
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
        /// 窗口关闭前释放托盘图标并保存日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            runTimeRecord[1] = DateTime.Now;
            TimeSpan ts = runTimeRecord[1] - runTimeRecord[0];
            Start: if (Directory.Exists("Log"))
            {
                try
                {
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Log\\" + String.Format("{0}~{1}.txt", runTimeRecord[0].ToString("MM月dd日HH时mm分ss秒"), runTimeRecord[1].ToString("HH时mm分ss秒")),"此次总运行时间：" + ts.ToString() + Environment.NewLine + uiRichTextBox_Log.Text);
                }
                catch { }
            }
            else
            {
                try
                {
                    Directory.CreateDirectory("Log");
                    goto Start;
                }
                catch { }
            }
            notifyIcon_MainForm.Dispose();
            try
            {
                _timePlanEveryDayRefreshThread.Abort();
            }
            catch { }
        }

        #region 关于页的3个打开链接按钮
        private void uiSymbolButton_ProjectPage_Click(object sender, EventArgs e)
        {
            Process.Start(versionData.ProjectPageUrl);
        }

        private void uiSymbolButton_SourceAddress_Click(object sender, EventArgs e)
        {
            Process.Start(versionData.OpenSourceUrl);
        }

        private void uiSymbolButton_CheckUpdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(uiSymbolLabel_VersionNumber.Text) != versionData.VersionNumber)
                UIMessageDialog.ShowMessageDialog(String.Format("当前软件可能不是最新版\n服务器数据中最新版版本为:{0}\n可通过点击项目地址按钮下载最新版",versionData.VersionNumber.ToString()), "版本检查", false, Style);
            else
                UIMessageDialog.ShowMessageDialog("恭喜！当前软件为最新版！", "版本检查", false, Style);
        }
        #endregion

        /// <summary>
        /// 窗口热键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_HotKeyEventHandler(object sender, HotKeyEventArgs e)
        {
            //Shift+F5 重启软件
            if (e.hotKey.ModifierKey == Sunny.UI.ModifierKeys.Shift && e.hotKey.Key == Keys.F5)
            {
                if(uiCheckBox_HotKey_ShiftF5.Checked == true)
                {
                    notifyIcon_MainForm.Dispose();
                    Application.Exit();
                    Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
            }
            //Shift+F6 重新拨号换IP
            if(e.hotKey.ModifierKey == Sunny.UI.ModifierKeys.Shift && e.hotKey.Key == Keys.F6)
            {
                if (uiCheckBox_HotKey_ShiftF6.Checked == true)
                {
                    LogAppend(CustomColor.Information, "用户按下Shift+F6并开始重新拨号换IP");
                    if (PPPoE.DisConnect(Decrypt.DES(savedaccount.Name, "latiaonb")) == 1)
                    {
                        Thread.Sleep(1000);
                        if (PPPoE.Connect(Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Name, "latiaonb"), Decrypt.DES(savedaccount.Name, "latiaonb")) == 1)
                        {
                            Toast.ShowNotifiy("重新拨号换IP", "已成功重新拨号换IP", Notifications.Wpf.NotificationType.Success);
                            LogAppend(CustomColor.Success, "已成功重新拨号换IP");
                        }
                        else
                        {
                            Toast.ShowNotifiy("重新拨号换IP", "由于拨号连接失败，未能更换IP", Notifications.Wpf.NotificationType.Error);
                            LogAppend(CustomColor.Error, "重新拨号换IP失败，原因：拨号连接失败");
                        }
                    }
                    else
                    {
                        Toast.ShowNotifiy("重新拨号换IP", "由于断开当前拨号连接失败，未能更换IP", Notifications.Wpf.NotificationType.Error);
                        LogAppend(CustomColor.Error, "重新拨号换IP失败，原因：断开当前拨号连接失败");
                    }
                }
                else
                    LogAppend(CustomColor.Information, "用户按下Shift+F6但并未开启重新拨号换IP功能");
            }
            //Shift+F7 一键连接
            if (e.hotKey.ModifierKey == Sunny.UI.ModifierKeys.Shift && e.hotKey.Key == Keys.F7)
            {
                if(uiCheckBox_HotKey_ShiftF7.Checked == true)
                    uiSymbolButton_OneKeyConnect_Click(new object(), new EventArgs());
            }
            //Shift+F8 断开拨号
            if (e.hotKey.ModifierKey == Sunny.UI.ModifierKeys.Shift && e.hotKey.Key == Keys.F8)
            {
                if(uiCheckBox_HotKey_ShiftF8.Checked == true)
                {
                    if (savedaccount.DialUpType >= 0 && savedaccount.Name != "解密失败")
                    {
                        if (PPPoE.DisConnect(Decrypt.DES(savedaccount.Name, "latiaonb")) == 1)
                        {
                            Toast.ShowNotifiy("断开拨号", "已成功断开拨号连接，请注意如果开启断网自动重连功能，6秒后会自动重连", Notifications.Wpf.NotificationType.Warning);
                            LogAppend(CustomColor.Success, "已成功断开拨号连接");
                        }
                    }
                }
                else
                    LogAppend(CustomColor.Information, "用户按下Shift+F8但并开启断开拨号功能");
            }
            //Esc 退出软件
            if (e.hotKey.Key == Keys.Escape)
            {
                if(uiCheckBox_HotKey_Esc.Checked == true)
                {
                    notifyIcon_MainForm.Dispose();
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Shift+F6更换IP旁的提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton_HotKey_ChangeIPHelp_Click(object sender, EventArgs e)
        {
            UIMessageDialog.ShowMessageDialog("为了更换IP保证效率，操作时尽量不做任何检查。\n故：不会检查账号配置文件是否存在，且一定要在已经拨号连接上网络的情况下使用此功能，否则软件一定会出现各类无法预料的致命错误！！","更换IP帮助",false,Style);
        }

        /// <summary>
        /// 保存热键设置配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton_SaveHotKeyConfig_Click(object sender, EventArgs e)
        {
            if(!(uiCheckBox_HotKey_ShiftF5.Checked == false && uiCheckBox_HotKey_ShiftF6.Checked == false && uiCheckBox_HotKey_ShiftF7.Checked == false && uiCheckBox_HotKey_ShiftF8.Checked == false && uiCheckBox_HotKey_Esc.Checked == false))
            {
                if (File.Exists(@"HotKey.json") == false)
                {
                    HotKeyConfig newHotKeyConfig = new HotKeyConfig()
                    {
                        Esc = uiCheckBox_HotKey_Esc.Checked == true ? 1 : 0,
                        ShiftF5 = uiCheckBox_HotKey_ShiftF5.Checked == true ? 1 : 0,
                        ShiftF6 = uiCheckBox_HotKey_ShiftF6.Checked == true ? 1 : 0,
                        ShiftF7 = uiCheckBox_HotKey_ShiftF7.Checked == true ? 1 : 0,
                        ShiftF8 = uiCheckBox_HotKey_ShiftF8.Checked == true ? 1 : 0,
                    };
                    string json = JsonConvert.SerializeObject(newHotKeyConfig);
                    try
                    {
                        File.WriteAllText(@"HotKey.json", json);
                        LogAppend(CustomColor.Success, "保存热键配置文件成功");
                    }
                    catch (Exception ex)
                    {
                        ShowErrorDialog("异常捕获", string.Format("保存热键配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}", ex.Message, ex.Source));
                        LogAppend(CustomColor.Error, "保存热键配置文件失败：写文件时异常");
                    }
                    finally
                    {
                        UIMessageDialog.ShowMessageDialog("热键配置文件已保存完毕", "提示", false, Style);
                    }
                }
                else
                {
                    if (ShowAskDialog("热键配置文件已经存在，是否需要以当前配置覆盖旧的账号配置？\n如果覆盖，旧的配置将永久失去"))
                    {
                        HotKeyConfig newHotKeyConfig = new HotKeyConfig()
                        {
                            Esc = uiCheckBox_HotKey_Esc.Checked == true ? 1 : 0,
                            ShiftF5 = uiCheckBox_HotKey_ShiftF5.Checked == true ? 1 : 0,
                            ShiftF6 = uiCheckBox_HotKey_ShiftF6.Checked == true ? 1 : 0,
                            ShiftF7 = uiCheckBox_HotKey_ShiftF7.Checked == true ? 1 : 0,
                            ShiftF8 = uiCheckBox_HotKey_ShiftF8.Checked == true ? 1 : 0,
                        };
                        string json = JsonConvert.SerializeObject(newHotKeyConfig);
                        try
                        {
                            File.WriteAllText(@"HotKey.json", json);
                            LogAppend(CustomColor.Success, "保存热键配置文件成功");
                        }
                        catch (Exception ex)
                        {
                            ShowErrorDialog("异常捕获", string.Format("保存热键配置文件失败\n异常消息:\n{0}\n异常跟踪：\n{1}", ex.Message, ex.Source));
                            LogAppend(CustomColor.Error, "保存热键配置文件失败：写文件时异常");
                        }
                        finally
                        {
                            UIMessageDialog.ShowMessageDialog("热键配置文件已保存完毕", "提示", false, Style);
                        }
                    }
                }
            }
            else
            {
                ShowErrorDialog("错误", "由于未选择任何热键设置，无需保存");
                LogAppend(CustomColor.Error, "保存热键配置文件失败：未选择任何热键设置");
            }
        }

        /// <summary>
        /// 保存TimePlan的配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton_SaveTimePlanConfig_Click(object sender, EventArgs e)
        {
            OneDay savingDay = new OneDay() { StartTime = uiTimePicker_StartTime.Text ,EndTime = uiTimePicker_EndTime.Text };
            if(savingDay.CheckValidity() == true)
            {
                //检查TimePlan文件夹是否存在，若不存在则先新建一个文件夹
                if(Directory.Exists("TimePlan") == false)
                {
                    try
                    {
                        Directory.CreateDirectory("TimePlan");
                    }
                    catch
                    {
                        ShowErrorDialog("错误", "TimePlan文件夹不存在且在创建文件夹的过程中出现了未知错误，请重启软件并重试");
                        return;
                    }
                }
                savingDay.DayIndex = uiComboBox_SelectWhichDay.SelectedIndex + 1;
                if(uiRadioButton_NormalActions.Checked == true && uiRadioButton_StopActions.Checked == false)
                    savingDay.Enabled = true;
                else
                {
                    if(uiRadioButton_NormalActions.Checked == false && uiRadioButton_StopActions.Checked == true)
                        savingDay.Enabled = false;
                    else
                    {
                        ShowErrorDialog("错误", "请选择一个指定行为(正常执行或不执行)才能够保存");
                        return;
                    } 
                }
                string checkingFileName = string.Empty;
                //根据日期，文件的名字不同
                switch (uiComboBox_SelectWhichDay.SelectedIndex + 1)
                {
                    case 1:
                        {
                            checkingFileName = "Mon.json";
                            break;
                        }
                    case 2:
                        {
                            checkingFileName = "Tues.json";
                            break;
                        }
                    case 3:
                        {
                            checkingFileName = "Wed.json";
                            break;
                        }
                    case 4:
                        {
                            checkingFileName = "Thur.json";
                            break;
                        }
                    case 5:
                        {
                            checkingFileName = "Fri.json";
                            break;
                        }
                    case 6:
                        {
                            checkingFileName = "Sat.json";
                            break;
                        }
                    case 7:
                        {
                            checkingFileName = "Sun.json";
                            break;
                        }
                }
                if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + string.Format("TimePlan\\{0}", checkingFileName)) == true)
                {
                    //先把旧的配置文件删了
                    if (ShowAskDialog("当前日期的配置文件已存在，是否进行覆盖？\n如果进行覆盖，旧的配置文件将永久失去"))
                    {
                        try
                        {
                            File.Delete(AppDomain.CurrentDomain.BaseDirectory + string.Format("TimePlan\\{0}", checkingFileName));
                        }
                        catch
                        {
                            ShowErrorDialog("错误", "在尝试覆盖旧的配置文件时失败了，原因是删除旧的文件失败");
                            return;
                        }
                    }
                    else
                        return;
                }
                //向目录写入指定名字的配置文件 在这之前先要检查数据完整性
                if(savingDay.CheckCompleteness() == true)
                {
                    try
                    {
                        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + string.Format("TimePlan\\{0}", checkingFileName), Json.Serialize(savingDay));
                    }
                    catch
                    {
                        ShowErrorDialog("错误", "保存时间段配置文件失败，原因是向指定目录写入文件时失败了");
                        return;
                    }
                }
                UIMessageDialog.ShowMessageDialog("已保存完毕，需要重启软件才能够生效\n建议将所有需要的日期设置完成后再自行重启", "提示", false, Style);
            }
            else
            {
                ShowErrorDialog("错误","由于结束时间早于开始时间，无法保存\n请修改后重新保存");
            }
        }

        /// <summary>
        /// 如果选中的日期已经有数据了，就在控件上加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiComboBox_SelectWhichDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            OneDay tempDay = null;
            switch (uiComboBox_SelectWhichDay.SelectedIndex)
            {
                case 0:
                    {
                        tempDay = DaysCollections.Mon;
                        break;
                    }

                case 1:
                    {
                        tempDay = DaysCollections.Tues;
                        break;
                    }

                case 2:
                    {
                        tempDay = DaysCollections.Wed;
                        break;
                    }

                case 3:
                    {
                        tempDay = DaysCollections.Thur;
                        break;
                    }

                case 4:
                    {
                        tempDay = DaysCollections.Fri;
                        break;
                    }

                case 5:
                    {
                        tempDay = DaysCollections.Sat;
                        break;
                    }

                case 6:
                    {
                        tempDay = DaysCollections.Sun;
                        break;
                    }

                default:
                    {
                        tempDay = null;
                        break;
                    }
            }
            //如果有数据就加载数据，没数据就变成默认的数据
            if(tempDay.Initialized != false)
            {
                uiTimePicker_StartTime.Text = tempDay.StartTime;
                uiTimePicker_EndTime.Text = tempDay.EndTime;
                if(tempDay.Enabled == true)
                {
                    uiRadioButton_NormalActions.Checked = true;
                    uiRadioButton_StopActions.Checked = false;
                }
                else
                {
                    uiRadioButton_NormalActions.Checked = false;
                    uiRadioButton_StopActions.Checked = true;
                }
            }
            else
            {
                uiTimePicker_StartTime.Text = @"08:00:00";
                uiTimePicker_EndTime.Text = @"23:00:00";
                uiRadioButton_NormalActions.Checked = true;
                uiRadioButton_StopActions.Checked = false;
            }
        }
    }
}