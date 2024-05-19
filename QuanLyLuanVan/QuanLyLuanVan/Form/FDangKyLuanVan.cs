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
    public partial class FDangKyLuanVan : Form
    {
        readonly SinhVienDao svDao = new SinhVienDao();
        readonly private string selectedItem;
        readonly private string loaiTimKiem;

        public FDangKyLuanVan()
        {
            InitializeComponent();
        }

        public FDangKyLuanVan(string selectedItem, string loaiTimKiem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            this.loaiTimKiem = loaiTimKiem;
        }

        public event EventHandler Xacnhan;
        private void FDangKyLuanVan_Load(object sender, EventArgs e)
        {
            pn_Chua.Controls.Clear();

            List<LuanVan> lv = svDao.LoadDSLuanVan(loaiTimKiem, selectedItem);
            foreach (LuanVan i in lv)
            {
                if (i.TrangThai == "0")
                {
                    UCLuanVanSV ucLuanVan = new UCLuanVanSV(i);
                    pn_Chua.Controls.Add(ucLuanVan);
                    ucLuanVan.xn += XacNhan;
                }
            }
        }

        private void XacNhan(object sender, EventArgs e)
        {
            Xacnhan?.Invoke(this, EventArgs.Empty);
        }

        private void btnDeXuat_Click(object sender, EventArgs e)
        {
            ItDangKy f = new ItDangKy();
            f.XacNhan += XacNhan;
            f.Show();
        }

    }
}
