using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanVan
{
    public class ThongBao
    {
        private string tieuDe;
        private string noiDung;
        string ngayGui;
        private string giangVien;
        private string nhom;

        public ThongBao(string tieuDe, string noiDung, string ngayGui, string giangVien, string nhom)
        {
            this.TieuDe = tieuDe;
            this.NoiDung = noiDung;
            this.NgayGui = ngayGui;
            this.GiangVien = giangVien;
            this.Nhom = nhom;
        }

        public string TieuDe { get => tieuDe; set => tieuDe = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public string NgayGui { get => ngayGui; set => ngayGui = value; }
        public string GiangVien { get => giangVien; set => giangVien = value; }
        public string Nhom { get => nhom; set => nhom = value; }
    }
}

