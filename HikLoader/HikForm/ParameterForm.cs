using HikUnLoader.HikClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikUnLoader.HikFrom
{
    /// <summary>
    /// 参数设置窗体类
    /// </summary>
    public partial class ParameterForm : Form
    {
        /// <summary>
        /// 相机补偿值表格
        /// </summary>
        public DataTable dt_BCData = new DataTable();

        /// <summary>
        /// 管控值表格
        /// </summary>
        public DataTable dt_GKData = new DataTable();

        /// <summary>
        /// 构造方法
        /// </summary>
        public ParameterForm()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 事件：窗体加载时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParameterForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 事件：保存参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SaveParameters_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("成功保存参数设置");
        }

        /// <summary>
        /// 从xml文件加载补偿值,管控值,文档参数
        /// </summary>
        public void LoadData()
        {
            try
            {
                InitializeCompensationValueDT(Enum.GetNames(typeof(CompRowHeader)), null, "补偿值2D", "CompDatas_2D", 3);
                InitializeControlValueDT(Enum.GetNames(typeof(ThresholdColHeader)), null, "管控值2D", "ThresholdDatas_2D", 2);
                documentParameter1.LoadDocData();
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        /// <summary>
        /// 保存补偿值,管控值,文档参数到xml文件
        /// </summary>
        /// <param name="fileName">文件名称，不含后缀。</param>
        public void SaveData()
        {
            try
            {
                //如果文件目录不存在，则创建目录
                if (!Directory.Exists(GlobleModule.CurrentSerializePath))
                {
                    Directory.CreateDirectory(GlobleModule.CurrentSerializePath);
                }
                dt_BCData.WriteXml(GlobleModule.CurrentSerializePath + $"\\CompDatas_2D.xml", XmlWriteMode.WriteSchema);
                dt_GKData.WriteXml(GlobleModule.CurrentSerializePath + $"\\ThresholdDatas_2D.xml", XmlWriteMode.WriteSchema);
                documentParameter1.SaveDocData();
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }

        }

        /// <summary>
        /// 补偿值表格数据初始化
        /// </summary>
        /// <param name="rowHeaderText">列首字符串数组</param>
        /// <param name="colHeaderText">行首字符串集合</param>
        /// <param name="topLeftText">左上角文本</param>
        /// <param name="fileName">文件名</param>
        /// <param name="pinNum">PIN数</param>
        /// <param name="rowHeaderWidth">行首单元格宽度</param>
        /// <returns>返回表格要占的尺寸。</returns>
        private Size InitializeCompensationValueDT(string[] rowHeaderText, List<string> colHeaderText, string topLeftText, string fileName, int pinNum, int rowHeaderWidth = 150)
        {
            DataGridView gridView = dgv_DataBC;
            try
            {
                dt_BCData.Clear();
                dt_BCData.Rows.Clear();
                dt_BCData.Columns.Clear();
                dt_BCData.TableName = topLeftText;

                if (File.Exists(GlobleModule.CurrentSerializePath + "\\" + fileName + ".xml"))
                {
                    dt_BCData.ReadXml(GlobleModule.CurrentSerializePath + "\\" + fileName + ".xml");
                }
                //判断读取的行数和列数与预期的行列数是否相等
                if (dt_BCData.Rows.Count != rowHeaderText.Length || dt_BCData.Columns.Count - 1 != pinNum)
                {
                    dt_BCData.Clear();
                    dt_BCData.Rows.Clear();
                    dt_BCData.Columns.Clear();

                    dt_BCData.Columns.Add(topLeftText);
                    if (colHeaderText == null)
                    {
                        for (int i = 1; i < pinNum + 1; i++)
                        {
                            dt_BCData.Columns.Add($"相机{i}目标", typeof(Double));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < colHeaderText.Count; i++)
                        {
                            dt_BCData.Columns.Add(colHeaderText[i], typeof(Double));
                        }
                    }

                    for (int i = 0; i < rowHeaderText.Length; i++)
                    {
                        dt_BCData.Rows.Add(rowHeaderText[i]);
                    }

                    for (int rowIndex = 0; rowIndex < dt_BCData.Rows.Count; rowIndex++)
                    {
                        for (int colIndex = 1; colIndex < dt_BCData.Columns.Count; colIndex++)
                        {
                            dt_BCData.Rows[rowIndex][colIndex] = 0;
                        }
                    }
                }

                gridView.AutoGenerateColumns = true;
                gridView.RowHeadersVisible = false;
                gridView.AllowUserToOrderColumns = false;
                gridView.AllowUserToResizeColumns = false;
                gridView.AllowUserToResizeRows = false;
                gridView.AllowUserToAddRows = false;
                gridView.AllowUserToDeleteRows = false;
                // gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridView.ColumnHeadersHeight = 30;
                gridView.RowHeadersWidth = 50;
                gridView.DataSource = dt_BCData;

                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dt_BCData.Columns[0].ReadOnly = true;
                for (int i = 0; i < gridView.ColumnCount; i++)
                {
                    gridView.Columns[i].Width = 80;
                }

            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }

            return gridView.PreferredSize;
        }

        /// <summary>
        /// 管控值表格数据初始化
        /// </summary>
        /// <param name="rowHeaderText">列首字符串数组</param>
        /// <param name="colHeaderText">行首字符串集合</param>
        /// <param name="topLeftText">左上角文本</param>
        /// <param name="fileName">文件名</param>
        /// <param name="pinNum">PIN数</param>
        /// <param name="rowHeaderWidth">行首单元格宽度</param>
        /// <returns>返回表格要占的尺寸。</returns>
        private Size InitializeControlValueDT(string[] rowHeaderText, List<string> colHeaderText, string topLeftText, string fileName, int pinNum, int rowHeaderWidth = 150)
        {
            DataGridView gridView = dgv_DataGK;
            try
            {
                dt_GKData.Clear();
                dt_GKData.Rows.Clear();
                dt_GKData.Columns.Clear();
                dt_GKData.TableName = topLeftText;

                if (File.Exists(GlobleModule.CurrentSerializePath + "\\" + fileName + ".xml"))
                    dt_GKData.ReadXml(GlobleModule.CurrentSerializePath + "\\" + fileName + ".xml");
                //判断读取的行数和列数与预期的行列数是否相等
                if (dt_GKData.Rows.Count != rowHeaderText.Length || dt_GKData.Columns.Count - 1 != pinNum)
                {
                    dt_GKData.Clear();
                    dt_GKData.Rows.Clear();
                    dt_GKData.Columns.Clear();

                    dt_GKData.Columns.Add(topLeftText);
                    if (colHeaderText == null)
                    {
                        for (int i = 1; i < pinNum + 1; i++)
                        {
                            dt_GKData.Columns.Add($"相机{i}目标", typeof(Double));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < colHeaderText.Count; i++)
                        {
                            dt_GKData.Columns.Add(colHeaderText[i], typeof(Double));
                        }
                    }

                    for (int i = 0; i < rowHeaderText.Length; i++)
                    {
                        dt_GKData.Rows.Add(rowHeaderText[i]);
                    }

                    for (int rowIndex = 0; rowIndex < dt_GKData.Rows.Count; rowIndex++)
                    {
                        for (int colIndex = 1; colIndex < dt_GKData.Columns.Count; colIndex++)
                        {
                            dt_GKData.Rows[rowIndex][colIndex] = 0;
                        }
                    }
                }

                gridView.AutoGenerateColumns = true;
                gridView.RowHeadersVisible = false;
                gridView.AllowUserToOrderColumns = false;
                gridView.AllowUserToResizeColumns = false;
                gridView.AllowUserToResizeRows = false;
                gridView.AllowUserToAddRows = false;
                gridView.AllowUserToDeleteRows = false;
                //gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridView.ColumnHeadersHeight = 30;
                gridView.DataSource = dt_GKData;
                gridView.RowHeadersWidth = 50;
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dt_GKData.Columns[0].ReadOnly = true;

                for (int i = 0; i < gridView.ColumnCount; i++)
                {
                    gridView.Columns[i].Width = 80;
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }

            return gridView.PreferredSize;
        }


        #region  未使用方法

        /// <summary> 初始化补偿值控件 </summary>
        /// <summary>
        /// 初始化补偿值控件
        /// </summary>
        /// <param name="rowHeaderTexts">补偿值数据</param>
        /// <param name="pinNum">Pin数</param>
        /// <param name="topLeftText">表格左上角字符串</param>
        /// <param name="rowHeaderWidth">行首单元格宽度</param>
        private void InitializeDataView(double[] rowHeaderTexts, string topLeftText, int rowHeaderWidth = 150)
        {
            try
            {
                dgv_DataBC.Rows.Clear();
                for (int colIndex = 0; colIndex < 2; colIndex++)
                {
                    dgv_DataBC.Columns.Add($"相机{colIndex + 1}目标", $"相机{colIndex + 1}目标");
                    dgv_DataBC.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgv_DataBC.Columns[colIndex].Width = 90;
                }
                dgv_DataBC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_DataBC.RowHeadersVisible = true;
                dgv_DataBC.AllowUserToOrderColumns = false;
                dgv_DataBC.AllowUserToResizeColumns = false;
                dgv_DataBC.AllowUserToResizeRows = false;
                dgv_DataBC.AllowUserToAddRows = false;
                dgv_DataBC.AllowUserToDeleteRows = false;
                dgv_DataBC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv_DataBC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv_DataBC.ColumnHeadersHeight = 25;
                dgv_DataBC.ReadOnly = false;
                dgv_DataBC.TopLeftHeaderCell.Value = topLeftText;


                DataGridViewRow viewRow = new DataGridViewRow();
                viewRow.HeaderCell.Value = "X";
                dgv_DataBC.Rows.Add(viewRow);

                DataGridViewRow viewRow1 = new DataGridViewRow();
                viewRow1.HeaderCell.Value = "Y";
                dgv_DataBC.Rows.Add(viewRow);

                DataGridViewRow viewRow2 = new DataGridViewRow();
                viewRow2.HeaderCell.Value = "角度";
                dgv_DataBC.Rows.Add(viewRow);


                dgv_DataBC.RowHeadersWidth = 80;


                for (int rowIndex = 0; rowIndex < dgv_DataBC.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < dgv_DataBC.ColumnCount; colIndex++)
                    {
                        dgv_DataBC[colIndex, rowIndex].Value = rowHeaderTexts[rowIndex];
                        dgv_DataBC[colIndex, rowIndex].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
                //GlobleModule.ShowException(ex);
            }
        }

        /// <summary> 初始化管控值控件 </summary>
        /// <summary>
        /// 初始化管控值控件
        /// </summary>
        /// <param name="rowHeaderTexts">管控值数据</param>
        /// <param name="pinNum">Pin数</param>
        /// <param name="topLeftText">表格左上角字符串</param>
        /// <param name="rowHeaderWidth">行首单元格宽度</param>
        private void InitializeDataView1(double[] rowHeaderTexts, string topLeftText, int rowHeaderWidth = 150)
        {
            try
            {
                dgv_DataGK.Rows.Clear();
                for (int colIndex = 0; colIndex < 1; colIndex++)
                {
                    dgv_DataGK.Columns.Add($"目标{colIndex + 1}", $"目标{colIndex + 1}");
                    dgv_DataGK.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgv_DataGK.Columns[colIndex].Width = 90;
                }
                dgv_DataGK.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_DataGK.RowHeadersVisible = true;
                dgv_DataGK.AllowUserToOrderColumns = false;
                dgv_DataGK.AllowUserToResizeColumns = false;
                dgv_DataGK.AllowUserToResizeRows = false;
                dgv_DataGK.AllowUserToAddRows = false;
                dgv_DataGK.AllowUserToDeleteRows = false;
                dgv_DataGK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv_DataGK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv_DataGK.ColumnHeadersHeight = 25;
                dgv_DataGK.ReadOnly = false;
                dgv_DataGK.TopLeftHeaderCell.Value = topLeftText;


                DataGridViewRow viewRow = new DataGridViewRow();
                viewRow.HeaderCell.Value = "X下限";
                dgv_DataGK.Rows.Add(viewRow);
                viewRow.HeaderCell.Value = "X上限";
                dgv_DataGK.Rows.Add(viewRow);

                viewRow.HeaderCell.Value = "Y下限";
                dgv_DataGK.Rows.Add(viewRow);

                viewRow.HeaderCell.Value = "Y上限";
                dgv_DataGK.Rows.Add(viewRow);


                viewRow.HeaderCell.Value = "角度下限";
                dgv_DataGK.Rows.Add(viewRow);

                viewRow.HeaderCell.Value = "角度上限";
                dgv_DataGK.Rows.Add(viewRow);

                dgv_DataGK.RowHeadersWidth = 80;


                for (int rowIndex = 0; rowIndex < dgv_DataBC.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < dgv_DataBC.ColumnCount; colIndex++)
                    {
                        dgv_DataGK[colIndex, rowIndex].Value = rowHeaderTexts[rowIndex];
                        dgv_DataGK[colIndex, rowIndex].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }

        #endregion

        private void ParameterForm_Activated(object sender, EventArgs e)
        {

        }
    }

}
