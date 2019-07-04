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
    public class TheLoaiDAL
    {
        private string connectionString;


        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }



        public TheLoaiDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        //public string ConnectionString { get => connectionString; set => connectionString = value; }
        public String cmd_string;
        public bool them(TheLoaiDTO tl)
        {
            Console.WriteLine("Them the doc gia.");
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblTheLoai]([maTheLoai],[tenTheLoai])";
            query += " VALUES(@MaTheLoai,@TenTheLoai)";
            Console.WriteLine("Query: " + query);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    Console.WriteLine("Bat đầu ex query");
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaTheLoai", tl.MaTheLoai);
                    cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);
                    Console.WriteLine("Ma: " + tl.MaTheLoai);
                    Console.WriteLine("Ten the loai: " + tl.TenTheLoai);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        con.Close();
                        con.Dispose();
                        Console.WriteLine("ex query thanh cong");
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        Console.WriteLine("ex query that bai");
                        return false;
                    }
                }
            }
            return true;
        }

        public bool xoa(TheLoaiDTO tl)
        {
            Console.WriteLine("Xoa the loai.");
            string query = string.Empty;
            query += "DELETE FROM [dbo].[tblTheLoai] WHERE [maTheLoai] = @MaTheLoai";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaTheLoai", tl.MaTheLoai);
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

        public bool sua(TheLoaiDTO tl)
        {
            Console.WriteLine("Sua loai doc gia.");
            string query = string.Empty;
            query += "UPDATE [dbo].[tblTheLoai]  SET ";
            query += "[tenTheLoai] = @TenTheLoai ";
            query += "WHERE [maTheLoai] = @MaTheLoai";
            Console.WriteLine("Query: " + query);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);
                    cmd.Parameters.AddWithValue("@MaTheLoai", tl.MaTheLoai);
                    Console.WriteLine("Bat dau query.");
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                        Console.WriteLine("ex query thanh cong.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ex query that bai.");
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }


        public List<TheLoaiDTO> select(String Ma)
        {
            string query = string.Empty;
            query += "select * from[dbo].[tblTheLoai]";

            if (Ma.Length > 0)
            {
                query += "WHERE [dbo].[tblTheLoai].[maTheLoai] =@maTheLoai";
            }



            List<TheLoaiDTO> lsLoaiDocGia = new List<TheLoaiDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("Load loai doc gia");
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    if (Ma.Length > 0)
                    {
                        cmd.Parameters.AddWithValue("maTheLoai", Ma);
                    }
                    cmd.CommandText = query;

                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;

                        reader = cmd.ExecuteReader();

                        if (reader.HasRows == true)
                        {

                            while (reader.Read())
                            {

                                TheLoaiDTO tl = new TheLoaiDTO();

                                tl.MaTheLoai = reader["MaTheLoai"].ToString();
                                Console.WriteLine("Ma loai doc gia: " + tl.MaTheLoai);
                                tl.TenTheLoai = reader["TenTheLoai"].ToString();
                                Console.WriteLine("Ten loai doc gia: " + tl.TenTheLoai);



                                lsLoaiDocGia.Add(tl);
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
            return lsLoaiDocGia;

        }

    }
}
