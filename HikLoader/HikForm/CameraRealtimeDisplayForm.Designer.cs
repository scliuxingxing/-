
namespace HikUnLoader.HikFrom
{
    partial class CameraRealtimeDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraRealtimeDisplayForm));
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_ExposureTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nud_Gain = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExposureTime)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Gain)).BeginInit();
            this.SuspendLayout();
            // 
            // vmRenderControl1
            // 
            this.vmRenderControl1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl1.ImageSource = null;
            this.vmRenderControl1.Location = new System.Drawing.Point(0, 0);
            this.vmRenderControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(1468, 876);
            this.vmRenderControl1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_ExposureTime);
            this.groupBox1.Location = new System.Drawing.Point(0, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(168, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "曝光时间";
            // 
            // nud_ExposureTime
            // 
            this.nud_ExposureTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_ExposureTime.Location = new System.Drawing.Point(3, 25);
            this.nud_ExposureTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_ExposureTime.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_ExposureTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ExposureTime.Name = "nud_ExposureTime";
            this.nud_ExposureTime.Size = new System.Drawing.Size(162, 28);
            this.nud_ExposureTime.TabIndex = 0;
            this.nud_ExposureTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ExposureTime.ValueChanged += new System.EventHandler(this.nud_ExposureTime_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_Gain);
            this.groupBox2.Location = new System.Drawing.Point(0, 77);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(168, 76);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "增益";
            // 
            // nud_Gain
            // 
            this.nud_Gain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_Gain.Location = new System.Drawing.Point(3, 25);
            this.nud_Gain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_Gain.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Gain.Name = "nud_Gain";
            this.nud_Gain.Size = new System.Drawing.Size(162, 28);
            this.nud_Gain.TabIndex = 0;
            this.nud_Gain.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Gain.ValueChanged += new System.EventHandler(this.nud_ExposureTime_ValueChanged);
            // 
            // CameraRealtimeDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 876);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vmRenderControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CameraRealtimeDisplayForm";
            this.Text = "相机实时窗体";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraRealTimeForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_ExposureTime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Gain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nud_ExposureTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nud_Gain;
    }
}