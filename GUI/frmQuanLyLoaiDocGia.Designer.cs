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
            ((System.ComponentModel.ISupportInitialize)(this.dvg_QuanLyLoaiDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_QuanLyLoaiDocGia
            // 
            this.dvg_QuanLyLoaiDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_QuanLyLoaiDocGia.Location = new System.Drawing.Point(12, 170);
            this.dvg_QuanLyLoaiDocGia.Name = "dvg_QuanLyLoaiDocGia";
            this.dvg_QuanLyLoaiDocGia.Size = new System.Drawing.Size(449, 268);
            this.dvg_QuanLyLoaiDocGia.TabIndex = 0;
            // 
            // bnt_Load
            // 
            this.bnt_Load.Location = new System.Drawing.Point(208, 79);
            this.bnt_Load.Name = "bnt_Load";
            this.bnt_Load.Size = new System.Drawing.Size(75, 23);
            this.bnt_Load.TabIndex = 1;
            this.bnt_Load.Text = "Load data";
            this.bnt_Load.UseVisualStyleBackColor = true;
            this.bnt_Load.Click += new System.EventHandler(this.bnt_Load_Click);
            // 
            // frmQuanLyLoaiDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 450);
            this.Controls.Add(this.bnt_Load);
            this.Controls.Add(this.dvg_QuanLyLoaiDocGia);
            this.Name = "frmQuanLyLoaiDocGia";
            this.Text = "frmQuanLyLoaiDocGia";
            this.Load += new System.EventHandler(this.frmQuanLyLoaiDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_QuanLyLoaiDocGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_QuanLyLoaiDocGia;
        private System.Windows.Forms.Button bnt_Load;
    }
}