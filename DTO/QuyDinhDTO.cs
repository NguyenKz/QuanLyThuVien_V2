using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class QuyDinhDTO
    {
        private String maQD;
        private int tuoiToiThieu;
        private int tuoiToiDa;
        private int khoangCachNamXuatBan;
        private int soSachMuonToiDa;
        private int soNgayMuonToiDa;

        public string MaQD { get => maQD; set => maQD = value; }
        public int TuoiToiThieu { get => tuoiToiThieu; set => tuoiToiThieu = value; }
        public int TuoiToiDa { get => tuoiToiDa; set => tuoiToiDa = value; }
        public int KhoangCachNamXuatBan { get => khoangCachNamXuatBan; set => khoangCachNamXuatBan = value; }
        public int SoSachMuonToiDa { get => soSachMuonToiDa; set => soSachMuonToiDa = value; }
        public int SoNgayMuonToiDa { get => soNgayMuonToiDa; set => soNgayMuonToiDa = value; }
    }
}
