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
            frmQuanLyTheDocGia frm = new frmQuanLyTheDocGia();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.Show();
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
            frmMuonTraSach frm = new frmMuonTraSach();
            frm.Show();
        }
    }
}
