using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanVan
{
    public class LuanVan
    {
        private string tenLuanVan;
        private string tenGiangVien;
        private string theLoai;
        private string moTa;
        private string slgThanhVien;
        private string congNghe;
        private string yeuCau;
        private string chucNang;
        private string diem;
        private string danhGia;
        private string nhom;
        private string trangThai;

        public LuanVan(string tenLuanVan, string tenGiangVien, string theLoai, string moTa, string slgThanhVien, string congNghe, string yeuCau, string chucNang, string diem, string danhGia, string nhom, string trangThai)
        {
            this.tenLuanVan = tenLuanVan;
            this.tenGiangVien = tenGiangVien;
            this.theLoai = theLoai;
            this.moTa = moTa;
            this.slgThanhVien = slgThanhVien;
            this.congNghe = congNghe;
            this.yeuCau = yeuCau;
            this.chucNang = chucNang;
            this.diem = diem;
            this.danhGia = danhGia;
            this.nhom = nhom;
            this.trangThai = trangThai;
        }

        public string TenLuanVan { get => tenLuanVan; set => tenLuanVan = value; }
        public string TenGiangVien { get => tenGiangVien; set => tenGiangVien = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string SlgThanhVien { get => slgThanhVien; set => slgThanhVien = value; }
        public string CongNghe { get => congNghe; set => congNghe = value; }
        public string YeuCau { get => yeuCau; set => yeuCau = value; }
        public string ChucNang { get => chucNang; set => chucNang = value; }
        public string Diem { get => diem; set => diem = value; }
        public string DanhGia { get => danhGia; set => danhGia = value; }
        public string Nhom { get => nhom; set => nhom = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
