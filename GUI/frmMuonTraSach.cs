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

        private List<QuyDinhDTO> listQD;
        private QuyDinhBUS qdBUS;
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
        private bool DieuKienMuon = true;
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
          
            listPhieuMuon = pmBus.select();



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
            this.listSach = this.sachBus.select(listPhieuMuon);

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
            qdBUS = new QuyDinhBUS();
            listQD = new List<QuyDinhDTO>();
            listQD = qdBUS.select();

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
            listPhieuMuon = pmBus.select();
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


        private bool quaSachDaMuonTrong4ngay(String maDocGia)
        {
            int count = 0;
            foreach(PhieuMuonDTO temp in listPhieuMuon)
            {
              
                if (temp.MaDocGia == maDocGia)
                {
                  
                    if (((int)(DateTime.Now.Subtract(temp.NgayMuon).TotalDays)) <= listQD[0].SoNgayMuonToiDa)
                    {
                        count++;
                   
                        if (count > listQD[0].SoSachMuonToiDa) return false;
                       
                    }
                }
            }

            return true;
        }
        private int theConHan(String maDocGia)
        {
    
            foreach (DocGiaDTO temp in listDocGia)
            {
                if (temp.Ma == maDocGia)
                {
                    Console.WriteLine(temp.NgayLapThe.ToString());
                    return (int)((DateTime.Now.Subtract(temp.NgayLapThe).TotalDays)) - 6 * 30;
                    
                }
            }

            return 0;
        }

        private bool KhongCoSachMuonQuaHan(String maDocGia)
        {
            int count = 0;
            foreach (PhieuMuonDTO temp in listPhieuMuon)
            {
                if (temp.MaDocGia == maDocGia)
                {
                    if ((temp.TinhTrang==PhieuMuonDTO.QuaHanVaChuaTra) || (temp.TinhTrang==PhieuMuonDTO.QuaHanVaDaTra))
                    {
                       return false;
                    }
                }
            }

            return true;
        }

        private bool SachChuaDuocMuon(String maSach)
        {
            int count = 0;
            foreach (PhieuMuonDTO temp in listPhieuMuon)
            {
                if (temp.MaSach == maSach&&temp.MaPhieuTra=="NULL")
                {       
                        return false;
                    
                }
            }

            return true;
        }

        private bool DuocTraSach(String maSach,String maDocGia)
        {

            foreach (PhieuMuonDTO temp in listPhieuMuon)
            {
                if (temp.MaSach == maSach && temp.MaDocGia == maDocGia)
                {
                    if (temp.MaPhieuTra == "NULL")
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private String getMaPhieuMuon(String madg,String maS) {

            foreach (PhieuMuonDTO pm in listPhieuMuon)
            {
                if (pm.MaDocGia == madg&&pm.MaSach==maS)
                {
                    return pm.MaPhieuMuon;
                }
            }

            return "NULL";
        }
        private String getMaPhieuTra(String madg, String maS)
        {

            foreach (PhieuMuonDTO pm in listPhieuMuon)
            {
                if (pm.MaDocGia == madg && pm.MaSach == maS)
                {
                    return pm.MaPhieuTra;
                }
            }

            return "NULL";
        }

        private void comboBox_MaDocGia_TextChanged(object sender, EventArgs e)
        {
            DuLieuDung_DocGia = true;
            String ma=this.comboBox_MaDocGia.Text;
            if (DuocTraSach(this.comboBox_MaSach.Text, ma))
            {
                this.button_TraSach.Enabled = true;
                this.textBox_MaPhieuMuon.Text = getMaPhieuMuon(ma,this.comboBox_MaSach.Text);
                this.textBox_MaTra.Text = getMaPhieuTra(ma, this.comboBox_MaSach.Text);
            }
            else
            {
                this.button_TraSach.Enabled = false;
            }

            if (!quaSachDaMuonTrong4ngay(ma))
            {
                this.label_KetQuaMaDG.Text = "Qúa số lượng mượn trong "+listQD[0].SoNgayMuonToiDa+" ngày";
                this.label_KetQuaMaDG.ForeColor = Color.Red;
                this.button_MuonSach.Enabled = false;
                DuLieuDung_DocGia = false;
                return;
            }
            int han = theConHan(ma);
           if (han>0)
            {
                this.label_KetQuaMaDG.Text = "Thẻ hết hạn "+han+" ngày." ;
                this.label_KetQuaMaDG.ForeColor = Color.Red;
                this.button_MuonSach.Enabled = false;
                DuLieuDung_DocGia = false;
                return;

            }

            if (!KhongCoSachMuonQuaHan(ma))
            {
                this.label_KetQuaMaDG.Text = "Có sách mượn quá hạn, không được mượn";
                this.label_KetQuaMaDG.ForeColor = Color.Red;
                this.button_MuonSach.Enabled = false;
                DuLieuDung_DocGia = false;
                return;

            }

            

            this.label_KetQuaMaDG.Text = "Thẻ hợp lệ.";
            this.label_KetQuaMaDG.ForeColor = Color.Green;
            this.button_MuonSach.Enabled = DuLieuDung_DocGia & DuLieuDung_Sach;





        }

        private void comboBox_MaSach_TextChanged(object sender, EventArgs e)
        {
            DuLieuDung_Sach = true;
            String ma = this.comboBox_MaSach.Text;
            if (DuocTraSach(ma, this.comboBox_MaDocGia.Text))
            {
                this.button_TraSach.Enabled = true;
                this.textBox_MaPhieuMuon.Text = getMaPhieuMuon(this.comboBox_MaDocGia.Text,ma);
                this.textBox_MaTra.Text = getMaPhieuTra(this.comboBox_MaDocGia.Text, ma);
            }
            else
            {
                this.button_TraSach.Enabled = false;
            }
            if (!SachChuaDuocMuon(ma))
            {
                this.label_KetQuaMaSach.Text = "Sách không có sắn";
                this.label_KetQuaMaSach.ForeColor = Color.Red;
                this.button_MuonSach.Enabled = false;
                DuLieuDung_Sach = false;
                button_MuonSach.Enabled = false;
                return;
            }

            if (!quaSachDaMuonTrong4ngay(this.comboBox_MaDocGia.Text))
            {
                this.label_KetQuaMaDG.Text = "Qúa số lượng mượn trong 4 ngày";
                this.label_KetQuaMaDG.ForeColor = Color.Red;
                this.button_MuonSach.Enabled = false;
                DuLieuDung_DocGia = false;
                return;
            }



            this.label_KetQuaMaSach.Text = "Mã sách hợp lệ.";
            this.label_KetQuaMaSach.ForeColor = Color.Green;
            this.button_MuonSach.Enabled = DuLieuDung_DocGia & DuLieuDung_Sach;

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

            this.button_MuonSach.Enabled = false;
            this.button_TraSach.Enabled = false;

            DialogResult dlr = MessageBox.Show("Bạn có muốn thêm thẻ với mã " + Ma + " không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

                temp.MaPhieuMuon = Ma;
                temp.MaDocGia = this.comboBox_MaDocGia.Text;
                temp.MaSach = this.comboBox_MaSach.Text;
                temp.NgayMuon = DateTime.Now;
                temp.ThoiHan = Convert.ToInt32(this.numericUpDown_ThoiHan.Value);

                bool kq = pmBus.them(temp, true);
                if (kq == false)
                    MessageBox.Show("Thêm Độc giả thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {

                    listPhieuMuon = pmBus.select();
                    MessageBox.Show("Thêm Độc giả thành công");
                    this.comboBox_MaDocGia.Text = this.comboBox_MaDocGia.Text;
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
            String Ma = this._TaoMa(this.textBox_MaPhieuMuon.Text);

            Console.WriteLine(this.textBox_MaPhieuMuon.Text + "  "+  Ma);
            this.button_MuonSach.Enabled = false;
            this.button_TraSach.Enabled = false;
      
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
                    listPhieuMuon = pmBus.select();
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
