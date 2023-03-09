
using HikUnLoader.HikControl;
using HikUnLoader.plc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace HikUnLoader.HikClass
{
    /// <summary>
    /// 接口：参数控件接口
    /// </summary>
    public interface IParamsControl
    {
        /// <summary>从文件读取参数 </summary>
        void LoadDocData();
        /// <summary>保存参数到文件 </summary>
        void SaveDocData();
    }

    /// <summary>全局静态类，定义全局性的静态变量和方法</summary>
    public static class GlobleModule
    {
        /// <summary>制表符,在Excel中表示换列 </summary>
        public const string TabChar = "\t";
        /// <summary>是否以管理员权限登录 </summary>
        public static bool IsAdministrater = CheckWindowsUser();
        /// <summary>互斥锁，用于限定只能启动一个应用程序的实例 </summary>
        public static Mutex Run;

        /// <summary>Para文件夹路径 </summary>
        public static string ParaPath = string.Empty;
        /// <summary>公共参数位于...\Para\Common文件夹中 </summary>
        public static string CommonPath = string.Empty;
        /// <summary>静态字段：配置文件config.ini路径 </summary>
        public static string ConfigFilePath = string.Empty;
        /// <summary>当前料号名称 </summary>
        public static string CurrentProduct = string.Empty;
        /// <summary>当前产品文件夹路径</summary>
        private static string currentProductPath;
        /// <summary>当前料号序列化参数文件夹路径 </summary>
        public static string CurrentSerializePath;
        /// <summary>当前产品vpp文件夹路径 </summary>
        public static string CurrentVppPath;
        /// <summary>主选项卡当前页面名称 </summary>
        public static string CurrentPage = string.Empty;

        /// <summary>文件参数实例引用 </summary> 
        public static CommonParams DocumentParams = null;
        /// <summary> 共面度为负值是否取零 </summary>
        public static bool NegativeCoplanarityIsZero = false;

        //序列化与反序列化
        private static SoapFormatter StreamOfSoap = new SoapFormatter();
        /// <summary>文本流，写入报警信息 </summary> 
        public static StreamWriter ExceptionWriter = null;
        /// <summary>记录当前写入报警日期 </summary> 
        private static string DateTime = string.Empty;
        private static int DateCount = 0;
        /// <summary>异常信息是否写入文件</summary>
        public static bool ExInfoWriteToFile = false;

        /// <summary>刷新的日志区 </summary>
        public static MultiCameraShow mc_Info;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static GlobleModule()
        {
            string exePath = Application.ExecutablePath;
            DirectoryInfo directoryInfo = new DirectoryInfo(exePath);

            ParaPath = directoryInfo.Parent.Parent.FullName + "\\Para";

            CommonPath = ParaPath + "\\Common";
            ConfigFilePath = CommonPath + "\\config.ini";
        }

        /// <summary>
        /// 静态属性：设置当前产品文件夹路径
        /// </summary>
        public static string CurrentProductPath
        {
            get => currentProductPath;
            set
            {
                currentProductPath = value;
                CurrentSerializePath = currentProductPath + "\\Serialize";
                CurrentVppPath = currentProductPath + "\\vpp";

                if (ExInfoWriteToFile)
                {
                    if (ExceptionWriter != null)
                        ExceptionWriter.Close();
                    ExceptionWriter = new StreamWriter($"{CurrentSerializePath}\\ExceptionMessages.txt", true, Encoding.GetEncoding("GB2312"))
                    {
                        AutoFlush = true
                    };
                }

                Debug.Listeners.Clear();
                Debug.Listeners.Add(new TextWriterTraceListener(@"C:\Users\jessm\Desktop\程序日志.txt"));
                Debug.AutoFlush = true;
            }
        }

        /// <summary>
        /// 异常显示，便于统一更改显示方式
        /// </summary>
        /// <param name="ex">异常信息类</param>
        public static void ShowException(Exception ex)
        {
            if (ExceptionWriter != null)
            {
                lock (ExceptionWriter)
                {
                    if (!DateTime.Equals(System.DateTime.Now.ToString("D")))
                    {
                        //如果保存异常信息超过3天，则删除文件，只保存最近3天的异常信息
                        if (++DateCount >= 3)
                        {
                            ExceptionWriter?.Close();
                            string filePath = $"{CurrentSerializePath}\\ExceptionMessages.txt";
                            FileInfo fileInfo = new FileInfo(filePath);
                            if (fileInfo.Exists)
                                fileInfo.Delete();
                            ExceptionWriter = new StreamWriter(filePath, true, Encoding.GetEncoding("GB2312"))
                            {
                                AutoFlush = true
                            };
                        }
                        DateTime = System.DateTime.Now.ToString("D");
                        ExceptionWriter.Write($"->{DateTime}<-{ExceptionWriter.NewLine}{ExceptionWriter.NewLine}");
                    }
                    ExceptionWriter.Write($"{System.DateTime.Now.ToString("T")}{ExceptionWriter.NewLine}");
                    ExceptionWriter.Write($"{ex.TargetSite.ToString()}:{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}{Environment.NewLine}");
                }
            }
            else
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", ex.TargetSite.ToString() + "发生异常");
        }

        /// <summary>
        /// 将调试信息写入主窗体DebugInfo中
        /// </summary>
        /// <param name="info"></param>
        /// <param name="additionalInfo"></param>
        /// <param name="InfoBox"></param>
        public static void WriteToDebugInfo(string info, string additionalInfo, ref TextBox InfoBox)
        {
            if (info != "")
            {
                string addInfo;
                if (additionalInfo != "") addInfo = Environment.NewLine + additionalInfo + Environment.NewLine + info;
                else addInfo = Environment.NewLine + info;
                InfoBox.Text += addInfo;
            }
        }

        /// <summary>
        /// 泛型序列化到文件
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="serialObject">序列化对象</param>
        /// <param name="serializePath">序列化文件夹路径</param>
        /// <param name="fileName">文件名</param>
        public static void XmlSerializer<T>(T serialObject, string serializePath, string fileName) where T : class
        {
            try
            {
                if (serialObject == null || string.IsNullOrEmpty(serializePath) || string.IsNullOrEmpty(fileName))
                { return; }
                //XmlSerializerNamespaces 包含的 XML 命名空间必须符合称为的 www.w3.org 规范，XML 命名空间
                //而XmlQualifiedName.Empty表示无XML限定名
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                //初始化 XmlSerializer 类的新实例，该类可以将指定类型的对象序列化为 XML 文档
                //也可以将 XML 文档反序列化为指定类型的对象。（应用程序通常定义若干类，XmlSerializer 将这些类转换为单个 XML 实例文档。
                //但是，XmlSerializer 只需知道一种类型，即表示 XML 根元素的类的类型。 XmlSerializer 自动序列化所有从属类的实例。 
                //同样，反序列化仅需要 XML 根元素的类型）
                var serializer = new XmlSerializer(serialObject.GetType());
                //使用XmlWriterSettings实例对象进行生成的XML的设置。如是否缩进文本、缩进量、每个节点一行等配置
                //（另：XmlReaderSettings代替XmlValidatingReader可用于XML验证）。
                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    WriteEndDocumentOnClose = true
                };
                //如果文件目录不存在，则创建目录
                if (!Directory.Exists(serializePath))
                    Directory.CreateDirectory(serializePath);

                using (var writer = XmlWriter.Create(serializePath + "\\" + fileName + ".xml", settings))
                {
                    serializer.Serialize(writer, serialObject, emptyNamepsaces);
                }
            }
            catch (Exception)
            {
                //ShowExceptionMessage(ex);
            }
        }

        /// <summary>
        /// 泛型反序列化
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="serializePath">序列化文件夹路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static T XmlDeserializer<T>(string serializePath, string fileName) where T : class
        {
            if (string.IsNullOrEmpty(serializePath) || string.IsNullOrEmpty(fileName))
                return null;
            string filePath = $"{serializePath}\\{fileName}.xml";
            if (File.Exists(filePath))
            {
                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(T));
                        return (T)xmlSerializer.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
            return null;
        }

        /// <summary>
        /// 泛型序列化到文件，针对结构体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="serialObject">序列化对象</param>
        /// <param name="serializePath">序列化文件夹路径</param>
        /// <param name="fileName">文件名</param>
        public static void XmlSerializer_<T>(T serialObject, string serializePath, string fileName) where T : struct
        {
            try
            {
                if (string.IsNullOrEmpty(serializePath) || string.IsNullOrEmpty(fileName))
                    return;
                //XmlSerializerNamespaces 包含的 XML 命名空间必须符合称为的 www.w3.org 规范，XML 命名空间
                //而XmlQualifiedName.Empty表示无XML限定名
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                //初始化 XmlSerializer 类的新实例，该类可以将指定类型的对象序列化为 XML 文档
                //也可以将 XML 文档反序列化为指定类型的对象。（应用程序通常定义若干类，XmlSerializer 将这些类转换为单个 XML 实例文档。
                //但是，XmlSerializer 只需知道一种类型，即表示 XML 根元素的类的类型。 XmlSerializer 自动序列化所有从属类的实例。 
                //同样，反序列化仅需要 XML 根元素的类型）
                var serializer = new XmlSerializer(serialObject.GetType());
                //使用XmlWriterSettings实例对象进行生成的XML的设置。如是否缩进文本、缩进量、每个节点一行等配置
                //（另：XmlReaderSettings代替XmlValidatingReader可用于XML验证）。
                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    WriteEndDocumentOnClose = true
                };
                using (var writer = XmlWriter.Create(serializePath + "\\" + fileName + ".xml", settings))
                {
                    serializer.Serialize(writer, serialObject, emptyNamepsaces);
                }
            }
            catch (Exception)
            {
                //ShowExceptionMessage(ex);
            }
        }

        /// <summary>
        /// 泛型反序列化,针对结构体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="serializePath">序列化文件夹路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static T XmlDeserializer_<T>(string serializePath, string fileName) where T : struct
        {
            if (string.IsNullOrEmpty(serializePath) || string.IsNullOrEmpty(fileName))
                return new T();
            string filePath = $"{serializePath}\\{fileName}.xml";
            if (File.Exists(filePath))
            {
                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(T));
                        return (T)xmlSerializer.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
            return new T();
        }

        /// <summary>
        /// 将类序列化到指定路径的文件中
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileName">文件名</param>
        /// <param name="WriteObject">要被序列化的对象</param>
        public static void SoapSerializer<T>(string FilePath, string FileName, T WriteObject)
        {
            if (WriteObject == null || string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(FileName))
                return;
            using (FileStream StreamWriteOfSoap = new FileStream($"{FilePath}\\{FileName}.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                try
                {
                    StreamOfSoap.Serialize(StreamWriteOfSoap, WriteObject); //将WriteFromClass序列化到对应路径的xml文件中
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        /// <summary>
        /// 从指定路径的文件中反序列化数据到类中
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileName">序列化文件名</param>
        /// <returns></returns>
        public static T SoapDeserializer<T>(string FilePath, string FileName) where T : new()
        {
            if (string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(FileName))
                return new T();
            string pathOfXml = $"{FilePath}\\{FileName}.xml";
            if (File.Exists(pathOfXml))
            {
                using (FileStream StreamReadOfSoap = new FileStream(pathOfXml, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        if (StreamReadOfSoap.Length > 0)
                            return (T)StreamOfSoap.Deserialize(StreamReadOfSoap);
                    }
                    catch (Exception ex)
                    {
                        ShowException(ex);
                    }
                }
            }
            return new T();
        }

        /// <summary>
        /// DataGridView序列化到文件
        /// </summary>
        /// <param name="gridView">数据表引用</param>
        /// <param name="fileName">文件名</param>
        public static void DataGridViewSerializeXml(ref DataGridView gridView, string fileName)
        {
            if (gridView == null || string.IsNullOrEmpty(fileName))
                return;
            List<string> data = new List<string>
            {
                gridView.RowCount.ToString(),
                gridView.ColumnCount.ToString()
            };
            for (int i = 0; i < gridView.RowCount; i++)
            {
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    if (gridView[j, i].Value != null)
                        data.Add(gridView[j, i].Value.ToString());
                    else
                        data.Add("0");
                }
            }
            XmlSerializer(data, CurrentSerializePath, fileName);
        }

        /// <summary>
        /// 从文件反序列化表格数据
        /// </summary>
        /// <param name="gridView">数据表格引用</param>
        /// <param name="topLeftText">表格左上角文本</param>
        /// <param name="rowHeaderTexts">列首字符串</param>
        /// <param name="colHeaderTexts">行首字符串</param>
        /// <param name="fileName">文件名</param>
        /// <param name="readOnly">是否调整父控件尺寸，默认是调整控件自身尺寸</param>
        /// <param name="resizeParentSize">是否调整父控件尺寸，默认是调整控件自身尺寸</param>
        public static int DataGridViewInitialize(ref DataGridView gridView, string topLeftText, List<string> rowHeaderTexts, List<string> colHeaderTexts, string fileName, bool readOnly = false, bool resizeParentSize = false)
        {
            if (gridView == null || string.IsNullOrEmpty(fileName))
                return 0;
            if (rowHeaderTexts == null)
            {
                MessageBox.Show($"数据表格{gridView.Name}行首字符串数组不能为null");
                return 0;
            }
            else if (colHeaderTexts == null)
            {
                MessageBox.Show($"数据表格{gridView.Name}列首字符串数组不能为null");
                return 0;
            }

            gridView.Rows.Clear();                                     //清空行
            gridView.Columns.Clear();

            gridView.ColumnCount = colHeaderTexts.Count;
            gridView.AllowUserToOrderColumns = false;
            gridView.AllowUserToResizeColumns = false;
            gridView.AllowUserToResizeRows = false;
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;

            for (int i = 0; i < rowHeaderTexts.Count; i++)
            {
                gridView.Rows.Add();
                gridView.Rows[i].Height = 25;
                gridView.Rows[i].HeaderCell.Value = rowHeaderTexts[i];  //动态增加列表框行，并将rowHeaderText集合中的行首字符串写入行首
            }

            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;                 //可自动调整列宽
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;     //可调整行首宽度
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;   //可调整列宽
            gridView.TopLeftHeaderCell.Value = topLeftText;
            gridView.RowHeadersWidth = 150;
            if (colHeaderTexts[0].Contains("\n"))
                gridView.ColumnHeadersHeight = 40;
            else
                gridView.ColumnHeadersHeight = 20;

            gridView.TopLeftHeaderCell.Value = topLeftText;

            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                gridView.Columns[i].HeaderText = colHeaderTexts[i];
                gridView.Columns[i].ReadOnly = readOnly;
            }

            string path = CurrentSerializePath + "\\" + fileName + ".xml";

            int index = 2;
            var data = XmlDeserializer<List<string>>(CurrentSerializePath, fileName);
            if (data != null)
            {
                if (gridView.RowCount == Convert.ToInt32(data[0]) && gridView.ColumnCount == Convert.ToInt32(data[1]))
                {
                    for (int rowIndex = 0; rowIndex < Convert.ToInt32(data[0]); rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < Convert.ToInt32(data[1]); colIndex++)
                        {
                            gridView[colIndex, rowIndex].Value = data[index++];
                        }
                    }
                }
                else
                {
                    for (int rowIndex = 0; rowIndex < gridView.RowCount; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < gridView.ColumnCount; colIndex++)
                        {
                            gridView[colIndex, rowIndex].Value = 0;
                        }
                    }
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < gridView.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < gridView.ColumnCount; colIndex++)
                    {
                        gridView[colIndex, rowIndex].Value = 0;
                    }
                }
            }

            //计算数据表格的高度
            int height = gridView.ColumnHeadersHeight;
            for (int i = 0; i < gridView.RowCount; i++)
            {
                height += gridView.Rows[i].Height;
            }
            return height;
        }

        /// <summary>
        /// 从文件反序列化表格数据
        /// </summary>
        /// <param name="gridView">数据表格引用</param>
        /// <param name="topLeftText">表格左上角文本</param>
        /// <param name="rowHeaderTexts">列首字符串</param>
        /// <param name="colHeaderTexts">行首字符串</param>
        /// <param name="fileName">文件名</param>
        /// <param name="readOnly">是否调整父控件尺寸，默认是调整控件自身尺寸</param>
        /// <param name="resizeParentSize">是否调整父控件尺寸，默认是调整控件自身尺寸</param>
        public static int DataGridViewInitialize(ref DataGridView gridView, string topLeftText, List<string> rowHeaderTexts, string[] colHeaderTexts, string fileName, bool readOnly = false, bool resizeParentSize = false)
        {
            if (gridView == null || string.IsNullOrEmpty(fileName))
                return 0;
            if (rowHeaderTexts == null)
            {
                MessageBox.Show($"数据表格{gridView.Name}行首字符串数组不能为null");
                return 0;
            }
            else if (colHeaderTexts == null)
            {
                MessageBox.Show($"数据表格{gridView.Name}列首字符串数组不能为null");
                return 0;
            }

            gridView.Rows.Clear();                                     //清空行
            gridView.Columns.Clear();

            gridView.ColumnCount = colHeaderTexts.Length;
            gridView.AllowUserToOrderColumns = false;
            gridView.AllowUserToResizeColumns = false;
            gridView.AllowUserToResizeRows = false;
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;

            for (int i = 0; i < rowHeaderTexts.Count; i++)
            {
                gridView.Rows.Add();
                gridView.Rows[i].Height = 25;
                gridView.Rows[i].HeaderCell.Value = rowHeaderTexts[i];  //动态增加列表框行，并将rowHeaderText集合中的行首字符串写入行首
            }

            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;                 //可自动调整列宽
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;     //可调整行首宽度
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;   //可调整列宽
            gridView.TopLeftHeaderCell.Value = topLeftText;
            gridView.RowHeadersWidth = 150;

            if (colHeaderTexts.Length > 20)
            {
                gridView.ColumnHeadersHeight = 40;
            }
            else
                gridView.ColumnHeadersHeight = 20;

            for (int colIndex = 0; colIndex < gridView.Columns.Count; colIndex++)
            {
                gridView.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                gridView.Columns[colIndex].HeaderText = colHeaderTexts[colIndex];
                gridView.Columns[colIndex].ReadOnly = readOnly;
            }

            string path = CurrentSerializePath + "\\" + fileName + ".xml";

            int index = 2;
            var data = XmlDeserializer<List<string>>(CurrentSerializePath, fileName);
            if (data != null)
            {
                if (gridView.RowCount == Convert.ToInt32(data[0]) && gridView.ColumnCount == Convert.ToInt32(data[1]))
                {
                    for (int rowIndex = 0; rowIndex < Convert.ToInt32(data[0]); rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < Convert.ToInt32(data[1]); colIndex++)
                        {
                            gridView[colIndex, rowIndex].Value = data[index++];
                        }
                    }
                }
                else
                {
                    for (int rowIndex = 0; rowIndex < gridView.RowCount; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < gridView.ColumnCount; colIndex++)
                        {
                            gridView[colIndex, rowIndex].Value = 0;
                        }
                    }
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < gridView.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < gridView.ColumnCount; colIndex++)
                    {
                        gridView[colIndex, rowIndex].Value = 0;
                    }
                }
            }

            //计算数据表格的高度
            int height = gridView.ColumnHeadersHeight;
            for (int i = 0; i < gridView.RowCount; i++)
            {
                height += gridView.Rows[i].Height;
            }

            //计算数据表格的宽度
            int width = gridView.RowHeadersWidth;
            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                width += gridView.Columns[i].Width;
            }
            if (resizeParentSize && gridView.Parent is GroupBox groupBox && groupBox != null)
            {
                if (height < groupBox.Height)
                {
                    groupBox.Dock = DockStyle.Top;
                    groupBox.Height = height + 45;
                    //groupBox.Width = width + 30;
                }
            }
            else
            {
                if (height < gridView.Height)
                {
                    gridView.Dock = DockStyle.None;
                    gridView.Height = height + 17;
                    gridView.Width = width + 17;
                    if (gridView.Parent is GroupBox groupBox1 && groupBox1 != null)
                    {
                        if (gridView.Height > groupBox1.Height - 4)
                            gridView.Height = groupBox1.Height - 4;
                        if (gridView.Width > groupBox1.Width - 6)
                            gridView.Width = groupBox1.Width - 6;
                        if (groupBox1.Dock == DockStyle.None)
                            groupBox1.Width = gridView.Width + 10;
                    }
                }
            }
            return height;
        }

        /// <summary>
        /// 从文件反序列化表格数据
        /// </summary>
        /// <param name="gridView">数据表格引用</param>
        /// <param name="topLeftText">表格左上角文本</param>
        /// <param name="rowHeaderTexts">列首字符串</param>
        /// <param name="colHeaderTexts">行首字符串</param>
        /// <param name="fileName">文件名</param>
        /// <param name="readOnly">是否调整父控件尺寸，默认是调整控件自身尺寸</param>
        public static void DataGridViewInitialize(DataGridView gridView, string topLeftText, List<string> rowHeaderTexts, string[] colHeaderTexts, string fileName, bool readOnly = false)
        {
            if (gridView == null || string.IsNullOrEmpty(fileName))
                return;
            if (rowHeaderTexts == null)
            {
                MessageBox.Show($"数据表格{gridView.Name}行首字符串数组不能为null");
                return;
            }
            else if (colHeaderTexts == null)
            {
                MessageBox.Show($"数据表格{gridView.Name}列首字符串数组不能为null");
                return;
            }

            gridView.Rows.Clear();                                     //清空行
            gridView.Columns.Clear();

            gridView.ColumnCount = colHeaderTexts.Length;
            gridView.AllowUserToOrderColumns = false;
            gridView.AllowUserToResizeColumns = false;
            gridView.AllowUserToResizeRows = false;
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;

            for (int i = 0; i < rowHeaderTexts.Count; i++)
            {
                gridView.Rows.Add();
                gridView.Rows[i].Height = 25;
                gridView.Rows[i].HeaderCell.Value = rowHeaderTexts[i];  //动态增加列表框行，并将rowHeaderText集合中的行首字符串写入行首
            }

            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;                 //可自动调整列宽
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;     //可调整行首宽度
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;   //可调整列宽
            gridView.TopLeftHeaderCell.Value = topLeftText;
            gridView.RowHeadersWidth = 150;
            gridView.ColumnHeadersHeight = 30;

            for (int colIndex = 0; colIndex < gridView.Columns.Count; colIndex++)
            {
                gridView.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                gridView.Columns[colIndex].HeaderText = colHeaderTexts[colIndex];
                gridView.Columns[colIndex].ReadOnly = readOnly;
               
            }

            string path = CurrentSerializePath + "\\" + fileName + ".xml";

            int index = 2;
            var data = XmlDeserializer<List<string>>(CurrentSerializePath, fileName);
            if (data != null)
            {
                if (gridView.RowCount == Convert.ToInt32(data[0]) && gridView.ColumnCount == Convert.ToInt32(data[1]))
                {
                    for (int rowIndex = 0; rowIndex < Convert.ToInt32(data[0]); rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < Convert.ToInt32(data[1]); colIndex++)
                        {
                            gridView[colIndex, rowIndex].Value = data[index++];
                        }
                    }
                }
                else
                {
                    for (int rowIndex = 0; rowIndex < gridView.RowCount; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < gridView.ColumnCount; colIndex++)
                        {
                            gridView[colIndex, rowIndex].Value = 0;
                        }
                    }
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < gridView.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < gridView.ColumnCount; colIndex++)
                    {
                        gridView[colIndex, rowIndex].Value = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 数据表和控件初始化
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="dataGrid">表格显示控件</param>
        /// <param name="rowHeaderText">行首字符串集合</param>
        /// <param name="colHeaderText">列首字符串集合</param>
        /// <param name="topLeftText">左上角字符串</param>
        /// <param name="fileName">参数文件名</param>
        /// <param name="colNum">表格列数</param>
        public static void DataTableInitialize(ref System.Data.DataTable dt, ref DataGridView dataGrid, List<string> rowHeaderText, List<string> colHeaderText, string topLeftText, string fileName, int colNum)
        {
            try
            {
                if (dt == null || dataGrid == null || string.IsNullOrEmpty(fileName))
                    return;

                dt.Clear();
                dt.Rows.Clear();
                dt.Columns.Clear();

                if (File.Exists(CurrentSerializePath + "\\" + fileName + ".xml"))
                    dt.ReadXml(CurrentSerializePath + "\\" + fileName + ".xml");
                else
                {
                    dt.Columns.Add(topLeftText);
                    if (colHeaderText == null)
                    {
                        for (int i = 1; i < colNum + 1; i++)
                        {
                            dt.Columns.Add("PIN" + i, typeof(Double));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < colHeaderText.Count; i++)
                        {
                            dt.Columns.Add(colHeaderText[i], typeof(Double));
                        }
                    }

                    for (int i = 0; i < rowHeaderText.Count; i++)
                    {
                        dt.Rows.Add(rowHeaderText[i]);
                    }

                    for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
                    {
                        for (int colIndex = 1; colIndex < dt.Columns.Count; colIndex++)
                        {
                            dt.Rows[rowIndex][colIndex] = 0.0;
                        }
                    }
                }

                dataGrid.AutoGenerateColumns = true;
                dataGrid.RowHeadersVisible = false;
                dataGrid.AllowUserToOrderColumns = false;
                dataGrid.AllowUserToResizeColumns = false;
                dataGrid.AllowUserToResizeRows = false;
                dataGrid.AllowUserToAddRows = false;
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGrid.DataSource = dt;

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dt.Columns[0].ReadOnly = true;
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// 从配置文件读取配置信息，包括拍照次数和端子PIN数
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadConfigInfoFromFile(string filePath)
        {
            FileStream ConfigStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(ConfigStream);               //以TXT流写入文件
            try
            {
                reader.BaseStream.Seek(0, SeekOrigin.Begin);                     //设置读取流位置
                //GlobleModule.AcqImageNum=Convert.ToInt32(reader.ReadLine());   //把一个以长度为前缀的字符串写入到 BinaryWriter 的当前编码的流中，并把流的当前位置按照所使用的编码和要写入到流中的指定的字符往前移。
                //GlobleModule.MaxPinNum = Convert.ToInt32(reader.ReadLine());
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
            finally                                     //使用finally块保证即使发生异常也会释放文件资源，避免进程占用
            {
                reader.Close();
                ConfigStream.Close();
            }
        }

        /// <summary>
        /// 保存配置信息到配置文件中
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteConfigInfoToFile(string filePath)
        {
            FileStream ConfigStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(ConfigStream);               //以TXT流写入文件
            try
            {
                writer.BaseStream.Seek(0, SeekOrigin.Begin);            //设置写入流位置
                //writer.WriteLine(GlobleModule.AcqImageCount);   //把一个以长度为前缀的字符串写入到 BinaryWriter 的当前编码的流中，并把流的当前位置按照所使用的编码和要写入到流中的指定的字符往前移。
                //writer.WriteLine(GlobleModule.MaxPinNum);
                writer.Flush();                        //清理缓冲区，使所有缓冲去数据写入文件中
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
            finally                                     //使用finally块保证即使发生异常也会释放文件资源，避免进程占用
            {
                writer.Close();
                ConfigStream.Close();
            }
        }

     
        /// <summary>
        /// 写入日志文件
        /// </summary>
        public static string LogInfo
        {
            set
            {
                if (mc_Info != null)
                {
                    mc_Info.SerInfo(value);
                }
            }
        }

        
       


        /// <summary>
        /// 获取独一无二的设备码（16位HASH代码）
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceID()
        {
            string sensorID = string.Empty;
            string basicID = GetCPUID() + GetMotherboardID() + GetPhysicalMemoryID();
            System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBuff = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(basicID));
            for (int i = 4; i < 12; i++)
            {
                sensorID += hashedBuff[i].ToString("X2");
            }
            return sensorID;
        }

        /// <summary>
        /// 获得cpu序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCPUID()
        {
            var myCpu = new ManagementClass("win32_Processor").GetInstances();
            var serial = "";
            foreach (ManagementObject cpu in myCpu)
            {
                var val = cpu.Properties["Processorid"].Value;
                serial += val == null ? "" : val.ToString();
            }
            myCpu.Dispose();
            return serial;
        }

        /// <summary>
        /// 获取主板序列号
        /// </summary>
        /// <returns></returns>
        public static string GetMotherboardID()
        {
            var myMb = new ManagementClass("Win32_BaseBoard").GetInstances();
            var serial = "";
            foreach (ManagementObject mb in myMb)
            {
                var val = mb.Properties["SerialNumber"].Value;
                serial += val == null ? "" : val.ToString();
            }
            myMb.Dispose();
            return serial;
        }

        /// <summary>
        /// 获取所有内存信息，参考 CPUID 软件
        /// </summary>
        /// <returns></returns>
        public static string GetPhysicalMemoryID()
        {
            string memoryID = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_PhysicalMemory");
            foreach (var prop in mos.Get())
            {
                memoryID = memoryID + prop["PartNumber"].ToString().Trim() + prop["SerialNumber"].ToString().Trim();
            }
            mos.Dispose();
            return memoryID;
        }

        /// <summary>
        /// 判断路径指定的根目录是否存在
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool LogicDriveExsit(string path)
        {
            bool driveExsit = false;
            foreach (string drive in Environment.GetLogicalDrives())
            {
                if (path.StartsWith(drive))
                {
                    driveExsit = true;
                    break;
                }
            }
            return driveExsit;
        }

        /// <summary>
        /// 获取参数文件夹中所有产品名称
        /// </summary>
        /// <param name="FilePath">参数文件夹路径</param>
        /// <returns></returns>
        public static List<string> InquirePath(string FilePath)
        {
            List<string> folderName = new List<string>();
            try
            {
                if (Directory.Exists(FilePath))                        //判断文件夹是否存在
                {
                    DirectoryInfo info = new DirectoryInfo(FilePath);
                    foreach (DirectoryInfo item in info.GetDirectories())        //只搜索产品名称的文件夹
                    {
                        //过滤掉文件名称中包含Common字符的文件夹
                        if (!item.Name.Contains("Common"))
                        {
                            folderName.Add(item.Name);
                        }
                    }
                }
                else MessageBox.Show("参数文件夹(common)不存在" + Environment.NewLine + FilePath);
            }
            catch (Exception ex)
            {
                UserLoginForm.ShowException(ex);
            }
            return folderName;
        }

        /// <summary>
        /// 获取当前DLL文件路径
        /// </summary>
        /// <returns></returns>
        public static string AssemblyDirectory()
        {
            try
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
            catch (Exception)
            {
                MessageBox.Show("获取MenuToolBar.dll路径出错", "获取DLL路径出错", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        /// <summary>
        /// 字符串倒序
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReverseA(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = string.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        /// <summary>
        /// 1.检查应用程序是否通过开机自启动。
        /// 2.校验设备ID，如果与预期不匹配，则退出程序。
        /// 3.判断该程序实例是否已启动.
        /// 4.校验License是否存在。
        /// 如果上述3个条件都满足则返回true，否则返回false。
        /// </summary>
        public static bool CheckDeviceID(params string[] deviceIDs)
        {
            bool result = false;
            try
            {
                CheckWhetherPowerSeftStart();
                string deviceID = GetDeviceID();
                //校验设备ID是否匹配
                foreach (string id in deviceIDs)
                {
                    if (deviceID == id)
                    {
                        result = true;
                        break;
                    }
                }
                if (!result)
                {
                    MessageBox.Show(string.Format("DeviceID Do Not Match,Please Contact Your Equipment Supplier!{0}{1}",
                        Environment.NewLine, ReverseA(deviceID)), "Unable To Start Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //判断程序实例是否已启动
                else
                {
                    //判断是否已经运行应用程序的实例
                    string exeName = Path.GetFileName(Application.ExecutablePath);
                    Run = new Mutex(true, exeName, out bool noRun);
                    if (!noRun)
                    {
                        result = false;
                        MessageBox.Show("抱歉，程序只能在一台机上运行一个实例！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                  
                }
                if (!result)
                    Application.Exit();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            return result;
        }

        /// <summary>
        /// 判断当前登录用户是否为管理员
        /// </summary>
        /// <returns></returns>
        public static bool CheckWindowsUser()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// 校验应用程序是否是开机自启动。
        /// </summary> 
        public static void CheckWhetherPowerSeftStart()
        {
            try
            {
                string[] use = Environment.GetCommandLineArgs();
                bool autoRun = false;
                foreach (var item in use)
                {
                    if (item.Contains("autoRun"))
                        autoRun = true;
                }
                //判断是开机自启动还是手动启动应用程序
                if (autoRun)
                {
                    if (DialogResult.No == MessageBox.Show("即将在关闭本窗口10秒后启动视觉检测程序，请确认是否要启动?", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        return;
                    }
                    //开机启动延时10秒钟
                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        /// <summary>
        /// 启动外部进程
        /// </summary>
        /// <param name="exeFilePath">外部程序exe文件路径</param>
        /// <param name="waitExit">是否等待外部进程关闭</param>
        public static void StartExternProcess(string exeFilePath, bool waitExit = false)
        {
            //if (!File.Exists(exeFilePath))
            //    return;

            Process process = new Process();
            try
            {
                //设置是否使用操作系统shell启动进程的值
                process.StartInfo.UseShellExecute = false;
                //指定外部进程的物理路径
                process.StartInfo.FileName = exeFilePath;
                //指定是否在新窗口中启动进程的值
                process.StartInfo.CreateNoWindow = true;
                //启动外部进程
                process.Start();
                //等待结束进程
                if (waitExit)
                    process.WaitForExit();
                //强制回收垃圾
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

     
      
    }
}
