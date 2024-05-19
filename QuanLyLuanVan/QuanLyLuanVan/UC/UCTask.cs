using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyLuanVan
{
    public partial class UCTask : UserControl
    {
        readonly DBConnection db = new DBConnection();
        readonly GiangVienDao gvDao = new GiangVienDao();
        readonly SinhVienDao svDao = new SinhVienDao();
        readonly Task t;

        public UCTask()
        {
            InitializeComponent();
        }

        public UCTask(Task task)
        {
            InitializeComponent();
            this.t = task;
            lblTieuDe.Text = task.Tieude;
            lblNoiDung.Text = task.Noidung;
            lblNgayBatDau.Text = task.Ngaybatdau;
            lblNgayKetThuc.Text = task.Ngayketthuc;
            lblGiangVien.Text = task.Tengiangvien;
            lblTienDo.Text = task.Tiendo + "%";
            lblChamDiem.Text = task.Diem;
            if (int.TryParse(task.Tiendo, out int trackBarValue))
            {
                // Nếu có thể chuyển đổi, cập nhật giá trị của TrackBar
                tbTienDo.Value = trackBarValue;
            }
        }

        private void tbTienDo_Scroll(object sender, ScrollEventArgs e)
        {
            int percent = tbTienDo.Value;
            lblTienDo.Text = percent.ToString() + "%";
        }

        void PhanQuyen()
        {
            tbTienDo.Visible = false;
            btnCapNhat.Visible = false;
            btnSua.Visible = true;
            lblDiem.Visible = false;
            lblChamDiem.Visible = false;
            btnChamDiem.Visible = false;
            txtChamDiem.Visible = false;
            HienThiDiem();
            CapNhatTrangThai();
        }
        
        private void UCTask_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            timer1_Tick(this, new EventArgs());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DateTime ngayKetThuc = DateTime.ParseExact(lblNgayKetThuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime ngayHienTai = DateTime.Now;

            if (ngayHienTai > ngayKetThuc)
            {
                MessageBox.Show("Task đã quá hạn. Không thể sửa đổi tiến độ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tbTienDo.Visible = true;
                btnCapNhat.Visible = true;
                btnSua.Visible = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác Nhận Cập Nhật Tiến Độ !",
        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string tienDo = tbTienDo.Value.ToString();
                string tieuDe = lblTieuDe.Text;

                //DateTime ngayKetThuc = DateTime.ParseExact(lblNgayKetThuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime ngayHienTai = DateTime.Now;

                //int tienDoInt = int.Parse(tienDo);

                //string trangThai = "";
                //if (ngayHienTai <= ngayKetThuc && tienDoInt < 100)
                //{
                //    trangThai = "Đang làm";
                //}
                //else if (ngayHienTai > ngayKetThuc && tienDoInt < 100)
                //{
                //    trangThai = "Quá hạn";
                //}
                //else if (tienDoInt == 100)
                //{
                //    trangThai = "Hoàn thành";
                //}
                svDao.CapNhatTienDo(tienDo, tieuDe, t.Nhom);

                tbTienDo.Visible = false;
                btnCapNhat.Visible = false;
                btnSua.Visible = true;
                MessageBox.Show("Cập Nhật Thành Công !");
            }
        }

        void CapNhatTrangThai()
        {
            string tienDo = tbTienDo.Value.ToString();
            string tieuDe = lblTieuDe.Text;

            DateTime ngayKetThuc = DateTime.ParseExact(lblNgayKetThuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime ngayHienTai = DateTime.Now;

            int tienDoInt = int.Parse(tienDo);

            string trangThai = "";
            if (ngayHienTai <= ngayKetThuc && tienDoInt < 100)
            {
                trangThai = "Đang làm";
            }
            else if (ngayHienTai > ngayKetThuc && tienDoInt < 100)
            {
                trangThai = "Quá hạn";
                btnSua.Visible = false;
            }
            else if (tienDoInt == 100)
            {
                trangThai = "Hoàn thành";
            }
            svDao.CapNhatTrangThai(tieuDe, trangThai, t.Nhom);
        }

        void HienThiDiem()
        {
            DateTime ngayKetThuc = DateTime.ParseExact(lblNgayKetThuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime ngayHienTai = DateTime.Now;
            if (Const.TaiKhoan.ChucVu == "Giảng viên")
            {
                btnCapNhat.Visible = false;
                btnSua.Visible = false;
                if (t.Diem != "")
                {
                    lblDiem.Visible = true;
                    txtChamDiem.Visible = false;
                    btnChamDiem.Visible = false;
                    lblChamDiem.Visible = true;
                }
                else if (ngayHienTai > ngayKetThuc)
                {
                    lblDiem.Visible = true;
                    btnChamDiem.Visible = true;
                    txtChamDiem.Visible = true;
                }
                else
                {
                    btnChamDiem.Visible = false;
                    txtChamDiem.Visible = false;
                }
            }
            else if (Const.TaiKhoan.ChucVu == "Sinh viên")
            {
                btnXoa.Visible = false;
                if (ngayHienTai > ngayKetThuc)
                {
                    lblDiem.Visible = true;
                    lblChamDiem.Visible = true;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa task này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                gvDao.XoaTask(lblTieuDe.Text, t.Nhom);

                // Xóa UserControl khỏi panel cha
                this.Parent.Controls.Remove(this);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = Const.TaiKhoan;

            if (taiKhoan.ChucVu == "Giảng viên")
            {
                bool hasNewMessages = db.CheckTinNhanMoi(t.Tieude, t.Nhom, "0");
                HandleNewMessages(hasNewMessages);
            }
            else if (taiKhoan.ChucVu == "Sinh viên")
            {
                bool hasNewMessages = db.CheckTinNhanMoi(t.Tieude, t.Nhom, "1");
                HandleNewMessages(hasNewMessages);
            }
        }

        private void HandleNewMessages(bool hasNewMessages)
        {
            if (hasNewMessages)
            {
                label1.Visible = !label1.Visible;
                timer1.Start();
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            ItChat x = new ItChat(t.Tieude, t.Nhom);
            x.ShowDialog();
            timer1_Tick(this, new EventArgs());
        }

        private void btnChamDiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChamDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm trước khi thực hiện chấm điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm điểm cho task này không?", "Xác nhận thêm điểm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                gvDao.ChamDiem(lblTieuDe.Text, txtChamDiem.Text, t.Nhom);
                txtChamDiem.Visible = false;
                btnChamDiem.Visible = false;
                lblChamDiem.Visible = true;
                lblChamDiem.Text = txtChamDiem.Text;
            }   
        }


    }
}
