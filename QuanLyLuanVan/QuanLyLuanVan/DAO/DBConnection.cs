using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace QuanLyLuanVan
{
    public class DBConnection
    {
        public static SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public bool CheckDangNhap(string iD, string matKhau, string chucVu)
        {
            conn.Open();
            string query = "";
            if (chucVu == "Sinh viên")
            {
                query = "SELECT COUNT(*) FROM SinhVien WHERE Id = '" + iD + "' AND Matkhau = '" + matKhau + "'";
            }
            else if (chucVu == "Giảng viên")
            {
                query = "SELECT COUNT(*) FROM GiangVien WHERE Id = '" + iD + "' AND Matkhau = '" + matKhau + "'";
            }
            SqlCommand command = new SqlCommand(query, conn);
            int count = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return count > 0;
        }

        public bool KiemTraTenNhom(string query)
        {
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            int count = (int)command.ExecuteScalar();
            conn.Close();

            return count > 0;
        }

        public void Thucthi(string s)
        {
            try
            {
                // Ket noi
                conn.Open();

                SqlCommand cmd = new SqlCommand(s, conn);
                //if (cmd.ExecuteNonQuery() > 0)
                //    MessageBox.Show("Thành Công");
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Có ít nhất một hàng đã được thêm, sửa đổi hoặc xóa từ cơ sở dữ liệu
                    // Điều này có thể được sử dụng để thông báo cho người dùng hoặc xử lý tiếp theo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("That Bai" + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> LoadGV(string query)
        {
            List<string> list = new List<string>();
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tenGiangVien = reader["Hoten"].ToString();
                list.Add(tenGiangVien);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public List<string> LoadTheLoai(string query)
        {
            List<string> theLoaiList = new List<string>();
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string theLoai = reader["TheLoai"].ToString();
                theLoaiList.Add(theLoai);
            }
            reader.Close();
            conn.Close();
            return theLoaiList;
        }

        public object ThongTin(string iD, string tableName)
        {
            string query = string.Format("SELECT * FROM {0} WHERE Id = @Id", tableName);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Id", iD);

            object obj = null;

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (tableName == "SinhVien")
                {
                    SinhVien sinhVien = Const.SinhVien;
                    sinhVien.ID = reader["Id"].ToString();
                    sinhVien.HoTen = reader["Hoten"].ToString();
                    sinhVien.ChucVu = reader["Chucvu"].ToString();
                    sinhVien.Khoa = reader["Khoa"].ToString();
                    sinhVien.GioiTinh = reader["Gioitinh"].ToString();
                    sinhVien.Cccd = reader["Cccd"].ToString();
                    sinhVien.Email = reader["Email"].ToString();
                    sinhVien.DiaChi = reader["Diachi"].ToString();
                    sinhVien.NgaySinh = reader["Ngaysinh"].ToString();
                    sinhVien.Nhom = reader["Nhom"].ToString();
                    obj = sinhVien;
                }
                else if (tableName == "GiangVien")
                {
                    GiangVien giangVien = Const.GiangVien;
                    giangVien.ID = reader["Id"].ToString();
                    giangVien.HoTen = reader["Hoten"].ToString();
                    giangVien.ChucVu = reader["Chucvu"].ToString();
                    giangVien.Khoa = reader["Khoa"].ToString();
                    giangVien.GioiTinh = reader["Gioitinh"].ToString();
                    giangVien.Cccd = reader["Cccd"].ToString();
                    giangVien.Email = reader["Email"].ToString();
                    giangVien.DiaChi = reader["Diachi"].ToString();
                    giangVien.NgaySinh = reader["Ngaysinh"].ToString();
                    obj = giangVien;
                }
            }
            conn.Close();

            return obj;
        }
    
        public List<LuanVan> LoadDSLuanVan(string query)
        {
            List<LuanVan> list = new List<LuanVan>();
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tenLuanVan = reader["TenLuanVan"].ToString();
                string tenGiangVien = reader["TenGiangVien"].ToString();
                string theLoai = reader["TheLoai"].ToString();
                string moTa = reader["MoTa"].ToString();
                string slgThanhVien = reader["SoLuongThanhVien"].ToString();
                string congNghe = reader["CongNghe"].ToString();
                string yeuCau = reader["YeuCau"].ToString();
                string chucNang = reader["ChucNang"].ToString();
                string diem = reader["Diem"].ToString();
                string danhGia = reader["DanhGia"].ToString();
                string nhom = reader["Nhom"].ToString();
                string trangThai = reader["TrangThai"].ToString();

                LuanVan lv = new LuanVan(tenLuanVan, tenGiangVien, theLoai, moTa, slgThanhVien, congNghe, yeuCau, chucNang, diem, danhGia, nhom, trangThai);
                list.Add(lv);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public List<Task> LoadDSTask(string query)
        {
            List<Task> list = new List<Task>();
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tieuDe = reader["TieuDe"].ToString();
                string tenGV = reader["TenGiangVien"].ToString();
                string nhom = reader["Nhom"].ToString();
                string noiDung = reader["NoiDung"].ToString();
                string ngayBatDau = reader["NgayBatDau"].ToString();
                string ngayKetThuc = reader["NgayKetThuc"].ToString();
                string tienDo = reader["TienDo"].ToString();
                string trangThai = reader["TrangThai"].ToString();
                string diem = reader["Diem"].ToString();
                Task task = new Task(tieuDe, tenGV, nhom, noiDung, ngayBatDau, ngayKetThuc, tienDo, trangThai, diem);
                list.Add(task);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public List<ThongBao> LoadDSThongBao(string query)
        {
            List<ThongBao> list = new List<ThongBao>();
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tieuDe = reader["TieuDe"].ToString();
                string noiDung = reader["NoiDung"].ToString();
                string tgGui = reader["ThoiGianGui"].ToString();
                string nguoiGui = reader["NguoiGui"].ToString();
                string nhom = reader["Nhom"].ToString();
                ThongBao lv = new ThongBao(tieuDe, noiDung, tgGui, nguoiGui, nhom);
                list.Add(lv);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public List<SinhVien> DanhSachSinhVien()
        {
            List<SinhVien> list = new List<SinhVien>();
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM SinhVien", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader["Id"].ToString();
                string hoten = reader["Hoten"].ToString();
                string chucvu = reader["Chucvu"].ToString();
                string khoa = reader["Khoa"].ToString();
                string gioitinh = reader["GioiTinh"].ToString();
                string cccd = reader["Cccd"].ToString();
                string email = reader["Email"].ToString();
                string diachi = reader["Diachi"].ToString();
                string ngaysinh = reader["Ngaysinh"].ToString();
                string matkhau = reader["Matkhau"].ToString();
                string nhom = reader["Nhom"].ToString();
                SinhVien sv = new SinhVien(id, hoten, chucvu, khoa, gioitinh, cccd, email, diachi, ngaysinh, matkhau, nhom);
                list.Add(sv);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public bool CheckTinNhanMoi(string tieudetask, string nhom, string trangthai)
        {
            try
            {
                string query = string.Format("SELECT COUNT(*) FROM TinNhan WHERE TieuDeTask=N'{0}' AND Nhom = N'{1}' AND TrangThai = N'{2}' ", tieudetask, nhom, trangthai);
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                int newMessagesCount = (int)command.ExecuteScalar();
                return newMessagesCount > 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public void ThemTinNhan(Mess mess)
        {
            try
            {
                conn.Open();
                string s;
                if (mess.Anh != null)
                {
                    s = "INSERT INTO TinNhan(TieuDeTask, NguoiGui, Nhom, ThoiGianGui, NoiDung, Anh, TrangThai) VALUES (@TieuDeTask, @NguoiGui, @Nhom, @ThoiGianGui, @NoiDung, @Anh, @TrangThai)";
                }
                else
                {
                    s = "INSERT INTO TinNhan(TieuDeTask, NguoiGui, Nhom, ThoiGianGui, NoiDung, TrangThai) VALUES (@TieuDeTask, @NguoiGui, @Nhom, @ThoiGianGui, @NoiDung, @TrangThai)";
                }

                using (SqlCommand command = new SqlCommand(s, conn))
                {
                    command.Parameters.AddWithValue("@TieuDeTask", mess.Tieudetask);
                    command.Parameters.AddWithValue("@NguoiGui", mess.Nguoigui);
                    command.Parameters.AddWithValue("@Nhom", mess.Nhom);
                    command.Parameters.AddWithValue("@ThoiGianGui", mess.Thoigiangui);
                    command.Parameters.AddWithValue("@NoiDung", mess.Noidung);
                    command.Parameters.AddWithValue("@TrangThai", mess.Trangthai);

                    if (mess.Anh != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            mess.Anh.Save(ms, mess.Anh.RawFormat);
                            command.Parameters.AddWithValue("@Anh", ms.ToArray());
                        }
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Anh", DBNull.Value);
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Có ít nhất một hàng đã được thêm, sửa đổi hoặc xóa từ cơ sở dữ liệu
                        // Điều này có thể được sử dụng để thông báo cho người dùng hoặc xử lý tiếp theo
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Mess> DanhSachChat(string tieuDe, string nhom)
        {
            List<Mess> list = new List<Mess>();
            conn.Open();
            string query = string.Format("SELECT * FROM TinNhan WHERE TieuDeTask = N'{0}' AND Nhom = N'{1}' ORDER BY Id ASC ", tieuDe, nhom);
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nguoiGui = reader["NguoiGui"].ToString();
                string tgGui = reader["ThoiGianGui"].ToString();
                string noiDung = reader["NoiDung"].ToString();
                string trangThai = reader["TrangThai"].ToString();

                Image anh = null;
                if (!reader.IsDBNull(reader.GetOrdinal("Anh")))
                {
                    byte[] imageData = (byte[])reader["Anh"];
                    anh = ByteArrayToImage(imageData);
                }
                Mess m = new Mess(tieuDe, nguoiGui, nhom, tgGui, noiDung, anh, trangThai);
                list.Add(m);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public double LayDiemTB(string query)
        {
            double diemTrungBinh = 0;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            int count = 0;
            double totalDiem = 0;
            while (reader.Read())
            {
                double diem;
                if (double.TryParse(reader["Diem"].ToString(), out diem))
                {
                    totalDiem += diem;
                    count++;
                }
            }
            reader.Close();
            conn.Close();
            if (count > 0)
            {
                diemTrungBinh = Math.Round(totalDiem / count, 2);
            }
            return diemTrungBinh;
        }

        public DataTable ThongKe (string query)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public int DemLuanVan(string query)
        {
            int count = 0;
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            count = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return count;
        }


    }
}
