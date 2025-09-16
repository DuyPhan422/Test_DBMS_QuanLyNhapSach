namespace _23110194_PhanNgocDuy_QuanLyNhapSach
{
    partial class KhoSachForm
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
            this.dgvKhoSach = new System.Windows.Forms.DataGridView();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnCapNhatKho = new System.Windows.Forms.Button();
            this.btnKiemTraKho = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.cbxMaSach = new System.Windows.Forms.ComboBox();
            this.lbSoLuongMoi = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhoSach
            // 
            this.dgvKhoSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoSach.Location = new System.Drawing.Point(46, 440);
            this.dgvKhoSach.Name = "dgvKhoSach";
            this.dgvKhoSach.RowHeadersVisible = false;
            this.dgvKhoSach.RowHeadersWidth = 51;
            this.dgvKhoSach.RowTemplate.Height = 24;
            this.dgvKhoSach.Size = new System.Drawing.Size(1387, 277);
            this.dgvKhoSach.TabIndex = 0;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(263, 114);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(194, 34);
            this.txtSoLuong.TabIndex = 4;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // btnCapNhatKho
            // 
            this.btnCapNhatKho.Location = new System.Drawing.Point(22, 181);
            this.btnCapNhatKho.Name = "btnCapNhatKho";
            this.btnCapNhatKho.Size = new System.Drawing.Size(134, 49);
            this.btnCapNhatKho.TabIndex = 5;
            this.btnCapNhatKho.Text = "Cập nhật kho";
            this.btnCapNhatKho.UseVisualStyleBackColor = true;
            this.btnCapNhatKho.Click += new System.EventHandler(this.btnCapNhatKho_Click);
            // 
            // btnKiemTraKho
            // 
            this.btnKiemTraKho.Location = new System.Drawing.Point(232, 181);
            this.btnKiemTraKho.Name = "btnKiemTraKho";
            this.btnKiemTraKho.Size = new System.Drawing.Size(134, 51);
            this.btnKiemTraKho.TabIndex = 6;
            this.btnKiemTraKho.Text = "Kiểm tra kho";
            this.btnKiemTraKho.UseVisualStyleBackColor = true;
            this.btnKiemTraKho.Click += new System.EventHandler(this.btnKiemTraKho_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(445, 181);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(134, 50);
            this.btnTaiLai.TabIndex = 7;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.BackColor = System.Drawing.Color.Transparent;
            this.lbMaSach.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbMaSach.Location = new System.Drawing.Point(17, 49);
            this.lbMaSach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(98, 26);
            this.lbMaSach.TabIndex = 68;
            this.lbMaSach.Text = "Mã Sách:";
            // 
            // cbxMaSach
            // 
            this.cbxMaSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaSach.FormattingEnabled = true;
            this.cbxMaSach.Location = new System.Drawing.Point(263, 46);
            this.cbxMaSach.Name = "cbxMaSach";
            this.cbxMaSach.Size = new System.Drawing.Size(194, 34);
            this.cbxMaSach.TabIndex = 69;
            // 
            // lbSoLuongMoi
            // 
            this.lbSoLuongMoi.AutoSize = true;
            this.lbSoLuongMoi.BackColor = System.Drawing.Color.Transparent;
            this.lbSoLuongMoi.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuongMoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbSoLuongMoi.Location = new System.Drawing.Point(17, 114);
            this.lbSoLuongMoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSoLuongMoi.Name = "lbSoLuongMoi";
            this.lbSoLuongMoi.Size = new System.Drawing.Size(203, 26);
            this.lbSoLuongMoi.TabIndex = 76;
            this.lbSoLuongMoi.Text = "Thay Đổi Số Lượng:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMaSach);
            this.groupBox1.Controls.Add(this.lbSoLuongMoi);
            this.groupBox1.Controls.Add(this.btnTaiLai);
            this.groupBox1.Controls.Add(this.cbxMaSach);
            this.groupBox1.Controls.Add(this.btnKiemTraKho);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.btnCapNhatKho);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(46, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 282);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Kho";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Ivory;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(41, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1346, 60);
            this.label11.TabIndex = 78;
            this.label11.Text = "QUẢN LÝ KHO SÁCH UTE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KhoSachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 729);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvKhoSach);
            this.Name = "KhoSachForm";
            this.Text = "KhoSachForm";
            this.Load += new System.EventHandler(this.KhoSachForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhoSach;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnCapNhatKho;
        private System.Windows.Forms.Button btnKiemTraKho;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.ComboBox cbxMaSach;
        private System.Windows.Forms.Label lbSoLuongMoi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
    }
}