namespace QLThuVien
{
    partial class frmQuanLyLoaiDocGia
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
            this.dvg_QuanLyLoaiDocGia = new System.Windows.Forms.DataGridView();
            this.bnt_Load = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox_MaLoai = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TenLoaiDocGia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_QuanLyLoaiDocGia)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvg_QuanLyLoaiDocGia
            // 
            this.dvg_QuanLyLoaiDocGia.AllowUserToOrderColumns = true;
            this.dvg_QuanLyLoaiDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvg_QuanLyLoaiDocGia.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dvg_QuanLyLoaiDocGia.Location = new System.Drawing.Point(12, 140);
            this.dvg_QuanLyLoaiDocGia.Name = "dvg_QuanLyLoaiDocGia";
            this.dvg_QuanLyLoaiDocGia.Size = new System.Drawing.Size(449, 148);
            this.dvg_QuanLyLoaiDocGia.TabIndex = 0;
            // 
            // bnt_Load
            // 
            this.bnt_Load.Location = new System.Drawing.Point(26, 8);
            this.bnt_Load.Name = "bnt_Load";
            this.bnt_Load.Size = new System.Drawing.Size(100, 23);
            this.bnt_Load.TabIndex = 1;
            this.bnt_Load.Text = "Load lại dữ liệu.";
            this.bnt_Load.UseVisualStyleBackColor = true;
            this.bnt_Load.Click += new System.EventHandler(this.bnt_Load_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 133);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 121);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox_MaLoai);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 50);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã loại:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bnt_Load);
            this.panel2.Location = new System.Drawing.Point(301, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 121);
            this.panel2.TabIndex = 0;
            // 
            // comboBox_MaLoai
            // 
            this.comboBox_MaLoai.FormattingEnabled = true;
            this.comboBox_MaLoai.Location = new System.Drawing.Point(79, 16);
            this.comboBox_MaLoai.Name = "comboBox_MaLoai";
            this.comboBox_MaLoai.Size = new System.Drawing.Size(204, 21);
            this.comboBox_MaLoai.TabIndex = 1;
            this.comboBox_MaLoai.SelectedIndexChanged += new System.EventHandler(this.comboBox_MaLoai_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox_TenLoaiDocGia);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(286, 50);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Loại";
            // 
            // textBox_TenLoaiDocGia
            // 
            this.textBox_TenLoaiDocGia.Location = new System.Drawing.Point(79, 16);
            this.textBox_TenLoaiDocGia.Name = "textBox_TenLoaiDocGia";
            this.textBox_TenLoaiDocGia.Size = new System.Drawing.Size(204, 20);
            this.textBox_TenLoaiDocGia.TabIndex = 1;
            // 
            // frmQuanLyLoaiDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 300);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dvg_QuanLyLoaiDocGia);
            this.Name = "frmQuanLyLoaiDocGia";
            this.Text = "frmQuanLyLoaiDocGia";
            this.Load += new System.EventHandler(this.frmQuanLyLoaiDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_QuanLyLoaiDocGia)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_QuanLyLoaiDocGia;
        private System.Windows.Forms.Button bnt_Load;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_TenLoaiDocGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_MaLoai;
    }
}