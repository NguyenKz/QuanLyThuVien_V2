using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class DocGiaBUS
    {
        private DocGiaDAL dgDAL;
        public String cmd_String;
        public DocGiaBUS()
        {
            dgDAL = new DocGiaDAL();
        }
        public bool them(DocGiaDTO dg)
        {
            bool re = dgDAL.them(dg);
            cmd_String = dgDAL.cmd_string;
            return re;
        }

        public bool xoa(DocGiaDTO dg)
        {
            bool re = dgDAL.xoa(dg);
            return re;
        }

        public bool sua(DocGiaDTO dg)
        {
            bool re = dgDAL.sua(dg);
            return re;
        }

        public List<DocGiaDTO> select()
        {
            return dgDAL.select();
        }
        public List<DocGiaDTO> TimKiemBangTen(string Ten)
        {
            return dgDAL.TimKiemBangTen(Ten);
        }
        public DocGiaDTO get(String MaDG)
        {
            return dgDAL.get(MaDG);
        }
    }
}
