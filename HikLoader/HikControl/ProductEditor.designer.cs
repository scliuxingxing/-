using System.Windows.Forms;
namespace HikUnLoader.HikControl
{
    partial class ProductEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEditor));
            this.ComboBox_ProductChoose = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_AddProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_AddProduct = new System.Windows.Forms.Button();
            this.button_DeleteProduct = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_GoToProductFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBox_ProductChoose
            // 
            this.ComboBox_ProductChoose.BackColor = System.Drawing.Color.LightYellow;
            this.ComboBox_ProductChoose.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBox_ProductChoose.FormattingEnabled = true;
            this.ComboBox_ProductChoose.Location = new System.Drawing.Point(6, 93);
            this.ComboBox_ProductChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboBox_ProductChoose.Name = "ComboBox_ProductChoose";
            this.ComboBox_ProductChoose.Size = new System.Drawing.Size(440, 41);
            this.ComboBox_ProductChoose.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "要复制的料号";
            // 
            // text_AddProductName
            // 
            this.text_AddProductName.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_AddProductName.Location = new System.Drawing.Point(6, 210);
            this.text_AddProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_AddProductName.Name = "text_AddProductName";
            this.text_AddProductName.Size = new System.Drawing.Size(440, 44);
            this.text_AddProductName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "新增料号名称";
            // 
            // button_AddProduct
            // 
            this.button_AddProduct.BackColor = System.Drawing.Color.GreenYellow;
            this.button_AddProduct.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AddProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_AddProduct.Location = new System.Drawing.Point(6, 288);
            this.button_AddProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_AddProduct.Name = "button_AddProduct";
            this.button_AddProduct.Size = new System.Drawing.Size(200, 48);
            this.button_AddProduct.TabIndex = 3;
            this.button_AddProduct.Text = "新增料号";
            this.button_AddProduct.UseVisualStyleBackColor = false;
            this.button_AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // button_DeleteProduct
            // 
            this.button_DeleteProduct.BackColor = System.Drawing.Color.DeepPink;
            this.button_DeleteProduct.Enabled = false;
            this.button_DeleteProduct.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_DeleteProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_DeleteProduct.Location = new System.Drawing.Point(246, 288);
            this.button_DeleteProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_DeleteProduct.Name = "button_DeleteProduct";
            this.button_DeleteProduct.Size = new System.Drawing.Size(200, 48);
            this.button_DeleteProduct.TabIndex = 3;
            this.button_DeleteProduct.Text = "删除料号";
            this.button_DeleteProduct.UseVisualStyleBackColor = false;
            this.button_DeleteProduct.Visible = false;
            this.button_DeleteProduct.Click += new System.EventHandler(this.DeleteProduct_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_GoToProductFolder);
            this.groupBox1.Controls.Add(this.button_DeleteProduct);
            this.groupBox1.Controls.Add(this.ComboBox_ProductChoose);
            this.groupBox1.Controls.Add(this.button_AddProduct);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.text_AddProductName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(452, 417);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "料号编辑";
            // 
            // button_GoToProductFolder
            // 
            this.button_GoToProductFolder.BackColor = System.Drawing.Color.GreenYellow;
            this.button_GoToProductFolder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_GoToProductFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_GoToProductFolder.Location = new System.Drawing.Point(6, 361);
            this.button_GoToProductFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_GoToProductFolder.Name = "button_GoToProductFolder";
            this.button_GoToProductFolder.Size = new System.Drawing.Size(440, 48);
            this.button_GoToProductFolder.TabIndex = 4;
            this.button_GoToProductFolder.Text = "进入料号文件夹";
            this.button_GoToProductFolder.UseVisualStyleBackColor = false;
            this.button_GoToProductFolder.Click += new System.EventHandler(this.button_GoToProductFolder_Click);
            // 
            // ProductEditor
            // 
            this.AcceptButton = this.button_AddProduct;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "料号编辑";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductEditor_FormClosing);
            this.Load += new System.EventHandler(this.ProductEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_ProductChoose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_AddProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_AddProduct;
        private System.Windows.Forms.Button button_DeleteProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private Button button_GoToProductFolder;
    }
}