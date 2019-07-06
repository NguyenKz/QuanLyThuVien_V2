using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SachDAL
    {
        private string connectionString;
        public const int TimToanBo = 0;
        public const int TimBangMa = 1;
        public const int TimBangTen = 2;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public SachDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public bool xoa(SachDTO temp)
        {
            string query = string.Empty;
            query += "DELETE FROM [dbo].[tblSach] WHERE[maSach] =@maSach";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maSach", temp.Ma);
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

        public bool sua(SachDTO temp)
        {
            Console.WriteLine("b============== BAT DAU SU THONG TIN THE =============");

            string query = string.Empty;
            query += "UPDATE [dbo].[tblSach]  SET ";
            query += "[TenSach] = @TenSach,";
        //    query += "[ngayNhap] = @ngayNhap,";
            query += " [tacGia] = @tacGia, ";
            query += "[nhaXuatBan] = @nhaXuatBan, ";
            query += "[maTheLoai] = @maTheLoai,";
            query += "[namXuatBan] =@namXuatBan,";
            query += "[triGia]=@triGia ";
            query += " WHERE[maSach] =@maSach";

            Console.WriteLine("Query: " + query);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maSach", temp.Ma);
                    cmd.Parameters.AddWithValue("@TenSach", temp.TenSach);
              //      cmd.Parameters.AddWithValue("@ngayNhap", temp.NgayNhap.Year + "-" + temp.NgayNhap.Month + "-" + temp.NgayNhap.Day);
                    cmd.Parameters.AddWithValue("@tacGia", temp.TacGia);

                    cmd.Parameters.AddWithValue("@nhaXuatBan", temp.NhaXuatBan);
                    cmd.Parameters.AddWithValue("@maTheLoai", temp.MaTheLoai);
                    cmd.Parameters.AddWithValue("@namXuatBan", temp.NamXuatBan.Year + "-" + temp.NamXuatBan.Month + "-" + temp.NamXuatBan.Day);
                    cmd.Parameters.AddWithValue("@triGia", temp.TriGia);
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




        public bool them(SachDTO temp)
        {
            Console.WriteLine("Them sach");
            string query = string.Empty;
            query += "INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia])";
            query += "VALUES(@maSach,@TenSach,@ngayNhap,@tacGia,@nhaXuatBan,@maTheLoai,@namXuatBan,@triGia)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    Console.WriteLine("Bat dau query");
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;    
                    cmd.Parameters.AddWithValue("@maSach", temp.Ma);
                    cmd.Parameters.AddWithValue("@TenSach", temp.TenSach);
                    cmd.Parameters.AddWithValue("@ngayNhap", temp.NgayNhap.Year+"-"+temp.NgayNhap.Month+"-"+temp.NgayNhap.Day);
                    cmd.Parameters.AddWithValue("@tacGia", temp.TacGia);
                    
                    cmd.Parameters.AddWithValue("@nhaXuatBan", temp.NhaXuatBan);
                    cmd.Parameters.AddWithValue("@maTheLoai", temp.MaTheLoai);
                    cmd.Parameters.AddWithValue("@namXuatBan", temp.NamXuatBan.Year + "-" + temp.NamXuatBan.Month + "-" + temp.NamXuatBan.Day);
                    cmd.Parameters.AddWithValue("@triGia", temp.TriGia);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Exe query");
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

        public List<SachDTO> select(List<PhieuMuonDTO> listPhieuMuon)
        {
            
            

            Console.WriteLine("========================================================");

            string query = string.Empty;
            query = "SELECT * FROM [dbo].[tblSach],[dbo].[tblTheLoai] ";
            query += "WHERE [dbo].[tblSach].[maTheLoai]=[dbo].[tblTheLoai].[maTheLoai]";
 


            List<SachDTO> listTemp = new List<SachDTO>();

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
                                SachDTO temp = new SachDTO();

                                temp.Ma = reader["maSach"].ToString();
                                Console.WriteLine("Ma doc gia: " + temp.Ma);
                                temp.TenSach = reader["TenSach"].ToString();
                                Console.WriteLine("Ten doc gia: " + temp.TenSach);
                                temp.TacGia = reader["tacGia"].ToString();

                                temp.NhaXuatBan = reader["nhaXuatBan"].ToString();
                                temp.MaTheLoai = reader["maTheLoai"].ToString();
                                temp.TenTheLoai = reader["tenTheLoai"].ToString();
                                temp.TriGia = int.Parse(reader["triGia"].ToString());
                                temp.NgayNhap = DateTime.Parse(reader["ngayNhap"].ToString());
                                temp.NamXuatBan = DateTime.Parse(reader["namXuatBan"].ToString());



                                foreach(PhieuMuonDTO _temp in listPhieuMuon)
                                {
                                    if (temp.Ma == _temp.MaSach)
                                    {
                                        switch (_temp.TinhTrang) {
                                            case PhieuMuonDTO.DungHan:
                                            case PhieuMuonDTO.QuaHanVaDaTra:
                                                temp.TìnhTrang="Có thể mượn";
                                                break;
                                            default:
                                                temp.TìnhTrang = "Không thể mượn";
                                                break;
                                        }
                                    }
                                }
                                if (temp.TìnhTrang==null) temp.TìnhTrang = "Có thể mượn";
                                listTemp.Add(temp);


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
            Console.WriteLine("Get doc gia thanh cong");
            return listTemp;

        }



    }
}
