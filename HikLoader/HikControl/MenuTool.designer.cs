namespace HikUnLoader.HikControl
{
    partial class MenuTool
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
            ToolStripItemClick = null;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuTool));
            this.menuStrip_SystemMenu = new System.Windows.Forms.MenuStrip();
            this.tsmi_AcquireToolManager = new System.Windows.Forms.ToolStripMenuItem();
            this.Cam1AcquireTool = new System.Windows.Forms.ToolStripMenuItem();
            this.Cam2AcquireTool = new System.Windows.Forms.ToolStripMenuItem();
            this.Cam3AcquireTool = new System.Windows.Forms.ToolStripMenuItem();
            this.Cam4AcquireTool = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAcquireTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DebugTools = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_PLCCard = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ScreenShot = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Calculater = new System.Windows.Forms.ToolStripMenuItem();
            this.SimulateRun = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbx_ProductChoose = new System.Windows.Forms.ToolStripComboBox();
            this.CurrentUser = new System.Windows.Forms.ToolStripMenuItem();
            this.CycleTime = new System.Windows.Forms.ToolStripMenuItem();
            this.AcquireTime = new System.Windows.Forms.ToolStripTextBox();
            this.ProcessTime = new System.Windows.Forms.ToolStripTextBox();
            this.tscb_ProductAutoChoose = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip_SystemTool = new System.Windows.Forms.ToolStrip();
            this.Cam1LiveDisplay = new System.Windows.Forms.ToolStripButton();
            this.Cam2LiveDisplay = new System.Windows.Forms.ToolStripButton();
            this.Cam3LiveDisplay = new System.Windows.Forms.ToolStripButton();
            this.Cam4LiveDisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_LogIn = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_LogOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_SaveParams = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_ReadParams = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Camera1CalibTool = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Camera1Debug = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Camera2CalibTool = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Camera2Debug = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_CodeReaderDebug = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_setParameter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_ProductEditor = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_ClearStatistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.button_SystemStart = new System.Windows.Forms.ToolStripButton();
            this.button_SystemStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLable_SysRunningTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.TotalTime = new System.Windows.Forms.ToolStripLabel();
            this.timer_TimeToShow = new System.Windows.Forms.Timer(this.components);
            this.menuStrip_SystemMenu.SuspendLayout();
            this.toolStrip_SystemTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_SystemMenu
            // 
            this.menuStrip_SystemMenu.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip_SystemMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip_SystemMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip_SystemMenu.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip_SystemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_AcquireToolManager,
            this.tsmi_DebugTools,
            this.tscbx_ProductChoose,
            this.CurrentUser,
            this.CycleTime,
            this.tscb_ProductAutoChoose});
            this.menuStrip_SystemMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_SystemMenu.Name = "menuStrip_SystemMenu";
            this.menuStrip_SystemMenu.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip_SystemMenu.Size = new System.Drawing.Size(933, 29);
            this.menuStrip_SystemMenu.TabIndex = 0;
            this.menuStrip_SystemMenu.Text = "menuStrip1";
            // 
            // tsmi_AcquireToolManager
            // 
            this.tsmi_AcquireToolManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cam1AcquireTool,
            this.Cam2AcquireTool,
            this.Cam3AcquireTool,
            this.Cam4AcquireTool,
            this.SaveAcquireTool});
            this.tsmi_AcquireToolManager.Name = "tsmi_AcquireToolManager";
            this.tsmi_AcquireToolManager.Size = new System.Drawing.Size(86, 25);
            this.tsmi_AcquireToolManager.Tag = "debugger";
            this.tsmi_AcquireToolManager.Text = "取像工具";
            this.tsmi_AcquireToolManager.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DropDownItem_Click);
            // 
            // Cam1AcquireTool
            // 
            this.Cam1AcquireTool.Image = ((System.Drawing.Image)(resources.GetObject("Cam1AcquireTool.Image")));
            this.Cam1AcquireTool.Name = "Cam1AcquireTool";
            this.Cam1AcquireTool.Size = new System.Drawing.Size(199, 36);
            this.Cam1AcquireTool.Tag = "debugger";
            this.Cam1AcquireTool.Text = "相机1取像工具";
            // 
            // Cam2AcquireTool
            // 
            this.Cam2AcquireTool.Image = ((System.Drawing.Image)(resources.GetObject("Cam2AcquireTool.Image")));
            this.Cam2AcquireTool.Name = "Cam2AcquireTool";
            this.Cam2AcquireTool.Size = new System.Drawing.Size(199, 36);
            this.Cam2AcquireTool.Tag = "debugger";
            this.Cam2AcquireTool.Text = "相机2取像工具";
            // 
            // Cam3AcquireTool
            // 
            this.Cam3AcquireTool.Image = ((System.Drawing.Image)(resources.GetObject("Cam3AcquireTool.Image")));
            this.Cam3AcquireTool.Name = "Cam3AcquireTool";
            this.Cam3AcquireTool.Size = new System.Drawing.Size(199, 36);
            this.Cam3AcquireTool.Tag = "debugger";
            this.Cam3AcquireTool.Text = "相机3取像工具";
            // 
            // Cam4AcquireTool
            // 
            this.Cam4AcquireTool.Image = ((System.Drawing.Image)(resources.GetObject("Cam4AcquireTool.Image")));
            this.Cam4AcquireTool.Name = "Cam4AcquireTool";
            this.Cam4AcquireTool.Size = new System.Drawing.Size(199, 36);
            this.Cam4AcquireTool.Text = "相机4取像工具";
            // 
            // SaveAcquireTool
            // 
            this.SaveAcquireTool.Name = "SaveAcquireTool";
            this.SaveAcquireTool.Size = new System.Drawing.Size(199, 36);
            this.SaveAcquireTool.Text = "保存相机配置";
            // 
            // tsmi_DebugTools
            // 
            this.tsmi_DebugTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_PLCCard,
            this.Menu_ScreenShot,
            this.Menu_Calculater,
            this.SimulateRun});
            this.tsmi_DebugTools.Name = "tsmi_DebugTools";
            this.tsmi_DebugTools.Size = new System.Drawing.Size(86, 25);
            this.tsmi_DebugTools.Tag = "debugger";
            this.tsmi_DebugTools.Text = "调试工具";
            this.tsmi_DebugTools.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DropDownItem_Click);
            // 
            // Menu_PLCCard
            // 
            this.Menu_PLCCard.Image = ((System.Drawing.Image)(resources.GetObject("Menu_PLCCard.Image")));
            this.Menu_PLCCard.Name = "Menu_PLCCard";
            this.Menu_PLCCard.Size = new System.Drawing.Size(187, 36);
            this.Menu_PLCCard.Tag = "debugger";
            this.Menu_PLCCard.Text = "PLC通讯调试";
            this.Menu_PLCCard.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DropDownItem_Click);
            // 
            // Menu_ScreenShot
            // 
            this.Menu_ScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("Menu_ScreenShot.Image")));
            this.Menu_ScreenShot.Name = "Menu_ScreenShot";
            this.Menu_ScreenShot.Size = new System.Drawing.Size(187, 36);
            this.Menu_ScreenShot.Tag = "debugger";
            this.Menu_ScreenShot.Text = "截图工具";
            // 
            // Menu_Calculater
            // 
            this.Menu_Calculater.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Calculater.Image")));
            this.Menu_Calculater.Name = "Menu_Calculater";
            this.Menu_Calculater.Size = new System.Drawing.Size(187, 36);
            this.Menu_Calculater.Tag = "debugger";
            this.Menu_Calculater.Text = "计算器";
            // 
            // SimulateRun
            // 
            this.SimulateRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageSource});
            this.SimulateRun.Image = ((System.Drawing.Image)(resources.GetObject("SimulateRun.Image")));
            this.SimulateRun.Name = "SimulateRun";
            this.SimulateRun.Size = new System.Drawing.Size(187, 36);
            this.SimulateRun.Text = "模拟运行";
            this.SimulateRun.ToolTipText = "从文件取像模拟正常运行，通常调试时使用";
            this.SimulateRun.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DropDownItem_Click);
            // 
            // ImageSource
            // 
            this.ImageSource.CheckOnClick = true;
            this.ImageSource.Image = ((System.Drawing.Image)(resources.GetObject("ImageSource.Image")));
            this.ImageSource.Name = "ImageSource";
            this.ImageSource.Size = new System.Drawing.Size(174, 36);
            this.ImageSource.Text = "从文件取像";
            this.ImageSource.ToolTipText = "选择从文件获取图像还是从相机采集图像";
            // 
            // tscbx_ProductChoose
            // 
            this.tscbx_ProductChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbx_ProductChoose.Name = "tscbx_ProductChoose";
            this.tscbx_ProductChoose.Size = new System.Drawing.Size(188, 25);
            this.tscbx_ProductChoose.Tag = "operator";
            this.tscbx_ProductChoose.ToolTipText = "料号选择";
            this.tscbx_ProductChoose.SelectedIndexChanged += new System.EventHandler(this.ProductChoose_SelectedIndexChanged);
            // 
            // CurrentUser
            // 
            this.CurrentUser.Enabled = false;
            this.CurrentUser.Name = "CurrentUser";
            this.CurrentUser.Size = new System.Drawing.Size(86, 25);
            this.CurrentUser.Text = "当前用户";
            this.CurrentUser.ToolTipText = "当前用户";
            // 
            // CycleTime
            // 
            this.CycleTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AcquireTime,
            this.ProcessTime});
            this.CycleTime.Name = "CycleTime";
            this.CycleTime.Size = new System.Drawing.Size(169, 25);
            this.CycleTime.Text = "CycleTime：000 ms";
            this.CycleTime.ToolTipText = "检测周期";
            this.CycleTime.Visible = false;
            // 
            // AcquireTime
            // 
            this.AcquireTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AcquireTime.Enabled = false;
            this.AcquireTime.Name = "AcquireTime";
            this.AcquireTime.Size = new System.Drawing.Size(150, 16);
            this.AcquireTime.Text = "AcquireTime：000 ms";
            // 
            // ProcessTime
            // 
            this.ProcessTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProcessTime.Enabled = false;
            this.ProcessTime.Name = "ProcessTime";
            this.ProcessTime.Size = new System.Drawing.Size(150, 16);
            this.ProcessTime.Text = "ProcessTime：000 ms";
            // 
            // tscb_ProductAutoChoose
            // 
            this.tscb_ProductAutoChoose.Items.AddRange(new object[] {
            "允许从PLC系统切换料号",
            "禁止从PLC系统切换料号"});
            this.tscb_ProductAutoChoose.Name = "tscb_ProductAutoChoose";
            this.tscb_ProductAutoChoose.Size = new System.Drawing.Size(180, 25);
            this.tscb_ProductAutoChoose.Text = "允许从PLC系统切换料号";
            this.tscb_ProductAutoChoose.SelectedIndexChanged += new System.EventHandler(this.tscb_ProductAutoChoose_SelectedIndexChanged);
            // 
            // toolStrip_SystemTool
            // 
            this.toolStrip_SystemTool.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip_SystemTool.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_SystemTool.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip_SystemTool.GripMargin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.toolStrip_SystemTool.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip_SystemTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cam1LiveDisplay,
            this.Cam2LiveDisplay,
            this.Cam3LiveDisplay,
            this.Cam4LiveDisplay,
            this.toolStripSeparator1,
            this.tsbtn_LogIn,
            this.tsbtn_LogOut,
            this.toolStripSeparator6,
            this.tsbtn_SaveParams,
            this.tsbtn_ReadParams,
            this.toolStripSeparator4,
            this.tsbtn_Camera1CalibTool,
            this.tsbtn_Camera1Debug,
            this.toolStripSeparator5,
            this.tsbtn_Camera2CalibTool,
            this.tsbtn_Camera2Debug,
            this.toolStripSeparator7,
            this.tsbtn_CodeReaderDebug,
            this.tsbtn_setParameter,
            this.toolStripSeparator3,
            this.tsbtn_ProductEditor,
            this.tsbtn_ClearStatistics,
            this.toolStripSeparator2,
            this.button_SystemStart,
            this.button_SystemStop,
            this.toolStripSeparator9,
            this.tsLable_SysRunningTime,
            this.toolStripSeparator10,
            this.TotalTime});
            this.toolStrip_SystemTool.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_SystemTool.Location = new System.Drawing.Point(0, 23);
            this.toolStrip_SystemTool.Name = "toolStrip_SystemTool";
            this.toolStrip_SystemTool.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStrip_SystemTool.Size = new System.Drawing.Size(933, 49);
            this.toolStrip_SystemTool.TabIndex = 9;
            this.toolStrip_SystemTool.Text = "功能区";
            this.toolStrip_SystemTool.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DropDownItem_Click);
            // 
            // Cam1LiveDisplay
            // 
            this.Cam1LiveDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cam1LiveDisplay.Image = ((System.Drawing.Image)(resources.GetObject("Cam1LiveDisplay.Image")));
            this.Cam1LiveDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cam1LiveDisplay.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Cam1LiveDisplay.Name = "Cam1LiveDisplay";
            this.Cam1LiveDisplay.Size = new System.Drawing.Size(44, 44);
            this.Cam1LiveDisplay.Text = "相机1实时图像";
            // 
            // Cam2LiveDisplay
            // 
            this.Cam2LiveDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cam2LiveDisplay.Image = ((System.Drawing.Image)(resources.GetObject("Cam2LiveDisplay.Image")));
            this.Cam2LiveDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cam2LiveDisplay.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Cam2LiveDisplay.Name = "Cam2LiveDisplay";
            this.Cam2LiveDisplay.Size = new System.Drawing.Size(44, 44);
            this.Cam2LiveDisplay.Text = "相机2实时图像";
            // 
            // Cam3LiveDisplay
            // 
            this.Cam3LiveDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cam3LiveDisplay.Image = ((System.Drawing.Image)(resources.GetObject("Cam3LiveDisplay.Image")));
            this.Cam3LiveDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cam3LiveDisplay.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Cam3LiveDisplay.Name = "Cam3LiveDisplay";
            this.Cam3LiveDisplay.Size = new System.Drawing.Size(44, 44);
            this.Cam3LiveDisplay.Text = "相机3实时图像";
            // 
            // Cam4LiveDisplay
            // 
            this.Cam4LiveDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cam4LiveDisplay.Image = ((System.Drawing.Image)(resources.GetObject("Cam4LiveDisplay.Image")));
            this.Cam4LiveDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cam4LiveDisplay.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Cam4LiveDisplay.Name = "Cam4LiveDisplay";
            this.Cam4LiveDisplay.Size = new System.Drawing.Size(44, 44);
            this.Cam4LiveDisplay.Text = "相机4实时图像";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtn_LogIn
            // 
            this.tsbtn_LogIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_LogIn.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_LogIn.Image")));
            this.tsbtn_LogIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_LogIn.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.tsbtn_LogIn.Name = "tsbtn_LogIn";
            this.tsbtn_LogIn.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_LogIn.Tag = "all";
            this.tsbtn_LogIn.Text = "用户登录";
            // 
            // tsbtn_LogOut
            // 
            this.tsbtn_LogOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_LogOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_LogOut.Image")));
            this.tsbtn_LogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_LogOut.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.tsbtn_LogOut.Name = "tsbtn_LogOut";
            this.tsbtn_LogOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbtn_LogOut.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_LogOut.Tag = "all";
            this.tsbtn_LogOut.Text = "用户注销";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtn_SaveParams
            // 
            this.tsbtn_SaveParams.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_SaveParams.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_SaveParams.Image")));
            this.tsbtn_SaveParams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_SaveParams.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.tsbtn_SaveParams.Name = "tsbtn_SaveParams";
            this.tsbtn_SaveParams.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_SaveParams.Tag = "debugger";
            this.tsbtn_SaveParams.Text = "保存参数";
            // 
            // tsbtn_ReadParams
            // 
            this.tsbtn_ReadParams.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ReadParams.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ReadParams.Image")));
            this.tsbtn_ReadParams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ReadParams.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.tsbtn_ReadParams.Name = "tsbtn_ReadParams";
            this.tsbtn_ReadParams.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_ReadParams.Tag = "debugger";
            this.tsbtn_ReadParams.Text = "读取参数";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtn_Camera1CalibTool
            // 
            this.tsbtn_Camera1CalibTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Camera1CalibTool.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Camera1CalibTool.Image")));
            this.tsbtn_Camera1CalibTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Camera1CalibTool.Name = "tsbtn_Camera1CalibTool";
            this.tsbtn_Camera1CalibTool.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_Camera1CalibTool.Text = "相机1标定";
            // 
            // tsbtn_Camera1Debug
            // 
            this.tsbtn_Camera1Debug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Camera1Debug.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Camera1Debug.Image")));
            this.tsbtn_Camera1Debug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Camera1Debug.Name = "tsbtn_Camera1Debug";
            this.tsbtn_Camera1Debug.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_Camera1Debug.Text = "相机1调试";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtn_Camera2CalibTool
            // 
            this.tsbtn_Camera2CalibTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Camera2CalibTool.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Camera2CalibTool.Image")));
            this.tsbtn_Camera2CalibTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Camera2CalibTool.Name = "tsbtn_Camera2CalibTool";
            this.tsbtn_Camera2CalibTool.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_Camera2CalibTool.Text = "相机2标定";
            // 
            // tsbtn_Camera2Debug
            // 
            this.tsbtn_Camera2Debug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Camera2Debug.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Camera2Debug.Image")));
            this.tsbtn_Camera2Debug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Camera2Debug.Name = "tsbtn_Camera2Debug";
            this.tsbtn_Camera2Debug.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_Camera2Debug.Text = "相机2调试";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtn_CodeReaderDebug
            // 
            this.tsbtn_CodeReaderDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_CodeReaderDebug.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_CodeReaderDebug.Image")));
            this.tsbtn_CodeReaderDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_CodeReaderDebug.Name = "tsbtn_CodeReaderDebug";
            this.tsbtn_CodeReaderDebug.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_CodeReaderDebug.Text = "读码器调试";
            // 
            // tsbtn_setParameter
            // 
            this.tsbtn_setParameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_setParameter.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_setParameter.Image")));
            this.tsbtn_setParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_setParameter.Name = "tsbtn_setParameter";
            this.tsbtn_setParameter.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_setParameter.Text = "参数设置";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtn_ProductEditor
            // 
            this.tsbtn_ProductEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ProductEditor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ProductEditor.Image")));
            this.tsbtn_ProductEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ProductEditor.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.tsbtn_ProductEditor.Name = "tsbtn_ProductEditor";
            this.tsbtn_ProductEditor.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_ProductEditor.Tag = "debugger";
            this.tsbtn_ProductEditor.Text = "料号编辑";
            // 
            // tsbtn_ClearStatistics
            // 
            this.tsbtn_ClearStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ClearStatistics.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ClearStatistics.Image")));
            this.tsbtn_ClearStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ClearStatistics.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.tsbtn_ClearStatistics.Name = "tsbtn_ClearStatistics";
            this.tsbtn_ClearStatistics.Size = new System.Drawing.Size(44, 44);
            this.tsbtn_ClearStatistics.Tag = "operator";
            this.tsbtn_ClearStatistics.Text = "统计清零";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // button_SystemStart
            // 
            this.button_SystemStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_SystemStart.Image = ((System.Drawing.Image)(resources.GetObject("button_SystemStart.Image")));
            this.button_SystemStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_SystemStart.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.button_SystemStart.Name = "button_SystemStart";
            this.button_SystemStart.Size = new System.Drawing.Size(44, 44);
            this.button_SystemStart.Text = "开始";
            // 
            // button_SystemStop
            // 
            this.button_SystemStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_SystemStop.Image = ((System.Drawing.Image)(resources.GetObject("button_SystemStop.Image")));
            this.button_SystemStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_SystemStop.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.button_SystemStop.Name = "button_SystemStop";
            this.button_SystemStop.Size = new System.Drawing.Size(44, 44);
            this.button_SystemStop.Text = "停止";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Margin = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 49);
            // 
            // tsLable_SysRunningTime
            // 
            this.tsLable_SysRunningTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsLable_SysRunningTime.Image = ((System.Drawing.Image)(resources.GetObject("tsLable_SysRunningTime.Image")));
            this.tsLable_SysRunningTime.Margin = new System.Windows.Forms.Padding(5, 1, 50, 2);
            this.tsLable_SysRunningTime.Name = "tsLable_SysRunningTime";
            this.tsLable_SysRunningTime.Size = new System.Drawing.Size(51, 40);
            this.tsLable_SysRunningTime.Text = ":";
            this.tsLable_SysRunningTime.ToolTipText = "本次运行时间";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 49);
            // 
            // TotalTime
            // 
            this.TotalTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.TotalTime.Image = ((System.Drawing.Image)(resources.GetObject("TotalTime.Image")));
            this.TotalTime.Margin = new System.Windows.Forms.Padding(5, 1, 50, 2);
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.Size = new System.Drawing.Size(51, 40);
            this.TotalTime.Text = ":";
            this.TotalTime.ToolTipText = "总运行时间";
            // 
            // timer_TimeToShow
            // 
            this.timer_TimeToShow.Interval = 1000;
            this.timer_TimeToShow.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MenuTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.toolStrip_SystemTool);
            this.Controls.Add(this.menuStrip_SystemMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuTool";
            this.Size = new System.Drawing.Size(933, 72);
            this.Load += new System.EventHandler(this.MenuTool_Load);
            this.menuStrip_SystemMenu.ResumeLayout(false);
            this.menuStrip_SystemMenu.PerformLayout();
            this.toolStrip_SystemTool.ResumeLayout(false);
            this.toolStrip_SystemTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// 系统菜单
        /// </summary>
        private System.Windows.Forms.MenuStrip menuStrip_SystemMenu;

        /// <summary>
        /// 调试工具
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem tsmi_DebugTools;
        /// <summary>
        /// PLC调试
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem Menu_PLCCard;
        /// <summary>
        /// 屏幕截图
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem Menu_ScreenShot;
        /// <summary>
        /// 计算器
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem Menu_Calculater;
        /// <summary>
        ///  模拟运行
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem SimulateRun;
        /// <summary>
        /// 调试工具：从文件取像
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem ImageSource;

        /// <summary>
        /// 料号切换
        /// </summary>
        private System.Windows.Forms.ToolStripComboBox tscbx_ProductChoose;
        /// <summary>
        /// 当前用户
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem CurrentUser;

        /// <summary>
        /// 系统工具
        /// </summary>
        internal System.Windows.Forms.ToolStrip toolStrip_SystemTool;

        /// <summary>
        /// 用户登录
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_LogIn;
        /// <summary>
        /// 用户登出
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_LogOut;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;

        /// <summary>
        /// 系统本次运行时间
        /// </summary>
        private System.Windows.Forms.ToolStripLabel tsLable_SysRunningTime;
        /// <summary>
        /// 系统总共运行时间
        /// </summary>
        private System.Windows.Forms.ToolStripLabel TotalTime;
        /// <summary>
        /// 系统运行时间显示
        /// </summary>
        private System.Windows.Forms.Timer timer_TimeToShow;
        private System.Windows.Forms.ToolStripMenuItem CycleTime;
        private System.Windows.Forms.ToolStripTextBox AcquireTime;
        private System.Windows.Forms.ToolStripTextBox ProcessTime;
        /// <summary>
        /// 相机配置工具
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem tsmi_AcquireToolManager;
        /// <summary>
        /// 相机1配置
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem Cam1AcquireTool;
        /// <summary>
        /// 相机2配置
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem Cam2AcquireTool;
        /// <summary>
        /// 相机3配置
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem Cam3AcquireTool;
        /// <summary>
        /// 相机4配置
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem Cam4AcquireTool;

        /// <summary>
        /// 相机1画面实时显示
        /// </summary>
        private System.Windows.Forms.ToolStripButton Cam1LiveDisplay;
        /// <summary>
        /// 相机2画面实时显示
        /// </summary>
        private System.Windows.Forms.ToolStripButton Cam2LiveDisplay;
        /// <summary>
        /// 相机3画面实时显示
        /// </summary>
        private System.Windows.Forms.ToolStripButton Cam3LiveDisplay;
        /// <summary>
        /// 相机4画面实时显示
        /// </summary>
        private System.Windows.Forms.ToolStripButton Cam4LiveDisplay;
        /// <summary>
        /// 系统启动
        /// </summary>
        private System.Windows.Forms.ToolStripButton button_SystemStart;
        /// <summary>
        /// 系统停止
        /// </summary>
        private System.Windows.Forms.ToolStripButton button_SystemStop;
        /// <summary>
        /// 相机1示教位设置
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_Camera1Debug;
        /// <summary>
        /// 相机2示教位设置
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_Camera2Debug;
        /// <summary>
        /// 读码器调试
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_CodeReaderDebug;
        /// <summary>
        /// 参数设置
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_setParameter;
        /// <summary>
        /// 相机1自动标定
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_Camera1CalibTool;
        /// <summary>
        /// 相机2自动标定
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_Camera2CalibTool;
        /// <summary>
        /// 保存数据
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_SaveParams;
        /// <summary>
        /// 读取数据
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_ReadParams;
        /// <summary>
        /// 料号编辑
        /// </summary>
        private System.Windows.Forms.ToolStripButton tsbtn_ProductEditor;
        /// <summary>
        /// 统计数据清零
        /// </summary>
        internal System.Windows.Forms.ToolStripButton tsbtn_ClearStatistics;
        private System.Windows.Forms.ToolStripComboBox tscb_ProductAutoChoose;
        private System.Windows.Forms.ToolStripMenuItem SaveAcquireTool;
    }
}
