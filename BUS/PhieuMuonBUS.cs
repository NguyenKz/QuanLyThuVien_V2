using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class PhieuMuonBUS
    {
        private PhieuMuonDAL pmDAL;

        public PhieuMuonBUS()
        {
            pmDAL = new PhieuMuonDAL();
        }
        public bool them(PhieuMuonDTO temp, bool MuonSach)
        {
            bool re = pmDAL.them(temp,MuonSach);
            return re;
        }
   
        //public bool xoa(TheLoaiDTO tl)
        //{
        //    bool re = tlDAL.xoa(tl);
        //    return re;
        //}

        //public bool sua(TheLoaiDTO tl)
        //{
        //    bool re = tlDAL.sua(tl);
        //    return re;
        //}

        public List<PhieuMuonDTO> select()
        {
            return pmDAL.select();

        }
    }
}
