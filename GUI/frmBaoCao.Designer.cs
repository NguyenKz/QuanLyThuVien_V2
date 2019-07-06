namespace GUI
{
    partial class frmBaoCao
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButton_BaoCaoTheoTheLoai = new System.Windows.Forms.RadioButton();
            this.radioButton_SachTraTe = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(809, 231);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(83, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // radioButton_BaoCaoTheoTheLoai
            // 
            this.radioButton_BaoCaoTheoTheLoai.AutoSize = true;
            this.radioButton_BaoCaoTheoTheLoai.Checked = true;
            this.radioButton_BaoCaoTheoTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_BaoCaoTheoTheLoai.ForeColor = System.Drawing.Color.Magenta;
            this.radioButton_BaoCaoTheoTheLoai.Location = new System.Drawing.Point(15, 59);
            this.radioButton_BaoCaoTheoTheLoai.Name = "radioButton_BaoCaoTheoTheLoai";
            this.radioButton_BaoCaoTheoTheLoai.Size = new System.Drawing.Size(147, 17);
            this.radioButton_BaoCaoTheoTheLoai.TabIndex = 3;
            this.radioButton_BaoCaoTheoTheLoai.Text = "Báo cáo theo thể loại";
            this.radioButton_BaoCaoTheoTheLoai.UseVisualStyleBackColor = true;
            // 
            // radioButton_SachTraTe
            // 
            this.radioButton_SachTraTe.AutoSize = true;
            this.radioButton_SachTraTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_SachTraTe.ForeColor = System.Drawing.Color.Magenta;
            this.radioButton_SachTraTe.Location = new System.Drawing.Point(15, 82);
            this.radioButton_SachTraTe.Name = "radioButton_SachTraTe";
            this.radioButton_SachTraTe.Size = new System.Drawing.Size(123, 17);
            this.radioButton_SachTraTe.TabIndex = 3;
            this.radioButton_SachTraTe.Text = "Theo sách trả trể";
            this.radioButton_SachTraTe.UseVisualStyleBackColor = true;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(833, 410);
            this.Controls.Add(this.radioButton_SachTraTe);
            this.Controls.Add(this.radioButton_BaoCaoTheoTheLoai);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Name = "frmBaoCao";
            this.Text = "Báo cáo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioButton_BaoCaoTheoTheLoai;
        private System.Windows.Forms.RadioButton radioButton_SachTraTe;
    }
}