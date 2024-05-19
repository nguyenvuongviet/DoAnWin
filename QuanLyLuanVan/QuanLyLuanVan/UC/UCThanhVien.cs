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
    public partial class UCThanhVien : UserControl
    {
        readonly string nhom;
        readonly SinhVien sv;
        readonly SinhVienDao svDao = new SinhVienDao();
        
        public UCThanhVien()
        {
            InitializeComponent();
        }

        public UCThanhVien(SinhVien sv)
        {
            InitializeComponent();
            lblHoTen.Text = sv.HoTen.ToString();
            lblID.Text = sv.ID.ToString();
            this.sv = sv;
        }

        public UCThanhVien(SinhVien sv, string nhom)
        {
            InitializeComponent();
            lblHoTen.Text = sv.HoTen.ToString();
            lblID.Text = sv.ID.ToString();
            this.sv = sv;
            this.nhom = nhom;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thêm bạn này vào nhóm không?",
    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                svDao.ThemNhom(sv, nhom);
            }
        }

        public event EventHandler CapNhat;
        private void btnXoaThanhVien_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa bạn này khỏi nhóm không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                svDao.XoaThanhVien(sv);
                CapNhat?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
