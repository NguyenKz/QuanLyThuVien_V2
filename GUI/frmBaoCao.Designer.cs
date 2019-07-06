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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButton_BaoCaoTheoTheLoai = new System.Windows.Forms.RadioButton();
            this.radioButton_SachTraTe = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView_BaoCao = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label_TongSoLuotMuon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tháng:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(97, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(216, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // radioButton_BaoCaoTheoTheLoai
            // 
            this.radioButton_BaoCaoTheoTheLoai.AutoSize = true;
            this.radioButton_BaoCaoTheoTheLoai.Checked = true;
            this.radioButton_BaoCaoTheoTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_BaoCaoTheoTheLoai.ForeColor = System.Drawing.Color.Magenta;
            this.radioButton_BaoCaoTheoTheLoai.Location = new System.Drawing.Point(17, 59);
            this.radioButton_BaoCaoTheoTheLoai.Name = "radioButton_BaoCaoTheoTheLoai";
            this.radioButton_BaoCaoTheoTheLoai.Size = new System.Drawing.Size(147, 17);
            this.radioButton_BaoCaoTheoTheLoai.TabIndex = 3;
            this.radioButton_BaoCaoTheoTheLoai.TabStop = true;
            this.radioButton_BaoCaoTheoTheLoai.Text = "Báo cáo theo thể loại";
            this.radioButton_BaoCaoTheoTheLoai.UseVisualStyleBackColor = true;
            this.radioButton_BaoCaoTheoTheLoai.CheckedChanged += new System.EventHandler(this.radioButton_BaoCaoTheoTheLoai_CheckedChanged);
            // 
            // radioButton_SachTraTe
            // 
            this.radioButton_SachTraTe.AutoSize = true;
            this.radioButton_SachTraTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_SachTraTe.ForeColor = System.Drawing.Color.Magenta;
            this.radioButton_SachTraTe.Location = new System.Drawing.Point(17, 82);
            this.radioButton_SachTraTe.Name = "radioButton_SachTraTe";
            this.radioButton_SachTraTe.Size = new System.Drawing.Size(170, 17);
            this.radioButton_SachTraTe.TabIndex = 3;
            this.radioButton_SachTraTe.Text = "Báo cáo theo sách trả trể";
            this.radioButton_SachTraTe.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_BaoCao
            // 
            this.dataGridView_BaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_BaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_BaoCao.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView_BaoCao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView_BaoCao.Location = new System.Drawing.Point(12, 167);
            this.dataGridView_BaoCao.Name = "dataGridView_BaoCao";
            this.dataGridView_BaoCao.Size = new System.Drawing.Size(534, 231);
            this.dataGridView_BaoCao.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng số lượt mượn tháng này:";
            // 
            // label_TongSoLuotMuon
            // 
            this.label_TongSoLuotMuon.AutoSize = true;
            this.label_TongSoLuotMuon.ForeColor = System.Drawing.Color.Red;
            this.label_TongSoLuotMuon.Location = new System.Drawing.Point(223, 136);
            this.label_TongSoLuotMuon.Name = "label_TongSoLuotMuon";
            this.label_TongSoLuotMuon.Size = new System.Drawing.Size(14, 13);
            this.label_TongSoLuotMuon.TabIndex = 6;
            this.label_TongSoLuotMuon.Text = "0";
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(556, 410);
            this.Controls.Add(this.label_TongSoLuotMuon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton_SachTraTe);
            this.Controls.Add(this.radioButton_BaoCaoTheoTheLoai);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_BaoCao);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao";
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioButton_BaoCaoTheoTheLoai;
        private System.Windows.Forms.RadioButton radioButton_SachTraTe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView_BaoCao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_TongSoLuotMuon;
    }
}