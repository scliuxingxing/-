
namespace HikUnLoader.HikFrom
{
    partial class Camera2DebugForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Camera2DebugForm));
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
            this.btn_VertexTool = new System.Windows.Forms.Button();
            this.btn_Load12PointCalibFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_CalibConversionY = new System.Windows.Forms.Label();
            this.label_CalibConversionX = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_BaseAngle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_BasePointY = new System.Windows.Forms.Label();
            this.label_BasePointX = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_CalibCentralPointY = new System.Windows.Forms.Label();
            this.label_CalibCentralPointX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_Pma = new System.Windows.Forms.ComboBox();
            this.btn_SetBasePosition = new System.Windows.Forms.Button();
            this.tb_Point = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1272, 696);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机调试界面";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.vmDebugControl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tb_Point, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1268, 678);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // vmDebugControl
            // 
            this.vmDebugControl.BackColor = System.Drawing.Color.White;
            this.vmDebugControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmDebugControl.ImageSource = null;
            this.vmDebugControl.Location = new System.Drawing.Point(4, 113);
            this.vmDebugControl.Margin = new System.Windows.Forms.Padding(4);
            this.vmDebugControl.ModuleSource = null;
            this.vmDebugControl.Name = "vmDebugControl";
            this.vmDebugControl.ParamsConfig = null;
            this.vmDebugControl.ROIVisible = true;
            this.vmDebugControl.Size = new System.Drawing.Size(1260, 527);
            this.vmDebugControl.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1264, 105);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(2, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(312, 101);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(308, 83);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btn_GetImageFromFile
            // 
            this.btn_GetImageFromFile.BackColor = System.Drawing.Color.Orange;
            this.btn_GetImageFromFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_GetImageFromFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GetImageFromFile.Location = new System.Drawing.Point(156, 2);
            this.btn_GetImageFromFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GetImageFromFile.Name = "btn_GetImageFromFile";
            this.btn_GetImageFromFile.Size = new System.Drawing.Size(150, 79);
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
            this.btn_GetImageFromCam.Location = new System.Drawing.Point(2, 2);
            this.btn_GetImageFromCam.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GetImageFromCam.Name = "btn_GetImageFromCam";
            this.btn_GetImageFromCam.Size = new System.Drawing.Size(150, 79);
            this.btn_GetImageFromCam.TabIndex = 0;
            this.btn_GetImageFromCam.Text = "从相机获取图像";
            this.btn_GetImageFromCam.UseVisualStyleBackColor = false;
            this.btn_GetImageFromCam.Click += new System.EventHandler(this.bt_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(318, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(944, 101);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "算法功能区";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40574F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40574F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40574F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40574F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.40914F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.9679F));
            this.tableLayoutPanel5.Controls.Add(this.btn_PMATool, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_CorrectionOfDistortion, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_VertexTool, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_Load12PointCalibFile, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(940, 83);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btn_PMATool
            // 
            this.btn_PMATool.BackColor = System.Drawing.Color.Orange;
            this.btn_PMATool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PMATool.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PMATool.Location = new System.Drawing.Point(128, 2);
            this.btn_PMATool.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PMATool.Name = "btn_PMATool";
            this.btn_PMATool.Size = new System.Drawing.Size(122, 79);
            this.btn_PMATool.TabIndex = 6;
            this.btn_PMATool.Text = "模板匹配";
            this.btn_PMATool.UseVisualStyleBackColor = false;
            this.btn_PMATool.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_CorrectionOfDistortion
            // 
            this.btn_CorrectionOfDistortion.BackColor = System.Drawing.Color.Orange;
            this.btn_CorrectionOfDistortion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CorrectionOfDistortion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CorrectionOfDistortion.Location = new System.Drawing.Point(2, 2);
            this.btn_CorrectionOfDistortion.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CorrectionOfDistortion.Name = "btn_CorrectionOfDistortion";
            this.btn_CorrectionOfDistortion.Size = new System.Drawing.Size(122, 79);
            this.btn_CorrectionOfDistortion.TabIndex = 0;
            this.btn_CorrectionOfDistortion.Text = "畸变校正";
            this.btn_CorrectionOfDistortion.UseVisualStyleBackColor = false;
            this.btn_CorrectionOfDistortion.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_VertexTool
            // 
            this.btn_VertexTool.BackColor = System.Drawing.Color.Orange;
            this.btn_VertexTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_VertexTool.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_VertexTool.Location = new System.Drawing.Point(254, 2);
            this.btn_VertexTool.Margin = new System.Windows.Forms.Padding(2);
            this.btn_VertexTool.Name = "btn_VertexTool";
            this.btn_VertexTool.Size = new System.Drawing.Size(122, 79);
            this.btn_VertexTool.TabIndex = 1;
            this.btn_VertexTool.Text = "顶点工具";
            this.btn_VertexTool.UseVisualStyleBackColor = false;
            this.btn_VertexTool.Click += new System.EventHandler(this.bt_Click);
            // 
            // btn_Load12PointCalibFile
            // 
            this.btn_Load12PointCalibFile.BackColor = System.Drawing.Color.Orange;
            this.btn_Load12PointCalibFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Load12PointCalibFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Load12PointCalibFile.Location = new System.Drawing.Point(380, 2);
            this.btn_Load12PointCalibFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Load12PointCalibFile.Name = "btn_Load12PointCalibFile";
            this.btn_Load12PointCalibFile.Size = new System.Drawing.Size(122, 79);
            this.btn_Load12PointCalibFile.TabIndex = 2;
            this.btn_Load12PointCalibFile.Text = "加载12点标定文件";
            this.btn_Load12PointCalibFile.UseVisualStyleBackColor = false;
            this.btn_Load12PointCalibFile.Click += new System.EventHandler(this.bt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_CalibConversionY);
            this.groupBox2.Controls.Add(this.label_CalibConversionX);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label_BaseAngle);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label_BasePointY);
            this.groupBox2.Controls.Add(this.label_BasePointX);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label_CalibCentralPointY);
            this.groupBox2.Controls.Add(this.label_CalibCentralPointX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(632, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(306, 79);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "示教点信息";
            // 
            // label_CalibConversionY
            // 
            this.label_CalibConversionY.AutoSize = true;
            this.label_CalibConversionY.Location = new System.Drawing.Point(170, 34);
            this.label_CalibConversionY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CalibConversionY.Name = "label_CalibConversionY";
            this.label_CalibConversionY.Size = new System.Drawing.Size(35, 12);
            this.label_CalibConversionY.TabIndex = 33;
            this.label_CalibConversionY.Text = "00.00";
            // 
            // label_CalibConversionX
            // 
            this.label_CalibConversionX.AutoSize = true;
            this.label_CalibConversionX.Location = new System.Drawing.Point(170, 18);
            this.label_CalibConversionX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CalibConversionX.Name = "label_CalibConversionX";
            this.label_CalibConversionX.Size = new System.Drawing.Size(35, 12);
            this.label_CalibConversionX.TabIndex = 32;
            this.label_CalibConversionX.Text = "00.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(107, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "标定转换Y:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(107, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "标定转换X：";
            // 
            // label_BaseAngle
            // 
            this.label_BaseAngle.AutoSize = true;
            this.label_BaseAngle.Location = new System.Drawing.Point(267, 49);
            this.label_BaseAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_BaseAngle.Name = "label_BaseAngle";
            this.label_BaseAngle.Size = new System.Drawing.Size(35, 12);
            this.label_BaseAngle.TabIndex = 29;
            this.label_BaseAngle.Text = "00.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "示教角度：";
            // 
            // label_BasePointY
            // 
            this.label_BasePointY.AutoSize = true;
            this.label_BasePointY.Location = new System.Drawing.Point(267, 34);
            this.label_BasePointY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_BasePointY.Name = "label_BasePointY";
            this.label_BasePointY.Size = new System.Drawing.Size(35, 12);
            this.label_BasePointY.TabIndex = 23;
            this.label_BasePointY.Text = "00.00";
            // 
            // label_BasePointX
            // 
            this.label_BasePointX.AutoSize = true;
            this.label_BasePointX.Location = new System.Drawing.Point(267, 18);
            this.label_BasePointX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_BasePointX.Name = "label_BasePointX";
            this.label_BasePointX.Size = new System.Drawing.Size(35, 12);
            this.label_BasePointX.TabIndex = 22;
            this.label_BasePointX.Text = "00.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "示教点Y：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(209, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "示教点X：";
            // 
            // label_CalibCentralPointY
            // 
            this.label_CalibCentralPointY.AutoSize = true;
            this.label_CalibCentralPointY.Location = new System.Drawing.Point(67, 34);
            this.label_CalibCentralPointY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CalibCentralPointY.Name = "label_CalibCentralPointY";
            this.label_CalibCentralPointY.Size = new System.Drawing.Size(35, 12);
            this.label_CalibCentralPointY.TabIndex = 19;
            this.label_CalibCentralPointY.Text = "00.00";
            // 
            // label_CalibCentralPointX
            // 
            this.label_CalibCentralPointX.AutoSize = true;
            this.label_CalibCentralPointX.Location = new System.Drawing.Point(67, 18);
            this.label_CalibCentralPointX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CalibCentralPointX.Name = "label_CalibCentralPointX";
            this.label_CalibCentralPointX.Size = new System.Drawing.Size(35, 12);
            this.label_CalibCentralPointX.TabIndex = 18;
            this.label_CalibCentralPointX.Text = "00.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "标定原点Y：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "标定原点X：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cb_Pma, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_SetBasePosition, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(506, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.76624F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.23376F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(122, 79);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cb_Pma
            // 
            this.cb_Pma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Pma.FormattingEnabled = true;
            this.cb_Pma.Items.AddRange(new object[] {
            "正面",
            "反面"});
            this.cb_Pma.Location = new System.Drawing.Point(2, 2);
            this.cb_Pma.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Pma.Name = "cb_Pma";
            this.cb_Pma.Size = new System.Drawing.Size(118, 20);
            this.cb_Pma.TabIndex = 0;
            // 
            // btn_SetBasePosition
            // 
            this.btn_SetBasePosition.BackColor = System.Drawing.Color.Orange;
            this.btn_SetBasePosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SetBasePosition.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SetBasePosition.Location = new System.Drawing.Point(2, 28);
            this.btn_SetBasePosition.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetBasePosition.Name = "btn_SetBasePosition";
            this.btn_SetBasePosition.Size = new System.Drawing.Size(118, 49);
            this.btn_SetBasePosition.TabIndex = 1;
            this.btn_SetBasePosition.Text = "设置示教位";
            this.btn_SetBasePosition.UseVisualStyleBackColor = false;
            this.btn_SetBasePosition.Click += new System.EventHandler(this.bt_Click);
            // 
            // tb_Point
            // 
            this.tb_Point.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Point.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Point.Location = new System.Drawing.Point(2, 646);
            this.tb_Point.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Point.Multiline = true;
            this.tb_Point.Name = "tb_Point";
            this.tb_Point.ReadOnly = true;
            this.tb_Point.Size = new System.Drawing.Size(1264, 30);
            this.tb_Point.TabIndex = 2;
            this.tb_Point.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Camera2DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 696);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Camera2DebugForm";
            this.Text = "相机调试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Camera2DebugForm_FormClosing);
            this.Load += new System.EventHandler(this.Camera2DebugForm_Load);
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
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox tb_Point;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btn_CorrectionOfDistortion;
        private System.Windows.Forms.Button btn_VertexTool;
        private System.Windows.Forms.Button btn_Load12PointCalibFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_BaseAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_BasePointY;
        private System.Windows.Forms.Label label_BasePointX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_CalibCentralPointY;
        private System.Windows.Forms.Label label_CalibCentralPointX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cb_Pma;
        private System.Windows.Forms.Button btn_SetBasePosition;
        private System.Windows.Forms.Button btn_PMATool;
        private System.Windows.Forms.Label label_CalibConversionY;
        private System.Windows.Forms.Label label_CalibConversionX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}