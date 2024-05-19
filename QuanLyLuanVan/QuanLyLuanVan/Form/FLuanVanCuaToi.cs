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
    public partial class FLuanVanCuaToi : Form
    {
        readonly SinhVienDao svDao = new SinhVienDao();
        readonly TaiKhoan taiKhoan = Const.TaiKhoan;
        readonly LuanVan lv;

        public FLuanVanCuaToi()
        {
            InitializeComponent();

            SinhVien sinhVien = svDao.ThongTin(taiKhoan.ID);
            List<LuanVan> luanvans = svDao.LoadDSLuanVan(null, null);
            foreach (LuanVan lv in luanvans)
            {
                if (lv.Nhom == sinhVien.Nhom)
                {
                    this.lv = lv;
                    UCLuanVanSV ucLuanVan = new UCLuanVanSV(lv);
                    ucLuanVan.btnDangKy.Visible = false;
                    lblTieuDe.Text = lv.TenLuanVan;
                    lblMoTa.Text = lv.MoTa;
                    lblGiangVien.Text = lv.TenGiangVien;
                    lblTheLoai.Text = lv.TheLoai;
                    lblCongNghe.Text = lv.CongNghe;
                    lblChucNang.Text = lv.ChucNang;
                    lblYeuCau.Text = lv.YeuCau;
                    lblNhom.Text = lv.Nhom;
                    lblDiem.Visible = false;
                    if (lv.Diem != "")
                    {
                        lblDiem.Visible = true;
                        lblDiem.Text = $"Điểm: {lv.Diem}";
                    }

                    if (lv.TrangThai == "1")
                    {
                        lblTrangThai.Text = "Đang chờ duyệt!";
                        lblTrangThai.BackColor = Color.Yellow;
                    }

                    if (lv.TrangThai == "2")
                    {
                        lblTrangThai.Text = "Đã duyệt!";
                        btnHuyDangKy.Visible = false;
                        lblTrangThai.BackColor = Color.SpringGreen;
                    }

                    if (lv.TrangThai == "0")
                    {
                        lblTrangThai.Text = "Không được duyệt!";
                        lblTrangThai.ForeColor = Color.White;
                        btnHuyDangKy.Text = "Đăng ký lại";
                        lblTrangThai.BackColor = Color.Red;
                        btnHuyDangKy.Image = null;
                        btnHuyDangKy.HoverState.FillColor = Color.Blue;
                    }
                }
            }
            LoadThanhVienNhom();
        }

        public void LoadThanhVienNhom()
        {
            pn_Chua_TV.Controls.Clear();
            DBConnection db = new DBConnection();
            List<SinhVien> sv = db.DanhSachSinhVien();
            foreach (SinhVien j in sv)
            {
                if (j.Nhom == lblNhom.Text)
                {
                    UCThanhVien uc = new UCThanhVien(j);
                    uc.btnThem.Visible = false;
                    uc.btnXoaThanhVien.Visible = false;
                    pn_Chua_TV.Controls.Add(uc);
                }
            }
        }

        public event EventHandler HuyDangKy;
        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            string s = "Bạn có chắc chắn muốn hủy không?";
            if (btnHuyDangKy.Text == "Đăng ký lại")
            {
                s = "Xác nhận đăng ký lại";
            }

            DialogResult result = MessageBox.Show(s, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                svDao.HuyLuanVan(lv);
                HuyDangKy?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }


    }
}
