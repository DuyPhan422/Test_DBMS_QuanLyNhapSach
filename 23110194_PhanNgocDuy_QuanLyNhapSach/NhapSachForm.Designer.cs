namespace _23110194_PhanNgocDuy_QuanLyNhapSach
{
    partial class NhapSachForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNhapSach = new System.Windows.Forms.DataGridView();
            this.btnNhapSach = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.picUploadAnh = new System.Windows.Forms.PictureBox();
            this.grbNhapSach = new System.Windows.Forms.GroupBox();
            this.cbbTheLoai = new System.Windows.Forms.ComboBox();
            this.txtNhaXuatBan = new System.Windows.Forms.TextBox();
            this.btnUploadAnh = new System.Windows.Forms.Button();
            this.txtNamXuatBan = new System.Windows.Forms.TextBox();
            this.lbGiaNhap = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.lbNgayNhap = new System.Windows.Forms.Label();
            this.lbTheLoai = new System.Windows.Forms.Label();
            this.lbNamXuatBan = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lbNhaXuatBan = new System.Windows.Forms.Label();
            this.lbTacGia = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.lbMaNhanVien = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbBangNhapSach = new System.Windows.Forms.Label();
            this.btnXacNhanNhap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUploadAnh)).BeginInit();
            this.grbNhapSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNhapSach
            // 
            this.dgvNhapSach.AllowUserToAddRows = false;
            this.dgvNhapSach.AllowUserToDeleteRows = false;
            this.dgvNhapSach.AllowUserToResizeRows = false;
            this.dgvNhapSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhapSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhapSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhapSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhapSach.Location = new System.Drawing.Point(18, 509);
            this.dgvNhapSach.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNhapSach.Name = "dgvNhapSach";
            this.dgvNhapSach.ReadOnly = true;
            this.dgvNhapSach.RowHeadersVisible = false;
            this.dgvNhapSach.RowHeadersWidth = 51;
            this.dgvNhapSach.RowTemplate.Height = 24;
            this.dgvNhapSach.Size = new System.Drawing.Size(1638, 447);
            this.dgvNhapSach.TabIndex = 15;
            this.dgvNhapSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapSach_CellContentClick);
            // 
            // btnNhapSach
            // 
            this.btnNhapSach.Location = new System.Drawing.Point(50, 323);
            this.btnNhapSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhapSach.Name = "btnNhapSach";
            this.btnNhapSach.Size = new System.Drawing.Size(133, 48);
            this.btnNhapSach.TabIndex = 16;
            this.btnNhapSach.Text = "Nhập Sách";
            this.btnNhapSach.UseVisualStyleBackColor = true;
            this.btnNhapSach.Click += new System.EventHandler(this.btnNhapSach_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Location = new System.Drawing.Point(456, 323);
            this.btnXoaSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(121, 48);
            this.btnXoaSach.TabIndex = 17;
            this.btnXoaSach.Text = "Xóa Sách";
            this.btnXoaSach.UseVisualStyleBackColor = true;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(245, 323);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(137, 48);
            this.btnCapNhat.TabIndex = 18;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // picUploadAnh
            // 
            this.picUploadAnh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picUploadAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picUploadAnh.Location = new System.Drawing.Point(1098, 64);
            this.picUploadAnh.Margin = new System.Windows.Forms.Padding(2);
            this.picUploadAnh.Name = "picUploadAnh";
            this.picUploadAnh.Size = new System.Drawing.Size(313, 294);
            this.picUploadAnh.TabIndex = 20;
            this.picUploadAnh.TabStop = false;
            // 
            // grbNhapSach
            // 
            this.grbNhapSach.Controls.Add(this.btnXacNhanNhap);
            this.grbNhapSach.Controls.Add(this.cbbTheLoai);
            this.grbNhapSach.Controls.Add(this.txtNhaXuatBan);
            this.grbNhapSach.Controls.Add(this.btnXoaSach);
            this.grbNhapSach.Controls.Add(this.txtNamXuatBan);
            this.grbNhapSach.Controls.Add(this.btnNhapSach);
            this.grbNhapSach.Controls.Add(this.btnCapNhat);
            this.grbNhapSach.Controls.Add(this.lbGiaNhap);
            this.grbNhapSach.Controls.Add(this.lbSoLuong);
            this.grbNhapSach.Controls.Add(this.lbNgayNhap);
            this.grbNhapSach.Controls.Add(this.lbTheLoai);
            this.grbNhapSach.Controls.Add(this.lbNamXuatBan);
            this.grbNhapSach.Controls.Add(this.txtTacGia);
            this.grbNhapSach.Controls.Add(this.lbNhaXuatBan);
            this.grbNhapSach.Controls.Add(this.lbTacGia);
            this.grbNhapSach.Controls.Add(this.lbTenSach);
            this.grbNhapSach.Controls.Add(this.lbMaNhanVien);
            this.grbNhapSach.Controls.Add(this.txtGiaNhap);
            this.grbNhapSach.Controls.Add(this.dtpNgayNhap);
            this.grbNhapSach.Controls.Add(this.txtSoLuong);
            this.grbNhapSach.Controls.Add(this.txtTenSach);
            this.grbNhapSach.Controls.Add(this.txtMaNhanVien);
            this.grbNhapSach.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNhapSach.Location = new System.Drawing.Point(8, 49);
            this.grbNhapSach.Margin = new System.Windows.Forms.Padding(2);
            this.grbNhapSach.Name = "grbNhapSach";
            this.grbNhapSach.Padding = new System.Windows.Forms.Padding(2);
            this.grbNhapSach.Size = new System.Drawing.Size(961, 400);
            this.grbNhapSach.TabIndex = 26;
            this.grbNhapSach.TabStop = false;
            this.grbNhapSach.Text = "Nhập Sách Mới";
            // 
            // cbbTheLoai
            // 
            this.cbbTheLoai.FormattingEnabled = true;
            this.cbbTheLoai.Location = new System.Drawing.Point(672, 94);
            this.cbbTheLoai.Name = "cbbTheLoai";
            this.cbbTheLoai.Size = new System.Drawing.Size(224, 34);
            this.cbbTheLoai.TabIndex = 83;
            // 
            // txtNhaXuatBan
            // 
            this.txtNhaXuatBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaXuatBan.Location = new System.Drawing.Point(223, 208);
            this.txtNhaXuatBan.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtNhaXuatBan.Name = "txtNhaXuatBan";
            this.txtNhaXuatBan.Size = new System.Drawing.Size(222, 30);
            this.txtNhaXuatBan.TabIndex = 82;
            // 
            // btnUploadAnh
            // 
            this.btnUploadAnh.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadAnh.Location = new System.Drawing.Point(1203, 401);
            this.btnUploadAnh.Margin = new System.Windows.Forms.Padding(2);
            this.btnUploadAnh.Name = "btnUploadAnh";
            this.btnUploadAnh.Size = new System.Drawing.Size(151, 48);
            this.btnUploadAnh.TabIndex = 63;
            this.btnUploadAnh.Text = "Thêm Ảnh";
            this.btnUploadAnh.UseVisualStyleBackColor = true;
            this.btnUploadAnh.Click += new System.EventHandler(this.btnUploadAnh_Click);
            // 
            // txtNamXuatBan
            // 
            this.txtNamXuatBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamXuatBan.Location = new System.Drawing.Point(672, 49);
            this.txtNamXuatBan.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtNamXuatBan.Name = "txtNamXuatBan";
            this.txtNamXuatBan.Size = new System.Drawing.Size(222, 30);
            this.txtNamXuatBan.TabIndex = 77;
            // 
            // lbGiaNhap
            // 
            this.lbGiaNhap.AutoSize = true;
            this.lbGiaNhap.BackColor = System.Drawing.Color.Transparent;
            this.lbGiaNhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaNhap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbGiaNhap.Location = new System.Drawing.Point(257, 263);
            this.lbGiaNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGiaNhap.Name = "lbGiaNhap";
            this.lbGiaNhap.Size = new System.Drawing.Size(106, 26);
            this.lbGiaNhap.TabIndex = 76;
            this.lbGiaNhap.Text = "Giá Nhập:";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lbSoLuong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbSoLuong.Location = new System.Drawing.Point(502, 206);
            this.lbSoLuong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(102, 26);
            this.lbSoLuong.TabIndex = 75;
            this.lbSoLuong.Text = "Số lượng:";
            // 
            // lbNgayNhap
            // 
            this.lbNgayNhap.AutoSize = true;
            this.lbNgayNhap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgayNhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayNhap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbNgayNhap.Location = new System.Drawing.Point(502, 154);
            this.lbNgayNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNgayNhap.Name = "lbNgayNhap";
            this.lbNgayNhap.Size = new System.Drawing.Size(118, 26);
            this.lbNgayNhap.TabIndex = 74;
            this.lbNgayNhap.Text = "Ngày nhập:";
            // 
            // lbTheLoai
            // 
            this.lbTheLoai.AutoSize = true;
            this.lbTheLoai.BackColor = System.Drawing.Color.Transparent;
            this.lbTheLoai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTheLoai.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTheLoai.Location = new System.Drawing.Point(502, 101);
            this.lbTheLoai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTheLoai.Name = "lbTheLoai";
            this.lbTheLoai.Size = new System.Drawing.Size(94, 26);
            this.lbTheLoai.TabIndex = 73;
            this.lbTheLoai.Text = "Thể loại:";
            // 
            // lbNamXuatBan
            // 
            this.lbNamXuatBan.AutoSize = true;
            this.lbNamXuatBan.BackColor = System.Drawing.Color.Transparent;
            this.lbNamXuatBan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamXuatBan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbNamXuatBan.Location = new System.Drawing.Point(504, 48);
            this.lbNamXuatBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNamXuatBan.Name = "lbNamXuatBan";
            this.lbNamXuatBan.Size = new System.Drawing.Size(147, 26);
            this.lbNamXuatBan.TabIndex = 71;
            this.lbNamXuatBan.Text = "Năm xuất bản:";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTacGia.Location = new System.Drawing.Point(223, 150);
            this.txtTacGia.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(222, 30);
            this.txtTacGia.TabIndex = 70;
            // 
            // lbNhaXuatBan
            // 
            this.lbNhaXuatBan.AutoSize = true;
            this.lbNhaXuatBan.BackColor = System.Drawing.Color.Transparent;
            this.lbNhaXuatBan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhaXuatBan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbNhaXuatBan.Location = new System.Drawing.Point(22, 211);
            this.lbNhaXuatBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNhaXuatBan.Name = "lbNhaXuatBan";
            this.lbNhaXuatBan.Size = new System.Drawing.Size(141, 26);
            this.lbNhaXuatBan.TabIndex = 69;
            this.lbNhaXuatBan.Text = "Nhà xuất bản:";
            // 
            // lbTacGia
            // 
            this.lbTacGia.AutoSize = true;
            this.lbTacGia.BackColor = System.Drawing.Color.Transparent;
            this.lbTacGia.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTacGia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTacGia.Location = new System.Drawing.Point(22, 149);
            this.lbTacGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTacGia.Name = "lbTacGia";
            this.lbTacGia.Size = new System.Drawing.Size(85, 26);
            this.lbTacGia.TabIndex = 68;
            this.lbTacGia.Text = "Tác giả:";
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoSize = true;
            this.lbTenSach.BackColor = System.Drawing.Color.Transparent;
            this.lbTenSach.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTenSach.Location = new System.Drawing.Point(22, 97);
            this.lbTenSach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(101, 26);
            this.lbTenSach.TabIndex = 67;
            this.lbTenSach.Text = "Tên sách:";
            // 
            // lbMaNhanVien
            // 
            this.lbMaNhanVien.AutoSize = true;
            this.lbMaNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lbMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaNhanVien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbMaNhanVien.Location = new System.Drawing.Point(22, 48);
            this.lbMaNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaNhanVien.Name = "lbMaNhanVien";
            this.lbMaNhanVien.Size = new System.Drawing.Size(145, 26);
            this.lbMaNhanVien.TabIndex = 66;
            this.lbMaNhanVien.Text = "Mã nhân viên:";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNhap.Location = new System.Drawing.Point(423, 260);
            this.txtGiaNhap.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(222, 30);
            this.txtGiaNhap.TabIndex = 64;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(674, 147);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(222, 30);
            this.dtpNgayNhap.TabIndex = 61;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(674, 203);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(222, 30);
            this.txtSoLuong.TabIndex = 38;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(223, 98);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(222, 30);
            this.txtTenSach.TabIndex = 29;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhanVien.Location = new System.Drawing.Point(223, 45);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(222, 30);
            this.txtMaNhanVien.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Ivory;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(65, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1346, 35);
            this.label11.TabIndex = 61;
            this.label11.Text = "QUẢN LÝ NHẬP SÁCH UTE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBangNhapSach
            // 
            this.lbBangNhapSach.AutoSize = true;
            this.lbBangNhapSach.BackColor = System.Drawing.Color.Transparent;
            this.lbBangNhapSach.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBangNhapSach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbBangNhapSach.Location = new System.Drawing.Point(13, 470);
            this.lbBangNhapSach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBangNhapSach.Name = "lbBangNhapSach";
            this.lbBangNhapSach.Size = new System.Drawing.Size(178, 27);
            this.lbBangNhapSach.TabIndex = 66;
            this.lbBangNhapSach.Text = "Bảng Nhập Sách:";
            // 
            // btnXacNhanNhap
            // 
            this.btnXacNhanNhap.Location = new System.Drawing.Point(640, 323);
            this.btnXacNhanNhap.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacNhanNhap.Name = "btnXacNhanNhap";
            this.btnXacNhanNhap.Size = new System.Drawing.Size(177, 48);
            this.btnXacNhanNhap.TabIndex = 84;
            this.btnXacNhanNhap.Text = "Xác Nhận Nhập";
            this.btnXacNhanNhap.UseVisualStyleBackColor = true;
            this.btnXacNhanNhap.Click += new System.EventHandler(this.btnXacNhanNhap_Click);
            // 
            // NhapSachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1793, 999);
            this.Controls.Add(this.lbBangNhapSach);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnUploadAnh);
            this.Controls.Add(this.grbNhapSach);
            this.Controls.Add(this.picUploadAnh);
            this.Controls.Add(this.dgvNhapSach);
            this.Name = "NhapSachForm";
            this.Text = "NhapSachForm";
            this.Load += new System.EventHandler(this.NhapSachForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUploadAnh)).EndInit();
            this.grbNhapSach.ResumeLayout(false);
            this.grbNhapSach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvNhapSach;
        private System.Windows.Forms.Button btnNhapSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.PictureBox picUploadAnh;
        private System.Windows.Forms.GroupBox grbNhapSach;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Button btnUploadAnh;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label lbMaNhanVien;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbNhaXuatBan;
        private System.Windows.Forms.Label lbTacGia;
        private System.Windows.Forms.Label lbNamXuatBan;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lbGiaNhap;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label lbNgayNhap;
        private System.Windows.Forms.Label lbTheLoai;
        private System.Windows.Forms.Label lbBangNhapSach;
        private System.Windows.Forms.TextBox txtNamXuatBan;
        private System.Windows.Forms.TextBox txtNhaXuatBan;
        private System.Windows.Forms.ComboBox cbbTheLoai;
        private System.Windows.Forms.Button btnXacNhanNhap;
    }
}