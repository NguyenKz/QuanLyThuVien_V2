using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DocGiaDTO
    {
        private String iMaDocGia;

        public String Ma
        {
            get { return iMaDocGia; }
            set { iMaDocGia = value; }
        }
        private string sHovaTen;

        public string HovaTen
        {
            get { return sHovaTen; }
            set { sHovaTen = value; }
        }
        private DateTime dtNgaySinh;

        public DateTime NgaySinh
        {
            get { return dtNgaySinh; }
            set { dtNgaySinh = value; }
        }

        private string sEmail;

        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }

        private string sDiaChi;

        public string DiaChi
        {
            get { return sDiaChi; }
            set { sDiaChi = value; }
        }

        private string sLoaiDocGia;

        public string maLoaiDocGia
        {
            get { return sLoaiDocGia; }
            set { sLoaiDocGia = value; }
        }
        public string stenLoaiDocGia;
        public string TenLoaiDocGia
        {
            get { return stenLoaiDocGia; }
            set { stenLoaiDocGia = value; }
        }


        private DateTime dtNgayLapThe;

        public DateTime NgayLapThe
        {
            get { return dtNgayLapThe; }
            set { dtNgayLapThe = value; }
        }

        private int dtHanSuDung;

        public int HanSuDung
        {
            get { return dtHanSuDung; }
            set { dtHanSuDung = value; }
        }
    }
}
