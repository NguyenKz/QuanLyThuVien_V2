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
    public class PhieuMuonDAL
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
        public PhieuMuonDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public bool them(PhieuMuonDTO temp, bool MuonSach)
        {
            Console.WriteLine("Them the doc gia.");
            string query = string.Empty;
            if (MuonSach)
            {
                query += "INSERT INTO[dbo].[tblPhieuMuon]([maPhieu],[maSach],[maDocGia],[ngayMuon],[thoiHang])";
                query += " VALUES(@maPhieu,@maSach,@maDocGiam,@ngayMuon,@thoiHang)";
            }
            else
            {
                query += "INSERT INTO[dbo].[tblPhieuTra]([maPhieu],[maSach],[maDocGia],[ngayTra])";
                query += " VALUES(@maPhieu,@maSach,@maDocGiam,@ngayTra)";
            }
            Console.WriteLine("Query: " + query);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    Console.WriteLine("Bat đầu ex query");
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    if (MuonSach)
                    {
                        cmd.Parameters.AddWithValue("@maPhieu", temp.MaPhieuMuon);
                        cmd.Parameters.AddWithValue("@maSach", temp.MaSach);
                        cmd.Parameters.AddWithValue("@maDocGiam", temp.MaDocGia);
                        cmd.Parameters.AddWithValue("@ngayMuon", temp.NgayMuon.Year + "-" + temp.NgayMuon.Month + "-" + temp.NgayMuon.Day);
                        cmd.Parameters.AddWithValue("@thoiHang", temp.ThoiHan);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@maPhieu", temp.MaPhieuTra);
                        cmd.Parameters.AddWithValue("@maSach", temp.MaSach);
                        cmd.Parameters.AddWithValue("@maDocGiam", temp.MaDocGia);
                        cmd.Parameters.AddWithValue("@ngayTra", temp.NgayTra.Year + "-" + temp.NgayTra.Month + "-" + temp.NgayTra.Day);
                    }
                    Console.WriteLine("Ma Ta:" + temp.MaPhieuTra + "ma sach" + temp.MaSach + " Ma doc gia " + temp.MaDocGia);
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
        public List<PhieuMuonDTO> select()
        {



            Console.WriteLine("========================================================");
  
            string query = string.Empty;
            query += "SELECT [dbo].[tblPhieuTra].maPhieu maPhieuTra,";
            query += "[dbo].[tblPhieuMuon].maPhieu maPhieuMuon,";
            query += "[dbo].[tblPhieuMuon].maDocGia,";
            query += "[dbo].[tblPhieuMuon].maSach  ,";
            query += "[dbo].[tblPhieuMuon].thoiHang ,";
            query += "[dbo].[tblPhieuMuon].ngayMuon ,";
            query += "[dbo].[tblPhieuTra].ngayTra  ";

            query += "FROM[dbo].[tblPhieuMuon] LEFT JOIN[dbo].[tblPhieuTra]";
            query += "ON [dbo].[tblPhieuMuon].maDocGia=[dbo].[tblPhieuTra].maDocGia ";
            query += "and [dbo].[tblPhieuMuon].maSach=[dbo].[tblPhieuTra].maSach    ";
           


            List<PhieuMuonDTO> ListDocGia = new List<PhieuMuonDTO>();

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
                                PhieuMuonDTO temp = new PhieuMuonDTO();
                                temp.MaPhieuMuon= reader["maPhieuMuon"].ToString();
                                String MaPhieuTra= reader["maPhieuTra"].ToString();
                                if (MaPhieuTra.Length > 0)
                                    temp.MaPhieuTra = MaPhieuTra;
                                else
                                    temp.MaPhieuTra = "NULL";
                                temp.MaDocGia = reader["maDocGia"].ToString();
                                temp.MaSach = reader["maSach"].ToString();
                                temp.NgayMuon = DateTime.Parse(reader["ngayMuon"].ToString());
                                String ngayTra = reader["ngayTra"].ToString();
                                if (ngayTra.Length>0)
                                    temp.NgayTra = DateTime.Parse(reader["ngayTra"].ToString());
                                
                                temp.ThoiHan = int.Parse(reader["thoiHang"].ToString());

                                temp.SoNgayQuaHan=(int)(DateTime.Now.Subtract(temp.NgayMuon).TotalDays-temp.ThoiHan);
                        
                                
                                temp.getTinhTrang();
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
            
            Console.WriteLine("Get doc gia thanh cong");
            return ListDocGia;

        }



        


    }
}
