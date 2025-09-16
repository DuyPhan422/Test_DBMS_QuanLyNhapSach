using _23110194_PhanNgocDuy_QuanLyNhapSach;
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
    public partial class ThuThuForm : Form
    {
        private readonly DBConnect db = new DBConnect();
        private Form currentFormChild;
        private int maTK; // Lưu MaTK
        private bool isAdmin; 

        public ThuThuForm(int maTK, bool isAdmin)
        {
            InitializeComponent();
            this.maTK = maTK;
            this.isAdmin = isAdmin;
            this.WindowState = FormWindowState.Maximized;
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel_Body.Controls.Clear();
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void ThuThuForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            string query = "SELECT CASE WHEN a.MaTK IS NOT NULL THEN a.HoTen ELSE nv.HoTen END AS HoTen " +
                           "FROM TaiKhoan tk " +
                           "LEFT JOIN [Admin] a ON tk.MaTK = a.MaTK " +
                           "LEFT JOIN NhanVien nv ON tk.MaTK = nv.MaTK " +
                           "WHERE tk.MaTK = @MaTK";
            SqlParameter[] paramsArr = new SqlParameter[] {
                new SqlParameter("@MaTK", SqlDbType.Int) { Value = maTK }
            };
            DataTable dt = db.ExecuteQuery(query, paramsArr);
            if (dt.Rows.Count > 0)
            {
                lbThongTinNhanVien.Text = "Chào " + dt.Rows[0]["HoTen"].ToString();
            }
            else
            {
                lbThongTinNhanVien.Text = "Chào Người dùng";
            }
        }

        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhapSachForm());
        }
        private void bntKhoSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhoSachForm());
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TraCuuSachForm());

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChuForm());
        }

        private void btnThongKeNhapSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeNhapSachForm());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm logIn_Form = new LoginForm();
            logIn_Form.Show();
        }

        private void lbThongTinNhanVien_Click(object sender, EventArgs e)
        {
           
        }
    }
}
