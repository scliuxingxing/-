namespace HikUnLoader.HikControl
{
    partial class DocumentParameter
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
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.btn_ChoosImageSavePath = new System.Windows.Forms.Button();
            this.btn_ChooseDataSavePath = new System.Windows.Forms.Button();
            this.textBox_ImageSavePath = new System.Windows.Forms.TextBox();
            this.textBox_DataSavePath = new System.Windows.Forms.TextBox();
            this.MaxSaveImageLabel = new System.Windows.Forms.Label();
            this.nud_MaxSaveImage = new System.Windows.Forms.NumericUpDown();
            this.checkbox_ImageSaveMode = new System.Windows.Forms.CheckBox();
            this.checkBox_DataSaveMode = new System.Windows.Forms.CheckBox();
            this.label_ImageSavePath = new System.Windows.Forms.Label();
            this.label_DataSavePath = new System.Windows.Forms.Label();
            this.MainBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxSaveImage)).BeginInit();
            this.SuspendLayout();
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.btn_ChoosImageSavePath);
            this.MainBox.Controls.Add(this.btn_ChooseDataSavePath);
            this.MainBox.Controls.Add(this.textBox_ImageSavePath);
            this.MainBox.Controls.Add(this.textBox_DataSavePath);
            this.MainBox.Controls.Add(this.MaxSaveImageLabel);
            this.MainBox.Controls.Add(this.nud_MaxSaveImage);
            this.MainBox.Controls.Add(this.checkbox_ImageSaveMode);
            this.MainBox.Controls.Add(this.checkBox_DataSaveMode);
            this.MainBox.Controls.Add(this.label_ImageSavePath);
            this.MainBox.Controls.Add(this.label_DataSavePath);
            this.MainBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainBox.Location = new System.Drawing.Point(0, 0);
            this.MainBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainBox.Name = "MainBox";
            this.MainBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainBox.Size = new System.Drawing.Size(680, 136);
            this.MainBox.TabIndex = 19;
            this.MainBox.TabStop = false;
            this.MainBox.Text = "文件参数";
            // 
            // btn_ChoosImageSavePath
            // 
            this.btn_ChoosImageSavePath.Location = new System.Drawing.Point(626, 30);
            this.btn_ChoosImageSavePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ChoosImageSavePath.Name = "btn_ChoosImageSavePath";
            this.btn_ChoosImageSavePath.Size = new System.Drawing.Size(42, 34);
            this.btn_ChoosImageSavePath.TabIndex = 20;
            this.btn_ChoosImageSavePath.Text = "<<";
            this.btn_ChoosImageSavePath.UseVisualStyleBackColor = true;
            this.btn_ChoosImageSavePath.Click += new System.EventHandler(this.btn_ChoosImageSavePath_Click);
            // 
            // btn_ChooseDataSavePath
            // 
            this.btn_ChooseDataSavePath.Location = new System.Drawing.Point(288, 30);
            this.btn_ChooseDataSavePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ChooseDataSavePath.Name = "btn_ChooseDataSavePath";
            this.btn_ChooseDataSavePath.Size = new System.Drawing.Size(42, 34);
            this.btn_ChooseDataSavePath.TabIndex = 19;
            this.btn_ChooseDataSavePath.Text = "<<";
            this.btn_ChooseDataSavePath.UseVisualStyleBackColor = true;
            this.btn_ChooseDataSavePath.Click += new System.EventHandler(this.btn_ChooseDataSavePath_Click);
            // 
            // textBox_ImageSavePath
            // 
            this.textBox_ImageSavePath.Enabled = false;
            this.textBox_ImageSavePath.Location = new System.Drawing.Point(474, 32);
            this.textBox_ImageSavePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ImageSavePath.Name = "textBox_ImageSavePath";
            this.textBox_ImageSavePath.ReadOnly = true;
            this.textBox_ImageSavePath.Size = new System.Drawing.Size(145, 28);
            this.textBox_ImageSavePath.TabIndex = 18;
            // 
            // textBox_DataSavePath
            // 
            this.textBox_DataSavePath.Enabled = false;
            this.textBox_DataSavePath.Location = new System.Drawing.Point(136, 32);
            this.textBox_DataSavePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_DataSavePath.Name = "textBox_DataSavePath";
            this.textBox_DataSavePath.ReadOnly = true;
            this.textBox_DataSavePath.Size = new System.Drawing.Size(145, 28);
            this.textBox_DataSavePath.TabIndex = 9;
            // 
            // MaxSaveImageLabel
            // 
            this.MaxSaveImageLabel.AutoSize = true;
            this.MaxSaveImageLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaxSaveImageLabel.Location = new System.Drawing.Point(332, 91);
            this.MaxSaveImageLabel.Name = "MaxSaveImageLabel";
            this.MaxSaveImageLabel.Size = new System.Drawing.Size(157, 21);
            this.MaxSaveImageLabel.TabIndex = 0;
            this.MaxSaveImageLabel.Text = "最大保存图片数";
            this.MaxSaveImageLabel.Visible = false;
            // 
            // nud_MaxSaveImage
            // 
            this.nud_MaxSaveImage.Location = new System.Drawing.Point(522, 88);
            this.nud_MaxSaveImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_MaxSaveImage.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nud_MaxSaveImage.Name = "nud_MaxSaveImage";
            this.nud_MaxSaveImage.Size = new System.Drawing.Size(146, 28);
            this.nud_MaxSaveImage.TabIndex = 5;
            this.nud_MaxSaveImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_MaxSaveImage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MaxSaveImage.Visible = false;
            // 
            // checkbox_ImageSaveMode
            // 
            this.checkbox_ImageSaveMode.AutoSize = true;
            this.checkbox_ImageSaveMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkbox_ImageSaveMode.Location = new System.Drawing.Point(174, 91);
            this.checkbox_ImageSaveMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkbox_ImageSaveMode.Name = "checkbox_ImageSaveMode";
            this.checkbox_ImageSaveMode.Size = new System.Drawing.Size(141, 25);
            this.checkbox_ImageSaveMode.TabIndex = 4;
            this.checkbox_ImageSaveMode.Text = "不保存图像";
            this.checkbox_ImageSaveMode.ThreeState = true;
            this.checkbox_ImageSaveMode.UseVisualStyleBackColor = true;
            this.checkbox_ImageSaveMode.CheckStateChanged += new System.EventHandler(this.checkbox_ImageSaveMode_CheckedStateChanged);
            // 
            // checkBox_DataSaveMode
            // 
            this.checkBox_DataSaveMode.AutoSize = true;
            this.checkBox_DataSaveMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_DataSaveMode.Location = new System.Drawing.Point(6, 91);
            this.checkBox_DataSaveMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_DataSaveMode.Name = "checkBox_DataSaveMode";
            this.checkBox_DataSaveMode.Size = new System.Drawing.Size(162, 25);
            this.checkBox_DataSaveMode.TabIndex = 2;
            this.checkBox_DataSaveMode.Text = "自动保存数据";
            this.checkBox_DataSaveMode.UseVisualStyleBackColor = true;
            this.checkBox_DataSaveMode.CheckStateChanged += new System.EventHandler(this.checkBox_DataSaveMode_CheckedStateChanged);
            // 
            // label_ImageSavePath
            // 
            this.label_ImageSavePath.AutoSize = true;
            this.label_ImageSavePath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ImageSavePath.Location = new System.Drawing.Point(332, 35);
            this.label_ImageSavePath.Name = "label_ImageSavePath";
            this.label_ImageSavePath.Size = new System.Drawing.Size(136, 21);
            this.label_ImageSavePath.TabIndex = 1;
            this.label_ImageSavePath.Text = "图片保存路径";
            // 
            // label_DataSavePath
            // 
            this.label_DataSavePath.AutoSize = true;
            this.label_DataSavePath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DataSavePath.Location = new System.Drawing.Point(-4, 35);
            this.label_DataSavePath.Name = "label_DataSavePath";
            this.label_DataSavePath.Size = new System.Drawing.Size(136, 21);
            this.label_DataSavePath.TabIndex = 0;
            this.label_DataSavePath.Text = "数据保存路径";
            // 
            // DocumentParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DocumentParameter";
            this.Size = new System.Drawing.Size(680, 136);
            this.MainBox.ResumeLayout(false);
            this.MainBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxSaveImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainBox;
        private System.Windows.Forms.Button btn_ChoosImageSavePath;
        private System.Windows.Forms.Button btn_ChooseDataSavePath;
        private System.Windows.Forms.TextBox textBox_ImageSavePath;
        private System.Windows.Forms.TextBox textBox_DataSavePath;
        private System.Windows.Forms.Label MaxSaveImageLabel;
        private System.Windows.Forms.NumericUpDown nud_MaxSaveImage;
        private System.Windows.Forms.CheckBox checkbox_ImageSaveMode;
        private System.Windows.Forms.CheckBox checkBox_DataSaveMode;
        private System.Windows.Forms.Label label_ImageSavePath;
        private System.Windows.Forms.Label label_DataSavePath;
    }
}
