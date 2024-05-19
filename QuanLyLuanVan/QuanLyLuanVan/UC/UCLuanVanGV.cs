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
    public partial class UCLuanVanGV : UserControl
    {
        readonly LuanVan luanvan;
        public event EventHandler CapNhatUC;
        readonly GiangVienDao gvDao = new GiangVienDao();

        public UCLuanVanGV()
        {
            InitializeComponent();
        }

        public UCLuanVanGV(LuanVan lv)
        {
            InitializeComponent();
            this.luanvan = lv;
            lblTieuDe.Text = lv.TenLuanVan;
            lblMoTa.Text = lv.MoTa;
            lblTheLoai.Text = lv.TheLoai;
            lblNhom.Text = $"Nhóm: {lv.Nhom}";
            lblNhomm.Text = $"Nhóm: {lv.Nhom}";
            lblDiem.Visible = false;
            if (lv.Diem != "")
            {
                lblDiem.Visible = true;
                lblDiem.Text = $"Điểm: {lv.Diem}";
            }
            #region "Hiển thị trạng thái của luận văn"
            if (lv.TrangThai == "0")
            {
                grb_ChuaDangKy.Visible = true;
                grbDangChoDuyet.Visible = false;
                grbDaDangKy.Visible = false;
            }

            else if (lv.TrangThai == "1")
            {
                grb_ChuaDangKy.Visible = false;
                grbDangChoDuyet.Visible = true;
                grbDaDangKy.Visible = false;
            }

            else if (lv.TrangThai == "2")
            {
                grb_ChuaDangKy.Visible = false;
                grbDangChoDuyet.Visible = false;
                grbDaDangKy.Visible = true;
            }
            #endregion

        }
       
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            ItDangKy f = new ItDangKy(luanvan, luanvan.Nhom);
            f.ShowDialog();
        }

        private void btnXoaNhomDangKy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn không duyệt nhóm này không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                gvDao.KhongDuyetNhom(lblTieuDe.Text, lblNhom.Text);
                CapNhatUC?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn duyệt nhóm này không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                gvDao.DuyetNhom(lblTieuDe.Text);
                CapNhatUC?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler Xoa1LuanVan;
        private void btnXoaLuanVan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa luận văn này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                gvDao.XoaLuanVan(lblTieuDe.Text, luanvan.Nhom);

                // Xóa UserControl khỏi panel cha
                this.Parent.Controls.Remove(this);

                // Kích hoạt sự kiện Xoa1LuanVan để thông báo cho FQuanLyLuanVan
                Xoa1LuanVan?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnTienDoCuaNhom_Click(object sender, EventArgs e)
        {
            FQuanLyTask Task = new FQuanLyTask(luanvan.Nhom);
            Task.ShowDialog();
        }
        
        private void btnThongBaoChoNhom_Click(object sender, EventArgs e)
        {
            ItThongBao tb = new ItThongBao(luanvan.Nhom);
            tb.ShowDialog();
        }

        #region "Thêm chú thích cho từng nút"
        private void btnXoaLuanVan_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            // Đặt chú thích cho PictureBox
            toolTip.SetToolTip(btnXoaLuanVan, "Xóa luận văn");
        }

        private void btnThongBaoChoNhom_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            // Đặt chú thích cho PictureBox
            toolTip.SetToolTip(btnThongBaoChoNhom, "Thông báo");
        }

        private void btnTienDoCuaNhom_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            // Đặt chú thích cho PictureBox
            toolTip.SetToolTip(btnTienDoCuaNhom, "Tiến độ");
        }

        private void btnChiTiet_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            // Đặt chú thích cho PictureBox
            toolTip.SetToolTip(btnChiTiet, "Chi tiết");
        }

        private void btnDuyet_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            // Đặt chú thích cho PictureBox
            toolTip.SetToolTip(btnDuyet, "Duyệt");
        }

        private void btnXoaNhomDangKy_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            // Đặt chú thích cho PictureBox
            toolTip.SetToolTip(btnXoaNhomDangKy, "Không duyệt");
        }
        #endregion
    }
}
