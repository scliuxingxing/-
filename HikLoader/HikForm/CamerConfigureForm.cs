using ImageSourceModuleCs;
using System;
using System.Windows.Forms;
using VM.Core;

namespace HikUnLoader.HikFrom
{
    /// <summary>
    /// 相机配置窗体类
    /// </summary>
    public partial class CamerConfigureForm : Form
    {
        /// <summary> 图像源工具 </summary>
        private ImageSourceModuleTool imageTool;

        /// <summary>
        /// 相机配置窗体
        /// </summary>
        /// <param name="vmProcedure">流程</param>
        public CamerConfigureForm(VmProcedure vmProcedure)
        {
            InitializeComponent();
            if (vmProcedure.Modules[0] is ImageSourceModuleTool)
            {
                imageTool = (ImageSourceModuleTool)vmProcedure.Modules[0];
                vmDebugControl.ModuleSource = imageTool;
            }
        }


        /// <summary>
        /// 窗体关闭事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CamerPZ_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (imageTool.ModuParams.ImageSourceType != ImageSourceParam.ImageSourceTypeEnum.Camera)
            {
                if (MessageBox.Show("是否要关闭窗体？" + Environment.NewLine + "图像源不是从相机获取图像，这会造成程序无法运行！", "关闭应用程序?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                string cameraID = null;
                imageTool.ModuParams.GetParamValue("cameraID", ref cameraID);
                if (cameraID == null)
                {
                    if (MessageBox.Show("是否要关闭窗体？" + Environment.NewLine + "图像源未配置相机，这会导致程序无法运行！", "关闭应用程序?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {

                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }

        }
    }
}
