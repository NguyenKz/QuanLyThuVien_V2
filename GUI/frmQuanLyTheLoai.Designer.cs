﻿namespace GUI
{
    partial class frmQuanLyTheLoai
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox_TenLoaiDocGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_Ma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Sua = new System.Windows.Forms.Button();
            this.button_Them = new System.Windows.Forms.Button();
            this.button_Xoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_QuanLyLoaiDocGia)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvg_QuanLyLoaiDocGia
            // 
            this.dvg_QuanLyLoaiDocGia.AllowUserToOrderColumns = true;
            this.dvg_QuanLyLoaiDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvg_QuanLyLoaiDocGia.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dvg_QuanLyLoaiDocGia.Location = new System.Drawing.Point(12, 151);
            this.dvg_QuanLyLoaiDocGia.Name = "dvg_QuanLyLoaiDocGia";
            this.dvg_QuanLyLoaiDocGia.Size = new System.Drawing.Size(449, 148);
            this.dvg_QuanLyLoaiDocGia.TabIndex = 3;
            this.dvg_QuanLyLoaiDocGia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvg_QuanLyLoaiDocGia_MouseClick);
            // 
            // bnt_Load
            // 
            this.bnt_Load.Location = new System.Drawing.Point(22, 9);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 133);
            this.flowLayoutPanel1.TabIndex = 4;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox_TenLoaiDocGia);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(286, 50);
            this.panel4.TabIndex = 0;
            // 
            // textBox_TenLoaiDocGia
            // 
            this.textBox_TenLoaiDocGia.Location = new System.Drawing.Point(79, 16);
            this.textBox_TenLoaiDocGia.Name = "textBox_TenLoaiDocGia";
            this.textBox_TenLoaiDocGia.Size = new System.Drawing.Size(204, 20);
            this.textBox_TenLoaiDocGia.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên thể loại";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox_Ma);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 50);
            this.panel3.TabIndex = 0;
            // 
            // textBox_Ma
            // 
            this.textBox_Ma.Location = new System.Drawing.Point(79, 16);
            this.textBox_Ma.Name = "textBox_Ma";
            this.textBox_Ma.ReadOnly = true;
            this.textBox_Ma.Size = new System.Drawing.Size(204, 20);
            this.textBox_Ma.TabIndex = 1;
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
            this.panel2.Controls.Add(this.button_Sua);
            this.panel2.Controls.Add(this.button_Them);
            this.panel2.Controls.Add(this.button_Xoa);
            this.panel2.Controls.Add(this.bnt_Load);
            this.panel2.Location = new System.Drawing.Point(301, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 121);
            this.panel2.TabIndex = 0;
            // 
            // button_Sua
            // 
            this.button_Sua.Location = new System.Drawing.Point(22, 91);
            this.button_Sua.Name = "button_Sua";
            this.button_Sua.Size = new System.Drawing.Size(100, 23);
            this.button_Sua.TabIndex = 2;
            this.button_Sua.Text = "Sửa";
            this.button_Sua.UseVisualStyleBackColor = true;
            this.button_Sua.Click += new System.EventHandler(this.button_Sua_Click);
            // 
            // button_Them
            // 
            this.button_Them.Location = new System.Drawing.Point(22, 62);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(100, 23);
            this.button_Them.TabIndex = 2;
            this.button_Them.Text = "Thêm";
            this.button_Them.UseVisualStyleBackColor = true;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // button_Xoa
            // 
            this.button_Xoa.Location = new System.Drawing.Point(22, 35);
            this.button_Xoa.Name = "button_Xoa";
            this.button_Xoa.Size = new System.Drawing.Size(100, 23);
            this.button_Xoa.TabIndex = 2;
            this.button_Xoa.Text = "Xóa";
            this.button_Xoa.UseVisualStyleBackColor = true;
            this.button_Xoa.Click += new System.EventHandler(this.button_Xoa_Click);
            // 
            // frmQuanLyTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 308);
            this.Controls.Add(this.dvg_QuanLyLoaiDocGia);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmQuanLyTheLoai";
            this.Text = "frmQuanLyTheLoai";
            this.Load += new System.EventHandler(this.frmQuanLyTheLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_QuanLyLoaiDocGia)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_QuanLyLoaiDocGia;
        private System.Windows.Forms.Button bnt_Load;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_TenLoaiDocGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_Ma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Sua;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.Button button_Xoa;
    }
}