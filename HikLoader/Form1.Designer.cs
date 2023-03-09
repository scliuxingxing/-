using HikUnLoader.HikControl;

namespace HikUnLoader
{
    partial class mainFrom
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrom));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuTool1 = new HikUnLoader.HikControl.MenuTool();
            this.multiCameraShow = new HikUnLoader.HikControl.MultiCameraShow();
            this.CustomStatusStrip_StatusDisplay = new HikUnLoader.HikControl.CustomStatusStrip();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuTool1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.multiCameraShow, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CustomStatusStrip_StatusDisplay, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1277, 700);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuTool1
            // 
            this.menuTool1.BackColor = System.Drawing.SystemColors.Control;
            this.menuTool1.CameraNum = 0;
            this.menuTool1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTool1.Location = new System.Drawing.Point(1, 1);
            this.menuTool1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.menuTool1.Name = "menuTool1";
            this.menuTool1.Running = false;
            this.menuTool1.Size = new System.Drawing.Size(1275, 54);
            this.menuTool1.TabIndex = 0;
            this.menuTool1.UserID = HikUnLoader.HikControl.LogUser.操作员;
            // 
            // multiCameraShow
            // 
            this.multiCameraShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiCameraShow.Location = new System.Drawing.Point(1, 57);
            this.multiCameraShow.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.multiCameraShow.Name = "multiCameraShow";
            this.multiCameraShow.Size = new System.Drawing.Size(1275, 621);
            this.multiCameraShow.TabIndex = 2;
            // 
            // CustomStatusStrip_StatusDisplay
            // 
            this.CustomStatusStrip_StatusDisplay.CurrentUser = HikUnLoader.HikControl.LogUser.无用户;
            this.CustomStatusStrip_StatusDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomStatusStrip_StatusDisplay.Location = new System.Drawing.Point(2, 680);
            this.CustomStatusStrip_StatusDisplay.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CustomStatusStrip_StatusDisplay.Name = "CustomStatusStrip_StatusDisplay";
            this.CustomStatusStrip_StatusDisplay.ShowAllSimulateTime = false;
            this.CustomStatusStrip_StatusDisplay.ShowCommStatus = false;
            this.CustomStatusStrip_StatusDisplay.ShowPLCStatus = true;
            this.CustomStatusStrip_StatusDisplay.Size = new System.Drawing.Size(1273, 19);
            this.CustomStatusStrip_StatusDisplay.TabIndex = 3;
            // 
            // mainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "mainFrom";
            this.Text = "UnLoader视觉系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFrom_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainFrom_FormClosed);
            this.Load += new System.EventHandler(this.mainFrom_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HikControl.MenuTool menuTool1;
        private HikControl.MultiCameraShow multiCameraShow;
        private CustomStatusStrip CustomStatusStrip_StatusDisplay;
    }
}

