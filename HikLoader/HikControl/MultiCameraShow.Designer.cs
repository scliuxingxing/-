
namespace HikUnLoader.HikControl
{
    partial class MultiCameraShow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label_SuccessRateOfHistoryCodeScan = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_SuccessRateOfCurrentCodeScan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lable_CodeReaderMessage = new System.Windows.Forms.Label();
            this.label_Cam1Result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vmRenderControlCam1 = new VMControls.Winform.Release.VmRenderControl();
            this.label_ModelMatchResult = new System.Windows.Forms.Label();
            this.label_Cam2Result = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vmRenderControlCam2 = new VMControls.Winform.Release.VmRenderControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_LogInfo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_DataStatistics = new System.Windows.Forms.DataGridView();
            this.dgv_DataSendToPLC = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataSendToPLC)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1422, 730);
            this.splitContainer1.SplitterDistance = 580;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label_SuccessRateOfHistoryCodeScan);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label_SuccessRateOfCurrentCodeScan);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.lable_CodeReaderMessage);
            this.splitContainer2.Panel1.Controls.Add(this.label_Cam1Result);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.vmRenderControlCam1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label_ModelMatchResult);
            this.splitContainer2.Panel2.Controls.Add(this.label_Cam2Result);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.vmRenderControlCam2);
            this.splitContainer2.Size = new System.Drawing.Size(1422, 580);
            this.splitContainer2.SplitterDistance = 648;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // label_SuccessRateOfHistoryCodeScan
            // 
            this.label_SuccessRateOfHistoryCodeScan.AutoSize = true;
            this.label_SuccessRateOfHistoryCodeScan.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SuccessRateOfHistoryCodeScan.Location = new System.Drawing.Point(525, 38);
            this.label_SuccessRateOfHistoryCodeScan.Name = "label_SuccessRateOfHistoryCodeScan";
            this.label_SuccessRateOfHistoryCodeScan.Size = new System.Drawing.Size(69, 20);
            this.label_SuccessRateOfHistoryCodeScan.TabIndex = 9;
            this.label_SuccessRateOfHistoryCodeScan.Text = "00.00%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Green;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(371, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "历史扫码成功率";
            // 
            // label_SuccessRateOfCurrentCodeScan
            // 
            this.label_SuccessRateOfCurrentCodeScan.AutoSize = true;
            this.label_SuccessRateOfCurrentCodeScan.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SuccessRateOfCurrentCodeScan.Location = new System.Drawing.Point(230, 38);
            this.label_SuccessRateOfCurrentCodeScan.Name = "label_SuccessRateOfCurrentCodeScan";
            this.label_SuccessRateOfCurrentCodeScan.Size = new System.Drawing.Size(69, 20);
            this.label_SuccessRateOfCurrentCodeScan.TabIndex = 7;
            this.label_SuccessRateOfCurrentCodeScan.Text = "00.00%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(76, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "本次扫码成功率";
            // 
            // lable_CodeReaderMessage
            // 
            this.lable_CodeReaderMessage.AutoSize = true;
            this.lable_CodeReaderMessage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable_CodeReaderMessage.Location = new System.Drawing.Point(121, 1);
            this.lable_CodeReaderMessage.Name = "lable_CodeReaderMessage";
            this.lable_CodeReaderMessage.Size = new System.Drawing.Size(169, 20);
            this.lable_CodeReaderMessage.TabIndex = 5;
            this.lable_CodeReaderMessage.Text = "扫码信息：未扫码";
            // 
            // label_Cam1Result
            // 
            this.label_Cam1Result.AutoSize = true;
            this.label_Cam1Result.BackColor = System.Drawing.Color.Green;
            this.label_Cam1Result.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Cam1Result.Location = new System.Drawing.Point(76, 0);
            this.label_Cam1Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Cam1Result.Name = "label_Cam1Result";
            this.label_Cam1Result.Size = new System.Drawing.Size(29, 20);
            this.label_Cam1Result.TabIndex = 4;
            this.label_Cam1Result.Text = "OK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "相机1";
            // 
            // vmRenderControlCam1
            // 
            this.vmRenderControlCam1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControlCam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControlCam1.ImageSource = null;
            this.vmRenderControlCam1.Location = new System.Drawing.Point(0, 0);
            this.vmRenderControlCam1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmRenderControlCam1.ModuleSource = null;
            this.vmRenderControlCam1.Name = "vmRenderControlCam1";
            this.vmRenderControlCam1.Size = new System.Drawing.Size(648, 580);
            this.vmRenderControlCam1.TabIndex = 1;
            // 
            // label_ModelMatchResult
            // 
            this.label_ModelMatchResult.AutoSize = true;
            this.label_ModelMatchResult.BackColor = System.Drawing.Color.Green;
            this.label_ModelMatchResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ModelMatchResult.Location = new System.Drawing.Point(105, 0);
            this.label_ModelMatchResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ModelMatchResult.Name = "label_ModelMatchResult";
            this.label_ModelMatchResult.Size = new System.Drawing.Size(49, 20);
            this.label_ModelMatchResult.TabIndex = 6;
            this.label_ModelMatchResult.Text = "正面";
            // 
            // label_Cam2Result
            // 
            this.label_Cam2Result.AutoSize = true;
            this.label_Cam2Result.BackColor = System.Drawing.Color.Green;
            this.label_Cam2Result.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Cam2Result.Location = new System.Drawing.Point(72, 0);
            this.label_Cam2Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Cam2Result.Name = "label_Cam2Result";
            this.label_Cam2Result.Size = new System.Drawing.Size(29, 20);
            this.label_Cam2Result.TabIndex = 5;
            this.label_Cam2Result.Text = "OK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "相机2";
            // 
            // vmRenderControlCam2
            // 
            this.vmRenderControlCam2.BackColor = System.Drawing.Color.Black;
            this.vmRenderControlCam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControlCam2.ImageSource = null;
            this.vmRenderControlCam2.Location = new System.Drawing.Point(0, 0);
            this.vmRenderControlCam2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmRenderControlCam2.ModuleSource = null;
            this.vmRenderControlCam2.Name = "vmRenderControlCam2";
            this.vmRenderControlCam2.Size = new System.Drawing.Size(771, 580);
            this.vmRenderControlCam2.TabIndex = 1;
            this.vmRenderControlCam2.Load += new System.EventHandler(this.vmRenderControl2_Load);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1422, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_LogInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(428, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(992, 143);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志区";
            // 
            // textBox_LogInfo
            // 
            this.textBox_LogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_LogInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_LogInfo.Location = new System.Drawing.Point(2, 16);
            this.textBox_LogInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_LogInfo.Multiline = true;
            this.textBox_LogInfo.Name = "textBox_LogInfo";
            this.textBox_LogInfo.ReadOnly = true;
            this.textBox_LogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_LogInfo.Size = new System.Drawing.Size(988, 125);
            this.textBox_LogInfo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(422, 143);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据显示";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.84173F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.15827F));
            this.tableLayoutPanel2.Controls.Add(this.dgv_DataStatistics, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgv_DataSendToPLC, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(418, 125);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgv_DataStatistics
            // 
            this.dgv_DataStatistics.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_DataStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DataStatistics.Location = new System.Drawing.Point(201, 2);
            this.dgv_DataStatistics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_DataStatistics.Name = "dgv_DataStatistics";
            this.dgv_DataStatistics.RowHeadersWidth = 51;
            this.dgv_DataStatistics.RowTemplate.Height = 27;
            this.dgv_DataStatistics.Size = new System.Drawing.Size(215, 121);
            this.dgv_DataStatistics.TabIndex = 1;
            // 
            // dgv_DataSendToPLC
            // 
            this.dgv_DataSendToPLC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_DataSendToPLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataSendToPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DataSendToPLC.Location = new System.Drawing.Point(2, 2);
            this.dgv_DataSendToPLC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_DataSendToPLC.Name = "dgv_DataSendToPLC";
            this.dgv_DataSendToPLC.RowHeadersWidth = 51;
            this.dgv_DataSendToPLC.RowTemplate.Height = 27;
            this.dgv_DataSendToPLC.Size = new System.Drawing.Size(195, 121);
            this.dgv_DataSendToPLC.TabIndex = 0;
            // 
            // MultiCameraShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MultiCameraShow";
            this.Size = new System.Drawing.Size(1422, 730);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataSendToPLC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private VMControls.Winform.Release.VmRenderControl vmRenderControlCam1;
        private VMControls.Winform.Release.VmRenderControl vmRenderControlCam2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Cam1Result;
        private System.Windows.Forms.Label label_Cam2Result;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgv_DataStatistics;
        private System.Windows.Forms.DataGridView dgv_DataSendToPLC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_LogInfo;
        private System.Windows.Forms.Label label_ModelMatchResult;
        private System.Windows.Forms.Label lable_CodeReaderMessage;
        private System.Windows.Forms.Label label_SuccessRateOfHistoryCodeScan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_SuccessRateOfCurrentCodeScan;
        private System.Windows.Forms.Label label3;
    }
}
