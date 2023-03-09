using HikUnLoader.HikClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HikUnLoader.HikControl
{
    /// <summary>
    /// 料号编辑窗体类
    /// </summary>
    public partial class ProductEditor : Form
    {
        private string currentProduct = string.Empty;

        /// <summary>
        /// 料号列表
        /// </summary>
        private List<string> list_ProductNames = new List<string>();

        /// <summary>
        /// 属性：获取当前料号名称字符串 
        /// </summary>
        public string GetCurrentProduct
        {
            get { return currentProduct; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public ProductEditor()
        {
            InitializeComponent();
            list_ProductNames = GlobleModule.InquirePath(GlobleModule.ParaPath);
        }

        /// <summary>
        /// 事件：窗体加载时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductEditor_Load(object sender, EventArgs e)
        {
            RefreshProductComboBox();
            RefreshPath();
        }

        private void AddName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char[] illegalCharacter = { '>', '<', '?', '|', ':', '"', '*' };
                foreach (char item in illegalCharacter)
                {
                    if (e.KeyChar.Equals(item))
                    {
                        MessageBox.Show("请勿输入非法字符！", "非法字符", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        text_AddProductName.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
        }

        /// <summary>
        /// 事件：新增料号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_AddProductName.Text == string.Empty)
                {
                    MessageBox.Show("料号名称不能为空");
                    return;
                }

                if (!text_AddProductName.Text.Contains("-"))
                {
                    MessageBox.Show("新增料号格式错误,正确格式为：数字-xxxx");
                    return;
                }

                int number;
                bool result = int.TryParse(text_AddProductName.Text.Substring(0, text_AddProductName.Text.IndexOf('-')), out number);
                if (!result)
                {
                    MessageBox.Show("新增料号格式错误,正确格式为：数字-xxxx");
                    return;
                }

                foreach (string item in list_ProductNames)
                {
                    int tempNumber;
                    bool tempResult = int.TryParse(item.Substring(0, item.IndexOf('-')), out tempNumber);
                    if (!tempResult)
                    {
                        continue;
                    }
                    if (number == tempNumber)
                    {
                        MessageBox.Show("料号编号已存在，请重新输入！");
                        return;
                    }
                }
                Directory.CreateDirectory(GlobleModule.ParaPath + "\\" + text_AddProductName.Text);

                string source = GlobleModule.ParaPath + "\\" + ComboBox_ProductChoose.SelectedItem.ToString();
                string dest = GlobleModule.ParaPath + "\\" + text_AddProductName.Text;
                bool isOK = CopyFolder(source, dest);
                if (!isOK)
                {
                    MessageBox.Show("增加料号失败！！！");
                    return;
                }
                list_ProductNames = GlobleModule.InquirePath(GlobleModule.ParaPath);
                RefreshProductComboBox();
                text_AddProductName.Text = string.Empty;

                MessageBox.Show("增加料号文件夹成功!!!", "操作完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
        }

        /// <summary>
        /// 复制文件夹及文件
        /// </summary>
        /// <param name="sourceFolder">原文件路径</param>
        /// <param name="destFolder">目标文件路径</param>
        /// <returns></returns>
        public static bool CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                //如果目标路径不存在,则创建目标路径
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                //得到原文件根目录下的所有文件
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest);//复制文件
                }
                //得到原文件根目录下的所有文件夹
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyFolder(folder, dest);//构建目标路径,递归复制文件
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("复制料号产生异常");
                return false;
            }
        }

        /// <summary>
        /// 从Para文件夹刷新现有的料号文件夹，并更新列表
        /// </summary>
        public void RefreshProductComboBox()
        {
            try
            {
                if (list_ProductNames.Count == 0) { return; }
                ComboBox_ProductChoose.Items.Clear();
                foreach (string item in list_ProductNames)
                {
                    if (item != null)
                    {
                        ComboBox_ProductChoose.Items.Add(item);
                    }
                }
                currentProduct = INIManager.IniReadValue("当前产品", "产品名称", GlobleModule.ConfigFilePath);

                if (currentProduct != string.Empty && list_ProductNames.Contains(currentProduct))
                {
                    ComboBox_ProductChoose.SelectedItem = currentProduct;
                }
                else
                {
                    ComboBox_ProductChoose.SelectedItem = ComboBox_ProductChoose.Items[0];
                    currentProduct = ComboBox_ProductChoose.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
        }

        /// <summary>
        /// 加载文件路径
        /// </summary>
        private void RefreshPath()
        {
            if (string.IsNullOrEmpty(currentProduct)) { return; }
        }

        /// <summary>
        /// 事件：删除料号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (list_ProductNames.Count == 0) { return; }
                if (MessageBox.Show("请确认是否要删除当前选中的料号！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Directory.Delete(GlobleModule.ParaPath + "\\" + ComboBox_ProductChoose.SelectedItem, true);

                    list_ProductNames.Clear();
                    list_ProductNames = GlobleModule.InquirePath(GlobleModule.ParaPath);
                    RefreshProductComboBox();

                    MessageBox.Show("已删除料号！", "操作完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
        }

        /// <summary>
        /// 事件：窗体关闭时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (ComboBox_ProductChoose.Items.Count > 0 && ComboBox_ProductChoose.SelectedItem != null)
                {
                    //currentProduct = ComboBox_ProductChoose.SelectedItem.ToString();
                    //INIManager.IniWriteValue("当前产品", "产品名称", currentProduct, GlobleModule.ConfigFilePath);
                }
                RefreshPath();
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
        }

        /// <summary>
        /// 事件：窗体关闭后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseForm_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 事件：进入料号文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_GoToProductFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobleModule.ParaPath);
            }
            catch (Exception)
            {
                GlobleModule.LogInfo = "不能进入料号文件夹，请检查文件路径。";
            }
        }
    }
}
