using BUS;
using DAL;
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
    public partial class frmQuanLySach : Form
    {

        private SachBUS sachBUS;
        private TheLoaiBUS tlBUS;
        List<SachDTO> listSach;

        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            sachBUS = new SachBUS();
            tlBUS = new TheLoaiBUS();
            listSach = new List<SachDTO>();
            loadData_Vao_GridView("", SachDAL.TimToanBo);
            loadData_Vao_Combobox();

        }
        void AddColum(String key, String tag)
        {
            DataGridViewTextBoxColumn Temp = new DataGridViewTextBoxColumn();
            Temp.Name = key;
            Temp.HeaderText = tag;
            Temp.DataPropertyName = key;
            dataGridView_DanhSachSach.Columns.Add(Temp);
        }

        private void getThongTin(String ma) {
            SachDTO temp = new SachDTO();

            Console.WriteLine(" Ma da chon: " + ma);

            //    listDocGia = dgBus.select(ma, 0);
            if (listSach == null) return;
            foreach (SachDTO _temp in listSach)
            {
                if (_temp.Ma.IndexOf(ma) >= 0)
                {
                    temp = _temp;
                    break;
                }
            }

            if (temp == null)
            {
                MessageBox.Show("Get thong tin DG tu db that bai");
            }
            else
            {
                
                this.textBox_NhaXuatBan.Text = temp.NhaXuatBan;
                this.textBox_TacGia.Text = temp.TacGia;
                this.textBox_TenSach.Text = temp.TenSach;
                this.textBox_TriGia.Text = temp.TriGia + "";
                this.textBox_TacGia.Text = temp.TacGia;
                this.dateTimePicker_NamXuatBan.Value = temp.NamXuatBan;
                this.dateTimePicker_NgayNhap.Value = temp.NgayNhap;
                
                
                for (int i = 0; i < this.comboBox_TheLoai.Items.Count; i++)
                {
                    comboBox_TheLoai.SelectedIndex = i;
                    Console.WriteLine("Ma combox: " + comboBox_TheLoai.SelectedValue.ToString());
                    if (comboBox_TheLoai.SelectedValue.ToString().IndexOf(temp.MaTheLoai) >= 0)
                    {

                        break;
                    }
                }


            }


        }
        private void loadData_Vao_Combobox()
        {
            List<TheLoaiDTO> list = tlBUS.select("");

            if (list == null)
            {
                MessageBox.Show("Có lỗi khi lấy loại độc gải từ DB.");
                return;
            }
            this.comboBox_TheLoai.DataSource = new BindingSource(list, String.Empty);
            this.comboBox_TheLoai.DisplayMember = "TenTheLoai";
            this.comboBox_TheLoai.ValueMember = "MaTheLoai";

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[comboBox_TheLoai.DataSource];
            myCurrencyManager.Refresh();


            if (comboBox_TheLoai.Items.Count > 0)
            {
                comboBox_TheLoai.SelectedIndex = 0;
            }

        }
        private void loadData_Vao_GridView(List<SachDTO> listDocGia)
        {
            if (listDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu từ DB");
                return;
            }

            dataGridView_DanhSachSach.Columns.Clear();
            dataGridView_DanhSachSach.DataSource = null;

            dataGridView_DanhSachSach.AutoGenerateColumns = false;
            dataGridView_DanhSachSach.AllowUserToAddRows = false;
            dataGridView_DanhSachSach.DataSource = listDocGia;


            AddColum("Ma","Mã sách");
            AddColum("TenSach", "Tên sách");
            AddColum("TenTheLoai", "Tên thể loại");
            AddColum("TacGia", "Tác giả");
            AddColum("NhaXuatBan", "Nhà xuất bản");
            AddColum("NgayNhap", "Ngày nghập");
            AddColum("TriGia", "Trị giá");
            AddColum("NamXuatBan", "Năm xuất bản");
         
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView_DanhSachSach.DataSource];
            myCurrencyManager.Refresh();

        }

        private void loadData_Vao_GridView(string tag, int key)
        {
            listSach = new List<SachDTO>();
            switch (key)
            {
                case DocGiaDAL.TimToanBo:
                    {
                        listSach = sachBUS.select("", key);
                        break;
                    }
                case DocGiaDAL.TimBangMa:
                    {
                        listSach = sachBUS.select(tag, key);
                        break;
                    }
                case DocGiaDAL.TimBangTen:
                    {
                        listSach = sachBUS.select(tag, key);
                        break;
                    }
            }
            loadData_Vao_GridView(listSach);

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SachDTO temp = new SachDTO();


            temp.Ma = this.textBox_MaSach.Text;
            DialogResult dlr = MessageBox.Show("Bạn có muốn sửa thẻ với mã " + temp.Ma + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                temp.Ma = this.textBox_MaSach.Text;
                temp.MaTheLoai = this.comboBox_TheLoai.SelectedValue.ToString();
                temp.NamXuatBan = this.dateTimePicker_NamXuatBan.Value;
                temp.NgayNhap = this.dateTimePicker_NgayNhap.Value;
                temp.NhaXuatBan = this.textBox_NhaXuatBan.Text;
                temp.TacGia = this.textBox_TacGia.Text;
                temp.TenSach = this.textBox_TenSach.Text;
                temp.TriGia = int.Parse(this.textBox_TriGia.Text);

                //2. Kiểm tra data hợp lệ or not
                if (temp.Ma.Length * temp.MaTheLoai.Length * temp.NhaXuatBan.Length * temp.TenSach.Length <= 0 || temp.TriGia < 0)
                {

                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }
                //3. Thêm vào DB
                bool kq = sachBUS.sua(temp);
                if (kq == false)
                    MessageBox.Show("Sửa thông tin Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Sửa thông tin Độc giả thành công");
                    int tempIndex = this.dataGridView_DanhSachSach.CurrentRow.Index;
                    loadData_Vao_GridView("", SachDAL.TimToanBo);
                    dataGridView_DanhSachSach.FirstDisplayedScrollingRowIndex = tempIndex;


                }
            }
            else
                MessageBox.Show("Không sửa.");


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_DanhSachSach_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.dataGridView_DanhSachSach.CurrentRow.Index;
            string Ma = this.dataGridView_DanhSachSach.Rows[index].Cells[0].Value + "";
            this.textBox_MaSach.Text = Ma;
            this.getThongTin(Ma);
            Console.WriteLine("R=" + index + "   C=0  " + Ma);
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
            while (_ma.Length < 5)
            {
                _ma = "0" + _ma;
            }
            _ma = "SA" + _ma;
            return _ma;
        }
        private void button_ThemSach_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            SachDTO temp = new SachDTO();
            String Ma = this.TaoMa(this.listSach[this.listSach.Count - 1].Ma);



            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thẻ với mã " + Ma + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                temp.Ma =Ma;
                temp.MaTheLoai = this.comboBox_TheLoai.SelectedValue.ToString();
                temp.NamXuatBan = this.dateTimePicker_NamXuatBan.Value;
                temp.NgayNhap = this.dateTimePicker_NgayNhap.Value;
                temp.NhaXuatBan = this.textBox_NhaXuatBan.Text;
                temp.TacGia = this.textBox_TacGia.Text;
                temp.TenSach = this.textBox_TenSach.Text;
                temp.TriGia = int.Parse(this.textBox_TriGia.Text);

                //2. Kiểm tra data hợp lệ or not
                if (temp.Ma.Length * temp.MaTheLoai.Length * temp.NhaXuatBan.Length * temp.TenSach.Length <= 0 || temp.TriGia < 0)
                {

                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }


                //3. Thêm vào DB
                bool kq = sachBUS.them(temp);
                if (kq == false)
                    MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Thêm Độc giả thành công");
                    loadData_Vao_GridView("", SachDAL.TimToanBo);
                    this.dataGridView_DanhSachSach.FirstDisplayedScrollingRowIndex = dataGridView_DanhSachSach.RowCount - 1;

                }
            }
            else
                MessageBox.Show("Không thêm.");

        }

        private void button_XoaSach_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            SachDTO temp = new SachDTO();


            temp.Ma = this.textBox_MaSach.Text;
            DialogResult dlr = MessageBox.Show("Bạn có muốn xoa thẻ với mã " + temp.Ma + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = sachBUS.xoa(temp);
                if (kq == false)
                    MessageBox.Show("Xóa Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Xóa Độc giả thành công");
                    int tempIndex = this.dataGridView_DanhSachSach.CurrentRow.Index - 1;
                    loadData_Vao_GridView("", DocGiaDAL.TimToanBo);
                    dataGridView_DanhSachSach.FirstDisplayedScrollingRowIndex = tempIndex;
                }
            }
            else
            {
                MessageBox.Show("Không xóa.");
            }
        }
    }
}
