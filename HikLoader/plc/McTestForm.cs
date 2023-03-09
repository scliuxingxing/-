using HikUnLoader.HikClass;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace HikUnLoader.plc
{
    /// <summary>
    /// McProtocolTcp测试窗体类。
    /// </summary>
    public partial class McProtocolTestForm : Form
    {
        TcpClient tcp = new TcpClient(); //定义连接

        /// <summary>
        /// 构造函数。
        /// </summary>
        public McProtocolTestForm() 
        {
            InitializeComponent();
            if (Parameter.PLCIP != null && Parameter.PLCPort != 0)
            {
                txt_CommunicationIP.Text = Parameter.PLCIP;
                nud_CommunicationPort.Value = Parameter.PLCPort;
            }
        }

        /// <summary>
        /// 建立链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConnectTcp_Click(object sender, EventArgs e)
        {
            try
            {
                tcp.Connect(txt_CommunicationIP.Text, Convert.ToInt32(nud_CommunicationPort.Value));
                if (tcp.Connected)
                {
                    AddText("连接成功");
                }
                else
                {
                    AddText("连接失败");
                }
            }
            catch
            {
                AddText("连接失败");
            }
            
        }

        /// <summary>
        /// 添加字符串到接收文件区域
        /// </summary>
        /// <param name="str">字符串内容</param>
        private void AddText(string str)
        {
            if (!txt_ReceiveData.InvokeRequired)
            {
                txt_ReceiveData.AppendText(str + "\r\n");
            }
            else
            {
                txt_ReceiveData.Invoke(new Action(() =>
                {
                    txt_ReceiveData.AppendText(str + "\r\n");
                }));
            }
        }

        /// <summary>
        /// 读取按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Read_Click(object sender, EventArgs e)
        {
            if (!tcp.Connected)
            {
                MessageBox.Show("请先连接网口");
                return;
            }

            string RD = "RD DM" + tb_Read.Text + ".U\r";
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "16位无符号")
                {
                    RD = "RD DM" + tb_Read.Text + ".U\r";
                }
                else if (comboBox1.SelectedItem.ToString() == "16位有符号")
                {
                    RD = "RD DM" + tb_Read.Text + ".S\r";
                }
                else if (comboBox1.SelectedItem.ToString() == "32位无符号")
                {
                    RD = "RD DM" + tb_Read.Text + ".D\r";
                }
                else if (comboBox1.SelectedItem.ToString() == "32位有符号")
                {
                    RD = "RD DM" + tb_Read.Text + ".L\r";
                }
            }
            if (SendMessage(RD) == ("E0\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0") || SendMessage(RD) == ("E1\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0") || SendMessage(RD) == "未返回数据")
            {
                AddText("发送失败：" + RD );
            }
            else
            {
                
                AddText("发送成功：" + RD );
                AddText( "接收成功：" + SendMessage(RD));
            }
        }

        /// <summary>
        /// 发送数据，返回结果
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        private string SendMessage(string mes)
        {
            try
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
            catch
            {
                return "发送失败";
            }
        }

        /// <summary>
        /// 写入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Writ_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tcp.Connected)
                {
                    MessageBox.Show("请先连接网口");
                    return;
                }
                string RD = "WR DM" + tb_DZ.Text + ".U " + tb_Data.Text + "\r";
                if (comboBox2.SelectedItem != null)
                {
                    if (comboBox2.SelectedItem.ToString() == "16位无符号")
                    {
                        RD = "WR DM" + tb_DZ.Text + ".U " + tb_Data.Text + "\r";
                    }
                    else if (comboBox2.SelectedItem.ToString() == "16位有符号")
                    {
                        RD = "WR DM" + tb_DZ.Text + ".S " + tb_Data.Text + "\r";
                    }
                    else if (comboBox2.SelectedItem.ToString() == "32位无符号")
                    {
                        RD = "WR DM" + tb_DZ.Text + ".D " + tb_Data.Text + "\r";
                    }
                    else if (comboBox2.SelectedItem.ToString() == "32位有符号")
                    {
                        RD = "WR DM" + tb_DZ.Text + ".L " + tb_Data.Text + "\r";
                    }
                    else if (comboBox2.SelectedItem.ToString() == "字符串")
                    {
                        StringConvert16(tb_Data.Text);
                        RD = "WRS DM" + tb_DZ.Text + ".H " + StringConvert16(tb_Data.Text) + "\r";
                    }
                }
                if (SendMessage(RD).Substring(0,2) == ("OK"))
                {
                    AddText("发送成功：" + RD);
                    AddText("接收成功：" + SendMessage(RD));
                }
                else
                {
                    AddText("发送失败：" + RD);

                }
            }
            catch
            {
                AddText("运行失败");
            }
        }

        /// <summary>
        /// 将字符串转化为16进制
        /// </summary>
        /// <returns></returns>
        private string StringConvert16(String _str)
        {
            try
            {
                _str = _str.Replace(" ", "");
                //将字符串转换成字节数组。
                byte[] buffer = Encoding.ASCII.GetBytes(_str);
                //定义一个string类型的变量，用于存储转换后的值。
                string result = string.Empty;
                if (_str.Length % 2 == 0)
                {
                    result = (_str.Length / 2).ToString()+" ";//需要先给寄存器数量
                }
                else
                {
                    result = (_str.Length / 2 + 1).ToString()+" ";//需要先给寄存器数量
                }
                for (int i = 0; i < buffer.Length; i++)
                {
                    //将每一个字节数组转换成16进制的字符串，以空格相隔开。
                    result += Convert.ToString(buffer[i], 16);
                    if (i % 2 == 1 && i != buffer.Length - 1)
                    {
                        result += " ";
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
                return "";
            }
        }

        private void McProtocolTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcp.Connected)
            {
                tcp.Close();
            }
        }

       
    }
}
