namespace HikUnLoader.HikControl
{
    partial class UserLoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLoginForm));
            this.PasswordModify = new System.Windows.Forms.Button();
            this.SecondPassword = new System.Windows.Forms.TextBox();
            this.NewPassword = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.ComboBox();
            this.UserPassword = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.ConfirmModify = new System.Windows.Forms.Button();
            this.UserLogIn = new System.Windows.Forms.Button();
            this.UserLogBox = new System.Windows.Forms.GroupBox();
            this.PasswordModfyBox = new System.Windows.Forms.GroupBox();
            this.ClosedForm = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.UserLogBox.SuspendLayout();
            this.PasswordModfyBox.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PasswordModify
            // 
            this.PasswordModify.Location = new System.Drawing.Point(238, 55);
            this.PasswordModify.Name = "PasswordModify";
            this.PasswordModify.Size = new System.Drawing.Size(75, 23);
            this.PasswordModify.TabIndex = 28;
            this.PasswordModify.Text = "密码修改";
            this.PasswordModify.UseVisualStyleBackColor = true;
            this.PasswordModify.Click += new System.EventHandler(this.PasswordModify_Click);
            // 
            // SecondPassword
            // 
            this.SecondPassword.Location = new System.Drawing.Point(100, 57);
            this.SecondPassword.Name = "SecondPassword";
            this.SecondPassword.PasswordChar = '*';
            this.SecondPassword.Size = new System.Drawing.Size(114, 21);
            this.SecondPassword.TabIndex = 26;
            // 
            // NewPassword
            // 
            this.NewPassword.Location = new System.Drawing.Point(100, 24);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.PasswordChar = '*';
            this.NewPassword.Size = new System.Drawing.Size(114, 21);
            this.NewPassword.TabIndex = 27;
            // 
            // UserName
            // 
            this.UserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserName.FormattingEnabled = true;
            this.UserName.Items.AddRange(new object[] {
            "调试员",
            "操作员",
            "管理员"});
            this.UserName.Location = new System.Drawing.Point(100, 21);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(114, 20);
            this.UserName.TabIndex = 24;
            this.UserName.SelectedIndexChanged += new System.EventHandler(this.UserName_SelectedIndexChanged);
            // 
            // UserPassword
            // 
            this.UserPassword.Location = new System.Drawing.Point(100, 57);
            this.UserPassword.Name = "UserPassword";
            this.UserPassword.PasswordChar = '*';
            this.UserPassword.Size = new System.Drawing.Size(114, 21);
            this.UserPassword.TabIndex = 25;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label2.Location = new System.Drawing.Point(5, 21);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 18);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "用 户 名";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label4.Location = new System.Drawing.Point(5, 58);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 18);
            this.Label4.TabIndex = 19;
            this.Label4.Text = "确认密码";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label3.Location = new System.Drawing.Point(5, 25);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 18);
            this.Label3.TabIndex = 20;
            this.Label3.Text = "新 密 码";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Location = new System.Drawing.Point(5, 58);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 18);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "密   码";
            // 
            // ConfirmModify
            // 
            this.ConfirmModify.Location = new System.Drawing.Point(238, 22);
            this.ConfirmModify.Name = "ConfirmModify";
            this.ConfirmModify.Size = new System.Drawing.Size(75, 23);
            this.ConfirmModify.TabIndex = 22;
            this.ConfirmModify.Text = "确认修改";
            this.ConfirmModify.UseVisualStyleBackColor = true;
            this.ConfirmModify.Click += new System.EventHandler(this.ConfirmModify_Click);
            // 
            // UserLogIn
            // 
            this.UserLogIn.Location = new System.Drawing.Point(238, 18);
            this.UserLogIn.Name = "UserLogIn";
            this.UserLogIn.Size = new System.Drawing.Size(75, 23);
            this.UserLogIn.TabIndex = 18;
            this.UserLogIn.Text = "登 入";
            this.UserLogIn.UseVisualStyleBackColor = true;
            this.UserLogIn.Click += new System.EventHandler(this.UserLogIn_Click);
            // 
            // UserLogBox
            // 
            this.UserLogBox.Controls.Add(this.Label2);
            this.UserLogBox.Controls.Add(this.PasswordModify);
            this.UserLogBox.Controls.Add(this.UserLogIn);
            this.UserLogBox.Controls.Add(this.Label1);
            this.UserLogBox.Controls.Add(this.UserPassword);
            this.UserLogBox.Controls.Add(this.UserName);
            this.UserLogBox.Location = new System.Drawing.Point(12, 10);
            this.UserLogBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserLogBox.Name = "UserLogBox";
            this.UserLogBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserLogBox.Size = new System.Drawing.Size(321, 90);
            this.UserLogBox.TabIndex = 29;
            this.UserLogBox.TabStop = false;
            this.UserLogBox.Text = "用户登录";
            // 
            // PasswordModfyBox
            // 
            this.PasswordModfyBox.Controls.Add(this.Label3);
            this.PasswordModfyBox.Controls.Add(this.ConfirmModify);
            this.PasswordModfyBox.Controls.Add(this.SecondPassword);
            this.PasswordModfyBox.Controls.Add(this.Label4);
            this.PasswordModfyBox.Controls.Add(this.NewPassword);
            this.PasswordModfyBox.Location = new System.Drawing.Point(12, 113);
            this.PasswordModfyBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordModfyBox.Name = "PasswordModfyBox";
            this.PasswordModfyBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordModfyBox.Size = new System.Drawing.Size(321, 90);
            this.PasswordModfyBox.TabIndex = 30;
            this.PasswordModfyBox.TabStop = false;
            this.PasswordModfyBox.Text = "用户修改密码";
            // 
            // ClosedForm
            // 
            this.ClosedForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ClosedForm.Location = new System.Drawing.Point(250, 264);
            this.ClosedForm.Name = "ClosedForm";
            this.ClosedForm.Size = new System.Drawing.Size(75, 23);
            this.ClosedForm.TabIndex = 22;
            this.ClosedForm.Text = "关闭窗口";
            this.ClosedForm.UseVisualStyleBackColor = true;
            this.ClosedForm.Click += new System.EventHandler(this.ClosedForm_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(124, 22);
            this.Help.Text = "帮助提示";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // UserForm
            // 
            this.AcceptButton = this.UserLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ClosedForm;
            this.ClientSize = new System.Drawing.Size(343, 210);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.PasswordModfyBox);
            this.Controls.Add(this.ClosedForm);
            this.Controls.Add(this.UserLogBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.UserLogBox.ResumeLayout(false);
            this.UserLogBox.PerformLayout();
            this.PasswordModfyBox.ResumeLayout(false);
            this.PasswordModfyBox.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button PasswordModify;
        internal System.Windows.Forms.TextBox SecondPassword;
        internal System.Windows.Forms.TextBox NewPassword;
        internal System.Windows.Forms.ComboBox UserName;
        internal System.Windows.Forms.TextBox UserPassword;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button ConfirmModify;
        internal System.Windows.Forms.Button UserLogIn;
        private System.Windows.Forms.GroupBox UserLogBox;
        private System.Windows.Forms.GroupBox PasswordModfyBox;
        internal System.Windows.Forms.Button ClosedForm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Help;
    }
}