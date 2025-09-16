using System;
using System.Data;
using System.Data.SqlClient;
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

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters, SqlConnection conn, SqlTransaction transaction)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
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
                MessageBox.Show("Lỗi truy vấn trong transaction: " + e.Message);
            }
            return dt;
        }

        public int ExecuteInsertWithIdentity(string query, SqlParameter[] parameters = null)
        {
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query + "; SELECT SCOPE_IDENTITY();", stringConnect))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + e.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ExecuteInsertWithIdentity(string query, SqlParameter[] parameters, SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query + "; SELECT SCOPE_IDENTITY();", conn, transaction))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu trong transaction: " + e.Message);
                return -1;
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, stringConnect))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thực thi lệnh: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters, SqlConnection conn, SqlTransaction transaction, CommandType commandType = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thực thi lệnh trong transaction: " + e.Message);
                throw; // Ném ngoại lệ để rollback
            }
        }
    }
}