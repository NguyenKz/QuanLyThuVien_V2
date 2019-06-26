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
    public partial class frmQuanLyLoaiDocGia : Form
    {
        public frmQuanLyLoaiDocGia()
        {
            InitializeComponent();
        }
        
        private LoaiDocGiaBUS ldgBus;
        private void loadData_Vao_GridView()
        {
            List<LoaiDocGiaDTO> listKieuNau = ldgBus.select();

            if (listKieuNau == null)
            {
                MessageBox.Show("Có lỗi khi lấy Món ăn từ DB");
                return;
            }

            

            dvg_QuanLyLoaiDocGia.Columns.Clear();
            dvg_QuanLyLoaiDocGia.DataSource = null;

            dvg_QuanLyLoaiDocGia.AutoGenerateColumns = false;
            dvg_QuanLyLoaiDocGia.AllowUserToAddRows = false;
            dvg_QuanLyLoaiDocGia.DataSource = listKieuNau;
            
            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaLoaiDocGia";
            clMa.HeaderText = "Mã loại độc giả";
            clMa.DataPropertyName = "MaLoaiDocGia";
            dvg_QuanLyLoaiDocGia.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "TenLoaiDocGia";
            clTen.HeaderText = "Tên loại độc giả";
            clTen.DataPropertyName = "TenLoaiDocGia";
            dvg_QuanLyLoaiDocGia.Columns.Add(clTen);

           

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dvg_QuanLyLoaiDocGia.DataSource];
            myCurrencyManager.Refresh();
        }
        private void bnt_Load_Click(object sender, EventArgs e)
        {
            loadData_Vao_GridView();
        }

        private void frmQuanLyLoaiDocGia_Load(object sender, EventArgs e)
        {
        
            ldgBus = new LoaiDocGiaBUS();


        }
    }
}
