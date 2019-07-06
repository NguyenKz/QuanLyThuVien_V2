using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuyDinhDAL
    {
        private string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public QuyDinhDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool sua(QuyDinhDTO temp)
        {
            Console.WriteLine("b============== BAT DAU SU THONG TIN THE =============");

            string query = string.Empty;
            query += "UPDATE [dbo].[tblQuyDinh]  SET ";
            query += "[maQuyDinh] = @maQuyDinh,";
            query += "[doTuoiToiThieu]=@doTuoiToiThieu,";
            query += "[doTuoiToiDa]=@doTuoiToiDa,";
            query += "[khoangCachNamXuatBan]=@khoangCachNamXuatBan,";
            query += "[soSachMuonToiDa]=@soSachMuonToiDa,";
            query += "[soNgayMuonToiDa]=@soNgayMuonToiDa";


            Console.WriteLine("Query: " + query);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maQuyDinh", temp.MaQD);
                    cmd.Parameters.AddWithValue("@doTuoiToiThieu", temp.TuoiToiThieu);
                    //      cmd.Parameters.AddWithValue("@ngayNhap", temp.NgayNhap.Year + "-" + temp.NgayNhap.Month + "-" + temp.NgayNhap.Day);
                    cmd.Parameters.AddWithValue("@doTuoiToiDa", temp.TuoiToiDa);

                    cmd.Parameters.AddWithValue("@khoangCachNamXuatBan", temp.KhoangCachNamXuatBan);
                    cmd.Parameters.AddWithValue("@soSachMuonToiDa", temp.SoSachMuonToiDa);
                    cmd.Parameters.AddWithValue("@soNgayMuonToiDa", temp.SoNgayMuonToiDa);
             
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        public List<QuyDinhDTO> select()
        {



            Console.WriteLine("========================================================");

            string query = string.Empty;
            query = "SELECT * FROM [dbo].[tblQuyDinh]";
            List<QuyDinhDTO> listTemp = new List<QuyDinhDTO>();

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
                                QuyDinhDTO temp = new QuyDinhDTO();
                                temp.MaQD = reader["maQuyDinh"].ToString();
                                temp.TuoiToiThieu = int.Parse(reader["doTuoiToiThieu"].ToString());
                                temp.TuoiToiDa = int.Parse(reader["doTuoiToiDa"].ToString());


                                temp.KhoangCachNamXuatBan = int.Parse(reader["khoangCachNamXuatBan"].ToString());
                                temp.SoSachMuonToiDa = int.Parse(reader["soSachMuonToiDa"].ToString());
                                temp.SoNgayMuonToiDa = int.Parse(reader["soNgayMuonToiDa"].ToString());

                       
                                listTemp.Add(temp);

                                Console.WriteLine("quy dinh: " + temp.MaQD+"  "+temp.TuoiToiThieu+"   "+temp.TuoiToiDa+"  "+temp.KhoangCachNamXuatBan+"  "+temp.SoNgayMuonToiDa+"  "+temp.SoSachMuonToiDa);

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
            Console.WriteLine("Get quy dinh thành công");
            return listTemp;

        }
    }
}
