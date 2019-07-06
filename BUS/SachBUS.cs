using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class SachBUS
    {
        private SachDAL tempDAL;
        public String cmd_String;
        public SachBUS()
        {
            tempDAL = new SachDAL();
        }
        public bool them(SachDTO sach)
        {
            bool re = tempDAL.them(sach);
         
            return re;
        }

        public bool xoa(SachDTO dg)
        {
            bool re = tempDAL.xoa(dg);
            return re;
        }

        public bool sua(SachDTO temp)
        {
            bool re = tempDAL.sua(temp);
            return re;
        }
        public List<SachDTO> select(List<PhieuMuonDTO> listPhieuMuon)
        {
            return tempDAL.select(listPhieuMuon);
        }
    }
}
