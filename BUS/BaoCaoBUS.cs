using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class BaoCaoBUS
    {
        private BaoCaoDAL bcDAL;

        public BaoCaoBUS()
        {
            bcDAL = new BaoCaoDAL();
        }
       
        public List<TheLoaiDTO> select()
        {
            return bcDAL.select_tl();
        }
    }
}
