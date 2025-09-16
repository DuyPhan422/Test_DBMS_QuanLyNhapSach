using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23110194_PhanNgocDuy_QuanLyNhapSach
{
    public partial class TraCuuSachForm : Form
    {
        private DBConnect dbConnect;
        public TraCuuSachForm()
        {
            InitializeComponent();
            dbConnect = new DBConnect();

        }

        private void TraCuuSachForm_Load(object sender, EventArgs e)
        {
            cbbTraCuu.Items.AddRange(new string[] { "Sách", "Tác giả", "Thể loại", "Nhà xuất bản", "Lịch sử nhập kho" });
          
            cbbTraCuu.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvTraCuu.AutoGenerateColumns = true;
            dgvTraCuu.AllowUserToAddRows = false;
            dgvTraCuu.ReadOnly = true;


            dgvTraCuu.DefaultCellStyle.Font = new Font("Segoe UI", 10); 
            dgvTraCuu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); 
            dgvTraCuu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 
            dgvTraCuu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvTraCuu.BackgroundColor = Color.White; 
            dgvTraCuu.DefaultCellStyle.ForeColor = Color.Black; 
            dgvTraCuu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255); 
            dgvTraCuu.GridColor = Color.Gray; 
            dgvTraCuu.BorderStyle = BorderStyle.Fixed3D; 
            dgvTraCuu.EnableHeadersVisualStyles = true; 
            dgvTraCuu.RowHeadersVisible = false;

        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                // Xác định View dựa trên lựa chọn trong ComboBox
                switch (cbbTraCuu.SelectedItem?.ToString())
                {
                    case "Sách":
                        query = "SELECT * FROM ViewDanhSachSach";
                        break;
                    case "Tác giả":
                        query = "SELECT * FROM ViewDanhSachTacGia";
                        break;
                    case "Thể loại":
                        query = "SELECT * FROM ViewDanhSachTheLoai";
                        break;
                    case "Nhà xuất bản":
                        query = "SELECT * FROM ViewDanhSachNhaXuatBan";
                        break;
                    case "Lịch sử nhập kho":
                        query = "SELECT * FROM ViewLichSuNhapKho";
                        break;
                    default:
                        MessageBox.Show("Vui lòng chọn một mục để tra cứu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
                DataTable dt = dbConnect.ExecuteQuery(query);
                dgvTraCuu.DataSource = dt;

                // Định dạng cột cho ViewDanhSachSach
                if (cbbTraCuu.SelectedItem.ToString() == "Sách")
                {
                    if (dgvTraCuu.Columns.Contains("MaSach"))
                        dgvTraCuu.Columns["MaSach"].HeaderText = "Mã Sách";
                    if (dgvTraCuu.Columns.Contains("TenSach"))
                        dgvTraCuu.Columns["TenSach"].HeaderText = "Tên Sách";
                    if (dgvTraCuu.Columns.Contains("NamXuatBan"))
                        dgvTraCuu.Columns["NamXuatBan"].HeaderText = "Năm Xuất Bản";
                    if (dgvTraCuu.Columns.Contains("GiaSach"))
                    {
                        dgvTraCuu.Columns["GiaSach"].HeaderText = "Giá Sách";
                        dgvTraCuu.Columns["GiaSach"].DefaultCellStyle.Format = "N2";
                    }
                    if (dgvTraCuu.Columns.Contains("TenTacGia"))
                        dgvTraCuu.Columns["TenTacGia"].HeaderText = "Tác Giả";
                    if (dgvTraCuu.Columns.Contains("TenTheLoai"))
                        dgvTraCuu.Columns["TenTheLoai"].HeaderText = "Thể Loại";
                    if (dgvTraCuu.Columns.Contains("TenNXB"))
                        dgvTraCuu.Columns["TenNXB"].HeaderText = "Nhà Xuất Bản";
                    if (dgvTraCuu.Columns.Contains("SoLuongHienTai"))
                        dgvTraCuu.Columns["SoLuongHienTai"].HeaderText = "Số Lượng Hiện Tại";
                    if (dgvTraCuu.Columns.Contains("TrangThaiSach"))
                        dgvTraCuu.Columns["TrangThaiSach"].HeaderText = "Trạng Thái";
                    if (dgvTraCuu.Columns.Contains("AnhBia"))
                        dgvTraCuu.Columns["AnhBia"].Visible = false;
                }
                // Định dạng cột cho ViewLichSuNhapKho
                else if (cbbTraCuu.SelectedItem.ToString() == "Lịch sử nhập kho")
                {
                    if (dgvTraCuu.Columns.Contains("MaTheNhap"))
                        dgvTraCuu.Columns["MaTheNhap"].HeaderText = "Mã Thẻ Nhập";
                    if (dgvTraCuu.Columns.Contains("NgayNhap"))
                    {
                        dgvTraCuu.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                        dgvTraCuu.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                    if (dgvTraCuu.Columns.Contains("TrangThai"))
                        dgvTraCuu.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    if (dgvTraCuu.Columns.Contains("TenSach"))
                        dgvTraCuu.Columns["TenSach"].HeaderText = "Tên Sách";
                    if (dgvTraCuu.Columns.Contains("TenNhanVien"))
                        dgvTraCuu.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
                    if (dgvTraCuu.Columns.Contains("TongSoLuongNhap"))
                        dgvTraCuu.Columns["TongSoLuongNhap"].HeaderText = "Tổng Số Lượng Nhập";
                    if (dgvTraCuu.Columns.Contains("TongTienNhap"))
                    {
                        dgvTraCuu.Columns["TongTienNhap"].HeaderText = "Tổng Tiền Nhập";
                        dgvTraCuu.Columns["TongTienNhap"].DefaultCellStyle.Format = "N2";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

