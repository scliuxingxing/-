using HikUnLoader.HikClass;
using HikUnLoader.HikControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HikUnLoader.HikControl
{
    /// <summary>
    /// 状态栏控件
    /// </summary>
    public partial class CustomStatusStrip : UserControl
    {
        private LogUser logUser = LogUser.无用户;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomStatusStrip()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 属性：设置相机个数。
        /// </summary>
        [Browsable(true)]
        [Description("相机个数，最大支持4个"), Category("VisionCommon")]
        public int CameraNum
        {
            set
            {
                switch (value)
                {
                    case 1:
                        tsl_Cam1CT.Visible = true;
                        tsl_Cam2CT.Visible = false;
                        tsl_Cam3CT.Visible = false;
                        tsl_Cam4CTLabel.Visible = false;
                        break;
                    case 2:
                        tsl_Cam1CT.Visible = true;
                        tsl_Cam2CT.Visible = true;
                        tsl_Cam3CT.Visible = false;
                        tsl_Cam4CTLabel.Visible = false;
                        break;
                    case 3:
                        tsl_Cam1CT.Visible = true;
                        tsl_Cam2CT.Visible = true;
                        tsl_Cam3CT.Visible = true;
                        tsl_Cam4CTLabel.Visible = false;
                        break;
                    case 4:
                        tsl_Cam1CT.Visible = true;
                        tsl_Cam2CT.Visible = true;
                        tsl_Cam3CT.Visible = true;
                        tsl_Cam4CTLabel.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// 属性：设置当前用户。
        /// </summary>
        [Browsable(true)]
        [Description("当前用户"), Category("VisionCommon")]
        public LogUser CurrentUser
        {
            set
            {
                logUser = value;
                tsl_CurrentUser.Text = $"当前用户：{value}";
            }
            get => logUser;
        }

        /// <summary> 属性：是否显示模拟运行总时间。 </summary>
        [Browsable(true)]
        [Description("显示所有相机模拟运行时间"), Category("VisionCommon")]
        public bool ShowAllSimulateTime
        {
            get => AllCameraElapsedTime.Visible;
            set
            {
                AllCameraElapsedTime.Visible = value;
            }
        }

        /// <summary> 属性：是否显示与PLC通信状态信息 </summary>
        [Browsable(true)]
        [Description("显示与PLC通信状态"), Category("VisionCommon")]
        public bool ShowPLCStatus
        {
            get => tsl_PLCStatus.Visible;
            set
            {
                tsl_PLCStatus.Visible = value;
            }
        }

        /// <summary> 属性：是否显示通信状态信息 </summary>
        [Browsable(true)]
        [Description("显示通信状态信息"), Category("VisionCommon")]
        public bool ShowCommStatus
        {
            get => tsl_CommStatus.Visible;
            set
            {
                tsl_CommStatus.Visible = value;
            }
        }

        /// <summary>
        /// 属性：设置软件版本
        /// </summary>
        public string SoftwareVersionText
        {
            set { tsl_SoftwareVersion.Text = value; }
        }

        ///// <summary>
        ///// 属性：设置运行状态
        ///// </summary>
        //public string RunStatus
        //{
        //    set { tsl_RunStatus.Text = value; }
        //}

        /// <summary>
        /// 属性：设置所有相机总耗时，支持在非界面线程调用。
        /// </summary>
        public string AllElapsedTime
        {
            set
            {
                if (InvokeRequired)
                    Invoke(new Action(() => { AllCameraElapsedTime.Text = $"☞所有相机运行总耗时:{value} ms"; }));
                else
                    AllCameraElapsedTime.Text = $"☞所有相机运行总耗时:{value} ms";
            }
        }

        /// <summary>
        /// 更新相机CT。
        /// </summary>
        /// <param name="elapsedTime">相机CT，采集图像+处理图像耗时。</param>
        /// <param name="cameraName">相机名称枚举。</param>
        /// <param name="camResult">相机检测结果。</param>
        public void UpdateCamCT(string elapsedTime, CameraName cameraName, string camResult)
        {
            if (InvokeRequired)
                Invoke(new Action<string, CameraName, string>(UpdateCamCT), elapsedTime, cameraName, camResult);
            else
            {
                switch (cameraName)
                {
                    case CameraName.相机1:
                        tsl_Cam1CT.Text = $"Cam1_CT:{elapsedTime}ms";
                        break;
                    case CameraName.相机2:
                        tsl_Cam2CT.Text = $"Cam2_CT:{elapsedTime}ms";
                        break;
                    case CameraName.相机3:
                        tsl_Cam3CT.Text = $"Cam3_CT:{elapsedTime}ms";
                        break;
                    case CameraName.相机4:
                        tsl_Cam4CTLabel.Text = $"Cam4_CT:{elapsedTime}ms";
                        break;
                }
            }
        }

        /// <summary> 更新与PLC通信状态。 </summary>
        /// <param name="info">更新信息。</param> 
        /// <param name="color">标签颜色。</param>
        public void UpdatePLCState(string info, Color color = default)
        {
            if (InvokeRequired)
                Invoke(new Action<string, Color>(UpdatePLCState), info, color);
            else
            {
                if (color != default)
                    tsl_PLCStatus.BackColor = color;
                tsl_PLCStatus.Text = info;
            }
        }

        /// <summary> 更新通信状态。 </summary>
        /// <param name="info">更新信息。</param> 
        /// <param name="color">标签颜色。</param>
        public void UpdateCommState(string info, Color color = default)
        {
            if (InvokeRequired)
                Invoke(new Action<string, Color>(UpdateCommState), info, color);
            else
            {
                if (color != default)
                    tsl_CommStatus.BackColor = color;
                tsl_CommStatus.Text = info;
            }
        }
    }
}
