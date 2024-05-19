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
    public partial class FThongBao : Form
    {
        readonly GiangVienDao gvDao = new GiangVienDao();
        readonly SinhVienDao svDao = new SinhVienDao();

        public FThongBao()
        {
            InitializeComponent();
            LoadDanhSach();

        }

        public void ThongBao(string noiDung)
        {
            InitializeComponent();
            lblNoiDung.Text = noiDung;
        }

        private void MyUserControl_ThongBao(object sender, string s)
        {
            lblNoiDung.Text = s;
        }

        private void LoadDanhSach()
        {
            TaiKhoan taiKhoan = Const.TaiKhoan;
            pn_Chua.Controls.Clear();
            List<ThongBao> tb = new List<ThongBao>();
            if (taiKhoan.ChucVu == "Giảng viên")
            {
                GiangVien giangvien = gvDao.ThongTin(taiKhoan.ID);
                tb = gvDao.LoadDSThongBao(giangvien.HoTen);
            }
            else if (taiKhoan.ChucVu == "Sinh viên")
            {
                SinhVien sinhVien = svDao.ThongTin(taiKhoan.ID);
                tb = svDao.LoadDSThongBao(sinhVien.Nhom);
            }
            foreach (ThongBao j in tb)
            {
                UCThongBao ucThongBao = new UCThongBao(j);
                pn_Chua.Controls.Add(ucThongBao);
                ucThongBao.ThongBao += MyUserControl_ThongBao;
            }
        }
    
    }
}
