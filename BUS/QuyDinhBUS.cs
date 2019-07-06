using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class QuyDinhBUS
    {
        private QuyDinhDAL qdDAL;

        public QuyDinhBUS()
        {
            qdDAL = new QuyDinhDAL();
        }
 


        public bool sua(QuyDinhDTO tl)
        {
            bool re = qdDAL.sua(tl);
            return re;
        }

        public List<QuyDinhDTO> select()
        {
            return qdDAL.select();

        }
    }
}
