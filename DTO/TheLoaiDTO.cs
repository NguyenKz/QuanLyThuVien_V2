using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TheLoaiDTO
    {
        String maTheLoai;
        String tenTheLoai;
        DateTime ngay;

        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
    }
}
