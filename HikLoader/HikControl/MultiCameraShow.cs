using HikUnLoader.HikClass;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.Core;
using GlobleModule = HikUnLoader.HikClass.GlobleModule;

namespace HikUnLoader.HikControl
{
    public partial class MultiCameraShow : UserControl
    {
        /// <summary>
        /// 相机个数 
        /// </summary>
        private int camNum = 0;

        /// <summary>
        /// 属性：设置相机个数
        /// </summary>
        public int CameraNum
        {
            set
            {
                if (value < 1 || value > 4)
                {
                    return;
                }
                camNum = value;
            }
        }

        private List<int> list_CameraData;

        /// <summary> 
        /// 线程安全阻塞集合:相机1保存图像队列
        /// </summary>
        public BlockingCollection<string> Camera1Images { get; }

        /// <summary> 
        /// 线程安全阻塞集合:相机2保存图像队列
        /// </summary>
        public BlockingCollection<string> Camera2Images { get; }

        /// <summary>
        /// 相机1保存图像线程
        /// </summary>
        public BackgroundWorker bgw_Camera1SaveImage = new BackgroundWorker();

        /// <summary>
        /// 相机2保存图像线程
        /// </summary>
        public BackgroundWorker bgw_Camera2SaveImage = new BackgroundWorker();

        /// <summary>
        ///构造方法
        /// </summary>
        public MultiCameraShow()
        {
            InitializeComponent();
            Camera1Images = new BlockingCollection<string>(10);
            Camera2Images = new BlockingCollection<string>(10);
        }

        /// <summary>
        /// 事件处理器：窗体加载时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vmRenderControl2_Load(object sender, EventArgs e)
        {
            bgw_Camera1SaveImage.DoWork += Bgw_SaveImage1_DoWork;
            bgw_Camera1SaveImage.WorkerSupportsCancellation = true;
            if (!bgw_Camera1SaveImage.IsBusy)
            {
                bgw_Camera1SaveImage.RunWorkerAsync();
            }

            bgw_Camera2SaveImage.DoWork += Bgw_SaveImage2_DoWork;
            bgw_Camera2SaveImage.WorkerSupportsCancellation = true;
            if (!bgw_Camera2SaveImage.IsBusy)
            {
                bgw_Camera2SaveImage.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 相机1保存图像后台执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bgw_SaveImage1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgw_Camera1SaveImage.CancellationPending)
            {
                try
                {
                    if (Camera1Images.TryTake(out string imagePath, 10))
                    {
                        string path = imagePath;
                        if (path == null)
                        { break; }
                        string sTime = DateTime.Now.ToLongDateString();    //当前日期,类似  2018年7月2日 
                        string folderName = $"{path}\\{GlobleModule.CurrentProduct}\\{sTime}\\相机1";
                        if (!Directory.Exists(folderName))  //判断文件是否存在，不存在则创建
                        { Directory.CreateDirectory(folderName); }
                        //当前时间，24小时制的 时:分:秒
                        string time = DateTime.Now.ToLongTimeString();
                        string NgImagePath = $"{path}\\{GlobleModule.CurrentProduct}\\{sTime}\\{DateTime.Now.ToString("hhmmss")}Y.bmp";//原图
                        string NgImagePath1 = $"{path}\\{GlobleModule.CurrentProduct}\\{sTime}\\{DateTime.Now.ToString("hhmmss")}X.bmp";//渲染图

                        if (vmRenderControlCam1.InvokeRequired)
                        {
                            vmRenderControlCam1.Invoke(new Action(() =>
                            {
                                vmRenderControlCam1.SaveOriginalImage(NgImagePath);
                                vmRenderControlCam1.SaveRenderedImage(NgImagePath1);
                            }));
                        }
                        else
                        {
                            vmRenderControlCam1.SaveOriginalImage(NgImagePath);
                            vmRenderControlCam1.SaveRenderedImage(NgImagePath1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobleModule.ShowException(ex);
                }
            }
        }

        /// <summary>
        /// 相机2保存图像后台执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bgw_SaveImage2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgw_Camera1SaveImage.CancellationPending)
            {
                try
                {
                    if (Camera2Images.TryTake(out string imagePath, 10))
                    {
                        string path = imagePath;
                        if (path == null)
                        { break; }
                        string sTime = DateTime.Now.ToLongDateString();    //当前日期,类似  2018年7月2日 
                        string folderName = $"{path}\\{GlobleModule.CurrentProduct}\\{sTime}\\相机2\\";
                        if (!Directory.Exists(folderName))  //判断文件是否存在，不存在则创建
                        { Directory.CreateDirectory(folderName); }
                        //当前时间，24小时制的 时:分:秒
                        string time = DateTime.Now.ToLongTimeString();
                        string NgImagePath = $"{path}\\{GlobleModule.CurrentProduct}\\{sTime}\\{DateTime.Now.ToString("hhmmss")}Y.bmp";//原图
                        string NgImagePath1 = $"{path}\\{GlobleModule.CurrentProduct}\\{sTime}\\{DateTime.Now.ToString("hhmmss")}X.bmp";//渲染图

                        if (vmRenderControlCam1.InvokeRequired)
                        {
                            vmRenderControlCam2.Invoke(new Action(() =>
                            {
                                vmRenderControlCam2.SaveOriginalImage(NgImagePath);
                                vmRenderControlCam2.SaveRenderedImage(NgImagePath1);
                            }));
                        }
                        else
                        {
                            vmRenderControlCam2.SaveOriginalImage(NgImagePath);
                            vmRenderControlCam2.SaveRenderedImage(NgImagePath1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobleModule.ShowException(ex);
                }
            }
        }

        /// <summary> 初始化数据显示控件 </summary>
        /// <summary>
        /// 测量数据显示控件初始化
        /// </summary>
        /// <param name="rowHeaderTexts">行首字符串数组</param>
        /// <param name="pinNum">Pin数</param>
        /// <param name="topLeftText">表格左上角字符串</param>
        /// <param name="rowHeaderWidth">行首单元格宽度</param>
        public void InitializeDataView(string[] rowHeaderTexts, string topLeftText, int rowHeaderWidth = 150)
        {
            try
            {

                dgv_DataSendToPLC.Rows.Clear();
                for (int colIndex = 0; colIndex < 2; colIndex++)
                {
                    dgv_DataSendToPLC.Columns.Add($"相机{colIndex + 1}目标", $"相机{colIndex + 1}目标");
                    dgv_DataSendToPLC.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgv_DataSendToPLC.Columns[colIndex].Width = 90;
                }
                dgv_DataSendToPLC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_DataSendToPLC.RowHeadersVisible = true;
                dgv_DataSendToPLC.AllowUserToOrderColumns = false;
                dgv_DataSendToPLC.AllowUserToResizeColumns = false;
                dgv_DataSendToPLC.AllowUserToResizeRows = false;
                dgv_DataSendToPLC.AllowUserToAddRows = false;
                dgv_DataSendToPLC.AllowUserToDeleteRows = false;
                dgv_DataSendToPLC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv_DataSendToPLC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv_DataSendToPLC.ColumnHeadersHeight = 25;
                dgv_DataSendToPLC.ReadOnly = true;
                dgv_DataSendToPLC.TopLeftHeaderCell.Value = topLeftText;

                for (int rowIndex = 0; rowIndex < rowHeaderTexts.Length; rowIndex++)
                {
                    DataGridViewRow viewRow = new DataGridViewRow();
                    viewRow.HeaderCell.Value = rowHeaderTexts[rowIndex];
                    dgv_DataSendToPLC.Rows.Add(viewRow);

                }
                dgv_DataSendToPLC.RowHeadersWidth = 80;


                for (int rowIndex = 0; rowIndex < dgv_DataSendToPLC.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < dgv_DataSendToPLC.ColumnCount; colIndex++)
                    {
                        dgv_DataSendToPLC[colIndex, rowIndex].Value = 0;
                        dgv_DataSendToPLC[colIndex, rowIndex].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
                //GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 更新扫码显示信息
        /// </summary>
        /// <param name="test"></param>
        /// <param name="isFalse"></param>
        public void UpdateQR(string test, bool isFalse)
        {
            if (lable_CodeReaderMessage.InvokeRequired)
            {
                lable_CodeReaderMessage.Invoke(new Action(() =>
                {
                    UpdateQR(test, isFalse);
                    return;
                }));
            }
            else
            {
                if (isFalse)
                {
                    lable_CodeReaderMessage.Text = $"扫码信息：{test}";
                    lable_CodeReaderMessage.BackColor = Color.Green;
                }
                else
                {
                    lable_CodeReaderMessage.Text = $"扫码信息：识别失败";
                    lable_CodeReaderMessage.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 更新扫码成功率
        /// </summary>
        /// <param name="CurrentNum"></param>
        /// <param name="HistoryNum"></param>
        public void UpdateSuccessRateOfScanning(double CurrentNum, double HistoryNum)
        {
            if (label_SuccessRateOfCurrentCodeScan.InvokeRequired)
            {
                label_SuccessRateOfCurrentCodeScan.Invoke(new Action(() =>
                {
                    UpdateSuccessRateOfScanning(CurrentNum, HistoryNum);
                    return;
                }));
            }
            else
            {
                label_SuccessRateOfCurrentCodeScan.Text = CurrentNum.ToString() + "%";
                label_SuccessRateOfHistoryCodeScan.Text = HistoryNum.ToString() + "%";
            }
        }

        /// <summary>
        /// 更新指定节点的统计数据
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="result">检测结果</param>
        public void UpdateProductStatisticsInfo(CameraName cameraName, string result)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdateProductStatisticsInfo(cameraName, result)));
                    return;
                }
                else
                {
                    string colHeaderText = cameraName.ToString();
                    //int conutOfGoodProduct = (int)dgv_DataStatistics[colHeaderText, 2].Value;//良品数
                    dgv_DataStatistics[colHeaderText, 0].Value = result;
                    if (result.Contains("OK"))
                    {
                        if (cameraName == CameraName.相机1)
                        {
                            label_Cam1Result.Text = result;
                            label_Cam1Result.BackColor = Color.Green;
                        }
                        else
                        {
                            label_Cam2Result.Text = result;
                            label_Cam2Result.BackColor = Color.Green;
                        }
                        dgv_DataStatistics[colHeaderText, 0].Value = "OK";
                        dgv_DataStatistics[colHeaderText, 0].Style.BackColor = Color.Green;
                        //dgv_DataStatistics[colHeaderText, 2].Value = ++conutOfGoodProduct;
                    }
                    else
                    {
                        if (cameraName == CameraName.相机1)
                        {
                            label_Cam1Result.Text = "NG";
                            label_Cam1Result.BackColor = Color.Red;
                        }
                        else
                        {
                            label_Cam2Result.Text = "NG";
                            label_Cam2Result.BackColor = Color.Red;
                        }
                        dgv_DataStatistics[colHeaderText, 0].Value = "NG";
                        dgv_DataStatistics[colHeaderText, 0].Style.BackColor = Color.Red;
                        //int fail = (int)dgv_DataStatistics[colHeaderText, 3].Value;
                        //dgv_DataStatistics[colHeaderText, 3].Value = ++fail;
                    }
                    int total = (int)dgv_DataStatistics[colHeaderText, 1].Value;
                    dgv_DataStatistics[colHeaderText, 1].Value = ++total;

                    //int sum = (int)dgv_DataStatistics[colHeaderText, 1].Value;
                    //if (sum > 0) 
                    //{ dgv_dataStatistics[colHeaderText, 4].Value = $"{Math.Round(((double)pass / (double)sum * 100), 2)}%"; }
                    //else
                    //{ dgv_dataStatistics[colHeaderText, 4].Value = "NaN"; }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }

        }

        /// <summary>
        /// 更新相机2拍照后tray盘的正反结果
        /// </summary>
        /// <param name="pma">1为正，2为反 ，0为未匹配到</param>
        public void UpdateCam2PositiveOrNegativeResult(int pma)
        {
            if (label_ModelMatchResult.InvokeRequired)
            {
                label_ModelMatchResult.Invoke(new Action(() =>
                {
                    UpdateCam2PositiveOrNegativeResult(pma);
                    return;
                }));
            }
            else
            {
                if (pma == 0)
                {
                    label_ModelMatchResult.Text = "无正反";
                    label_ModelMatchResult.BackColor = Color.Red;
                }
                else if (pma == 1)
                {
                    label_ModelMatchResult.Text = "正向角";
                    label_ModelMatchResult.BackColor = Color.Green;
                }
                else if (pma == 2)
                {
                    label_ModelMatchResult.Text = "反向角";
                    label_ModelMatchResult.BackColor = Color.LawnGreen;
                }
            }
        }

        /// <summary>
        /// 绑定相机1流程
        /// </summary>
        public VmModule Camera1vmModule
        {
            set
            {
                vmRenderControlCam1.ModuleSource = value;
            }
        }

        /// <summary>
        /// 绑定相机2流程
        /// </summary>
        public VmModule Camera2vmModule
        {
            set
            {
                vmRenderControlCam2.ModuleSource = value;
            }
        }

        /// <summary>
        /// 写入测量数据和分类统计数据。
        /// </summary>
        /// <param name="resultDats">待写入结果数据行集合。</param>
        /// <param name="productFound">产品是否找到，找到才更新分类统计表格。</param>
        /// <param name="writeTo2">此参数未使用，为了实现接口而定义。</param>
        public void RefreshMeasureShow(CameraName cameraName, List<Result> resultDats)
        {
            try
            {
                //WinAPI.SendMessage(MeasureDataShow.Handle, WinAPI.WM_SETREDRAW, 0, IntPtr.Zero);
                if (dgv_DataSendToPLC.InvokeRequired)
                {
                    Invoke(new Action<CameraName, List<Result>>(RefreshMeasureShow), resultDats);
                }
                else
                {

                    int rowCount = Math.Min(resultDats.Count, dgv_DataSendToPLC.RowCount);

                    if (cameraName == CameraName.相机1)
                    {
                        for (int rowIndex = 0; rowIndex < resultDats.Count; rowIndex++)
                        {

                            if (resultDats.Count <= dgv_DataSendToPLC.ColumnCount)
                            {

                                dgv_DataSendToPLC[rowIndex, 0].Value = resultDats[rowIndex].X;
                                if (resultDats[rowIndex].Xresult == false)
                                {
                                    dgv_DataSendToPLC[rowIndex, 0].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dgv_DataSendToPLC[rowIndex, 0].Style.BackColor = Color.White;
                                }
                                dgv_DataSendToPLC[rowIndex, 1].Value = resultDats[rowIndex].Y;
                                if (resultDats[rowIndex].Yresult == false)
                                {
                                    dgv_DataSendToPLC[rowIndex, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dgv_DataSendToPLC[rowIndex, 1].Style.BackColor = Color.White;
                                }
                                dgv_DataSendToPLC[rowIndex, 2].Value = resultDats[rowIndex].Angle;
                                if (resultDats[rowIndex].Angleresult == false)
                                {
                                    dgv_DataSendToPLC[rowIndex, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dgv_DataSendToPLC[rowIndex, 2].Style.BackColor = Color.White;
                                }
                            }


                        }
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < resultDats.Count; rowIndex++)
                        {

                            if (resultDats.Count <= dgv_DataSendToPLC.ColumnCount)
                            {
                                dgv_DataSendToPLC[1, 0].Value = resultDats[rowIndex].X;
                                if (resultDats[rowIndex].Xresult == false)
                                {
                                    dgv_DataSendToPLC[1, 0].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dgv_DataSendToPLC[1, 0].Style.BackColor = Color.White;
                                }
                                dgv_DataSendToPLC[1, 1].Value = resultDats[rowIndex].Y;
                                if (resultDats[rowIndex].Yresult == false)
                                {
                                    dgv_DataSendToPLC[1, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dgv_DataSendToPLC[1, 1].Style.BackColor = Color.White;
                                }
                                dgv_DataSendToPLC[1, 2].Value = resultDats[rowIndex].Angle;
                                if (resultDats[rowIndex].Angleresult == false)
                                {
                                    dgv_DataSendToPLC[1, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dgv_DataSendToPLC[1, 2].Style.BackColor = Color.White;
                                }
                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
            //WinAPI.SendMessage(MeasureDataShow.Handle, WinAPI.WM_SETREDRAW, 1, IntPtr.Zero);
            //MeasureDataShow.Refresh();
        }

        /// <summary> 
        /// 保存统计数据
        /// </summary>
        public void Save()
        {
            try
            {
                List<int> data = new List<int>();
                for (int i = 0; i < dgv_DataStatistics.ColumnCount; i++)
                {
                    data.Add(Convert.ToInt32(dgv_DataStatistics[i, 1].Value));
                    //data.Add(Convert.ToInt32(dgv_DataStatistics[i, 2].Value));
                }
                GlobleModule.XmlSerializer(data, GlobleModule.CurrentSerializePath + "\\相机1", "CameraData");
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 读取参数，初始化相机数据和统计数据
        /// </summary>
        public void Read()
        {
            try
            {
                InitializeDataView(Enum.GetNames(typeof(CompRowHeader)), "数据显示");
                list_CameraData = GlobleModule.XmlDeserializer<List<int>>(GlobleModule.CurrentSerializePath + "\\相机1", "CameraData");
                CameraInitialize(list_CameraData, "数据统计");
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 相机数据和统计数据初始化
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="cameraData">相机数据</param>
        /// <param name="topLeftText">表格左上角字符串</param>
        /// <param name="rowHeaderWidth">行首单元格宽度</param>
        public void CameraInitialize(List<int> cameraData, string topLeftText, int rowHeaderWidth = 150)
        {
            try
            {
                if (camNum < 1 || camNum > 4) { return; }
                dgv_DataStatistics.Rows.Clear();
                for (int colIndex = 0; colIndex < camNum; colIndex++)
                {

                    dgv_DataStatistics.Columns.Add($"相机{colIndex + 1}", $"相机{colIndex + 1}");
                    dgv_DataStatistics.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgv_DataStatistics.Columns[colIndex].Width = 80;
                }
                dgv_DataStatistics.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_DataStatistics.RowHeadersVisible = true;
                dgv_DataStatistics.AllowUserToOrderColumns = false;
                dgv_DataStatistics.AllowUserToResizeColumns = false;
                dgv_DataStatistics.AllowUserToResizeRows = false;
                dgv_DataStatistics.AllowUserToAddRows = false;
                dgv_DataStatistics.AllowUserToDeleteRows = false;
                dgv_DataStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv_DataStatistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv_DataStatistics.ColumnHeadersHeight = 25;
                dgv_DataStatistics.ReadOnly = true;
                dgv_DataStatistics.TopLeftHeaderCell.Value = topLeftText;

                //string[] rowHeaderTexts = new string[] { "当前结果", "生产总数", "良品数", "不良品数", "合格率" };
                string[] rowHeaderTexts = new string[] { "当前结果", "生产总数" };
                for (int rowIndex = 0; rowIndex < rowHeaderTexts.Length; rowIndex++)
                {
                    DataGridViewRow viewRow = new DataGridViewRow();
                    viewRow.HeaderCell.Value = rowHeaderTexts[rowIndex];
                    dgv_DataStatistics.Rows.Add(viewRow);

                }
                dgv_DataStatistics.RowHeadersWidth = 90;

                if (cameraData == null || cameraData.Count != camNum * 2)
                {
                    for (int i = 0; i < camNum; i++)
                    {
                        dgv_DataStatistics[i, 0].Value = "OK";//当前结果
                        dgv_DataStatistics[i, 0].Style.BackColor = Color.White;

                        dgv_DataStatistics[i, 1].Value = 0;//生产总数
                        dgv_DataStatistics[i, 1].Style.BackColor = Color.White;

                        //dgv_DataStatistics[i, 2].Value = 0;//良品数
                        //dgv_DataStatistics[i, 2].Style.BackColor = Color.White;

                        //dgv_DataStatistics[i, 3].Value = 0;//NG数
                        //dgv_DataStatistics[i, 3].Style.BackColor = Color.White;

                        //dgv_dataStatistics[i, 4].Value = 0;//合格率
                        //dgv_dataStatistics[i, 4].Style.BackColor = Color.White;
                    }

                }
                else
                {
                    for (int colIndex = 0; colIndex < camNum; colIndex++)//有几个相机就有几列
                    {
                        dgv_DataStatistics[colIndex, 0].Value = "OK";//当前结果
                        dgv_DataStatistics[colIndex, 0].Style.BackColor = Color.White;

                        dgv_DataStatistics[colIndex, 1].Value = cameraData[2 * colIndex + 0];//生产总数
                        dgv_DataStatistics[colIndex, 1].Style.BackColor = Color.White;

                        //dgv_DataStatistics[colIndex, 2].Value = cameraData[2 * colIndex + 1];//良品数
                        //dgv_DataStatistics[colIndex, 2].Style.BackColor = Color.White;

                        //dgv_DataStatistics[colIndex, 3].Value = cameraData[2 * colIndex + 0] - cameraData[2 * colIndex + 1];//不良品数
                        //dgv_DataStatistics[colIndex, 3].Style.BackColor = Color.White;

                        //if (cameraData[2 * colIndex + 0] + cameraData[2 * colIndex + 1] == 0)
                        //{
                        //    dgv_dataStatistics[colIndex, 4].Value = 0;
                        //}
                        //else
                        //{
                        //    dgv_dataStatistics[colIndex, 4].Value = $"{Math.Round(((double)cameraData[2 * colIndex + 0] / (double)(cameraData[2 * colIndex + 0] + cameraData[2 * colIndex + 1]) * 100), 2)}%";
                        //}
                        //dgv_dataStatistics[colIndex, 4].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 显示区数据清空
        /// </summary>
        public void ClearData()
        {
            for (int rowIndex = 0; rowIndex < dgv_DataSendToPLC.RowCount; rowIndex++)//测量数据清理
            {
                for (int colIndex = 0; colIndex < dgv_DataSendToPLC.ColumnCount; colIndex++)
                {
                    dgv_DataSendToPLC[colIndex, rowIndex].Value = 0;
                    dgv_DataSendToPLC[colIndex, rowIndex].Style.BackColor = Color.White;
                }
            }

            for (int colIndex = 0; colIndex < camNum; colIndex++)//生产数据清理
            {
                for (int rowindex = 0; rowindex < dgv_DataStatistics.RowCount; rowindex++)
                {
                    dgv_DataStatistics[colIndex, rowindex].Value = 0;
                    dgv_DataStatistics[colIndex, rowindex].Style.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="str"></param>
        public void SerInfo(string str)
        {
            try
            {
                if (str == null)
                {
                    return;
                }
                string time = DateTime.Now.ToLongTimeString();
                if (textBox_LogInfo.InvokeRequired)
                {
                    textBox_LogInfo.Invoke(new Action(() =>
                    {
                        textBox_LogInfo.AppendText(time + ":" + str + "\r\n");
                    }));
                }
                else
                {
                    textBox_LogInfo.AppendText(time + ":" + str + "\r\n");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 控件重绘功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            //try
            //{
            //    groupBox2.Location = new Point(splitContainer1.Panel1.Width - groupBox2.Width, splitContainer1.Panel1.Height - groupBox2.Height);
            //}
            //catch
            //{ 

            //}
        }

        ///// <summary>
        ///// 判断通信信号不为空
        ///// </summary>
        ///// <returns>true不为空，fasle为空</returns>
        //public bool JudgeSignal()
        //{
        //    //if (Parameter.PLCIP != null && Parameter.PLCPort != null && GlobleModule.CamerRady!=null && GlobleModule.CamerCF!=null &&
        //    //    Parameter.QRCF!=null && GlobleModule.CamerCalibStart!=null && GlobleModule.CalibXCoordinate!=null && GlobleModule.CalibYCoordinate!=null &&
        //    //        GlobleModule.CameraResult!=null && GlobleModule.CameraXData!=null && GlobleModule.CameraYData!=null
        //    //    )
        //    //{
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}
        //}


    }
}
