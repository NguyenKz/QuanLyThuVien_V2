using System;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Collections.Generic;

namespace QLThuVien
{
    public partial class frmThemTheDocGia : Form
    {
        private DocGiaBUS dgBus;
        private LoaiDocGiaBUS ldgBus;
        public frmThemTheDocGia()
        {
            InitializeComponent();

        }


        private void bnt_ThemTheDocGia_Click(object sender, EventArgs e)
        {

            //1. Map data from GUI
            DocGiaDTO dg = new DocGiaDTO();


            dg.Ma = tb_MaDG.Text;
            dg.HovaTen = TB_HoVaTen.Text;
            dg.maLoaiDocGia = cb_LaiDocGia.SelectedValue.ToString();
            dg.NgayLapThe = date_NgayLapThe.Value;
            dg.NgaySinh = date_NgaySinh.Value;
            dg.DiaChi = tb_DiaChi.Text;
            dg.Email = tb_Email.Text;
            dg.HanSuDung = int.Parse(tb_HanSuDung.Text);         
            
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = dgBus.them(dg);
            if (kq == false)
                MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Thêm Độc giả thành công");
           
        }

        private void loadLoaiDocGia_Combobox()
        {
            List<LoaiDocGiaDTO> listLoaiDocGia = ldgBus.select();

            if (listLoaiDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy loại ĐG từ DB");
                return;
            }

            cb_LaiDocGia.DataSource = new BindingSource(listLoaiDocGia, String.Empty);
            cb_LaiDocGia.DisplayMember = "tenLoaiDocGia";
            cb_LaiDocGia.ValueMember = "maLoaiDocGia";

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[cb_LaiDocGia.DataSource];
            myCurrencyManager.Refresh();

            if (cb_LaiDocGia.Items.Count > 0)
            {
                cb_LaiDocGia.SelectedIndex = 0;
            }

        }
        private void frmThemDocGia_Load(object sender, EventArgs e)
        {
            dgBus = new DocGiaBUS();
            ldgBus = new LoaiDocGiaBUS();
            loadLoaiDocGia_Combobox();

        }
    }
}
