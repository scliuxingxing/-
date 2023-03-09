
namespace HikUnLoader.HikFrom
{
    partial class CamerConfigureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamerConfigureForm));
            this.vmDebugControl = new VMControls.Winform.Release.VmParamsConfigWithRenderControl();
            this.SuspendLayout();
            // 
            // vmDebugControl
            // 
            this.vmDebugControl.BackColor = System.Drawing.Color.White;
            this.vmDebugControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmDebugControl.ImageSource = null;
            this.vmDebugControl.Location = new System.Drawing.Point(0, 0);
            this.vmDebugControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmDebugControl.ModuleSource = null;
            this.vmDebugControl.Name = "vmDebugControl";
            this.vmDebugControl.ParamsConfig = null;
            this.vmDebugControl.ROIVisible = true;
            this.vmDebugControl.Size = new System.Drawing.Size(1279, 671);
            this.vmDebugControl.TabIndex = 2;
            // 
            // CamerPZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 671);
            this.Controls.Add(this.vmDebugControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CamerPZ";
            this.Text = "相机配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CamerPZ_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private VMControls.Winform.Release.VmParamsConfigWithRenderControl vmDebugControl;
    }
}