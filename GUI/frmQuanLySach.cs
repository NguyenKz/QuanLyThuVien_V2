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
        public const int TimToanBo = 0;
        public const int TimBangMa = 1;
        public const int TimBangTen = 2;
        List<QuyDinhDTO> listQD;
        private QuyDinhBUS qdBUS;
        List<SachDTO> listSach;

        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void AddDataToCmbTimKiem()
        {
            this.comboBox_PhuongThucTimKiem.Items.Insert(TimToanBo, "Toàn bộ");
            this.comboBox_PhuongThucTimKiem.Items.Insert(TimBangMa, "Tìm bằng mã");
            this.comboBox_PhuongThucTimKiem.Items.Insert(TimBangTen, "Tìm bằng tên");
            this.comboBox_PhuongThucTimKiem.SelectedIndex = 0;

        }
        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            qdBUS = new QuyDinhBUS();
            listQD = new List<QuyDinhDTO>();
            listQD = qdBUS.select();

            sachBUS = new SachBUS();
            tlBUS = new TheLoaiBUS();
            listSach = new List<SachDTO>();
            List<PhieuMuonDTO> ls = new PhieuMuonBUS().select();
            listSach = sachBUS.select(ls);
            loadData_Vao_GridView(listSach);
            loadData_Vao_Combobox();
            AddDataToCmbTimKiem();
            this.dateTimePicker_NgayNhap.Value = DateTime.Now;

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
                MessageBox.Show("Get thong tin sách tu db that bai");
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
                MessageBox.Show("Có lỗi khi lấy thể loại từ DB.");
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
            AddColum("TìnhTrang", "Tình trạng");
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView_DanhSachSach.DataSource];
            myCurrencyManager.Refresh();

        }
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text.ToUpper();
        }

   
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SachDTO temp = new SachDTO();


            temp.Ma = this.textBox_MaSach.Text;
            DialogResult dlr = MessageBox.Show("Bạn có muốn sửa sách với mã " + temp.Ma + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

                    MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }
                //3. Thêm vào DB
                bool kq = sachBUS.sua(temp);
                if (kq == false)
                    MessageBox.Show("Sửa thông tin sách thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Sửa thông tin sách thành công");
                    List<PhieuMuonDTO> ls = new PhieuMuonBUS().select();
                    listSach = sachBUS.select(ls);
                    loadData_Vao_GridView(listSach);

                  

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



            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm sách với mã " + Ma + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                if ((DateTime.Now.Subtract(temp.NamXuatBan).TotalDays / 365) > listQD[0].KhoangCachNamXuatBan)
                {
                    MessageBox.Show("Thêm thất bại, chỉ nhận các sách xuất bản trong vòng "+ listQD[0].KhoangCachNamXuatBan+" năm.");
                    return;
                }
                //2. Kiểm tra data hợp lệ or not
                if (temp.Ma.Length * temp.MaTheLoai.Length * temp.NhaXuatBan.Length * temp.TenSach.Length <= 0 || temp.TriGia < 0)
                {

                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }


                //3. Thêm vào DB
                bool kq = sachBUS.them(temp);
                if (kq == false)
                    MessageBox.Show("Thêm sách thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Thêm sách thành công");
                    List<PhieuMuonDTO> ls = new PhieuMuonBUS().select();
                    listSach = sachBUS.select(ls);
                    loadData_Vao_GridView(listSach);

                   

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
            DialogResult dlr = MessageBox.Show("Bạn có muốn xoa sách với mã " + temp.Ma + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                //2. Kiểm tra data hợp lệ or not
                MessageBox.Show("Có thê không xóa được vì dữ liệu liên quan đến dữ liệu khác.");
                //3. Thêm vào DB
                bool kq = sachBUS.xoa(temp);
                if (kq == false)
                    MessageBox.Show("Xóa sách thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    List<PhieuMuonDTO> ls = new PhieuMuonBUS().select();
                    listSach = sachBUS.select(ls);
                    loadData_Vao_GridView(listSach);

                   
                    MessageBox.Show("Xóa sách thành công");
                    
                    
                }
            }
            else
            {
                MessageBox.Show("Không xóa.");
            }
        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            int key = this.comboBox_PhuongThucTimKiem.SelectedIndex;
            switch (key)
            {
                case TimToanBo:
                    {
                        loadData_Vao_GridView(listSach);
                        break;
                    }
                case TimBangMa:
                    {
                        List<SachDTO> ls = new List<SachDTO>();
                        foreach (SachDTO sa in listSach)
                        {
                            String key1 = RemoveUnicode(sa.Ma);
                            key1 = key1.ToUpper();
                            String key2 = RemoveUnicode(this.textBox_NoiDungTimKiem.Text);
                            key2 = key2.ToUpper();
                            if (key1.IndexOf(key2) >= 0)
                            {
                                ls.Add(sa);
                            }
                        }
                        loadData_Vao_GridView(ls);
                        break;
                    }
                case TimBangTen:
                    {
                        List<SachDTO> ls = new List<SachDTO>();
                        foreach (SachDTO sa in listSach)
                        {
                            String key1 = RemoveUnicode(sa.TenSach);
                            key1 = key1.ToUpper();
                            String key2 = RemoveUnicode(textBox_NoiDungTimKiem.Text);
                            key2 = key2.ToUpper();
                            if (key1.IndexOf(key2) >= 0)
                            {
                                ls.Add(sa);
                            }
                        }
                        loadData_Vao_GridView(ls);

                        break;
                    }
            }

        }

        private void dateTimePicker_NgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (this.dateTimePicker_NamXuatBan.Value > DateTime.Now)
            {
                this.dateTimePicker_NamXuatBan.Value = DateTime.Now;
            }

            if (this.dateTimePicker_NgayNhap.Value > DateTime.Now)
            {
                this.dateTimePicker_NgayNhap.Value = DateTime.Now;
            }
            if (this.dateTimePicker_NgayNhap.Value < this.dateTimePicker_NamXuatBan.Value)
            {
                this.dateTimePicker_NgayNhap.Value = this.dateTimePicker_NamXuatBan.Value;
            }
        }
    }
}
