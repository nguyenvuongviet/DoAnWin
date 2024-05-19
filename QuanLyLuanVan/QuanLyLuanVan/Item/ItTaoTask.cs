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
    public partial class ItTaoTask : Form
    {
        readonly GiangVienDao gvDao = new GiangVienDao();

        public ItTaoTask()
        {
            InitializeComponent();
            tbTienDo.Minimum = 0;
            tbTienDo.Maximum = 100;
            tbTienDo.Value = 0;
        }

        public ItTaoTask(string nhom)
        {
            InitializeComponent();
            txtNhom.Text = nhom;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác Nhận Giao Task !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                TaiKhoan taiKhoan = Const.TaiKhoan;
                GiangVien giangVien = gvDao.ThongTin(taiKhoan.ID);
                Task t = new Task(txtTieuDe.Text, giangVien.HoTen, txtNhom.Text, txtNoiDung.Text, dtpNgayBatDau.Value.ToString("dd/MM/yyyy"), dtpNgayKetThuc.Value.ToString("dd/MM/yyyy"), tbTienDo.Value.ToString(), "Đang làm", "");
                gvDao.GiaoTask(t);
                MessageBox.Show("Task Đã Được Giao !");
                this.Close();
            }
        }

        private void tbTienDo_Scroll(object sender, ScrollEventArgs e)
        {
            int percent = tbTienDo.Value;
            label1.Text = percent.ToString() + "%";
        }

        private void dtpNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayKetThuc.Format = DateTimePickerFormat.Short;
        }
    }
}
