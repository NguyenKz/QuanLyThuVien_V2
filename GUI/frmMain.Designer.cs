namespace QLThuVien
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thẻĐộcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLýLoạiDọcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLýThẻĐộcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátỨngDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thẻĐộcGiảToolStripMenuItem,
            this.hệThốngToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thẻĐộcGiảToolStripMenuItem
            // 
            this.thẻĐộcGiảToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLýLoạiDọcGiảToolStripMenuItem,
            this.quanLýThẻĐộcGiảToolStripMenuItem});
            this.thẻĐộcGiảToolStripMenuItem.Name = "thẻĐộcGiảToolStripMenuItem";
            this.thẻĐộcGiảToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.thẻĐộcGiảToolStripMenuItem.Text = "Thẻ độc giả";
            // 
            // quanLýLoạiDọcGiảToolStripMenuItem
            // 
            this.quanLýLoạiDọcGiảToolStripMenuItem.Name = "quanLýLoạiDọcGiảToolStripMenuItem";
            this.quanLýLoạiDọcGiảToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.quanLýLoạiDọcGiảToolStripMenuItem.Text = "Quan Lý loại dọc giả";
            this.quanLýLoạiDọcGiảToolStripMenuItem.Click += new System.EventHandler(this.quanLýLoạiDọcGiảToolStripMenuItem_Click);
            // 
            // quanLýThẻĐộcGiảToolStripMenuItem
            // 
            this.quanLýThẻĐộcGiảToolStripMenuItem.Name = "quanLýThẻĐộcGiảToolStripMenuItem";
            this.quanLýThẻĐộcGiảToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.quanLýThẻĐộcGiảToolStripMenuItem.Text = "Quan Lý thẻ độc giả";
            this.quanLýThẻĐộcGiảToolStripMenuItem.Click += new System.EventHandler(this.quanLýThẻĐộcGiảToolStripMenuItem_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátỨngDụngToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // thoátỨngDụngToolStripMenuItem
            // 
            this.thoátỨngDụngToolStripMenuItem.Name = "thoátỨngDụngToolStripMenuItem";
            this.thoátỨngDụngToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.thoátỨngDụngToolStripMenuItem.Text = "Thoát ứng dụng";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.versionToolStripMenuItem.Text = "Version";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 348);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "Quản lý thư viện 1.0";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thẻĐộcGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátỨngDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLýThẻĐộcGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLýLoạiDọcGiảToolStripMenuItem;
    }
}

