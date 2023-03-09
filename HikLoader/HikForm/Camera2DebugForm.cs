using GlobalCameraModuleCs;
using HikUnLoader.HikClass;
using ImageSourceModuleCs;
using IMVSCalibTransformModuCs;
using IMVSCaliperCornerModuCs;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using VM.Core;
using static ImageSourceModuleCs.ImageSourceParam;

namespace HikUnLoader.HikFrom
{
    /// <summary>
    /// 相机2示教位设置窗体类
    /// </summary>
    public partial class Camera2DebugForm : Form
    {
        /// <summary>
        /// 打开文件窗体
        /// </summary>
        private OpenFileDialog ofd_OpenImage;

        /// <summary>
        /// 示教位调试流程
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
        /// 是否已经执行完毕，执行完毕为True
        /// </summary>
        /// 
        private bool runStop = true;

        /// <summary> 
        /// 获取相机是否连接
        /// </summary>
        private bool CmaeraIsConnected
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
        /// 判断相机是否配置
        /// </summary>
        public bool CameraIsConnect = false;

        /// <summary>
        /// 相机工具
        /// </summary>
        private GlobalCameraModuleTool cameraTool;

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="vmProcedure">流程</param>
        public Camera2DebugForm(VmProcedure vmProcedure, GlobalCameraModuleTool globalCamera)
        {
            InitializeComponent();
            VmFlowPath = vmProcedure;
            cameraTool = globalCamera;
            if (VmFlowPath != null)
            {
                imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)//先拿到相机的配置源
                {
                    imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                    CameraIsConnect = true;
                }
                else
                {
                    MessageBox.Show("图像源未配置到相机");
                    CameraIsConnect = false;
                }
            }
            ofd_OpenImage = new OpenFileDialog();
            ofd_OpenImage.Filter = "*.bmp*|";
            vmDebugControl.ModuleSource = VmFlowPath.Modules[2];
            vmDebugControl.OnMouseLeftButtonDownPixelChanged += VmDebugControl_OnMouseLeftButtonDownPixelChanged;
        }

        /// <summary>
        /// 窗体加载时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Camera2DebugForm_Load(object sender, EventArgs e)
        {
            cb_Pma.SelectedIndex = 0;
            UpdataFormInformation();
        }

        /// <summary> 图像点击事件 </summary>
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
        /// 属性:示教位调试流程
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
                            if (!CmaeraIsConnected)
                            {
                                MessageBox.Show("相机未连接!!!");
                            }
                            else
                            {
                                imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                                imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                                imageTool.ModuParams.SetParamValue("CameraID", cameraID);
                                cameraTool?.ModuParams.SetParamValue("TriggerSource", "7");
                                imageTool.ModuParams.SetParamValue("TriggerSource", "7");
                                VmFlowPath.Modules[0] = imageTool;
                                VmFlowPath.Run();
                            }
                            break;
                        case nameof(btn_GetImageFromFile)://从文件获取图像
                            if (ofd_OpenImage.ShowDialog() == DialogResult.OK)
                            {
                                imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                                imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.LocalImage;
                                imageTool.ModuParams.SetParamValue("ClearImage", "");//清空图像

                                Parameter.Camera2imagePath = ofd_OpenImage.FileName;

                                imageTool.ModuParams.SetParamValue("AddImage", ofd_OpenImage.FileName);//只添加一张图像
                                VmFlowPath.Run();
                                VmFlowPath.Modules[0] = imageTool;

                            }
                            break;
                        case nameof(btn_CorrectionOfDistortion):
                            if (runStop)
                            {
                                runStop = false;

                                // VmFlowPath.Modules[4].IsForbidden = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[1];
                                runStop = true;
                            }
                            break;
                        case nameof(btn_PMATool)://模板匹配
                            if (runStop)
                            {
                                runStop = false;

                                VmFlowPath.Modules[4].IsForbidden = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[2];
                                runStop = true;
                            }
                            break;
                        case nameof(btn_VertexTool)://顶点工具
                            if (runStop)
                            {
                                runStop = false;
                                if (cb_Pma.SelectedIndex == 0)
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[6];
                                }
                                else
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[10];
                                }
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_Load12PointCalibFile)://标定转换工具
                            if (runStop)
                            {
                                runStop = false;
                                if (cb_Pma.SelectedIndex == 0)
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[7];
                                }
                                else
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[11];
                                }
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_SetBasePosition)://设置示教位
                            SetBasePositon();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
                runStop = true;
            }
        }

        /// <summary>
        /// 点击示教位按钮后执行此方法
        /// </summary>
        private void SetBasePositon()
        {
            if (Parameter.PLC_Client.Connected)
            {
                if (runStop)
                {
                    runStop = false;
                    VmFlowPath.Run();
                    IMVSCaliperCornerModuTool DTool = null;
                    IMVSCalibTransformModuTool calibTool = null;
                    if (cb_Pma.SelectedIndex == 0)//正面
                    {
                        //vmDebugControl.ModuleSource = VmFlowPath.Modules[8];
                        DTool = (IMVSCaliperCornerModuTool)VmFlowPath.Modules[6];
                        calibTool = (IMVSCalibTransformModuTool)VmFlowPath.Modules[7];

                        //读取PLC标定起始点
                        string str1 = SendMessage("RD DM" + Parameter.Address_Cam2CalibStartPointX + ".L\r");
                        string str2 = SendMessage("RD DM" + Parameter.Address_Cam2CalibStartPointY + ".L\r");
                        //读取PLC当前取料基准位
                        string str3 = SendMessage("RD DM" + Parameter.Address_Cam2FrontBasePointX + ".L\r");
                        string str4 = SendMessage("RD DM" + Parameter.Address_Cam2FrontBasePointY + ".L\r");
                        //读取PLC标定时x和y偏移地址
                        string str5 = SendMessage("RD EM" + Parameter.Address_Cam2CalibOffsetX + ".L\r");
                        string str6 = SendMessage("RD EM" + Parameter.Address_Cam2CalibOffsetY + ".L\r");

                        if (Parameter.IsNumberic(str1) && Parameter.IsNumberic(str2) && Parameter.IsNumberic(str3) && Parameter.IsNumberic(str4) && Parameter.IsNumberic(str5) && Parameter.IsNumberic(str6))
                        {
                            //标定原点坐标
                            Parameter.Cam2CalibCentralPointX = Math.Round(double.Parse(str1) / 100, 2) + Math.Round(double.Parse(str5) / 100, 2);
                            Parameter.Cam2CalibCentralPointY = Math.Round(double.Parse(str2) / 100, 2) + Math.Round(double.Parse(str6) / 100, 2);
                            //示教点x和y的值
                            Parameter.Cam2BasePointXOfFront = Math.Round(double.Parse(str3) / 100, 2);
                            Parameter.Cam2BasePointYOfFront = Math.Round(double.Parse(str4) / 100, 2);

                            if (DTool.ModuResult.EdgeLine1 != null)
                            {
                                Parameter.Camera2BaseAngleOfFront = Math.Round(DTool.ModuResult.EdgeLine1.Angle, 2);
                            }
                            if (calibTool.ModuResult.TransPoint != null && calibTool.ModuResult.TransPoint.Count > 0)
                            {
                                Parameter.Cam2CalibConversionXOfFront = Math.Round(calibTool.ModuResult.TransPoint[0].X, 2);
                                Parameter.Cam2CalibConversionYOfFront = Math.Round(calibTool.ModuResult.TransPoint[0].Y, 2);
                            }
                            GlobleModule.LogInfo = "tray盘正面示教完成";
                        }
                    }
                    else if (cb_Pma.SelectedIndex == 1)//反面
                    {
                        //vmDebugControl.ModuleSource = VmFlowPath.Modules[12];
                        DTool = (IMVSCaliperCornerModuTool)VmFlowPath.Modules[10];
                        calibTool = (IMVSCalibTransformModuTool)VmFlowPath.Modules[11];
                        //读取PLC标定起始点
                        string str1 = SendMessage("RD DM" + Parameter.Address_Cam2CalibStartPointX + ".L\r");
                        string str2 = SendMessage("RD DM" + Parameter.Address_Cam2CalibStartPointY + ".L\r");
                        //读取PLC当前取料基准位
                        string str3 = SendMessage("RD DM" + Parameter.Address_Cam2BasePointXOfOpposite + ".L\r");
                        string str4 = SendMessage("RD DM" + Parameter.Address_Cam2BasePointYOfOpposite + ".L\r");
                        //读取PLC标定时x和y偏移地址
                        string str5 = SendMessage("RD EM" + Parameter.Address_Cam2CalibOffsetX + ".L\r");
                        string str6 = SendMessage("RD EM" + Parameter.Address_Cam2CalibOffsetY + ".L\r");
                        if (Parameter.IsNumberic(str1) && Parameter.IsNumberic(str2) && Parameter.IsNumberic(str3) && Parameter.IsNumberic(str4) && Parameter.IsNumberic(str5) && Parameter.IsNumberic(str6))
                        {
                            Parameter.Cam2CalibCentralPointX = Math.Round(double.Parse(str1) / 100, 2) + Math.Round(double.Parse(str5) / 100, 2);
                            Parameter.Cam2CalibCentralPointY = Math.Round(double.Parse(str2) / 100, 2) + Math.Round(double.Parse(str6) / 100, 2);
                            Parameter.Cam2BasePointXOfOpposite = Math.Round(double.Parse(str3) / 100, 2);
                            Parameter.Cam2BasePointYOfOpposite = Math.Round(double.Parse(str4) / 100, 2);

                            Parameter.Cam2BaseAngleOfOpposite = Parameter.Camera2BaseAngleOfFront;
                            Parameter.Cam2CalibConversionXOfOpposite = Parameter.Cam2CalibConversionXOfFront;
                            Parameter.Cam2CalibConversionYOfOpposite = Parameter.Cam2CalibConversionYOfFront;
                        }
                        GlobleModule.LogInfo = "tray盘反面示教完成";
                    }
                    UpdataFormInformation();
                    runStop = true;
                }
            }
            else
            {
                MessageBox.Show("PLC未连接!");
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

        /// <summary>
        /// 事件处理器:窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Camera2DebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CameraIsConnect)
                {
                    imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                    imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                    imageTool.ModuParams.SetParamValue("CameraID", cameraID);
                    imageTool.ModuParams.SetParamValue("TriggerSource", "7");
                    VmFlowPath.Modules[0] = imageTool;
                }
                VmFlowPath.Modules[4].IsForbidden = true;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 更新界面示教点数据信息
        /// </summary>
        private void UpdataFormInformation()
        {
            if (label_BasePointX.InvokeRequired)
            {
                label_BasePointX.Invoke(new Action(() => UpdataFormInformation()));
                return;
            }
            else
            {
                if (cb_Pma.SelectedIndex == 0)//正面示教
                {
                    label_CalibCentralPointX.Text = Parameter.Cam2CalibCentralPointX.ToString();
                    label_CalibCentralPointY.Text = Parameter.Cam2CalibCentralPointY.ToString();
                    label_CalibConversionX.Text = Math.Round(Parameter.Cam2CalibConversionXOfFront, 2).ToString();
                    label_CalibConversionY.Text = Math.Round(Parameter.Cam2CalibConversionYOfFront, 2).ToString();
                    label_BasePointX.Text = Math.Round(Parameter.Cam2BasePointXOfFront, 2).ToString();
                    label_BasePointY.Text = Math.Round(Parameter.Cam2BasePointYOfFront, 2).ToString();
                    label_BaseAngle.Text = Parameter.Camera2BaseAngleOfFront.ToString();
                }
                else//反面示教
                {
                    label_CalibCentralPointX.Text = Parameter.Cam2CalibCentralPointX.ToString();
                    label_CalibCentralPointY.Text = Parameter.Cam2CalibCentralPointY.ToString();
                    label_CalibConversionX.Text = Math.Round(Parameter.Cam2CalibConversionXOfOpposite, 2).ToString();
                    label_CalibConversionY.Text = Math.Round(Parameter.Cam2CalibConversionYOfOpposite, 2).ToString();
                    label_BasePointX.Text = Math.Round(Parameter.Cam2BasePointXOfOpposite, 2).ToString();
                    label_BasePointY.Text = Math.Round(Parameter.Cam2BasePointYOfOpposite, 2).ToString();
                    label_BaseAngle.Text = Parameter.Cam2BaseAngleOfOpposite.ToString();
                }
            }
        }

        private void cb_Pma_SelectedIndexChanged(object sender, EventArgs e)
        {
            vmDebugControl.ModuleSource = VmFlowPath.Modules[2];
        }

    }
}
