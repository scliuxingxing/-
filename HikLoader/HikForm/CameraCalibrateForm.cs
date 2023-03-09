using HikUnLoader.HikClass;
using ImageSourceModuleCs;
using IMVSNPointCalibModuCs;
using ScaipMDAS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VM.Core;
using static ImageSourceModuleCs.ImageSourceParam;

namespace HikUnLoader.HikFrom
{
    /// <summary>
    /// 相机自动标定窗体类
    /// </summary>
    public partial class CameraCalibrateForm : Form
    {

        /// <summary>
        /// 打开文件窗体
        /// </summary>
        private OpenFileDialog ofd_OpenImage;

        /// <summary> 
        /// 自动标定流程
        /// </summary>
        private VmProcedure VmFlowPath;

        /// <summary> 
        /// 用于判断相机的连接状态
        /// </summary>
        private string cameraConnectionStatus;
        //private string strVal11;

        /// <summary>
        /// 图像源工具
        /// </summary>
        private ImageSourceModuleTool imageTool;

        /// <summary>
        /// 相机编号
        /// </summary>
        private string cameraID;

        /// <summary>
        /// 判断相机是否配置
        /// </summary>
        public bool cameraIsConnect = false;

        /// <summary> 相机名称 </summary>
        private CameraName cameraName1;

        /// <summary>
        /// 是否已经执行完毕，执行完毕为True
        /// </summary>
        private bool runStop = true;

        /// <summary>
        /// 自动标定线程 
        /// </summary>
        public BackgroundWorker bgw_AutoCalibStart = new BackgroundWorker();

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="vmProcedure">流程</param>
        /// <param name="dt_CompRowHeader">补偿值</param>
        /// <param name="dt_ThresholdColHeader">管控值</param>
        public CameraCalibrateForm(CameraName cameraName, VmProcedure vmProcedure)
        {
            InitializeComponent();
            cameraName1 = cameraName;
            VmFlowPath = vmProcedure;
            if (VmFlowPath != null)
            {
                imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//先拿到相机的配置源
                {
                    imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                    cameraIsConnect = true;
                }
                else
                {
                    MessageBox.Show("图像源未配置到相机");
                    cameraIsConnect = false;

                }
            }
            ofd_OpenImage = new OpenFileDialog();
            ofd_OpenImage.Filter = "*.bmp*|";
            vmDebugControl.ModuleSource = VmFlowPath.Modules[1];//默认为模板匹配
            vmDebugControl.OnMouseLeftButtonDownPixelChanged += VmDebugControl_OnMouseLeftButtonDownPixelChanged;
            bgw_AutoCalibStart.DoWork += bgw_AutoCalibStart_DoWork;
            bgw_AutoCalibStart.WorkerSupportsCancellation = true;

        }

        /// <summary>
        /// 事件处理器:自动标定线程执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">事件参数</param>
        private void bgw_AutoCalibStart_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //如果PLC未连接，直接结束
                if (!Parameter.PLC_Client.Connected)
                {
                    groupBox2.BackColor = Color.Red;
                    MessageBox.Show("PLC未连接!!!");
                    if (cb_Calib.InvokeRequired)
                    {
                        cb_Calib.Invoke(new Action(() => { cb_Calib.Checked = false; }));
                    }
                    else
                    {
                        cb_Calib.Checked = false;
                    }
                    groupBox2.BackColor = Color.Orange;
                    return;
                }

                //如果相机未连接，直接结束
                if (!CameraIsConnected)
                {
                    groupBox2.BackColor = Color.Red;
                    MessageBox.Show("相机未连接!!!");
                    if (cb_Calib.InvokeRequired)
                    {
                        cb_Calib.Invoke(new Action(() => { cb_Calib.Checked = false; }));
                    }
                    else
                    {
                        cb_Calib.Checked = false;
                    }
                    groupBox2.BackColor = Color.Orange;
                    return;
                }

                groupBox2.BackColor = Color.LawnGreen;

                string RD = null;
                int cameraCF0 = 1;
                int cameraCF1 = 0;
                int quantity = -1;
                RD = "WR DM" + Parameter.Address_Camer1CalibStart + ".U " + 1 + "\r";
                SendMessage(RD);

                GlobleModule.LogInfo = "已发送开始标定信号";
                GlobleModule.LogInfo = "开始标定";

                while (true)
                {
                    //如果收到了取消线程的信号，则退出循环
                    if (bgw_AutoCalibStart.CancellationPending)
                    {
                        groupBox2.BackColor = Color.Orange;
                        //return;
                        //e.Cancel = true;
                        break;
                    }
                    runStop = false;

                    Thread.Sleep(5);

                    //相机触发
                    if (cameraName1 == CameraName.相机1)
                    {
                        RD = "RD DM" + Parameter.Address_Camer1CF + ".U\r";//相机1触发拍照信号
                    }
                    else
                    {
                        RD = "RD DM" + Parameter.Address_Camer2CF + ".U\r";//相机2触发拍照信号
                    }
                    RD = SendMessage(RD);//读出来的字段是+00001或者+00000
                    if (RD.Substring(0, 5) == "00000" || RD.Substring(0, 5) == "00001")
                    {
                        cameraCF1 = Convert.ToInt32(RD.Substring(4, 1));
                        if (cameraCF1 == 1 && cameraCF1 != cameraCF0)
                        {
                            //执行一次流程
                            VmFlowPath.Run();
                            //计数
                            quantity++;
                            string path = $"C:\\Users\\Administrator\\Desktop\\图片\\{DateTime.Now.ToString("hhmmss")}.bmp";
                            this.Invoke(new Action(() => vmDebugControl.SaveOriginalImage(path)));

                            //界面计数更新
                            if (lb_text.InvokeRequired)
                            {
                                lb_text.Invoke(new Action(() =>
                                {
                                    lb_text.Text = (quantity + 1).ToString();
                                }));
                            }
                            else
                            {
                                lb_text.Text = (quantity + 1).ToString();
                            }
                            if (cameraName1 == CameraName.相机1)
                            {
                                //相机1拍照完成信号
                                RD = "WR DM" + Parameter.Address_Cam1Result + ".U " + 1 + "\r";
                            }
                            else
                            {
                                //相机2拍照完成信号
                                RD = "WR DM" + Parameter.Address_Cam2Result + ".U " + 1 + "\r";
                            }
                            SendMessage(RD);

                            if (quantity == 11)
                            {
                                GlobleModule.LogInfo = "标定结束";
                                runStop = true;

                                //给PLC发送停止信号
                                RD = "WR DM" + Parameter.Address_Cam1Result + ".U " + 0 + "\r";
                                SendMessage(RD);

                                //GlobleModule.LogInfo = "标定结束";
                                if (VmFlowPath.Modules[2] is IMVSNPointCalibModuTool calibTool)
                                {
                                    calibTool = (IMVSNPointCalibModuTool)VmFlowPath.Modules[2];
                                    if (calibTool.ModuResult.CalibStatus == 0)
                                    {
                                        MessageBox.Show("标定失败");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"旋转误差为{Math.Round(calibTool.ModuResult.RotError, 2)}，平移误差为{Math.Round(calibTool.ModuResult.TransError, 2)}");
                                    }
                                }

                                if (cb_Calib.InvokeRequired)
                                {
                                    cb_Calib.Invoke(new Action(() =>
                                    {
                                        cb_Calib.Checked = false;
                                        cb_Calib.Enabled = true;
                                    }));
                                }
                                else
                                {
                                    cb_Calib.Checked = false;
                                    cb_Calib.Enabled = true;
                                }
                                //return;
                                break;
                            }
                        }
                        cameraCF0 = cameraCF1;
                    }
                }
                groupBox2.BackColor = Color.Orange;
            }
            catch (Exception ex)
            {
                groupBox2.BackColor = Color.Red;
                LogHelper.Warn("自动标定流程产生异常：" + ex.Message);
                if (cb_Calib.InvokeRequired)
                {
                    cb_Calib.Invoke(new Action(() => { cb_Calib.Checked = false; }));
                }
                else
                {
                    cb_Calib.Checked = false;
                }

                cb_Calib.Enabled = true;
            }
        }

        /// <summary> 事件处理器:图像点击事件 </summary>
        /// <param name="X">当前图像的X坐标</param>
        /// <param name="Y">当前图像的Y坐标</param>
        private void VmDebugControl_OnMouseLeftButtonDownPixelChanged(int X, int Y)
        {
            try
            {
                tb_Point.Text = $"图像坐标({X},{Y})";
            }
            catch
            {

            }
        }

        /// <summary> 
        /// 属性:自动标定流程
        /// </summary>
        public VmProcedure Procedure
        {
            get
            {
                return VmFlowPath;
            }
        }

        /// <summary> 
        /// 事件处理器:点击按钮事件
        /// </summary>
        private void bt_Click(object sender, EventArgs e)
        {
            try
            {
                //所有按钮默认颜色
                foreach (var item in tableLayoutPanel5.Controls)
                {
                    if (item is Button btn)
                    {
                        btn.BackColor = Color.Orange;
                    }
                }
                foreach (var item in tableLayoutPanel4.Controls)
                {
                    if (item is Button btn)
                    {
                        btn.BackColor = Color.Orange;
                    }
                }


                if (sender is Button button)
                {
                    button = (Button)sender;
                    //点击某个按钮后，按钮变色
                    button.BackColor = Color.LightGreen;
                    switch (button.Name)
                    {
                        case nameof(btn_GetImageFromCam)://从相机获取图像                                
                            if (!CameraIsConnected)
                            {
                                MessageBox.Show("相机未连接!!!");
                            }
                            else
                            {
                                imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                                imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                                imageTool.ModuParams.SetParamValue("CameraID", cameraID);
                                imageTool.ModuParams.SetParamValue("TriggerSource", "7");
                                VmFlowPath.Modules[0] = imageTool;
                                if (runStop)
                                {
                                    runStop = false;
                                    VmFlowPath.Run();
                                    runStop = true;
                                }

                            }
                            break;
                        case nameof(btn_GetImageFromFile)://从文件获取图像
                            if (ofd_OpenImage.ShowDialog() == DialogResult.OK)
                            {

                                imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                                imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.LocalImage;
                                imageTool.ModuParams.SetParamValue("ClearImage", "");//清空图像
                                imageTool.ModuParams.SetParamValue("AddImage", ofd_OpenImage.FileName);//只添加一张图像
                                VmFlowPath.Run();
                                VmFlowPath.Modules[0] = imageTool;

                            }
                            break;
                        case nameof(btn_CalibrationOfDistortion)://畸变标定
                            if (runStop)
                            {
                                runStop = false;
                                VmFlowPath.Modules[6].IsForbidden = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[6];
                                runStop = true;
                            }
                            break;
                        case nameof(btn_CorrectionOfDistortion)://畸变矫正
                            if (runStop)
                            {
                                runStop = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[5];
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_PMATool)://模板匹配工具
                            if (runStop)
                            {
                                runStop = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[1];
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_VertexTool)://顶点工具
                            if (runStop)
                            {
                                runStop = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[4];
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_Generate12PointCalibFile)://标定工具
                            if (runStop)
                            {
                                runStop = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[2];
                                VmFlowPath.Run();
                                runStop = true;
                            }
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
        /// 获取相机是否连接
        /// </summary>
        private bool CameraIsConnected
        {
            get
            {
                try
                {
                    imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                    imageTool.ModuParams.SetParamValue("CameraID", cameraID);
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
                catch (Exception ex)
                {
                    GlobleModule.ShowException(ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraDubugFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (cameraIsConnect)
                {
                    imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                    imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                    imageTool.ModuParams.SetParamValue("CameraID", cameraID);
                    imageTool.ModuParams.SetParamValue("TriggerSource", "7");
                    VmFlowPath.Modules[0] = imageTool;
                }
                VmFlowPath.Modules[6].IsForbidden = true;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 复选框勾选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Calib_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Calib.Checked)
            {
                if (VmFlowPath.Modules[2] is IMVSNPointCalibModuTool calibTool)
                {
                    VmFlowPath.Modules[6].IsForbidden = true;//禁用畸变标定
                    calibTool = (IMVSNPointCalibModuTool)VmFlowPath.Modules[2];
                    calibTool.ModuParams.SetParamValue("Clear", "");
                    //bgw_AutoCalibStart.RunWorkerAsync();
                }
                if (!bgw_AutoCalibStart.IsBusy)
                {
                    bgw_AutoCalibStart.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("自动标定线程已经在运行中！！！");
                }
            }
            else
            {
                runStop = true;
                if (bgw_AutoCalibStart.IsBusy)
                {
                    bgw_AutoCalibStart.CancelAsync();
                }
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
