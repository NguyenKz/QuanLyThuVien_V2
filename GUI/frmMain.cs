using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ThêmThẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemTheDocGia frm = new frmThemTheDocGia();
           // frm.MdiParent = this;
            frm.Show();
        }

        private void XóaThẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXoaTheDocGia frm = new frmXoaTheDocGia();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void SửaThẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   frmSuaTheDocGia frm = new frmSuaTheDocGia();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void quanLýLoạiDọcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiDocGia frm = new frmQuanLyLoaiDocGia();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void quanLýThẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmQuanLySach frm = new frmQuanLySach();
            //frm.Show();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void quảnLýThểLoạiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmQuanLyTheLoai frm = new frmQuanLyTheLoai();
            frm.Show();

        }

        private void quảnLýMượnTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMuonTraSach frm = new frmMuonTraSach();
            //frm.Show();
        }

        private void quảnLýQuyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuyDinh frm = new frmQuyDinh();
            frm.Show();

        }

        private void quảnLýThẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTheDocGia frm = new frmQuanLyTheDocGia();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýLoạiĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiDocGia frm = new frmQuanLyLoaiDocGia();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();

        }

        private void quảnLýLoạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTheLoai frm = new frmQuanLyTheLoai();
            frm.Show();

        }

        private void quảnLýMượnTrảSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMuonTraSach frm = new frmMuonTraSach();
            frm.Show();

        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            frm.Show();
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quản lý thư viện V1.0");
        }

        private void thoátỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thốngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đồ án môn công nghệ phần mềm.\n Đề tài: Quản lý thư viện bằng công nghệ thông tin.\n Thành viên:\n1: Trần Thảo Nguyên\n2:Phạm Kim Thành.\n3:Trương Văn Việt.\n4:Vũ Nhân Nghĩa.");
        }
    }
}
