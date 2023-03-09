using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HikUnLoader.HikClass;

namespace HikUnLoader.HikFrom
{
    /// <summary>
    /// 进度条加载显示窗体类
    /// </summary>
    public partial class ProgressLoadingDisplayForm : Form
    {
        private string loadInfo = string.Empty;
        private bool direction;
        /// <summary>
        /// 此窗体的句柄
        /// </summary>
        private static  IntPtr progressFormHandle = IntPtr.Zero;
        /// <summary>
        /// 进度条背景框句柄
        /// </summary>
        private static  IntPtr progressLabelHandle = IntPtr.Zero;
        /// <summary>
        /// 进度条句柄
        /// </summary>
        private static  IntPtr progressBarHandle = IntPtr.Zero;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ProgressLoadingDisplayForm(string projectText = "", string companyText = "")
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            ProgressLabel.BackColor = Color.Transparent;
            //获取窗口及控件句柄
            progressFormHandle = Handle;
            progressLabelHandle = ProgressLabel.Handle;
            progressBarHandle = LoadProgressBar.Handle;

            if (!string.IsNullOrEmpty(projectText))
            {
                ProjectLabel.Text = projectText;
            }

            if (!string.IsNullOrEmpty(companyText))
            {
                CompanyLabel.Text = companyText;
            }


            //将此控件放置到所有控件的最顶层
            this.BringToFront();
            //his.TopMost = true;
        }

        /// <summary>
        /// 进度条标题信息
        /// </summary>
        public string SetLoadInfo
        {
            set
            {
                loadInfo = value;
                LoadLabel.Text = loadInfo;
            }
        }

        /// <summary>
        /// 设置进度条信息
        /// </summary>
        /// <param name="info">显示信息</param>
        /// <param name="progress">显示进度</param>
        public void SetProgressInfo(string info,int? progress)
        {
            if (info != null)
            {
                ProgressLabel.Text = info;
                ProgressLabel.Refresh();
            }
            if (progress != null)
            {
                LoadProgressBar.Value = progress.Value;
                LoadProgressBar.Refresh();
            }
            Application.DoEvents();
        }

        /// <summary>
        /// 显示进度框
        /// </summary>
        public void ShowProgressForm(int ProgressMax)
        {
            LoadProgressBar.Maximum = ProgressMax;
            LoadProgressBar.Value = 0;
            Text = "ProgressShow";
            StartPosition = FormStartPosition.CenterScreen;
            Show();
            Application.DoEvents();
        }

        /// <summary>
        /// 关闭进度框
        /// </summary>
        public void CloseProgressForm()
        {
            progressFormHandle = IntPtr.Zero;
            progressLabelHandle = IntPtr.Zero;
            progressBarHandle = IntPtr.Zero;
            Close();
        }

        /// <summary>
        /// 刷新进度条
        /// </summary>
        public void RefreshProgress()
        {
            if (!direction)
            {
                LoadProgressBar.Value++;
                if (LoadProgressBar.Value == LoadProgressBar.Maximum)
                {
                    direction = true;
                    Thread.Sleep(200);
                }
            }
            if (direction)
            {
                LoadProgressBar.Value--;
                    if (LoadProgressBar.Value == 0)
                    {
                        direction = false;
                        Thread.Sleep(200);
                    }
            }
        }

        //用spy++工具得到以下信息
        //WindowsForms10.msctls_progress32.app.0.141b42a_r8_ad1   进度条类名
        //WindowsForms10.STATIC.app.0.141b42a_r8_ad1   进度条标签类名
        //WindowsForms10.msctls_progress32.app.0.141b42a_r8_ad1   进度条类名
        //WindowsForms10.msctls_progress32.app.0.141b42a_r6_ad1

        /// <summary>
        /// 获取进度条标签和进度条控件句柄,弃用
        /// </summary>
        public static void GetProgressHandle()
        {
            //等待进度窗口打开
            Thread.Sleep(1000);
            progressFormHandle = Win32API.FindWindow(null, "ProgressShow");
            if (!progressFormHandle.Equals(IntPtr.Zero))
            {

                progressLabelHandle = Win32API.FindWindowEx(progressFormHandle, IntPtr.Zero, "WindowsForms10.STATIC.app.0.141b42a_r8_ad1", null);
                progressBarHandle = Win32API.FindWindowEx(progressFormHandle, IntPtr.Zero, "WindowsForms10.msctls_progress32.app.0.141b42a_r8_ad1", null);
            }
            else
            {
                progressLabelHandle = IntPtr.Zero;
                progressBarHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// 发送消息到进度条标签和进度条控件
        /// </summary>
        /// <param name="message">进度条标签信息</param>
        /// <param name="progress">进度条进度</param>
        public static void SendMessage(string message,int? progress)
        {
            try
            {
                if(progressLabelHandle!=IntPtr.Zero&&message!=null) Win32API.SendMessage(progressLabelHandle, Win32API.WM_SETTEXT, IntPtr.Zero, new StringBuilder(message));
                if (progressBarHandle != IntPtr.Zero&&progress!=null) Win32API.SendMessage(progressBarHandle, Win32API.PBM_SETPOS, progress.Value, 0);
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }
    }
}
