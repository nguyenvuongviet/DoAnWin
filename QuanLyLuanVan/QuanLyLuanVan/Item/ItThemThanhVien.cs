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
    public partial class ItThemThanhVien : Form
    {
        readonly DBConnection db = new DBConnection();
        readonly string nhom;
        
        public ItThemThanhVien(string nhom)
        {
            InitializeComponent();
            this.nhom = nhom;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pn_Chua.Controls.Clear();
            List<SinhVien> sv = db.DanhSachSinhVien();
            foreach (SinhVien j in sv)
            {
                if (j.ID == txtTimKiem.Text && j.Nhom == "")
                {
                    UCThanhVien uc = new UCThanhVien(j, nhom);
                    uc.btnXoaThanhVien.Visible = false;
                    pn_Chua.Controls.Add(uc);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }
    

    }
}
