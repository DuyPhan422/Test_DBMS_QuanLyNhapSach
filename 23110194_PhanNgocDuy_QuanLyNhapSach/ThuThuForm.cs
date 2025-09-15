using _23110194_PhanNgocDuy_QuanLyNhapSach.Login;
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
    public partial class ThuThuForm : Form
    {
        private Form currentFormChild;
        public ThuThuForm()
        {
            InitializeComponent();
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
    }
}
