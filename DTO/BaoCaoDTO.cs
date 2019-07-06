using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class BaoCaoDTO
    {
        private String maTheLoai;
        private String tenTheLoai;
        private int soLuotMuong;
        private string tyLe;
        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public int SoLuotMuong { get => soLuotMuong; set => soLuotMuong = value; }
        public string TyLe { get => tyLe; set => tyLe = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }
    }
}
