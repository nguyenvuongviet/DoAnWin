using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanVan
{
    public partial class ItChat : Form
    {
        readonly DBConnection db = new DBConnection();
        readonly GiangVienDao gvDao = new GiangVienDao();
        readonly  SinhVienDao svDao = new SinhVienDao();
        readonly TaiKhoan taiKhoan = Const.TaiKhoan;

        public ItChat(string tieude, string nhom)
        {
            InitializeComponent();
            this.Load += ChatForm_Load; 
            lbltask.Text = tieude;
            lblnhom.Text = nhom;
        }
        
        private void ChatForm_Load(object sender, EventArgs e)
        {
            if (pn_Chua.Controls.Count > 0)
            {
                pn_Chua.ScrollControlIntoView(pn_Chua.Controls[pn_Chua.Controls.Count - 1]);
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            string noiDung = txtNoiDung.Text;
            Image image = null; 
            Mess tinNhan = null;
            if (taiKhoan.ChucVu == "Giảng viên")
            {
                GiangVien giangvien = gvDao.ThongTin(taiKhoan.ID);
                tinNhan = new Mess(lbltask.Text, giangvien.HoTen, lblnhom.Text, DateTime.Now.ToString(), noiDung, image, "1");
            }
            else if (taiKhoan.ChucVu == "Sinh viên")
            {
                SinhVien sinhvien = svDao.ThongTin(taiKhoan.ID);
                tinNhan = new Mess(lbltask.Text, sinhvien.HoTen, lblnhom.Text, DateTime.Now.ToString(), noiDung, image, "0");
            }
            if (!string.IsNullOrEmpty(noiDung))
            {
                db.ThemTinNhan(tinNhan);
            }
            UCChat uc1 = new UCChat(tinNhan);
            pn_Chua.Controls.Add(uc1);
            pn_Chua.ScrollControlIntoView(uc1);
            txtNoiDung.Clear();
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            string noiDung = "";
            Image image = null;
            Mess tinNhan = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string selectedImagePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(selectedImagePath);
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }
            }
           
            if (taiKhoan.ChucVu == "Giảng viên")
            {
                GiangVien giangvien = gvDao.ThongTin(taiKhoan.ID);
                tinNhan = new Mess(lbltask.Text, giangvien.HoTen, lblnhom.Text, DateTime.Now.ToString(), noiDung, image, "1");            }
            else if (taiKhoan.ChucVu == "Sinh viên")
            {
                SinhVien sinhvien = svDao.ThongTin(taiKhoan.ID);
                tinNhan = new Mess(lbltask.Text, sinhvien.HoTen, lblnhom.Text, DateTime.Now.ToString(), noiDung, image, "0");
            }
            db.ThemTinNhan(tinNhan);
            UCChat uc1 = new UCChat(tinNhan);
            pn_Chua.Controls.Add(uc1);
            pn_Chua.ScrollControlIntoView(uc1);
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            pn_Chua.Controls.Clear();
            List<Mess> mess = db.DanhSachChat(lbltask.Text, lblnhom.Text);
            foreach (Mess j in mess)
            {
                UCChat uc = new UCChat(j);
                pn_Chua.Controls.Add(uc);
            }
            if (taiKhoan.ChucVu == "Giảng viên")
            {
                gvDao.DaXem(lbltask.Text, lblnhom.Text);
            }
            else if (taiKhoan.ChucVu == "Sinh viên")
            {
                svDao.DaXem(lbltask.Text, lblnhom.Text);
            }
        }

    }
}
