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
    public partial class ItThemLuanVan : Form
    {
        readonly GiangVienDao gvDao = new GiangVienDao();
        
        public ItThemLuanVan()
        {
            InitializeComponent();
            TaiKhoan taiKhoan = Const.TaiKhoan;
            GiangVien giangVien = gvDao.ThongTin(taiKhoan.ID);
            txtTenGiangVien.Text = giangVien.HoTen;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            LuanVan lv = new LuanVan(txtTenLuanVan.Text, txtTenGiangVien.Text, txtTheLoai.Text, txtMoTa.Text, txtSoLuongSinhVien.Text, txtCongNghe.Text, txtYeuCau.Text, txtChucNang.Text,"","","", "0");
            gvDao.ThemLuanVan(lv);
            MessageBox.Show("Thêm luận văn thành công!");
            this.Close();
        }
    }
}
