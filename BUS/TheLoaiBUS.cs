using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class TheLoaiBUS
        {
        private TheLoaiDAL tlDAL;
        public String cmd_String;
        public TheLoaiBUS()
        {
            tlDAL = new TheLoaiDAL();
        }
        public bool them(TheLoaiDTO tl)
        {
            bool re = tlDAL.them(tl);
            return re;
        }

        public bool xoa(TheLoaiDTO tl)
        {
            bool re = tlDAL.xoa(tl);
            return re;
        }

        public bool sua(TheLoaiDTO tl)
        {
            bool re = tlDAL.sua(tl);
            return re;
        }

        public List<TheLoaiDTO> select(String Ma)
        {
            return tlDAL.select(Ma);

        }
    }
}
