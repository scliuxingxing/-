using System.IO;
using System;
using System.Windows.Forms;
using System.Text;
using HikUnLoader.HikClass;

namespace HikUnLoader.HikControl
{
    /// <summary>
    /// 登陆用户枚举
    /// </summary>
    public enum LogUser
    {
        /// <summary>用户枚举：无用户，只有登录用户的权限</summary>
        无用户,
        /// <summary>用户枚举：操作员，有运行、停止及清除统计</summary>
        操作员,
        /// <summary>用户枚举：调试员，除修改密码之外的所有权限 </summary>
        调试员,
        /// <summary>用户枚举：管理员，所有权限</summary>
        管理员
    }

    /// <summary>
    /// 用户登录窗体类
    /// </summary>
    public partial class UserLoginForm : Form
    {
        /// <summary>
        /// 用户登录成功或失败 
        /// </summary>
        public bool LogInResult = false;

        /// <summary>
        /// 操作员密码，默认0
        /// </summary>
        public string OperatorPassword = "0";

        /// <summary>
        /// 调试员密码，默认1 
        /// </summary>
        public string DebugerPassword = "1";

        private readonly int formHeight1 = 152, formHeight2 = 254;

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserLoginForm()
        {
            InitializeComponent();
            //指定按回车键的焦点控件
            AcceptButton = UserLogIn;
            //指定按ESC键的控件
            CancelButton = ClosedForm;
        }

        /// <summary>
        /// 事件处理器：窗体加载时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPasswordFromFile();                //从磁盘文件读取操作员和调试员密码
                UserLogIn.Enabled = false;
                PasswordModfyBox.Visible = false;
                Height = formHeight1;
                PasswordModify.Text = "密码修改";
                PasswordModify.Visible = false;
                UserName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// 自动属性：获取当前用户
        /// </summary>
        public LogUser GetUserID { get; private set; } = LogUser.无用户;

        /// <summary>
        /// 事件处理器：账户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                switch (UserName.Text)
                {
                    case "操作员":
                        if (UserPassword.Text == OperatorPassword)
                        {
                            GetUserID = LogUser.操作员;
                            Close();
                        }
                        else { MessageBox.Show("输入密码错误，请重新输入", "警告"); }
                        break;
                    case "调试员":
                        if (UserPassword.Text == DebugerPassword)
                        {
                            GetUserID = LogUser.调试员;
                            Close();
                        }
                        else { MessageBox.Show("输入密码错误，请重新输入", "警告"); }
                        break;
                    case "管理员":
                        if (UserPassword.Text == "CommonDLL")
                        {
                            if(MessageBox.Show("是否重置操作员和调试员密码？","重置密码",MessageBoxButtons.YesNo)==DialogResult.Yes)
                            {
                                OperatorPassword = "0";
                                DebugerPassword = "1";
                            }
                            GetUserID = LogUser.管理员;
                            Close();
                        }
                        else { MessageBox.Show("输入密码错误，请重新输入", "警告"); }
                        break;
                    default:
                        MessageBox.Show("请选择登录用户！", "警告");
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// 事件处理器：密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PasswordModfyBox.Visible)
                {
                    PasswordModfyBox.Visible = true;
                    Height = formHeight2;
                    PasswordModify.Text = "隐藏修改";
                }
                else
                {
                    PasswordModfyBox.Visible = false;
                    Height = formHeight1;
                    PasswordModify.Text = "密码修改";
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// 事件处理器：密码修改确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmModify_Click(object sender, EventArgs e)
        {
            try
            {
                switch (UserName.Text)
                {
                    case "操作员":
                        if (UserPassword.Text != OperatorPassword) { MessageBox.Show("当前密码输入错误，请重新输入！", "警告"); }
                        else
                        {
                            if (NewPassword.Text != SecondPassword.Text) { MessageBox.Show("2次新密码输入不一致，请重新输入！", "警告"); }
                            else
                            {
                                OperatorPassword = NewPassword.Text;
                                MessageBox.Show("操作员密码修改成功", "提示");
                            }
                        }
                        break;
                    case "调试员":
                        if (UserPassword.Text != DebugerPassword) { MessageBox.Show("当前密码输入错误，请重新输入！", "警告"); }
                        else
                        {
                            if (NewPassword.Text != SecondPassword.Text) { MessageBox.Show("2次新密码输入不一致，请重新输入！", "警告"); }
                            else
                            {
                                DebugerPassword = NewPassword.Text;
                                MessageBox.Show("调试员密码修改成功", "提示");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// 事件处理器：用户名切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UserLogIn.Enabled = true;
                UserPassword.Text = "";
                if (UserName.Text != "管理员")
                {
                    PasswordModify.Visible = true;
                }
                else
                {
                    PasswordModfyBox.Visible = false;
                    PasswordModify.Visible = false;
                    Height = formHeight1;
                    PasswordModify.Text = "密码修改";
                }
            }
            catch (System.Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        ///  从磁盘文件读取操作员和调试员密码
        /// </summary>
        private void LoadPasswordFromFile()
        {
            //如果密码文件不存在，则使用默认密码
            if (!File.Exists(GlobleModule.ConfigFilePath))
            {
                OperatorPassword = "0";
                DebugerPassword = "1";
            }
            else
            {
                try
                {
                    string password = INIManager.IniReadValue("密码", "操作员", GlobleModule.ConfigFilePath);
                    OperatorPassword = (string.IsNullOrEmpty(password)) ? "0" : password;
                    password = INIManager.IniReadValue("密码", "调试员", GlobleModule.ConfigFilePath);
                    DebugerPassword = (string.IsNullOrEmpty(password)) ? "1" : password;
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        /// <summary>
        /// 保存操作员和调试员密码到磁盘文件
        /// </summary>
        private void SavePasswordToFile()
        {
            try
            {
                INIManager.IniWriteValue("密码", "操作员", OperatorPassword, GlobleModule.ConfigFilePath);
                INIManager.IniWriteValue("密码", "调试员", DebugerPassword, GlobleModule.ConfigFilePath);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// 事件处理器：窗体关闭后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosedForm_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        /// <summary>
        /// 事件处理器：窗体关闭时触发，保存操作员和调试员密码到磁盘文件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePasswordToFile();
        }

        /// <summary>
        /// 事件处理器：工具菜单帮助按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Click(object sender, EventArgs e)
        {
            StringBuilder tips = new StringBuilder();
            tips.Append("->操作员具备基本权限:" + Environment.NewLine + "打开关闭应用程序、启动与停止检测、用户登陆、查看帮助" + Environment.NewLine+ Environment.NewLine);
            tips.Append("->调试员增加以下权限:" + Environment.NewLine+"调试参数、实时图像显示、切换料号、使用调试工具"+Environment.NewLine+ Environment.NewLine);
            tips.Append("->管理增加以下权限:" + Environment.NewLine + "重置操作员和调试员登陆密码");
            MessageBox.Show(tips.ToString(),"用户权限",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示异常信息
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message+Environment.NewLine+ex.StackTrace, ex.TargetSite.ToString() + "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
