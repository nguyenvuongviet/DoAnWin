using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanVan
{
    public partial class FDangNhap : Form
    {
        readonly DBConnection db = new DBConnection();
        public FDangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Const.TaiKhoan.ID = txtTaiKhoan.Text;
            Const.TaiKhoan.MatKhau = txtMatKhau.Text;
            Const.TaiKhoan.ChucVu = rbSinhVien.Checked ? "Sinh viên" : (rbGiangVien.Checked ? "Giảng viên" : "");

            if (Const.TaiKhoan.ID == "" || Const.TaiKhoan.MatKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(Const.TaiKhoan.ChucVu))
            {
                MessageBox.Show("Vui lòng chọn loại người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (db.CheckDangNhap(Const.TaiKhoan.ID, Const.TaiKhoan.MatKhau, Const.TaiKhoan.ChucVu))
            {
                FMain f = new FMain();
                f.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
            }
        }

        private void pc_TaiKhoan_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void pc_HienMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                txtMatKhau.PasswordChar = '•';
                pc_HienMatKhau.Image = Properties.Resources.show1;
            }
            else
            {
                txtMatKhau.PasswordChar = '\0';
                pc_HienMatKhau.Image = Properties.Resources.hide;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    
    }
}
