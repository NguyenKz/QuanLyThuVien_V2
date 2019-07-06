
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
using BUS;

namespace GUI
{
    public partial class frmQuyDinh : Form
    {
        public frmQuyDinh()
        {
            InitializeComponent();
        }
        private List<QuyDinhDTO> listQD;
        private QuyDinhBUS qdBUS;

        private void numericUpDown_TuoiToiThieu_ValueChanged(object sender, EventArgs e)
        {
            if (this.numericUpDown_TuoiToiDa.Value < this.numericUpDown_TuoiToiThieu.Value)
            {
                this.numericUpDown_TuoiToiThieu.Value=this.numericUpDown_TuoiToiDa.Value-1 ;
            }
        }

        private void numericUpDown_TuoiToiDa_ValueChanged(object sender, EventArgs e)
        {
            if (this.numericUpDown_TuoiToiDa.Value < this.numericUpDown_TuoiToiThieu.Value)
            {
                this.numericUpDown_TuoiToiDa.Value = this.numericUpDown_TuoiToiThieu.Value + 1;
            }
        }

        private void button_SuaQuyDinh_Click(object sender, EventArgs e)
        {
            QuyDinhDTO temp = new QuyDinhDTO();

            DialogResult dlr = MessageBox.Show("Bạn có muốn sử quy dinh không?", "Xác nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {

               
                temp.TuoiToiThieu = Convert.ToInt32(this.numericUpDown_TuoiToiThieu.Value);
                temp.TuoiToiDa = Convert.ToInt32(this.numericUpDown_TuoiToiDa.Value);
                temp.SoNgayMuonToiDa = Convert.ToInt32(this.numericUpDown_NgayMuonToiDa.Value);
                temp.SoSachMuonToiDa = Convert.ToInt32(this.numericUpDown_SachMuonToiDa.Value);
                temp.KhoangCachNamXuatBan= Convert.ToInt32(this.numericUpDown_NamXuatBan.Value);
                bool kq = qdBUS.sua(temp);
                if (kq == false)
                    MessageBox.Show("Sửa dữ quy định thất bại.");
                else
                {
                    listQD = qdBUS.select();
                  
                    this.numericUpDown_TuoiToiThieu.Value = listQD[0].TuoiToiThieu;
                    this.numericUpDown_TuoiToiDa.Value = listQD[0].TuoiToiDa;
                    this.numericUpDown_NgayMuonToiDa.Value = listQD[0].SoNgayMuonToiDa;
                    this.numericUpDown_SachMuonToiDa.Value = listQD[0].SoSachMuonToiDa;
                    this.numericUpDown_NamXuatBan.Value = listQD[0].KhoangCachNamXuatBan;
                    MessageBox.Show("Sửa quy dịnh thành công");


                }
            }
            else
                MessageBox.Show("Không sửa.");
        }

        private void frmQuyDinh_Load(object sender, EventArgs e)
        {
            qdBUS = new QuyDinhBUS();
            listQD = new List<QuyDinhDTO>();
            listQD = qdBUS.select();
          
    //        this.tb_MaDG.Text = listQD[0].MaQD; 
            this.numericUpDown_TuoiToiThieu.Value= listQD[0].TuoiToiThieu;
            this.numericUpDown_TuoiToiDa.Value= listQD[0].TuoiToiDa;
            this.numericUpDown_NgayMuonToiDa.Value= listQD[0].SoNgayMuonToiDa ;
            this.numericUpDown_SachMuonToiDa.Value= listQD[0].SoSachMuonToiDa ;
            this.numericUpDown_NamXuatBan.Value= listQD[0].KhoangCachNamXuatBan ;
        }
    }
}
