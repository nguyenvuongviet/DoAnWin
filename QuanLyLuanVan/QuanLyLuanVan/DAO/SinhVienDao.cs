using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanVan
{
    internal class SinhVienDao
    {
        readonly DBConnection db = new DBConnection();

        public void Thucthi(string s)
        {
            DBConnection db = new DBConnection();
            db.Thucthi(s);
        }

        public SinhVien ThongTin(string iD)
        {
            return (SinhVien)db.ThongTin(iD, "SinhVien");
        }

        public void CapNhatThongTin(SinhVien sinhVien)
        {
            string SQL = string.Format("UPDATE SinhVien SET Hoten = N'{0}', Khoa = N'{1}', Gioitinh = N'{2}', Cccd = '{3}', Email = '{4}', Diachi = N'{5}', Ngaysinh = '{6}', Nhom ='{7}' WHERE Id = '{8}'",
                sinhVien.HoTen, sinhVien.Khoa, sinhVien.GioiTinh, sinhVien.Cccd, sinhVien.Email, sinhVien.DiaChi, sinhVien.NgaySinh, sinhVien.Nhom, sinhVien.ID);
            Thucthi(SQL);
        }
        
        public List<string> LoadGV()
        {
            string query = string.Format("SELECT Hoten FROM GiangVien");
            List<string> list = db.LoadGV(query);
            return list;
        }

        public List<string> LoadTheLoai()
        {
            string query = string.Format("SELECT TheLoai FROM LuanVan");
            List<string> list = db.LoadTheLoai(query);
            return list;
        }

        public List<LuanVan> LoadDSLuanVan(string loaiTimKiem, string selectedItem)
        {
            string trangThai = "0";
            string query = string.Format("SELECT * FROM LuanVan");
            if (loaiTimKiem == "GiangVien")
            {
                query = string.Format("SELECT * FROM LuanVan WHERE TrangThai= N'{0}' AND TenGiangVien = N'{1}'", trangThai, selectedItem);
            }
            else if (loaiTimKiem == "TheLoai")
            {
                query = string.Format("SELECT * FROM LuanVan WHERE TrangThai= N'{0}' AND TheLoai = N'{1}'", trangThai, selectedItem);
            }
            List<LuanVan> list = db.LoadDSLuanVan(query);
            return list;
        }

        public List<Task> LoadDSTask(string nhom, string trangThai)
        {
            string query;
            if (string.IsNullOrEmpty(trangThai))
            {
                query = string.Format("SELECT * FROM Task WHERE Nhom = N'{0}'", nhom);
            }
            else
            {
                query = string.Format("SELECT * FROM Task WHERE Nhom = N'{0}' AND TrangThai = N'{1}'", nhom, trangThai);
            }
            List<Task> list = db.LoadDSTask(query);
            return list;
        }

        public List<ThongBao> LoadDSThongBao(string nhom)
        {
            string s = string.Format("SELECT * FROM ThongBao Where Nhom = N'{0}'", nhom);
            List<ThongBao> list = db.LoadDSThongBao(s);
            return list;
        }

        public void CapNhatTienDo(string tiendo, string tieuDe, string nhom)
        {
            string SQL = string.Format("UPDATE Task SET TienDo = N'{0}' WHERE TieuDe = N'{1}' AND Nhom = N'{2}'", tiendo, tieuDe, nhom);
            Thucthi(SQL);
        }

        public void CapNhatTrangThai(string tieuDe, string trangThai, string nhom)
        {
            string SQL = string.Format("UPDATE Task SET TrangThai = N'{0}' WHERE TieuDe = N'{1}' AND Nhom = N'{2}'", trangThai, tieuDe, nhom);
            Thucthi(SQL);
        }

        public void DangKy(LuanVan lv, string nhom)
        {
            string SQL = string.Format("UPDATE LuanVan SET TrangThai = '1', Nhom = N'{1}' WHERE TenLuanVan = N'{0}'", lv.TenLuanVan, nhom);
            Thucthi(SQL);
        }

        public void DeXuat(LuanVan lv, string nhom)
        {
            string SQL = string.Format("INSERT INTO LuanVan(TenLuanVan, TenGiangVien, TheLoai, MoTa, SoLuongThanhVien, CongNghe, YeuCau, ChucNang, Nhom, TrangThai) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'1')",
                lv.TenLuanVan, lv.TenGiangVien, lv.TheLoai, lv.MoTa, lv.SlgThanhVien, lv.CongNghe, lv.YeuCau, lv.ChucNang, nhom);
            Thucthi(SQL);
        }

        public void DaXem(string tieudetask, string nhom)
        {
            string SQL = string.Format("UPDATE TinNhan SET TrangThai = N'2' WHERE TieuDeTask = N'{0}' AND Nhom =N'{1}' AND TrangThai='1'", tieudetask, nhom);
            Thucthi(SQL);
        }

        public void ThemNhom(SinhVien sinhVien, string nhom)
        {
            string SQL = string.Format("UPDATE SinhVien SET Nhom = N'{1}' WHERE Id = N'{0}'", sinhVien.ID, nhom);
            Thucthi(SQL);
        }

        public bool KiemTraTenNhom(string nhom)
        {
            string query = string.Format("SELECT COUNT(*) FROM SinhVien WHERE Nhom = N'{0}'", nhom);
            return db.KiemTraTenNhom(query);
        }

        public void XoaThanhVien(SinhVien sinhVien)
        {
            string SQL = string.Format("UPDATE SinhVien SET Nhom = N'' WHERE Id = N'{0}'", sinhVien.ID);
            Thucthi(SQL);
        }

        public void HuyLuanVan(LuanVan lv)
        {
            string SQL = string.Format("UPDATE LuanVan SET Nhom = N'', TrangThai = N'0' WHERE TenLuanVan = N'{0}'", lv.TenLuanVan);
            Thucthi(SQL);
            string SQL1 = string.Format("UPDATE  SinhVien SET Nhom = N'{0}' WHERE Nhom = N'{1}'", "", lv.Nhom);
            Thucthi(SQL1);
        }

    }
}
