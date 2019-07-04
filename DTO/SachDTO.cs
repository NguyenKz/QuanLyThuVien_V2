using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SachDTO
    {
        String ma;
        String tenSach;
        String maTheLoai;
        String tenTheLoai;
        String tacGia;
        String nhaXuatBan;
        int triGia;
        DateTime ngayNhap;
        DateTime namXuatBan;

        public string Ma { get => ma; set => ma = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public string NhaXuatBan { get => nhaXuatBan; set => nhaXuatBan = value; }
        public int TriGia { get => triGia; set => triGia = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public DateTime NamXuatBan { get => namXuatBan; set => namXuatBan = value; }
    }
}
