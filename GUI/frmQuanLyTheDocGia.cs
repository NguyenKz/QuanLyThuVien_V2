using BUS;
using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//haha
namespace QLThuVien
{
    public partial class frmQuanLyTheDocGia : Form
    {
        private DocGiaBUS dgBus;
        private LoaiDocGiaBUS ldgBus;
        
        public const int TimToanBo = 0;
        public const int TimBangMa = 1;
        public const int TimBangTen = 2;
        List<DocGiaDTO> listDocGia;
        List<QuyDinhDTO> listQD;
        private QuyDinhBUS qdBUS;
        public frmQuanLyTheDocGia()
        {
            InitializeComponent();
        }



        private void loadLoaiDocGia_Combobox()
        {
            List<LoaiDocGiaDTO> listLoaiDocGia = ldgBus.select("");

            if (listLoaiDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy loại độc gải từ DB.");
                return;
            }
            comboBox_LoaiDocGia.DataSource = new BindingSource(listLoaiDocGia, String.Empty);
            comboBox_LoaiDocGia.DisplayMember = "tenLoaiDocGia";
            comboBox_LoaiDocGia.ValueMember = "maLoaiDocGia";

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[comboBox_LoaiDocGia.DataSource];
            myCurrencyManager.Refresh();


            if (comboBox_LoaiDocGia.Items.Count > 0)
            {
                comboBox_LoaiDocGia.SelectedIndex = 0;
            }

        }
        private void loadData_Vao_GridView(List<DocGiaDTO> listDocGia) {
            if (listDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu từ DB");
                return;
            }

            dgv_QuanLyTheDocGia.Columns.Clear();
            dgv_QuanLyTheDocGia.DataSource = null;

            dgv_QuanLyTheDocGia.AutoGenerateColumns = false;
            dgv_QuanLyTheDocGia.AllowUserToAddRows = false;
            dgv_QuanLyTheDocGia.DataSource = listDocGia;




            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maDocGia";
            clMa.HeaderText = "Mã độc giả";
            clMa.DataPropertyName = "Ma";
            dgv_QuanLyTheDocGia.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "hoVaTenDocGia";
            clTen.HeaderText = "Tên độc giả";
            clTen.DataPropertyName = "HoVaTen";
            dgv_QuanLyTheDocGia.Columns.Add(clTen);



            DataGridViewTextBoxColumn clNgaySinh = new DataGridViewTextBoxColumn();
            clNgaySinh.DefaultCellStyle.Format = "dd/MM/yyyy";
            clNgaySinh.Name = "NgaySinh";
            clNgaySinh.HeaderText = "Ngày sinh";
            clNgaySinh.DataPropertyName = "NgaySinh";
            dgv_QuanLyTheDocGia.Columns.Add(clNgaySinh);


            DataGridViewTextBoxColumn clDiaChi = new DataGridViewTextBoxColumn();
            clDiaChi.Name = "DiaChi";
            clDiaChi.HeaderText = "Địa chỉ";
            clDiaChi.DataPropertyName = "DiaChi";
            dgv_QuanLyTheDocGia.Columns.Add(clDiaChi);

            DataGridViewTextBoxColumn clEmail = new DataGridViewTextBoxColumn();
            clEmail.Name = "email";
            clEmail.HeaderText = "Email";
            clEmail.DataPropertyName = "email";
            dgv_QuanLyTheDocGia.Columns.Add(clEmail);


            DataGridViewTextBoxColumn clTenLoaiDocGia = new DataGridViewTextBoxColumn();
            clTenLoaiDocGia.Name = "maLoaiDocGia";
            clTenLoaiDocGia.HeaderText = "Loại độc giả";
            clTenLoaiDocGia.DataPropertyName = "TenLoaiDocGia";
            dgv_QuanLyTheDocGia.Columns.Add(clTenLoaiDocGia);


            DataGridViewTextBoxColumn clNgayLapThe = new DataGridViewTextBoxColumn();
            clNgayLapThe.DefaultCellStyle.Format = "dd/MM/yyyy";
            clNgayLapThe.Name = "NgayLapThe";
            clNgayLapThe.HeaderText = "Ngày lập thẻ";
            clNgayLapThe.DataPropertyName = "NgayLapThe";
            dgv_QuanLyTheDocGia.Columns.Add(clNgayLapThe);


            DataGridViewTextBoxColumn clHanSuDung = new DataGridViewTextBoxColumn();
            clHanSuDung.Name = "HanSuDung";
            clHanSuDung.HeaderText = "Hạn sử dụng";
            clHanSuDung.DataPropertyName = "HanSuDung";
            dgv_QuanLyTheDocGia.Columns.Add(clHanSuDung);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgv_QuanLyTheDocGia.DataSource];
            myCurrencyManager.Refresh();

        }
        private void loadData_Vao_GridView(string tag, int key)
        {
            listDocGia = new List<DocGiaDTO>();
            switch (key)
            {
                case DocGiaDAL.TimToanBo:
                    {
                        listDocGia = dgBus.select("", key);
                        break;
                    }
                case DocGiaDAL.TimBangMa:
                    {
                        listDocGia = dgBus.select(tag, key);
                        break;
                    }
                case DocGiaDAL.TimBangTen:
                    {
                        listDocGia = dgBus.select(tag, key);
                        break;
                    }
            }
            loadData_Vao_GridView(listDocGia);



        }
        private void getThongTinDocGia(string ma)
        {
            DocGiaDTO dg = new DocGiaDTO();

            Console.WriteLine(" Ma da chon: " + ma);

            //    listDocGia = dgBus.select(ma, 0);
            if (listDocGia == null) return;
            foreach (DocGiaDTO _dg in listDocGia)
            {
                if (_dg.Ma.IndexOf(ma) >= 0) {
                    dg = _dg;
                    break;
                }
            }

            if (dg == null)
            {
                MessageBox.Show("Get thong tin DG tu db that bai");
            }
            else
            {
                textBox_HoVaTen.Text = dg.HovaTen;
                textBox_DiaChi.Text = dg.DiaChi;
                textBox_Email.Text = dg.Email;
                textBox_HanSuDung.Text = dg.HanSuDung + "";
                dateTimePicker_NgaySinh.Value = dg.NgaySinh;
                dateTimePicker_NgayLapThe.Value = dg.NgayLapThe;

                for (int i = 0; i < comboBox_LoaiDocGia.Items.Count; i++)
                {
                    comboBox_LoaiDocGia.SelectedIndex = i;
                    Console.WriteLine("Ma combox: " + comboBox_LoaiDocGia.SelectedValue.ToString());
                    if (comboBox_LoaiDocGia.SelectedValue.ToString().IndexOf(dg.maLoaiDocGia) >= 0)
                    {

                        break;
                    }
                }


            }
        }


        private void AddDataToCmbTimKiem()
        {
            this.comboBox_TimKiem.Items.Insert(DocGiaDAL.TimToanBo, "Toàn bộ");
            this.comboBox_TimKiem.Items.Insert(DocGiaDAL.TimBangMa, "Tìm bằng mã");
            this.comboBox_TimKiem.Items.Insert(DocGiaDAL.TimBangTen, "Tìm bằng tên");
            this.comboBox_TimKiem.SelectedIndex = 0;

        }


        private void frmQuanLyTheDocGia_Load(object sender, EventArgs e)
        {


            dgBus = new DocGiaBUS();
            ldgBus = new LoaiDocGiaBUS();
            listDocGia = new List<DocGiaDTO>();
            loadData_Vao_GridView("", DocGiaDAL.TimToanBo);
            
            loadLoaiDocGia_Combobox();
            AddDataToCmbTimKiem();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadData_Vao_GridView("", DocGiaDAL.TimToanBo);
        }

        private void dgv_QuanLyTheDocGia_MouseClick(object sender, MouseEventArgs e)
        {
            int index = dgv_QuanLyTheDocGia.CurrentRow.Index;
            string MaDG = dgv_QuanLyTheDocGia.Rows[index].Cells[0].Value + "";
            textBox_Ma.Text = MaDG;
            getThongTinDocGia(MaDG);
            Console.WriteLine("R=" + index + "   C=0  " + MaDG);
        }

        private void textBox_Ma_TextChanged(object sender, EventArgs e)
        {
            getThongTinDocGia(textBox_Ma.Text);
        }
        private String TaoMa(String Ma)
        {
            String s = "";
            for (int i = 0; i < Ma.Length; i++) {
                if ((Ma[i]>='0' & Ma[i]<='9')){
                    s += Ma[i];
                }
            }
            Console.WriteLine("Ma moi nhat: "+s);
            int _s = int.Parse(s);
            _s++;
            String _ma = "" + _s;
            while (_ma.Length < 5)
            {
                _ma = "0" + _ma;
            }
            _ma = "DG" + _ma;
            return _ma;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             //1. Map data from GUI
            DocGiaDTO dg = new DocGiaDTO();
            String Ma = this.TaoMa(listDocGia[listDocGia.Count - 1].Ma);

            
   
            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thẻ với mã "+Ma+" không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                dg.Ma = Ma;

                dg.HovaTen = textBox_HoVaTen.Text;
                dg.maLoaiDocGia = comboBox_LoaiDocGia.SelectedValue.ToString();
                dg.NgayLapThe = dateTimePicker_NgayLapThe.Value;
                dg.NgaySinh = dateTimePicker_NgaySinh.Value;
                dg.DiaChi = textBox_DiaChi.Text;
                dg.Email = textBox_Email.Text;
                
                dg.HanSuDung = int.Parse("0"+textBox_HanSuDung.Text);

                if ((DateTime.Now.Subtract( dg.NgaySinh).TotalDays/365)<listQD[0].TuoiToiThieu|| (DateTime.Now.Subtract(dg.NgaySinh).TotalDays / 365) > listQD[0].TuoiToiDa)
                {
                    MessageBox.Show("Thêm thất bại, tuổi độc giả phải từ"+ listQD[0].TuoiToiThieu+" đến "+ listQD[0].TuoiToiDa);
                    return;
                }


                //2. Kiểm tra data hợp lệ or not
                if (dg.HovaTen.Length*dg.maLoaiDocGia.Length*dg.DiaChi.Length*dg.Email.Length*dg.Ma.Length<=0||dg.HanSuDung<=0) {

                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }
                

                //3. Thêm vào DB
                bool kq = dgBus.them(dg);
                if (kq == false)
                    MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Thêm Độc giả thành công");
                    loadData_Vao_GridView("", DocGiaDAL.TimToanBo);
                    dgv_QuanLyTheDocGia.FirstDisplayedScrollingRowIndex = dgv_QuanLyTheDocGia.RowCount-1;

                }
            }
            else
                MessageBox.Show("Không thêm.");







           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DocGiaDTO dg = new DocGiaDTO();


            dg.Ma = textBox_Ma.Text;
            DialogResult dlr = MessageBox.Show("Bạn có muốn sửa thẻ với mã " + dg.Ma + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                dg.HovaTen = textBox_HoVaTen.Text;
                dg.maLoaiDocGia = comboBox_LoaiDocGia.SelectedValue.ToString();
                dg.NgayLapThe = dateTimePicker_NgayLapThe.Value;
                dg.NgaySinh = dateTimePicker_NgaySinh.Value;
                dg.DiaChi = textBox_DiaChi.Text;
                dg.Email = textBox_Email.Text;
                dg.HanSuDung = int.Parse("0" + textBox_HanSuDung.Text);
                if ((DateTime.Now.Subtract(dg.NgaySinh).TotalDays / 365) < 18 || (DateTime.Now.Subtract(dg.NgaySinh).TotalDays / 365) > 55)
                {
                    MessageBox.Show("Sửa thất bại, tuổi độc giả phải từ 18 đến 55.");
                    return;
                }
                //2. Kiểm tra data hợp lệ or not
                if (dg.HovaTen.Length * dg.maLoaiDocGia.Length * dg.DiaChi.Length * dg.Email.Length * dg.Ma.Length <= 0 || dg.HanSuDung <= 0)
                {

                    MessageBox.Show("Cập nhật thất bại, vui lòng kiểm tra lại thông tin.");
                    return;
                }
                //3. Thêm vào DB
                bool kq = dgBus.sua(dg);
                if (kq == false)
                    MessageBox.Show("Sửa thông tin Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Sửa thông tin Độc giả thành công");
                    int tempIndex = dgv_QuanLyTheDocGia.CurrentRow.Index;
                    loadData_Vao_GridView("", DocGiaDAL.TimToanBo);
                    dgv_QuanLyTheDocGia.FirstDisplayedScrollingRowIndex = tempIndex;


                }
            }
            else
                MessageBox.Show("Không sửa.");

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            DocGiaDTO dg = new DocGiaDTO();


            dg.Ma = this.textBox_Ma.Text;
            DialogResult dlr = MessageBox.Show("Khi xóa thẻ đọc giả thì các dữ liệu liên quan cũng sẽ bị xóa.\nBạn có muốn xoa thẻ với mã " + dg.Ma + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = dgBus.xoa(dg);
                if (kq == false)
                    MessageBox.Show("Xóa Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else { 
                    MessageBox.Show("Xóa Độc giả thành công");
                    int tempIndex = dgv_QuanLyTheDocGia.CurrentRow.Index-1;
                    loadData_Vao_GridView("", DocGiaDAL.TimToanBo);
                    dgv_QuanLyTheDocGia.FirstDisplayedScrollingRowIndex = tempIndex;
                }
            }
            else
            {
                MessageBox.Show("Không xóa.");
            }
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
            return text;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int key = this.comboBox_TimKiem.SelectedIndex;
            switch (key) {
                case TimToanBo: {
                        loadData_Vao_GridView(listDocGia);
                        break;
                    }
                case TimBangMa: {
                        List<DocGiaDTO> ls = new List<DocGiaDTO>();
                        foreach (DocGiaDTO dg in listDocGia)
                        {
                            String key1 = RemoveUnicode(dg.Ma);
                            key1 = key1.ToUpper();
                            String key2 = RemoveUnicode(textBox_TimKiem.Text);
                            key2 = key2.ToUpper();
                            if (key1.IndexOf(key2) >= 0)
                            {
                                ls.Add(dg);
                            }
                        }
                        loadData_Vao_GridView(ls);
                        break;
                    }
                case TimBangTen:
                    {
                        List<DocGiaDTO> ls = new List<DocGiaDTO>();
                        foreach (DocGiaDTO dg in listDocGia)
                        {
                            String key1 = RemoveUnicode(dg.HovaTen);
                            key1 = key1.ToUpper();
                            String key2 = RemoveUnicode(textBox_TimKiem.Text);
                            key2 = key2.ToUpper();
                            if (key1.IndexOf(key2) >= 0)
                            {
                                ls.Add(dg);
                            }
                        }
                        loadData_Vao_GridView(ls);

                        break;
                    }
            }
            
        }

        private void comboBox_LoaiDocGia_TextChanged(object sender, EventArgs e)
        {
           // this.comboBox_LoaiDocGia.
           /* String temp = this.comboBox_LoaiDocGia.Text;
           // this.comboBox_LoaiDocGia.Text = "";
            for (int i = 0; i < this.comboBox_LoaiDocGia.Items.Count; i++) {
                Console.WriteLine(((LoaiDocGiaDTO)this.comboBox_LoaiDocGia.Items[i]).TenLoaiDocGia);
                if (((LoaiDocGiaDTO)this.comboBox_LoaiDocGia.Items[i]).TenLoaiDocGia.IndexOf(temp)==0) {
                    this.comboBox_LoaiDocGia.SelectedIndex = i;
                    this.comboBox_LoaiDocGia.Text = ((LoaiDocGiaDTO)this.comboBox_LoaiDocGia.Items[i]).TenLoaiDocGia;

                    break;
                }
            }
            */
        }

        private void comboBox_LoaiDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_QuanLyTheDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
