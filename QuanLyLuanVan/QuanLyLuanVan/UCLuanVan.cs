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
    public partial class UCLuanVan : UserControl
    {
        LuanVan lv;
        public UCLuanVan()
        {
            InitializeComponent();
        }

        public UCLuanVan(LuanVan lv)
        {
            InitializeComponent();
            this.lv = lv;
            lblTenLuanVan.Text = lv.TenLuanVan;
            lblTheLoai.Text = lv.TheLoai;
            lblMoTa.Text = lv.MoTa;
        }

        private void btnXoaLuanVan_Click(object sender, EventArgs e)
        {

        }

        private void UCLuanVan_Load(object sender, EventArgs e)
        {

        }
    }
}
