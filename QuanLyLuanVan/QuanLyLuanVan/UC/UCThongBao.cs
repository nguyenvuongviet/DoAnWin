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
    public partial class UCThongBao : UserControl
    {
        public event EventHandler<string> ThongBao;
        readonly GiangVienDao gvDao = new GiangVienDao();
        readonly ThongBao t;

        public UCThongBao()
        {
            InitializeComponent();
        }

        public UCThongBao(ThongBao tb)
        {
            this.t = tb;
            InitializeComponent();
            lblTieuDe.Text = tb.TieuDe;
            lblNhom.Text = tb.Nhom;
            lblNgayGui.Text = tb.NgayGui.ToString();
            lblNguoiGui.Text = tb.GiangVien;
        }

        private void btnXemNoiDung_Click(object sender, EventArgs e)
        {
            ThongBao?.Invoke(this, t.NoiDung);
        }

        private void UCThongBao_Load_1(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = Const.TaiKhoan;
            if (taiKhoan.ChucVu == "Sinh viên")
            {
                lblNhom.Visible = false;
                lblNhomm.Visible = false;
                btnXoaThongBao.Visible = false;
            }
        }

        private void btnXoaThongBao_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông báo này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                gvDao.XoaTb(lblTieuDe.Text, t.Nhom);

                // Xóa UserControl khỏi panel cha
                this.Parent.Controls.Remove(this);
            }
        }


    }
}
