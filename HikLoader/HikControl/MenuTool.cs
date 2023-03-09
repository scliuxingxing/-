using GlobalCameraModuleCs;
using HikUnLoader.HikClass;
using HikUnLoader.HikFrom;
using HikUnLoader.plc;
using ImageSourceModuleCs;
using IMVSCalibTransformModuCs;
using IMVSCaliperCornerModuCs;
using IMVSFastFeatureMatchModuCs;
using IMVSQuadrangleFindModuCs;
using ScaipMDAS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;
using static ImageSourceModuleCs.ImageSourceParam;

namespace HikUnLoader.HikControl
{
    /// <summary>
    /// 菜单和工具栏项功能定义
    /// </summary>
    public enum ItemsFunc
    {
        /// <summary>清除统计数据 </summary>
        ClearStatistics = 0,
        /// <summary>停止应用程序 </summary>
        StopApplication,
        /// <summary>退出应用程序 </summary>
        ExitApplication,
        /// <summary>启动检测 </summary>
        Run,
        /// <summary>模拟检测 </summary>
        SimulateRun,
        /// <summary>停止检测 </summary>
        Stop,
        /// <summary>模拟运行模式</summary>
        SimulateMode,
        /// <summary>模拟取像模式 </summary>
        AcquireMode,
        /// <summary>停止单次模拟 </summary>
        StopSimulateOnce,
        /// <summary>用户登陆 </summary>
        LogIn,
        /// <summary>用户退出 </summary>
        LogOut,
        /// <summary>保存参数到文件</summary>
        SaveParams,
        /// <summary>从文件读取参数 </summary>
        ReadParams,
        /// <summary>多料号编辑 </summary>
        ProductEditor,
        /// <summary>相机1实时 </summary>
        Cam1Live,
        /// <summary>相机2实时 </summary>
        Cam2Live,
        /// <summary>相机3实时 </summary>
        Cam3Live,
        /// <summary>相机4实时 </summary>
        Cam4Live,
        /// <summary>相机5实时 </summary>
        Cam5Live,
        /// <summary>相机1取像工具 </summary>
        Cam1Acqfifo,
        /// <summary>相机2取像工具 </summary>
        Cam2Acqfifo,
        /// <summary>相机3取像工具 </summary>
        Cam3Acqfifo,
        /// <summary>相机4取像工具 </summary> 
        Cam4Acqfifo,
        /// <summary>保存取像工具 </summary>
        SaveAcqfifo,
        /// <summary>IO配置</summary>
        IOCardConfig,
        /// <summary>IO卡监控 </summary>
        IOCardMotion,
        /// <summary>截屏工具 </summary>
        ScreenShot,
        /// <summary>系统计算器 </summary>
        Calculater,
        /// <summary>显示三维图像 </summary> 
        Viewer3D,
        /// <summary>设置3D相机参数 </summary> 
        CameraConfig,
        /// <summary>相机调试界面 </summary> 
        CameraDebugFrom,
        /// <summary>读码器调试界面 </summary> 
        CordDebugFrom,
        /// <summary>参数调试界面 </summary> 
        ParameterFrom,
        /// <summary>未定义 </summary>
        NON
    };

    /// <summary>
    /// 菜单和工具栏项单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="ItemFunc"></param>
    public delegate void ItemClick(object sender, ItemsFunc ItemFunc);

    /// <summary>
    /// 结构体：定义模拟运行属性
    /// </summary>
    public struct SimulateOption
    {
        /// <summary>模拟运行图像来源，true为从相机取像，false从文件取像 </summary>
        public bool ImageSource { set; get; }
        /// <summary>模拟运行，false单次运行，true连续运行 </summary>
        public bool RunContinous { set; get; }
        /// <summary>文件读取选项，false表示读取固定的图像，true表示在文件夹循环读取图像 </summary>
        public bool CycleRead { set; get; }
    }

    /// <summary>
    /// 菜单工具栏自定义控件 
    /// </summary>
    public partial class MenuTool : UserControl
    {
        /// <summary>
        /// 菜单工具栏项单击事件
        /// </summary>
        public event ItemClick ToolStripItemClick;

        /// <summary>
        /// 当前料号名称
        /// </summary>
        private string _currentProduct = string.Empty;

        /// <summary>
        /// 程序是否已经运行
        /// </summary>
        private bool running;

        /// <summary>
        /// 模拟运行选项
        /// </summary>
        private SimulateOption simulateOption;

        /// <summary>
        /// 当前用户ID，操作员:1,调试员:2,管理员:3,其他:无用户
        /// </summary>
        private LogUser userID;

        /// <summary>
        /// 系统历史运行总时间
        /// </summary>
        private TimeSpan totalSysRunningTime;

        /// <summary>
        /// 系统实时显示的运行总时间
        /// </summary>
        private TimeSpan SysRunningTime;

        /// <summary>
        /// 系统本次启动时间
        /// </summary>
        private DateTime startTime = DateTime.Now;

        ///// <summary>
        ///// 耗时
        ///// </summary>
        //public string esplaedTime;

        /// <summary>
        /// 设置或读取相机个数
        /// </summary>
        private int cameraNum = 0;

        /// <summary>
        /// 是否加载“产品构成”文件，true表示要加载，false表示不加载
        /// </summary>
        public bool loadProductMix = true;

        /// <summary>当前料号文件路径，位于参数文件夹下 </summary>
        public string currentProductPath = string.Empty;
        /// <summary>当前料号序列化文件夹路径，位于参数文件夹下 </summary>
        public string currentSerializePath = string.Empty;
        ///<summary>当前料号方案文件夹路径，位于参数文件夹下 </summary>
        public string currentVppPath = string.Empty;

        /// <summary>
        /// 用于判断相机的连接状态
        /// </summary>
        private string cameraConnectionStatus;
        //private string strVal11;

        /// <summary>
        /// 用来监测相机是否连接的字符串,"$"
        /// </summary>
        private string cameraConnectedStr = "$";

        /// <summary>
        /// 相机1工具
        /// </summary>
        private GlobalCameraModuleTool Camera1Tool;

        /// <summary>
        /// 相机2工具
        /// </summary>
        private GlobalCameraModuleTool Camera2Tool;

        /// <summary>
        /// 相机1调试窗体：示教位设置
        /// </summary>
        private Camera1DebugForm form_Camera1Debug;

        /// <summary>
        /// 相机2调试窗体：示教位设置
        /// </summary>
        private Camera2DebugForm form_Camera2Debug;

        /// <summary> 
        /// 相机1自动标定窗体
        /// </summary>
        private CameraCalibrateForm form_camera1Calibration;

        /// <summary> 
        /// 相机2自动标定窗体
        /// </summary>
        private CameraCalibrateForm form_camera2Calibration;

        /// <summary>
        /// 相机1示教位调试流程
        /// </summary>
        public VmProcedure vmProcedureCam1Debug;

        /// <summary>
        /// 相机2示教位调试流程
        /// </summary>
        public VmProcedure vmProcedureCam2Debug;

        /// <summary>
        /// 相机1标定调试流程
        /// </summary>
        private VmProcedure vmProcedureCam1Calibration;

        /// <summary>
        /// 相机2标定调试流程
        /// </summary>
        private VmProcedure vmProcedureCam2Calibration;

        /// <summary>
        /// 参数设置界面窗体
        /// </summary>
        private ParameterForm form_ParameterConfigure = new ParameterForm();

        /// <summary>
        /// 相机1实时显示窗体
        /// </summary>
        private CameraRealtimeDisplayForm form_Camera1RealTimeDisplay;

        /// <summary>
        /// 相机2实时显示窗体
        /// </summary>
        private CameraRealtimeDisplayForm form_Camera2RealTimeDisplay;

        /// <summary> 
        /// 相机自身参数设置：曝光、增益等 
        /// </summary>
        private CameraData cameraData;

        /// <summary> 
        /// 相机1配置窗体 
        /// </summary>
        private CamerConfigureForm form_Camer1Configuration;

        /// <summary> 
        /// 相机2配置窗体 
        /// </summary>
        private CamerConfigureForm form_Camer2Configuration;

        /// <summary>
        /// PLC调试窗体
        /// </summary>
        private McProtocolTestForm form_PLCDebug;

        /// <summary> 
        /// 相机实时画面显示窗体，需要更新数据
        /// </summary>
        public MultiCameraShow form_MultiCamShow;

        /// <summary> 
        /// 信息显示栏：版本号、用户、相机CT等信息
        /// </summary>
        public CustomStatusStrip css_ShowMessages;

        /// <summary> 
        /// 相机1拍照后结果（点，角度）
        /// </summary>
        private List<Result> camera1Result;

        /// <summary>
        /// 相机2拍照后结果（点，角度）
        /// </summary>
        private List<Result> camera2Result;

        /// <summary>制表符,在Excel中表示换列 </summary>
        public const string TabChar = "\t";

        /// <summary>
        /// 拍照时匹配到的模板个数？
        /// </summary>
        private int cameraModelsAmount = 0;

        /// <summary>
        /// 相机1是否配置
        /// </summary>
        private bool camera1IsConnect;

        /// <summary>
        /// 相机2是否配置
        /// </summary>
        private bool camera2sConnect;

        /// <summary>
        /// 用于计时
        /// </summary>
        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// 视觉系统运行线程
        /// </summary>
        public BackgroundWorker bgw_VisualSystemRunning = new BackgroundWorker();

        /// <summary>
        /// 产品料号自动切换线程
        /// </summary>
        public BackgroundWorker bgw_ProductAutoChange = new BackgroundWorker();

        /// <summary>
        /// 与读码器通讯串口
        /// </summary>
        private SerialPort codeReaderPort;

        /// <summary>
        /// PLC是否给信号读取二维码 
        /// </summary>
        private bool plcReadQR = false;

        /// <summary>
        /// 相机2正反，正为1，反为2，未匹配到为0
        /// </summary>
        private int PmaZ = 0;

        /// <summary>
        /// 构造方法
        /// </summary>
        public MenuTool()
        {
            InitializeComponent();
            //默认用户是操作员：UserID = 1
            UserID = LogUser.操作员;
            try
            {
                totalSysRunningTime = TimeSpan.Parse(INIManager.IniReadValue("运行时间", "间隔", GlobleModule.ConfigFilePath));
            }
            catch (Exception)
            {
                totalSysRunningTime = TimeSpan.Zero;
            }
            camera1Result = new List<Result>(Parameter.productMax);
            camera2Result = new List<Result>(Parameter.productMax);

        }

        /// <summary>
        /// 事件处理器：窗体加载时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuTool_Load(object sender, EventArgs e)
        {

            //初始化视觉系统运行线程
            bgw_VisualSystemRunning.DoWork += Bgw_VisualSystemRunning_DoWork;
            bgw_VisualSystemRunning.WorkerSupportsCancellation = true;

            //产品料号自动切换线程
            bgw_ProductAutoChange.DoWork += Bgw_ProductAutoChange_DoWork;
            bgw_ProductAutoChange.WorkerSupportsCancellation = true;
            tscb_ProductAutoChoose.SelectedIndex = 1;
            tscb_ProductAutoChoose_SelectedIndexChanged(this, new EventArgs());

        }

        /// <summary>
        /// 事件处理器:菜单工具栏项单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (ToolStripItemClick == null) { return; }
                ToolStripItem clickItem = e.ClickedItem;
                string clickItemName = clickItem.Name;
                ItemsFunc itemsFunc = ItemsFunc.NON;
                switch (clickItemName)
                {
                    case nameof(tsbtn_LogIn)://用户登录                       
                        UserLoginForm form_UserLogin = new UserLoginForm();
                        //模态窗口close后并不会释放资源，应显示调用dispose
                        //非模态窗口close会调用dispose方法，不用显示调用
                        form_UserLogin.ShowDialog();
                        UserID = form_UserLogin.GetUserID;
                        form_UserLogin.Dispose();
                        itemsFunc = ItemsFunc.LogIn;
                        break;
                    case nameof(tsbtn_LogOut)://用户登出
                        UserID = LogUser.无用户;
                        RefreshControlEnabledStatus();
                        //statusStrip.LogUser = UserID = LogUser.无用户;
                        itemsFunc = ItemsFunc.LogOut;
                        break;
                    case nameof(tsbtn_ProductEditor)://料号编辑
                        ProductEditor editor = new ProductEditor();
                        editor.ShowDialog();
                        if (_currentProduct != editor.GetCurrentProduct)
                        {
                            CurrentProduct = editor.GetCurrentProduct;
                            RefreshProductComboBox();
                            itemsFunc = ItemsFunc.ProductEditor;
                        }
                        editor.Dispose();
                        break;
                    case nameof(Menu_PLCCard)://PLC调试窗体
                        form_PLCDebug = new McProtocolTestForm();
                        form_PLCDebug.ShowDialog();
                        form_PLCDebug.Dispose();
                        break;
                    case "Menu_IOMotion":
                        tsmi_DebugTools.HideDropDown();
                        itemsFunc = ItemsFunc.IOCardMotion;
                        break;
                    case nameof(Menu_ScreenShot)://屏幕截图
                        tsmi_DebugTools.HideDropDown();
                        itemsFunc = ItemsFunc.ScreenShot;
                        break;
                    case nameof(Menu_Calculater)://计算器
                        tsmi_DebugTools.HideDropDown();
                        itemsFunc = ItemsFunc.Calculater;
                        break;
                    case nameof(SimulateRun)://模拟运行
                        tsmi_DebugTools.HideDropDown();
                        //itemsFunc = ItemsFunc.SimulateRun;
                        Running = true;
                        SimulationRun();
                        button_SystemStop.Enabled = true;
                        break;
                    case nameof(ImageSource):
                        tsmi_DebugTools.HideDropDown();
                        ImageSource.Text = SimulateOption.ImageSource ? "从文件取像" : "从相机取像";
                        simulateOption.ImageSource = !simulateOption.ImageSource;
                        break;
                    case nameof(tsbtn_SaveParams):///保存数据
                        if (MessageBox.Show("确定要将当前参数保存到文件？", "保存参数", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            itemsFunc = ItemsFunc.SaveParams;
                        }
                        break;
                    case nameof(tsbtn_ReadParams):///读取数据
                        if (MessageBox.Show("是否确认从文件读取参数?\n当前参数将会被覆盖!", "读取参数", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            itemsFunc = ItemsFunc.ReadParams;
                        }
                        break;
                    case nameof(tsbtn_ClearStatistics)://清除统计数据
                        if (MessageBox.Show("确定要清除统计数据？", "统计清零", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            itemsFunc = ItemsFunc.ClearStatistics;
                        }
                        break;
                    case nameof(Cam1LiveDisplay)://相机1画面实时显示
                        ReadExposureTime(CameraName.相机1);
                        form_Camera1RealTimeDisplay = new CameraRealtimeDisplayForm(CameraName.相机1, vmProcedureCam1Debug, cameraData, Camera1Tool, out bool formopen);
                        if (formopen)
                        {
                            form_Camera1RealTimeDisplay.ShowDialog();
                        }
                        break;
                    case nameof(Cam2LiveDisplay)://相机2画面实时显示
                        ReadExposureTime(CameraName.相机2);
                        form_Camera2RealTimeDisplay = new CameraRealtimeDisplayForm(CameraName.相机2, vmProcedureCam2Debug, cameraData, Camera2Tool, out bool formopen1);
                        if (formopen1)
                        {
                            form_Camera2RealTimeDisplay.ShowDialog();
                        }
                        break;
                    case nameof(Cam3LiveDisplay)://相机3画面实时显示
                        itemsFunc = ItemsFunc.Cam3Live;
                        break;
                    case nameof(Cam4LiveDisplay)://相机4画面实时显示
                        itemsFunc = ItemsFunc.Cam4Live;
                        break;
                    case nameof(Cam1AcquireTool)://相机1配置
                        tsmi_AcquireToolManager.HideDropDown();
                        form_Camer1Configuration = new CamerConfigureForm(vmProcedureCam1Debug);
                        form_Camer1Configuration.ShowDialog();
                        UpdateCameraTool(CameraName.相机1);
                        break;
                    case nameof(Cam2AcquireTool)://相机2配置
                        tsmi_AcquireToolManager.HideDropDown();
                        form_Camer2Configuration = new CamerConfigureForm(vmProcedureCam2Debug);
                        form_Camer2Configuration.ShowDialog();
                        UpdateCameraTool(CameraName.相机2);
                        break;
                    case nameof(Cam3AcquireTool)://相机3配置
                        tsmi_AcquireToolManager.HideDropDown();
                        itemsFunc = ItemsFunc.Cam3Acqfifo;
                        break;
                    case nameof(Cam4AcquireTool)://相机4配置
                        tsmi_AcquireToolManager.HideDropDown();
                        itemsFunc = ItemsFunc.Cam4Acqfifo;
                        break;
                    case nameof(SaveAcquireTool)://保存相机配置
                        tsmi_AcquireToolManager.HideDropDown();
                        itemsFunc = ItemsFunc.SaveAcqfifo;
                        break;
                    case nameof(tsbtn_Camera1Debug)://相机1示教位设置
                        form_Camera1Debug = new Camera1DebugForm(CameraName.相机1, vmProcedureCam1Debug, Camera1Tool);
                        if (form_Camera1Debug.CameraIsConnect)
                        {
                            form_Camera1Debug.ShowDialog();
                        }
                        break;
                    case nameof(tsbtn_Camera2Debug)://相机2示教位设置
                        form_Camera2Debug = new Camera2DebugForm(vmProcedureCam2Debug, Camera1Tool);
                        if (form_Camera2Debug.CameraIsConnect)
                        {
                            form_Camera2Debug.ShowDialog();
                        }
                        break;
                    case nameof(tsbtn_Camera1CalibTool)://相机1自动标定
                        form_camera1Calibration = new CameraCalibrateForm(CameraName.相机1, vmProcedureCam1Calibration);
                        if (form_camera1Calibration.cameraIsConnect)
                        {
                            form_camera1Calibration.ShowDialog();
                        }
                        break;
                    case nameof(tsbtn_Camera2CalibTool)://相机2自动标定
                        form_camera2Calibration = new CameraCalibrateForm(CameraName.相机2, vmProcedureCam2Calibration);
                        if (form_camera2Calibration.cameraIsConnect)
                        {
                            form_camera2Calibration.ShowDialog();
                        }
                        break;
                    case nameof(tsbtn_CodeReaderDebug)://读码器调试
                        CodeReaderDebugForm codeReaderDebug = new CodeReaderDebugForm();
                        codeReaderDebug.ShowDialog();
                        codeReaderDebug.Dispose();
                        break;
                    case nameof(tsbtn_setParameter)://参数设置
                        form_ParameterConfigure.ShowDialog();
                        break;
                    case nameof(button_SystemStart)://系统启动
                        if (!Parameter.PLC_Client.Connected)
                        {
                            MessageBox.Show("PLC未连接!!!");
                            return;
                        }
                        if (!Camera1IsConnected)//&& Cmaera2IsConnected)
                        {
                            MessageBox.Show("相机未连接!!!");
                            return;
                        }
                        InitializeCodeReaderPort();
                        Running = true;
                        button_SystemStart.Enabled = false;
                        button_SystemStop.Enabled = true;
                        //如果线程没有启动则开启
                        if (!bgw_VisualSystemRunning.IsBusy)
                        {
                            bgw_VisualSystemRunning.RunWorkerAsync();
                        }
                        break;
                    case nameof(button_SystemStop)://系统停止
                        if (codeReaderPort != null)
                        {
                            if (codeReaderPort.IsOpen)
                            {
                                codeReaderPort.Close();
                            }
                            codeReaderPort.Dispose();
                        }
                        GlobleModule.LogInfo = "释放读码器串口资源";
                        Running = false;
                        button_SystemStart.Enabled = true;
                        button_SystemStop.Enabled = false;
                        //如果线程处于运行状态则关闭
                        if (bgw_VisualSystemRunning.IsBusy)
                        {
                            bgw_VisualSystemRunning.CancelAsync();
                        }
                        break;
                    default:
                        itemsFunc = ItemsFunc.NON;
                        break;
                }
                if (itemsFunc != ItemsFunc.NON)
                {
                    ToolStripItemClick?.Invoke(sender, itemsFunc);
                }
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
            GC.Collect();
        }

        /// <summary>
        /// 读取相机曝光和增益
        /// </summary>
        private void ReadExposureTime(CameraName cameraName)
        {
            try
            {
                if (cameraData == null)
                {
                    cameraData = new CameraData();
                }
                double data = 0;
                if (cameraName == CameraName.相机1)
                {
                    if (Camera1Tool == null)
                    {
                        return;
                    }
                    Camera1Tool.ModuParams.GetParamValue("ExposureTime", ref cameraConnectedStr);
                    if (cameraConnectedStr.Substring(0, 4) == "NULL")
                    {
                        return;
                    }
                    cameraConnectedStr = cameraConnectedStr.Substring(0, cameraConnectedStr.IndexOf("$", 0));
                    data = Convert.ToDouble(cameraConnectedStr);

                    cameraData.Camera1ExposureTime = (int)data;
                    Camera1Tool.ModuParams.GetParamValue("Gain", ref cameraConnectedStr);
                    cameraConnectedStr = cameraConnectedStr.Substring(0, cameraConnectedStr.IndexOf("$", 0));
                    data = Convert.ToDouble(cameraConnectedStr);
                    cameraData.Camera1Gain = (int)data;
                }
                else
                {
                    if (Camera2Tool == null)
                    {
                        return;
                    }
                    Camera2Tool.ModuParams.GetParamValue("ExposureTime", ref cameraConnectedStr);
                    if (cameraConnectedStr.Substring(0, 4) == "NULL")
                    {
                        return;
                    }
                    cameraConnectedStr = cameraConnectedStr.Substring(0, cameraConnectedStr.IndexOf("$", 0));
                    data = Convert.ToDouble(cameraConnectedStr);

                    cameraData.Camera2ExposureTime = (int)data;
                    Camera2Tool.ModuParams.GetParamValue("Gain", ref cameraConnectedStr);
                    cameraConnectedStr = cameraConnectedStr.Substring(0, cameraConnectedStr.IndexOf("$", 0));
                    data = Convert.ToDouble(cameraConnectedStr);
                    cameraData.Camera2Gain = (int)data;
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 更新相机工具
        /// </summary>
        private void UpdateCameraTool(CameraName cameraName)
        {
            try
            {
                if (cameraName == CameraName.相机1)
                {
                    if (vmProcedureCam1Debug.Modules[0] is ImageSourceModuleTool imageTool && vmProcedureCam1Calibration.Modules[0] is ImageSourceModuleTool imageTool1)
                    {
                        imageTool = (ImageSourceModuleTool)vmProcedureCam1Debug.Modules[0];
                        imageTool1 = (ImageSourceModuleTool)vmProcedureCam1Calibration.Modules[0];
                        imageTool1.ModuParams.ImageSourceType = imageTool.ModuParams.ImageSourceType;
                        if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//图像源为相机
                        {
                            string cameraID = null;
                            imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                            imageTool1.ModuParams.SetParamValue("CameraID", cameraID);
                            int camer = Convert.ToInt32(cameraID);
                            if (camer > 0)
                            {
                                Camera1Tool = VmSolution.Instance[$"全局相机{1}"] as GlobalCameraModuleTool;
                            }
                        }
                    }
                }
                else
                {
                    if (vmProcedureCam2Debug.Modules[0] is ImageSourceModuleTool imageTool && vmProcedureCam2Calibration.Modules[0] is ImageSourceModuleTool imageTool1)
                    {
                        imageTool = (ImageSourceModuleTool)vmProcedureCam2Debug.Modules[0];
                        imageTool1 = (ImageSourceModuleTool)vmProcedureCam2Calibration.Modules[0];
                        imageTool1.ModuParams.ImageSourceType = imageTool.ModuParams.ImageSourceType;
                        if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//图像源为相机
                        {
                            string cameraID = null;
                            imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                            imageTool1.ModuParams.SetParamValue("CameraID", cameraID);
                            int camer = Convert.ToInt32(cameraID);
                            if (camer > 0)
                            {
                                Camera2Tool = VmSolution.Instance[$"全局相机{2}"] as GlobalCameraModuleTool;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 事件处理器：视觉系统线程运行时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bgw_VisualSystemRunning_DoWork(object sender, DoWorkEventArgs e)
        {
            VisualSystemStartRun();
        }

        /// <summary>
        /// 视觉系统本次运行扫码OK次数
        /// </summary>
        private double OKCountOfCurrentCodeScan;

        /// <summary>
        /// 视觉系统本次运行扫码NG次数
        /// </summary>
        private double NGCountOfCurrentCodeScan;

        /// <summary>
        /// 上一次扫码是否OK
        /// </summary>
        bool lastScanIsOK = true;

        /// <summary>
        /// 视觉系统开始运行的方法
        /// </summary>
        private void VisualSystemStartRun()
        {
            //相机1
            int camera1CF0 = 1;
            int camera1CF1 = 0;
            //相机2
            int camera2CF0 = 1;
            int camera2CF1 = 0;
            //读码器
            int QRCF0 = 1;
            int QRCF1 = 0;

            while (!bgw_VisualSystemRunning.CancellationPending)
            {
                try
                {
                    Thread.Sleep(20);
                    if (Parameter.PLC_Client.Connected)
                    {
                        //相机1触发
                        Cam1Trig(ref camera1CF0, ref camera1CF1);

                        //相机2触发
                        Cam2Trig(ref camera2CF0, ref camera2CF1);

                        //读码器触发
                        string RD = "RD DM" + Parameter.Address_TriggerSignalOfCodeReader + ".H\r";
                        RD = SendMessage(RD);//读出来的字段是+00001或者+00000
                        if (RD.Substring(0, 4) == "0000" || RD.Substring(0, 4) == "0001")
                        {
                            QRCF1 = Convert.ToInt32(RD.Substring(0, 4));
                            if (QRCF1 == 1 && QRCF1 != QRCF0)
                            {
                                GlobleModule.LogInfo = "收到扫码信号";

                                //camer1Form.UpdateQR("扫码中。。。", true);
                                //codeReaderPort.DiscardInBuffer();
                                //codeReaderPort.Write(new byte[] { 0x01, 0x54, 0x04 }, 0, 3);//触发拍照
                                //Thread.Sleep(500);
                                //string s = codeReaderPort.ReadExisting();

                                form_MultiCamShow.UpdateQR("扫码中。。。", true);
                                codeReaderPort.DiscardInBuffer();
                                codeReaderPort.Write(new byte[] { 0x01, 0x54, 0x04 }, 0, 3);//触发拍照

                                int waitTime = 0;
                                List<byte> result = new List<byte>();
                                while (true)
                                {
                                    bool isReceived = false;
                                    Thread.Sleep(50);
                                    waitTime += 50;
                                    while (codeReaderPort.BytesToRead > 0)
                                    {
                                        int number = codeReaderPort.BytesToRead;
                                        byte[] buffer = new byte[number];
                                        codeReaderPort.Read(buffer, 0, number);
                                        result.AddRange(buffer);
                                        isReceived = true;
                                        Thread.Sleep(50);
                                    }
                                    if (isReceived || waitTime >= 1000)
                                    {
                                        break;
                                    }
                                }
                                string s = Encoding.Default.GetString(result.ToArray());
                                if (s != null && s != string.Empty)
                                {
                                    OKCountOfCurrentCodeScan++;
                                    Parameter.OKCountOfHistoryCodeScan++;
                                    lastScanIsOK = true;
                                    form_MultiCamShow.UpdateQR(s, true);
                                    GlobleModule.LogInfo = s;
                                }
                                else
                                {
                                    if (lastScanIsOK)
                                    {
                                        NGCountOfCurrentCodeScan++;
                                        Parameter.NGCountOfHistoryCodeScan++;
                                    }
                                    lastScanIsOK = false;
                                    form_MultiCamShow.UpdateQR(string.Empty, false);
                                    GlobleModule.LogInfo = "扫码失败";
                                }
                                double CurrentNum = Math.Round((OKCountOfCurrentCodeScan / (OKCountOfCurrentCodeScan + NGCountOfCurrentCodeScan)) * 100, 2);
                                double HistoryNum = Math.Round((Parameter.OKCountOfHistoryCodeScan / (Parameter.OKCountOfHistoryCodeScan + Parameter.NGCountOfHistoryCodeScan)) * 100, 2);
                                form_MultiCamShow.UpdateSuccessRateOfScanning(CurrentNum, HistoryNum);

                                string RD1 = "WRS DM" + Parameter.Address_CodeReaderData + ".H " + StringConvert16(s) + "\r";
                                if (SendMessage(RD1).Substring(0, 2) == "OK")
                                {
                                    GlobleModule.LogInfo = "读码数据发送成功";
                                    RD = "WR DM" + Parameter.Address_CodeReaderOK + ".U " + 1 + "\r";
                                    if (SendMessage(RD).Substring(0, 2) == "OK")
                                    {
                                        GlobleModule.LogInfo = "读码完成状态发送成功";
                                    }
                                    else
                                    {
                                        GlobleModule.LogInfo = "读码完成状态发送失败";
                                    }
                                }
                                else
                                {
                                    GlobleModule.LogInfo = "读码数据发送失败";
                                    //RD = "WR DM" + Parameter.Address_CodeReaderOK + ".U " + 1 + "\r";
                                    //if (SendMessage(RD).Substring(0, 2) == "OK")
                                    //{
                                    //    GlobleModule.LogInfo = "读码完成状态发送成功";
                                    //}
                                    //else
                                    //{
                                    //    GlobleModule.LogInfo = "读码完成状态发送失败";
                                    //}
                                }
                            }
                            QRCF0 = QRCF1;
                        }
                    }

                }
                catch (Exception ex)
                {
                    GlobleModule.ShowException(ex);
                }
            }

        }

        /// <summary>
        /// 相机2是否触发拍照，上升沿触发
        /// </summary>
        /// <param name="camera1CF0"></param>
        /// <param name="camera1CF1"></param>
        /// <returns></returns>
        private void Cam2Trig(ref int camera2CF0, ref int camera2CF1)
        {
            string RD = "RD DM" + Parameter.Address_Camer2CF + ".H\r";
            RD = SendMessage(RD);//读出来的字段是+00001或者+00000
            if (RD.Substring(0, 4) == "0000" || RD.Substring(0, 4) == "0001")
            {
                camera2CF1 = Convert.ToInt32(RD.Substring(0, 4));
                if (camera2CF1 == 1 && camera2CF1 != camera2CF0)
                {
                    GlobleModule.LogInfo = "相机2收到触发信号";
                    stopwatch.Restart();
                    Camera2ProcedureRunOnce();
                    stopwatch.Stop();
                    css_ShowMessages.UpdateCamCT(stopwatch.ElapsedMilliseconds.ToString(), CameraName.相机2, "");
                }
                camera2CF0 = camera2CF1;
            }
        }

        /// <summary>
        /// 相机1是否触发拍照，上升沿触发
        /// </summary>
        /// <param name="camera1CF0"></param>
        /// <param name="camera1CF1"></param>
        /// <returns></returns>
        private void Cam1Trig(ref int camera1CF0, ref int camera1CF1)
        {
            string RD = "RD DM" + Parameter.Address_Camer1CF + ".H\r";
            RD = SendMessage(RD);//读出来的字段是+00001或者+00000
            if (RD.Substring(0, 4) == "0000" || RD.Substring(0, 4) == "0001")
            {
                camera1CF1 = Convert.ToInt32(RD.Substring(0, 4));
                if (camera1CF1 == 1 && camera1CF1 != camera1CF0)
                {
                    GlobleModule.LogInfo = "相机1收到触发信号";
                    stopwatch.Restart();
                    Camera1ProcedureRunOnce();
                    stopwatch.Stop();
                    css_ShowMessages.UpdateCamCT(stopwatch.ElapsedMilliseconds.ToString(), CameraName.相机1, "");
                }
                camera1CF0 = camera1CF1;
            }
        }

        /// <summary> 
        /// 运行一次相机1视觉处理流程:拍照=>处理=>发送数据给PLC 
        /// </summary>
        private void Camera1ProcedureRunOnce()
        {
            try
            {
                GlobleModule.LogInfo = "1.0->开始运行相机1视觉处理流程";
                vmProcedureCam1Debug.Run();
                GlobleModule.LogInfo = "1.1->成功运行相机1视觉处理流程";

                double angle, x, y;
                //如果不是17寸产品
                if (Parameter.ProductIs17Inch != 1)
                {
                    if (vmProcedureCam1Debug.Modules[7] is IMVSQuadrangleFindModuTool && vmProcedureCam1Debug.Modules[3] is IMVSCalibTransformModuTool)
                    {
                        IMVSQuadrangleFindModuTool SbxTool = (IMVSQuadrangleFindModuTool)vmProcedureCam1Debug.Modules[7];
                        IMVSCalibTransformModuTool CalibTool = (IMVSCalibTransformModuTool)vmProcedureCam1Debug.Modules[3];

                        if (SbxTool.ModuResult.EdgeLine1 != null)
                        {
                            angle = SbxTool.ModuResult.EdgeLine1.Angle;//标定准换的角度
                        }
                        else
                        {
                            angle = -999;//标定准换的角度
                        }
                        if (CalibTool.ModuResult.TransPoint != null && CalibTool.ModuResult.TransPoint.Count > 0)
                        {
                            x = CalibTool.ModuResult.TransPoint[0].X;
                            y = CalibTool.ModuResult.TransPoint[0].Y;
                        }
                        else
                        {
                            x = -999;
                            y = -999;
                        }
                    }
                    else
                    {
                        angle = -999;//标定准换的角度
                        x = -999;
                        y = -999;
                    }
                }
                //如果是17寸产品
                else if (Parameter.ProductIs17Inch == 1)
                {
                    if (vmProcedureCam1Debug.Modules[7] is IMVSQuadrangleFindModuTool && vmProcedureCam1Debug.Modules[3] is IMVSCalibTransformModuTool
                        && vmProcedureCam1Debug.Modules[10] is IMVSCaliperCornerModuTool && vmProcedureCam1Debug.Modules[11] is IMVSCaliperCornerModuTool
                        && vmProcedureCam1Debug.Modules[8] is IMVSCalibTransformModuTool && vmProcedureCam1Debug.Modules[9] is IMVSCalibTransformModuTool)
                    {
                        IMVSQuadrangleFindModuTool SbxTool = (IMVSQuadrangleFindModuTool)vmProcedureCam1Debug.Modules[7];
                        IMVSCaliperCornerModuTool CornerTool3 = (IMVSCaliperCornerModuTool)vmProcedureCam1Debug.Modules[10];
                        IMVSCaliperCornerModuTool CornerTool1 = (IMVSCaliperCornerModuTool)vmProcedureCam1Debug.Modules[11];

                        IMVSCalibTransformModuTool CalibTool = (IMVSCalibTransformModuTool)vmProcedureCam1Debug.Modules[3];
                        IMVSCalibTransformModuTool CalibTool3 = (IMVSCalibTransformModuTool)vmProcedureCam1Debug.Modules[8];
                        IMVSCalibTransformModuTool CalibTool1 = (IMVSCalibTransformModuTool)vmProcedureCam1Debug.Modules[9];

                        double angleCenter, CenterX, CenterY;
                        double angle3, x3, y3;
                        double angle1, x1, y1;

                        //抓到了对角线交点
                        if (CalibTool.ModuResult.TransPoint != null && CalibTool.ModuResult.TransPoint.Count > 0)
                        {

                            CenterX = CalibTool.ModuResult.TransPoint[0].X;
                            CenterY = CalibTool.ModuResult.TransPoint[0].Y;
                            angleCenter = SbxTool.ModuResult.EdgeLine1.Angle;//标定准换的角度

                            GlobleModule.LogInfo = CalibTool.ModuResult.TransPoint[0].X.ToString() + " z " + CalibTool.ModuResult.TransPoint[0].Y.ToString();
                            x = CenterX;
                            y = CenterY;
                            angle = angleCenter;


                            //double tempAngle = Math.Abs(CornerTool3.ModuResult.EdgeLine1.Angle);//标定准换的角度
                            //double pointX3 = CalibTool3.ModuResult.TransPoint[0].X;
                            //double pointY3 = CalibTool3.ModuResult.TransPoint[0].Y;
                            //x3 = pointX3 + 0.5 * Parameter.LongEdgeOf17InchPro * Math.Sin(tempAngle / 180 * Math.PI) + 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Sin((90 - tempAngle) / 180 * Math.PI);
                            //y3 = pointY3 - 0.5 * Parameter.LongEdgeOf17InchPro * Math.Cos(tempAngle / 180 * Math.PI) + 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Cos((90 - tempAngle) / 180 * Math.PI);
                            //angle3 = CornerTool3.ModuResult.EdgeLine1.Angle;//标定准换的角度
                            //GlobleModule.LogInfo = x3.ToString() + " 3 " + y3.ToString();

                            //GlobleModule.LogInfo = angle3.ToString();

                            //double tempAngle1 = Math.Abs(CornerTool1.ModuResult.EdgeLine1.Angle);//标定准换的角度
                            //double pointX = CalibTool1.ModuResult.TransPoint[0].X;
                            //double pointY = CalibTool1.ModuResult.TransPoint[0].Y;
                            //x1 = pointX + 0.5 * Parameter.LongEdgeOf17InchPro * Math.Sin(tempAngle1 / 180 * Math.PI) - 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Cos(tempAngle1 / 180 * Math.PI);
                            //y1 = pointY + 0.5 * Parameter.LongEdgeOf17InchPro * Math.Cos(tempAngle1 / 180 * Math.PI) + 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Sin(tempAngle1 / 180 * Math.PI);
                            //angle1 = CornerTool1.ModuResult.EdgeLine1.Angle;//标定准换的角度
                            //GlobleModule.LogInfo = x1.ToString() + " 1 " + y1.ToString();
                            //GlobleModule.LogInfo = angle1.ToString();

                        }
                        else
                        {
                            //抓到了顶点3
                            if (CalibTool3.ModuResult.TransPoint != null && CalibTool3.ModuResult.TransPoint.Count > 0 && CornerTool3.ModuResult.EdgeLine1.Angle > 0)
                            {
                                double tempAngle = Math.Abs(CornerTool3.ModuResult.EdgeLine1.Angle);//标定准换的角度
                                double pointX = CalibTool3.ModuResult.TransPoint[0].X;
                                double pointY = CalibTool3.ModuResult.TransPoint[0].Y;

                                //以顶点3为基准进行偏移计算对角线交点
                                x3 = pointX + 0.5 * Parameter.LongEdgeOf17InchPro * Math.Sin(tempAngle / 180 * Math.PI) + 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Sin((90 - tempAngle) / 180 * Math.PI);
                                y3 = pointY - 0.5 * Parameter.LongEdgeOf17InchPro * Math.Cos(tempAngle / 180 * Math.PI) + 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Cos((90 - tempAngle) / 180 * Math.PI);
                                angle3 = CornerTool3.ModuResult.EdgeLine1.Angle;//标定准换的角度

                                GlobleModule.LogInfo = x3.ToString() + " 3 " + y3.ToString();
                                GlobleModule.LogInfo = angle3.ToString();

                                x = x3;
                                y = y3;
                                angle = angle3;
                            }
                            //抓到了顶点1
                            else if (CalibTool1.ModuResult.TransPoint != null && CalibTool1.ModuResult.TransPoint.Count > 0 && CornerTool1.ModuResult.EdgeLine1.Angle <= 0)
                            {
                                double tempAngle = Math.Abs(CornerTool1.ModuResult.EdgeLine1.Angle);//标定准换的角度
                                double pointX = CalibTool1.ModuResult.TransPoint[0].X;
                                double pointY = CalibTool1.ModuResult.TransPoint[0].Y;

                                //以顶点1为基准进行偏移计算对角线交点
                                x1 = pointX + 0.5 * Parameter.LongEdgeOf17InchPro * Math.Sin(tempAngle / 180 * Math.PI) - 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Cos(tempAngle / 180 * Math.PI);
                                y1 = pointY + 0.5 * Parameter.LongEdgeOf17InchPro * Math.Cos(tempAngle / 180 * Math.PI) + 0.5 * Parameter.ShortEdgeOf17InchPro * Math.Sin(tempAngle / 180 * Math.PI);
                                angle1 = CornerTool1.ModuResult.EdgeLine1.Angle;//标定准换的角度

                                GlobleModule.LogInfo = x1.ToString() + " 1 " + y1.ToString();
                                GlobleModule.LogInfo = angle1.ToString();

                                x = x1;
                                y = y1;
                                angle = angle1;
                            }
                            else
                            {
                                angle = -999;//标定准换的角度
                                x = -999;
                                y = -999;
                            }
                        }
                    }
                    else
                    {
                        angle = -999;//标定准换的角度
                        x = -999;
                        y = -999;
                    }

                }
                //其他情况
                else
                {
                    angle = -999;//标定准换的角度
                    x = -999;
                    y = -999;
                }


                camera1Result.Clear();
                cameraModelsAmount = 0;
                if (angle == -999 || x == -999 || y == -999)
                {
                    camera1Result.Add(new Result() { X = 999, Y = 999, Angle = 999, Xresult = false, Yresult = false, Angleresult = false });
                }
                else
                {
                    cameraModelsAmount = 1;
                    camera1Result.Add(new Result() { X = x, Y = y, Angle = angle });
                    //角度偏差
                    float dr = (float)(angle - Parameter.Cam1baseAngle1);

                    //将所有坐标，转换到示教抓取位的坐标系下
                    float markWorldX_T = (float)(Parameter.Cam1CalibConversionX + Parameter.Cam1CalibCentralPointX - Parameter.Cam1BasePointX);
                    float markWorldY_T = (float)(Parameter.Cam1CalibConversionY + Parameter.Cam1CalibCentralPointY - Parameter.Cam1BasePointY);
                    float runWorldX_T = (float)(x + Parameter.Cam1CalibCentralPointX - Parameter.Cam1BasePointX);
                    float runWorldY_T = (float)(y + Parameter.Cam1CalibCentralPointY - Parameter.Cam1BasePointY);
                    float rotatedX, rotatedY;
                    float AngleReverse = -1; //角度是否取反（如果使用图像中的特征角度，而机器人坐标系和图像坐标系旋转正方向不一致时，需要取反）
                    rotateMethod(-1 * dr * AngleReverse, markWorldX_T, markWorldY_T, out rotatedX, out rotatedY);
                    camera1Result[0].X = Math.Round(runWorldX_T - rotatedX, 2);
                    camera1Result[0].Y = Math.Round(runWorldY_T - rotatedY, 2);
                    camera1Result[0].Angle = Math.Round(AngleReverse * dr, 2);


                    //加上补偿值
                    double tempLong = (double)form_ParameterConfigure.dt_BCData.Rows[1][1];
                    double tempShort = (double)form_ParameterConfigure.dt_BCData.Rows[0][1];
                    double tempAngle = (double)form_ParameterConfigure.dt_BCData.Rows[2][1];

                    double tempX, tempY;
                    if (angle > 0)//此角度是像素坐标系下的角度，在此设备中与机械臂坐标系相反
                    {
                        tempX = -0.5 * tempLong * Math.Sin(angle / 180 * Math.PI) + 0.5 * tempShort * Math.Sin((90 - angle) / 180 * Math.PI);
                        tempY = 0.5 * tempLong * Math.Cos(angle / 180 * Math.PI) + 0.5 * tempShort * Math.Cos((90 - angle) / 180 * Math.PI);
                    }
                    else
                    {
                        tempX = 0.5 * tempLong * Math.Sin(Math.Abs(angle) / 180 * Math.PI) + 0.5 * tempShort * Math.Cos(Math.Abs(angle) / 180 * Math.PI);
                        tempY = 0.5 * tempLong * Math.Cos(Math.Abs(angle) / 180 * Math.PI + 0.5 * tempShort * Math.Sin(Math.Abs(angle) / 180 * Math.PI));
                    }

                    camera1Result[0].X = Math.Round(camera1Result[0].X + tempX, 2);
                    camera1Result[0].Y = Math.Round(camera1Result[0].Y + tempY, 2);
                    camera1Result[0].Angle = Math.Round(camera1Result[0].Angle + tempAngle, 2);

                    //判断x，y，角度值是否符合管控值
                    if (camera1Result[0].X >= (double)form_ParameterConfigure.dt_GKData.Rows[0][1] && camera1Result[0].X <= (double)form_ParameterConfigure.dt_GKData.Rows[1][1])
                    {
                        camera1Result[0].Xresult = true;
                    }
                    else
                    {
                        camera1Result[0].Xresult = false;
                    }

                    if (camera1Result[0].Y >= (double)form_ParameterConfigure.dt_GKData.Rows[2][1] && camera1Result[0].Y <= (double)form_ParameterConfigure.dt_GKData.Rows[3][1])
                    {
                        camera1Result[0].Yresult = true;
                    }
                    else
                    {
                        camera1Result[0].Yresult = false;
                    }

                    if (camera1Result[0].Angle >= (double)form_ParameterConfigure.dt_GKData.Rows[4][1] && camera1Result[0].Angle <= (double)form_ParameterConfigure.dt_GKData.Rows[5][1])
                    {
                        camera1Result[0].Angleresult = true;
                    }
                    else
                    {
                        camera1Result[0].Angleresult = false;
                    }
                }

                if (Parameter.PLC_Client.Connected)
                {
                    GlobleModule.LogInfo = "1.2->开始发送相机1数据给PLC";
                    Camera1SendDataToPLC();
                    GlobleModule.LogInfo = "1.3->成功发送相机1数据给PLC";
                }

                GlobleModule.LogInfo = "1.4->开始更新相机1数据到窗体";
                if (form_MultiCamShow is UserControl control && control.InvokeRequired)//更新相机结果
                {
                    control.BeginInvoke(new Action<CameraName>(UIInvoke), CameraName.相机1);
                }
                else
                {
                    UIInvoke(CameraName.相机1);
                }
                GlobleModule.LogInfo = "1.5->成功更新相机1数据到窗体";

                GlobleModule.LogInfo = "1.6->开始保存数据和图片";
                CheckState checkState = GlobleModule.DocumentParams.SaveImageCheckState;
                switch (checkState)
                {
                    case CheckState.Checked://保存所有图像
                                            //camer1From.SaveImageY(GlobleModule.DocumentParams.NGImageFolder);
                        form_MultiCamShow.Camera1Images.TryAdd(GlobleModule.DocumentParams.NGImageFolder);
                        break;
                    case CheckState.Unchecked://不保存图像
                        break;
                    case CheckState.Indeterminate://只保存NG图像
                        if (!PdResult(camera1Result))
                        {
                            form_MultiCamShow.Camera1Images.TryAdd(GlobleModule.DocumentParams.NGImageFolder);
                        }
                        break;
                }//保存图像
                SaveDataToExcel(CameraName.相机1);
                GlobleModule.LogInfo = "1.7->成功保存数据和图片";

            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary> 
        /// 相机1处理完后发送数据
        /// </summary>
        private void Camera1SendDataToPLC()
        {
            try
            {
                string RD = null;
                if (cameraModelsAmount == 0)
                {
                    RD = "WR DM" + Parameter.Address_Cam1Result + ".L " + 2 + "\r";//NG
                }
                else
                {
                    RD = "WR DM" + Parameter.Address_Cam1Result + ".L " + 1 + "\r";//发送OK
                }
                if (SendMessage(RD) == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                {
                    GlobleModule.LogInfo = "相机1结果发送成功!!!";
                }
                else
                {
                    GlobleModule.LogInfo = "相机1结果发送失败!!!";
                }
                if (cameraModelsAmount > 0)//产品片数大于0片发送
                {
                    int send;
                    for (int i = 0; i < cameraModelsAmount; i++)
                    {
                        send = (int)(camera1Result[i].X * 100);
                        RD = "WR DM" + Parameter.Address_Cam1XSendToPLC + ".L " + send + "\r";
                        if (SendMessage(RD) == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                        {
                            GlobleModule.LogInfo = $"相机1X坐标发送成功!!!";
                        }
                        else
                        {
                            GlobleModule.LogInfo = $"相机1X坐标发送失败!!!";
                        }
                        send = (int)(camera1Result[i].Y * 100);
                        RD = "WR DM" + Parameter.Address_Cam1YSendToPLC + ".L " + send + "\r";
                        if (SendMessage(RD) == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                        {
                            GlobleModule.LogInfo = $"相机1Y坐标发送成功!!!";
                        }
                        else
                        {
                            GlobleModule.LogInfo = $"相机1Y坐标发送失败!!!";
                        }
                        send = (int)(camera1Result[i].Angle * 100);
                        RD = "WR DM" + Parameter.Address_Cam1AngleSendToPLC + ".L " + send + "\r";
                        if (SendMessage(RD) == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                        {
                            GlobleModule.LogInfo = $"相机1角度坐标发送成功!!!";
                        }
                        else
                        {
                            GlobleModule.LogInfo = $"相机1角度发送失败!!!";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary> 
        /// 运行一次相机2视觉处理流程:拍照=>处理=>发送数据给PLC
        /// </summary>
        private void Camera2ProcedureRunOnce()
        {
            try
            {
                GlobleModule.LogInfo = "2.0->开始运行相机2视觉处理流程";
                vmProcedureCam2Debug.Run();
                GlobleModule.LogInfo = "2.1->成功运行相机2视觉处理流程";
                camera2Result.Clear();
                PmaZ = 0;
                double tempVertexX = 0;
                double tempVertexY = 0;
                double tempLine1Angle = 0;
                IMVSCalibTransformModuTool CalibTool = null;
                IMVSCaliperCornerModuTool DTool = null;

                if (vmProcedureCam2Debug.Modules[2] is IMVSFastFeatureMatchModuTool pmaTool)
                {
                    pmaTool = (IMVSFastFeatureMatchModuTool)vmProcedureCam2Debug.Modules[2];

                    if (pmaTool.ModuResult.MatchNum > 0)//匹配到了 
                    {

                        if (pmaTool.ModuResult.MatchModelIndex[0] == 0)//正面
                        {
                            GlobleModule.LogInfo = $"匹配到正面模板，匹配分数:{pmaTool.ModuResult.MatchScore[0]}";
                            PmaZ = 1;
                            DTool = (IMVSCaliperCornerModuTool)vmProcedureCam2Debug.Modules[6];
                            CalibTool = (IMVSCalibTransformModuTool)vmProcedureCam2Debug.Modules[7];
                            //if (CalibTool.ModuResult.TransPoint != null && CalibTool.ModuResult.TransPoint.Count > 0 && DTool.ModuResult.Line1Angle != null)
                            if (CalibTool.ModuResult.TransPoint != null && CalibTool.ModuResult.TransPoint.Count > 0 && DTool.ModuResult.EdgeLine1 != null)
                            {
                                tempVertexX = CalibTool.ModuResult.TransPoint[0].X;
                                tempVertexY = CalibTool.ModuResult.TransPoint[0].Y;
                                tempLine1Angle = DTool.ModuResult.Line1Angle;
                            }
                            form_MultiCamShow.UpdateCam2PositiveOrNegativeResult(1);
                            //角度偏差
                            float dr = (float)(tempLine1Angle - Parameter.Camera2BaseAngleOfFront);

                            //将所有坐标，转换到示教抓取位的坐标系下
                            float markWorldX_T = (float)(Parameter.Cam2CalibConversionXOfFront + Parameter.Cam2CalibCentralPointX - Parameter.Cam2BasePointXOfFront);
                            float markWorldY_T = (float)(Parameter.Cam2CalibConversionYOfFront + Parameter.Cam2CalibCentralPointY - Parameter.Cam2BasePointYOfFront);
                            float runWorldX_T = (float)(tempVertexX + Parameter.Cam2CalibCentralPointX - Parameter.Cam2BasePointXOfFront);
                            float runWorldY_T = (float)(tempVertexY + Parameter.Cam2CalibCentralPointY - Parameter.Cam2BasePointYOfFront);
                            float rotatedX, rotatedY;
                            float AngleReverse = -1; //角度是否取反（如果使用图像中的特征角度，而机器人坐标系和图像坐标系旋转正方向不一致时，需要取反）
                            rotateMethod(-1 * dr * AngleReverse, markWorldX_T, markWorldY_T, out rotatedX, out rotatedY);
                            camera2Result.Add(new Result());
                            camera2Result[0].X = Math.Round(runWorldX_T - rotatedX, 2);
                            camera2Result[0].Y = Math.Round(runWorldY_T - rotatedY, 2);
                            camera2Result[0].Angle = Math.Round(AngleReverse * dr, 2);
                        }
                        else if (pmaTool.ModuResult.MatchModelIndex[0] == 1)//反面
                        {
                            GlobleModule.LogInfo = $"匹配到反面模板，匹配分数:{pmaTool.ModuResult.MatchScore[0]}";
                            PmaZ = 2;
                            DTool = (IMVSCaliperCornerModuTool)vmProcedureCam2Debug.Modules[10];
                            CalibTool = (IMVSCalibTransformModuTool)vmProcedureCam2Debug.Modules[11];
                            tempVertexX = CalibTool.ModuResult.TransPoint[0].X;
                            tempVertexY = CalibTool.ModuResult.TransPoint[0].Y;
                            tempLine1Angle = DTool.ModuResult.Line1Angle;
                            form_MultiCamShow.UpdateCam2PositiveOrNegativeResult(2);

                            //角度偏差
                            float dr = (float)(tempLine1Angle - Parameter.Cam2BaseAngleOfOpposite);

                            //将所有坐标，转换到示教抓取位的坐标系下
                            float markWorldX_T = (float)(Parameter.Cam2CalibConversionXOfOpposite + Parameter.Cam2CalibCentralPointX - Parameter.Cam2BasePointXOfOpposite);
                            float markWorldY_T = (float)(Parameter.Cam2CalibConversionYOfOpposite + Parameter.Cam2CalibCentralPointY - Parameter.Cam2BasePointYOfOpposite);
                            float runWorldX_T = (float)(tempVertexX + Parameter.Cam2CalibCentralPointX - Parameter.Cam2BasePointXOfOpposite);
                            float runWorldY_T = (float)(tempVertexY + Parameter.Cam2CalibCentralPointY - Parameter.Cam2BasePointYOfOpposite);
                            float rotatedX, rotatedY;
                            float AngleReverse = -1; //角度是否取反（如果使用图像中的特征角度，而机器人坐标系和图像坐标系旋转正方向不一致时，需要取反）
                            rotateMethod(-1 * dr * AngleReverse, markWorldX_T, markWorldY_T, out rotatedX, out rotatedY);
                            camera2Result.Add(new Result());
                            camera2Result[0].X = Math.Round(runWorldX_T - rotatedX, 2);
                            camera2Result[0].Y = Math.Round(runWorldY_T - rotatedY, 2);
                            camera2Result[0].Angle = Math.Round(AngleReverse * dr, 2);
                        }
                        else
                        {

                            MessageBox.Show("模板匹配到第三个模板编号，这是不正常的");
                        }
                    }
                    else//未匹配到
                    {
                        GlobleModule.LogInfo = "未匹配到模板";
                        form_MultiCamShow.UpdateCam2PositiveOrNegativeResult(3);
                        PmaZ = 0;
                        camera2Result.Add(new Result() { X = 999, Y = 999, Angle = 999, Xresult = false, Yresult = false, Angleresult = false });
                    }

                    if (tempLine1Angle == 0 && tempVertexX == 0 && tempVertexY == 0)
                    {
                        camera2Result.Clear();  //相机1还是相机2
                        camera2Result.Add(new Result() { X = 999, Y = 999, Angle = 999, Xresult = false, Yresult = false, Angleresult = false });
                    }
                    else
                    {
                        double x_CompensationValue = 0;
                        double y_CompensationValue = 0;
                        double angle_CompensationValue = 0;
                        if (PmaZ == 1)
                        {
                            x_CompensationValue = (double)form_ParameterConfigure.dt_BCData.Rows[0][2];
                            y_CompensationValue = (double)form_ParameterConfigure.dt_BCData.Rows[1][2];
                            angle_CompensationValue = (double)form_ParameterConfigure.dt_BCData.Rows[2][2];
                        }
                        if (PmaZ == 2)
                        {
                            x_CompensationValue = (double)form_ParameterConfigure.dt_BCData.Rows[0][3];
                            y_CompensationValue = (double)form_ParameterConfigure.dt_BCData.Rows[1][3];
                            angle_CompensationValue = (double)form_ParameterConfigure.dt_BCData.Rows[2][3];
                        }

                        cameraModelsAmount = 1;

                        camera2Result[0].X = Math.Round(camera2Result[0].X + x_CompensationValue, 2);
                        //camera2Result[0].X = Math.Round(camera2Result[0].X + (double)form_ParameterConfigure.dt_BCData.Rows[0][2], 2);
                        if (camera2Result[0].X >= (double)form_ParameterConfigure.dt_GKData.Rows[0][2] && camera2Result[0].X <= (double)form_ParameterConfigure.dt_GKData.Rows[1][2])
                        {
                            camera2Result[0].Xresult = true;
                        }
                        else
                        {
                            camera2Result[0].Xresult = false;
                        }

                        camera2Result[0].Y = Math.Round(camera2Result[0].Y + y_CompensationValue, 2);
                        //camera2Result[0].Y = Math.Round(camera2Result[0].Y + (double)form_ParameterConfigure.dt_BCData.Rows[1][2], 2);
                        if (camera2Result[0].Y >= (double)form_ParameterConfigure.dt_GKData.Rows[2][2] && camera2Result[0].Y <= (double)form_ParameterConfigure.dt_GKData.Rows[3][2])
                        {
                            camera2Result[0].Yresult = true;
                        }
                        else
                        {
                            camera2Result[0].Yresult = false;
                        }

                        camera2Result[0].Angle = Math.Round(camera2Result[0].Angle + angle_CompensationValue, 2);
                        //camera2Result[0].Angle = Math.Round(camera2Result[0].Angle + (double)form_ParameterConfigure.dt_BCData.Rows[2][2], 2);
                        if (camera2Result[0].Angle >= (double)form_ParameterConfigure.dt_GKData.Rows[4][2] && camera2Result[0].Angle <= (double)form_ParameterConfigure.dt_GKData.Rows[5][2])
                        {
                            camera2Result[0].Angleresult = true;
                        }
                        else
                        {
                            camera2Result[0].Angleresult = false;
                        }

                    }
                    if (Parameter.PLC_Client.Connected)//发送数据到PLC
                    {
                        GlobleModule.LogInfo = "2.2->开始发送相机2数据给PLC";
                        Camera2SendDataToPLC();
                        GlobleModule.LogInfo = "2.3->成功发送相机2数据给PLC";
                    }

                    //更新界面
                    GlobleModule.LogInfo = "2.4->开始更新相机2数据到窗体";
                    if (form_MultiCamShow is UserControl control && control.InvokeRequired)//更新相机结果
                    {
                        control.BeginInvoke(new Action<CameraName>(UIInvoke), CameraName.相机2);
                    }
                    else
                    {
                        UIInvoke(CameraName.相机2);
                    }
                    GlobleModule.LogInfo = "2.5->成功更新相机2数据到窗体";

                    GlobleModule.LogInfo = "2.6->开始保存相机2数据和图片";
                    CheckState checkState = GlobleModule.DocumentParams.SaveImageCheckState;
                    switch (checkState)
                    {
                        case CheckState.Checked://保存所有图像
                            form_MultiCamShow.Camera2Images.TryAdd(GlobleModule.DocumentParams.NGImageFolder);
                            break;
                        case CheckState.Unchecked://不保存图像
                            break;
                        case CheckState.Indeterminate://只保存NG图像
                            if (!PdResult(camera2Result))
                            {
                                form_MultiCamShow.Camera2Images.TryAdd(GlobleModule.DocumentParams.NGImageFolder);
                            }
                            break;
                    }
                    SaveDataToExcel(CameraName.相机2); //保存数据
                    GlobleModule.LogInfo = "2.7->成功保存相机2数据和图片";

                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary> 
        /// 相机2处理完后发送数据
        /// </summary>
        private void Camera2SendDataToPLC()
        {
            try
            {
                int Ms = 0;//读取PLC模式，1发送正反数据，2发送定位数据
                string RD = "RD DM" + Parameter.Camer2MS + ".U\r";
                if (SendMessage(RD).Substring(0, 5) == "00001" || SendMessage(RD).Substring(0, 5) == "00002" || SendMessage(RD).Substring(0, 5) == "00000")
                {
                    Ms = Convert.ToInt32(SendMessage(RD).Substring(0, 5));
                    if (Ms == 1)//发送正反数据
                    {
                        if (PmaZ == 0)//未匹配到模板
                        {

                            RD = "WR DM" + Parameter.Address_Cam2Result + ".L " + 2 + "\r";
                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                GlobleModule.LogInfo = "相机2模板匹配结果发送成功：未匹配到模板";
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2未匹配到模板，且模板匹配结果发送失败";
                            }

                        }
                        else
                        {

                            if (PmaZ == 1)//正面数据
                            {
                                RD = "WR DM" + Parameter.Camera2Direction + ".D " + 0 + "\r";
                            }
                            else if (PmaZ == 2)//反面数据
                            {
                                RD = "WR DM" + Parameter.Camera2Direction + ".D " + 1 + "\r";
                            }

                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                if (PmaZ == 1)//正面数据
                                {
                                    GlobleModule.LogInfo = "相机2模板匹配结果发送成功：正面";
                                }
                                if (PmaZ == 2)//反面数据
                                {
                                    GlobleModule.LogInfo = "相机2模板匹配结果发送成功：反面";
                                }
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2匹配到模板，且相机2模板匹配结果发送成功";
                            }

                            RD = "WR DM" + Parameter.Address_Cam2Result + ".D " + 1 + "\r";
                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                GlobleModule.LogInfo = "相机2 OK 结果发送成功";
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2 OK 结果发送失败";
                            }

                        }
                    }
                    else if (Ms == 2)//发送点位数据
                    {
                        int mes = 0;
                        if (camera2Result[0].Xresult == true && camera2Result[0].Yresult == true && camera2Result[0].Angleresult == true)//OK
                        {
                            mes = Convert.ToInt32(camera2Result[0].X * 100);
                            RD = "WR DM" + Parameter.Address_Cam2XDataSendToPLC + ".L " + mes + "\r";
                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                GlobleModule.LogInfo = "相机2X结果发送成功";
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2X结果发送失败";
                            }

                            mes = Convert.ToInt32(camera2Result[0].Y * 100);
                            RD = "WR DM" + Parameter.Address_Cam2YDataSendToPLC + ".L " + mes + "\r";
                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                GlobleModule.LogInfo = "相机2Y结果发送成功";
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2Y结果发送失败";
                            }

                            mes = Convert.ToInt32(camera2Result[0].Angle * 100);
                            RD = "WR DM" + Parameter.Address_Cam2AngleSendToPLC + ".L " + mes + "\r";
                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                GlobleModule.LogInfo = "相机2角度结果发送成功";
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2角度结果发送失败";
                            }

                            RD = "WR DM" + Parameter.Address_Cam2Result + ".D " + 1 + "\r";
                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                GlobleModule.LogInfo = "相机2点位数据 ok 结果发送成功";
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2点位数据 ok 结果发送失败";
                            }

                        }
                        else//NG
                        {
                            RD = "WR DM" + Parameter.Address_Cam2Result + ".D " + 2 + "\r";
                            if (SendMessage(RD).Substring(0, 2) == "OK")
                            {
                                GlobleModule.LogInfo = "相机2点位数据 NG 结果发送成功";
                            }
                            else
                            {
                                GlobleModule.LogInfo = "相机2点位数据 NG 结果发送成功";
                            }

                        }
                    }
                }
                else
                {
                    GlobleModule.LogInfo = "相机2读取寄存器模式失败";
                }

            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 旋转公式，围绕某个点进行旋转（此方法为0,0点）
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="x">旋转前x坐标</param>
        /// <param name="y">旋转前y坐标</param>
        /// <param name="rotatex">旋转后x坐标</param>
        /// <param name="rotatey">旋转后y左边</param>
        private void rotateMethod(float dr, float x, float y, out float rotatex, out float rotatey)
        {
            rotatex = 0f;
            rotatey = 0f;
            float drRad = (float)(dr / 180.0 * Math.PI);
            rotatex = (float)(x * Math.Cos(drRad) - y * Math.Sin(drRad));
            rotatey = (float)(x * Math.Sin(drRad) + y * Math.Cos(drRad));

            //rotatex = (float)(（x-0） * Math.Cos(drRad) - y * Math.Sin(drRad));
            //rotatey = (float)(（x-0） * Math.Sin(drRad) + y * Math.Cos(drRad));
        }

        /// <summary>
        /// 保存测量数据到Excel文件
        /// </summary>
        private void SaveDataToExcel(CameraName cameraName)
        {
            try
            {
                if (!GlobleModule.DocumentParams.SaveExcelData || string.IsNullOrEmpty(GlobleModule.DocumentParams.ExcelDataFolder) || camera1Result == null)
                    return;
                if (!GlobleModule.LogicDriveExsit(GlobleModule.DocumentParams.ExcelDataFolder))
                {
                    MessageBox.Show($"Excel数据路径：{GlobleModule.DocumentParams.ExcelDataFolder} 指定的根目录 {GlobleModule.DocumentParams.ExcelDataFolder.Split('\\')[0]} 不存在，请重新设定Excel数据文件夹路径!", "根目录不存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Excel文件夹路径，按照"D:数据\\当前料号\\日期\\测量类型\\xls"的路径格式
                string folderName = string.Empty;
                if (cameraName == CameraName.相机1)
                {
                    if (string.IsNullOrEmpty(GlobleModule.CurrentProduct))
                        folderName = $"{GlobleModule.DocumentParams.ExcelDataFolder}\\{DateTime.Now.ToLongDateString()}";
                    else
                        folderName = $"{GlobleModule.DocumentParams.ExcelDataFolder}\\{GlobleModule.CurrentProduct}\\相机1\\{DateTime.Now.ToLongDateString()}";
                }
                else
                {
                    if (string.IsNullOrEmpty(GlobleModule.CurrentProduct))
                        folderName = $"{GlobleModule.DocumentParams.ExcelDataFolder}\\{DateTime.Now.ToLongDateString()}";
                    else
                        folderName = $"{GlobleModule.DocumentParams.ExcelDataFolder}\\{GlobleModule.CurrentProduct}\\相机2\\{DateTime.Now.ToLongDateString()}";
                }
                //判断文件夹是否存在，如果不存在则创建文件夹
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);

                string excelPath = string.Empty;
                string sTime = string.Empty;


                //Excel文件路径
                excelPath = $"{folderName}\\数据.xls";
                //判断是否存在excel文件
                bool fileExist = File.Exists(excelPath);
                //实例化写入流，如果文件不存在，会创建该文件
                using (StreamWriter excelWriter = new StreamWriter(excelPath, true, Encoding.GetEncoding("GB2312")))
                {
                    //判断excel文件是否存在，如果不存在则以相应格式创建文件
                    if (!fileExist)
                    {
                        //设置表格第1列为当前写入时间，设置列首为Time
                        excelWriter.Write("Time" + TabChar);
                        //设置excel表格列首
                        excelWriter.Write("目标" + TabChar);
                        excelWriter.Write($"X{TabChar}");
                        excelWriter.Write($"Y{TabChar}");
                        excelWriter.Write($"角度{TabChar}");
                        //设置最后一列为当前写入数据结果显示，列首为结果
                        excelWriter.Write("结果" + TabChar);
                        //写入行结束符
                        excelWriter.WriteLine();
                    }

                    //写入测量数据到excel，对只读文件夹或文件使用Writer流会异常“路径访问被拒绝”

                    //遍历当前测量项所有数据
                    if (cameraName == CameraName.相机1)
                    {
                        for (int pinIndex = 0; pinIndex < camera1Result.Count; pinIndex++)
                        {
                            //当前时间，24小时制的 时:分:秒
                            sTime = DateTime.Now.ToLongTimeString();
                            //第一列写入当前时间
                            excelWriter.Write(sTime + TabChar);//时间
                            excelWriter.Write($"目标{pinIndex + 1}" + TabChar);//时间
                            excelWriter.Write(camera1Result[pinIndex].X + TabChar);
                            excelWriter.Write(camera1Result[pinIndex].Y + TabChar);
                            excelWriter.Write(camera1Result[pinIndex].Angle + TabChar);
                            //最后一列写入该项测量结果
                            if (camera1Result[pinIndex].Xresult == true && camera1Result[pinIndex].Yresult == true && camera1Result[pinIndex].Angleresult == true)
                            {
                                excelWriter.Write("OK" + TabChar);
                            }
                            else
                            {
                                excelWriter.Write("NG" + TabChar);
                            }
                            //写入行结束符
                            excelWriter.WriteLine();
                        }
                    }
                    else
                    {
                        for (int pinIndex = 0; pinIndex < camera2Result.Count; pinIndex++)
                        {
                            //当前时间，24小时制的 时:分:秒
                            sTime = DateTime.Now.ToLongTimeString();
                            //第一列写入当前时间
                            excelWriter.Write(sTime + TabChar);//时间
                            excelWriter.Write($"目标{pinIndex + 1}" + TabChar);//时间
                            excelWriter.Write(camera2Result[pinIndex].X + TabChar);
                            excelWriter.Write(camera2Result[pinIndex].Y + TabChar);
                            excelWriter.Write(camera2Result[pinIndex].Angle + TabChar);
                            //最后一列写入该项测量结果
                            if (camera2Result[pinIndex].Xresult == true && camera2Result[pinIndex].Yresult == true && camera2Result[pinIndex].Angleresult == true)
                            {
                                excelWriter.Write("OK" + TabChar);
                            }
                            else
                            {
                                excelWriter.Write("NG" + TabChar);
                            }
                            //写入行结束符
                            excelWriter.WriteLine();
                        }
                    }

                    //将缓冲区数据写入文件
                    excelWriter.Flush();
                }

            }
            catch (Exception)
            {
            }
        }

        ///// <summary>保存图片到指定文件夹 </summary>
        //private void SaveImage()
        //{
        //    CheckState checkState = GlobleModule.DocumentParams.SaveImageCheckState;
        //    switch (checkState)
        //    {
        //        case CheckState.Checked://保存所有图像
        //            //camer1From.SaveImageY(GlobleModule.DocumentParams.NGImageFolder);
        //            camer1Form.Images.TryAdd(GlobleModule.DocumentParams.NGImageFolder);
        //            break;
        //        case CheckState.Unchecked://不保存图像
        //            break;
        //        case CheckState.Indeterminate://只保存NG图像
        //            if (!PdResult())
        //            {
        //                camer1Form.Images.TryAdd(GlobleModule.DocumentParams.NGImageFolder);
        //            }
        //            break;
        //    }
        //}

        #region  料号切换模块

        /// <summary>
        /// 事件处理器：产品料号自动切换线程运行时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Bgw_ProductAutoChange_DoWork(object sender, DoWorkEventArgs e)
        {

            // int proChangeTrigHigh = 0;
            while (true)
            {
                int proChangeTrigLow = 0;
                Thread.Sleep(50);
                //收到取消信号,结束线程
                if (bgw_ProductAutoChange.CancellationPending)
                {
                    return;
                }
                try
                {
                    if (Parameter.PLC_Client != null && Parameter.PLC_Client.Connected)
                    {

                        #region  将视觉系统当前料号发送给PLC,格式为001-xxxxx,002-xxxxx以此类推
                        int number;
                        bool result = int.TryParse(CurrentProduct.Substring(0, CurrentProduct.IndexOf('-')), out number);
                        if (!result)
                        {
                            GlobleModule.LogInfo = "视觉系统当前料号格式异常,请检查!!!";
                            continue;
                        }
                        string wr_Message = "WR DM" + Parameter.Address_CurrentProductSendToPLC + ".U " + number + "\r";
                        //RD = "WR DM" + Parameter.CamerReady + ".U " + 1 + "\r";
                        if (SendMessage(wr_Message).Substring(0, 2) == "OK")
                        {
                            //GlobleModule.LogInfo = "发送料号给PLC成功.";
                        }
                        else
                        {
                            GlobleModule.LogInfo = "发送料号给PLC失败!";
                        }
                        #endregion

                        //读取PLC料号切换寄存器数据
                        string rd_Message = "RD DM" + Parameter.Address_ProductChangeTrigger + ".U\r";
                        rd_Message = SendMessage(rd_Message);//读出来的字段是+00001或者+00000
                        if (rd_Message.Substring(0, 5) == "00000" || rd_Message.Substring(0, 5) == "00001")
                        {
                            proChangeTrigLow = Convert.ToInt32(rd_Message.Substring(0, 5));
                            if (proChangeTrigLow == 1/* && proChangeTrigLow != proChangeTrigHigh*/)
                            {
                                //视觉系统读取PLC当前料号
                                rd_Message = "RD DM" + Parameter.Address_PLCCurrentProduct + ".U\r";
                                rd_Message = SendMessage(rd_Message);

                                result = int.TryParse(rd_Message.Substring(0, 5), out number);

                                if (!result)
                                {
                                    GlobleModule.LogInfo = "从PLC读取到的料号格式异常,请检查!!!";
                                    continue;
                                }

                                //视觉系统当前料号和PLC当前料号比较,如果一致则不用切换
                                if (tscbx_ProductChoose.Items == null && tscbx_ProductChoose.Items.Count < 1)
                                {
                                    GlobleModule.LogInfo = "料号列表异常,请检查!!!";
                                    continue;
                                }
                                if (CurrentProduct.Substring(0, CurrentProduct.IndexOf('-')) == number.ToString())
                                {
                                    GlobleModule.LogInfo = "视觉系统当前料号与PLC料号一致,不用切换.";
                                    continue;
                                }
                                //如果不一致且视觉系统存在此料号,则切换料号
                                bool productExist = false;
                                foreach (var item in tscbx_ProductChoose.Items)
                                {
                                    string tempProduct = item.ToString();

                                    if (int.Parse(tempProduct.Substring(0, tempProduct.IndexOf('-'))) == number)
                                    {
                                        productExist = true;
                                        //切换料号,程序重启
                                        try
                                        {
                                            CurrentProduct = tempProduct;
                                            INIManager.IniWriteValue("当前产品", "产品名称", _currentProduct, GlobleModule.ConfigFilePath);
                                            ToolStripItemClick?.Invoke(sender, ItemsFunc.ProductEditor);
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                }
                                //如果视觉系统不存在此料号,弹窗提示
                                if (!productExist)
                                {
                                    this.Invoke(new Action(() => MessageBox.Show("视觉系统没有与PLC系统对应的料号!!!")));
                                    tscb_ProductAutoChoose.SelectedIndex = 1;
                                    return;
                                }

                            }
                            // proChangeTrigHigh = proChangeTrigLow;
                        }
                        //读码器触发
                        //RD_message = "RD DM" + Parameter.QRCF + ".H\r";
                        //RD = SendMessage(RD);//读出来的字段是+00001或者+00000
                        //if (RD.Substring(0, 4) == "0000" || RD.Substring(0, 4) == "0001")
                    }
                    else
                    {
                        GlobleModule.LogInfo = "PLC暂时未连接!!!";
                        continue;
                    }

                }
                catch (Exception ex)
                {
                    GlobleModule.ShowException(ex);
                }
            }
        }

        /// <summary>
        /// 事件处理器:选择是否允许从PLC系统切换料号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscb_ProductAutoChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscb_ProductAutoChoose.SelectedIndex == 0)
            {
                if (!bgw_ProductAutoChange.IsBusy)
                {
                    bgw_ProductAutoChange.RunWorkerAsync();
                    GlobleModule.LogInfo = "允许从PLC系统切换料号.";
                }
            }
            else
            {
                if (bgw_ProductAutoChange.IsBusy)
                {
                    bgw_ProductAutoChange.CancelAsync();
                }
                GlobleModule.LogInfo = "禁止从PLC系统切换料号.";
            }
        }

        /// <summary>
        /// 事件处理器:料号切换触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToolStripItemClick == null) return;
            if (_currentProduct != tscbx_ProductChoose.SelectedItem.ToString())
            {
                if (MessageBox.Show("是否确定要切换产品？", "切换产品", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        CurrentProduct = tscbx_ProductChoose.SelectedItem.ToString();
                        INIManager.IniWriteValue("当前产品", "产品名称", _currentProduct, GlobleModule.ConfigFilePath);
                        ToolStripItemClick?.Invoke(sender, ItemsFunc.ProductEditor);
                    }
                    catch (Exception ex)
                    {
                        UserLoginForm.ShowException(ex);
                    }
                }
                else tscbx_ProductChoose.SelectedItem = _currentProduct;
            }
        }

        #endregion

        #region  与读码器相关的模块

        /// <summary>
        /// 初始化并打开读码器通讯串口
        /// </summary>
        public void InitializeCodeReaderPort()
        {
            try
            {
                codeReaderPort = new SerialPort(Parameter.CodeReaderPort, 9600);
                if (codeReaderPort.IsOpen)
                {
                    codeReaderPort.Close();
                }
                codeReaderPort.Open();
                GlobleModule.LogInfo = "读码器已连接";
                //codeReaderPort.DataReceived += codeReaderPort_DataReceived;
            }
            catch (Exception)
            {
                MessageBox.Show("连接读码器异常！！！");
            }
        }

        /// <summary>
        /// 事件处理器：读码器串口收到数据时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeReaderPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = codeReaderPort.ReadExisting();
            if (plcReadQR && Parameter.PLC_Client.Connected)//此时是PLC触发，不是人为触发
            {
                string RD = "WRS DM" + Parameter.Address_CodeReaderData + ".H " + StringConvert16(s) + "\r";
                if (SendMessage(RD).Substring(0, 2) == "OK")
                {
                    form_MultiCamShow.UpdateQR(s, true);
                    GlobleModule.LogInfo = "读码数据发送成功";
                    RD = "WR DM" + Parameter.Address_CodeReaderOK + ".U " + 1 + "\r";
                    if (SendMessage(RD).Substring(0, 2) == "OK")
                    {
                        GlobleModule.LogInfo = "读码状态发送成功";
                    }
                    else
                    {
                        GlobleModule.LogInfo = "读码状态发送失败";
                    }
                }
                else
                {
                    GlobleModule.LogInfo = "读码数据发送失败";
                }
            }
            plcReadQR = false;
        }

        /// <summary>
        /// 将字符串转化为16进制
        /// </summary>
        /// <returns></returns>
        private string StringConvert16(String _str)
        {
            try
            {
                if (_str.Length > 0)
                {
                    _str = _str.Substring(0, _str.Length - 1);
                }

                _str = _str.Replace(" ", "");
                //将字符串的每2个字符进行反转
                _str = ReverseEveryTwoChar(_str);

                //将字符串转换成字节数组。
                byte[] buffer = Encoding.ASCII.GetBytes(_str);
                //定义一个string类型的变量，用于存储转换后的值。
                string result = string.Empty;
                if (_str.Length % 2 == 0)
                {
                    result = (_str.Length / 2).ToString() + " ";//需要先给寄存器数量
                }
                else
                {
                    result = (_str.Length / 2 + 1).ToString() + " ";//需要先给寄存器数量
                }
                for (int i = 0; i < buffer.Length; i++)
                {
                    //将每一个字节数组转换成16进制的字符串，以空格相隔开。
                    result += Convert.ToString(buffer[i], 16);
                    if (i % 2 == 1 && i != buffer.Length - 1)
                    {
                        result += " ";
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
                return "";
            }
        }

        /// <summary>
        /// 将字符串的每2个字符进行反转
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ReverseEveryTwoChar(string str)
        {
            char[] charAry = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)//如果下标为偶数
                {
                    if (i == str.Length - 1)//最后一位是偶数不需要反转
                    {
                        charAry[i] = str[i];
                        break;
                    }
                    charAry[i + 1] = str[i];
                }
                if (i % 2 == 1)//下标为奇数
                {
                    charAry[i - 1] = str[i];
                }
            }
            return new string(charAry);
        }

        #endregion


        /// <summary>
        /// 属性：获取当前料号名称
        /// </summary>
        public string CurrentProduct
        {
            private set
            {
                _currentProduct = value;
                currentProductPath = GlobleModule.ParaPath + "\\" + _currentProduct;
                currentSerializePath = currentProductPath + "\\Serialize";
                currentVppPath = currentProductPath + "\\schemes";
                GlobleModule.CurrentProduct = value;
                GlobleModule.CurrentProductPath = currentProductPath;
            }
            get
            {
                return _currentProduct;
            }
        }

        /// <summary>
        /// 属性：获取当前料号文件路径，所有料号文件在“参数“文件夹下
        /// </summary>
        public string CurrentProductPath
        {
            get { return currentProductPath; }
        }

        /// <summary>
        /// 属性：读写用户ID。操作员：1，调试员：2，管理员：3，无用户：0和其他。
        /// </summary>
        public LogUser UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                RefreshControlEnabledStatus();
                CurrentUser.Text = $"{userID.ToString()}";
            }
        }

        /// <summary>
        /// 属性：获取模拟选项
        /// </summary>
        public SimulateOption SimulateOption
        {
            get { return simulateOption; }
        }

        /// <summary>
        /// 属性:设定或读取相机个数
        /// </summary>
        public int CameraNum
        {
            set
            {
                cameraNum = value;

                Cam1LiveDisplay.Visible = true;
                Cam2LiveDisplay.Visible = false;
                Cam3LiveDisplay.Visible = false;
                Cam4LiveDisplay.Visible = false;

                Cam1AcquireTool.Visible = true;
                Cam2AcquireTool.Visible = false;
                Cam3AcquireTool.Visible = false;
                Cam4AcquireTool.Visible = false;
                switch (value)
                {
                    case 2:
                        Cam2LiveDisplay.Visible = true;
                        Cam2AcquireTool.Visible = true;
                        break;
                    case 3:
                        Cam2LiveDisplay.Visible = true;
                        Cam2AcquireTool.Visible = true;
                        Cam3LiveDisplay.Visible = true;
                        Cam3AcquireTool.Visible = true;
                        break;
                    case 4:
                        Cam2LiveDisplay.Visible = true;
                        Cam2AcquireTool.Visible = true;
                        Cam3LiveDisplay.Visible = true;
                        Cam3AcquireTool.Visible = true;
                        Cam4LiveDisplay.Visible = true;
                        Cam4AcquireTool.Visible = true;
                        break;
                    case 5:
                        Cam2LiveDisplay.Visible = true;
                        Cam2AcquireTool.Visible = true;
                        Cam3LiveDisplay.Visible = true;
                        Cam3AcquireTool.Visible = true;
                        Cam4LiveDisplay.Visible = true;
                        Cam4AcquireTool.Visible = true;

                        break;
                }
            }
            get { return cameraNum; }
        }

        /// <summary>
        /// 属性：视觉系统是否运行，“Start”按下为true，“Stop”按下为false
        /// </summary>
        public bool Running
        {
            get
            {
                return running;
            }
            set
            {
                running = value;
                RefreshControlEnabledStatus();
            }
        }

        /// <summary> 
        /// 属性：获取相机1是否连接
        /// </summary>
        private bool Camera1IsConnected
        {
            get
            {
                try
                {
                    if (vmProcedureCam1Debug == null) { return false; }
                    if (vmProcedureCam1Debug.Modules[0] is ImageSourceModuleTool imageTool)
                    {
                        //imageTool = (ImageSourceModuleTool)vmProcedureCam1Debug.Modules[0];
                        if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//图像源为相机
                        {
                            string strCameraID = string.Empty;
                            imageTool.ModuParams.GetParamValue("CameraID", ref strCameraID);
                            int cameraID = Convert.ToInt32(strCameraID);
                            if (cameraID > 0)
                            {
                                Camera1Tool = VmSolution.Instance[$"全局相机{1}"] as GlobalCameraModuleTool;
                            }
                            imageTool.ModuParams.GetParamValue("TriggerSource", ref cameraConnectionStatus);
                            if (cameraConnectionStatus == null)
                            {
                                return false;
                            }
                            //会获取类似"0$0$$$$Close"的数据，对此数据按$分割获取第一个数据，第一个值大于0表示连接，等于0表示未连接，如上数据表示该相机未连接。 
                            int data = Convert.ToInt32(cameraConnectionStatus.Substring(cameraConnectionStatus.IndexOf("$", 0) + 1, 1));
                            if (data > 0)
                            {
                                return true;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;

                }
                catch (Exception ex)
                {
                    GlobleModule.ShowException(ex);
                    return false;
                }
            }
        }

        /// <summary> 
        /// 属性：获取相机2是否连接
        /// </summary>
        private bool Cmaera2IsConnected
        {
            get
            {
                try
                {
                    if (vmProcedureCam2Debug == null) { return false; }
                    if (vmProcedureCam2Debug.Modules[0] is ImageSourceModuleTool imageTool)
                    {
                        //imageTool = (ImageSourceModuleTool)vmProcedureCam2Debug.Modules[0];
                        if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//图像源为相机
                        {
                            string cameraID = null;
                            imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                            int camer = Convert.ToInt32(cameraID);
                            if (camer > 0)
                            {
                                Camera2Tool = VmSolution.Instance[$"全局相机{2}"] as GlobalCameraModuleTool;
                            }
                            imageTool.ModuParams.GetParamValue("TriggerSource", ref cameraConnectionStatus);
                            if (cameraConnectionStatus == null)
                            {
                                return false;
                            }
                            //会获取类似"0$0$$$$Close"的数据，对此数据按$分割获取第一个数据，第一个值大于0表示连接，等于0表示未连接，如上数据表示该相机未连接。 
                            int data = Convert.ToInt32(cameraConnectionStatus.Substring(cameraConnectionStatus.IndexOf("$", 0) + 1, 1));
                            if (data > 0)
                            {
                                return true;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;

                }
                catch (Exception ex)
                {
                    GlobleModule.ShowException(ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// 根据运行与否改变控件的“enabled”状态
        /// </summary>
        private void RefreshControlEnabledStatus()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(RefreshControlEnabledStatus));
                    return;
                }
                else
                {
                    DisableCamLive(false);
                    tsmi_AcquireToolManager.Enabled = false;
                    tsmi_DebugTools.Enabled = false;
                    tscbx_ProductChoose.Enabled = false;
                    tscb_ProductAutoChoose.Enabled = false;
                    tsbtn_Camera1Debug.Enabled = false;
                    tsbtn_Camera2Debug.Enabled = false;
                    tsbtn_Camera1CalibTool.Enabled = false;
                    tsbtn_Camera2CalibTool.Enabled = false;
                    tsbtn_CodeReaderDebug.Enabled = false;
                    tsbtn_SaveParams.Enabled = false;
                    tsbtn_ReadParams.Enabled = false;
                    tsbtn_LogIn.Enabled = !Running;
                    tsbtn_LogOut.Enabled = false;
                    tsbtn_setParameter.Enabled = false;
                    tsbtn_ProductEditor.Enabled = false;
                    tsbtn_ClearStatistics.Enabled = false;

                    if (Running)
                    {
                        return;
                    }
                    switch (userID)
                    {
                        case LogUser.无用户:
                            break;
                        case LogUser.操作员:
                            DisableCamLive(true);
                            tsbtn_LogOut.Enabled = true;
                            tsbtn_ClearStatistics.Enabled = true;
                            break;
                        case LogUser.调试员:
                            DisableCamLive(true);
                            tsmi_AcquireToolManager.Enabled = true;
                            tsmi_DebugTools.Enabled = true;
                            //ProductChoose.Enabled = true;
                            tscb_ProductAutoChoose.Enabled = true;
                            tsbtn_Camera1Debug.Enabled = true;
                            tsbtn_CodeReaderDebug.Enabled = true;
                            tsbtn_setParameter.Enabled = true;
                            tsbtn_SaveParams.Enabled = true;
                            tsbtn_ReadParams.Enabled = true;
                            tsbtn_ProductEditor.Enabled = true;
                            tsbtn_LogOut.Enabled = true;
                            tsbtn_ClearStatistics.Enabled = true;
                            tsbtn_Camera1CalibTool.Enabled = true;
                            tsbtn_Camera2CalibTool.Enabled = true;
                            tsbtn_Camera1Debug.Enabled = true;
                            tsbtn_Camera2Debug.Enabled = true;
                            break;
                        case LogUser.管理员:
                            DisableCamLive(true);
                            tsmi_AcquireToolManager.Enabled = true;
                            tsmi_DebugTools.Enabled = true;
                            //ProductChoose.Enabled = true;
                            tscb_ProductAutoChoose.Enabled = true;
                            tsbtn_Camera1Debug.Enabled = true;
                            tsbtn_CodeReaderDebug.Enabled = true;
                            tsbtn_setParameter.Enabled = true;
                            tsbtn_SaveParams.Enabled = true;
                            tsbtn_ReadParams.Enabled = true;
                            tsbtn_ProductEditor.Enabled = true;
                            tsbtn_LogOut.Enabled = true;
                            tsbtn_ClearStatistics.Enabled = true;
                            tsbtn_Camera1CalibTool.Enabled = true;
                            tsbtn_Camera2CalibTool.Enabled = true;
                            tsbtn_Camera1Debug.Enabled = true;
                            tsbtn_Camera2Debug.Enabled = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 禁用或使能实时图像
        /// </summary>
        /// <param name="enaleOrNot"></param>
        private void DisableCamLive(bool enaleOrNot)
        {
            Cam1LiveDisplay.Enabled = enaleOrNot;
            Cam2LiveDisplay.Enabled = enaleOrNot;
            Cam3LiveDisplay.Enabled = enaleOrNot;
            Cam4LiveDisplay.Enabled = enaleOrNot;
        }

        /// <summary>
        /// 加载补偿值和管控值,相机参数文件
        /// </summary>
        public void LoadCompensationControlData()
        {
            try
            {
                form_ParameterConfigure.LoadData();
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 读取参数文件夹所有产品名称，更新到料号选择框中
        /// </summary>
        public void RefreshProductComboBox()
        {
            tscbx_ProductChoose.SelectedIndexChanged -= ProductChoose_SelectedIndexChanged;
            tscbx_ProductChoose.Items.Clear();
            try
            {
                string currentProduct = string.Empty;
                foreach (string item in GlobleModule.InquirePath(GlobleModule.ParaPath))
                {
                    tscbx_ProductChoose.Items.Add(item);
                }
                currentProduct = INIManager.IniReadValue("当前产品", "产品名称", GlobleModule.ConfigFilePath);

                if (currentProduct != string.Empty && tscbx_ProductChoose.Items.Contains(currentProduct))
                {
                    tscbx_ProductChoose.SelectedItem = currentProduct;
                }
                else if (tscbx_ProductChoose.Items.Count > 0)
                {
                    tscbx_ProductChoose.SelectedItem = tscbx_ProductChoose.Items[0];
                    currentProduct = tscbx_ProductChoose.SelectedItem.ToString();
                }
                CurrentProduct = currentProduct;
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
            tscbx_ProductChoose.SelectedIndexChanged += ProductChoose_SelectedIndexChanged;
        }

        /// <summary>
        /// 更新耗时信息
        /// </summary>
        /// <param name="cycleTime">周期</param>
        /// <param name="acquireTime">采集图像时间</param>
        /// <param name="processTime">处理时间</param>
        //public void RefreshCycleTimeText(int cycleTime, int acquireTime, int processTime)
        //{
        //    try
        //    {
        //        CycleTime.Text = "CycleTime：" + cycleTime.ToString() + " ms";
        //        AcquireTime.Text = "AcqTime：" + acquireTime.ToString() + " ms";
        //        ProcessTime.Text = "ProcessTime：" + processTime.ToString() + " ms";
        //    }
        //    catch (Exception) { }
        //}

        /// <summary>
        /// 定时器计时到事件回调方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //本次运行时间显示
                DateTime currentTime = DateTime.Now;
                TimeSpan timeSpan = currentTime.Subtract(startTime);
                tsLable_SysRunningTime.Text = "：" + timeSpan.Days.ToString() + "天" + timeSpan.Hours.ToString() + "时" + timeSpan.Minutes.ToString() + "分" + timeSpan.Seconds.ToString() + "秒";

                //系统总运行时间显示
                SysRunningTime = totalSysRunningTime.Add(timeSpan);
                TotalTime.Text = "：" + SysRunningTime.Days.ToString() + "天" + SysRunningTime.Hours.ToString() + "时" + SysRunningTime.Minutes.ToString() + "分" + SysRunningTime.Seconds.ToString() + "秒"; ;

                INIManager.IniWriteValue("运行时间", "系统历史运行总时间", SysRunningTime.ToString(), GlobleModule.ConfigFilePath);
                INIManager.IniWriteValue("当前产品", "产品名称", _currentProduct, GlobleModule.ConfigFilePath);

                INIManager.IniWriteValue("扫码相关", "历史扫码OK总次数", Parameter.OKCountOfHistoryCodeScan.ToString(), GlobleModule.ConfigFilePath);
                INIManager.IniWriteValue("扫码相关", "历史扫码NG总次数", Parameter.NGCountOfHistoryCodeScan.ToString(), GlobleModule.ConfigFilePath);
            }
            catch (Exception ex)
            {
                LogHelper.Warn("系统运行时间显示产生异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 启动定时器
        /// </summary>
        public void StartTimer()
        {
            timer_TimeToShow.Start();
        }

        /// <summary>
        /// 停止定时器运行
        /// </summary>
        public void StopTimer()
        {
            timer_TimeToShow.Stop();
        }

        /// <summary>
        /// 加载补偿值和管控值,相机参数文件
        /// </summary>
        //public void LoadCompensationControlData()
        //{
        //    try
        //    {
        //        form_ParameterConfigure.LoadData();
        //    }
        //    catch (Exception ex)
        //    {
        //        GlobleModule.ShowException(ex);
        //    }
        //}

        /// <summary>
        /// 保存补偿值和管控值参数
        /// </summary>
        //public void SaveCompensationAndControlData()
        //{
        //    try
        //    {
        //        form_ParameterConfigure.SaveData();
        //    }
        //    catch (Exception ex)
        //    {
        //        GlobleModule.ShowException(ex);
        //    }
        //}

        /// <summary>
        /// 加载相机参数
        /// </summary>
        public CameraData LoadCameraParameterData()
        {
            try
            {
                return GlobleModule.XmlDeserializer<CameraData>(currentVppPath + "\\Serialize", "CameraData.xml");
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
                return null;

            }
        }

        /// <summary>
        /// 保存相机参数
        /// </summary>
        public void SaveCameraParameterData()
        {
            try
            {
                GlobleModule.XmlSerializer(cameraData, currentVppPath + "\\Serialize", "CameraData.xml");
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 判断相机结果,有一个结果为OK，则全部为OK
        /// </summary>
        /// <returns></returns>
        private bool PdResult(List<Result> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].Xresult == true && results[i].Yresult == true && results[i].Angleresult == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 模拟运行
        /// </summary>
        private void SimulationRun()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                if (ImageSource.Text == "从文件取像")
                {
                    string cameraID = null;

                    stopwatch.Restart();
                    if (Parameter.Camera1imagePath != null)//相机1
                    {

                        if (vmProcedureCam1Debug.Modules[0] is ImageSourceModuleTool imageTool)
                        {
                            imageTool = (ImageSourceModuleTool)vmProcedureCam1Debug.Modules[0];

                            if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//先拿到相机的配置源
                            {
                                imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                                camera1IsConnect = true;
                            }
                            imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.LocalImage;
                            imageTool.ModuParams.SetParamValue("ClearImage", "");//清空图像                    
                            imageTool.ModuParams.SetParamValue("AddImage", Parameter.Camera1imagePath);//只添加一张图像
                            Camera1ProcedureRunOnce();

                            if (camera1IsConnect)
                            {
                                imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                                imageTool.ModuParams.SetParamValue("CameraID", cameraID);
                                imageTool.ModuParams.SetParamValue("TriggerSource", "7");
                                vmProcedureCam1Debug.Modules[0] = imageTool;
                            }

                        }
                        stopwatch.Stop();
                        css_ShowMessages.UpdateCamCT(stopwatch.ElapsedMilliseconds.ToString(), CameraName.相机1, "");
                    }

                    stopwatch.Restart();//相机2
                    if (Parameter.Camera2imagePath != null)
                    {
                        if (vmProcedureCam2Debug.Modules[0] is ImageSourceModuleTool imageTool1)
                        {
                            imageTool1 = (ImageSourceModuleTool)vmProcedureCam2Debug.Modules[0];
                            if (imageTool1.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//先拿到相机的配置源
                            {
                                imageTool1.ModuParams.GetParamValue("CameraID", ref cameraID);
                                camera2sConnect = true;
                            }

                            imageTool1.ModuParams.ImageSourceType = ImageSourceTypeEnum.LocalImage;

                            imageTool1.ModuParams.SetParamValue("ClearImage", "");//清空图像                    
                            imageTool1.ModuParams.SetParamValue("AddImage", Parameter.Camera2imagePath);//只添加一张图像
                            Camera2ProcedureRunOnce();

                            if (camera2sConnect)
                            {
                                imageTool1.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                                imageTool1.ModuParams.SetParamValue("CameraID", cameraID);
                                imageTool1.ModuParams.SetParamValue("TriggerSource", "7");
                                vmProcedureCam2Debug.Modules[0] = imageTool1;
                            }
                        }
                        stopwatch.Stop();
                        css_ShowMessages.UpdateCamCT(stopwatch.ElapsedMilliseconds.ToString(), CameraName.相机2, "");
                    }

                }
                else
                {
                    stopwatch.Restart();
                    if (Camera1IsConnected)
                    {
                        Camera1ProcedureRunOnce();
                    }
                    else
                    {
                        MessageBox.Show("相机1未连接!!!");
                    }
                    stopwatch.Stop();
                    css_ShowMessages.UpdateCamCT(stopwatch.ElapsedMilliseconds.ToString(), CameraName.相机1, "");

                    stopwatch.Restart();
                    if (Cmaera2IsConnected)
                    {
                        Camera2ProcedureRunOnce();
                    }
                    else
                    {
                        MessageBox.Show("相机1未连接!!!");
                    }
                    stopwatch.Stop();
                    css_ShowMessages.UpdateCamCT(stopwatch.ElapsedMilliseconds.ToString(), CameraName.相机2, "");
                }


                Running = false;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }

        }

        /// <summary> 更新表格</summary>
        private void UIInvoke(CameraName cameraName)
        {
            if (cameraName == CameraName.相机1)
            {
                form_MultiCamShow.RefreshMeasureShow(cameraName, camera1Result);
                if (PdResult(camera1Result))
                {
                    form_MultiCamShow.UpdateProductStatisticsInfo(CameraName.相机1, "OK");
                }
                else
                {
                    form_MultiCamShow.UpdateProductStatisticsInfo(CameraName.相机1, "NG");
                }
            }
            else
            {
                form_MultiCamShow.RefreshMeasureShow(cameraName, camera2Result);
                if (PdResult(camera2Result))
                {
                    form_MultiCamShow.UpdateProductStatisticsInfo(CameraName.相机2, "OK");
                }
                else
                {
                    form_MultiCamShow.UpdateProductStatisticsInfo(CameraName.相机2, "NG");
                }
            }

        }

        private static readonly object templock = new object();

        /// <summary>
        /// 发送数据，返回结果
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        private string SendMessage(string mes)
        {
            lock (templock)
            {
                NetworkStream DataSend = Parameter.PLC_Client.GetStream();//定义网络流
                string SendW = mes;
                var ByteSendW = Encoding.ASCII.GetBytes(SendW);//把发送数据转换为ASCII数组          
                DataSend.Write(ByteSendW, 0, ByteSendW.Length); //发送通讯数据
                byte[] data = new byte[16];//设定接收数据为16位数组，接收数据不足用0填充
                DataSend.Read(data, 0, data.Length);       //读取返回数据
                var ByteRD = "未返回数据";
                ByteRD = Encoding.ASCII.GetString(data);//接收数据从ASCII数组转换为字符串
                return ByteRD;
            }

        }



        /// <summary>
        /// 打开VisionMaster方案,加载方案流程
        /// </summary>
        public void OpenSchemes()
        {
            try
            {
                KillProcess("VisionMasterServerApp");
                KillProcess("VisionMaster");
                KillProcess("MVS");
                string str = currentVppPath + "\\相机1\\HikSolution.sol";
                try
                {
                    Parameter.ProductIs17Inch = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "是否是17寸产品", GlobleModule.ConfigFilePath));
                    VmSolution.Import(str, "jcx123"); //打开方案

                    if (Parameter.ProductIs17Inch == 1)
                    {
                        vmProcedureCam1Debug = (VmProcedure)VmSolution.Instance["相机1调试流程17寸专用"];
                    }
                    else
                    {
                        vmProcedureCam1Debug = (VmProcedure)VmSolution.Instance["相机1调试流程"];
                    }
                    vmProcedureCam2Debug = (VmProcedure)VmSolution.Instance["相机2调试流程"];
                    vmProcedureCam1Calibration = (VmProcedure)VmSolution.Instance["相机1标定流程"];
                    vmProcedureCam2Calibration = (VmProcedure)VmSolution.Instance["相机2标定流程"];
                    Camera1Tool = VmSolution.Instance[$"全局相机{1}"] as GlobalCameraModuleTool;
                    Camera2Tool = VmSolution.Instance[$"全局相机{2}"] as GlobalCameraModuleTool;
                }
                catch
                {
                    MessageBox.Show("打开.sol格式方案异常：未插机密狗或其他原因！！！");
                }
                cameraData = LoadCameraParameterData();
                WritExposureTime();
            }
            catch (VmException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 写入相机曝光和增益
        /// </summary>
        private void WritExposureTime()
        {
            try
            {
                if (cameraData == null)
                {
                    cameraData = new CameraData();
                    return;
                }
                if (!Camera1IsConnected)
                {
                    GlobleModule.LogInfo = "相机1未连接";
                    //MessageBox.Show("相机1未连接");
                }
                else
                {
                    if (vmProcedureCam1Debug.Modules[0] is ImageSourceModuleTool imageTool)
                    {
                        imageTool = (ImageSourceModuleTool)vmProcedureCam1Debug.Modules[0];

                        if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//图像源为相机
                        {
                            string cameraID = null;
                            imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                            int camer = Convert.ToInt32(cameraID);
                            if (camer > 0)
                            {
                                Camera1Tool = VmSolution.Instance[$"全局相机{1}"] as GlobalCameraModuleTool;
                                Camera1Tool.ModuParams.SetParamValue("ExposureTime", (cameraData.Camera1ExposureTime * 1000).ToString());
                                Camera1Tool.ModuParams.SetParamValue("Gain", (cameraData.Camera1Gain).ToString());
                            }
                        }
                    }
                }
                if (!Cmaera2IsConnected)
                {
                    GlobleModule.LogInfo = "相机2未连接";
                    //MessageBox.Show("相机2未连接");
                }
                else
                {

                    if (vmProcedureCam2Debug.Modules[0] is ImageSourceModuleTool imageTool1)
                    {
                        imageTool1 = (ImageSourceModuleTool)vmProcedureCam1Debug.Modules[0];

                        if (imageTool1.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//图像源为相机
                        {
                            string cameraID = null;
                            imageTool1.ModuParams.GetParamValue("CameraID", ref cameraID);
                            int camer = Convert.ToInt32(cameraID);
                            if (camer > 0)
                            {
                                Camera2Tool = VmSolution.Instance[$"全局相机{2}"] as GlobalCameraModuleTool;
                                Camera2Tool.ModuParams.SetParamValue("ExposureTime", (cameraData.Camera2ExposureTime * 1000).ToString());
                                Camera2Tool.ModuParams.SetParamValue("Gain", (cameraData.Camera2Gain).ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 保存VisionMaster方案
        /// </summary>
        public void SaveSchemes()
        {
            try
            {
                VmSolution.Export(currentVppPath + "\\相机1\\HikSolution.sol");
                SaveData();
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 保存数据到.ini文件
        /// </summary>
        private static void SaveData()
        {
            INIManager.IniWriteValue("相机1设置", "标定原点X坐标", Parameter.Cam1CalibCentralPointX.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机1设置", "标定原点Y坐标", Parameter.Cam1CalibCentralPointY.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            //INIManager.IniWriteValue("相机1设置", "相机1自动12点标定时X偏移量", Parameter.Cam1CalibOffsetX.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            //INIManager.IniWriteValue("相机1设置", "相机1自动12点标定时Y偏移量", Parameter.Cam1CalibOffsetY.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");

            INIManager.IniWriteValue("相机1设置", "示教点X坐标", Parameter.Cam1BasePointX.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机1设置", "示教点Y坐标", Parameter.Cam1BasePointY.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机1设置", "标定转化X", Parameter.Cam1CalibConversionX.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机1设置", "标定转化Y", Parameter.Cam1CalibConversionY.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机1设置", "示教角度", Parameter.Cam1baseAngle1.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");

            INIManager.IniWriteValue("相机2设置", "标定原点X坐标", Parameter.Cam2CalibCentralPointX.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "标定原点Y坐标", Parameter.Cam2CalibCentralPointY.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            //INIManager.IniWriteValue("相机2设置", "相机2自动12点标定时X偏移量", Parameter.Cam2CalibOffsetX.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            //INIManager.IniWriteValue("相机2设置", "相机2自动12点标定时Y偏移量", Parameter.Cam2CalibOffsetY.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");

            INIManager.IniWriteValue("相机2设置", "正面示教点X坐标", Parameter.Cam2BasePointXOfFront.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "正面示教点Y坐标", Parameter.Cam2BasePointYOfFront.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "正面示教角度", Parameter.Camera2BaseAngleOfFront.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "正面标定转化X", Parameter.Cam2CalibConversionXOfFront.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "正面标定转化Y", Parameter.Cam2CalibConversionYOfFront.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");

            INIManager.IniWriteValue("相机2设置", "反面示教点X坐标", Parameter.Cam2BasePointXOfOpposite.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "反面示教点Y坐标", Parameter.Cam2BasePointYOfOpposite.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "反面示教角度", Parameter.Cam2BaseAngleOfOpposite.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "反面标定转化X", Parameter.Cam2CalibConversionXOfOpposite.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
            INIManager.IniWriteValue("相机2设置", "反面标定转化Y", Parameter.Cam2CalibConversionYOfOpposite.ToString(), GlobleModule.CurrentProductPath + "\\产品构成.ini");
        }

        /// <summary>
        /// 关闭VisionMaster方案
        /// </summary>
        public void CloseVmSolution()
        {
            try
            {
                //关闭VM方案
                VmSolution.Instance.CloseSolution();
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                LogHelper.Warn("关闭VmSolution产生异常：" + Environment.NewLine + $"{ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}{ex.TargetSite.ToString()}");
            }
        }

        /// <summary>
        /// 在启动之前关闭指定程序
        /// </summary>
        /// <param name="strKillName">程序进程名</param>
        private void KillProcess(string strKillName)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains(strKillName))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        GlobleModule.ShowException(ex);
                    }
                }
            }
        }

    }
}
