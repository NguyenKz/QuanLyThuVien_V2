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
    public class DocGiaDAL
    {
        private string connectionString;


        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }



        public DocGiaDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        //public string ConnectionString { get => connectionString; set => connectionString = value; }
        public String cmd_string;
        public bool them(DocGiaDTO dg)
        {
            string query = string.Empty;
            query += "INSERT INTO[dbo].[tblTheDocGia] ([maDocGia],[hoVaTenDocGia],[ngaySinh],[email],[diaChi],[maLoaiDocGia],[ngayLapThe],[hanSuDung])";
            query += "VALUES(@maDocGia, @hoVaTenDocGia,@ngaySinh, @diaChi,@email,@loaiDocGia,@ngayLapThe,@hanSuDung)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maDocGia", dg.Ma);
                    cmd.Parameters.AddWithValue("@hoVaTenDocGia", dg.HovaTen);
                    cmd.Parameters.AddWithValue("@ngaySinh", dg.NgaySinh.Year + "-" + dg.NgaySinh.Month + "-" + dg.NgaySinh.Day);
                    cmd.Parameters.AddWithValue("@email", dg.Email);
                    cmd.Parameters.AddWithValue("@diaChi", dg.DiaChi);
                    cmd.Parameters.AddWithValue("@loaiDocGia", dg.maLoaiDocGia);
                    cmd.Parameters.AddWithValue("@ngayLapThe", dg.NgayLapThe.Year + "-" + dg.NgayLapThe.Month + "-" + dg.NgayLapThe.Day);
                    cmd.Parameters.AddWithValue("@hanSuDung", dg.HanSuDung);


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

        public bool xoa(DocGiaDTO dg)
        {
            string query = string.Empty;
            query += "DELETE FROM [dbo].[tblTheDocGia] WHERE [maDocGia] = @maDocGia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maDocGia", dg.Ma);
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




        public bool sua(DocGiaDTO dg)
        {
            Console.WriteLine("b============== BAT DAU SU THONG TIN THE =============");
            Console.WriteLine("Dia chi: " + dg.DiaChi);
            Console.WriteLine("Email: " + dg.Email);
            Console.WriteLine("Ma doc gia: " + dg.Ma);
            Console.WriteLine("Ma loai doc gia: '" + dg.maLoaiDocGia + "'");
            string query = string.Empty;
            query += "UPDATE [dbo].[tblTheDocGia]  SET ";
            query += "[hoVaTenDocGia] = @hoVaTenDocGia,";
            query += "[ngaySinh] = @ngaySinh,";
            query += " [email] = @email, ";
            query += "[diaChi] = @diaChi, ";
            query += "[maLoaiDocGia] = @maLoaiDocGia,";
            query += "[ngayLapThe] =@ngayLapThe,";
            query += "[hanSuDung]=@hanSuDung ";
            query += " WHERE[maDocGia] =@maDocGia";
            Console.WriteLine("Query: " + query);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maDocGia", dg.Ma);
                    cmd.Parameters.AddWithValue("@hoVaTenDocGia", dg.HovaTen);
                    cmd.Parameters.AddWithValue("@ngaySinh", dg.NgaySinh.Year + "-" + dg.NgaySinh.Month + "-" + dg.NgaySinh.Day);
                    cmd.Parameters.AddWithValue("@email", dg.Email);
                    cmd.Parameters.AddWithValue("@diaChi", dg.DiaChi);
                    cmd.Parameters.AddWithValue("@maLoaiDocGia", dg.maLoaiDocGia);
                    cmd.Parameters.AddWithValue("@ngayLapThe", dg.NgayLapThe.Year + "-" + dg.NgayLapThe.Month + "-" + dg.NgayLapThe.Day);
                    cmd.Parameters.AddWithValue("@hanSuDung", dg.HanSuDung);
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

        public List<DocGiaDTO> TimKiemBangTen(String ten)
        {



            Console.WriteLine("========================================================");
            Console.WriteLine("Tim kiem doc gia bang ten: " + ten);
            string query = string.Empty;
            query = "select * from[dbo].[tblTheDocGia]";
            query += "WHERE [hoVaTenDocGia] =@hoVaTenDocGia";

            List<DocGiaDTO> ListDocGia = new List<DocGiaDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@hoVaTenDocGia", ten);

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
                                DocGiaDTO DocGia = new DocGiaDTO();

                                DocGia.Ma = reader["maDocGia"].ToString();
                                Console.WriteLine("Ma doc gia: " + DocGia.Ma);
                                DocGia.HovaTen = reader["hoVaTenDocGia"].ToString();
                                Console.WriteLine("Ten doc gia: " + DocGia.HovaTen);
                                DocGia.HanSuDung = int.Parse(reader["hanSuDung"].ToString());
                                DocGia.DiaChi = reader["diaChi"].ToString();
                                DocGia.Email = reader["email"].ToString();
                                DocGia.maLoaiDocGia = reader["maLoaiDocGia"].ToString();


                                DocGia.NgayLapThe = DateTime.Parse(reader["ngayLapThe"].ToString());
                                DocGia.NgaySinh = DateTime.Parse(reader["ngaySinh"].ToString());

                                ListDocGia.Add(DocGia);


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
            return ListDocGia;

        }


        public DocGiaDTO get(String MaDG)
        {


            Console.WriteLine("========================================================");
            Console.WriteLine("Load get Thong tin doc gia: " + MaDG);
            string query = string.Empty;
            query = "select * from[dbo].[tblTheDocGia]";
            query += "WHERE [maDocGia] =@maDocGia";

            DocGiaDTO DocGia = new DocGiaDTO();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maDocGia", MaDG);

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

                                DocGia.Ma = reader["maDocGia"].ToString();
                                Console.WriteLine("Ma doc gia: " + DocGia.Ma);
                                DocGia.HovaTen = reader["hoVaTenDocGia"].ToString();
                                Console.WriteLine("Ten doc gia: " + DocGia.HovaTen);
                                DocGia.HanSuDung = int.Parse(reader["hanSuDung"].ToString());
                                DocGia.DiaChi = reader["diaChi"].ToString();
                                DocGia.Email = reader["email"].ToString();
                                DocGia.maLoaiDocGia = reader["maLoaiDocGia"].ToString();


                                DocGia.NgayLapThe = DateTime.Parse(reader["ngayLapThe"].ToString());
                                DocGia.NgaySinh = DateTime.Parse(reader["ngaySinh"].ToString());




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
            return DocGia;
        }

        public List<DocGiaDTO> select()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Load doc gia");
            string query = string.Empty;
            query = "select * from[dbo].[tblTheDocGia],[dbo].[tblLoaiDocGia]";
            query += "WHERE [dbo].[tblTheDocGia].[maLoaiDocGia]=[dbo].[tblLoaiDocGia].[maLoaiDocGia]";

            List<DocGiaDTO> lsDocGia = new List<DocGiaDTO>();

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
                                DocGiaDTO dg = new DocGiaDTO();
                                dg.Ma = reader["maDocGia"].ToString();
                                Console.WriteLine("Ma doc gia: " + dg.Ma);

                                dg.HovaTen = reader["hoVaTenDocGia"].ToString();

                                dg.NgayLapThe = DateTime.Parse(reader["ngayLapThe"].ToString());
                                dg.NgaySinh = DateTime.Parse(reader["ngaySinh"].ToString());
                                dg.HanSuDung = int.Parse(reader["hanSuDung"].ToString());
                                dg.DiaChi = reader["diaChi"].ToString();
                                dg.Email = reader["email"].ToString();
                                dg.maLoaiDocGia = reader["maLoaiDocGia"].ToString();
                                dg.TenLoaiDocGia = reader["TenLoaiDocGia"].ToString();

                                lsDocGia.Add(dg);
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
            Console.WriteLine("Load loai doc gia thanh cong");
            return lsDocGia;
        }
    }
}
