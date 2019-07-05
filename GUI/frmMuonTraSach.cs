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
    public partial class frmMuonTraSach : Form
    {


        public const int ToanBo = 0;
        public const int MaPhieuMuon = 1;
        public const int MaPhieuTra = 2;
        public const int MaDocGai = 3;
        public const int MaSach = 4;
        private DocGiaBUS dgBus;
        private LoaiDocGiaBUS ldgBus;
        private SachBUS sachBus;
        private PhieuMuonBUS pmBus;
        private List<DocGiaDTO> listDocGia;
        private List<SachDTO> listSach;
        private List<PhieuMuonDTO> listPhieuMuon;
        private Boolean DuLieuDung_DocGia = true;
        private Boolean DuLieuDung_Sach = true;
        private Boolean DuLieuDung_ThoiHan = true;
        public frmMuonTraSach()
        {
            InitializeComponent();
        }
        private void loadLoaiDocGia_Combobox()
        {
            listDocGia = dgBus.select("",0);

            if (listDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy loại độc gải từ DB.");
                return;
            }
            this.comboBox_MaDocGia.DataSource = new BindingSource(listDocGia, String.Empty);
            this.comboBox_MaDocGia.DisplayMember = "Ma";
            this.comboBox_MaDocGia.ValueMember = "Ma";

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.comboBox_MaDocGia.DataSource];
            myCurrencyManager.Refresh();


            if (this.comboBox_MaDocGia.Items.Count > 0)
            {
                this.comboBox_MaDocGia.SelectedIndex = 0;
            }

        }
        private void LoadTatCaPhieuMuonTra()
        {
            listPhieuMuon = pmBus.select("", 0);



        }


        void AddColum(String key, String tag)
        {
            DataGridViewTextBoxColumn Temp = new DataGridViewTextBoxColumn();
            Temp.Name = key;
            Temp.HeaderText = tag;
            Temp.DataPropertyName = key;
            this.dataGridView_Data.Columns.Add(Temp);
        }
        private void loadData_Vao_GridView(List<PhieuMuonDTO> listDocGia)
        {
            if (listDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu từ DB");
                return;
            }

            dataGridView_Data.Columns.Clear();
            dataGridView_Data.DataSource = null;

            dataGridView_Data.AutoGenerateColumns = false;
            dataGridView_Data.AllowUserToAddRows = false;
            dataGridView_Data.DataSource = listDocGia;


            AddColum("MaPhieuMuon", "Ma phiếu mượn");
            AddColum("MaPhieuTra", "Ma phiêu trả");
            AddColum("MaSach", "Ma sách");
            AddColum("MaDocGia", "Ma đọc giả");
            AddColum("NgayMuon", "Ngày mượn");
            AddColum("NgayTra", "Ngày trả");
            AddColum("StrTinhTrang", "Tình trạng");
            AddColum("SoNgayQuaHan", "Số ngày quá hạn");
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView_Data.DataSource];
            myCurrencyManager.Refresh();

        }


        private void loadMaSach_Combobox()
        {
            this.listSach = this.sachBus.select("", 0);

            if (listDocGia == null)
            {
                MessageBox.Show("Có lỗi khi lấy loại độc gải từ DB.");
                return;
            }
            this.comboBox_MaSach.DataSource = new BindingSource(listSach, String.Empty);
            this.comboBox_MaSach.DisplayMember = "Ma";
            this.comboBox_MaSach.ValueMember = "Ma";

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.comboBox_MaSach.DataSource];
            myCurrencyManager.Refresh();


            if (this.comboBox_MaSach.Items.Count > 0)
            {
                this.comboBox_MaSach.SelectedIndex = 0;
            }

        }



        private void frmMuonTraSach_Load(object sender, EventArgs e)
        {
            this.comboBox_PhuongThuc.Items.Insert(0, "Toàn bộ");
            this.comboBox_PhuongThuc.Items.Insert(1, "Bằng mã phiếu mượn");
            this.comboBox_PhuongThuc.Items.Insert(2, "Bằng mã phiếu trả");
            this.comboBox_PhuongThuc.Items.Insert(3, "Bằng mã đọc giả");
            this.comboBox_PhuongThuc.Items.Insert(4, "Bằng mã sách");
            this.comboBox_PhuongThuc.SelectedIndex = 0;
            dgBus = new DocGiaBUS();
            sachBus = new SachBUS();
            ldgBus = new LoaiDocGiaBUS();
            pmBus = new PhieuMuonBUS();
            listPhieuMuon = new List<PhieuMuonDTO>();
            listDocGia = new List<DocGiaDTO>();
            listSach=new List<SachDTO>();
            //  loadData_Vao_GridView("", DocGiaDAL.TimToanBo);
            listPhieuMuon = pmBus.select("", 0);
            loadLoaiDocGia_Combobox();
            loadMaSach_Combobox();
            loadData_Vao_GridView(listPhieuMuon);
        }
        private void getThongTinSach(string ma)
        {
            SachDTO sach = new SachDTO();



            //    listDocGia = dgBus.select(ma, 0);
            if (listSach == null) return;
            Console.WriteLine(" Ma da chon: " + ma);
            foreach (SachDTO _sach in listSach)
            {
                Console.WriteLine(_sach.TenSach);
                if (_sach.Ma.IndexOf(ma) >= 0)
                {
                    Console.WriteLine(_sach.TenSach);
                    sach = _sach;
                    break;
                }
            }

            if (sach == null)
            {
                MessageBox.Show("Get thong tin DG tu db that bai");
            }
            else
            {
                this.textBox_TenSach.Text = sach.TenSach;




            }
        }
        private void getThongTinDocGia(string ma)
        {
            DocGiaDTO dg = new DocGiaDTO();

           

            //    listDocGia = dgBus.select(ma, 0);
            if (listDocGia == null) return;
            Console.WriteLine(" Ma da chon: " + ma);
            foreach (DocGiaDTO _dg in listDocGia)
            {
                Console.WriteLine(_dg.HovaTen);
                if (_dg.Ma.IndexOf(ma) >= 0)
                {
                    Console.WriteLine(_dg.HovaTen);
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
                this.textBox_TenDocGia.Text = dg.HovaTen;

           


            }
        }
        private void comboBox_MaDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.comboBox_MaDocGia.SelectedValue.ToString());
            getThongTinDocGia(this.comboBox_MaDocGia.SelectedValue.ToString());
            if (this.radioButton_DocGiaDaMuon.Checked == true)
            {
                List<PhieuMuonDTO> _list = new List<PhieuMuonDTO>();
                foreach (PhieuMuonDTO temp in listPhieuMuon)
                {
                    if (temp.MaDocGia == this.comboBox_MaDocGia.Text)
                    {
                        _list.Add(temp);
                    }

                }
                loadData_Vao_GridView(_list);
            }
        }

        private void comboBox_MaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.comboBox_MaSach.SelectedValue.ToString());
            getThongTinSach(this.comboBox_MaSach.SelectedValue.ToString());
        }



        private void dataGridView_Data_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.dataGridView_Data.CurrentRow.Index;
            string maDG = dataGridView_Data.Rows[index].Cells[3].Value + "";
            comboBox_MaDocGia.Text = maDG;
            getThongTinDocGia(maDG);
            string maSach = dataGridView_Data.Rows[index].Cells[2].Value + "";
            comboBox_MaSach.Text = maSach;
            getThongTinSach(maSach);
            this.textBox_TinhTrang.Text = dataGridView_Data.Rows[index].Cells[6].Value + ""; 
            this.textBox_SoNgayQuaHan.Text = dataGridView_Data.Rows[index].Cells[7].Value + "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<PhieuMuonDTO> _list = new List<PhieuMuonDTO>();
            foreach (PhieuMuonDTO temp in listPhieuMuon)
            {
                if (temp.MaPhieuTra == "NULL")
                {
                    _list.Add(temp);
                }

            }
            loadData_Vao_GridView(_list);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            loadData_Vao_GridView(listPhieuMuon);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<PhieuMuonDTO> _list = new List<PhieuMuonDTO>();
            foreach (PhieuMuonDTO temp in listPhieuMuon)
            {
                if (temp.MaDocGia == this.comboBox_MaDocGia.Text)
                {
                    _list.Add(temp);
                }

            }
            loadData_Vao_GridView(_list);
        }

        private void radioButton_SachQuaHan_CheckedChanged(object sender, EventArgs e)
        {
            List<PhieuMuonDTO> _list = new List<PhieuMuonDTO>();
            foreach (PhieuMuonDTO temp in listPhieuMuon)
            {
                if (temp.MaPhieuTra == "NULL" &temp.SoNgayQuaHan>0)
                {
                    _list.Add(temp);
                }

            }
            loadData_Vao_GridView(_list);

        }

        private void radioButton_SachQuaHanDaTra_CheckedChanged(object sender, EventArgs e)
        {
            List<PhieuMuonDTO> _list = new List<PhieuMuonDTO>();
            foreach (PhieuMuonDTO temp in listPhieuMuon)
            {
                if (temp.MaPhieuTra != "NULL" & temp.SoNgayQuaHan > 0)
                {
                    _list.Add(temp);
                }

            }
            loadData_Vao_GridView(_list);
        }

        private void button_Tim_Click(object sender, EventArgs e)
        {
            this.radioButton_KetQuaTimKiem.Checked = true;
            List<PhieuMuonDTO> _list = new List<PhieuMuonDTO>();
            switch (this.comboBox_PhuongThuc.SelectedIndex)
            {
                case ToanBo:
                    foreach (PhieuMuonDTO temp in listPhieuMuon)
                    {
                        if (this.checkBox_ChuaTra.Checked)
                        {
                            if (temp.MaPhieuTra == "NULL")
                                _list.Add(temp);
                        }
                        else
                        {
                            _list.Add(temp);
                        }
                    }
                    loadData_Vao_GridView(_list);
                    break;
                case MaPhieuMuon:

                    
                    foreach (PhieuMuonDTO temp in listPhieuMuon)
                    {
                        if (temp.MaPhieuMuon.IndexOf(this.textBox_NoiDungTimKiem.Text)>=0)
                        {
                            if (this.checkBox_ChuaTra.Checked)
                            {
                                if ( temp.MaPhieuTra == "NULL")
                                    _list.Add(temp);
                            }
                            else
                            {
                                _list.Add(temp);
                            }
                            
                        }

                    }
                    loadData_Vao_GridView(_list);

                    break;

                case MaPhieuTra:

                    
                    foreach (PhieuMuonDTO temp in listPhieuMuon)
                    {
                        if (temp.MaPhieuTra.IndexOf(this.textBox_NoiDungTimKiem.Text) >= 0)
                        {
                            if (this.checkBox_ChuaTra.Checked)
                            {
                                if (temp.MaPhieuTra == "NULL")
                                    _list.Add(temp);
                            }
                            else
                            {
                                _list.Add(temp);
                            }
                        }

                    }
                    loadData_Vao_GridView(_list);

                    break;
                case MaDocGai:


                    foreach (PhieuMuonDTO temp in listPhieuMuon)
                    {
                        if (temp.MaDocGia.IndexOf(this.textBox_NoiDungTimKiem.Text) >= 0)
                        {
                            if (this.checkBox_ChuaTra.Checked)
                            {
                                if (temp.MaPhieuTra == "NULL")
                                    _list.Add(temp);
                            }
                            else
                            {
                                _list.Add(temp);
                            }
                        }
                    }
                    loadData_Vao_GridView(_list);

                    break;
                case MaSach:


                    foreach (PhieuMuonDTO temp in listPhieuMuon)
                    {
                        if (temp.MaSach.IndexOf(this.textBox_NoiDungTimKiem.Text) >= 0)
                        {
                            if (this.checkBox_ChuaTra.Checked)
                            {
                                if (temp.MaPhieuTra == "NULL")
                                    _list.Add(temp);
                            }
                            else
                            {
                                _list.Add(temp);
                            }
                        }
                    }
                    loadData_Vao_GridView(_list);

                    break;
            }
        }

        private void comboBox_MaDocGia_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.comboBox_MaDocGia.Text);
            this.label_KetQuaMaDG.Text = "*Đọc giả không tồn tại";
            this.label_KetQuaMaDG.ForeColor = Color.Red;
            this.label_KetQuaMaDG.Enabled = true;
            DuLieuDung_DocGia = false;
            this.textBox_TenDocGia.Text = "*NULL";
            foreach (DocGiaDTO temp in listDocGia) {
                if (temp.Ma== this.comboBox_MaDocGia.Text)
                {
                    this.textBox_TenDocGia.Text = temp.HovaTen;
                    this.label_KetQuaMaDG.Text = "*Mã đọc giả đúng";
                    this.label_KetQuaMaDG.ForeColor = Color.Blue;
                    DuLieuDung_DocGia = true;

                    break;
                }
            }
  
            
            Boolean coTrongDanhSach = false;
            for (int i = listPhieuMuon.Count - 1; i >= 0; i--)
            {

                if (listPhieuMuon[i].MaDocGia == this.comboBox_MaDocGia.Text & listPhieuMuon[i].MaSach == this.comboBox_MaSach.Text)
                {
                    this.textBox_MaPhieuMuon.Text = listPhieuMuon[i].MaPhieuMuon;
                    this.textBox_MaTra.Text = listPhieuMuon[i].MaPhieuTra;
                    coTrongDanhSach = true;
                    if (listPhieuMuon[i].MaPhieuTra == "NULL")
                    {
                        this.label_KetQuaMuon.Text = "Đọc giả đã mượn sách này và chưa trả.";
                        this.label_KetQuaMuon.ForeColor = Color.Green;
                        this.button_TraSach.Enabled = true;
                        this.button_MuonSach.Enabled = false;
                    }
                    else
                    {
                        this.label_KetQuaMuon.Text = "Đọc giả không mượn sách này.";
                        this.label_KetQuaMuon.ForeColor = Color.Green;
                        this.button_TraSach.Enabled = false;
                        this.button_MuonSach.Enabled = true;
                    }
                }
            }
            if (!coTrongDanhSach)
            {
                this.textBox_MaPhieuMuon.Text = "NULL";
                this.textBox_MaTra.Text ="NULL";
                if (this.DuLieuDung_DocGia & this.DuLieuDung_Sach)
                {
                    this.button_MuonSach.Enabled = true;
                    this.label_KetQuaMuon.ForeColor = Color.Green;
                    this.label_KetQuaMuon.Text = "Đọc giả có thể mượn sách này.";
                }
                else
                {
                    this.button_MuonSach.Enabled = false;
                    this.label_KetQuaMuon.ForeColor = Color.Red;
                    this.label_KetQuaMuon.Text = "Dữ liệu bị sai.";
                }
                this.button_TraSach.Enabled = false;
            }



           
        }

        private void comboBox_MaSach_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.comboBox_MaDocGia.Text);
            this.label_KetQuaMaSach.Text = "*Sach không tồn tại";
            this.label_KetQuaMaSach.ForeColor = Color.Red;
            this.label_KetQuaMaSach.Enabled = true;
            DuLieuDung_Sach = false;
            this.textBox_TenSach.Text ="NULL";
            foreach (SachDTO temp in listSach)
            {
                if (temp.Ma == this.comboBox_MaSach.Text)
                {
                    this.textBox_TenSach.Text = temp.TenSach;
                    this.label_KetQuaMaSach.Text = "*Mã sach đúng";
                    this.label_KetQuaMaSach.ForeColor = Color.Blue;
                    DuLieuDung_Sach = true;
                    break;
                }
            }
            Boolean coTrongDanhSach = false;
            for (int i = listPhieuMuon.Count - 1; i >= 0; i--)
            {

                if (listPhieuMuon[i].MaDocGia == this.comboBox_MaDocGia.Text & listPhieuMuon[i].MaSach == this.comboBox_MaSach.Text)
                {
                    coTrongDanhSach = true;
                    this.textBox_MaPhieuMuon.Text = listPhieuMuon[i].MaPhieuMuon;
                    this.textBox_MaTra.Text = listPhieuMuon[i].MaPhieuTra;
                    if (listPhieuMuon[i].MaPhieuTra == "NULL")
                    {
                        
                        this.label_KetQuaMuon.Text = "Đọc giả đã mượn sách này và chưa trả.";
                        this.label_KetQuaMuon.ForeColor = Color.Green;
                        this.button_TraSach.Enabled = true;
                        this.button_MuonSach.Enabled = false;
                    }
                    else
                    {
                        this.label_KetQuaMuon.Text = "Đọc giả không mượn sách này.";
                        this.label_KetQuaMuon.ForeColor = Color.Green;
                        this.button_TraSach.Enabled = false;
                        this.button_MuonSach.Enabled = true;
                        
                    }
                }
            }
            if (!coTrongDanhSach)
            {
                this.textBox_MaPhieuMuon.Text = "NULL";
                this.textBox_MaTra.Text = "NULL";
                if (this.DuLieuDung_DocGia & this.DuLieuDung_Sach)
                {
                    
                    this.button_MuonSach.Enabled = true;

                    this.label_KetQuaMuon.ForeColor = Color.Green;

                    this.label_KetQuaMuon.Text = "Đọc giả có thể mượn sách này.";
                }
                else
                {
                    this.button_MuonSach.Enabled = false;
                    this.label_KetQuaMuon.ForeColor = Color.Red;
                    this.label_KetQuaMuon.Text = "Dữ liệu bị sai.";
                }
                this.button_TraSach.Enabled = false;
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
            while (_ma.Length < 5)
            {
                _ma = "0" + _ma;
            }
            _ma = "Mu" + _ma;
            return _ma;
        }
        private void button_MuonSach_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            PhieuMuonDTO temp = new PhieuMuonDTO();
            String Ma = this.TaoMa(listPhieuMuon[listPhieuMuon.Count - 1].MaPhieuMuon);



            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thẻ với mã " + Ma + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                temp.MaPhieuMuon = Ma;
                temp.MaDocGia = this.comboBox_MaDocGia.Text;
                temp.MaSach = this.comboBox_MaSach.Text;
                temp.NgayMuon = DateTime.Now;
                temp.ThoiHan = Convert.ToInt32(this.numericUpDown_ThoiHan.Value);

                bool kq = pmBus.them(temp,true);
                if (kq == false)
                    MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    listPhieuMuon = pmBus.select("", 0);
                    MessageBox.Show("Thêm Độc giả thành công");
                    loadData_Vao_GridView(listPhieuMuon);
                    this.dataGridView_Data.FirstDisplayedScrollingRowIndex = dataGridView_Data.RowCount - 1;

                }
            }
            else
                MessageBox.Show("Không thêm.");



        }
        private String _TaoMa(String Ma)
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
            String _ma = "" + _s;
            while (_ma.Length < 5)
            {
                _ma = "0" + _ma;
            }
            _ma = "Tr" + _ma;
            return _ma;
        }
        private void button_TraSach_Click(object sender, EventArgs e)
        {
            //1. Map data from GUI
            PhieuMuonDTO temp = new PhieuMuonDTO();
            String Ma = this._TaoMa(listPhieuMuon[listPhieuMuon.Count - 1].MaPhieuMuon);



            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thẻ với mã " + Ma + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                temp.MaPhieuTra = Ma;
                temp.MaDocGia = this.comboBox_MaDocGia.Text;
                temp.MaSach = this.comboBox_MaSach.Text;
                temp.NgayTra = DateTime.Now;
                temp.ThoiHan = Convert.ToInt32(this.numericUpDown_ThoiHan.Value);

                bool kq = pmBus.them(temp,false);
                if (kq == false)
                    MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    listPhieuMuon = pmBus.select("", 0);
                    MessageBox.Show("Thêm Độc giả thành công");
                    loadData_Vao_GridView(listPhieuMuon);
                    this.dataGridView_Data.FirstDisplayedScrollingRowIndex = dataGridView_Data.RowCount - 1;

                }
            }
            else
                MessageBox.Show("Không thêm.");
        }
    }
}
