using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            dtpNgayNhap.Value = DateTime.Now;
            txtNamXuatBan.Text = DateTime.Now.Year.ToString();
        }
        private void ConfigureDataGridView()
        {
            dgvNhapSach.Columns.Clear();
            dgvNhapSach.AutoGenerateColumns = false;

            dgvNhapSach.Columns.Add("MaNhanVien", "Mã Nhân Viên");
            dgvNhapSach.Columns.Add("MaTheNhap", "Mã Thẻ Nhập");
            dgvNhapSach.Columns.Add("MaSach", "Mã Sách");
            dgvNhapSach.Columns.Add("TenSach", "Tên Sách");
            dgvNhapSach.Columns.Add("MaTacGia", "Mã Tác Giả");
            dgvNhapSach.Columns.Add("TenTacGia", "Tên Tác Giả");
            dgvNhapSach.Columns.Add("MaNhaXuatBan", "Mã Nhà Xuất Bản");
            dgvNhapSach.Columns.Add("NhaXuatBan", "Nhà Xuất Bản");
            dgvNhapSach.Columns.Add("MaTheLoai", "Mã Thể Loại");
            dgvNhapSach.Columns.Add("TheLoai", "Thể Loại");
            dgvNhapSach.Columns.Add("NamXuatBan", "Năm Xuất Bản");
            dgvNhapSach.Columns.Add("NgayNhap", "Ngày Nhập");
            dgvNhapSach.Columns.Add("SoLuong", "Số Lượng");
            dgvNhapSach.Columns.Add("GiaNhap", "Giá Nhập");
            dgvNhapSach.Columns.Add("ThanhTien", "Thành Tiền");

            foreach (DataGridViewColumn column in dgvNhapSach.Columns)
            {
                column.DataPropertyName = column.Name;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvNhapSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhapSach.AllowUserToAddRows = false;
            dgvNhapSach.AllowUserToDeleteRows = false;
            dgvNhapSach.ReadOnly = true;
            dgvNhapSach.RowHeadersVisible = false;

            dgvNhapSach.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void LoadDataGridView()
        {
            string query = @"
                SELECT 
                    nv.IdNV AS MaNhanVien, 
                    tn.MaTheNhap, 
                    s.MaSach, 
                    s.TenSach, 
                    tg.MaTacGia, 
                    tg.TenTacGia, 
                    nxb.MaNXB AS MaNhaXuatBan, 
                    nxb.TenNXB AS NhaXuatBan, 
                    tl.MaTheLoai, 
                    tl.TenTheLoai AS TheLoai, 
                    s.NamXuatBan, 
                    tn.NgayNhap, 
                    tn.TongSoLuongNhap AS SoLuong, 
                    tn.GiaNhap, 
                    tn.TongTienNhap AS ThanhTien
                FROM The_Nhap tn
                JOIN NhanVien nv ON tn.MaNV = nv.IdNV
                JOIN SACH s ON tn.MaSach = s.MaSach
                JOIN TAC_GIA tg ON s.MaTacGia = tg.MaTacGia
                JOIN THE_LOAI tl ON s.MaTheLoai = tl.MaTheLoai
                JOIN NHA_XUAT_BAN nxb ON s.MaNXB = nxb.MaNXB";
            DataTable dt = db.ExecuteQuery(query);
            dgvNhapSach.DataSource = dt;
        }


        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                // Log thông tin đầu vào
                string inputLog = $"Đầu vào: MaNhanVien={txtMaNhanVien.Text}, TenSach={txtTenSach.Text}, TacGia={txtTacGia.Text}, " +
                                 $"TheLoai={txtTheLoai.Text}, NXB={txtNhaXuatBan.Text}, NamXuatBan={txtNamXuatBan.Text}, " +
                                 $"SoLuong={txtSoLuong.Text}, GiaNhap={txtGiaNhap.Text}";
                Console.WriteLine(inputLog);

                // Kiểm tra mã nhân viên
                string checkNVQuery = "SELECT COUNT(*) FROM NhanVien WHERE IdNV = @IdNV";
                SqlParameter[] checkNVParams = new SqlParameter[] {
            new SqlParameter("@IdNV", SqlDbType.Int) { Value = int.Parse(txtMaNhanVien.Text) }
        };
                DataTable dtNVCheck = db.ExecuteQuery(checkNVQuery, checkNVParams);
                if (dtNVCheck.Rows.Count == 0 || dtNVCheck.Rows[0][0].ToString() == "0")
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                // Kiểm tra và thêm Nhà Xuất Bản
                string checkNXBQuery = "IF NOT EXISTS (SELECT 1 FROM NHA_XUAT_BAN WHERE TenNXB = @TenNXB) " +
                                      "INSERT INTO NHA_XUAT_BAN (TenNXB) VALUES (@TenNXB)";
                SqlParameter[] checkNXBParams = new SqlParameter[] {
            new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() ?? string.Empty }
        };
                db.ExecuteQuery(checkNXBQuery, checkNXBParams);
                string getNXBQuery = "SELECT MaNXB FROM NHA_XUAT_BAN WHERE TenNXB = @TenNXB";
                SqlParameter[] getNXBParams = new SqlParameter[] {
            new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() ?? string.Empty }
        };
                DataTable dtNXB = db.ExecuteQuery(getNXBQuery, getNXBParams);
                if (dtNXB.Rows.Count == 0) { MessageBox.Show("Không thể lấy MaNXB!"); return; }
                string maNXB = dtNXB.Rows[0]["MaNXB"].ToString();
                Console.WriteLine("MaNXB: " + maNXB);

                // Kiểm tra và thêm Tác Giả
                string checkTacGiaQuery = "IF NOT EXISTS (SELECT 1 FROM TAC_GIA WHERE TenTacGia = @TenTacGia) " +
                                         "INSERT INTO TAC_GIA (TenTacGia) VALUES (@TenTacGia)";
                SqlParameter[] checkTacGiaParams = new SqlParameter[] {
            new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() ?? string.Empty }
        };
                db.ExecuteQuery(checkTacGiaQuery, checkTacGiaParams);
                string getTacGiaQuery = "SELECT MaTacGia FROM TAC_GIA WHERE TenTacGia = @TenTacGia";
                SqlParameter[] getTacGiaParams = new SqlParameter[] {
            new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() ?? string.Empty }
        };
                DataTable dtTacGia = db.ExecuteQuery(getTacGiaQuery, getTacGiaParams);
                if (dtTacGia.Rows.Count == 0) { MessageBox.Show("Không thể lấy MaTacGia!"); return; }
                string maTacGia = dtTacGia.Rows[0]["MaTacGia"].ToString();
                Console.WriteLine("MaTacGia: " + maTacGia);

                // Kiểm tra và thêm Thể Loại
                string checkTheLoaiQuery = "IF NOT EXISTS (SELECT 1 FROM THE_LOAI WHERE TenTheLoai = @TenTheLoai) " +
                                          "INSERT INTO THE_LOAI (TenTheLoai) VALUES (@TenTheLoai)";
                SqlParameter[] checkTheLoaiParams = new SqlParameter[] {
            new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = txtTheLoai.Text.Trim() ?? string.Empty }
        };
                db.ExecuteQuery(checkTheLoaiQuery, checkTheLoaiParams);
                string getTheLoaiQuery = "SELECT MaTheLoai FROM THE_LOAI WHERE TenTheLoai = @TenTheLoai";
                SqlParameter[] getTheLoaiParams = new SqlParameter[] {
            new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = txtTheLoai.Text.Trim() ?? string.Empty }
        };
                DataTable dtTheLoai = db.ExecuteQuery(getTheLoaiQuery, getTheLoaiParams);
                if (dtTheLoai.Rows.Count == 0) { MessageBox.Show("Không thể lấy MaTheLoai!"); return; }
                string maTheLoai = dtTheLoai.Rows[0]["MaTheLoai"].ToString();
                Console.WriteLine("MaTheLoai: " + maTheLoai);

                // Tạo và kiểm tra MaSach
                string getMaxMaSachQuery = "SELECT ISNULL(MAX(MaSach), 'S000') FROM SACH";
                DataTable dtMaxMaSach = db.ExecuteQuery(getMaxMaSachQuery);
                string maSach = "S001";
                if (dtMaxMaSach.Rows.Count > 0 && dtMaxMaSach.Rows[0][0] != DBNull.Value)
                {
                    string maxMaSach = dtMaxMaSach.Rows[0][0].ToString();
                    int number = int.Parse(maxMaSach.Substring(1)) + 1;
                    maSach = "S" + number.ToString("D3");
                }
                Console.WriteLine("MaSach được tạo: " + maSach);

                string checkMaSachQuery = "SELECT COUNT(*) FROM SACH WHERE MaSach = @MaSach";
                SqlParameter[] checkMaSachParams = new SqlParameter[] {
            new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach }
        };
                DataTable dtCheckMaSach = db.ExecuteQuery(checkMaSachQuery, checkMaSachParams);
                if (dtCheckMaSach.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show("MaSach đã tồn tại! Vui lòng thử lại.");
                    return;
                }

                // Thêm Sách
                string insertSachQuery = @"
            INSERT INTO SACH (MaSach, TenSach, NamXuatBan, GiaSach, MaTacGia, MaTheLoai, MaNXB, AnhBia)
            VALUES (@MaSach, @TenSach, @NamXuatBan, @GiaSach, @MaTacGia, @MaTheLoai, @MaNXB, NULL)";
                SqlParameter[] sachParams = new SqlParameter[] {
            new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach },
            new SqlParameter("@TenSach", SqlDbType.NVarChar) { Value = txtTenSach.Text.Trim() ?? string.Empty },
            new SqlParameter("@NamXuatBan", SqlDbType.Int) { Value = int.Parse(txtNamXuatBan.Text) },
            new SqlParameter("@GiaSach", SqlDbType.Decimal) { Value = decimal.Parse(txtGiaNhap.Text) },
            new SqlParameter("@MaTacGia", SqlDbType.VarChar) { Value = maTacGia },
            new SqlParameter("@MaTheLoai", SqlDbType.VarChar) { Value = maTheLoai },
            new SqlParameter("@MaNXB", SqlDbType.VarChar) { Value = maNXB }
        };
                int sachId = db.ExecuteInsertWithIdentity(insertSachQuery, sachParams);
                Console.WriteLine("Sách Id: " + sachId);
                if (sachId == -1)
                {
                    MessageBox.Show("Lỗi khi thêm sách! Vui lòng kiểm tra log trong Console để biết chi tiết.");
                    return;
                }
                Console.WriteLine("Sách chèn thành công với Id: " + sachId);

                // Thêm Thẻ Nhập
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal tongTienNhap = giaNhap * soLuong;

                string getMaxMaTheNhapQuery = "SELECT ISNULL(MAX(MaTheNhap), 'TN000') FROM The_Nhap";
                DataTable dtMaxMaTheNhap = db.ExecuteQuery(getMaxMaTheNhapQuery);
                string maTheNhap = "TN001";
                if (dtMaxMaTheNhap.Rows.Count > 0 && dtMaxMaTheNhap.Rows[0][0] != DBNull.Value)
                {
                    string maxMaTheNhap = dtMaxMaTheNhap.Rows[0][0].ToString();
                    int number = int.Parse(maxMaTheNhap.Substring(2)) + 1;
                    maTheNhap = "TN" + number.ToString("D3");
                }
                Console.WriteLine("MaTheNhap được tạo: " + maTheNhap);

                string insertTheNhapQuery = @"
            INSERT INTO The_Nhap (MaTheNhap, MaNV, NgayNhap, TongSoLuongNhap, TrangThai, GiaNhap, TongTienNhap, MaSach)
            VALUES (@MaTheNhap, @MaNV, @NgayNhap, @TongSoLuongNhap, @TrangThai, @GiaNhap, @TongTienNhap, @MaSach)";
                SqlParameter[] theNhapParams = new SqlParameter[] {
            new SqlParameter("@MaTheNhap", SqlDbType.VarChar) { Value = maTheNhap },
            new SqlParameter("@MaNV", SqlDbType.Int) { Value = int.Parse(txtMaNhanVien.Text) },
            new SqlParameter("@NgayNhap", SqlDbType.Date) { Value = dtpNgayNhap.Value },
            new SqlParameter("@TongSoLuongNhap", SqlDbType.Int) { Value = soLuong },
            new SqlParameter("@TrangThai", SqlDbType.VarChar) { Value = "DaNhap" },
            new SqlParameter("@GiaNhap", SqlDbType.Decimal) { Value = giaNhap },
            new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Value = tongTienNhap },
            new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach }
        };
                int theNhapId = db.ExecuteInsertWithIdentity(insertTheNhapQuery, theNhapParams);
                Console.WriteLine("Thẻ Nhập Id: " + theNhapId);
                if (theNhapId == -1)
                {
                    MessageBox.Show("Lỗi khi thêm thẻ nhập! Vui lòng kiểm tra log trong Console để biết chi tiết.");
                    return;
                }
                Console.WriteLine("Thẻ Nhập chèn thành công với Id: " + theNhapId);

                MessageBox.Show("Nhập sách thành công! MaSach=" + maSach + ", MaTheNhap=" + maTheNhap);
                LoadDataGridView();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                Console.WriteLine("Lỗi chi tiết: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
        }
        private string GetMaSachFromId(int id)
        {
            string query = "SELECT MaSach FROM SACH WHERE Id = @Id";
            SqlParameter[] paramsArray = new SqlParameter[] {
        new SqlParameter("@Id", SqlDbType.Int) { Value = id }
    };
            DataTable dt = db.ExecuteQuery(query, paramsArray);
            return dt.Rows.Count > 0 ? dt.Rows[0]["MaSach"].ToString() : null;
        }

        private string GetMaTheNhapFromId(int id)
        {
            string query = "SELECT MaTheNhap FROM The_Nhap WHERE Id = @Id";
            SqlParameter[] paramsArray = new SqlParameter[] {
        new SqlParameter("@Id", SqlDbType.Int) { Value = id }
    };
            DataTable dt = db.ExecuteQuery(query, paramsArray);
            return dt.Rows.Count > 0 ? dt.Rows[0]["MaTheNhap"].ToString() : null;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNhapSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một bản ghi để cập nhật!");
                    return;
                }

                if (!ValidateInput()) return;

                string maTheNhap = dgvNhapSach.SelectedRows[0].Cells["MaTheNhap"].Value.ToString();
                string maSach = dgvNhapSach.SelectedRows[0].Cells["MaSach"].Value.ToString();

                // Kiểm tra và thêm Nhà Xuất Bản nếu chưa tồn tại
                string checkNXBQuery = "IF NOT EXISTS (SELECT 1 FROM NHA_XUAT_BAN WHERE TenNXB = @TenNXB) " +
                                      "INSERT INTO NHA_XUAT_BAN (TenNXB) VALUES (@TenNXB)";
                SqlParameter[] checkNXBParams = new SqlParameter[] {
                    new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() }
                };
                db.ExecuteQuery(checkNXBQuery, checkNXBParams);

                // Lấy MaNXB
                string getNXBQuery = "SELECT MaNXB FROM NHA_XUAT_BAN WHERE TenNXB = @TenNXB";
                SqlParameter[] getNXBParams = new SqlParameter[] {
                    new SqlParameter("@TenNXB", SqlDbType.NVarChar) { Value = txtNhaXuatBan.Text.Trim() }
                };
                DataTable dtNXB = db.ExecuteQuery(getNXBQuery, getNXBParams);
                string maNXB = dtNXB.Rows[0]["MaNXB"].ToString();

                // Kiểm tra và thêm Tác Giả nếu chưa tồn tại
                string checkTacGiaQuery = "IF NOT EXISTS (SELECT 1 FROM TAC_GIA WHERE TenTacGia = @TenTacGia) " +
                                          "INSERT INTO TAC_GIA (TenTacGia) VALUES (@TenTacGia)";
                SqlParameter[] checkTacGiaParams = new SqlParameter[] {
                    new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() }
                };
                db.ExecuteQuery(checkTacGiaQuery, checkTacGiaParams);

                // Lấy MaTacGia
                string getTacGiaQuery = "SELECT MaTacGia FROM TAC_GIA WHERE TenTacGia = @TenTacGia";
                SqlParameter[] getTacGiaParams = new SqlParameter[] {
                    new SqlParameter("@TenTacGia", SqlDbType.NVarChar) { Value = txtTacGia.Text.Trim() }
                };
                DataTable dtTacGia = db.ExecuteQuery(getTacGiaQuery, getTacGiaParams);
                string maTacGia = dtTacGia.Rows[0]["MaTacGia"].ToString();

                // Kiểm tra và thêm Thể Loại nếu chưa tồn tại
                string checkTheLoaiQuery = "IF NOT EXISTS (SELECT 1 FROM THE_LOAI WHERE TenTheLoai = @TenTheLoai) " +
                                           "INSERT INTO THE_LOAI (TenTheLoai) VALUES (@TenTheLoai)";
                SqlParameter[] checkTheLoaiParams = new SqlParameter[] {
                    new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = txtTheLoai.Text.Trim() }
                };
                db.ExecuteQuery(checkTheLoaiQuery, checkTheLoaiParams);

                // Lấy MaTheLoai
                string getTheLoaiQuery = "SELECT MaTheLoai FROM THE_LOAI WHERE TenTheLoai = @TenTheLoai";
                SqlParameter[] getTheLoaiParams = new SqlParameter[] {
                    new SqlParameter("@TenTheLoai", SqlDbType.NVarChar) { Value = txtTheLoai.Text.Trim() }
                };
                DataTable dtTheLoai = db.ExecuteQuery(getTheLoaiQuery, getTheLoaiParams);
                string maTheLoai = dtTheLoai.Rows[0]["MaTheLoai"].ToString();

                // Cập nhật Sách
                string updateSachQuery = @"
                    UPDATE SACH 
                    SET TenSach = @TenSach, NamXuatBan = @NamXuatBan, GiaSach = @GiaSach, 
                        MaTacGia = @MaTacGia, MaTheLoai = @MaTheLoai, MaNXB = @MaNXB
                    WHERE MaSach = @MaSach";
                SqlParameter[] sachParams = new SqlParameter[]
                {
                    new SqlParameter("@TenSach", SqlDbType.NVarChar) { Value = txtTenSach.Text.Trim() },
                    new SqlParameter("@NamXuatBan", SqlDbType.Int) { Value = int.Parse(txtNamXuatBan.Text) },
                    new SqlParameter("@GiaSach", SqlDbType.Decimal) { Value = decimal.Parse(txtGiaNhap.Text) },
                    new SqlParameter("@MaTacGia", SqlDbType.VarChar) { Value = maTacGia },
                    new SqlParameter("@MaTheLoai", SqlDbType.VarChar) { Value = maTheLoai },
                    new SqlParameter("@MaNXB", SqlDbType.VarChar) { Value = maNXB },
                    new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach }
                };
                db.ExecuteQuery(updateSachQuery, sachParams);

                // Cập nhật Thẻ Nhập
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal tongTienNhap = giaNhap * soLuong;

                string updateTheNhapQuery = @"
                    UPDATE The_Nhap 
                    SET MaNV = @MaNV, NgayNhap = @NgayNhap, TongSoLuongNhap = @TongSoLuongNhap, 
                        TrangThai = @TrangThai, GiaNhap = @GiaNhap, TongTienNhap = @TongTienNhap, MaSach = @MaSach 
                    WHERE MaTheNhap = @MaTheNhap";
                SqlParameter[] theNhapParams = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", SqlDbType.Int) { Value = int.Parse(txtMaNhanVien.Text) },
                    new SqlParameter("@NgayNhap", SqlDbType.Date) { Value = dtpNgayNhap.Value },
                    new SqlParameter("@TongSoLuongNhap", SqlDbType.Int) { Value = soLuong },
                    new SqlParameter("@TrangThai", SqlDbType.VarChar) { Value = "DaNhap" },
                    new SqlParameter("@GiaNhap", SqlDbType.Decimal) { Value = giaNhap },
                    new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Value = tongTienNhap },
                    new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach },
                    new SqlParameter("@MaTheNhap", SqlDbType.VarChar) { Value = maTheNhap }
                };
                db.ExecuteQuery(updateTheNhapQuery, theNhapParams);

                MessageBox.Show("Cập nhật thành công!");
                LoadDataGridView();
                ClearInput();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lỗi định dạng: Vui lòng nhập đúng kiểu dữ liệu (số, chữ) cho các trường. Chi tiết: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: Kiểm tra kết nối hoặc ràng buộc dữ liệu. Chi tiết: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNhapSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một bản ghi để xóa!");
                    return;
                }

                string maTheNhap = dgvNhapSach.SelectedRows[0].Cells["MaTheNhap"].Value.ToString();
                string query = "DELETE FROM The_Nhap WHERE MaTheNhap = @MaTheNhap";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTheNhap", SqlDbType.VarChar) { Value = maTheNhap }
                };

                db.ExecuteQuery(query, parameters);
                MessageBox.Show("Xóa thành công!");
                LoadDataGridView();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: Kiểm tra kết nối hoặc ràng buộc dữ liệu. Chi tiết: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }
        }

        private void btnUploadAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string anhBia = openFileDialog.FileName;
                    picUploadAnh.Image = Image.FromFile(anhBia);
                    picUploadAnh.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (dgvNhapSach.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn một bản ghi để cập nhật ảnh!");
                        return;
                    }

                    string maSach = dgvNhapSach.SelectedRows[0].Cells["MaSach"].Value.ToString();
                    string query = "UPDATE SACH SET AnhBia = @AnhBia WHERE MaSach = @MaSach";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@AnhBia", SqlDbType.VarChar) { Value = anhBia },
                        new SqlParameter("@MaSach", SqlDbType.VarChar) { Value = maSach }
                    };
                    db.ExecuteQuery(query, parameters);
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
                string.IsNullOrWhiteSpace(txtNamXuatBan.Text) || string.IsNullOrWhiteSpace(txtTheLoai.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return false;
            }

            if (!int.TryParse(txtMaNhanVien.Text, out int maNhanVien))
            {
                MessageBox.Show("Mã nhân viên phải là số nguyên!");
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
            txtNamXuatBan.Text = DateTime.Now.Year.ToString();
            txtTheLoai.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
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
                txtTheLoai.Text = row.Cells["TheLoai"].Value?.ToString() ?? "";
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
                    picUploadAnh.Image = Image.FromFile(dt.Rows[0]["AnhBia"].ToString());
                    picUploadAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picUploadAnh.Image = null;
                }
            }
        }
    }
}
