namespace AutoDialUp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uiStyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.Aside = new Sunny.UI.UINavMenu();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Status = new System.Windows.Forms.TabPage();
            this.uiProcessBar_ConectProcess = new Sunny.UI.UIProcessBar();
            this.uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            this.uiSymbolButton_OneKeyConnect = new Sunny.UI.UISymbolButton();
            this.uiComboBox_ConnectMethod = new Sunny.UI.UIComboBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiTitlePanel_Config = new Sunny.UI.UITitlePanel();
            this.uiSymbolLabe_AccountConfigCheck = new Sunny.UI.UISymbolLabel();
            this.uiSymbolButton_ResetConfig = new Sunny.UI.UISymbolButton();
            this.uiSymbolLabel_SoftConfigCheck = new Sunny.UI.UISymbolLabel();
            this.uiAvatar_NetStatus = new Sunny.UI.UIAvatar();
            this.uiTitlePanel_NetStatus = new Sunny.UI.UITitlePanel();
            this.uiSymbolLabel_PingOK = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel_InternetDeviceType = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel_ConnectCheck = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            this.tabPage_AccountConfig = new System.Windows.Forms.TabPage();
            this.uiSymbolButton_AccountHelp = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_SaveAccountConfig = new Sunny.UI.UISymbolButton();
            this.uiComboBox_DialUpType = new Sunny.UI.UIComboBox();
            this.uiSymbolLabel2 = new Sunny.UI.UISymbolLabel();
            this.uiTextBox_DialUpPassword = new Sunny.UI.UITextBox();
            this.uiTextBox_DialUpAccount = new Sunny.UI.UITextBox();
            this.uiTextBox_DialUpName = new Sunny.UI.UITextBox();
            this.tabPage_SoftwareConfig = new System.Windows.Forms.TabPage();
            this.uiSymbolButton_SaveSoftwareConfig = new Sunny.UI.UISymbolButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiIntegerUpDown_ReConnectCount = new Sunny.UI.UIIntegerUpDown();
            this.uiCheckBox_AutoReConnect = new Sunny.UI.UICheckBox();
            this.uiMarkLabel3 = new Sunny.UI.UIMarkLabel();
            this.uiCheckBox_AutoConnect = new Sunny.UI.UICheckBox();
            this.uiCheckBox_AutoStart = new Sunny.UI.UICheckBox();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.tabPage_HotKey = new System.Windows.Forms.TabPage();
            this.uiSymbolButton_HotKey_ChangeIPHelp = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_SaveHotKeyConfig = new Sunny.UI.UISymbolButton();
            this.uiCheckBox_HotKey_ShiftF8 = new Sunny.UI.UICheckBox();
            this.uiCheckBox_HotKey_ShiftF7 = new Sunny.UI.UICheckBox();
            this.uiCheckBox_HotKey_ShiftF6 = new Sunny.UI.UICheckBox();
            this.uiCheckBox_HotKey_ShiftF5 = new Sunny.UI.UICheckBox();
            this.uiCheckBox_HotKey_Esc = new Sunny.UI.UICheckBox();
            this.tabPage_About = new System.Windows.Forms.TabPage();
            this.uiSymbolButton_CheckUpdate = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_SourceAddress = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_ProjectPage = new Sunny.UI.UISymbolButton();
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            this.uiSymbolLabel3 = new Sunny.UI.UISymbolLabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLinkLabel1 = new Sunny.UI.UILinkLabel();
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.timer_NetChecker = new System.Windows.Forms.Timer(this.components);
            this.uiToolTip1 = new Sunny.UI.UIToolTip(this.components);
            this.timer_AutoConnect = new System.Windows.Forms.Timer(this.components);
            this.timer_AutoReConnect = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon_MainForm = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.软件状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.一键连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPage_Status.SuspendLayout();
            this.uiTitlePanel3.SuspendLayout();
            this.uiTitlePanel_Config.SuspendLayout();
            this.uiTitlePanel_NetStatus.SuspendLayout();
            this.tabPage_AccountConfig.SuspendLayout();
            this.tabPage_SoftwareConfig.SuspendLayout();
            this.tabPage_HotKey.SuspendLayout();
            this.tabPage_About.SuspendLayout();
            this.contextMenuStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiStyleManager
            // 
            this.uiStyleManager.DPIScale = true;
            this.uiStyleManager.FontSize = 15F;
            // 
            // Aside
            // 
            this.Aside.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Aside.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.Aside.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Aside.FullRowSelect = true;
            this.Aside.ItemHeight = 50;
            this.Aside.Location = new System.Drawing.Point(0, 36);
            this.Aside.Name = "Aside";
            this.Aside.ShowLines = false;
            this.Aside.Size = new System.Drawing.Size(138, 442);
            this.Aside.TabIndex = 0;
            this.Aside.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Aside.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Aside.Click += new System.EventHandler(this.Aside_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Status);
            this.tabControl.Controls.Add(this.tabPage_AccountConfig);
            this.tabControl.Controls.Add(this.tabPage_SoftwareConfig);
            this.tabControl.Controls.Add(this.tabPage_HotKey);
            this.tabControl.Controls.Add(this.tabPage_About);
            this.tabControl.Location = new System.Drawing.Point(134, 36);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(631, 429);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_Status
            // 
            this.tabPage_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPage_Status.Controls.Add(this.uiProcessBar_ConectProcess);
            this.tabPage_Status.Controls.Add(this.uiTitlePanel3);
            this.tabPage_Status.Controls.Add(this.uiTitlePanel_Config);
            this.tabPage_Status.Controls.Add(this.uiAvatar_NetStatus);
            this.tabPage_Status.Controls.Add(this.uiTitlePanel_NetStatus);
            this.tabPage_Status.Controls.Add(this.uiSymbolLabel1);
            this.tabPage_Status.Location = new System.Drawing.Point(4, 40);
            this.tabPage_Status.Name = "tabPage_Status";
            this.tabPage_Status.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Status.Size = new System.Drawing.Size(623, 385);
            this.tabPage_Status.TabIndex = 0;
            this.tabPage_Status.Text = "状态";
            // 
            // uiProcessBar_ConectProcess
            // 
            this.uiProcessBar_ConectProcess.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiProcessBar_ConectProcess.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiProcessBar_ConectProcess.Location = new System.Drawing.Point(25, 365);
            this.uiProcessBar_ConectProcess.MinimumSize = new System.Drawing.Size(70, 3);
            this.uiProcessBar_ConectProcess.Name = "uiProcessBar_ConectProcess";
            this.uiProcessBar_ConectProcess.Size = new System.Drawing.Size(583, 17);
            this.uiProcessBar_ConectProcess.TabIndex = 7;
            this.uiProcessBar_ConectProcess.TabStop = false;
            this.uiProcessBar_ConectProcess.Visible = false;
            this.uiProcessBar_ConectProcess.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel3
            // 
            this.uiTitlePanel3.Controls.Add(this.uiSymbolButton_OneKeyConnect);
            this.uiTitlePanel3.Controls.Add(this.uiComboBox_ConnectMethod);
            this.uiTitlePanel3.Controls.Add(this.uiLine1);
            this.uiTitlePanel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel3.Location = new System.Drawing.Point(429, 133);
            this.uiTitlePanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel3.Name = "uiTitlePanel3";
            this.uiTitlePanel3.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel3.ShowText = false;
            this.uiTitlePanel3.Size = new System.Drawing.Size(179, 224);
            this.uiTitlePanel3.TabIndex = 6;
            this.uiTitlePanel3.Text = "一键连接";
            this.uiTitlePanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton_OneKeyConnect
            // 
            this.uiSymbolButton_OneKeyConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_OneKeyConnect.Enabled = false;
            this.uiSymbolButton_OneKeyConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_OneKeyConnect.Location = new System.Drawing.Point(15, 148);
            this.uiSymbolButton_OneKeyConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_OneKeyConnect.Name = "uiSymbolButton_OneKeyConnect";
            this.uiSymbolButton_OneKeyConnect.Size = new System.Drawing.Size(156, 35);
            this.uiSymbolButton_OneKeyConnect.Symbol = 61633;
            this.uiSymbolButton_OneKeyConnect.SymbolSize = 26;
            this.uiSymbolButton_OneKeyConnect.TabIndex = 2;
            this.uiSymbolButton_OneKeyConnect.Text = "连接";
            this.uiSymbolButton_OneKeyConnect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_OneKeyConnect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_OneKeyConnect.Click += new System.EventHandler(this.uiSymbolButton_OneKeyConnect_Click);
            // 
            // uiComboBox_ConnectMethod
            // 
            this.uiComboBox_ConnectMethod.DataSource = null;
            this.uiComboBox_ConnectMethod.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_ConnectMethod.FillColor = System.Drawing.Color.White;
            this.uiComboBox_ConnectMethod.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox_ConnectMethod.Items.AddRange(new object[] {
            "PPPoE",
            "ADSL"});
            this.uiComboBox_ConnectMethod.Location = new System.Drawing.Point(15, 103);
            this.uiComboBox_ConnectMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_ConnectMethod.MaxDropDownItems = 2;
            this.uiComboBox_ConnectMethod.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_ConnectMethod.Name = "uiComboBox_ConnectMethod";
            this.uiComboBox_ConnectMethod.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_ConnectMethod.Size = new System.Drawing.Size(150, 29);
            this.uiComboBox_ConnectMethod.TabIndex = 1;
            this.uiComboBox_ConnectMethod.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_ConnectMethod.Watermark = "";
            this.uiComboBox_ConnectMethod.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.LineSize = 2;
            this.uiLine1.Location = new System.Drawing.Point(15, 67);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(150, 29);
            this.uiLine1.TabIndex = 0;
            this.uiLine1.Text = "连接方式";
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel_Config
            // 
            this.uiTitlePanel_Config.Controls.Add(this.uiSymbolLabe_AccountConfigCheck);
            this.uiTitlePanel_Config.Controls.Add(this.uiSymbolButton_ResetConfig);
            this.uiTitlePanel_Config.Controls.Add(this.uiSymbolLabel_SoftConfigCheck);
            this.uiTitlePanel_Config.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel_Config.Location = new System.Drawing.Point(229, 133);
            this.uiTitlePanel_Config.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel_Config.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel_Config.Name = "uiTitlePanel_Config";
            this.uiTitlePanel_Config.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel_Config.ShowText = false;
            this.uiTitlePanel_Config.Size = new System.Drawing.Size(179, 224);
            this.uiTitlePanel_Config.TabIndex = 5;
            this.uiTitlePanel_Config.Text = "配置文件";
            this.uiTitlePanel_Config.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel_Config.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabe_AccountConfigCheck
            // 
            this.uiSymbolLabe_AccountConfigCheck.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabe_AccountConfigCheck.Location = new System.Drawing.Point(12, 103);
            this.uiSymbolLabe_AccountConfigCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabe_AccountConfigCheck.Name = "uiSymbolLabe_AccountConfigCheck";
            this.uiSymbolLabe_AccountConfigCheck.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabe_AccountConfigCheck.Size = new System.Drawing.Size(156, 35);
            this.uiSymbolLabe_AccountConfigCheck.Symbol = 61761;
            this.uiSymbolLabe_AccountConfigCheck.TabIndex = 2;
            this.uiSymbolLabe_AccountConfigCheck.Text = "检查账号文件中";
            this.uiSymbolLabe_AccountConfigCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolLabe_AccountConfigCheck.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton_ResetConfig
            // 
            this.uiSymbolButton_ResetConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_ResetConfig.Enabled = false;
            this.uiSymbolButton_ResetConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_ResetConfig.Location = new System.Drawing.Point(12, 148);
            this.uiSymbolButton_ResetConfig.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_ResetConfig.Name = "uiSymbolButton_ResetConfig";
            this.uiSymbolButton_ResetConfig.Size = new System.Drawing.Size(156, 35);
            this.uiSymbolButton_ResetConfig.Symbol = 61473;
            this.uiSymbolButton_ResetConfig.SymbolSize = 26;
            this.uiSymbolButton_ResetConfig.TabIndex = 1;
            this.uiSymbolButton_ResetConfig.Text = "重置配置";
            this.uiSymbolButton_ResetConfig.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_ResetConfig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabel_SoftConfigCheck
            // 
            this.uiSymbolLabel_SoftConfigCheck.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel_SoftConfigCheck.Location = new System.Drawing.Point(12, 62);
            this.uiSymbolLabel_SoftConfigCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel_SoftConfigCheck.Name = "uiSymbolLabel_SoftConfigCheck";
            this.uiSymbolLabel_SoftConfigCheck.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel_SoftConfigCheck.Size = new System.Drawing.Size(156, 35);
            this.uiSymbolLabel_SoftConfigCheck.Symbol = 61761;
            this.uiSymbolLabel_SoftConfigCheck.TabIndex = 0;
            this.uiSymbolLabel_SoftConfigCheck.Text = "检查配置文件中";
            this.uiSymbolLabel_SoftConfigCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolLabel_SoftConfigCheck.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiAvatar_NetStatus
            // 
            this.uiAvatar_NetStatus.BackColor = System.Drawing.Color.Transparent;
            this.uiAvatar_NetStatus.FillColor = System.Drawing.Color.Gainsboro;
            this.uiAvatar_NetStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiAvatar_NetStatus.Location = new System.Drawing.Point(522, 6);
            this.uiAvatar_NetStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar_NetStatus.Name = "uiAvatar_NetStatus";
            this.uiAvatar_NetStatus.Size = new System.Drawing.Size(81, 103);
            this.uiAvatar_NetStatus.Style = Sunny.UI.UIStyle.Custom;
            this.uiAvatar_NetStatus.Symbol = 61598;
            this.uiAvatar_NetStatus.SymbolSize = 100;
            this.uiAvatar_NetStatus.TabIndex = 0;
            this.uiAvatar_NetStatus.Text = "uiAvatar1";
            this.uiAvatar_NetStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel_NetStatus
            // 
            this.uiTitlePanel_NetStatus.Controls.Add(this.uiSymbolLabel_PingOK);
            this.uiTitlePanel_NetStatus.Controls.Add(this.uiSymbolLabel_InternetDeviceType);
            this.uiTitlePanel_NetStatus.Controls.Add(this.uiSymbolLabel_ConnectCheck);
            this.uiTitlePanel_NetStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel_NetStatus.Location = new System.Drawing.Point(25, 133);
            this.uiTitlePanel_NetStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel_NetStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel_NetStatus.Name = "uiTitlePanel_NetStatus";
            this.uiTitlePanel_NetStatus.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel_NetStatus.ShowText = false;
            this.uiTitlePanel_NetStatus.Size = new System.Drawing.Size(179, 224);
            this.uiTitlePanel_NetStatus.TabIndex = 4;
            this.uiTitlePanel_NetStatus.Text = "网络状态";
            this.uiTitlePanel_NetStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel_NetStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabel_PingOK
            // 
            this.uiSymbolLabel_PingOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel_PingOK.Location = new System.Drawing.Point(12, 148);
            this.uiSymbolLabel_PingOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel_PingOK.Name = "uiSymbolLabel_PingOK";
            this.uiSymbolLabel_PingOK.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel_PingOK.Size = new System.Drawing.Size(156, 35);
            this.uiSymbolLabel_PingOK.Symbol = 61761;
            this.uiSymbolLabel_PingOK.TabIndex = 5;
            this.uiSymbolLabel_PingOK.Text = "上网设备获取中";
            this.uiSymbolLabel_PingOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolLabel_PingOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabel_InternetDeviceType
            // 
            this.uiSymbolLabel_InternetDeviceType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel_InternetDeviceType.Location = new System.Drawing.Point(11, 103);
            this.uiSymbolLabel_InternetDeviceType.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel_InternetDeviceType.Name = "uiSymbolLabel_InternetDeviceType";
            this.uiSymbolLabel_InternetDeviceType.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel_InternetDeviceType.Size = new System.Drawing.Size(156, 35);
            this.uiSymbolLabel_InternetDeviceType.Symbol = 61761;
            this.uiSymbolLabel_InternetDeviceType.TabIndex = 4;
            this.uiSymbolLabel_InternetDeviceType.Text = "连接类型检测中";
            this.uiSymbolLabel_InternetDeviceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolLabel_InternetDeviceType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabel_ConnectCheck
            // 
            this.uiSymbolLabel_ConnectCheck.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel_ConnectCheck.Location = new System.Drawing.Point(11, 62);
            this.uiSymbolLabel_ConnectCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel_ConnectCheck.Name = "uiSymbolLabel_ConnectCheck";
            this.uiSymbolLabel_ConnectCheck.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel_ConnectCheck.Size = new System.Drawing.Size(156, 35);
            this.uiSymbolLabel_ConnectCheck.Symbol = 61761;
            this.uiSymbolLabel_ConnectCheck.TabIndex = 3;
            this.uiSymbolLabel_ConnectCheck.Text = "设备检测初始化";
            this.uiSymbolLabel_ConnectCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolLabel_ConnectCheck.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabel1
            // 
            this.uiSymbolLabel1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel1.Location = new System.Drawing.Point(6, 5);
            this.uiSymbolLabel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel1.Name = "uiSymbolLabel1";
            this.uiSymbolLabel1.Padding = new System.Windows.Forms.Padding(84, 0, 0, 0);
            this.uiSymbolLabel1.Size = new System.Drawing.Size(532, 100);
            this.uiSymbolLabel1.Symbol = 61568;
            this.uiSymbolLabel1.SymbolSize = 80;
            this.uiSymbolLabel1.TabIndex = 1;
            this.uiSymbolLabel1.Text = "软件状态面板";
            this.uiSymbolLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage_AccountConfig
            // 
            this.tabPage_AccountConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPage_AccountConfig.Controls.Add(this.uiSymbolButton_AccountHelp);
            this.tabPage_AccountConfig.Controls.Add(this.uiSymbolButton_SaveAccountConfig);
            this.tabPage_AccountConfig.Controls.Add(this.uiComboBox_DialUpType);
            this.tabPage_AccountConfig.Controls.Add(this.uiSymbolLabel2);
            this.tabPage_AccountConfig.Controls.Add(this.uiTextBox_DialUpPassword);
            this.tabPage_AccountConfig.Controls.Add(this.uiTextBox_DialUpAccount);
            this.tabPage_AccountConfig.Controls.Add(this.uiTextBox_DialUpName);
            this.tabPage_AccountConfig.Location = new System.Drawing.Point(4, 40);
            this.tabPage_AccountConfig.Name = "tabPage_AccountConfig";
            this.tabPage_AccountConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_AccountConfig.Size = new System.Drawing.Size(623, 385);
            this.tabPage_AccountConfig.TabIndex = 1;
            this.tabPage_AccountConfig.Text = "拨号设置";
            // 
            // uiSymbolButton_AccountHelp
            // 
            this.uiSymbolButton_AccountHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_AccountHelp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_AccountHelp.Location = new System.Drawing.Point(447, 304);
            this.uiSymbolButton_AccountHelp.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_AccountHelp.Name = "uiSymbolButton_AccountHelp";
            this.uiSymbolButton_AccountHelp.Size = new System.Drawing.Size(38, 35);
            this.uiSymbolButton_AccountHelp.Symbol = 61529;
            this.uiSymbolButton_AccountHelp.SymbolSize = 28;
            this.uiSymbolButton_AccountHelp.TabIndex = 6;
            this.uiSymbolButton_AccountHelp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_AccountHelp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_AccountHelp.Click += new System.EventHandler(this.uiSymbolButton_AccountHelp_Click);
            // 
            // uiSymbolButton_SaveAccountConfig
            // 
            this.uiSymbolButton_SaveAccountConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_SaveAccountConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SaveAccountConfig.Location = new System.Drawing.Point(136, 304);
            this.uiSymbolButton_SaveAccountConfig.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_SaveAccountConfig.Name = "uiSymbolButton_SaveAccountConfig";
            this.uiSymbolButton_SaveAccountConfig.Size = new System.Drawing.Size(296, 35);
            this.uiSymbolButton_SaveAccountConfig.Symbol = 61639;
            this.uiSymbolButton_SaveAccountConfig.SymbolSize = 28;
            this.uiSymbolButton_SaveAccountConfig.TabIndex = 5;
            this.uiSymbolButton_SaveAccountConfig.Text = "保存配置";
            this.uiSymbolButton_SaveAccountConfig.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SaveAccountConfig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_SaveAccountConfig.Click += new System.EventHandler(this.uiSymbolButton_SaveAccountConfig_Click);
            // 
            // uiComboBox_DialUpType
            // 
            this.uiComboBox_DialUpType.DataSource = null;
            this.uiComboBox_DialUpType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_DialUpType.FillColor = System.Drawing.Color.White;
            this.uiComboBox_DialUpType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox_DialUpType.Items.AddRange(new object[] {
            "PPPoE",
            "ADSL"});
            this.uiComboBox_DialUpType.Location = new System.Drawing.Point(283, 242);
            this.uiComboBox_DialUpType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_DialUpType.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_DialUpType.Name = "uiComboBox_DialUpType";
            this.uiComboBox_DialUpType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_DialUpType.Size = new System.Drawing.Size(202, 28);
            this.uiComboBox_DialUpType.TabIndex = 4;
            this.uiComboBox_DialUpType.Text = "请先选择方式";
            this.uiComboBox_DialUpType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_DialUpType.Watermark = "";
            this.uiComboBox_DialUpType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabel2
            // 
            this.uiSymbolLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel2.Location = new System.Drawing.Point(136, 238);
            this.uiSymbolLabel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel2.Name = "uiSymbolLabel2";
            this.uiSymbolLabel2.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel2.Size = new System.Drawing.Size(152, 35);
            this.uiSymbolLabel2.Symbol = 361496;
            this.uiSymbolLabel2.TabIndex = 3;
            this.uiSymbolLabel2.Text = "拨号方式：";
            this.uiSymbolLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox_DialUpPassword
            // 
            this.uiTextBox_DialUpPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_DialUpPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_DialUpPassword.Location = new System.Drawing.Point(136, 182);
            this.uiTextBox_DialUpPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_DialUpPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_DialUpPassword.Name = "uiTextBox_DialUpPassword";
            this.uiTextBox_DialUpPassword.ShowText = false;
            this.uiTextBox_DialUpPassword.Size = new System.Drawing.Size(349, 34);
            this.uiTextBox_DialUpPassword.Symbol = 61475;
            this.uiTextBox_DialUpPassword.SymbolSize = 28;
            this.uiTextBox_DialUpPassword.TabIndex = 2;
            this.uiTextBox_DialUpPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_DialUpPassword.Watermark = "宽带连接密码";
            this.uiTextBox_DialUpPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox_DialUpAccount
            // 
            this.uiTextBox_DialUpAccount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_DialUpAccount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_DialUpAccount.Location = new System.Drawing.Point(136, 113);
            this.uiTextBox_DialUpAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_DialUpAccount.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_DialUpAccount.Name = "uiTextBox_DialUpAccount";
            this.uiTextBox_DialUpAccount.ShowText = false;
            this.uiTextBox_DialUpAccount.Size = new System.Drawing.Size(349, 34);
            this.uiTextBox_DialUpAccount.Symbol = 62141;
            this.uiTextBox_DialUpAccount.SymbolSize = 28;
            this.uiTextBox_DialUpAccount.TabIndex = 1;
            this.uiTextBox_DialUpAccount.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_DialUpAccount.Watermark = "宽带连接账号";
            this.uiTextBox_DialUpAccount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox_DialUpName
            // 
            this.uiTextBox_DialUpName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_DialUpName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_DialUpName.Location = new System.Drawing.Point(136, 45);
            this.uiTextBox_DialUpName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_DialUpName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_DialUpName.Name = "uiTextBox_DialUpName";
            this.uiTextBox_DialUpName.ShowText = false;
            this.uiTextBox_DialUpName.Size = new System.Drawing.Size(349, 34);
            this.uiTextBox_DialUpName.Symbol = 61641;
            this.uiTextBox_DialUpName.SymbolSize = 28;
            this.uiTextBox_DialUpName.TabIndex = 0;
            this.uiTextBox_DialUpName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_DialUpName.Watermark = "宽带名 默认为：宽带连接";
            this.uiTextBox_DialUpName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage_SoftwareConfig
            // 
            this.tabPage_SoftwareConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPage_SoftwareConfig.Controls.Add(this.uiSymbolButton_SaveSoftwareConfig);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiLabel1);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiIntegerUpDown_ReConnectCount);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiCheckBox_AutoReConnect);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiMarkLabel3);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiCheckBox_AutoConnect);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiCheckBox_AutoStart);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiMarkLabel2);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiMarkLabel1);
            this.tabPage_SoftwareConfig.Controls.Add(this.uiLine2);
            this.tabPage_SoftwareConfig.Location = new System.Drawing.Point(4, 40);
            this.tabPage_SoftwareConfig.Name = "tabPage_SoftwareConfig";
            this.tabPage_SoftwareConfig.Size = new System.Drawing.Size(623, 385);
            this.tabPage_SoftwareConfig.TabIndex = 3;
            this.tabPage_SoftwareConfig.Text = "软件设置";
            // 
            // uiSymbolButton_SaveSoftwareConfig
            // 
            this.uiSymbolButton_SaveSoftwareConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_SaveSoftwareConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SaveSoftwareConfig.Location = new System.Drawing.Point(376, 281);
            this.uiSymbolButton_SaveSoftwareConfig.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_SaveSoftwareConfig.Name = "uiSymbolButton_SaveSoftwareConfig";
            this.uiSymbolButton_SaveSoftwareConfig.Size = new System.Drawing.Size(204, 55);
            this.uiSymbolButton_SaveSoftwareConfig.Symbol = 61639;
            this.uiSymbolButton_SaveSoftwareConfig.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton_SaveSoftwareConfig.SymbolSize = 30;
            this.uiSymbolButton_SaveSoftwareConfig.TabIndex = 10;
            this.uiSymbolButton_SaveSoftwareConfig.Text = "保存配置";
            this.uiSymbolButton_SaveSoftwareConfig.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SaveSoftwareConfig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_SaveSoftwareConfig.Click += new System.EventHandler(this.uiSymbolButton_SaveSoftwareConfig_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(351, 50);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(252, 125);
            this.uiLabel1.TabIndex = 9;
            this.uiLabel1.Text = "将在下次更新中实现";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiIntegerUpDown_ReConnectCount
            // 
            this.uiIntegerUpDown_ReConnectCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiIntegerUpDown_ReConnectCount.HasMaximum = true;
            this.uiIntegerUpDown_ReConnectCount.HasMinimum = true;
            this.uiIntegerUpDown_ReConnectCount.Location = new System.Drawing.Point(57, 294);
            this.uiIntegerUpDown_ReConnectCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiIntegerUpDown_ReConnectCount.Maximum = 5;
            this.uiIntegerUpDown_ReConnectCount.MaximumEnabled = true;
            this.uiIntegerUpDown_ReConnectCount.Minimum = 1;
            this.uiIntegerUpDown_ReConnectCount.MinimumEnabled = true;
            this.uiIntegerUpDown_ReConnectCount.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown_ReConnectCount.Name = "uiIntegerUpDown_ReConnectCount";
            this.uiIntegerUpDown_ReConnectCount.ShowText = false;
            this.uiIntegerUpDown_ReConnectCount.Size = new System.Drawing.Size(186, 42);
            this.uiIntegerUpDown_ReConnectCount.TabIndex = 8;
            this.uiIntegerUpDown_ReConnectCount.Text = "陈雨豪死全家";
            this.uiIntegerUpDown_ReConnectCount.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiToolTip1.SetToolTip(this.uiIntegerUpDown_ReConnectCount, "此数值为最大重连次数\r\n例如数值为2，则断网后尝试重连两次仍失败则不再重连");
            this.uiIntegerUpDown_ReConnectCount.Value = 1;
            this.uiIntegerUpDown_ReConnectCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCheckBox_AutoReConnect
            // 
            this.uiCheckBox_AutoReConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_AutoReConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_AutoReConnect.Location = new System.Drawing.Point(57, 245);
            this.uiCheckBox_AutoReConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_AutoReConnect.Name = "uiCheckBox_AutoReConnect";
            this.uiCheckBox_AutoReConnect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_AutoReConnect.Size = new System.Drawing.Size(186, 29);
            this.uiCheckBox_AutoReConnect.TabIndex = 6;
            this.uiCheckBox_AutoReConnect.Text = "断网自动重连";
            this.uiCheckBox_AutoReConnect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiMarkLabel3
            // 
            this.uiMarkLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel3.Location = new System.Drawing.Point(370, 12);
            this.uiMarkLabel3.MarkPos = Sunny.UI.UIMarkLabel.UIMarkPos.Bottom;
            this.uiMarkLabel3.Name = "uiMarkLabel3";
            this.uiMarkLabel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.uiMarkLabel3.Size = new System.Drawing.Size(192, 38);
            this.uiMarkLabel3.TabIndex = 5;
            this.uiMarkLabel3.Text = "自动拨号换IP";
            this.uiMarkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiMarkLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCheckBox_AutoConnect
            // 
            this.uiCheckBox_AutoConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_AutoConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_AutoConnect.Location = new System.Drawing.Point(57, 130);
            this.uiCheckBox_AutoConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_AutoConnect.Name = "uiCheckBox_AutoConnect";
            this.uiCheckBox_AutoConnect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_AutoConnect.Size = new System.Drawing.Size(210, 29);
            this.uiCheckBox_AutoConnect.TabIndex = 4;
            this.uiCheckBox_AutoConnect.Text = "启动后自动连接";
            this.uiCheckBox_AutoConnect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCheckBox_AutoStart
            // 
            this.uiCheckBox_AutoStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_AutoStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_AutoStart.Location = new System.Drawing.Point(57, 75);
            this.uiCheckBox_AutoStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_AutoStart.Name = "uiCheckBox_AutoStart";
            this.uiCheckBox_AutoStart.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_AutoStart.Size = new System.Drawing.Size(186, 29);
            this.uiCheckBox_AutoStart.TabIndex = 3;
            this.uiCheckBox_AutoStart.Text = "开机自动启动";
            this.uiCheckBox_AutoStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiMarkLabel2
            // 
            this.uiMarkLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel2.Location = new System.Drawing.Point(51, 186);
            this.uiMarkLabel2.MarkPos = Sunny.UI.UIMarkLabel.UIMarkPos.Bottom;
            this.uiMarkLabel2.Name = "uiMarkLabel2";
            this.uiMarkLabel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.uiMarkLabel2.Size = new System.Drawing.Size(192, 38);
            this.uiMarkLabel2.TabIndex = 2;
            this.uiMarkLabel2.Text = "自动重连设置";
            this.uiMarkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiMarkLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel1.Location = new System.Drawing.Point(51, 12);
            this.uiMarkLabel1.MarkPos = Sunny.UI.UIMarkLabel.UIMarkPos.Bottom;
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.uiMarkLabel1.Size = new System.Drawing.Size(192, 38);
            this.uiMarkLabel1.TabIndex = 1;
            this.uiMarkLabel1.Text = "系统启动设置";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiMarkLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine2
            // 
            this.uiLine2.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.LineDashStyle = Sunny.UI.UILineDashStyle.Dash;
            this.uiLine2.LineSize = 3;
            this.uiLine2.Location = new System.Drawing.Point(273, 3);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(52, 362);
            this.uiLine2.TabIndex = 0;
            this.uiLine2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage_HotKey
            // 
            this.tabPage_HotKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPage_HotKey.Controls.Add(this.uiSymbolButton_HotKey_ChangeIPHelp);
            this.tabPage_HotKey.Controls.Add(this.uiSymbolButton_SaveHotKeyConfig);
            this.tabPage_HotKey.Controls.Add(this.uiCheckBox_HotKey_ShiftF8);
            this.tabPage_HotKey.Controls.Add(this.uiCheckBox_HotKey_ShiftF7);
            this.tabPage_HotKey.Controls.Add(this.uiCheckBox_HotKey_ShiftF6);
            this.tabPage_HotKey.Controls.Add(this.uiCheckBox_HotKey_ShiftF5);
            this.tabPage_HotKey.Controls.Add(this.uiCheckBox_HotKey_Esc);
            this.tabPage_HotKey.Location = new System.Drawing.Point(4, 40);
            this.tabPage_HotKey.Name = "tabPage_HotKey";
            this.tabPage_HotKey.Size = new System.Drawing.Size(623, 385);
            this.tabPage_HotKey.TabIndex = 4;
            this.tabPage_HotKey.Text = "热键设置";
            // 
            // uiSymbolButton_HotKey_ChangeIPHelp
            // 
            this.uiSymbolButton_HotKey_ChangeIPHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_HotKey_ChangeIPHelp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_HotKey_ChangeIPHelp.Location = new System.Drawing.Point(416, 122);
            this.uiSymbolButton_HotKey_ChangeIPHelp.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_HotKey_ChangeIPHelp.Name = "uiSymbolButton_HotKey_ChangeIPHelp";
            this.uiSymbolButton_HotKey_ChangeIPHelp.Size = new System.Drawing.Size(38, 35);
            this.uiSymbolButton_HotKey_ChangeIPHelp.Symbol = 61546;
            this.uiSymbolButton_HotKey_ChangeIPHelp.SymbolSize = 28;
            this.uiSymbolButton_HotKey_ChangeIPHelp.TabIndex = 12;
            this.uiSymbolButton_HotKey_ChangeIPHelp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_HotKey_ChangeIPHelp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_HotKey_ChangeIPHelp.Click += new System.EventHandler(this.uiSymbolButton_HotKey_ChangeIPHelp_Click);
            // 
            // uiSymbolButton_SaveHotKeyConfig
            // 
            this.uiSymbolButton_SaveHotKeyConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_SaveHotKeyConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SaveHotKeyConfig.Location = new System.Drawing.Point(153, 290);
            this.uiSymbolButton_SaveHotKeyConfig.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_SaveHotKeyConfig.Name = "uiSymbolButton_SaveHotKeyConfig";
            this.uiSymbolButton_SaveHotKeyConfig.Size = new System.Drawing.Size(297, 55);
            this.uiSymbolButton_SaveHotKeyConfig.Symbol = 61639;
            this.uiSymbolButton_SaveHotKeyConfig.SymbolOffset = new System.Drawing.Point(-10, 0);
            this.uiSymbolButton_SaveHotKeyConfig.SymbolSize = 30;
            this.uiSymbolButton_SaveHotKeyConfig.TabIndex = 11;
            this.uiSymbolButton_SaveHotKeyConfig.Text = "保存配置";
            this.uiSymbolButton_SaveHotKeyConfig.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SaveHotKeyConfig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_SaveHotKeyConfig.Click += new System.EventHandler(this.uiSymbolButton_SaveHotKeyConfig_Click);
            // 
            // uiCheckBox_HotKey_ShiftF8
            // 
            this.uiCheckBox_HotKey_ShiftF8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_HotKey_ShiftF8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_HotKey_ShiftF8.Location = new System.Drawing.Point(153, 243);
            this.uiCheckBox_HotKey_ShiftF8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_HotKey_ShiftF8.Name = "uiCheckBox_HotKey_ShiftF8";
            this.uiCheckBox_HotKey_ShiftF8.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_HotKey_ShiftF8.Size = new System.Drawing.Size(331, 29);
            this.uiCheckBox_HotKey_ShiftF8.TabIndex = 4;
            this.uiCheckBox_HotKey_ShiftF8.Text = "Shift+F8 断开当前拨号连接";
            this.uiCheckBox_HotKey_ShiftF8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCheckBox_HotKey_ShiftF7
            // 
            this.uiCheckBox_HotKey_ShiftF7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_HotKey_ShiftF7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_HotKey_ShiftF7.Location = new System.Drawing.Point(153, 185);
            this.uiCheckBox_HotKey_ShiftF7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_HotKey_ShiftF7.Name = "uiCheckBox_HotKey_ShiftF7";
            this.uiCheckBox_HotKey_ShiftF7.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_HotKey_ShiftF7.Size = new System.Drawing.Size(297, 29);
            this.uiCheckBox_HotKey_ShiftF7.TabIndex = 3;
            this.uiCheckBox_HotKey_ShiftF7.Text = "Shift+F7 一键拨号连接";
            this.uiCheckBox_HotKey_ShiftF7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCheckBox_HotKey_ShiftF6
            // 
            this.uiCheckBox_HotKey_ShiftF6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_HotKey_ShiftF6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_HotKey_ShiftF6.Location = new System.Drawing.Point(153, 127);
            this.uiCheckBox_HotKey_ShiftF6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_HotKey_ShiftF6.Name = "uiCheckBox_HotKey_ShiftF6";
            this.uiCheckBox_HotKey_ShiftF6.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_HotKey_ShiftF6.Size = new System.Drawing.Size(313, 29);
            this.uiCheckBox_HotKey_ShiftF6.TabIndex = 2;
            this.uiCheckBox_HotKey_ShiftF6.Text = "Shift+F6 重新拨号更换IP";
            this.uiCheckBox_HotKey_ShiftF6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCheckBox_HotKey_ShiftF5
            // 
            this.uiCheckBox_HotKey_ShiftF5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_HotKey_ShiftF5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_HotKey_ShiftF5.Location = new System.Drawing.Point(153, 69);
            this.uiCheckBox_HotKey_ShiftF5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_HotKey_ShiftF5.Name = "uiCheckBox_HotKey_ShiftF5";
            this.uiCheckBox_HotKey_ShiftF5.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_HotKey_ShiftF5.Size = new System.Drawing.Size(280, 29);
            this.uiCheckBox_HotKey_ShiftF5.TabIndex = 1;
            this.uiCheckBox_HotKey_ShiftF5.Text = "Shift+F5 快速重启软件";
            this.uiCheckBox_HotKey_ShiftF5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCheckBox_HotKey_Esc
            // 
            this.uiCheckBox_HotKey_Esc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_HotKey_Esc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox_HotKey_Esc.Location = new System.Drawing.Point(153, 11);
            this.uiCheckBox_HotKey_Esc.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_HotKey_Esc.Name = "uiCheckBox_HotKey_Esc";
            this.uiCheckBox_HotKey_Esc.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_HotKey_Esc.Size = new System.Drawing.Size(177, 29);
            this.uiCheckBox_HotKey_Esc.TabIndex = 0;
            this.uiCheckBox_HotKey_Esc.Text = "Esc 退出软件";
            this.uiCheckBox_HotKey_Esc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage_About
            // 
            this.tabPage_About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPage_About.Controls.Add(this.uiSymbolButton_CheckUpdate);
            this.tabPage_About.Controls.Add(this.uiSymbolButton_SourceAddress);
            this.tabPage_About.Controls.Add(this.uiSymbolButton_ProjectPage);
            this.tabPage_About.Controls.Add(this.uiSmoothLabel1);
            this.tabPage_About.Controls.Add(this.uiSymbolLabel3);
            this.tabPage_About.Controls.Add(this.uiLabel2);
            this.tabPage_About.Controls.Add(this.uiLinkLabel1);
            this.tabPage_About.Controls.Add(this.uiAvatar1);
            this.tabPage_About.Location = new System.Drawing.Point(4, 40);
            this.tabPage_About.Name = "tabPage_About";
            this.tabPage_About.Size = new System.Drawing.Size(623, 385);
            this.tabPage_About.TabIndex = 2;
            this.tabPage_About.Text = "关于";
            // 
            // uiSymbolButton_CheckUpdate
            // 
            this.uiSymbolButton_CheckUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_CheckUpdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_CheckUpdate.Location = new System.Drawing.Point(412, 203);
            this.uiSymbolButton_CheckUpdate.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_CheckUpdate.Name = "uiSymbolButton_CheckUpdate";
            this.uiSymbolButton_CheckUpdate.Size = new System.Drawing.Size(142, 48);
            this.uiSymbolButton_CheckUpdate.Symbol = 61454;
            this.uiSymbolButton_CheckUpdate.SymbolSize = 28;
            this.uiSymbolButton_CheckUpdate.TabIndex = 8;
            this.uiSymbolButton_CheckUpdate.Text = "检查更新";
            this.uiSymbolButton_CheckUpdate.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_CheckUpdate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_CheckUpdate.Click += new System.EventHandler(this.uiSymbolButton_CheckUpdate_Click);
            // 
            // uiSymbolButton_SourceAddress
            // 
            this.uiSymbolButton_SourceAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_SourceAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SourceAddress.Location = new System.Drawing.Point(260, 203);
            this.uiSymbolButton_SourceAddress.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_SourceAddress.Name = "uiSymbolButton_SourceAddress";
            this.uiSymbolButton_SourceAddress.Size = new System.Drawing.Size(142, 48);
            this.uiSymbolButton_SourceAddress.Symbol = 61595;
            this.uiSymbolButton_SourceAddress.SymbolSize = 28;
            this.uiSymbolButton_SourceAddress.TabIndex = 7;
            this.uiSymbolButton_SourceAddress.Text = "开源地址";
            this.uiSymbolButton_SourceAddress.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_SourceAddress.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_SourceAddress.Click += new System.EventHandler(this.uiSymbolButton_SourceAddress_Click);
            // 
            // uiSymbolButton_ProjectPage
            // 
            this.uiSymbolButton_ProjectPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_ProjectPage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_ProjectPage.Location = new System.Drawing.Point(112, 203);
            this.uiSymbolButton_ProjectPage.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_ProjectPage.Name = "uiSymbolButton_ProjectPage";
            this.uiSymbolButton_ProjectPage.Size = new System.Drawing.Size(142, 48);
            this.uiSymbolButton_ProjectPage.Symbol = 62056;
            this.uiSymbolButton_ProjectPage.SymbolSize = 28;
            this.uiSymbolButton_ProjectPage.TabIndex = 6;
            this.uiSymbolButton_ProjectPage.Text = "项目页面";
            this.uiSymbolButton_ProjectPage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_ProjectPage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton_ProjectPage.Click += new System.EventHandler(this.uiSymbolButton_ProjectPage_Click);
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSmoothLabel1.Location = new System.Drawing.Point(153, 140);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.Size = new System.Drawing.Size(390, 49);
            this.uiSmoothLabel1.TabIndex = 5;
            this.uiSmoothLabel1.Text = "愿每一行代码都能改变世界";
            this.uiSmoothLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolLabel3
            // 
            this.uiSymbolLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel3.Location = new System.Drawing.Point(400, 99);
            this.uiSymbolLabel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel3.Name = "uiSymbolLabel3";
            this.uiSymbolLabel3.Padding = new System.Windows.Forms.Padding(34, 0, 0, 0);
            this.uiSymbolLabel3.Size = new System.Drawing.Size(79, 35);
            this.uiSymbolLabel3.Symbol = 61734;
            this.uiSymbolLabel3.SymbolOffset = new System.Drawing.Point(2, 0);
            this.uiSymbolLabel3.SymbolSize = 30;
            this.uiSymbolLabel3.TabIndex = 4;
            this.uiSymbolLabel3.Text = "1.0";
            this.uiSymbolLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(146, 37);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(431, 62);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "易拨 - 自动拨号上网";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLinkLabel1
            // 
            this.uiLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.uiLinkLabel1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.uiLinkLabel1.Location = new System.Drawing.Point(151, 99);
            this.uiLinkLabel1.Name = "uiLinkLabel1";
            this.uiLinkLabel1.Size = new System.Drawing.Size(309, 41);
            this.uiLinkLabel1.TabIndex = 1;
            this.uiLinkLabel1.TabStop = true;
            this.uiLinkLabel1.Text = "From e剑终情.com";
            this.uiLinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiLinkLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.AvatarSize = 80;
            this.uiAvatar1.FillColor = System.Drawing.Color.Transparent;
            this.uiAvatar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiAvatar1.Icon = Sunny.UI.UIAvatar.UIIcon.Image;
            this.uiAvatar1.Image = ((System.Drawing.Image)(resources.GetObject("uiAvatar1.Image")));
            this.uiAvatar1.Location = new System.Drawing.Point(67, 75);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(62, 65);
            this.uiAvatar1.Style = Sunny.UI.UIStyle.Custom;
            this.uiAvatar1.SymbolSize = 80;
            this.uiAvatar1.TabIndex = 0;
            this.uiAvatar1.Text = "uiAvatar1";
            this.uiAvatar1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timer_NetChecker
            // 
            this.timer_NetChecker.Interval = 3000;
            this.timer_NetChecker.Tick += new System.EventHandler(this.timer_NetChecker_Tick);
            // 
            // uiToolTip1
            // 
            this.uiToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.uiToolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.uiToolTip1.OwnerDraw = true;
            // 
            // timer_AutoConnect
            // 
            this.timer_AutoConnect.Interval = 1000;
            this.timer_AutoConnect.Tick += new System.EventHandler(this.timer_AutoConnect_Tick);
            // 
            // timer_AutoReConnect
            // 
            this.timer_AutoReConnect.Enabled = true;
            this.timer_AutoReConnect.Interval = 6000;
            this.timer_AutoReConnect.Tick += new System.EventHandler(this.timer_AutoReConnect_Tick);
            // 
            // notifyIcon_MainForm
            // 
            this.notifyIcon_MainForm.ContextMenuStrip = this.contextMenuStrip_Main;
            this.notifyIcon_MainForm.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_MainForm.Icon")));
            this.notifyIcon_MainForm.Text = "自动拨号器 - 运行中";
            this.notifyIcon_MainForm.Visible = true;
            this.notifyIcon_MainForm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MainForm_MouseClick);
            // 
            // contextMenuStrip_Main
            // 
            this.contextMenuStrip_Main.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.软件状态ToolStripMenuItem,
            this.toolStripSeparator1,
            this.一键连接ToolStripMenuItem,
            this.退出软件ToolStripMenuItem});
            this.contextMenuStrip_Main.Name = "contextMenuStrip_Main";
            this.contextMenuStrip_Main.Size = new System.Drawing.Size(153, 106);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 软件状态ToolStripMenuItem
            // 
            this.软件状态ToolStripMenuItem.Name = "软件状态ToolStripMenuItem";
            this.软件状态ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.软件状态ToolStripMenuItem.Text = "软件状态";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 一键连接ToolStripMenuItem
            // 
            this.一键连接ToolStripMenuItem.Name = "一键连接ToolStripMenuItem";
            this.一键连接ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.一键连接ToolStripMenuItem.Text = "一键网络";
            this.一键连接ToolStripMenuItem.Click += new System.EventHandler(this.一键连接ToolStripMenuItem_Click);
            // 
            // 退出软件ToolStripMenuItem
            // 
            this.退出软件ToolStripMenuItem.Name = "退出软件ToolStripMenuItem";
            this.退出软件ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.退出软件ToolStripMenuItem.Text = "退出软件";
            this.退出软件ToolStripMenuItem.Click += new System.EventHandler(this.退出软件ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(768, 472);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.Aside);
            this.ExtendBox = true;
            this.ExtendSymbolSize = 30;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsForbidAltF4 = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "易拨 - e剑终情.com";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 720, 591);
            this.HotKeyEventHandler += new Sunny.UI.HotKeyEventHandler(this.MainForm_HotKeyEventHandler);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.tabControl.ResumeLayout(false);
            this.tabPage_Status.ResumeLayout(false);
            this.uiTitlePanel3.ResumeLayout(false);
            this.uiTitlePanel_Config.ResumeLayout(false);
            this.uiTitlePanel_NetStatus.ResumeLayout(false);
            this.tabPage_AccountConfig.ResumeLayout(false);
            this.tabPage_SoftwareConfig.ResumeLayout(false);
            this.tabPage_HotKey.ResumeLayout(false);
            this.tabPage_About.ResumeLayout(false);
            this.contextMenuStrip_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIStyleManager uiStyleManager;
        private Sunny.UI.UINavMenu Aside;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_Status;
        private System.Windows.Forms.TabPage tabPage_AccountConfig;
        private System.Windows.Forms.TabPage tabPage_About;
        private Sunny.UI.UIAvatar uiAvatar_NetStatus;
        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
        private Sunny.UI.UITitlePanel uiTitlePanel_NetStatus;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private Sunny.UI.UITitlePanel uiTitlePanel_Config;
        private Sunny.UI.UISymbolLabel uiSymbolLabel_ConnectCheck;
        private Sunny.UI.UISymbolLabel uiSymbolLabel_PingOK;
        private Sunny.UI.UISymbolLabel uiSymbolLabel_InternetDeviceType;
        private Sunny.UI.UISymbolLabel uiSymbolLabel_SoftConfigCheck;
        private Sunny.UI.UISymbolButton uiSymbolButton_ResetConfig;
        private Sunny.UI.UISymbolLabel uiSymbolLabe_AccountConfigCheck;
        private System.Windows.Forms.TabPage tabPage_SoftwareConfig;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIComboBox uiComboBox_ConnectMethod;
        private Sunny.UI.UISymbolButton uiSymbolButton_OneKeyConnect;
        private Sunny.UI.UITextBox uiTextBox_DialUpName;
        private System.Windows.Forms.TabPage tabPage_HotKey;
        private Sunny.UI.UITextBox uiTextBox_DialUpPassword;
        private Sunny.UI.UITextBox uiTextBox_DialUpAccount;
        private Sunny.UI.UISymbolLabel uiSymbolLabel2;
        private Sunny.UI.UIComboBox uiComboBox_DialUpType;
        private Sunny.UI.UISymbolButton uiSymbolButton_SaveAccountConfig;
        private Sunny.UI.UISymbolButton uiSymbolButton_AccountHelp;
        private Sunny.UI.UIProcessBar uiProcessBar_ConectProcess;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private Sunny.UI.UICheckBox uiCheckBox_AutoConnect;
        private Sunny.UI.UICheckBox uiCheckBox_AutoStart;
        private Sunny.UI.UIMarkLabel uiMarkLabel3;
        private System.Windows.Forms.Timer timer_NetChecker;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown_ReConnectCount;
        private Sunny.UI.UICheckBox uiCheckBox_AutoReConnect;
        private Sunny.UI.UIToolTip uiToolTip1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton uiSymbolButton_SaveSoftwareConfig;
        private System.Windows.Forms.Timer timer_AutoConnect;
        private System.Windows.Forms.Timer timer_AutoReConnect;
        private System.Windows.Forms.NotifyIcon notifyIcon_MainForm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem 软件状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 一键连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILinkLabel uiLinkLabel1;
        private Sunny.UI.UISymbolLabel uiSymbolLabel3;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private Sunny.UI.UISymbolButton uiSymbolButton_CheckUpdate;
        private Sunny.UI.UISymbolButton uiSymbolButton_SourceAddress;
        private Sunny.UI.UISymbolButton uiSymbolButton_ProjectPage;
        private Sunny.UI.UICheckBox uiCheckBox_HotKey_ShiftF6;
        private Sunny.UI.UICheckBox uiCheckBox_HotKey_ShiftF5;
        private Sunny.UI.UICheckBox uiCheckBox_HotKey_Esc;
        private Sunny.UI.UICheckBox uiCheckBox_HotKey_ShiftF8;
        private Sunny.UI.UICheckBox uiCheckBox_HotKey_ShiftF7;
        private Sunny.UI.UISymbolButton uiSymbolButton_SaveHotKeyConfig;
        private Sunny.UI.UISymbolButton uiSymbolButton_HotKey_ChangeIPHelp;
    }
}

