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
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }
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
        private TheLoaiBUS tlBUS;
        List<TheLoaiDTO> listTheLoai;


        List<BaoCaoDTO> listBaoCao;
        BaoCaoBUS bcBus;
        void AddColum(String key, String tag)
        {
            DataGridViewTextBoxColumn Temp = new DataGridViewTextBoxColumn();
            Temp.Name = key;
            Temp.HeaderText = tag;
            Temp.DataPropertyName = key;
            this.dataGridView_BaoCao.Columns.Add(Temp);
        }



        private void loadBaoCaoTheLoai_Vao_GridView(List<BaoCaoDTO> list)
        {
            if (list == null)
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu từ DB");
                return;
            }

            dataGridView_BaoCao.Columns.Clear();
            dataGridView_BaoCao.DataSource = null;

            dataGridView_BaoCao.AutoGenerateColumns = false;
            dataGridView_BaoCao.AllowUserToAddRows = false;
            dataGridView_BaoCao.DataSource = list;


            AddColum("MaTheLoai", "Mã thể loại");
            AddColum("TenTheLoai", "Tên thể loại");
            AddColum("SoLuotMuong", "Số lượt mượn");
            AddColum("TyLe", "Tỷ lệ mượn");


            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView_BaoCao.DataSource];
            myCurrencyManager.Refresh();

        }

        private void frmBaoCao_Load(object sender, EventArgs e)

        {
          

            

        }

        private void radioButton_BaoCaoTheoTheLoai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.radioButton_BaoCaoTheoTheLoai.Checked == true)
            {
                bcBus = new BaoCaoBUS();
                List<TheLoaiDTO> list;
                list = bcBus.select();

                tlBUS = new TheLoaiBUS();
                listTheLoai = tlBUS.select("");
                listBaoCao = new List<BaoCaoDTO>();

                pmBus = new PhieuMuonBUS();
                int countnow = 0;
                listPhieuMuon = pmBus.select();

                foreach (PhieuMuonDTO tl in listPhieuMuon)
                {
                    if (tl.NgayMuon.Month == this.dateTimePicker1.Value.Month)
                    {
                        countnow++;
                    }

                }
                    foreach (TheLoaiDTO tl in listTheLoai)
                {
                    int count = 0;
                    foreach (TheLoaiDTO theloaimuon in list)
                    {
                        if (theloaimuon.Ngay.Month == this.dateTimePicker1.Value.Month)
                        {
                            if (tl.MaTheLoai == theloaimuon.MaTheLoai)
                            {
                                count++;

                            }
                        }
                    }
                    BaoCaoDTO temp = new BaoCaoDTO();
                    temp.MaTheLoai = tl.MaTheLoai;
                    temp.SoLuotMuong = count;
                    Console.WriteLine(countnow);
                    if (countnow == 0)
                        temp.TyLe = "0%";
                    else
                    temp.TyLe = "" + (count / countnow) * 100 + "%";
                    temp.TenTheLoai = tl.TenTheLoai;
                    listBaoCao.Add(temp);
                   
                }
                this.label_TongSoLuotMuon.Text = countnow.ToString();
                loadBaoCaoTheLoai_Vao_GridView(listBaoCao);
            }

        }
    }
}
