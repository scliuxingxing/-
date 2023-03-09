namespace HikUnLoader.HikFrom
{
    partial class ProgressLoadingDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressLoadingDisplayForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProjectLabel = new System.Windows.Forms.Label();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.LoadLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoadProgressBar
            // 
            this.LoadProgressBar.Location = new System.Drawing.Point(50, 94);
            this.LoadProgressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadProgressBar.Name = "LoadProgressBar";
            this.LoadProgressBar.Size = new System.Drawing.Size(604, 53);
            this.LoadProgressBar.TabIndex = 1;
            // 
            // ProjectLabel
            // 
            this.ProjectLabel.AutoSize = true;
            this.ProjectLabel.Font = new System.Drawing.Font("楷体", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProjectLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ProjectLabel.Location = new System.Drawing.Point(211, 33);
            this.ProjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProjectLabel.Name = "ProjectLabel";
            this.ProjectLabel.Size = new System.Drawing.Size(318, 31);
            this.ProjectLabel.TabIndex = 2;
            this.ProjectLabel.Text = "江川行 视觉检测系统";
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CompanyLabel.Location = new System.Drawing.Point(304, 174);
            this.CompanyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(0, 22);
            this.CompanyLabel.TabIndex = 3;
            // 
            // LoadLabel
            // 
            this.LoadLabel.AutoSize = true;
            this.LoadLabel.Location = new System.Drawing.Point(224, 73);
            this.LoadLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoadLabel.Name = "LoadLabel";
            this.LoadLabel.Size = new System.Drawing.Size(143, 12);
            this.LoadLabel.TabIndex = 4;
            this.LoadLabel.Text = "正在加载程序，请稍等...";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressLabel.Location = new System.Drawing.Point(75, 113);
            this.ProgressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(568, 18);
            this.ProgressLabel.TabIndex = 4;
            this.ProgressLabel.Text = "正在准备......";
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressLoadingDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 213);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.CompanyLabel);
            this.Controls.Add(this.ProjectLabel);
            this.Controls.Add(this.LoadProgressBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProgressLoadingDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar LoadProgressBar;
        private System.Windows.Forms.Label ProjectLabel;
        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.Label LoadLabel;
        private System.Windows.Forms.Label ProgressLabel;
    }
}