using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQuanLyTheLoai : Form
    {
        public frmQuanLyTheLoai()
        {
            InitializeComponent();
        }
        private TheLoaiBUS tlBUS;
        private void frmQuanLyTheLoai_Load(object sender, EventArgs e)
        {
             tlBUS = new TheLoaiBUS();
             loadData_Vao_GridView();
        }
        void loadData_Vao_GridView() {
            List<TheLoaiDTO> listTheLoai = tlBUS.select("");

            if (listTheLoai == null)
            {
                MessageBox.Show("Có lỗi khi lấy data từ DB");
                return;
            }



            dvg_QuanLyLoaiDocGia.Columns.Clear();
            dvg_QuanLyLoaiDocGia.DataSource = null;

            dvg_QuanLyLoaiDocGia.AutoGenerateColumns = false;
            dvg_QuanLyLoaiDocGia.AllowUserToAddRows = false;
            dvg_QuanLyLoaiDocGia.DataSource = listTheLoai;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaTheLoai";
            clMa.HeaderText = "Mã thể loại";
            clMa.DataPropertyName = "MaTheLoai";
            dvg_QuanLyLoaiDocGia.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "TenTheLoai";
            clTen.HeaderText = "Tên thể loại";
            clTen.DataPropertyName = "TenTheLoai";
            dvg_QuanLyLoaiDocGia.Columns.Add(clTen);



            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dvg_QuanLyLoaiDocGia.DataSource];
            myCurrencyManager.Refresh();

        }

        private void getThongTinMa(String ma) {

            TheLoaiDTO tl = new TheLoaiDTO();

            Console.WriteLine(" Ma da chon: " + ma);

            List<TheLoaiDTO> listTheLoai = tlBUS.select(ma);
            if (listTheLoai == null) return;
            Console.WriteLine(" Get thong tin thanh cong.");
            tl = listTheLoai[0];
            if (tl == null)
            {
                MessageBox.Show("Get thong tin DG tu db that bai");
            }
            else
            {
                this.textBox_TenLoaiDocGia.Text = tl.TenTheLoai;
                this.textBox_Ma.Text = tl.MaTheLoai;

            }
        }

        private void bnt_Load_Click(object sender, EventArgs e)
        {
            loadData_Vao_GridView();


        }


        private void dvg_QuanLyLoaiDocGia_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.dvg_QuanLyLoaiDocGia.CurrentRow.Index;
            string MaDG = dvg_QuanLyLoaiDocGia.Rows[index].Cells[0].Value + "";
            getThongTinMa(MaDG);
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            TheLoaiDTO temp = new TheLoaiDTO();
            temp.MaTheLoai = this.textBox_Ma.Text;

            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa thể loại với mã  " + temp.MaTheLoai + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = tlBUS.xoa(temp);
                if (kq == false)
                    MessageBox.Show("Xóa thể loai thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Xóa thể loai thành công");
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
            _ma = "ThLo" + _ma;
            return _ma;
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            TheLoaiDTO temp = new TheLoaiDTO();
            List<TheLoaiDTO> listtl = new List<TheLoaiDTO>();
            listtl = tlBUS.select("");
            String Ma = this.TaoMa(listtl[listtl.Count - 1].MaTheLoai);
            


            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thể loại với mã " + Ma + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                temp.MaTheLoai = Ma;

                temp.TenTheLoai = this.textBox_TenLoaiDocGia.Text;


                //2. Kiểm tra data hợp lệ or not
                if (temp.MaTheLoai.Length <= 0)
                {

                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }


                //3. Thêm vào DB
                bool kq = tlBUS.them(temp);
                if (kq == false)
                    MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Thêm thành công");
                    this.loadData_Vao_GridView();


                }
            }
            else
                MessageBox.Show("Không thêm.");


        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.MaTheLoai = this.textBox_Ma.Text;
            tl.TenTheLoai = this.textBox_TenLoaiDocGia.Text;


            DialogResult dlr = MessageBox.Show("Bạn có muốn sửa thể loại với mã " + tl.MaTheLoai + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {


                //2. Kiểm tra data hợp lệ or not
                if (tl.TenTheLoai.Length <= 0)
                {

                    MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }


                //3. Thêm vào DB
                bool kq = tlBUS.sua(tl);
                if (kq == false)
                    MessageBox.Show("Sửa thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Sửa thành công");
                    this.loadData_Vao_GridView();
                }
            }
        }
    }
}
