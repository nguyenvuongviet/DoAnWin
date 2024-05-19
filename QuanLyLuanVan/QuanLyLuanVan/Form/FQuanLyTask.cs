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
    public partial class FQuanLyTask : Form
    {
        readonly TaiKhoan taiKhoan = Const.TaiKhoan;
        readonly GiangVienDao gvDao = new GiangVienDao();
        readonly SinhVienDao svDao = new SinhVienDao();
        readonly string nhom;
        readonly string trangThai;

        public FQuanLyTask()
        {
            InitializeComponent();
        }

        public FQuanLyTask(string nhom, string trangThai)
        {
            InitializeComponent();
            this.nhom = nhom;
            this.trangThai = trangThai;
        }

        public FQuanLyTask(string nhom)
        {
            InitializeComponent();
            this.nhom = nhom;
        }

        private void btnTaoTask_Click(object sender, EventArgs e)
        {
            ItTaoTask f = new ItTaoTask(nhom);
            f.ShowDialog();
            FQuanLyTask_Load(sender, e);
        }

        private void FQuanLyTask_Load(object sender, EventArgs e)
        {
            pn_Chua.Controls.Clear();
            List<Task> task = new List<Task>();
            if (taiKhoan.ChucVu == "Giảng viên")
            {
                GiangVien giangvien = gvDao.ThongTin(taiKhoan.ID);
                task = gvDao.LoadDSTask(nhom, giangvien.HoTen.ToString());
            }
            else if (taiKhoan.ChucVu == "Sinh viên")
            {
                btnTaoTask.Visible = false;
                task = svDao.LoadDSTask(nhom, trangThai);
            }
            foreach (Task thesis in task)
            {
                UCTask uc = new UCTask(thesis);
                pn_Chua.Controls.Add(uc);
            }
        }


    }
}
