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
    public partial class FThongTinSV : Form
    {
        readonly SinhVienDao svDao = new SinhVienDao();
        public FThongTinSV()
        {
            InitializeComponent();
        }

        public void ThongTin(SinhVien sinhVien)
        {
            txtID.Text = sinhVien.ID;
            txtHoTen.Text = sinhVien.HoTen;
            txtChucVu.Text = sinhVien.ChucVu;
            txtKhoa.Text = sinhVien.Khoa;
            cbGioiTinh.SelectedItem = sinhVien.GioiTinh;
            txtCCCD.Text = sinhVien.Cccd;
            txtEmail.Text = sinhVien.Email;
            txtDiaChi.Text = sinhVien.DiaChi;
            DateTime ngaySinh = DateTime.ParseExact(sinhVien.NgaySinh, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            dtpNgaySinh.Value = ngaySinh;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = Const.SinhVien;
            sv.HoTen = txtHoTen.Text;
            sv.Khoa = txtKhoa.Text;
            sv.GioiTinh = cbGioiTinh.SelectedItem.ToString();
            sv.Cccd = txtCCCD.Text;
            sv.Email = txtEmail.Text;
            sv.DiaChi = txtDiaChi.Text;
            sv.NgaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");

            svDao.CapNhatThongTin(sv);
            MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    }
}
