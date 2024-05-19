CREATE DATABASE QuanLyLuanVan;
GO 
USE QuanLyLuanVan
Go
CREATE TABLE LuanVan(
    TenLuanVan    NVARCHAR(4000) NULL,
    TenGiangVien NVARCHAR(100) NULL,
    TheLoai      NVARCHAR (200) NULL,
    Mota       NVARCHAR (4000) NULL,
    SoLuongThanhVien       NVARCHAR (500) NULL,
    CongNghe NVARCHAR (100)  NULL, 
    YeuCau NVARCHAR(4000) NULL, 
    ChucNang NVARCHAR(4000) NULL,
    -- TaiLieuBaoCao NVARCHAR (1000)  NULL,
    -- TienDo NVARCHAR (50)  NULL,
    Diem NVARCHAR (50)  NULL,
    -- DanhGia NVARCHAR (4000)  NULL,
    Nhom NVARCHAR (50)  NULL,
    -- NhomTruong NVARCHAR (50)  NULL,
    -- SoLuongTVNhom NVARCHAR (100) NULL,
    TrangThai NVARCHAR (50)  NULL,
);
SELECT*from LuanVan

CREATE TABLE GiangVien(
	Id NVARCHAR(100),
	Hoten NVARCHAR(100),
	Chucvu NVARCHAR(100),
	Khoa NVARCHAR(100),
	Gioitinh NVARCHAR(100),
	Cccd NVARCHAR(100),
	Email NVARCHAR(100),
	Diachi NVARCHAR(100),
	Ngaysinh NVARCHAR(100),
	Matkhau NVARCHAR(50)
)
SELECT*from GiangVien

INSERT INTO GiangVien (Id, Hoten, Chucvu, Khoa, Gioitinh, Cccd, Email, Diachi, Ngaysinh, Matkhau)
VALUES 
('GV01', N'Nguyễn Thành Sơn', N'Giảng viên', N'Công nghệ Thông tin', N'Nam', '123456', 'gv01@gmail.com', N'Hồ Chí Minh', '08/07/1963', '123'),
('GV02', N'Nguyễn Thuỷ An', N'Giảng viên', N'Công nghệ Thông tin', N'Nữ', '456789', 'gv02@gmail.com', N'Hồ Chí Minh', '30/06/1986', '123')

CREATE TABLE SinhVien(
	Id NVARCHAR(100),
	Hoten NVARCHAR(100),
	Chucvu NVARCHAR(100),
	Khoa NVARCHAR(100),
	Gioitinh NVARCHAR(100),
	Cccd NVARCHAR(100),
	Email NVARCHAR(100),
	Diachi NVARCHAR(100),
	Ngaysinh NVARCHAR(100),
	Matkhau NVARCHAR(50),
    Nhom NVARCHAR(10)
)
SELECT*from SinhVien

INSERT INTO SinhVien (Id, Hoten, Chucvu, Khoa, Gioitinh, Cccd, Email, Diachi, Ngaysinh, Matkhau, nhom)
VALUES 
('SV01', N'Nguyễn Văn Nam', N'Sinh viên', N'Công nghệ Thông tin', N'Nam', '123', 'sv01@gmail.com', N'Hồ Chí Minh', '13/08/2004', '123', ''),
('SV02', N'Nguyễn Thị Linh', N'Sinh viên', N'Công nghệ Thông tin', N'Nữ', '456', 'sv02@gmail.com', N'Hồ Chí Minh', '20/08/2004', '123', ''),
('SV03', N'Trần Đình Bảo', N'Sinh viên', N'Công nghệ Thông tin', N'Nam', '124', 'sv03@gmail.com', N'Hồ Chí Minh', '24/04/2004', '123', ''),
('SV04', N'Lê Anh Tài', N'Sinh viên', N'Công nghệ Thông tin', N'Nam', '125', 'sv04@gmail.com', N'Hồ Chí Minh', '12/07/2004', '123', ''),
('SV05', N'Nguyễn Hồng Thi', N'Sinh viên', N'Công nghệ Thông tin', N'Nam', '126', 'sv05@gmail.com', N'Hồ Chí Minh', '15/01/2004', '123', ''),
('SV06', N'Lê Thị Hồng Hoa', N'Sinh viên', N'Công nghệ Thông tin', N'Nữ', '127', 'sv06@gmail.com', N'Hồ Chí Minh', '19/11/2003', '123', ''),
('SV07', N'Nguyễn Ly Na', N'Sinh viên', N'Công nghệ Thông tin', N'Nữ', '128', 'sv07@gmail.com', N'Hồ Chí Minh', '06/03/2004', '123', ''),
('SV08', N'Trần Quốc Vượng', N'Sinh viên', N'Công nghệ Thông tin', N'Nam', '129', 'sv08@gmail.com', N'Hồ Chí Minh', '22/09/2004', '123', ''),
('SV09', N'Nguyễn Quỳnh Lan', N'Sinh viên', N'Công nghệ Thông tin', N'Nữ', '130', 'sv09@gmail.com', N'Hồ Chí Minh', '29/05/2004', '123', ''),
('SV10', N'Lê Hữu Hoàng', N'Sinh viên', N'Công nghệ Thông tin', N'Nam', '131', 'sv10@gmail.com', N'Hồ Chí Minh', '01/02/2004', '123', '')

CREATE TABLE Task(
    TieuDe    NVARCHAR(4000) NULL,
    TenGiangVien NVARCHAR(500) NULL,
    Nhom      NVARCHAR (100) NULL,
    NgayBatDau NVARCHAR (100) NULL,  
    NgayKetThuc NVARCHAR (100)  NULL,
    TienDo NVARCHAR (50)  NULL,
	TrangThai NVARCHAR(50),
	Diem NVARCHAR (50)  NULL,
    NoiDung NVARCHAR(4000)
);
SELECT * From Task

CREATE TABLE ThongBao(
    TieuDe    NVARCHAR(4000) NULL,
    NguoiGui NVARCHAR(100) NULL,
    Nhom      NVARCHAR (100) NULL,
    ThoiGianGui NVARCHAR (500) NULL,  
	NoiDung NVARCHAR(4000) 
);
SELECT * From ThongBao

CREATE TABLE TinNhan(
    TieuDeTask NVARCHAR(4000) NULL,
    NguoiGui NVARCHAR(100) NULL,
    Nhom      NVARCHAR (100) NULL,
    ThoiGianGui NVARCHAR (500) NULL,
	NoiDung NVARCHAR(4000),
    Anh IMAGE,
    TrangThai NVARCHAR(50),
    Id INT IDENTITY(1,1) PRIMARY KEY,
);
SELECT * From TinNhan