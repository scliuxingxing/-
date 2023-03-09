
namespace HikUnLoader.HikFrom
{
    partial class CameraCalibrateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraCalibrateForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.vmDebugControl = new VMControls.Winform.Release.VmParamsConfigWithRenderControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_GetImageFromFile = new System.Windows.Forms.Button();
            this.btn_GetImageFromCam = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_PMATool = new System.Windows.Forms.Button();
            this.btn_CorrectionOfDistortion = new System.Windows.Forms.Button();
            this.btn_CalibrationOfDistortion = new System.Windows.Forms.Button();
            this.btn_VertexTool = new System.Windows.Forms.Button();
            this.btn_Generate12PointCalibFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Calib = new System.Windows.Forms.CheckBox();
            this.tb_Point = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1594, 1044);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机调试界面";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.vmDebugControl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tb_Point, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.44921F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.55079F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1588, 1019);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // vmDebugControl
            // 
            this.vmDebugControl.BackColor = System.Drawing.Color.White;
            this.vmDebugControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmDebugControl.ImageSource = null;
            this.vmDebugControl.Location = new System.Drawing.Point(6, 146);
            this.vmDebugControl.Margin = new System.Windows.Forms.Padding(6);
            this.vmDebugControl.ModuleSource = null;
            this.vmDebugControl.Name = "vmDebugControl";
            this.vmDebugControl.ParamsConfig = null;
            this.vmDebugControl.ROIVisible = true;
            this.vmDebugControl.Size = new System.Drawing.Size(1576, 816);
            this.vmDebugControl.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.38078F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.61922F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1582, 136);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(448, 132);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图像获取功能区";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btn_GetImageFromFile, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_GetImageFromCam, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(442, 107);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btn_GetImageFromFile
            // 
            this.btn_GetImageFromFile.BackColor = System.Drawing.Color.Orange;
            this.btn_GetImageFromFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_GetImageFromFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GetImageFromFile.Location = new System.Drawing.Point(224, 2);
            this.btn_GetImageFromFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GetImageFromFile.Name = "btn_GetImageFromFile";
            this.btn_GetImageFromFile.Size = new System.Drawing.Size(215, 103);
            this.btn_GetImageFromFile.TabIndex = 1;
            this.btn_GetImageFromFile.Text = "从文件获取图像";
            this.btn_GetImageFromFile.UseVisualStyleBackColor = false;
            this.btn_GetImageFromFile.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_GetImageFromCam
            // 
            this.btn_GetImageFromCam.BackColor = System.Drawing.Color.Orange;
            this.btn_GetImageFromCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_GetImageFromCam.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GetImageFromCam.Location = new System.Drawing.Point(3, 2);
            this.btn_GetImageFromCam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GetImageFromCam.Name = "btn_GetImageFromCam";
            this.btn_GetImageFromCam.Size = new System.Drawing.Size(215, 103);
            this.btn_GetImageFromCam.TabIndex = 0;
            this.btn_GetImageFromCam.Text = "从相机获取图像";
            this.btn_GetImageFromCam.UseVisualStyleBackColor = false;
            this.btn_GetImageFromCam.Click += new System.EventHandler(this.bt_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(457, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(902, 132);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "算法功能区";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btn_PMATool, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_CorrectionOfDistortion, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_CalibrationOfDistortion, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_VertexTool, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_Generate12PointCalibFile, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(896, 107);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btn_PMATool
            // 
            this.btn_PMATool.BackColor = System.Drawing.Color.Orange;
            this.btn_PMATool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PMATool.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PMATool.Location = new System.Drawing.Point(361, 2);
            this.btn_PMATool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_PMATool.Name = "btn_PMATool";
            this.btn_PMATool.Size = new System.Drawing.Size(173, 103);
            this.btn_PMATool.TabIndex = 20;
            this.btn_PMATool.Text = "模板匹配";
            this.btn_PMATool.UseVisualStyleBackColor = false;
            this.btn_PMATool.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_CorrectionOfDistortion
            // 
            this.btn_CorrectionOfDistortion.BackColor = System.Drawing.Color.Orange;
            this.btn_CorrectionOfDistortion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CorrectionOfDistortion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CorrectionOfDistortion.Location = new System.Drawing.Point(182, 2);
            this.btn_CorrectionOfDistortion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_CorrectionOfDistortion.Name = "btn_CorrectionOfDistortion";
            this.btn_CorrectionOfDistortion.Size = new System.Drawing.Size(173, 103);
            this.btn_CorrectionOfDistortion.TabIndex = 19;
            this.btn_CorrectionOfDistortion.Text = "畸变校正";
            this.btn_CorrectionOfDistortion.UseVisualStyleBackColor = false;
            this.btn_CorrectionOfDistortion.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_CalibrationOfDistortion
            // 
            this.btn_CalibrationOfDistortion.BackColor = System.Drawing.Color.Orange;
            this.btn_CalibrationOfDistortion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CalibrationOfDistortion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CalibrationOfDistortion.Location = new System.Drawing.Point(3, 2);
            this.btn_CalibrationOfDistortion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_CalibrationOfDistortion.Name = "btn_CalibrationOfDistortion";
            this.btn_CalibrationOfDistortion.Size = new System.Drawing.Size(173, 103);
            this.btn_CalibrationOfDistortion.TabIndex = 3;
            this.btn_CalibrationOfDistortion.Text = "畸变标定";
            this.btn_CalibrationOfDistortion.UseVisualStyleBackColor = false;
            this.btn_CalibrationOfDistortion.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_VertexTool
            // 
            this.btn_VertexTool.BackColor = System.Drawing.Color.Orange;
            this.btn_VertexTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_VertexTool.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_VertexTool.Location = new System.Drawing.Point(540, 2);
            this.btn_VertexTool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_VertexTool.Name = "btn_VertexTool";
            this.btn_VertexTool.Size = new System.Drawing.Size(173, 103);
            this.btn_VertexTool.TabIndex = 17;
            this.btn_VertexTool.Text = "顶点工具";
            this.btn_VertexTool.UseVisualStyleBackColor = false;
            this.btn_VertexTool.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_Generate12PointCalibFile
            // 
            this.btn_Generate12PointCalibFile.BackColor = System.Drawing.Color.Orange;
            this.btn_Generate12PointCalibFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Generate12PointCalibFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Generate12PointCalibFile.Location = new System.Drawing.Point(719, 2);
            this.btn_Generate12PointCalibFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Generate12PointCalibFile.Name = "btn_Generate12PointCalibFile";
            this.btn_Generate12PointCalibFile.Size = new System.Drawing.Size(174, 103);
            this.btn_Generate12PointCalibFile.TabIndex = 18;
            this.btn_Generate12PointCalibFile.Text = "生成12点标定文件";
            this.btn_Generate12PointCalibFile.UseVisualStyleBackColor = false;
            this.btn_Generate12PointCalibFile.Click += new System.EventHandler(this.bt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_text);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cb_Calib);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(1365, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(214, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自动标定";
            // 
            // lb_text
            // 
            this.lb_text.AutoSize = true;
            this.lb_text.Location = new System.Drawing.Point(120, 73);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(17, 18);
            this.lb_text.TabIndex = 2;
            this.lb_text.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "标定计数";
            // 
            // cb_Calib
            // 
            this.cb_Calib.AutoSize = true;
            this.cb_Calib.Location = new System.Drawing.Point(6, 29);
            this.cb_Calib.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Calib.Name = "cb_Calib";
            this.cb_Calib.Size = new System.Drawing.Size(178, 22);
            this.cb_Calib.TabIndex = 0;
            this.cb_Calib.Text = "允许自动12点标定";
            this.cb_Calib.UseVisualStyleBackColor = true;
            this.cb_Calib.CheckedChanged += new System.EventHandler(this.cb_Calib_CheckedChanged);
            // 
            // tb_Point
            // 
            this.tb_Point.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Point.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Point.Location = new System.Drawing.Point(3, 970);
            this.tb_Point.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Point.Multiline = true;
            this.tb_Point.Name = "tb_Point";
            this.tb_Point.ReadOnly = true;
            this.tb_Point.Size = new System.Drawing.Size(1582, 47);
            this.tb_Point.TabIndex = 2;
            this.tb_Point.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CameraCalibrateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 1044);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraCalibrateForm";
            this.Text = "相机标定调试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraDubugFrom_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private VMControls.Winform.Release.VmParamsConfigWithRenderControl vmDebugControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btn_GetImageFromFile;
        private System.Windows.Forms.Button btn_GetImageFromCam;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox tb_Point;
        private System.Windows.Forms.Button btn_CalibrationOfDistortion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_Calib;
        private System.Windows.Forms.Button btn_VertexTool;
        private System.Windows.Forms.Button btn_Generate12PointCalibFile;
        private System.Windows.Forms.Button btn_PMATool;
        private System.Windows.Forms.Button btn_CorrectionOfDistortion;
    }
}