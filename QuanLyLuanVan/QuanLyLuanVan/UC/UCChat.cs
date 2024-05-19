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
    public partial class UCChat : UserControl
    {
        readonly Mess s;

        public UCChat(Mess t)
        {
            InitializeComponent();
            this.s = t;
            if (!string.IsNullOrEmpty(t.Noidung))
            {
                ThemVanBan();
            }
            else if (t.Anh != null)
            {
                ThemAnh();
            }
        }

        public void ThemVanBan()
        {
            lblNguoigui.Text = s.Nguoigui;
            lblNoiDung.Text = s.Noidung;
            ptbHienThiAnh.Visible = false;
            lblNoiDung.Visible = true;
        }

        public void ThemAnh()
        {
            lblNguoigui.Text = s.Nguoigui;
            ptbHienThiAnh.Image = s.Anh;
            lblNoiDung.Visible = false;
            ptbHienThiAnh.Visible = true;
        }

        private void ptbHienThiAnh_Click(object sender, EventArgs e)
        {
            ItAnh x = new ItAnh(ptbHienThiAnh.Image);
            x.ShowDialog();
        }

    }
}
