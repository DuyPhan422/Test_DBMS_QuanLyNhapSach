using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _23110194_PhanNgocDuy_QuanLyNhapSach
{
    internal class DBConnect
    {
        private SqlConnection stringConnect;

        public DBConnect()
        {
            string strCon = @"Data Source=localhost;Initial Catalog=NhapSach;Persist Security Info=True;User ID=sa;Password=40938813dD#;Encrypt=True;TrustServerCertificate=True";
            stringConnect = new SqlConnection(strCon);
        }

        public SqlConnection GetConnection
        {
            get { return stringConnect; }
        }

        public void OpenConnection()
        {
            try
            {
                if (stringConnect.State == ConnectionState.Closed)
                {
                    stringConnect.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (stringConnect.State == ConnectionState.Open)
                {
                    stringConnect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, stringConnect))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi truy vấn: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public int ExecuteInsertWithIdentity(string query, SqlParameter[] parameters = null)
        {
            int identityValue = -1;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, stringConnect))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT SCOPE_IDENTITY()";
                    object result = cmd.ExecuteScalar();
                    identityValue = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) : -1;
                    Console.WriteLine("IdentityValue từ SCOPE_IDENTITY(): " + identityValue);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL khi thực thi INSERT: " + ex.Message);
                Console.WriteLine("Lỗi SQL chi tiết: " + ex.Message + "\nSố lỗi: " + ex.Number + "\nTrạng thái: " + ex.State);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thực thi INSERT: " + e.Message);
                Console.WriteLine("Lỗi chi tiết: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return identityValue;
        }
    }
}