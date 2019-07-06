namespace GUI
{
    partial class frmQuyDinh
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown_NgayMuonToiDa = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_SachMuonToiDa = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_NamXuatBan = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_TuoiToiDa = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_TuoiToiThieu = new System.Windows.Forms.NumericUpDown();
            this.button_SuaQuyDinh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NgayMuonToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SachMuonToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NamXuatBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TuoiToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TuoiToiThieu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown_NgayMuonToiDa);
            this.panel1.Controls.Add(this.numericUpDown_SachMuonToiDa);
            this.panel1.Controls.Add(this.numericUpDown_NamXuatBan);
            this.panel1.Controls.Add(this.numericUpDown_TuoiToiDa);
            this.panel1.Controls.Add(this.numericUpDown_TuoiToiThieu);
            this.panel1.Controls.Add(this.button_SuaQuyDinh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 343);
            this.panel1.TabIndex = 1;
            // 
            // numericUpDown_NgayMuonToiDa
            // 
            this.numericUpDown_NgayMuonToiDa.Location = new System.Drawing.Point(158, 198);
            this.numericUpDown_NgayMuonToiDa.Name = "numericUpDown_NgayMuonToiDa";
            this.numericUpDown_NgayMuonToiDa.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_NgayMuonToiDa.TabIndex = 7;
            // 
            // numericUpDown_SachMuonToiDa
            // 
            this.numericUpDown_SachMuonToiDa.Location = new System.Drawing.Point(158, 162);
            this.numericUpDown_SachMuonToiDa.Name = "numericUpDown_SachMuonToiDa";
            this.numericUpDown_SachMuonToiDa.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_SachMuonToiDa.TabIndex = 7;
            // 
            // numericUpDown_NamXuatBan
            // 
            this.numericUpDown_NamXuatBan.Location = new System.Drawing.Point(158, 122);
            this.numericUpDown_NamXuatBan.Name = "numericUpDown_NamXuatBan";
            this.numericUpDown_NamXuatBan.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_NamXuatBan.TabIndex = 7;
            // 
            // numericUpDown_TuoiToiDa
            // 
            this.numericUpDown_TuoiToiDa.Location = new System.Drawing.Point(158, 88);
            this.numericUpDown_TuoiToiDa.Name = "numericUpDown_TuoiToiDa";
            this.numericUpDown_TuoiToiDa.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_TuoiToiDa.TabIndex = 7;
            this.numericUpDown_TuoiToiDa.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown_TuoiToiDa.ValueChanged += new System.EventHandler(this.numericUpDown_TuoiToiDa_ValueChanged);
            // 
            // numericUpDown_TuoiToiThieu
            // 
            this.numericUpDown_TuoiToiThieu.Location = new System.Drawing.Point(158, 55);
            this.numericUpDown_TuoiToiThieu.Name = "numericUpDown_TuoiToiThieu";
            this.numericUpDown_TuoiToiThieu.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_TuoiToiThieu.TabIndex = 7;
            this.numericUpDown_TuoiToiThieu.ValueChanged += new System.EventHandler(this.numericUpDown_TuoiToiThieu_ValueChanged);
            // 
            // button_SuaQuyDinh
            // 
            this.button_SuaQuyDinh.Location = new System.Drawing.Point(105, 248);
            this.button_SuaQuyDinh.Name = "button_SuaQuyDinh";
            this.button_SuaQuyDinh.Size = new System.Drawing.Size(75, 53);
            this.button_SuaQuyDinh.TabIndex = 6;
            this.button_SuaQuyDinh.Text = "Sửa quy định";
            this.button_SuaQuyDinh.UseVisualStyleBackColor = true;
            this.button_SuaQuyDinh.Click += new System.EventHandler(this.button_SuaQuyDinh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khoảng cách năm xuất bản:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Độ tuổi tối thiểu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Số ngày mượn tối đa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số sách mượn tối đa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Độ tổi tối đa:";
            // 
            // frmQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 382);
            this.Controls.Add(this.panel1);
            this.Name = "frmQuyDinh";
            this.Text = "frmQuyDinh";
            this.Load += new System.EventHandler(this.frmQuyDinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NgayMuonToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SachMuonToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NamXuatBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TuoiToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TuoiToiThieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_SuaQuyDinh;
        private System.Windows.Forms.NumericUpDown numericUpDown_NgayMuonToiDa;
        private System.Windows.Forms.NumericUpDown numericUpDown_SachMuonToiDa;
        private System.Windows.Forms.NumericUpDown numericUpDown_NamXuatBan;
        private System.Windows.Forms.NumericUpDown numericUpDown_TuoiToiDa;
        private System.Windows.Forms.NumericUpDown numericUpDown_TuoiToiThieu;
    }
}