using HikUnLoader.HikClass;
using HikUnLoader.HikControl;
using HikUnLoader.HikFrom;
using ScaipMDAS;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;


namespace HikUnLoader
{
    /// <summary>
    /// 程序主窗体
    /// </summary>
    public partial class mainFrom : Form
    {
        /// <summary>
        /// 标记进度条加载窗口是否打开，true表示已经打开，false表示未打开
        /// </summary>
        private bool progressLoadingDisplayFormIsOpen;

        /// <summary>
        /// 程序重启标识
        /// </summary>
        private bool programRestart = false;

        /// <summary>
        /// 是否需要与PLC进行连接，true表示需要连接，false表示不需要连接
        /// </summary>
        private bool connectToPLC = true;

        /// <summary>
        /// 构造方法
        /// </summary>
        public mainFrom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 事件处理器:窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainFrom_Load(object sender, EventArgs e)
        {
            //绑定菜单工具栏项单击事件
            menuTool1.ToolStripItemClick += MenuTool1_ToolStripItemClick;
            GlobleModule.mc_Info = multiCameraShow;
            multiCameraShow.CameraNum = 2;
            menuTool1.CameraNum = 2;
            menuTool1.form_MultiCamShow = multiCameraShow;

            LogHelper.Info("程序启动");
            //启动进度条加载窗口线程
            progressLoadingDisplayFormIsOpen = true;
            Task.Run(() => RefreshProgress("正在加载程序，请稍等......"));
            ProgressLoadingDisplayForm.SendMessage("正在扫描产品文件夹，获取当前料号", 10);
            Thread.Sleep(20);
            menuTool1.StartTimer();
            menuTool1.RefreshProductComboBox();
            ProgressLoadingDisplayForm.SendMessage("加载用户权限", 30);
            Thread.Sleep(20);
            menuTool1.UserID = LogUser.操作员;

            RefreshVarable();

            ProgressLoadingDisplayForm.SendMessage("连接到PLC", 180);
            //启动PLC连接线程
            Parameter.PLC_Client = new TcpClient();
            Task.Run(() => ConnectPLC());

            ProgressLoadingDisplayForm.SendMessage("程序加载完成，即将启动应用", 200);

            this.WindowState = FormWindowState.Maximized;
            progressLoadingDisplayFormIsOpen = false;
            WindowState = FormWindowState.Maximized;
            //Show();
            BringToFront();

            //将窗体置为最顶层窗体
            //this.TopMost = true;

            //监控与PLC的连接状态，断线重连
            Task.Run(() => MonitoringPLC());
        }

        /// <summary> 
        /// 更新变量，这些变量的值与产品型号有关 
        /// </summary>
        private void RefreshVarable()
        {
            //更新当前选择料号
            ProgressLoadingDisplayForm.SendMessage("获取当前料号", 50);
            Thread.Sleep(20);
            string paraName = menuTool1.CurrentProduct;
            LoadPLCParameter();
            ProgressLoadingDisplayForm.SendMessage($"加载相机参数文件", 70);
            Thread.Sleep(20);
            ProgressLoadingDisplayForm.SendMessage($"当前料号{paraName}", 90);
            Thread.Sleep(20);
            ProgressLoadingDisplayForm.SendMessage("加载解决方案", 120);
            menuTool1.OpenSchemes();
            ProgressLoadingDisplayForm.SendMessage("加载相机1统计数据", 140);
            multiCameraShow.Camera1vmModule = menuTool1.vmProcedureCam1Debug;
            multiCameraShow.Camera2vmModule = menuTool1.vmProcedureCam2Debug;
            multiCameraShow.Read();

            ProgressLoadingDisplayForm.SendMessage("加载补偿值和管控值数据", 160);
            menuTool1.LoadCompensationControlData();

            //显示应用程序版本
            menuTool1.css_ShowMessages = CustomStatusStrip_StatusDisplay;
            CustomStatusStrip_StatusDisplay.SoftwareVersionText = "Version:" + Application.ProductVersion;
            CustomStatusStrip_StatusDisplay.CameraNum = 2;
            CustomStatusStrip_StatusDisplay.ShowCommStatus = true;

        }

        /// <summary>
        /// 事件处理器:菜单工具栏项单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ItemFunc">被单击的项</param>
        private void MenuTool1_ToolStripItemClick(object sender, ItemsFunc ItemFunc)
        {
            if (sender == null) return;
            try
            {
                switch (ItemFunc)
                {
                    case ItemsFunc.ClearStatistics:
                        multiCameraShow.ClearData();
                        break;
                    case ItemsFunc.ExitApplication:
                        Application.Exit();
                        break;
                    case ItemsFunc.LogIn:
                        //页面集成到一页，所以不做隐藏显示处理
                        break;
                    case ItemsFunc.LogOut:
                        //页面集成到一页，所以不做隐藏显示处理
                        break;
                    case ItemsFunc.SimulateRun://模拟运行                       
                        break;
                    case ItemsFunc.SaveParams://保存数据
                        SaveProjectParams();
                        break;
                    case ItemsFunc.ReadParams://读取参数
                        //ReadProjectParams();
                        break;
                    case ItemsFunc.ProductEditor:
                        GlobleModule.CurrentProductPath = menuTool1.currentProductPath;
                        programRestart = true;
                        GlobleModule.Run.Close();
                        Application.Restart();
                        break;
                    case ItemsFunc.Cam1Live://相机实时
                        break;
                    case ItemsFunc.Cam2Live:
                        break;
                    case ItemsFunc.Cam1Acqfifo://取像工具
                    case ItemsFunc.Cam2Acqfifo:
                    case ItemsFunc.Cam3Acqfifo:
                    case ItemsFunc.Cam4Acqfifo:
                        break;
                    case ItemsFunc.SaveAcqfifo://保存取像工具
                        MessageBox.Show("取像工具已保存完毕!", "保存完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case ItemsFunc.IOCardConfig://IO配置
                        break;
                    case ItemsFunc.IOCardMotion://IO监控
                        break;
                    case ItemsFunc.ScreenShot:
                        GlobleModule.StartExternProcess("snippingtool.exe", false);
                        break;
                    case ItemsFunc.Calculater:
                        GlobleModule.StartExternProcess("calc.exe", false);
                        break;
                    case ItemsFunc.NON:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 事件处理器:窗体关闭中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (programRestart)
            {
                return;
            }

            bool result = MessageBox.Show("是否要退出应用程序？" + Environment.NewLine + "请确定参数是否需要保存？", "关闭应用程序?", MessageBoxButtons.OKCancel) == DialogResult.OK;
            if (result)//如果选择退出
            {
                connectToPLC = false;
                menuTool1.StopTimer();
                menuTool1.CloseVmSolution();
                if (Parameter.PLC_Client.Connected)
                {
                    Parameter.PLC_Client.Close();
                }

                FormClosing -= mainFrom_FormClosing;

                e.Cancel = false;
            }
            else//如果选择取消退出
            {
                e.Cancel = true;//事件取消(取消关闭窗体)
            }
        }

        /// <summary>
        /// 事件处理器:窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭线程
            if (multiCameraShow.bgw_Camera1SaveImage != null)
            {
                if (multiCameraShow.bgw_Camera1SaveImage.IsBusy)
                {
                    multiCameraShow.bgw_Camera1SaveImage.CancelAsync();
                }
                multiCameraShow.bgw_Camera1SaveImage.Dispose();
            }

            if (multiCameraShow.bgw_Camera2SaveImage != null)
            {
                if (multiCameraShow.bgw_Camera2SaveImage.IsBusy)
                {
                    multiCameraShow.bgw_Camera2SaveImage.CancelAsync();
                }
                multiCameraShow.bgw_Camera2SaveImage.Dispose();
            }

            if (menuTool1.bgw_VisualSystemRunning != null)
            {
                if (menuTool1.bgw_VisualSystemRunning.IsBusy)
                {
                    menuTool1.bgw_VisualSystemRunning.CancelAsync();
                }
                menuTool1.bgw_VisualSystemRunning.Dispose();
            }

            if (menuTool1.bgw_ProductAutoChange != null)
            {
                if (menuTool1.bgw_ProductAutoChange.IsBusy)
                {
                    menuTool1.bgw_ProductAutoChange.CancelAsync();
                }
                menuTool1.bgw_ProductAutoChange.Dispose();
            }

        }

        #region  与PLC相关的模块

        /// <summary>
        /// 读取PLC参数
        /// </summary>
        private void LoadPLCParameter()
        {
            try
            {
                Parameter.productMax = 1;

                //扫码成功率相关
                Parameter.OKCountOfHistoryCodeScan = Convert.ToInt32(INIManager.IniReadValue("扫码相关", "历史扫码OK总次数", GlobleModule.ConfigFilePath));
                Parameter.NGCountOfHistoryCodeScan = Convert.ToInt32(INIManager.IniReadValue("扫码相关", "历史扫码NG总次数", GlobleModule.ConfigFilePath));

                //料号切换相关
                Parameter.Address_CurrentProductSendToPLC = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "视觉当前料号发送到PLC的地址", GlobleModule.ConfigFilePath));
                Parameter.Address_PLCCurrentProduct = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "PLC当前料号地址", GlobleModule.ConfigFilePath));
                Parameter.Address_ProductChangeTrigger = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "料号切换触发地址", GlobleModule.ConfigFilePath));
                //读码器相关
                Parameter.CodeReaderPort = INIManager.IniReadValue("PLC通信参数", "读码器COM口", GlobleModule.ConfigFilePath);
                Parameter.Address_CodeReaderData = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "读码器数据开始地址", GlobleModule.ConfigFilePath));
                Parameter.Address_CodeReaderOK = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "读码器OK地址", GlobleModule.ConfigFilePath));
                Parameter.Address_TriggerSignalOfCodeReader = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "读码器触发地址", GlobleModule.ConfigFilePath));
                //PLC
                Parameter.PLCIP = INIManager.IniReadValue("PLC通信参数", "IP地址", GlobleModule.ConfigFilePath);
                Parameter.PLCPort = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "端口号", GlobleModule.ConfigFilePath));

                Parameter.Address_CamerRady = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "Ready地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Camer1CF = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1触发地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Camer1CalibStart = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1自动标定地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1Result = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1结果地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1CalibStartPointX = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1标定原点X地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1CalibStartPointY = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1标定原点Y地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1BasePointX = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1X示教点X地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1BasePointY = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1X示教点Y地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1XSendToPLC = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1抓取产品1X点坐标", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1YSendToPLC = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1抓取产品1Y点坐标", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1AngleSendToPLC = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1抓取产品1角度坐标", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1CalibOffsetX = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1自动12点标定时X偏移量地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam1CalibOffsetY = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机1自动12点标定时Y偏移量地址", GlobleModule.ConfigFilePath));

                Parameter.Address_Camer2CF = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2触发地址", GlobleModule.ConfigFilePath));
                Parameter.Camer2MS = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2拍照模式", GlobleModule.ConfigFilePath));
                Parameter.Camera2Direction = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2正反结果地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2XDataSendToPLC = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2抓取产品1X点坐标", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2YDataSendToPLC = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2抓取产品1Y点坐标", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2AngleSendToPLC = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2抓取产品1角度坐标", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2Result = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2结果地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2CalibStartPointX = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2标定原点X地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2CalibStartPointY = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2标定原点Y地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2FrontBasePointX = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2X正面示教点X地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2FrontBasePointY = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2X正面示教点Y地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2BasePointXOfOpposite = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2X反面示教点X地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2BasePointYOfOpposite = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2X反面示教点Y地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Camer2CalibStart = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2自动标定地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2CalibOffsetX = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2自动12点标定时X偏移量地址", GlobleModule.ConfigFilePath));
                Parameter.Address_Cam2CalibOffsetY = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "相机2自动12点标定时Y偏移量地址", GlobleModule.ConfigFilePath));

                Parameter.ProductIs17Inch = Convert.ToInt32(INIManager.IniReadValue("PLC通信参数", "是否是17寸产品", GlobleModule.ConfigFilePath));
                Parameter.LongEdgeOf17InchPro = Convert.ToDouble(INIManager.IniReadValue("PLC通信参数", "17寸产品长边长度", GlobleModule.ConfigFilePath));
                Parameter.ShortEdgeOf17InchPro = Convert.ToDouble(INIManager.IniReadValue("PLC通信参数", "17寸产品短边长度", GlobleModule.ConfigFilePath));

                Parameter.Cam1CalibCentralPointX = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "标定原点X坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam1CalibCentralPointY = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "标定原点Y坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam1BasePointX = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "示教点X坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam1BasePointY = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "示教点Y坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam1baseAngle1 = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "示教角度", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam1CalibConversionX = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "标定转化X", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam1CalibConversionY = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "标定转化Y", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                //Parameter.Cam1CalibOffsetX = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "相机1自动12点标定时X偏移量", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                //Parameter.Cam1CalibOffsetY = Convert.ToDouble(INIManager.IniReadValue("相机1设置", "相机1自动12点标定时Y偏移量", GlobleModule.CurrentProductPath + "\\产品构成.ini"));

                Parameter.Cam2CalibCentralPointX = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "标定原点X坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2CalibCentralPointY = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "标定原点Y坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2BasePointXOfFront = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "正面示教点X坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2BasePointYOfFront = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "正面示教点Y坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Camera2BaseAngleOfFront = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "正面示教角度", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2CalibConversionXOfFront = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "正面标定转化X", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2CalibConversionYOfFront = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "正面标定转化Y", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                //Parameter.Cam2CalibOffsetX = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "相机2自动12点标定时X偏移量", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                //Parameter.Cam2CalibOffsetY = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "相机2自动12点标定时Y偏移量", GlobleModule.CurrentProductPath + "\\产品构成.ini"));

                Parameter.Cam2BasePointXOfOpposite = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "反面示教点X坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2BasePointYOfOpposite = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "反面示教点Y坐标", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2BaseAngleOfOpposite = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "反面示教角度", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2CalibConversionXOfOpposite = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "反面标定转化X", GlobleModule.CurrentProductPath + "\\产品构成.ini"));
                Parameter.Cam2CalibConversionYOfOpposite = Convert.ToDouble(INIManager.IniReadValue("相机2设置", "反面标定转化Y", GlobleModule.CurrentProductPath + "\\产品构成.ini"));


            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 连接到PLC
        /// </summary>
        private void ConnectPLC()
        {
            try
            {
                Parameter.PLC_Client.Connect(Parameter.PLCIP, Parameter.PLCPort);
                if (Parameter.PLC_Client.Connected)
                {
                    GlobleModule.LogInfo = "PLC连接成功";
                    CustomStatusStrip_StatusDisplay.UpdateCommState("PLC连接成功", Color.Green);
                }
            }
            catch
            {
                GlobleModule.LogInfo = "PLC连接失败";
                CustomStatusStrip_StatusDisplay.UpdateCommState("PLC连接失败", Color.Red);
            }
        }

        /// <summary>
        /// 监控与PLC的连接状态，如果断线则重新连接
        /// </summary>
        private void MonitoringPLC()
        {
            while (connectToPLC)
            {
                Thread.Sleep(1000);
                if (connectToPLC && !Parameter.PLC_Client.Connected)
                {
                    GlobleModule.LogInfo = $"PLC:{Parameter.PLCIP},端口号:{Parameter.PLCPort}正在重新连接...";
                    CustomStatusStrip_StatusDisplay.UpdateCommState("PLC正在重新连接", Color.Red);
                    try
                    {
                        Parameter.PLC_Client.Connect(Parameter.PLCIP, Parameter.PLCPort);
                        if (Parameter.PLC_Client.Connected)
                        {
                            GlobleModule.LogInfo = $"PLC连接成功!";
                            CustomStatusStrip_StatusDisplay.UpdateCommState("PLC连接成功", Color.Green);
                        }
                    }
                    catch
                    {
                        GlobleModule.LogInfo = $"PLC连接失败!";
                        CustomStatusStrip_StatusDisplay.UpdateCommState("PLC连接失败", Color.Red);
                    }

                }
            }
        }

        #endregion

        /// <summary>
        /// 进度条更新线程执行方法
        /// </summary>
        /// <param name="Info">当前过程</param>
        private void RefreshProgress(object Info)
        {

            ProgressLoadingDisplayForm welcome = new ProgressLoadingDisplayForm("Unloader 视觉系统", "")
            {
                SetLoadInfo = Info.ToString(),
            };
            welcome.ShowProgressForm(200);
            while (progressLoadingDisplayFormIsOpen)
            {
                Thread.Sleep(30);
                Application.DoEvents();
                welcome.Refresh();
            }
            welcome.CloseProgressForm();
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        private void SaveProjectParams()
        {
            try
            {
                progressLoadingDisplayFormIsOpen = true;
                Task task = new Task(RefreshProgress, "正在保存参数，请稍等......");
                task.Start();
                Thread.Sleep(50);
                ProgressLoadingDisplayForm.SendMessage("正在保存相机参数到文件", 50);
                Thread.Sleep(50);
                menuTool1.SaveCameraParameterData();
                ProgressLoadingDisplayForm.SendMessage("正在保存统计数据到文件", 100);
                Thread.Sleep(50);
                multiCameraShow.Save();
                ProgressLoadingDisplayForm.SendMessage("正在保存相机1解决方案", 150);
                Thread.Sleep(50);
                menuTool1.SaveSchemes();
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
            finally
            {
                ProgressLoadingDisplayForm.SendMessage("参数保存完毕", 200);
                Thread.Sleep(300);
                progressLoadingDisplayFormIsOpen = false;
                GC.Collect();
            }


        }

        /// <summary>
        /// 发送数据，返回结果
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        private string SendMessage(string mes)
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
}
