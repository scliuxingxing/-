using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HikUnLoader.HikClass
{
    /// <summary>
    /// 类：封装WIN32 API函数
    /// </summary>
    public class Win32API
    {
        //Windows消息定义
        /// <summary>Windows消息：获取文本 </summary>
        public const int WM_GETTEXT = 0x000D;
        /// <summary>Windows消息：设置文本 </summary>
        public const int WM_SETTEXT = 0x000C;
        /// <summary>Windows消息：单击 </summary>
        public const int WM_CLICK = 0x00F5;
        /// <summary>Windows消息：显示窗口 </summary>
        public const int WM_SHOWWINDOW = 0x0018;
        /// <summary>Windows消息：自定义消息 </summary>
        public const int WM_USER = 0x0400;
        /// <summary>Windows消息：设置进度条新位置 </summary>
        public const int PBM_SETPOS = (WM_USER + 2);
        /// <summary>允许或者禁止窗口重绘消息 </summary>
        public const int WM_SETREDRAW = 0xB;

        /// <summary>
        /// 发送消息允许或禁止窗口重绘
        /// </summary>
        /// <param name="hwnd">控件或窗口句柄</param>
        /// <param name="wMsg">Windows消息</param>
        /// <param name="wParam">附加参数</param>
        /// <param name="lParam">未定义指针</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);

        /// <summary> 
        /// 获取窗体的句柄函数
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题名</param>
        /// <returns>返回句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 通过句柄，窗体显示函数
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="cmdShow">显示方式</param>
        /// <returns>返工成功与否</returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindowAsync", SetLastError = true)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        /// <summary>
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。 
        /// </summary>
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 获取当前焦点窗口句柄，返回值类型是IntPtr
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 可以对该窗口进行操作.比如,关闭该窗口或在该窗口隐藏，nCmdShow的含义(0:关闭窗口,1:正常大小显示窗口,2:最小化窗口,3:最大化窗口)
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        /// <summary>
        /// 获取窗口大小及位置:
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// 矩形结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary> 矩形左上角X坐标 </summary>
            public int Left;                             //最左坐标
            /// <summary> 矩形左上角Y坐标 </summary>
            public int Top;                             //最上坐标
            /// <summary> 矩形右下角X坐标 </summary>
            public int Right;                           //最右坐标
            /// <summary> 矩形右下角X坐标 </summary>
            public int Bottom;                          //最下坐标
        }

        /// <summary>
        /// 通过句柄获取窗口标题
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpString">指向接收文本的缓冲区的指针</param>
        /// <param name="nMaxCount">指定要保存在缓冲区内的字符的最大个数，其中包含NULL字符。如果文本超过界限，它就被截断</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 获取窗口类名 
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpString">存放窗口类名</param>
        /// <param name="nMaxCount">指定要保存在缓冲区内的字符的最大个数，其中包含NULL字符。如果文本超过界限，它就被截断</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 获取子窗口句柄，如未找到相符窗口，则返回零
        /// </summary>
        /// <param name="parentHandle">父窗口句柄，如果设置了hwndParent，则表示从这个hwndParent指向的父窗口中搜索子窗口，如果hwndParent为null ，则函数以桌面窗口为父窗口，查找桌面窗口的所有子窗口</param>
        /// <param name="childAfter">子窗口句柄，如果HwndChildAfter为NULL，查找从hwndParent的第一个子窗口开始。如果hwndParent 和 hwndChildAfter同时为NULL，则函数查找所有的顶层窗口及消息窗口</param>
        /// <param name="className">向一个指定了类名的空结束字符串</param>
        /// <param name="windowTitle">指向一个指定了窗口名（窗口标题）的空结束字符串。如果该参数为 NULL，则为所有窗口全匹配</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="Msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息特定信息</param>
        /// <param name="lParam">指定附加的消息特定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息</returns>
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam);

        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="Msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息特定信息</param>
        /// <param name="lParam">指定附加的消息特定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息</returns>
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hWnd, int Msg, Int32 wParam, Int32 lParam);
    }
}
