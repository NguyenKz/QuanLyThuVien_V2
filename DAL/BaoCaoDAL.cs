using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
namespace DAL
{
    public class BaoCaoDAL
    {
        private string connectionString;
        public const int TimToanBo = 0;
        public const int TimBangMa = 1;
        public const int TimBangTen = 2;
        public const int TatCa = 0;
        public const int SachChuaTra = 1;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public BaoCaoDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public List<TheLoaiDTO> select_tl()
        {



            Console.WriteLine("========================================================");

            string query = string.Empty;
            query += "select [maTheLoai] , [ngayMuon] from[tblPhieuMuon],[tblSach] where tblPhieuMuon.maSach=tblSach.maSach";

            List<TheLoaiDTO> ListDocGia = new List<TheLoaiDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;



                    try
                    {
                        Console.WriteLine("Bat dau chay query");
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        Console.WriteLine("Chay query thanh cong");
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                TheLoaiDTO temp = new TheLoaiDTO();
                                temp.MaTheLoai = reader["maTheLoai"].ToString();
                                temp.Ngay = DateTime.Parse(reader["ngayMuon"].ToString());
                                ListDocGia.Add(temp);



                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }

            Console.WriteLine("get all the loai thanh cong");
            return ListDocGia;

        }

    }
}
