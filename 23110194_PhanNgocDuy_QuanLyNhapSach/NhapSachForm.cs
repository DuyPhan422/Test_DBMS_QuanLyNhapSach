using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23110194_PhanNgocDuy_QuanLyNhapSach
{
    public partial class NhapSachForm : Form
    {
        private DBConnect db = new DBConnect();
        public NhapSachForm()
        {
            InitializeComponent();
        }

        private void NhapSachForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDataGridView();
            LoadTheLoaiComboBox();
            dtpNgayNhap.Value = DateTime.Now;
            txtNamXuatBan.Text = DateTime.Now.Year.ToString();
        }
        private void ConfigureDataGridView()
        {
            // Thêm các cột
            dgvNhapSach.Columns.Add("MaNhanVien", "Mã Nhân Viên");
            dgvNhapSach.Columns.Add("MaTheNhap", "Mã Thẻ Nhập");
            dgvNhapSach.Columns.Add("MaSach", "Mã Sách");
            dgvNhapSach.Columns.Add("TenSach", "Tên Sách");
            dgvNhapSach.Columns.Add("TenTacGia", "Tên Tác Giả");
            dgvNhapSach.Columns.Add("NhaXuatBan", "Nhà Xuất Bản");
            dgvNhapSach.Columns.Add("TheLoai", "Thể Loại");
            dgvNhapSach.Columns.Add("NamXuatBan", "Năm XB");
            dgvNhapSach.Columns.Add("NgayNhap", "Ngày Nhập");
            dgvNhapSach.Columns.Add("SoLuong", "Số Lượng");
            dgvNhapSach.Columns.Add("GiaNhap", "Giá Nhập");
            dgvNhapSach.Columns.Add("ThanhTien", "Thành Tiền");


            // Cấu hình cột
            foreach (DataGridViewColumn column in dgvNhapSach.Columns)
            {
                column.DataPropertyName = column.Name;
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Bật wrap text
            }


            // Cấu hình DataGridView
            dgvNhapSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhapSach.AllowUserToAddRows = false;
            dgvNhapSach.AllowUserToDeleteRows = false;
            dgvNhapSach.ReadOnly = true;
            dgvNhapSach.RowHeadersVisible = false;
            dgvNhapSach.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhapSach.ScrollBars = ScrollBars.Both; // Bật cả thanh cuộn dọc và ngang
            dgvNhapSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Tự động điều chỉnh chiều cao hàng
            dgvNhapSach.RowTemplate.Height = 50; // Chiều cao hàng tối thiểu
            dgvNhapSach.Height = 300;
        }
        private void LoadTheLoaiComboBox()
        {
            cbbTheLoai.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTheLoai.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Tải danh sách thể loại từ cơ sở dữ liệu
            string query = "SELECT TenTheLoai FROM THE_LOAI";
            DataTable dt = db.ExecuteQuery(query);
            cbbTheLoai.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cbbTheLoai.Items.Add(row["TenTheLoai"].ToString());
            }
        }

        private void LoadDataGridView()
        {
            string query = @"
                SELECT
                    nv.MaNV AS MaNhanVien,
                    tn.MaTheNhap,
                    s.MaSach,
                    s.TenSach,
                    tg.TenTacGia,
                    nxb.TenNXB AS NhaXuatBan,
                    tl.TenTheLoai AS TheLoai,
                    s.NamXuatBan,
                    tn.NgayNhap,
                    tn.TongSoLuongNhap AS SoLuong,
                    tn.GiaNhap,
                    tn.TongTienNhap AS ThanhTien
                FROM The_Nhap tn
                JOIN NhanVien nv ON tn.IdNV = nv.IdNV
                JOIN SACH s ON tn.IdS = s.IdS
                JOIN TAC_GIA tg ON s.IdTacGia = tg.IdTG
                JOIN THE_LOAI tl ON s.IdTheLoai = tl.IdTL
                JOIN NHA_XUAT_BAN nxb ON s.IdNXB = nxb.IdNXB";
            DataTable dt = db.ExecuteQuery(query);
            dgvNhapSach.DataSource = dt;
        }
        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            try
            {
                if (!ValidateInput()) return;

                conn = db.GetConnection; // Sử dụng thuộc tính thay vì gọi phương thức
                conn.Open();
                transaction = conn.BeginTransaction();

                // Kiểm tra mã nhân viên
                string checkNVQuery = "SELECT IdNV FROM NhanVien WHERE MaNV = @MaNV";
                SqlParameter[] checkNVParams = new SqlParameter[] {
            new SqlParameter("@MaNV", SqlDbType.VarChar) { Value = txtMaNhanVien.Text.Trim() }
        };
                DataTable dtNVCheck = db.ExecuteQuery(checkNVQuery, checkNVParams, conn, transaction);
                if (dtNVCheck.Rows.Count == 0)
                {
                    transaction.Rollback();
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }
                int idNV = Convert.ToInt32(dtNVCheck.Rows[0]["IdNV"]);

                // Kiểm tra và thêm tác giả
                string getTGQuery = "SELECT IdTG FROM TAC_GIA WHERE TenTacGia = @TenTacGia";
                SqlParameter[] getTGParams = new SqlParameter[] {
            new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() }
        };
                DataTable dtTG = db.ExecuteQuery(getTGQuery, getTGParams, conn, transaction);
                int idTacGia;
                if (dtTG.Rows.Count > 0)
                {
                    idTacGia = Convert.ToInt32(dtTG.Rows[0]["IdTG"]);
                }
                else
                {
                    string insertTGQuery = "INSERT INTO TAC_GIA (TenTacGia) VALUES (@TenTacGia)";
                    SqlParameter[] insertTGParams = new SqlParameter[] {
                new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() }
            };
                    idTacGia = db.ExecuteInsertWithIdentity(insertTGQuery, insertTGParams, conn, transaction);
                    if (idTacGia == -1)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm tác giả!");
                        return;
                    }
                }

                // Kiểm tra và thêm thể loại
                string getTLQuery = "SELECT IdTL FROM THE_LOAI WHERE TenTheLoai = @TenTheLoai";
                SqlParameter[] getTLParams = new SqlParameter[] {
                    new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = cbbTheLoai.Text.Trim() } // Thay txtTheLoai bằng cbbTheLoai
                };
                DataTable dtTL = db.ExecuteQuery(getTLQuery, getTLParams, conn, transaction);
                int idTheLoai;
                if (dtTL.Rows.Count > 0)
                {
                    idTheLoai = Convert.ToInt32(dtTL.Rows[0]["IdTL"]);
                }
                else
                {
                    string insertTLQuery = "INSERT INTO THE_LOAI (TenTheLoai) VALUES (@TenTheLoai)";
                    SqlParameter[] insertTLParams = new SqlParameter[] {
                        new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = cbbTheLoai.Text.Trim() } // Thay txtTheLoai bằng cbbTheLoai
                    };
                    idTheLoai = db.ExecuteInsertWithIdentity(insertTLQuery, insertTLParams, conn, transaction);
                    if (idTheLoai == -1)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm thể loại!");
                        return;
                    }
                    // Cập nhật ComboBox với thể loại mới
                    cbbTheLoai.Items.Add(cbbTheLoai.Text.Trim()); // Thay txtTheLoai bằng cbbTheLoai
                }

                // Kiểm tra và thêm nhà xuất bản
                string getNXBQuery = "SELECT IdNXB FROM NHA_XUAT_BAN WHERE TenNXB = @TenNXB";
                SqlParameter[] getNXBParams = new SqlParameter[] {
            new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() }
        };
                DataTable dtNXB = db.ExecuteQuery(getNXBQuery, getNXBParams, conn, transaction);
                int idNXB;
                if (dtNXB.Rows.Count > 0)
                {
                    idNXB = Convert.ToInt32(dtNXB.Rows[0]["IdNXB"]);
                }
                else
                {
                    string insertNXBQuery = "INSERT INTO NHA_XUAT_BAN (TenNXB) VALUES (@TenNXB)";
                    SqlParameter[] insertNXBParams = new SqlParameter[] {
                new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() }
            };
                    idNXB = db.ExecuteInsertWithIdentity(insertNXBQuery, insertNXBParams, conn, transaction);
                    if (idNXB == -1)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm nhà xuất bản!");
                        return;
                    }
                }

                // Kiểm tra và thêm sách
                string checkSachQuery = @"
            SELECT IdS, MaSach FROM SACH
            WHERE TenSach = @TenSach AND IdTacGia = @IdTacGia AND IdTheLoai = @IdTheLoai
            AND IdNXB = @IdNXB AND NamXuatBan = @NamXuatBan";
                SqlParameter[] checkSachParams = new SqlParameter[] {
            new SqlParameter("@TenSach", SqlDbType.NVarChar) { Value = txtTenSach.Text.Trim() },
            new SqlParameter("@IdTacGia", SqlDbType.Int) { Value = idTacGia },
            new SqlParameter("@IdTheLoai", SqlDbType.Int) { Value = idTheLoai },
            new SqlParameter("@IdNXB", SqlDbType.Int) { Value = idNXB },
            new SqlParameter("@NamXuatBan", SqlDbType.Int) { Value = int.Parse(txtNamXuatBan.Text) }
        };
                DataTable dtSachCheck = db.ExecuteQuery(checkSachQuery, checkSachParams, conn, transaction);
                int sachId;
                string maSach;

                if (dtSachCheck.Rows.Count > 0)
                {
                    sachId = Convert.ToInt32(dtSachCheck.Rows[0]["IdS"]);
                    maSach = dtSachCheck.Rows[0]["MaSach"].ToString();
                }
                else
                {
                    string insertSachQuery = @"
                INSERT INTO SACH (TenSach, NamXuatBan, GiaSach, IdTacGia, IdTheLoai, IdNXB, AnhBia)
                VALUES (@TenSach, @NamXuatBan, @GiaSach, @IdTacGia, @IdTheLoai, @IdNXB, NULL)";
                    SqlParameter[] sachParams = new SqlParameter[] {
                new SqlParameter("@TenSach", SqlDbType.NVarChar) { Value = txtTenSach.Text.Trim() },
                new SqlParameter("@NamXuatBan", SqlDbType.Int) { Value = int.Parse(txtNamXuatBan.Text) },
                new SqlParameter("@GiaSach", SqlDbType.Decimal) { Value = decimal.Parse(txtGiaNhap.Text) },
                new SqlParameter("@IdTacGia", SqlDbType.Int) { Value = idTacGia },
                new SqlParameter("@IdTheLoai", SqlDbType.Int) { Value = idTheLoai },
                new SqlParameter("@IdNXB", SqlDbType.Int) { Value = idNXB }
            };
                    sachId = db.ExecuteInsertWithIdentity(insertSachQuery, sachParams, conn, transaction);
                    if (sachId == -1)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm sách!");
                        return;
                    }

                    string getMaSachQuery = "SELECT MaSach FROM SACH WHERE IdS = @IdS";
                    SqlParameter[] getMaSachParams = new SqlParameter[] {
                new SqlParameter("@IdS", SqlDbType.Int) { Value = sachId }
            };
                    DataTable dtMaSach = db.ExecuteQuery(getMaSachQuery, getMaSachParams, conn, transaction);
                    if (dtMaSach.Rows.Count == 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi lấy mã sách!");
                        return;
                    }
                    maSach = dtMaSach.Rows[0]["MaSach"].ToString();
                }

                // Thêm thẻ nhập
                string insertTheNhapQuery = @"
            INSERT INTO The_Nhap (IdNV, IdS, NgayNhap, TrangThai, GiaNhap, TongSoLuongNhap, TongTienNhap)
            VALUES (@IdNV, @IdS, @NgayNhap, @TrangThai, @GiaNhap, @TongSoLuongNhap, @TongTienNhap)";
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal tongTienNhap = giaNhap * soLuong;
                SqlParameter[] theNhapParams = new SqlParameter[] {
            new SqlParameter("@IdNV", SqlDbType.Int) { Value = idNV },
            new SqlParameter("@IdS", SqlDbType.Int) { Value = sachId },
            new SqlParameter("@NgayNhap", SqlDbType.Date) { Value = dtpNgayNhap.Value },
            new SqlParameter("@TrangThai", SqlDbType.VarChar) { Value = "DaNhap" },
            new SqlParameter("@GiaNhap", SqlDbType.Decimal) { Value = giaNhap },
            new SqlParameter("@TongSoLuongNhap", SqlDbType.Int) { Value = soLuong },
            new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Value = tongTienNhap }
        };
                int theNhapId = db.ExecuteInsertWithIdentity(insertTheNhapQuery, theNhapParams, conn, transaction);
                if (theNhapId == -1)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi thêm thẻ nhập!");
                    return;
                }

                transaction.Commit();
                MessageBox.Show("Nhập sách thành công!");
                LoadDataGridView();
                ClearInput();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
       

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            try
            {
                if (dgvNhapSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một bản ghi để cập nhật!");
                    return;
                }
                if (!ValidateInput()) return;

                conn = db.GetConnection;
                conn.Open();
                transaction = conn.BeginTransaction();

                string maSach = dgvNhapSach.SelectedRows[0].Cells["MaSach"].Value.ToString();
                string maTheNhap = dgvNhapSach.SelectedRows[0].Cells["MaTheNhap"].Value.ToString();

                // Lấy số lượng cũ từ The_Nhap
                int soLuongCu = Convert.ToInt32(db.ExecuteQuery("SELECT TongSoLuongNhap FROM The_Nhap WHERE MaTheNhap = @MaTheNhap",
                    new SqlParameter[] { new SqlParameter("@MaTheNhap", maTheNhap) }, conn, transaction).Rows[0]["TongSoLuongNhap"]);
                int soLuongMoi = int.Parse(txtSoLuong.Text);
                bool capNhatSoLuong = soLuongCu != soLuongMoi; // Chỉ cập nhật số lượng nếu có thay đổi

                // Kiểm tra và thêm tác giả
                string getTGQuery = "SELECT IdTG FROM TAC_GIA WHERE TenTacGia = @TenTacGia";
                SqlParameter[] getTGParams = new SqlParameter[] {
            new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() }
        };
                DataTable dtTG = db.ExecuteQuery(getTGQuery, getTGParams, conn, transaction);
                int idTacGia;
                if (dtTG.Rows.Count > 0)
                {
                    idTacGia = Convert.ToInt32(dtTG.Rows[0]["IdTG"]);
                }
                else
                {
                    string insertTGQuery = "INSERT INTO TAC_GIA (TenTacGia) VALUES (@TenTacGia)";
                    SqlParameter[] insertTGParams = new SqlParameter[] {
                new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() }
            };
                    idTacGia = db.ExecuteInsertWithIdentity(insertTGQuery, insertTGParams, conn, transaction);
                    if (idTacGia == -1)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm tác giả!");
                        return;
                    }
                }

                // Kiểm tra và thêm thể loại
                // Kiểm tra và thêm thể loại
                string getTLQuery = "SELECT IdTL FROM THE_LOAI WHERE TenTheLoai = @TenTheLoai";
                SqlParameter[] getTLParams = new SqlParameter[] {
                    new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = cbbTheLoai.Text.Trim() } // Thay txtTheLoai bằng cbbTheLoai
                };
                DataTable dtTL = db.ExecuteQuery(getTLQuery, getTLParams, conn, transaction);
                int idTheLoai;
                if (dtTL.Rows.Count > 0)
                {
                    idTheLoai = Convert.ToInt32(dtTL.Rows[0]["IdTL"]);
                }
                else
                {
                    string insertTLQuery = "INSERT INTO THE_LOAI (TenTheLoai) VALUES (@TenTheLoai)";
                    SqlParameter[] insertTLParams = new SqlParameter[] {
                        new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = cbbTheLoai.Text.Trim() } // Thay txtTheLoai bằng cbbTheLoai
                    };
                    idTheLoai = db.ExecuteInsertWithIdentity(insertTLQuery, insertTLParams, conn, transaction);
                    if (idTheLoai == -1)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm thể loại!");
                        return;
                    }
                    // Cập nhật ComboBox với thể loại mới
                    cbbTheLoai.Items.Add(cbbTheLoai.Text.Trim()); // Thay txtTheLoai bằng cbbTheLoai
                }

                // Kiểm tra và thêm nhà xuất bản
                string getNXBQuery = "SELECT IdNXB FROM NHA_XUAT_BAN WHERE TenNXB = @TenNXB";
                SqlParameter[] getNXBParams = new SqlParameter[] {
            new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() }
        };
                DataTable dtNXB = db.ExecuteQuery(getNXBQuery, getNXBParams, conn, transaction);
                int idNXB;
                if (dtNXB.Rows.Count > 0)
                {
                    idNXB = Convert.ToInt32(dtNXB.Rows[0]["IdNXB"]);
                }
                else
                {
                    string insertNXBQuery = "INSERT INTO NHA_XUAT_BAN (TenNXB) VALUES (@TenNXB)";
                    SqlParameter[] insertNXBParams = new SqlParameter[] {
                new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() }
            };
                    idNXB = db.ExecuteInsertWithIdentity(insertNXBQuery, insertNXBParams, conn, transaction);
                    if (idNXB == -1)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm nhà xuất bản!");
                        return;
                    }
                }

                // Cập nhật thông tin sách
                string updateSachQuery = @"
            UPDATE SACH
            SET TenSach = @TenSach, NamXuatBan = @NamXuatBan, GiaSach = @GiaSach,
                IdTacGia = @IdTacGia, IdTheLoai = @IdTheLoai, IdNXB = @IdNXB
            WHERE MaSach = @MaSach";
                SqlParameter[] sachParams = new SqlParameter[] {
            new SqlParameter("@TenSach", SqlDbType.NVarChar) { Value = txtTenSach.Text.Trim() },
            new SqlParameter("@NamXuatBan", SqlDbType.Int) { Value = int.Parse(txtNamXuatBan.Text) },
            new SqlParameter("@GiaSach", SqlDbType.Decimal) { Value = decimal.Parse(txtGiaNhap.Text) },
            new SqlParameter("@IdTacGia", SqlDbType.Int) { Value = idTacGia },
            new SqlParameter("@IdTheLoai", SqlDbType.Int) { Value = idTheLoai },
            new SqlParameter("@IdNXB", SqlDbType.Int) { Value = idNXB },
            new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach }
        };
                db.ExecuteNonQuery(updateSachQuery, sachParams, conn, transaction);

                // Cập nhật thông tin thẻ nhập
                string updateTheNhapQuery = @"
            UPDATE The_Nhap
            SET NgayNhap = @NgayNhap, GiaNhap = @GiaNhap, TongSoLuongNhap = @TongSoLuongNhap,
                TongTienNhap = @TongTienNhap
            WHERE MaTheNhap = @MaTheNhap";
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                decimal tongTienNhap = giaNhap * soLuongMoi;
                SqlParameter[] theNhapParams = new SqlParameter[] {
            new SqlParameter("@NgayNhap", SqlDbType.Date) { Value = dtpNgayNhap.Value },
            new SqlParameter("@GiaNhap", SqlDbType.Decimal) { Value = giaNhap },
            new SqlParameter("@TongSoLuongNhap", SqlDbType.Int) { Value = soLuongMoi },
            new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Value = tongTienNhap },
            new SqlParameter("@MaTheNhap", SqlDbType.VarChar) { Value = maTheNhap }
        };
                db.ExecuteNonQuery(updateTheNhapQuery, theNhapParams, conn, transaction);

                // Chỉ gọi sp_CapNhatKhoSach nếu có thay đổi số lượng
                if (capNhatSoLuong)
                {
                    int idS = Convert.ToInt32(db.ExecuteQuery("SELECT IdS FROM SACH WHERE MaSach = @MaSach", new SqlParameter[] { new SqlParameter("@MaSach", maSach) }, conn, transaction).Rows[0]["IdS"]);
                    string updateKhoQuery = "EXEC sp_CapNhatKhoSach @IdS, @SoLuong";
                    SqlParameter[] updateKhoParams = new SqlParameter[] {
                new SqlParameter("@IdS", SqlDbType.Int) { Value = idS },
                new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuongMoi - soLuongCu } // Cập nhật chênh lệch
            };
                    db.ExecuteNonQuery(updateKhoQuery, updateKhoParams, conn, transaction);
                }

                transaction.Commit();
                MessageBox.Show("Cập nhật thành công!");
                LoadDataGridView();
                ClearInput();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            try
            {
                if (dgvNhapSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một bản ghi để xóa!");
                    return;
                }

                string maTheNhap = dgvNhapSach.SelectedRows[0].Cells["MaTheNhap"].Value.ToString();
                string maSach = dgvNhapSach.SelectedRows[0].Cells["MaSach"].Value.ToString();

                conn = db.GetConnection;
                conn.Open();
                transaction = conn.BeginTransaction();

                // Xóa thẻ nhập trước (vì có khóa ngoại liên quan đến SACH)
                string deleteTheNhapQuery = "DELETE FROM The_Nhap WHERE MaTheNhap = @MaTheNhap";
                using (SqlCommand cmdTheNhap = new SqlCommand(deleteTheNhapQuery, conn, transaction))
                {
                    cmdTheNhap.Parameters.AddWithValue("@MaTheNhap", maTheNhap);
                    int rowsAffectedTheNhap = cmdTheNhap.ExecuteNonQuery();
                    if (rowsAffectedTheNhap == 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Không tìm thấy thẻ nhập để xóa!");
                        return;
                    }
                }

                // Xóa sách
                string deleteSachQuery = "DELETE FROM SACH WHERE MaSach = @MaSach";
                using (SqlCommand cmdSach = new SqlCommand(deleteSachQuery, conn, transaction))
                {
                    cmdSach.Parameters.AddWithValue("@MaSach", maSach);
                    int rowsAffectedSach = cmdSach.ExecuteNonQuery();
                    if (rowsAffectedSach == 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Không tìm thấy sách để xóa!");
                        return;
                    }
                }

                transaction.Commit();
                MessageBox.Show("Xóa sách thành công!");
                LoadDataGridView();
                ClearInput();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnUploadAnh_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNhapSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một bản ghi để cập nhật ảnh!");
                    return;
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string anhBia = openFileDialog.FileName;
                    byte[] imageData = File.ReadAllBytes(anhBia);
                    string maSach = dgvNhapSach.SelectedRows[0].Cells["MaSach"].Value.ToString();

                    string updateImageQuery = "UPDATE SACH SET AnhBia = @AnhBia WHERE MaSach = @MaSach";
                    SqlParameter[] updateImageParams = new SqlParameter[] {
                        new SqlParameter("@AnhBia", SqlDbType.VarBinary) { Value = imageData },
                        new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach }
                    };
                    db.ExecuteNonQuery(updateImageQuery, updateImageParams);

                    picUploadAnh.Image = Image.FromFile(anhBia);
                    picUploadAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    MessageBox.Show("Tải ảnh lên thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text) || string.IsNullOrWhiteSpace(txtTenSach.Text) ||
                string.IsNullOrWhiteSpace(txtTacGia.Text) || string.IsNullOrWhiteSpace(txtNhaXuatBan.Text) ||
                string.IsNullOrWhiteSpace(cbbTheLoai.Text) || string.IsNullOrWhiteSpace(txtNamXuatBan.Text) || // Thay txtTheLoai bằng cbbTheLoai
                string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                return false;
            }

            if (!decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) || giaNhap < 0)
            {
                MessageBox.Show("Giá nhập phải là số không âm!");
                return false;
            }

            if (!int.TryParse(txtNamXuatBan.Text, out int namXuatBan) || namXuatBan <= 0)
            {
                MessageBox.Show("Năm xuất bản phải là số nguyên dương!");
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            txtMaNhanVien.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNhaXuatBan.Text = "";
            cbbTheLoai.Text = ""; // Thay txtTheLoai bằng cbbTheLoai
            txtNamXuatBan.Text = DateTime.Now.Year.ToString();
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            picUploadAnh.Image = null;
        }


        private void dgvNhapSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhapSach.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value?.ToString() ?? "";
                txtTenSach.Text = row.Cells["TenSach"].Value?.ToString() ?? "";
                txtTacGia.Text = row.Cells["TenTacGia"].Value?.ToString() ?? "";
                txtNhaXuatBan.Text = row.Cells["NhaXuatBan"].Value?.ToString() ?? "";
                cbbTheLoai.Text = row.Cells["TheLoai"].Value?.ToString() ?? "";
                txtNamXuatBan.Text = row.Cells["NamXuatBan"].Value?.ToString() ?? "";
                dtpNgayNhap.Value = row.Cells["NgayNhap"].Value != DBNull.Value ? (DateTime)row.Cells["NgayNhap"].Value : DateTime.Now;
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString() ?? "";
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value?.ToString() ?? "";

                // Hiển thị ảnh nếu có
                string maSach = row.Cells["MaSach"].Value?.ToString() ?? "";
                string query = "SELECT AnhBia FROM SACH WHERE MaSach = @MaSach";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach }
                };
                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0 && dt.Rows[0]["AnhBia"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])dt.Rows[0]["AnhBia"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        picUploadAnh.Image = Image.FromStream(ms);
                        picUploadAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    picUploadAnh.Image = null;
                }
            }
        }

        private void btnXacNhanNhap_Click(object sender, EventArgs e)
        {

        }
    }
}
