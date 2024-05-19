using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanVan
{
    public class GiangVien
    {
        private string iD;
        private string hoTen;
        private string chucVu;
        private string khoa;
        private string gioiTinh;
        private string cccd;
        private string email;
        private string diaChi;
        private string ngaySinh;
        private string matKhau;

        public string ID { get => iD; set => iD = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }

        public GiangVien(string iD, string hoTen, string chucVu, string khoa, string gioiTinh, string cccd, string email, string diaChi, string ngaySinh, string matKhau)
        {
            this.iD = iD;
            this.hoTen = hoTen;
            this.chucVu = chucVu;
            this.khoa = khoa;
            this.gioiTinh = gioiTinh;
            this.cccd = cccd;
            this.email = email;
            this.diaChi = diaChi;
            this.ngaySinh = ngaySinh;
            this.matKhau = matKhau;
        }
    }
}

