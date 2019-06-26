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
//haha
namespace QLThuVien
{
    public partial class frmQuanLyTheDocGia : Form
    {
        private DocGiaBUS dgBus;
        private LoaiDocGiaBUS ldgBus;
        public const int TimBangMa= 1;
        public const int TimBangTen = 2;
        
        public frmQuanLyTheDocGia()
        {
            InitializeComponent();
        }



        private void loadLoaiDocGia_Combobox()
        {
            List<LoaiDocGiaDTO> listLoaiDocGia = ldgBus.select();

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

            DocGiaDTO dg = new DocGiaDTO();
            dg = dgBus.get(textBox_Ma.Text);

            if (comboBox_LoaiDocGia.Items.Count > 0)
            {                       
                comboBox_LoaiDocGia.SelectedIndex = 0;               
            }

        }
        private void loadData_Vao_GridView(int key)
        {
            List<DocGiaDTO> listDocGia = new List<DocGiaDTO>();
            switch (key)
            {
                case 0:
                    {
                        listDocGia = dgBus.select();
                        break;
                    }
                case TimBangMa:
                    {
                        listDocGia.Add(dgBus.get(this.textBox_TimKiem.Text)) ;
                        break;
                    }
                case TimBangTen:
                    {
                        listDocGia=dgBus.TimKiemBangTen(this.textBox_TimKiem.Text);
                        break;
                    }
            }


            if (listDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy Món ăn từ DB");
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

            DataGridViewTextBoxColumn clEmail= new DataGridViewTextBoxColumn();
            clEmail.Name = "email";
            clEmail.HeaderText = "Email";
            clEmail.DataPropertyName = "email";
            dgv_QuanLyTheDocGia.Columns.Add(clEmail);


            DataGridViewTextBoxColumn clTenLoaiDocGia = new DataGridViewTextBoxColumn();
            clTenLoaiDocGia.Name = "TenLoaiDocGia";
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
        private void getThongTinDocGia( string ma)
        {
            DocGiaDTO dg = new DocGiaDTO();
            Console.WriteLine(" Ma da chon: " + ma);
            dg = dgBus.get(ma);
            if (dg == null)
            {
                MessageBox.Show("Get thong tin DG tu db that bai");
            }
            else
            {
                textBox_HoVaTen.Text = dg.HovaTen;
                textBox_DiaChi.Text = dg.DiaChi;
                textBox_Email.Text = dg.Email;
                textBox_HanSuDung.Text = dg.HanSuDung+"";
                dateTimePicker_NgaySinh.Value = dg.NgaySinh;
                dateTimePicker_NgayLapThe.Value = dg.NgayLapThe;

                for (int i=0;i< comboBox_LoaiDocGia.Items.Count; i++)
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
            this.comboBox_TimKiem.Items.Insert(0, "bằng mã");
            this.comboBox_TimKiem.Items.Insert(TimBangMa, "Tìm bằng mã");
            this.comboBox_TimKiem.Items.Insert(TimBangTen, "Tìm bằng tên");
            this.comboBox_TimKiem.SelectedIndex = 0;

        }


        private void frmQuanLyTheDocGia_Load(object sender, EventArgs e)
        {


            dgBus = new DocGiaBUS();
            ldgBus = new LoaiDocGiaBUS();
            loadData_Vao_GridView(0);
            loadLoaiDocGia_Combobox();
            AddDataToCmbTimKiem();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadData_Vao_GridView(0);
        }

        private void dgv_QuanLyTheDocGia_MouseClick(object sender, MouseEventArgs e)
        {
            int index = dgv_QuanLyTheDocGia.CurrentRow.Index;
            string MaDG = dgv_QuanLyTheDocGia.Rows[index].Cells[0].Value + "";
            textBox_Ma.Text = MaDG;
            Console.WriteLine("R="+index+"   C=0  "+MaDG);
        }

        private void textBox_Ma_TextChanged(object sender, EventArgs e)
        {
            getThongTinDocGia(textBox_Ma.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             //1. Map data from GUI
            DocGiaDTO dg = new DocGiaDTO();

            int SoLuongDocGia = dgv_QuanLyTheDocGia.RowCount+1;

            string Ma = SoLuongDocGia+"";
            while (Ma.Length < 5)
            {
                Ma = "0" + Ma;
            }
            Ma = "DG" + Ma;

            

            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thẻ với mã "+Ma+" khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                dg.Ma = Ma;

                dg.HovaTen = textBox_HoVaTen.Text;
                dg.maLoaiDocGia = comboBox_LoaiDocGia.SelectedValue.ToString();
                dg.NgayLapThe = dateTimePicker_NgayLapThe.Value;
                dg.NgaySinh = dateTimePicker_NgaySinh.Value;
                dg.DiaChi = textBox_DiaChi.Text;
                dg.Email = textBox_Email.Text;
                dg.HanSuDung = int.Parse(textBox_HanSuDung.Text);

                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = dgBus.them(dg);
                if (kq == false)
                    MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Thêm Độc giả thành công");
                    loadData_Vao_GridView(0);
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
                dg.HanSuDung = int.Parse(textBox_HanSuDung.Text);

                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = dgBus.sua(dg);
                if (kq == false)
                    MessageBox.Show("Sửa thông tin Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Sửa thông tin Độc giả thành công");
                    int tempIndex = dgv_QuanLyTheDocGia.CurrentRow.Index;
                    loadData_Vao_GridView(0);
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
            DialogResult dlr = MessageBox.Show("Bạn có muốn xoa thẻ với mã " + dg.Ma + " khổng?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                    loadData_Vao_GridView(0);
                    dgv_QuanLyTheDocGia.FirstDisplayedScrollingRowIndex = tempIndex;
                }
            }
            else
            {
                MessageBox.Show("Không xóa.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int key = this.comboBox_TimKiem.SelectedIndex;
            switch (key)
            {
                case TimBangMa:
                    {
                        loadData_Vao_GridView(TimBangMa);

                        break;
                    }


            }
        }
    }
}
