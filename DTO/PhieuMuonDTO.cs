using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuMuonDTO
    {

        public const int DungHan = 0;
        public const int QuaHanVaDaTra = 1;
        public const int QuaHanVaChuaTra = 2;
        public const int ChuaTraVaChuaQuaHan = 3;
        private String maPhieuMuon;
        private String maPhieuTra;
        private String maSach;
        private String maDocGia;
        private DateTime ngayMuon;
        private DateTime ngayTra;
        private int thoiHan;
        private String tenDocGia;
        private String tenSach;
        private String tacGia;
        private int giaTri;
        private int tinhTrang;
        private String strTinhTrang;
        private int soNgayQuaHan;
        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public string MaPhieuTra { get => maPhieuTra; set => maPhieuTra = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public int ThoiHan { get => thoiHan; set => thoiHan = value; }
        public string TenDocGia { get => tenDocGia; set => tenDocGia = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public int GiaTri { get => giaTri; set => giaTri = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string StrTinhTrang { get => strTinhTrang; set => strTinhTrang = value; }
        public int SoNgayQuaHan { get => soNgayQuaHan; set => soNgayQuaHan = value; }

        public void getTinhTrang() {

           if (SoNgayQuaHan <= 0)
            {
                if(this.MaPhieuTra=="NULL"){
                    this.TinhTrang = ChuaTraVaChuaQuaHan;
                    this.strTinhTrang = "Chưa quá hạn và chưa trả";
                }
                else
                {
                    this.tinhTrang = DungHan;
                    this.strTinhTrang = "Đúng hạn";
                }
            }
            else
            {
                if (this.MaPhieuTra == "NULL")
                {
                    this.TinhTrang = QuaHanVaChuaTra;
                    this.strTinhTrang = "Qúa hạn và chưa trả";
                }
                else
                {
                    this.tinhTrang = QuaHanVaDaTra;
                    this.strTinhTrang = "Qúa hạn và đã trả";
                }

            }
     
        }
    }
}
