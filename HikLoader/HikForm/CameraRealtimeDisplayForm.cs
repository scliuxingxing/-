using GlobalCameraModuleCs;
using HikUnLoader.HikClass;
using ImageSourceModuleCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.Core;
using static ImageSourceModuleCs.ImageSourceParam;

namespace HikUnLoader.HikFrom
{
    /// <summary>
    /// 相机画面实时显示窗体类
    /// </summary>
    public partial class CameraRealtimeDisplayForm : Form
    {
        // <summary> 相机工具 </summary>
        private GlobalCameraModuleTool camerTool;

        private ImageSourceModuleTool imageTool;

        /// <summary> 判断相机是否连接 </summary>
        private string strVal11;

        /// <summary> 用于停止相机采集 </summary>
        private bool stop=true;

        /// <summary> 流程</summary>
        private VmProcedure VmFlowPath;

        /// <summary>相机设置表格</summary>
        public DataTable dt_CameraData = new DataTable();

        /// <summary>相机设置表格参数</summary>
        public CameraData cameraData;

        /// <summary>相机编号 </summary>
        private string cameraID;

        private CameraName cameraName1;

        public CameraRealtimeDisplayForm(CameraName cameraName, VmProcedure vmProcedure, CameraData cameraData1, GlobalCameraModuleTool globalCameraModuleTool, out bool formOpen)
        {
            InitializeComponent();
            cameraName1 = cameraName;
            formOpen =iniFrom(cameraName1,vmProcedure, cameraData1, globalCameraModuleTool);     
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private bool iniFrom(CameraName cameraName, VmProcedure vmProcedure, CameraData cameraData1, GlobalCameraModuleTool globalCameraModuleTool)
        {
            try
            {
                cameraData = cameraData1;
                VmFlowPath = vmProcedure;

                if (VmFlowPath.Modules[0] is ImageSourceModuleTool)
                {
                    imageTool = (ImageSourceModuleTool)VmFlowPath.Modules[0];
                    if (imageTool.ModuParams.ImageSourceType == ImageSourceTypeEnum.Camera)
                    {
                        imageTool.ModuParams.GetParamValue("CameraID", ref cameraID);
                        int camer = Convert.ToInt32(cameraID);
                        if (camer > 0)
                        {
                            camerTool = globalCameraModuleTool;
                        }
                       // camerTool = VmSolution.Instance["全局相机1"] as GlobalCameraModuleTool;
                        if (camerTool == null)
                        {
                            MessageBox.Show("全局相机列表为空");
                            return false;
                        }
                        camerTool.ModuParams.SetParamValue("TriggerSource", "7");
                        
                        VmFlowPath.Modules[0] = imageTool;
                        if (!CmaeraIsConnected)
                        {
                            MessageBox.Show("相机未连接");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("图像源未配置从相机取像");
                        return false;
                    }


                    vmRenderControl1.ModuleSource = vmProcedure.Modules[0];
                    stop = true;
                }
                if (cameraData == null)
                {
                    nud_ExposureTime.Value = 1;
                    nud_Gain.Value = 1;
                }
                else
                {
                    if (cameraName == CameraName.相机1)
                    {
                        nud_ExposureTime.Value = cameraData.Camera1ExposureTime / 1000;
                        nud_Gain.Value = cameraData.Camera1Gain;
                    }
                    else
                    {
                        nud_ExposureTime.Value = cameraData.Camera2ExposureTime / 1000;
                        nud_Gain.Value = cameraData.Camera2Gain;
                    }
                }
                Task.Run(CameraStart);
                return true;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
                return false;
            }
        }


        /// <summary> 获取相机是否连接</summary>
        private bool CmaeraIsConnected
        {
            get
            {
                try
                {
                    imageTool.ModuParams.ImageSourceType = ImageSourceTypeEnum.Camera;
                    imageTool.ModuParams.SetParamValue("CameraID", cameraID);
                    imageTool.ModuParams.GetParamValue("TriggerSource", ref strVal11);
                    if (strVal11 == null)
                    {
                        return false;
                    }
                    //会获取类似"0$0$$$$Close"的数据，对此数据按$分割获取第一个数据，第一个值大于0表示连接，等于0表示未连接，如上数据表示该相机未连接。 
                    int data = Convert.ToInt32(strVal11.Substring(strVal11.IndexOf("$", 0) + 1, 1));
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

        /// <summary> 开始采集图像 </summary>
        private void CameraStart()
        {
            while (stop)
            {
                Thread.Sleep(10);
                imageTool.Run();
            }
        }


        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraRealTimeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop = false;
        }

        /// <summary>
        /// 控件值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_ExposureTime_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud)
            {
                nud = (NumericUpDown)sender;
                switch (nud.Name)
                {
                    case  "nud_ExposureTime":
                        camerTool.ModuParams.SetParamValue("ExposureTime", (nud_ExposureTime.Value*1000).ToString());
                        break;

                    case "nud_Gain":
                        camerTool.ModuParams.SetParamValue("Gain", nud_Gain.Value.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
    }

     

     
    }

