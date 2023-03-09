using ScaipMDAS;
using System;
using System.Threading;
using System.Windows.Forms;

namespace HikUnLoader
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //8CC8E95AD20ABA37  1
            //63CB29A113F5EA9E  2
            //D6635E4E20FBA642  3
            //7C42AA0C0B5D2CB8  4
            //5B8274BB77B815ED  5
            //B2C19590F2DCDDD5  大尺寸线
            if (HikClass.GlobleModule.CheckDeviceID("8CC8E95AD20ABA37", "63CB29A113F5EA9E", "D6635E4E20FBA642", "7C42AA0C0B5D2CB8", "5B8274BB77B815ED", "B2C19590F2DCDDD5", "DD1885AA25090E71"))
            {
                //设置应用程序如何响应未经处理的异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //当某个异常未被捕获时触发
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                //当线程中的某个异常未捕获时触发
                Application.ThreadException += Application_ThreadException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainFrom());
            }
        }

        /// <summary>
        /// 事件处理器：当某个异常未被捕获时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.Error("产生未被捕获的异常：" + e.ExceptionObject.ToString());
        }

        /// <summary>
        /// 事件处理器：当线程中的异常未捕获时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogHelper.Error("多线程中产生未被捕获的异常：" + Environment.NewLine + $"{ e.Exception.Message + Environment.NewLine + e.Exception.StackTrace + Environment.NewLine + e.Exception.TargetSite.ToString()}");
        }
    }
}
