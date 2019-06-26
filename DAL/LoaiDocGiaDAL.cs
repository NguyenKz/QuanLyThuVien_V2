using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{

    public class LoaiDocGiaDAL
    {
        private string connectionString;


        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }



        public LoaiDocGiaDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        //public string ConnectionString { get => connectionString; set => connectionString = value; }
        public String cmd_string;
        public bool them(LoaiDocGiaDTO ldg)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblLoaiDocGia]([maLoaiDocGia],[tenLoaiDocGia])";
            query += " VALUES(@MaLoaiDocGia,@TenLoaiDocGia)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaLoaiDocGia", ldg.MaLoaiDocGia);
                    cmd.Parameters.AddWithValue("@TenLoaiDocGia", ldg.TenLoaiDocGia);


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

        public bool xoa(LoaiDocGiaDTO ldg)
        {
            string query = string.Empty;
            query += "DELETE FROM [dbo].[tblLoaiDocGia] WHERE [maLoaiDocGia] = @maLoaiDocGia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maDocGia", ldg.MaLoaiDocGia);
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

        public bool sua(LoaiDocGiaDTO ldg)
        {
            string query = string.Empty;
            query += "UPDATE [dbo].[tblLoaiDocGia]  SET ";
            query += "[tenLoaiDocGia]] = @[tenLoaiDocGia],";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tenLoaiDocGia", ldg.TenLoaiDocGia);
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

        public List<LoaiDocGiaDTO> select()
        {
            string query = string.Empty;
            query += "select * from[dbo].[tblLoaiDocGia]";


            List<LoaiDocGiaDTO> lsLoaiDocGia = new List<LoaiDocGiaDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("Load loai doc gia");
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
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

                                LoaiDocGiaDTO ldg = new LoaiDocGiaDTO();

                                ldg.MaLoaiDocGia = reader["maLoaiDocGia"].ToString();
                                Console.WriteLine("Ma loai doc gia: " + ldg.MaLoaiDocGia);
                                ldg.TenLoaiDocGia = reader["tenLoaiDocGia"].ToString();
                                Console.WriteLine("Ten loai doc gia: " + ldg.TenLoaiDocGia);



                                lsLoaiDocGia.Add(ldg);
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
