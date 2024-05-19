using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace QuanLyLuanVan
{
    public partial class FQuanLyLuanVan : Form
    {
        readonly GiangVienDao gvDao = new GiangVienDao();
        readonly private string trangThai;

        public FQuanLyLuanVan()
        {
            InitializeComponent();
        }

        public FQuanLyLuanVan(string trangThai)
        {
            InitializeComponent();
            this.trangThai = trangThai;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ItThemLuanVan f = new ItThemLuanVan();
            f.ShowDialog();
            FQuanLyLuanVan_Load(sender, e);
        }

        private void FQuanLyLuanVan_Load(object sender, EventArgs e)
        {
            pn_Chua.Controls.Clear();
            List<LuanVan> lv = gvDao.LoadDSLuanVan(trangThai);
            foreach (LuanVan j in lv)
            {
                TaiKhoan taiKhoan = Const.TaiKhoan;
                GiangVien giangVien = gvDao.ThongTin(taiKhoan.ID);
                if (j.TenGiangVien == giangVien.HoTen)
                {
                    UCLuanVanGV uc = new UCLuanVanGV(j);
                    pn_Chua.Controls.Add(uc);
                    uc.Xoa1LuanVan += CapNhat;
                    uc.CapNhatUC += CapNhat;
                }
            }
        }

        private void CapNhat(object sender, EventArgs e)
        {
            FQuanLyLuanVan_Load(sender, e);
        }
    
    }
}

