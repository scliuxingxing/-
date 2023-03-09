using HikUnLoader.HikClass;
using System;
using System.Windows.Forms;

namespace HikUnLoader.HikControl
{
    /// <summary>
    /// 文档参数类
    /// </summary>
    public partial class DocumentParameter : UserControl, IParamsControl
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public DocumentParameter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 属性：获取文档参数
        /// </summary>
        public CommonParams DocumentParams { get; private set; } = null;

        /// <summary>
        /// 从文件加载文档参数
        /// </summary>
        public void LoadDocData()
        {
            try
            {
                MainBox.Enabled = false;

                DocumentParams = GlobleModule.XmlDeserializer<CommonParams>(GlobleModule.CurrentSerializePath, "DocumentParameters.xml");
                if (DocumentParams == null)
                {
                    DocumentParams = new CommonParams();
                }
                GlobleModule.DocumentParams = DocumentParams;

                //删除以前的数据绑定
                textBox_DataSavePath.DataBindings.Clear();
                textBox_ImageSavePath.DataBindings.Clear();
                checkBox_DataSaveMode.DataBindings.Clear();
                checkbox_ImageSaveMode.DataBindings.Clear();
                nud_MaxSaveImage.DataBindings.Clear();

                //绑定新的数据源
                textBox_DataSavePath.DataBindings.Add("Text", DocumentParams, "ExcelDataFolder", false, DataSourceUpdateMode.OnPropertyChanged);
                textBox_ImageSavePath.DataBindings.Add("Text", DocumentParams, "NGImageFolder", false, DataSourceUpdateMode.OnPropertyChanged);
                checkBox_DataSaveMode.DataBindings.Add("Checked", DocumentParams, "SaveExcelData", false, DataSourceUpdateMode.OnPropertyChanged);
                checkbox_ImageSaveMode.DataBindings.Add("CheckState", DocumentParams, "SaveImageCheckState", false, DataSourceUpdateMode.OnPropertyChanged);
                nud_MaxSaveImage.DataBindings.Add("Value", DocumentParams, "MaxSaveImageNum", false, DataSourceUpdateMode.OnPropertyChanged);

                MainBox.Enabled = true;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 保存文档参数到文件
        /// </summary>
        public void SaveDocData()
        {
            try
            {
                MainBox.Enabled = false;
                GlobleModule.XmlSerializer(DocumentParams, GlobleModule.CurrentSerializePath, "DocumentParameters.xml");
                MainBox.Enabled = true;
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 事件处理器：选择数据保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChooseDataSavePath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    textBox_DataSavePath.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 事件处理器：选择图片保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChoosImageSavePath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    textBox_ImageSavePath.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 事件处理器：数据保存模式选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_DataSaveMode_CheckedStateChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 事件处理器：图片保存模式选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkbox_ImageSaveMode_CheckedStateChanged(object sender, EventArgs e)
        {
            switch (checkbox_ImageSaveMode.CheckState)
            {
                case CheckState.Unchecked:
                    checkbox_ImageSaveMode.Text = "不保存图像";
                    break;
                case CheckState.Checked:
                    checkbox_ImageSaveMode.Text = "保存所有图像";
                    break;
                case CheckState.Indeterminate:
                    checkbox_ImageSaveMode.Text = "仅保存NG图像";
                    break;
            }

        }


    }
}
