namespace HikUnLoader.HikControl
{
    partial class CustomStatusStrip
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsl_SoftwareVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_CurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_Cam1CT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_Cam2CT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_Cam3CT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_Cam4CTLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AllCameraElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_PLCStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_CommStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.spaceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_SoftwareVersion,
            this.tsl_CurrentUser,
            this.tsl_Cam1CT,
            this.tsl_Cam2CT,
            this.tsl_Cam3CT,
            this.tsl_Cam4CTLabel,
            this.AllCameraElapsedTime,
            this.tsl_PLCStatus,
            this.tsl_CommStatus,
            this.spaceLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1508, 29);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsl_SoftwareVersion
            // 
            this.tsl_SoftwareVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_SoftwareVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_SoftwareVersion.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_SoftwareVersion.Name = "tsl_SoftwareVersion";
            this.tsl_SoftwareVersion.Size = new System.Drawing.Size(210, 23);
            this.tsl_SoftwareVersion.Text = "Software Version:0.0.0";
            // 
            // tsl_CurrentUser
            // 
            this.tsl_CurrentUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_CurrentUser.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_CurrentUser.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_CurrentUser.Name = "tsl_CurrentUser";
            this.tsl_CurrentUser.Size = new System.Drawing.Size(97, 23);
            this.tsl_CurrentUser.Text = "当前用户：";
            // 
            // tsl_Cam1CT
            // 
            this.tsl_Cam1CT.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_Cam1CT.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_Cam1CT.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_Cam1CT.Name = "tsl_Cam1CT";
            this.tsl_Cam1CT.Size = new System.Drawing.Size(129, 23);
            this.tsl_Cam1CT.Text = "Cam1_CT:0.00s";
            // 
            // tsl_Cam2CT
            // 
            this.tsl_Cam2CT.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_Cam2CT.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_Cam2CT.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_Cam2CT.Name = "tsl_Cam2CT";
            this.tsl_Cam2CT.Size = new System.Drawing.Size(129, 23);
            this.tsl_Cam2CT.Text = "Cam2_CT:0.00s";
            // 
            // tsl_Cam3CT
            // 
            this.tsl_Cam3CT.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_Cam3CT.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_Cam3CT.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_Cam3CT.Name = "tsl_Cam3CT";
            this.tsl_Cam3CT.Size = new System.Drawing.Size(129, 23);
            this.tsl_Cam3CT.Text = "Cam3_CT:0.00s";
            // 
            // tsl_Cam4CTLabel
            // 
            this.tsl_Cam4CTLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_Cam4CTLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_Cam4CTLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_Cam4CTLabel.Name = "tsl_Cam4CTLabel";
            this.tsl_Cam4CTLabel.Size = new System.Drawing.Size(129, 23);
            this.tsl_Cam4CTLabel.Text = "Cam4_CT:0.00s";
            // 
            // AllCameraElapsedTime
            // 
            this.AllCameraElapsedTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.AllCameraElapsedTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.AllCameraElapsedTime.Font = new System.Drawing.Font("宋体", 10F);
            this.AllCameraElapsedTime.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.AllCameraElapsedTime.Name = "AllCameraElapsedTime";
            this.AllCameraElapsedTime.Size = new System.Drawing.Size(114, 24);
            this.AllCameraElapsedTime.Text = "模拟运行耗时";
            this.AllCameraElapsedTime.Visible = false;
            // 
            // tsl_PLCStatus
            // 
            this.tsl_PLCStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_PLCStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_PLCStatus.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_PLCStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsl_PLCStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.tsl_PLCStatus.Name = "tsl_PLCStatus";
            this.tsl_PLCStatus.Size = new System.Drawing.Size(80, 24);
            this.tsl_PLCStatus.Text = "通信状态";
            // 
            // tsl_CommStatus
            // 
            this.tsl_CommStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsl_CommStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tsl_CommStatus.Font = new System.Drawing.Font("宋体", 10F);
            this.tsl_CommStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsl_CommStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.tsl_CommStatus.Name = "tsl_CommStatus";
            this.tsl_CommStatus.Size = new System.Drawing.Size(80, 24);
            this.tsl_CommStatus.Text = "通信状态";
            this.tsl_CommStatus.Visible = false;
            // 
            // spaceLabel
            // 
            this.spaceLabel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(17, 24);
            this.spaceLabel.Text = "  ";
            // 
            // StatusStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StatusStrip";
            this.Size = new System.Drawing.Size(1508, 29);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsl_SoftwareVersion;
        private System.Windows.Forms.ToolStripStatusLabel tsl_CurrentUser;
        private System.Windows.Forms.ToolStripStatusLabel tsl_Cam1CT;
        private System.Windows.Forms.ToolStripStatusLabel AllCameraElapsedTime;
        private System.Windows.Forms.ToolStripStatusLabel tsl_CommStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsl_Cam2CT;
        private System.Windows.Forms.ToolStripStatusLabel tsl_Cam3CT;
        private System.Windows.Forms.ToolStripStatusLabel tsl_Cam4CTLabel;
        private System.Windows.Forms.ToolStripStatusLabel spaceLabel;
        private System.Windows.Forms.ToolStripStatusLabel tsl_PLCStatus;
    }
}
