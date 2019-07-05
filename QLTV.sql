	
	USE [master]
	GO

	WHILE EXISTS(select NULL from sys.databases where name='QLTV')
	BEGIN
		DECLARE @SQL varchar(max)
		SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
		FROM MASTER..SysProcesses
		WHERE DBId = DB_ID(N'QLTV') AND SPId <> @@SPId
		EXEC(@SQL)
		DROP DATABASE [QLTV]
	END
	GO

	CREATE DATABASE [QLTV]
	GO

	USE [QLTV]
	GO
	/****** Object:  Table [dbo].[TTDOCGIA]    Script Date: 5/18/2018 8:05:42 AM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[TTDOCGIA](
		[MaDG] [nchar](20) NOT NULL,
		[TenDG] [nvarchar](50) NOT NULL,
		[GioiTinh] nvarchar(30) NOT NULL,
		[NgaySinh] datetime NOT NULL,
		[Email] nvarchar(45) NOT NULL,
		[DiaChi] nvarchar(65) NOT NULL,
		[MaLoaiDG] nvarchar(30) NOT NULL,
		[NgayLapThe] datetime NOT NULL,
		[NgayHetHan] datetime NOT NULL,
		CONSTRAINT [PK_TTDOCGIA] PRIMARY KEY CLUSTERED 
	(
		[MaDG] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	USE [QLTV]
	GO
	INSERT INTO [dbo].[TTDOCGIA]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[Email],[DiaChi],[MaLoaiDG],[NgayLapThe],[NgayHetHan]) VALUES (N'18000001',N'Nguyễn Văn Anh',N'NAM','8/26/1998',N'vananhn98@gm.uit.edu.vn',N'Nghệ An',N'151','5/17/2018','11/17/2018')
	GO
	INSERT INTO [dbo].[TTDOCGIA]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[Email],[DiaChi],[MaLoaiDG],[NgayLapThe],[NgayHetHan]) VALUES (N'18000002',N'Hoàng Văn Khải',N'NAM','2/26/1999',N'khaidalka262@gm.uit.edu.vn',N'Tp.Hồ Chí Minh',N'151','5/17/2018','11/17/2018')
	GO
	INSERT INTO [dbo].[TTDOCGIA]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[Email],[DiaChi],[MaLoaiDG],[NgayLapThe],[NgayHetHan]) VALUES (N'18000003',N'Hoàng Nhật Linh',N'NỮ','8/17/2001',N'linhsuzaka817@gm.uit.edu.vn',N'Bình Phước',N'152','5/17/2018','11/17/2018')
	GO
	INSERT INTO [dbo].[TTDOCGIA]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[Email],[DiaChi],[MaLoaiDG],[NgayLapThe],[NgayHetHan]) VALUES (N'18000004',N'Ngô Việt Cường',N'KHÁC','2/23/1999',N'b404nh052vn@gm.uit.edu.vn',N'Quảng Bình',N'151','5/17/2018','11/17/2018')
	GO
	INSERT INTO [dbo].[TTDOCGIA]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[Email],[DiaChi],[MaLoaiDG],[NgayLapThe],[NgayHetHan]) VALUES(N'18000005',N'Ngô Thị Thục Trinh',N'NỮ','1/16/2002',N'cbtuoithi@gm.uit.edu.vn',N'Bình Thuận',N'152','5/17/2018','11/17/2018')
	GO
	/****** Object:  Table [dbo].[LOAIDOCGIA]    Script Date: 5/18/2018 8:05:42 AM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[LOAIDOCGIA](
		[MaLoaiDG] nvarchar(30) NOT NULL,
		[LoaiDG] nvarchar(30) NOT NULL,
		CONSTRAINT [PK_LOAIDOCGIA] PRIMARY KEY CLUSTERED 
	(
		[MaLoaiDG] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	USE [QLTV]
	GO
	INSERT INTO [dbo].[LOAIDOCGIA]([MaLoaiDG],[LoaiDG]) VALUES (N'151',N'Sinh Viên')
	GO
	INSERT INTO [dbo].[LOAIDOCGIA]([MaLoaiDG],[LoaiDG]) VALUES (N'152',N'Học Sinh')
	GO
	INSERT INTO [dbo].[LOAIDOCGIA]([MaLoaiDG],[LoaiDG]) VALUES (N'153',N'Nhân Viên Văn Phòng')
	
	/****** Object:  Table [dbo].[SACH]    Script Date: 5/18/2018 6:20:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SACH](
	[MaSach] [nchar](20) NOT NULL,
	[TenSach] [nvarchar](50) NOT NULL,
	[MaTheLoai] [nvarchar](15) NOT NULL,
	[MaTacGia]  [nvarchar](15) NOT NULL,
	[NamXuatBan] int NOT NULL,
	[NhaXuatBan] [nvarchar](30) NOT NULL,
	[NgayNhap] datetime NOT NULL,
	[TriGia] int  NOT NULL,
	[TinhTrang] nvarchar(5) NOT NULL,
    CONSTRAINT [PK_SACH] PRIMARY KEY CLUSTERED 
	(
		[MaSach] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

GO


USE [QLTV]
GO
INSERT INTO [dbo].[SACH]([MaSach],[TenSach],[MaTheLoai],[MaTacGia],[NamXuatBan],[NhaXuatBan],[NgayNhap],[TriGia],[TinhTrang]) VALUES (N'10101',N'Đồ Họa Máy Tính',N'181',N'18001',2011,N'Nhà Xuất Bản Trẻ','5/18/2018',25000,N'Còn')
	GO
INSERT INTO [dbo].[SACH]([MaSach],[TenSach],[MaTheLoai],[MaTacGia],[NamXuatBan],[NhaXuatBan],[NgayNhap],[TriGia],[TinhTrang]) VALUES (N'10102',N'Cơ Sở Dữ Liệu',N'181',N'18002',2012,N'Nhà Xuất Bản Trẻ','5/18/2018',30000,N'Còn')
	GO
INSERT INTO [dbo].[SACH]([MaSach],[TenSach],[MaTheLoai],[MaTacGia],[NamXuatBan],[NhaXuatBan],[NgayNhap],[TriGia],[TinhTrang]) VALUES (N'10103',N'Ngữ Văn',N'182',N'18003',2013,N'Nhà Xuất Bản Giáo Dục','5/18/2018',26000,N'Còn')
	GO
INSERT INTO [dbo].[SACH]([MaSach],[TenSach],[MaTheLoai],[MaTacGia],[NamXuatBan],[NhaXuatBan],[NgayNhap],[TriGia],[TinhTrang]) VALUES (N'10104',N'Địa Lí',N'182',N'18004',2014,N'Nhà Xuất Bản Giáo Dục','5/18/2018',28000,N'Còn')
	GO
INSERT INTO [dbo].[SACH]([MaSach],[TenSach],[MaTheLoai],[MaTacGia],[NamXuatBan],[NhaXuatBan],[NgayNhap],[TriGia],[TinhTrang]) VALUES (N'10105',N'Cô Gái Đến Từ Hôm Qua',N'183',N'18005',2015,N'Nhà Xuất Bản Trẻ','5/18/2018',55000,N'Còn')
	GO
INSERT INTO [dbo].[SACH]([MaSach],[TenSach],[MaTheLoai],[MaTacGia],[NamXuatBan],[NhaXuatBan],[NgayNhap],[TriGia],[TinhTrang]) VALUES (N'10106',N'Chờ Một Ngày Nắng',N'183',N'18006',2014,N'Nhà Xuất Bản Trẻ','5/18/2018',45000,N'Còn')
	GO
	/****** Object:  Table [dbo].[TTTRASACH]    Script Date: 05/23/2016 11:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTMUONTRASACH](
	[MaPhieu] [nchar](20) NOT NULL,
	[MaDG] [nchar](20) NOT NULL,
	[MaSach] [nchar](20) NOT NULL,
	[NgayMuon] datetime NOT NULL,
	[NgayHenTra] datetime NOT NULL,
	[NgayTra] datetime NOT NULL,
	[TinhTrangSach] nvarchar(25) NOT NULL,
	[TinhTrangTraSach] nvarchar(25) NOT NULL,
 CONSTRAINT [PK_TTTRASACH] PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC,
	[MaDG] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [QLTV]
GO
INSERT INTO [dbo].[TTMUONTRASACH]([MaPhieu],[MaDG],[MaSach],[NgayMuon],[NgayHenTra],[NgayTra],[TinhTrangSach],[TinhTrangTraSach]) VALUES (N'10001',N'18000001',N'10102','05/02/2018','05/29/2018','06/01/2018',N'Đã Trả',N'Quá Hạn')
	GO
INSERT INTO [dbo].[TTMUONTRASACH]([MaPhieu],[MaDG],[MaSach],[NgayMuon],[NgayHenTra],[NgayTra],[TinhTrangSach],[TinhTrangTraSach]) VALUES (N'10002',N'18000005',N'10103','05/04/2018','05/28/2018','01/01/2000',N'Đang Mượn',N'Đang Mượn')
	GO
INSERT INTO [dbo].[TTMUONTRASACH]([MaPhieu],[MaDG],[MaSach],[NgayMuon],[NgayHenTra],[NgayTra],[TinhTrangSach],[TinhTrangTraSach]) VALUES (N'10003',N'18000003',N'10104','05/03/2018','05/30/2018','01/01/2000',N'Đang Mượn',N'Đang Mượn')
	GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 6/01/2016 11:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
  [MaTheLoai] [nvarchar](15) NOT NULL,
  [TheLoai] [nvarchar](25) NOT NULL,

 CONSTRAINT [PK_THELOAI] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [QLTV]
GO
INSERT INTO [dbo].[THELOAI]([MaTheLoai],[TheLoai]) VALUES (N'181',N'Khoa Học Tự Nhiên')
	GO
INSERT INTO [dbo].[THELOAI]([MaTheLoai],[TheLoai]) VALUES (N'182',N'Khoa Học Xã Hội')
	GO
INSERT INTO [dbo].[THELOAI]([MaTheLoai],[TheLoai]) VALUES (N'183',N'Truyện Ngắn')
	GO
INSERT INTO [dbo].[THELOAI]([MaTheLoai],[TheLoai]) VALUES (N'184',N'Nấu Ăn')
	GO

/****** Object:  Table [dbo].[TacGia]    Script Date: 6/23/2016 11:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TACGIA](
  [MaTacGia] [nvarchar](15) NOT NULL,
  [TacGia] [nvarchar](25) NOT NULL,

 CONSTRAINT [PK_TACGIA] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [QLTV]
GO
INSERT INTO [dbo].[TACGIA]([MaTacGia],[TacGia]) VALUES (N'18001',N'Đình Thế Hiển')
	GO
INSERT INTO [dbo].[TACGIA]([MaTacGia],[TacGia]) VALUES (N'18002',N'Hà Duy Cường')
	GO
INSERT INTO [dbo].[TACGIA]([MaTacGia],[TacGia]) VALUES (N'18003',N'Bùi Thế Duy')
	GO
INSERT INTO [dbo].[TACGIA]([MaTacGia],[TacGia]) VALUES (N'18004',N'Đặng Trần Tùng')
	GO
INSERT INTO [dbo].[TACGIA]([MaTacGia],[TacGia]) VALUES (N'18005',N'Nguyễn Nhật Ánh')
GO
INSERT INTO [dbo].[TACGIA]([MaTacGia],[TacGia]) VALUES (N'18006',N'Điệp Linh Chi')
	GO

	/****** Object:  Table [dbo].[QuyDinh]    Script Date: 06/16/2016 9:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyDinh](
	[SoTuoiToiThieu] int NOT NULL,
	[SoTuoiToiDa] int NOT NULL,
    [HSDThe] int NOT NULL,
	[KhoangCachNXB] int NOT NULL,
	[SLTheLoai] int NOT NULL,
	[SoLuongSachMuon] int NOT NULL,
	[SoNgayMuon] int NOT NULL,


	)
GO
USE [QLTV]
GO
INSERT INTO [dbo].[QuyDinh]([SoTuoiToiThieu],[SoTuoiToiDa],[HSDThe],[KhoangCachNXB],[SLTheLoai],[SoLuongSachMuon],[SoNgayMuon]) VALUES (18,55,6,8,15,5,30)
	GO

ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SACH_tbl_THELOAI] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[THELOAI] ([MaTheLoai])
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SACH_tbl_TACGIA] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TACGIA] ([MaTacGia])
GO
ALTER TABLE [dbo].[TTDOCGIA]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TTDOCGIA_tbl_LOAIDOCGIA] FOREIGN KEY([MaLoaiDG])
REFERENCES [dbo].[LOAIDOCGIA] ([MaLoaiDG])
GO
ALTER TABLE [dbo].[TTMUONTRASACH]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TTMUONTRASACH_tbl_TTDOCGIA] FOREIGN KEY([MaDG])
REFERENCES [dbo].[TTDOCGIA] ([MaDG])
GO
ALTER TABLE [dbo].[TTMUONTRASACH]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TTMUONTRASACH_tbl_SACH] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO


select * from TTMUONTRASACH

delete from TTDOCGIA where MaDG=18000001