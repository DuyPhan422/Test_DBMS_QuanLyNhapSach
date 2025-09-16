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
    public partial class KhoSachForm : Form
    {
        private DBConnect dbConnect;
        public KhoSachForm()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
            LoadMaSachComboBox(); // Tải danh sách mã sách
            LoadKhoSach();
        }

       

        private void KhoSachForm_Load(object sender, EventArgs e)
        {
            // Cấu hình DataGridView
            dgvKhoSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoSach.AllowUserToAddRows = false;
            dgvKhoSach.AllowUserToDeleteRows = false;
            dgvKhoSach.ReadOnly = true;
            dgvKhoSach.RowHeadersVisible = false;
            dgvKhoSach.ScrollBars = ScrollBars.Both; // Bật cả thanh cuộn dọc và ngang
            dgvKhoSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Tự động điều chỉnh chiều cao hàng
            dgvKhoSach.RowTemplate.Height = 50; // Chiều cao hàng tối thiểu
            dgvKhoSach.Height = 300;

            // Định dạng cột ngày nếu có (tùy chỉnh theo cột trong dgvKhoSach)
            if (dgvKhoSach.Columns.Contains("NgayNhap")) // Thay "NgayNhap" bằng tên cột ngày thực tế nếu khác
            {
                dgvKhoSach.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            // Giữ các thiết lập font, màu sắc, và wrap text từ mã trước
            dgvKhoSach.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvKhoSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvKhoSach.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvKhoSach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhoSach.BackgroundColor = Color.White;
            dgvKhoSach.DefaultCellStyle.ForeColor = Color.Black;
            dgvKhoSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dgvKhoSach.GridColor = Color.Gray;
            dgvKhoSach.BorderStyle = BorderStyle.Fixed3D;

            // Bật wrap text và tự động điều chỉnh chiều cao
            foreach (DataGridViewColumn column in dgvKhoSach.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                column.Width = 150; // Giữ chiều rộng cột như đã điều chỉnh trước
            }

        }
        private void LoadKhoSach()
        {
            try
            {
                string query = "SELECT * FROM ViewChiTietNhapKho ORDER BY MaNhanVien";
                DataTable dt = dbConnect.ExecuteQuery(query);
                dgvKhoSach.DataSource = dt;

                // Đặt tiêu đề cột
                if (dgvKhoSach.Columns.Contains("MaNhanVien")) dgvKhoSach.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                if (dgvKhoSach.Columns.Contains("MaTheNhap")) dgvKhoSach.Columns["MaTheNhap"].HeaderText = "Mã Thẻ Nhập";
                if (dgvKhoSach.Columns.Contains("MaSach")) dgvKhoSach.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvKhoSach.Columns.Contains("TenSach")) dgvKhoSach.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvKhoSach.Columns.Contains("MaTacGia")) dgvKhoSach.Columns["MaTacGia"].HeaderText = "Mã Tác Giả";
                if (dgvKhoSach.Columns.Contains("TenTacGia")) dgvKhoSach.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
                if (dgvKhoSach.Columns.Contains("MaTheLoai")) dgvKhoSach.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
                if (dgvKhoSach.Columns.Contains("TheLoai")) dgvKhoSach.Columns["TheLoai"].HeaderText = "Thể Loại";
                if (dgvKhoSach.Columns.Contains("MaNhaXuatBan")) dgvKhoSach.Columns["MaNhaXuatBan"].HeaderText = "Mã Nhà Xuất Bản";
                if (dgvKhoSach.Columns.Contains("TenNhaXuatBan")) dgvKhoSach.Columns["TenNhaXuatBan"].HeaderText = "Tên Nhà Xuất Bản";
                if (dgvKhoSach.Columns.Contains("NamXuatBan")) dgvKhoSach.Columns["NamXuatBan"].HeaderText = "Năm Xuất Bản";
                if (dgvKhoSach.Columns.Contains("SoLuong")) dgvKhoSach.Columns["SoLuong"].HeaderText = "Số Lượng";
                if (dgvKhoSach.Columns.Contains("NgayNhap"))
                {
                    dgvKhoSach.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                    dgvKhoSach.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (dgvKhoSach.Columns.Contains("GiaNhap"))
                {
                    dgvKhoSach.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgvKhoSach.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                }
                if (dgvKhoSach.Columns.Contains("ThanhTien"))
                {
                    dgvKhoSach.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                    dgvKhoSach.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
                if (dgvKhoSach.Columns.Contains("TrangThaiSach")) dgvKhoSach.Columns["TrangThaiSach"].HeaderText = "Trạng Thái Sách";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMaSachComboBox()
        {
            try
            {
                string query = "SELECT MaSach FROM ViewChiTietNhapKho";
                DataTable dt = dbConnect.ExecuteQuery(query);
                cbxMaSach.DataSource = dt;
                cbxMaSach.DisplayMember = "MaSach";
                cbxMaSach.ValueMember = "MaSach";
                cbxMaSach.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải mã sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetIdSFromMaSach(string maSach)
        {
            if (string.IsNullOrEmpty(maSach) || !maSach.StartsWith("S") || maSach.Length < 2)
            {
                return -1;
            }
            if (int.TryParse(maSach.Substring(1), out int idS))
            {
                return idS;
            }
            return -1;
        }

        private void btnCapNhatKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaSach.SelectedIndex == -1 || string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã sách và nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSach = cbxMaSach.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maSach))
                {
                    MessageBox.Show("Mã sách không hợp lệ từ ComboBox!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idS = GetIdSFromMaSach(maSach);
                if (idS == -1)
                {
                    MessageBox.Show($"Mã sách '{maSach}' không hợp lệ! Phải theo định dạng Sxxx (ví dụ: S001).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSoLuong.Text, out int soLuongThem))
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra số lượng hiện tại trong kho
                string query = "SELECT SoLuongHienTai FROM Kho_Sach WHERE MaSach = @IdS";
                DataTable dt = dbConnect.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@IdS", idS) });
                int soLuongHienTai = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoLuongHienTai"]) : 0;

                // Ngăn cập nhật nếu số lượng hiện tại là 0 và số lượng thêm vào là âm
                if (soLuongHienTai == 0 && soLuongThem < 0)
                {
                    MessageBox.Show("Kho hiện tại không có sách, không thể giảm số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ngăn cập nhật nếu số lượng sau khi thêm vào nhỏ hơn 0
                if (soLuongHienTai + soLuongThem < 0)
                {
                    MessageBox.Show("Số lượng sau khi cập nhật không thể nhỏ hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dbConnect.ExecuteNonQuery("sp_CapNhatKhoSach", new SqlParameter[]
                {
            new SqlParameter("@IdS", idS),
            new SqlParameter("@SoLuongThem", soLuongThem)
                }, CommandType.StoredProcedure);

                MessageBox.Show("Cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhoSach();
                txtSoLuong.Clear(); // Làm sạch trường txtSoLuong
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKiemTraKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaSach.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSach = cbxMaSach.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maSach))
                {
                    MessageBox.Show("Mã sách không hợp lệ từ ComboBox!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idS = GetIdSFromMaSach(maSach);
                if (idS == -1)
                {
                    MessageBox.Show($"Mã sách '{maSach}' không hợp lệ! Phải theo định dạng Sxxx (ví dụ: S001).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = dbConnect.ExecuteQuery("SELECT dbo.fn_KiemTraTrangThaiKhoSach(@p_IdS) AS TrangThai",
                    new SqlParameter[] { new SqlParameter("@p_IdS", idS) });
                if (dt.Rows.Count > 0)
                {
                    string trangThaiRaw = dt.Rows[0]["TrangThai"].ToString();
                    // Kiểm tra và phân tích chuỗi
                    if (trangThaiRaw.Contains("không tồn tại"))
                    {
                        MessageBox.Show(trangThaiRaw, "Thông tin trạng thái kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string[] parts = trangThaiRaw.Split(new[] { "Số lượng hiện tại = ", ", Trạng thái = " }, StringSplitOptions.None);
                        if (parts.Length == 3)
                        {
                            string soLuongHienTai = parts[1].Split(',')[0]; // Lấy số lượng
                            string trangThai = parts[2]; // Lấy trạng thái
                            string message = $"Mã Sách: {maSach}, Số Lượng Hiện Tại: {soLuongHienTai}, Trạng Thái: {trangThai}";
                            MessageBox.Show(message, "Thông tin trạng thái kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Định dạng dữ liệu không hợp lệ: {trangThaiRaw}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu", "Thông tin trạng thái kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadKhoSach();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            // Chỉ cho phép một dấu trừ ở đầu
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
