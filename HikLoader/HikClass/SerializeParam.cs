using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikUnLoader.HikClass
{
    /// <summary>
    /// 文档参数类
    /// </summary>
    [Serializable]
    public class CommonParams : INotifyPropertyChanged
    {
        private CheckState _saveImageCheckState = CheckState.Unchecked;
        private bool _saveExcelData = false;
        private bool _showAllGraphics = false;
        private bool _showAllDatas = false;
        private bool _chechCameras = false;
        private bool _powerOnAtSelfStart = false;
        private string _imageFilePath = string.Empty;
        private string _nGImageFolder = string.Empty;
        private string _excelDataFolder = string.Empty;
        private int _maxSaveImageNum = 20;
        private bool _negativeCoplanarityIsZero = false;

        /// <summary>在组件上更改属性时引发事件 </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>属性：保存图像复选框状态</summary>
        public CheckState SaveImageCheckState { get => _saveImageCheckState; set { _saveImageCheckState = value; OnPropertyChanged("SaveImageCheckState"); } }
        /// <summary>属性：是否保存数据到Excel</summary>
        public bool SaveExcelData { get => _saveExcelData; set { _saveExcelData = value; OnPropertyChanged("SaveExcelData"); } }
        /// <summary>属性：是否显示所有图形</summary>
        public bool ShowAllGraphics { get => _showAllGraphics; set { _showAllGraphics = value; OnPropertyChanged("ShowAllGraphics"); } }
        /// <summary>属性：是否显示所有数据</summary>
        public bool ShowAllDatas { get => _showAllDatas; set { _showAllDatas = value; OnPropertyChanged("ShowAllDatas"); } }
        /// <summary>属性：是否持续侦测相机</summary>
        public bool ChechCameras { get => _chechCameras; set { _chechCameras = value; OnPropertyChanged("ChechCameras"); } }
        /// <summary>属性：是否开启自启动</summary>
        public bool PowerOnAtSelfStart { get => _powerOnAtSelfStart; set { _powerOnAtSelfStart = value; OnPropertyChanged("PowerOnAtSelfStart"); } }
        /// <summary>属性：文件取像路径 </summary>
        public string ImageFilePath { get => _imageFilePath; set { _imageFilePath = value; OnPropertyChanged("ImageFilePath"); } }
        /// <summary>属性：NG图像保存路径 </summary>
        public string NGImageFolder { get => _nGImageFolder; set { _nGImageFolder = value; OnPropertyChanged("NGImageFolder"); } }
        /// <summary>属性：EXCEL数据路径 </summary>
        public string ExcelDataFolder { get => _excelDataFolder; set { _excelDataFolder = value; OnPropertyChanged("ExcelDataFolder"); } }
        /// <summary>属性：保存最大图片数 </summary>
        public int MaxSaveImageNum { get => _maxSaveImageNum; set { _maxSaveImageNum = value; OnPropertyChanged("MaxSaveImageNum"); } }
        /// <summary> 属性：共面度负值是否取零 </summary>
        public bool NegativeCoplanarityIsZero { get => _negativeCoplanarityIsZero; set { _negativeCoplanarityIsZero = value; OnPropertyChanged("NegativeCoplanarityIsZero"); } }
        /// <summary>
        /// 引发属性更改事件
        /// </summary>
        /// <param name="propertyName">更改的属性名称</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// 文档参数类
    /// </summary>
    [Serializable]
    public class CameraData 
    {
        /// <summary>
        /// 相机1曝光时间
        /// </summary>
        public int Camera1ExposureTime;

        /// <summary>
        /// 相机1增益
        /// </summary>
        public int Camera1Gain;

        /// <summary>
        /// 相机1曝光时间
        /// </summary>
        public int Camera2ExposureTime;

        /// <summary>
        /// 相机1增益
        /// </summary>
        public int Camera2Gain;
    }

}
