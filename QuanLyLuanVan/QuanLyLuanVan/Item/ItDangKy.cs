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
    public partial class ItDangKy : Form
    {
        readonly DBConnection db = new DBConnection();
        readonly TaiKhoan taiKhoan = Const.TaiKhoan;
        readonly SinhVienDao svDao = new SinhVienDao();
        readonly LuanVan lv;

        //Đề xuất luận văn cho giảng viên
        public ItDangKy()
        {
            InitializeComponent();
            #region "Tắt lbl hiện thị luận văn"
            lblTenLuanVan.Visible = false;
            lblTenGiangVien.Visible = false;
            lblTheLoai.Visible = false;
            lblMoTa.Visible = false;
            lblCongNghe.Visible = false;
            lblYeuCau.Visible = false;
            lblChucNang.Visible = false;
            lblSoLuongSinhVien.Visible = false;
            btnDangKy.Visible = false;
            #endregion
            LoadGV();
            KiemTraNhom();
        }

        // Giảng viên khi xem luận văn chi tiết
        public ItDangKy(LuanVan lv, string nhom)
        {
            InitializeComponent();
            lblTenLuanVan.Text = lv.TenLuanVan;
            lblTenGiangVien.Text = lv.TenGiangVien;
            lblTheLoai.Text = lv.TheLoai;
            lblMoTa.Text = lv.MoTa;
            lblCongNghe.Text = lv.CongNghe;
            lblYeuCau.Text = lv.YeuCau;
            lblChucNang.Text = lv.ChucNang;
            lblSoLuongSinhVien.Text = lv.SlgThanhVien;

            #region "Tắt textbox để nhập"
            txtTenLuanVan.Visible = false;
            cbGiangVien.Visible = false;
            txtTheLoai.Visible = false;
            txtMoTa.Visible = false;
            txtCongNghe.Visible = false;
            txtYeuCau.Visible = false;
            txtChucNang.Visible = false;
            txtSoLuongTV.Visible = false;
            btnDeXuat.Visible = false;
            btnDangKy.Visible = false;
            btnThemThanhVien.Visible = false;
            #endregion

            if (nhom != "")
            {
                lblTrangThaiNhom.Text = "Nhóm đăng kí";
                txtNhom.Text = nhom;
                txtNhom.ReadOnly = true;
                btnDatTenNhom.Visible = false;
                LoadThanhVienNhom();
            }

            else
            {
                lblTrangThaiNhom.Text = "Chưa có nhóm đăng kí";
                txtNhom.Visible = false;
                lbl.Visible = false;
                btnDatTenNhom.Visible = false;
                pn_Chua.Visible = false;
            }
        }

        // Sinh viên đăng kí luận văn
        public ItDangKy(LuanVan lv)
        {
            InitializeComponent();
            this.lv = lv;
            lblTenLuanVan.Text = lv.TenLuanVan;
            lblTenGiangVien.Text = lv.TenGiangVien;
            lblTheLoai.Text = lv.TheLoai;
            lblMoTa.Text = lv.MoTa;
            lblCongNghe.Text = lv.CongNghe;
            lblYeuCau.Text = lv.YeuCau;
            lblChucNang.Text = lv.ChucNang;
            lblSoLuongSinhVien.Text = lv.SlgThanhVien;

            #region "Tắt textbox để nhập"
            txtTenLuanVan.Visible = false;
            cbGiangVien.Visible = false;
            txtTheLoai.Visible = false;
            txtMoTa.Visible = false;
            txtCongNghe.Visible = false;
            txtYeuCau.Visible = false;
            txtChucNang.Visible = false;
            txtSoLuongTV.Visible = false;
            btnDeXuat.Visible = false;
            #endregion
            KiemTraNhom();

        }

        public void LoadThanhVienNhom()
        {
            pn_Chua.Controls.Clear();
            List<SinhVien> sv = db.DanhSachSinhVien();
            foreach (SinhVien j in sv)
            {
                if (j.Nhom == txtNhom.Text)
                {
                    UCThanhVien uc = new UCThanhVien(j);
                    uc.btnThem.Visible = false;
                    pn_Chua.Controls.Add(uc);
                    uc.CapNhat += CapNhat;
                }
            }
        }

        public void KiemTraNhom()
        {
            pn_Chua.Controls.Clear();
            SinhVien sv = svDao.ThongTin(taiKhoan.ID);
            if (sv.Nhom != "")
            {
                txtNhom.Text = sv.Nhom;
                txtNhom.ReadOnly = true;
                btnDatTenNhom.Visible = false;
                LoadThanhVienNhom();
            }
            else if (sv.Nhom == "")
            {
                txtNhom.ReadOnly = false;
                btnDatTenNhom.Visible = true;
                UCThanhVien uc = new UCThanhVien(sv);
                uc.btnXoaThanhVien.Visible = false;
                uc.btnThem.Visible = false;
                pn_Chua.Controls.Add(uc);
            }
        }

        public void LoadGV()
        {
            List<string> tenGV = svDao.LoadGV();
            foreach (string tenGiangVien in tenGV)
            {
                cbGiangVien.Items.Add(tenGiangVien);
            }
        }

        public void CapNhat(object sender, EventArgs e)
        {
            LoadThanhVienNhom();
        }

        private void btnDatTenNhom_Click(object sender, EventArgs e)
        {
            if (txtNhom.Text != "")
            {
                SinhVien sinhVien = svDao.ThongTin(taiKhoan.ID);

                if (svDao.KiemTraTenNhom(txtNhom.Text))
                {
                    MessageBox.Show("Tên nhóm đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn tên nhóm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    svDao.ThemNhom(sinhVien, txtNhom.Text);
                    MessageBox.Show("Đặt tên nhóm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNhom.ReadOnly = true;
                    btnDatTenNhom.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên nhóm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public event EventHandler DangKy;
        private void btnThemThanhVien_Click(object sender, EventArgs e)
        {
            if (btnDatTenNhom.Visible == false)
            {
                ItThemThanhVien f = new ItThemThanhVien(txtNhom.Text);
                f.ShowDialog();
                LoadThanhVienNhom();
                DangKy?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Vui lòng đặt tên nhóm");
            }
        }

        public event EventHandler XacNhan;

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng kí không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                svDao.DangKy(lv, txtNhom.Text);
                XacNhan?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        private void btnDeXuat_Click(object sender, EventArgs e)
        {
            LuanVan lv = new LuanVan(txtTenLuanVan.Text, cbGiangVien.Text, txtTheLoai.Text, txtMoTa.Text, txtSoLuongTV.Text, txtCongNghe.Text, txtYeuCau.Text, txtChucNang.Text, "", "", "", "1");
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đề xuất không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                svDao.DeXuat(lv, txtNhom.Text);
                XacNhan?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
