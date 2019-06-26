using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace QLThuVien
{
    public partial class frmXoaTheDocGia : Form
    {
        private DocGiaBUS dgBus;
        public frmXoaTheDocGia()
        {
            InitializeComponent();

        }

        private void bnt_Xoa_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            DocGiaDTO dg = new DocGiaDTO();


            dg.Ma = tb_Ma.Text;
        

            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = dgBus.xoa(dg);
            if (kq == false)
                MessageBox.Show("Xóa Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Xóa Độc giả thành công");

        }

        private void frmXoaTheDocGia_Load(object sender, EventArgs e)
        {
            dgBus = new DocGiaBUS();
        }
    }
}
