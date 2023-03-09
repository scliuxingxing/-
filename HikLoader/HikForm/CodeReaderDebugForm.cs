using HikUnLoader.HikClass;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HikUnLoader.HikFrom
{
    /// <summary>
    /// 读码器调试窗体类
    /// </summary>
    public partial class CodeReaderDebugForm : Form
    {
        /// <summary>
        /// 读码器通讯串口
        /// </summary>
        private SerialPort codeReaderPort;

        public CodeReaderDebugForm()
        {
            InitializeComponent();

        }

        private void CodeReaderDebugForm_Load(object sender, EventArgs e)
        {
            InitializeCodeReaderPort();

        }

        /// <summary>
        /// 初始化并打开读码器通讯串口
        /// </summary>
        public void InitializeCodeReaderPort()
        {
            codeReaderPort = new SerialPort(Parameter.CodeReaderPort, 9600);
            if (codeReaderPort.IsOpen)
            {
                codeReaderPort.Close();
            }
            codeReaderPort.Open();
            GlobleModule.LogInfo = "读码器已连接";
            codeReaderPort.DataReceived += codeReaderPort_DataReceived;
        }

        List<byte> result = new List<byte>();

        /// <summary>
        /// 读码器串口收到数据时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeReaderPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            textBox1.Invoke(new Action(() => { textBox1.Text = "扫码中"; }));
            while (codeReaderPort.BytesToRead > 0)
            {
                int number = codeReaderPort.BytesToRead;
                byte[] buffer = new byte[number];
                codeReaderPort.Read(buffer, 0, number);
                result.AddRange(buffer);
                Thread.Sleep(50);
            }
            string s = Encoding.Default.GetString(result.ToArray());
            textBox1.Invoke(new Action(() => { textBox1.Text = s; }));
            result.Clear();


            //if (this.IsHandleCreated)
            //{
            //    textBox1.Invoke(new Action(() => { textBox1.Text = "扫码中"; }));
            //}

            //Thread.Sleep(100);

            //string s = sp.ReadExisting();
            ////如果读码器调试窗口存在，则显示读码器串口接收到的数据
            //if (this.IsHandleCreated)
            //{
            //    textBox1.Invoke(new Action(() => { textBox1.Text = s; }));
            //}
        }

        /// <summary>
        /// 触发读码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Read_Click(object sender, EventArgs e)
        {
            if (codeReaderPort.IsOpen)
            {
                textBox1.Invoke(new Action(() => { textBox1.Text = "扫码中"; }));
                codeReaderPort.DiscardInBuffer();
                codeReaderPort.Write(new byte[] { 0x01, 0x54, 0x04 }, 0, 3);
            }
            else
            {
                MessageBox.Show("读码器串口未打开");
            }

        }

        /// <summary>
        /// 窗体关闭时取消订阅事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeReaderDebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (codeReaderPort.IsOpen)
            {
                codeReaderPort.Close();
            }
            codeReaderPort.Dispose();
            GlobleModule.LogInfo = "释放读码器串口资源";
        }


    }
}
