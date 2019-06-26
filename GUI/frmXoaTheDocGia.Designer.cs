namespace QLThuVien
{
    partial class frmXoaTheDocGia
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
            this.tb_Ma = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bnt_Xoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Ma
            // 
            this.tb_Ma.Location = new System.Drawing.Point(94, 47);
            this.tb_Ma.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Ma.Name = "tb_Ma";
            this.tb_Ma.Size = new System.Drawing.Size(116, 20);
            this.tb_Ma.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã thẻ độc giả";
            // 
            // bnt_Xoa
            // 
            this.bnt_Xoa.Location = new System.Drawing.Point(94, 103);
            this.bnt_Xoa.Name = "bnt_Xoa";
            this.bnt_Xoa.Size = new System.Drawing.Size(75, 23);
            this.bnt_Xoa.TabIndex = 2;
            this.bnt_Xoa.Text = "Xoa";
            this.bnt_Xoa.UseVisualStyleBackColor = true;
            this.bnt_Xoa.Click += new System.EventHandler(this.bnt_Xoa_Click);
            // 
            // frmXoaTheDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 172);
            this.Controls.Add(this.bnt_Xoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Ma);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmXoaTheDocGia";
            this.Text = "Xóa thẻ độc giả";
            this.Load += new System.EventHandler(this.frmXoaTheDocGia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tb_Ma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnt_Xoa;
    }
}