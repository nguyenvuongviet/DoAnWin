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
    public partial class UCLuanVanSV : UserControl
    {
        readonly LuanVan lv;
       
        public UCLuanVanSV()
        {
            InitializeComponent();
        }

        public UCLuanVanSV(LuanVan lv)
        {
            InitializeComponent();
            lblTieuDe.Text = lv.TenLuanVan;
            lblGiangVien.Text = lv.TenGiangVien;
            lblMoTa.Text = lv.MoTa;
            lblTheLoai.Text = lv.TheLoai;
            this.lv = lv;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            ItDangKy f = new ItDangKy(lv);
            f.XacNhan += XacNhan;
            f.Show();
        }

        public event EventHandler xn;
        private void XacNhan(object sender, EventArgs e)
        {
            xn?.Invoke(this, EventArgs.Empty);
        }
        
        #region "Thêm chú thích cho từng nút"
        private void btnDangKy_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            // Đặt chú thích cho PictureBox
            toolTip.SetToolTip(btnDangKy, "Đăng ký luận văn");
        }
 
        #endregion


    }
}
