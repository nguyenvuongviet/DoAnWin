using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace QuanLyLuanVan
{
    internal class GiangVienDao
    {
        readonly DBConnection db = new DBConnection();

        public void Thucthi(string s)
        {
            DBConnection db = new DBConnection();
            db.Thucthi(s);
        }

        public GiangVien ThongTin(string iD)
        {
            return (GiangVien)db.ThongTin(iD, "GiangVien");
        }

        public void CapNhatThongTin(GiangVien giangVien)
        {
            string SQL = string.Format("UPDATE GiangVien SET Hoten = N'{0}', Khoa = N'{1}', Gioitinh = N'{2}', Cccd = '{3}', Email = '{4}', Diachi = N'{5}', Ngaysinh = '{6}' WHERE Id = '{7}'",
                giangVien.HoTen, giangVien.Khoa, giangVien.GioiTinh, giangVien.Cccd, giangVien.Email, giangVien.DiaChi, giangVien.NgaySinh, giangVien.ID);
            Thucthi(SQL);
        }

        public List<LuanVan> LoadDSLuanVan(string trangThai)
        {
            string query;
            if (string.IsNullOrEmpty(trangThai))
            {
                query = string.Format("SELECT * FROM LuanVan");
            }
            else
            {
                query = string.Format("SELECT * FROM LuanVan WHERE TrangThai= N'{0}'", trangThai);
            }
            List<LuanVan> list = db.LoadDSLuanVan(query);
            return list;
        }

        public void ThemLuanVan(LuanVan lv)
        {
            string SQL = string.Format("INSERT INTO LuanVan(TenLuanVan, TenGiangVien, TheLoai, MoTa, SoLuongThanhVien, CongNghe, YeuCau, ChucNang, TrangThai) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'0')",
                lv.TenLuanVan, lv.TenGiangVien, lv.TheLoai, lv.MoTa, lv.SlgThanhVien, lv.CongNghe, lv.YeuCau, lv.ChucNang);
            Thucthi(SQL);
        }

        public void XoaLuanVan(string tenLuanVan, string nhom)
        {
            string SQL = string.Format("DELETE FROM LuanVan WHERE TenLuanVan = N'{0}' AND Nhom = N'{1}'", tenLuanVan, nhom);
            string SQL1 = string.Format("DELETE FROM Task WHERE Nhom = N'{0}'", nhom);
            string SQL2 = string.Format("DELETE FROM ThongBao WHERE Nhom = N'{0}'", nhom);
            string SQL3 = string.Format("UPDATE  SinhVien SET Nhom = N'{0}' WHERE Nhom = N'{1}'", "", nhom);
            string SQL4 = string.Format("DELETE FROM TinNhan WHERE Nhom = N'{0}'", nhom);
            string SQL5 = string.Format("DELETE FROM LuanVan WHERE TenLuanVan = N'{0}'", tenLuanVan);
            Thucthi(SQL5);
            Thucthi(SQL);
            Thucthi(SQL1);
            Thucthi(SQL2);
            Thucthi(SQL3);
            Thucthi(SQL4);
        }

        public void KhongDuyetNhom(string tenLuanVan, string nhom)
        {
            string SQL = string.Format("UPDATE LuanVan SET TrangThai = '0' WHERE TenLuanVan = N'{0}'", tenLuanVan);
            Thucthi(SQL);
            string SQL1 = string.Format("UPDATE  SinhVien SET Nhom = N'{0}' WHERE Nhom = N'{1}'", "", nhom);
            Thucthi(SQL1);
        }

        public void DuyetNhom(string tenLuanVan)
        {
            string SQL = string.Format("UPDATE LuanVan SET TrangThai = '2' WHERE TenLuanVan = N'{0}'", tenLuanVan);
            Thucthi(SQL);
        }

        public List<Task> LoadDSTask(string nhom, string tenGV)
        {
            string s = string.Format("SELECT * FROM Task WHERE Nhom = N'{0}' AND TenGiangVien = N'{1}'", nhom, tenGV);
            List<Task> list = db.LoadDSTask(s);
            return list;
        }

        public void XoaTask(string tieuDe, string nhom)
        {
            string SQL = string.Format("DELETE FROM Task WHERE TieuDe = N'{0}' AND Nhom = N'{1}'", tieuDe, nhom);
            Thucthi(SQL);
            string SQL1 = string.Format("DELETE FROM TinNhan WHERE Nhom = N'{0}'", nhom);
            Thucthi(SQL1);
            UpDateDiem(nhom);
        }

        public void GiaoTask(Task t)
        {
            string SQL = string.Format("INSERT INTO Task(TieuDe,TenGiangVien,Nhom,NoiDung,NgayBatDau,NgayKetThuc,TienDo,TrangThai,Diem) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')",
                t.Tieude, t.Tengiangvien, t.Nhom, t.Noidung, t.Ngaybatdau, t.Ngayketthuc, t.Tiendo, t.Trangthai, t.Diem);
            Thucthi(SQL);
        }

        public void ThongBao(ThongBao tb)
        {
            string SQL = string.Format("INSERT INTO ThongBao(TieuDe,NoiDung,ThoiGianGui,NguoiGui,Nhom) VALUES (N'{0}',N'{1}','{2}',N'{3}',N'{4}')",
                tb.TieuDe, tb.NoiDung, tb.NgayGui, tb.GiangVien, tb.Nhom);
            Thucthi(SQL);
        }

        public List<ThongBao> LoadDSThongBao(string tenGV)
        {
            string s = string.Format("SELECT * FROM ThongBao WHERE NguoiGui = N'{0}'", tenGV);
            List <ThongBao> list = db.LoadDSThongBao(s);
            return list;
        }

        public void XoaTb(string tieuDe, string nhom)
        {
            string SQL = string.Format("DELETE FROM ThongBao WHERE TieuDe = N'{0}' AND Nhom = N'{1}'", tieuDe, nhom);
            Thucthi(SQL);
        }
       
        public void DaXem(string tieudetask, string nhom)
        {
            string SQL = string.Format("UPDATE TinNhan SET TrangThai = N'2' WHERE TieuDeTask = N'{0}' AND Nhom =N'{1}' AND TrangThai='0'", tieudetask, nhom);
            Thucthi(SQL);
        }

        public void ChamDiem (string tieuDe, string diem, string nhom)
        {
            string SQL = string.Format("UPDATE Task SET Diem = N'{0}' WHERE TieuDe = N'{1}' AND Nhom = N'{2}'", diem, tieuDe, nhom);
            Thucthi(SQL);
            UpDateDiem(nhom);
        }

        public void UpDateDiem(string nhom)
        {
            string SQL = string.Format("SELECT Diem FROM Task WHERE Nhom = N'{0}'", nhom);
            double diem = db.LayDiemTB(SQL);
            string SQL1 = string.Format("UPDATE LuanVan SET Diem = N'{0}' WHERE Nhom = N'{1}'", diem, nhom);
            Thucthi(SQL1);
        }

        public DataTable TKSoLuongDiem(string tenGV)
        {
            string query = string.Format("SELECT Diem, COUNT(*) AS Count FROM LuanVan Where TenGiangVien = N'{0}' GROUP BY Diem ORDER BY Diem ASC", tenGV);
            return db.ThongKe(query);
        }

        public DataTable TKDiemNhom(string tenGV)
        {
            string query = string.Format("SELECT Nhom,Diem FROM LuanVan Where TenGiangVien = N'{0}' AND Diem IS NOT NULL ", tenGV);
            return db.ThongKe(query);
        }

        public int DemLuanVan(string tenGV, string trangthai)
        {
            string query;
            if (trangthai != null)
            {
                query = string.Format("SELECT COUNT(*) FROM LuanVan WHERE TrangThai = N'{0}' AND TenGiangVien = N'{1}'", trangthai, tenGV);
            }
            else
            {
                query = string.Format("SELECT COUNT(*) FROM LuanVan WHERE TenGiangVien = N'{0}'", tenGV);

            }
            return db.DemLuanVan(query);
        }
    }
}
