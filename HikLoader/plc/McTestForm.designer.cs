namespace HikUnLoader.plc
{ 
    partial class McProtocolTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(McProtocolTestForm));
            this.grp_RcvData = new System.Windows.Forms.GroupBox();
            this.txt_ReceiveData = new System.Windows.Forms.TextBox();
            this.grp_IPConfigGroup = new System.Windows.Forms.GroupBox();
            this.txt_CommunicationIP = new System.Windows.Forms.TextBox();
            this.btn_ConnectTcp = new System.Windows.Forms.Button();
            this.lbl_CommunicationIP = new System.Windows.Forms.Label();
            this.nud_CommunicationPort = new System.Windows.Forms.NumericUpDown();
            this.lbl_CommunicationPort = new System.Windows.Forms.Label();
            this.bt_Writ = new System.Windows.Forms.Button();
            this.grp_Memory = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Read = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Data = new System.Windows.Forms.TextBox();
            this.tb_DZ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Read = new System.Windows.Forms.Button();
            this.grp_RcvData.SuspendLayout();
            this.grp_IPConfigGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CommunicationPort)).BeginInit();
            this.grp_Memory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_RcvData
            // 
            this.grp_RcvData.Controls.Add(this.txt_ReceiveData);
            this.grp_RcvData.Location = new System.Drawing.Point(211, 10);
            this.grp_RcvData.Margin = new System.Windows.Forms.Padding(2);
            this.grp_RcvData.Name = "grp_RcvData";
            this.grp_RcvData.Padding = new System.Windows.Forms.Padding(2);
            this.grp_RcvData.Size = new System.Drawing.Size(566, 407);
            this.grp_RcvData.TabIndex = 10;
            this.grp_RcvData.TabStop = false;
            this.grp_RcvData.Text = "接收数据";
            // 
            // txt_ReceiveData
            // 
            this.txt_ReceiveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ReceiveData.Location = new System.Drawing.Point(2, 16);
            this.txt_ReceiveData.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ReceiveData.Multiline = true;
            this.txt_ReceiveData.Name = "txt_ReceiveData";
            this.txt_ReceiveData.ReadOnly = true;
            this.txt_ReceiveData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ReceiveData.Size = new System.Drawing.Size(562, 389);
            this.txt_ReceiveData.TabIndex = 8;
            // 
            // grp_IPConfigGroup
            // 
            this.grp_IPConfigGroup.Controls.Add(this.txt_CommunicationIP);
            this.grp_IPConfigGroup.Controls.Add(this.btn_ConnectTcp);
            this.grp_IPConfigGroup.Controls.Add(this.lbl_CommunicationIP);
            this.grp_IPConfigGroup.Controls.Add(this.nud_CommunicationPort);
            this.grp_IPConfigGroup.Controls.Add(this.lbl_CommunicationPort);
            this.grp_IPConfigGroup.Location = new System.Drawing.Point(9, 10);
            this.grp_IPConfigGroup.Margin = new System.Windows.Forms.Padding(2);
            this.grp_IPConfigGroup.Name = "grp_IPConfigGroup";
            this.grp_IPConfigGroup.Padding = new System.Windows.Forms.Padding(2);
            this.grp_IPConfigGroup.Size = new System.Drawing.Size(176, 128);
            this.grp_IPConfigGroup.TabIndex = 9;
            this.grp_IPConfigGroup.TabStop = false;
            this.grp_IPConfigGroup.Text = "IP设置";
            // 
            // txt_CommunicationIP
            // 
            this.txt_CommunicationIP.Location = new System.Drawing.Point(65, 17);
            this.txt_CommunicationIP.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CommunicationIP.Name = "txt_CommunicationIP";
            this.txt_CommunicationIP.Size = new System.Drawing.Size(103, 21);
            this.txt_CommunicationIP.TabIndex = 4;
            this.txt_CommunicationIP.Text = "127.0.0.1";
            // 
            // btn_ConnectTcp
            // 
            this.btn_ConnectTcp.BackColor = System.Drawing.Color.Moccasin;
            this.btn_ConnectTcp.Location = new System.Drawing.Point(0, 85);
            this.btn_ConnectTcp.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ConnectTcp.Name = "btn_ConnectTcp";
            this.btn_ConnectTcp.Size = new System.Drawing.Size(176, 40);
            this.btn_ConnectTcp.TabIndex = 12;
            this.btn_ConnectTcp.Text = "建立TCP连接";
            this.btn_ConnectTcp.UseVisualStyleBackColor = false;
            this.btn_ConnectTcp.Click += new System.EventHandler(this.btn_ConnectTcp_Click);
            // 
            // lbl_CommunicationIP
            // 
            this.lbl_CommunicationIP.AutoSize = true;
            this.lbl_CommunicationIP.Location = new System.Drawing.Point(7, 21);
            this.lbl_CommunicationIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_CommunicationIP.Name = "lbl_CommunicationIP";
            this.lbl_CommunicationIP.Size = new System.Drawing.Size(47, 12);
            this.lbl_CommunicationIP.TabIndex = 1;
            this.lbl_CommunicationIP.Text = "PLC IP:";
            // 
            // nud_CommunicationPort
            // 
            this.nud_CommunicationPort.Location = new System.Drawing.Point(65, 44);
            this.nud_CommunicationPort.Margin = new System.Windows.Forms.Padding(2);
            this.nud_CommunicationPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_CommunicationPort.Name = "nud_CommunicationPort";
            this.nud_CommunicationPort.Size = new System.Drawing.Size(102, 21);
            this.nud_CommunicationPort.TabIndex = 2;
            this.nud_CommunicationPort.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            // 
            // lbl_CommunicationPort
            // 
            this.lbl_CommunicationPort.AutoSize = true;
            this.lbl_CommunicationPort.Location = new System.Drawing.Point(7, 48);
            this.lbl_CommunicationPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_CommunicationPort.Name = "lbl_CommunicationPort";
            this.lbl_CommunicationPort.Size = new System.Drawing.Size(59, 12);
            this.lbl_CommunicationPort.TabIndex = 3;
            this.lbl_CommunicationPort.Text = "PLC端口：";
            // 
            // bt_Writ
            // 
            this.bt_Writ.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_Writ.Location = new System.Drawing.Point(106, 380);
            this.bt_Writ.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Writ.Name = "bt_Writ";
            this.bt_Writ.Size = new System.Drawing.Size(79, 37);
            this.bt_Writ.TabIndex = 21;
            this.bt_Writ.Text = "写入";
            this.bt_Writ.UseVisualStyleBackColor = false;
            this.bt_Writ.Click += new System.EventHandler(this.bt_Writ_Click);
            // 
            // grp_Memory
            // 
            this.grp_Memory.Controls.Add(this.comboBox1);
            this.grp_Memory.Controls.Add(this.label4);
            this.grp_Memory.Controls.Add(this.tb_Read);
            this.grp_Memory.Controls.Add(this.label1);
            this.grp_Memory.Location = new System.Drawing.Point(9, 142);
            this.grp_Memory.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Memory.Name = "grp_Memory";
            this.grp_Memory.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Memory.Size = new System.Drawing.Size(176, 92);
            this.grp_Memory.TabIndex = 7;
            this.grp_Memory.TabStop = false;
            this.grp_Memory.Text = "读取地址设置";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "16位无符号",
            "16位有符号",
            "32位无符号",
            "32位有符号"});
            this.comboBox1.Location = new System.Drawing.Point(72, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 20);
            this.comboBox1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "数据格式";
            // 
            // tb_Read
            // 
            this.tb_Read.Location = new System.Drawing.Point(76, 23);
            this.tb_Read.Name = "tb_Read";
            this.tb_Read.Size = new System.Drawing.Size(100, 21);
            this.tb_Read.TabIndex = 12;
            this.tb_Read.Text = "00000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "DM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_Data);
            this.groupBox1.Controls.Add(this.tb_DZ);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 238);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(176, 138);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送地址设置";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "16位无符号",
            "16位有符号",
            "32位无符号",
            "32位有符号",
            "字符串"});
            this.comboBox2.Location = new System.Drawing.Point(72, 112);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(104, 20);
            this.comboBox2.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "数据格式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "值";
            // 
            // tb_Data
            // 
            this.tb_Data.Location = new System.Drawing.Point(76, 72);
            this.tb_Data.Name = "tb_Data";
            this.tb_Data.Size = new System.Drawing.Size(100, 21);
            this.tb_Data.TabIndex = 13;
            this.tb_Data.Text = "00000";
            // 
            // tb_DZ
            // 
            this.tb_DZ.Location = new System.Drawing.Point(76, 29);
            this.tb_DZ.Name = "tb_DZ";
            this.tb_DZ.Size = new System.Drawing.Size(100, 21);
            this.tb_DZ.TabIndex = 12;
            this.tb_DZ.Text = "00000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "DM地址";
            // 
            // bt_Read
            // 
            this.bt_Read.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_Read.Location = new System.Drawing.Point(9, 380);
            this.bt_Read.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Read.Name = "bt_Read";
            this.bt_Read.Size = new System.Drawing.Size(79, 37);
            this.bt_Read.TabIndex = 22;
            this.bt_Read.Text = "读取";
            this.bt_Read.UseVisualStyleBackColor = false;
            this.bt_Read.Click += new System.EventHandler(this.bt_Read_Click);
            // 
            // McProtocolTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 428);
            this.Controls.Add(this.bt_Read);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_Writ);
            this.Controls.Add(this.grp_IPConfigGroup);
            this.Controls.Add(this.grp_RcvData);
            this.Controls.Add(this.grp_Memory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "McProtocolTestForm";
            this.Text = "PLC 通信测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.McProtocolTestForm_FormClosing);
            this.grp_RcvData.ResumeLayout(false);
            this.grp_RcvData.PerformLayout();
            this.grp_IPConfigGroup.ResumeLayout(false);
            this.grp_IPConfigGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CommunicationPort)).EndInit();
            this.grp_Memory.ResumeLayout(false);
            this.grp_Memory.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_RcvData;
        private System.Windows.Forms.TextBox txt_ReceiveData;
        private System.Windows.Forms.GroupBox grp_IPConfigGroup;
        private System.Windows.Forms.TextBox txt_CommunicationIP;
        private System.Windows.Forms.Label lbl_CommunicationIP;
        private System.Windows.Forms.NumericUpDown nud_CommunicationPort;
        private System.Windows.Forms.Label lbl_CommunicationPort;
        private System.Windows.Forms.Button btn_ConnectTcp;
        private System.Windows.Forms.Button bt_Writ;
        private System.Windows.Forms.GroupBox grp_Memory;
        private System.Windows.Forms.TextBox tb_Read;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Data;
        private System.Windows.Forms.TextBox tb_DZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Read;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
    }
}

