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
    /// <summary>
    /// adfasdf
    /// </summary>
    public partial class frmQuanLyLoaiDocGia : Form
    {
        public frmQuanLyLoaiDocGia()
        {
            InitializeComponent();
        }
        
        private LoaiDocGiaBUS ldgBus;
        private void loadData_Vao_GridView()
        {
            List<LoaiDocGiaDTO> listKieuNau = ldgBus.select("");

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
          
            loadData_Vao_GridView();

        }


        private void dvg_QuanLyLoaiDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void getThongTinMa(string ma)
        {
            LoaiDocGiaDTO dg = new LoaiDocGiaDTO();

            Console.WriteLine(" Ma da chon: " + ma);

            List<LoaiDocGiaDTO> listDocGia = ldgBus.select(ma);
            if (listDocGia == null) return;
            Console.WriteLine(" Get thong tin thanh cong.");
            dg = listDocGia[0];
            if (dg == null)
            {
                MessageBox.Show("Get thong tin DG tu db that bai");
            }
            else
            {
                this.textBox_TenLoaiDocGia.Text = dg.TenLoaiDocGia;

            }
        }

        private void dvg_QuanLyLoaiDocGia_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.dvg_QuanLyLoaiDocGia.CurrentRow.Index;
            string MaDG = dvg_QuanLyLoaiDocGia.Rows[index].Cells[0].Value + "";
            this.textBox_Ma.Text = MaDG;
            getThongTinMa(MaDG);


        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {

            //1. Map data from GUI
            LoaiDocGiaDTO ldg = new LoaiDocGiaDTO();
            ldg.MaLoaiDocGia = this.textBox_Ma.Text;
            
            DialogResult dlr = MessageBox.Show("Bạn có muốn xoa loai voi ma  " + ldg.MaLoaiDocGia + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = ldgBus.xoa(ldg);
                if (kq == false)
                    MessageBox.Show("Xóa loai độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Xóa loai độc giả thành công");
                    loadData_Vao_GridView();
                    this.dvg_QuanLyLoaiDocGia.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Không xóa.");
            }
        }
        private String TaoMa(String Ma)
        {
            String s = "";
            for (int i = 0; i < Ma.Length; i++)
            {
                if ((Ma[i] >= '0' & Ma[i] <= '9'))
                {
                    s += Ma[i];
                }
            }
            Console.WriteLine("Ma moi nhat: " + s);
            int _s = int.Parse(s);
            _s++;
            String _ma = "" + _s;
            while (_ma.Length < 3)
            {
                _ma = "0" + _ma;
            }
            _ma = "Loai" + _ma;
            return _ma;
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            LoaiDocGiaDTO ldg = new LoaiDocGiaDTO();
            List<LoaiDocGiaDTO> listldg = new List<LoaiDocGiaDTO>();
            listldg = ldgBus.select("");
            String Ma = this.TaoMa(listldg[listldg.Count - 1].MaLoaiDocGia);



            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thẻ với mã " + Ma + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                ldg.MaLoaiDocGia = Ma;

                ldg.TenLoaiDocGia = this.textBox_TenLoaiDocGia.Text;
               
              
                //2. Kiểm tra data hợp lệ or not
                if (ldg.TenLoaiDocGia.Length<=0)
                {

                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }


                //3. Thêm vào DB
                bool kq = ldgBus.them(ldg);
                if (kq == false)
                    MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Thêm Độc giả thành công");
                    this.loadData_Vao_GridView();
                   

                }
            }
            else
                MessageBox.Show("Không thêm.");



        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            LoaiDocGiaDTO ldg = new LoaiDocGiaDTO();
            ldg.MaLoaiDocGia = this.textBox_Ma.Text;
            ldg.TenLoaiDocGia = this.textBox_TenLoaiDocGia.Text;


            DialogResult dlr = MessageBox.Show("Bạn có muốn sửa thẻ với mã " + ldg.MaLoaiDocGia + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {


                //2. Kiểm tra data hợp lệ or not
                if (ldg.TenLoaiDocGia.Length <= 0)
                {

                    MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }


                //3. Thêm vào DB
                bool kq = ldgBus.sua(ldg);
                if (kq == false)
                    MessageBox.Show("Sửa Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Sửa Độc giả thành công");
                    this.loadData_Vao_GridView();
                }
            }
        }
    }
}
