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
    public partial class FThongTinGV : Form
    {
        readonly GiangVienDao gvDao = new GiangVienDao();
        public FThongTinGV()
        {
            InitializeComponent();
        }

        public void ThongTin(GiangVien giangVien)
        {
            txtID.Text = giangVien.ID;
            txtHoTen.Text = giangVien.HoTen;
            txtChucVu.Text = giangVien.ChucVu;
            txtKhoa.Text = giangVien.Khoa;
            cbGioiTinh.SelectedItem = giangVien.GioiTinh;
            txtCCCD.Text = giangVien.Cccd;
            txtEmail.Text = giangVien.Email;
            txtDiaChi.Text = giangVien.DiaChi;
            DateTime ngaySinh = DateTime.ParseExact(giangVien.NgaySinh, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            dtpNgaySinh.Value = ngaySinh;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            GiangVien gv = Const.GiangVien;
            gv.HoTen = txtHoTen.Text;
            gv.Khoa = txtKhoa.Text;
            gv.GioiTinh = cbGioiTinh.SelectedItem.ToString();
            gv.Cccd = txtCCCD.Text;
            gv.Email = txtEmail.Text;
            gv.DiaChi = txtDiaChi.Text;
            gv.NgaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");

            gvDao.CapNhatThongTin(gv);
            MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
