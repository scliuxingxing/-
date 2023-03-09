using GlobalCameraModuleCs;
using HikUnLoader.HikClass;
using ImageSourceModuleCs;
using IMVSCalibTransformModuCs;
using IMVSQuadrangleFindModuCs;
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
    /// 相机1示教位设置窗体类
    /// </summary>
    public partial class Camera1DebugForm : Form
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
        /// 判断相机是否配置
        /// </summary>
        public bool CameraIsConnect = false;

        /// <summary>
        /// 是否已经执行完毕，执行完毕为True
        /// </summary> 
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

        /// <summary>相机名称</summary>
        private CameraName cameraName1;

        /// <summary>
        /// 相机工具
        /// </summary>
        private GlobalCameraModuleTool cameraTool;

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="vmProcedure">流程</param>
        public Camera1DebugForm(CameraName cameraName, VmProcedure vmProcedure, GlobalCameraModuleTool globalCamTool)
        {
            InitializeComponent();
            cameraName1 = cameraName;
            VmFlowPath = vmProcedure;
            cameraTool = globalCamTool;
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
        private void Camera1DebugForm_Load(object sender, EventArgs e)
        {
            label_CalibCentralPointX.Text = Parameter.Cam1CalibCentralPointX.ToString();
            label_CalibCentralPointY.Text = Parameter.Cam1CalibCentralPointY.ToString();
            label_CalibConversionX.Text = Parameter.Cam1CalibConversionX.ToString();
            label_CalibConversionY.Text = Parameter.Cam1CalibConversionY.ToString();
            label_BasePointX.Text = Parameter.Cam1BasePointX.ToString();
            label_BasePointY.Text = Parameter.Cam1BasePointY.ToString();
            label_BaseAngle.Text = Parameter.Cam1baseAngle1.ToString();

            comboBox1.SelectedIndex = 0;
            if (Parameter.ProductIs17Inch == 1)
            {
                btn_Load12PointCalibFile.Text = "加载12点标定文件(四边形)";
                comboBox1.Visible = true;
                comboBox1.Enabled = true;
            }
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
        /// 点击按钮事件
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
                                if (cameraName1 == CameraName.相机1)
                                {
                                    Parameter.Camera1imagePath = ofd_OpenImage.FileName;
                                }
                                else
                                {
                                    Parameter.Camera2imagePath = ofd_OpenImage.FileName;
                                }
                                imageTool.ModuParams.SetParamValue("AddImage", ofd_OpenImage.FileName);//只添加一张图像
                                VmFlowPath.Run();
                                VmFlowPath.Modules[0] = imageTool;

                            }
                            break;
                        case nameof(btn_CorrectionOfDistortion)://畸变矫正
                            if (runStop)
                            {
                                runStop = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[1];
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_PMATool)://模板匹配工具
                            if (runStop)
                            {
                                runStop = false;
                                vmDebugControl.ModuleSource = VmFlowPath.Modules[2];
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_GuadrangleTool)://四边形工具
                            if (runStop)
                            {
                                runStop = false;

                                if (comboBox1.SelectedIndex == 1)
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[10];//顶点工具(左上)
                                }
                                else if (comboBox1.SelectedIndex == 2)
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[11];//顶点工具(右下)
                                }
                                else
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[7];//四边形工具
                                }
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_Load12PointCalibFile)://标定转换工具
                            if (runStop)
                            {
                                runStop = false;
                                if (comboBox1.SelectedIndex == 0)
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[3]; ;//四边形工具对应的标定转换工具
                                }
                                else if (comboBox1.SelectedIndex == 1)
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[8];//顶点工具(左上)对应的标定转换工具
                                }
                                else if (comboBox1.SelectedIndex == 2)
                                {
                                    vmDebugControl.ModuleSource = VmFlowPath.Modules[9];//顶点工具(右下)对应的标定转换工具
                                }
                                VmFlowPath.Run();
                                runStop = true;
                            }
                            break;
                        case nameof(btn_SetBasePosition)://设置示教位
                            if (Parameter.PLC_Client.Connected)
                            {
                                runStop = false;
                                VmFlowPath.Run();
                                //从PLC读取相关数据
                                string str1 = SendMessage("RD DM" + Parameter.Address_Cam1CalibStartPointX + ".L\r");
                                string str2 = SendMessage("RD DM" + Parameter.Address_Cam1CalibStartPointY + ".L\r");
                                string str3 = SendMessage("RD DM" + Parameter.Address_Cam1BasePointX + ".L\r");
                                string str4 = SendMessage("RD DM" + Parameter.Address_Cam1BasePointY + ".L\r");
                                string str5 = SendMessage("RD EM" + Parameter.Address_Cam1CalibOffsetX + ".L\r");
                                string str6 = SendMessage("RD EM" + Parameter.Address_Cam1CalibOffsetY + ".L\r");
                                if (Parameter.IsNumberic(str1) && Parameter.IsNumberic(str2) && Parameter.IsNumberic(str3)
                                    && Parameter.IsNumberic(str4) && Parameter.IsNumberic(str5) && Parameter.IsNumberic(str6))
                                {
                                    Parameter.Cam1CalibCentralPointX = Math.Round(double.Parse(str1) / 100, 2) + Math.Round(double.Parse(str5) / 100, 2);
                                    Parameter.Cam1CalibCentralPointY = Math.Round(double.Parse(str2) / 100, 2) + Math.Round(double.Parse(str6) / 100, 2);
                                    //旧的示教点
                                    Parameter.Cam1BasePointX = Math.Round(double.Parse(str3) / 100, 2);
                                    Parameter.Cam1BasePointY = Math.Round(double.Parse(str4) / 100, 2);
                                    if (VmFlowPath.Modules[7] is IMVSQuadrangleFindModuTool sbTool && VmFlowPath.Modules[3] is IMVSCalibTransformModuTool calibTool)
                                    {
                                        sbTool = (IMVSQuadrangleFindModuTool)VmFlowPath.Modules[7];
                                        calibTool = (IMVSCalibTransformModuTool)VmFlowPath.Modules[3];
                                        if (sbTool.ModuResult.EdgeLine1 != null)
                                        {
                                            Parameter.Cam1baseAngle1 = Math.Round(sbTool.ModuResult.EdgeLine1.Angle, 2);
                                        }
                                        if (calibTool.ModuResult.TransPoint != null && calibTool.ModuResult.TransPoint.Count > 0)
                                        {
                                            Parameter.Cam1CalibConversionX = Math.Round(calibTool.ModuResult.TransPoint[0].X, 2);
                                            Parameter.Cam1CalibConversionY = Math.Round(calibTool.ModuResult.TransPoint[0].Y, 2);
                                        }
                                    }
                                    UpdateFormInformation();
                                    //新的示教点
                                    Parameter.Cam1BasePointX = Parameter.Cam1CalibCentralPointX + Math.Round(Parameter.Cam1CalibConversionX, 2);
                                    Parameter.Cam1BasePointY = Parameter.Cam1CalibCentralPointY + Math.Round(Parameter.Cam1CalibConversionY, 2);
                                }
                                runStop = true;
                            }
                            else
                            {
                                MessageBox.Show("PLC未连接");
                            }
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
        ///  更新界面示教位信息
        /// </summary>
        private void UpdateFormInformation()
        {
            if (label_BasePointX.InvokeRequired)
            {
                label_BasePointX.Invoke(new Action(() => UpdateFormInformation()));
                return;
            }
            else
            {
                label_CalibCentralPointX.Text = Math.Round(Parameter.Cam1CalibCentralPointX).ToString();
                label_CalibCentralPointY.Text = Math.Round(Parameter.Cam1CalibCentralPointY).ToString();
                label_CalibConversionX.Text = Math.Round(Parameter.Cam1CalibConversionX, 2).ToString();
                label_CalibConversionY.Text = Math.Round(Parameter.Cam1CalibConversionY, 2).ToString();
                label_BasePointX.Text = Math.Round(Parameter.Cam1BasePointX, 2).ToString();
                label_BasePointY.Text = Math.Round(Parameter.Cam1BasePointY, 2).ToString();
                label_BaseAngle.Text = Parameter.Cam1baseAngle1.ToString();

                GlobleModule.LogInfo = "PLC取料基准位X轴：" + (Parameter.Cam1CalibCentralPointX + Math.Round(Parameter.Cam1CalibConversionX, 2)).ToString();
                GlobleModule.LogInfo = "PLC取料基准位Y轴：" + (Parameter.Cam1CalibCentralPointY + Math.Round(Parameter.Cam1CalibConversionY, 2)).ToString();
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
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Camera1DebugForm_FormClosing(object sender, FormClosingEventArgs e)
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
        /// 将数据信息写入到PLC的X轴和Y轴取料基准位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_WriteToPLC_Click(object sender, EventArgs e)
        {
            try
            {

                //发送数据到PLC取料基准位X
                int send = Convert.ToInt32(Parameter.Cam1BasePointX * 100);
                string RD = "WR EM" + Parameter.Address_Cam1BasePointX + ".L " + send + "\r";
                if (SendMessage(RD) == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                {
                    GlobleModule.LogInfo = $"PLC取料基准位X坐标发送成功!!!";
                }
                else
                {
                    GlobleModule.LogInfo = $"PLC取料基准位X坐标发送失败!!!";
                }
                //发送数据到PLC取料基准位Y
                send = Convert.ToInt32(Parameter.Cam1BasePointY * 100);
                RD = "WR EM" + Parameter.Address_Cam1BasePointY + ".L " + send + "\r";
                if (SendMessage(RD) == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                {
                    GlobleModule.LogInfo = $"PLC取料基准位Y坐标发送成功!!!";
                }
                else
                {
                    GlobleModule.LogInfo = $"PLC取料基准位Y坐标发送失败!!!";
                }

                //更新界面显示信息
                UpdateFormInformation();
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// 事件处理器：选择四边形工具或者顶点工具时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                btn_GuadrangleTool.Text = "四边形工具";
                btn_Load12PointCalibFile.Text = "加载12点标定文件(四边形)";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                btn_GuadrangleTool.Text = "顶点工具(左上)";
                btn_Load12PointCalibFile.Text = "加载12点标定文件(顶点左上)";
            }
            else
            {
                btn_GuadrangleTool.Text = "顶点工具(右下)";
                btn_Load12PointCalibFile.Text = "加载12点标定文件(顶点右下)";
            }

        }
    }
}
