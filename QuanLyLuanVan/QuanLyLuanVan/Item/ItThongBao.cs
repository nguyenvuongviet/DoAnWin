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
    public partial class ItThongBao : Form
    {
        readonly GiangVienDao gvDao = new GiangVienDao();

        public ItThongBao()
        {
            InitializeComponent();
        }

        public ItThongBao(string nhom)
        {
            InitializeComponent();
            txtNhom.Text = nhom;
            dtpThoiDiemGui.Value = DateTime.Now;
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận gửi thông báo !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                TaiKhoan taiKhoan = Const.TaiKhoan;
                GiangVien giangvien = gvDao.ThongTin(taiKhoan.ID);
                ThongBao tb = new ThongBao(txtTieuDe.Text, txtNoiDung.Text, dtpThoiDiemGui.Value.ToString("dd/MM/yyyy"), giangvien.HoTen, txtNhom.Text);
                gvDao.ThongBao(tb);
                MessageBox.Show("Thông Báo Đã Được Gửi !");
                this.Close();
            }
        }


    }
}
