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
    public partial class FMain : Form
    {
        readonly TaiKhoan taiKhoan = Const.TaiKhoan;
        readonly GiangVienDao gvDao = new GiangVienDao();
        readonly SinhVienDao svDao = new SinhVienDao();
        private Form currentForm;

        public FMain()
        {
            InitializeComponent();
        }

        void PhanQuyen()
        {
            if (taiKhoan.ChucVu == "Giảng viên")
            {
                btnDangKyLuanVan.Visible = false;
                btnQuanLyTask.Visible = false;
                btnLuanVanCuaToi.Visible = false;
            }
            else if (taiKhoan.ChucVu == "Sinh viên")
            {
                btnQuanLyLuanVan.Visible = false;
                btnThongKeKetQua.Visible = false;
            }
        }
        
        private void FMain_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            btnThongTinCaNhan_Click(sender, e);
            guna2ShadowForm1.SetShadowForm(this);
        }

        public void container(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = form;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            pn_Container.Controls.Add(currentForm);
            currentForm.Show();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (currentForm is FQuanLyLuanVan)
            {
                List<string> items = svDao.LoadTheLoai(); if (items != null)
                {
                    ComboBoxItems(items);
                }
                string trangThai = rb1.Checked ? "0" : (rb2.Checked ? "1" : (rb3.Checked ? "2" : ""));
                container(new FQuanLyLuanVan(trangThai));
            }
            else if (currentForm is FDangKyLuanVan)
            {
                List<string> items = null;
                if (rb1.Checked)
                {
                    items = svDao.LoadGV();
                }
                else if (rb2.Checked)
                {
                    items = svDao.LoadTheLoai();
                }
                if (items != null)
                {
                    ComboBoxItems(items);
                }
            }
            else if (currentForm is FQuanLyTask)
            {
                SinhVien sinhVien = svDao.ThongTin(taiKhoan.ID);
                string nhom = sinhVien.Nhom;
                string trangThai = rb1.Checked ? "Đang làm" : (rb2.Checked ? "Hoàn thành" : (rb3.Checked ? "Quá hạn" : ""));
                container(new FQuanLyTask(nhom, trangThai));
            }
        }

        private void ComboBoxItems(List<string> items)
        {
            HashSet<string> uniqueItems = new HashSet<string>(items);
            cbTimKiem.Items.Clear();
            foreach (string item in uniqueItems)
            {
                cbTimKiem.Items.Add(item);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string selectedItem = cbTimKiem.SelectedItem?.ToString();
            string loaiTimKiem = rb1.Checked ? "GiangVien" : "TheLoai";
            container(new FDangKyLuanVan(selectedItem, loaiTimKiem));
        }

        private void btnQuanLyLuanVan_Click(object sender, EventArgs e)
        {
            lblVal.Text = "Quản lý luận văn";
            picVal.Image = Properties.Resources.idea;
            cbTimKiem.Visible = false;
            btnTimKiem.Visible = false;

            rb2.Visible = true;
            rb1.Visible = true;
            rb3.Visible = true;
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb1.Text = "Chưa đăng ký";
            rb2.Text = "Đang chờ duyệt";
            rb3.Text = "Đã đăng ký";
            rb1.CheckedChanged += RadioButton_CheckedChanged;
            rb2.CheckedChanged += RadioButton_CheckedChanged;
            rb3.CheckedChanged += RadioButton_CheckedChanged;
            container(new FQuanLyLuanVan());
        }

        private void btnDangKyLuanVan_Click(object sender, EventArgs e)
        {
            bool result = kiemTraTrangThaiCuaToi();
            if (result)
            {
                lblVal.Text = "Đăng ký luận văn";
                picVal.Image = Properties.Resources.edit;

                cbTimKiem.Items.Clear();
                cbTimKiem.Visible = true;
                btnTimKiem.Visible = true;

                rb1.Visible = true;
                rb2.Visible = true;
                rb3.Visible = false;
                rb1.Checked = false;
                rb2.Checked = false;
                rb1.Text = "Giảng viên";
                rb2.Text = "Thể loại";
                rb1.CheckedChanged += RadioButton_CheckedChanged;
                rb2.CheckedChanged += RadioButton_CheckedChanged;
                FDangKyLuanVan f = new FDangKyLuanVan(null, null);
                container(f);
                f.Xacnhan += btnLuanVanCuaToi_Click;
                
            }
            else if (!result)
            {
                MessageBox.Show("Đã đăng ký luận văn");
            }
        }

        private void btnQuanLyTask_Click(object sender, EventArgs e)
        {
            lblVal.Text = "Quản lý task";
            picVal.Image = Properties.Resources.task;
            cbTimKiem.Visible = false;
            btnTimKiem.Visible = false;
            rb1.Visible = true;
            rb2.Visible = true;
            rb3.Visible = true;
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb1.Text = "Đang làm";
            rb2.Text = "Hoàn thành";
            rb3.Text = "Quá hạn";
            rb1.CheckedChanged += RadioButton_CheckedChanged;
            rb2.CheckedChanged += RadioButton_CheckedChanged;
            rb3.CheckedChanged += RadioButton_CheckedChanged;
            SinhVien sinhVien = svDao.ThongTin(taiKhoan.ID);
            string nhom = sinhVien.Nhom;
            container(new FQuanLyTask(nhom));
        }

        private void btnThongKeKetQua_Click(object sender, EventArgs e)
        {
            lblVal.Text = "Thống kê kết quả";
            picVal.Image = Properties.Resources.graph_bar1;
            container(new FThongKeKetQua());
            cbTimKiem.Visible = false;
            btnTimKiem.Visible = false;
            rb2.Visible = false;
            rb1.Visible = false;
            rb3.Visible = false;

        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            lblVal.Text = "Thông báo";
            picVal.Image = Properties.Resources.bell_ring;
            container(new FThongBao());
            cbTimKiem.Visible = false;
            btnTimKiem.Visible = false;
            rb1.Visible = false;
            rb2.Visible = false;
            rb3.Visible = false;
        }

        public void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            lblVal.Text = "Thông tin cá nhân";
            picVal.Image = Properties.Resources.user;
            cbTimKiem.Visible = false;
            btnTimKiem.Visible = false;
            rb2.Visible = false;
            rb1.Visible = false;
            rb3.Visible = false;

            if (taiKhoan.ChucVu == "Sinh viên")
            {
                FThongTinSV fThongTin = new FThongTinSV();
                SinhVien sinhVien = svDao.ThongTin(taiKhoan.ID);
                if (sinhVien != null)
                {
                    fThongTin.ThongTin(sinhVien);
                }
                container(fThongTin);
            }
            else if (taiKhoan.ChucVu == "Giảng viên")
            {
                FThongTinGV fThongTin = new FThongTinGV();
                GiangVien giangVien = gvDao.ThongTin(taiKhoan.ID);
                if (giangVien != null)
                {
                    fThongTin.ThongTin(giangVien);
                }
                container(fThongTin);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FDangNhap f = new FDangNhap();
            f.Show();
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLuanVanCuaToi_Click(object sender, EventArgs e)
        {
            bool result = kiemTraTrangThaiCuaToi();
            if (result)
            {
                MessageBox.Show("Chưa đăng ký luận văn");
            }
            else if (!result)
            {
                lblVal.Text = "Luận văn của tôi";
                picVal.Image = Properties.Resources.job;
                FLuanVanCuaToi a = new FLuanVanCuaToi();
                container(a);
                a.HuyDangKy += btnDangKyLuanVan_Click;
                cbTimKiem.Visible = false;
                btnTimKiem.Visible = false;
                rb1.Visible = false;
                rb2.Visible = false;
                rb3.Visible = false;
            }
        }

        private bool kiemTraTrangThaiCuaToi()
        {
            bool result = true;
            SinhVien sinhVien = svDao.ThongTin(taiKhoan.ID);
            List<LuanVan> lv = svDao.LoadDSLuanVan(null, null);
            foreach (LuanVan i in lv)
            {
                if (i.Nhom != "" && i.Nhom == sinhVien.Nhom)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
