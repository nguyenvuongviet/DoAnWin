using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanVan
{
    public class Task
    {
        private string tieude;
        private string tengiangvien;
        private string nhom;
        private string ngaybatdau;
        private string ngayketthuc;
        private string tiendo;
        private string trangthai;
        private string diem;
        private string noidung;

        public Task(string tieude, string tengiangvien, string nhom, string noidung, string ngaybatdau, string ngayketthuc, string tiendo, string trangthai, string diem)
        {
            this.Tieude = tieude;
            this.Tengiangvien = tengiangvien;
            this.Nhom = nhom;
            this.Noidung = noidung;
            this.Ngaybatdau = ngaybatdau;
            this.Ngayketthuc = ngayketthuc;
            this.Tiendo = tiendo;
            this.Trangthai = trangthai;
            this.Diem = diem;
        }

        public string Tieude { get => tieude; set => tieude = value; }
        public string Tengiangvien { get => tengiangvien; set => tengiangvien = value; }
        public string Nhom { get => nhom; set => nhom = value; }
        public string Ngaybatdau { get => ngaybatdau; set => ngaybatdau = value; }
        public string Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
        public string Tiendo { get => tiendo; set => tiendo = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Diem { get => diem; set => diem = value; }
        public string Noidung { get => noidung; set => noidung = value; }
    }
}
