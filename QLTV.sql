	
USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='QLTV')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLTC') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QLTV]
END
GO

/* Collation = SQL_Latin1_General_CP1_CI_AS */
CREATE DATABASE [QLTV]
GO
USE [QLTV]
GO


CREATE TABLE [dbo].[tblLoaiDocGia](
	[maLoaiDocGia] [varchar](7) primary key,
	[tenLoaiDocGia] [nvarchar](50) NOT NULL,
	
)
GO
INSERT INTO[dbo].[tblLoaiDocGia]([maLoaiDocGia],[tenLoaiDocGia]) VALUES('Loai001',N'X')
GO
INSERT INTO[dbo].[tblLoaiDocGia]([maLoaiDocGia],[tenLoaiDocGia]) VALUES('Loai002',N'Y')
GO



CREATE TABLE [dbo].[tblTheDocGia](
	[maDocGia] [varchar](7) primary key,
	[hoVaTenDocGia] [nvarchar](50) NOT NULL,
	[ngaySinh] datetime2(7),
	[email] [nvarchar](50), 
	[diaChi] [nvarchar](50) NOT NULL, 
	[maLoaiDocGia] [varchar](7) FOREIGN KEY REFERENCES [dbo].[tblLoaiDocGia] ([maLoaiDocGia]) ,
	[ngayLapThe] datetime2(7),
	[hanSuDung] int
	)
	GO


INSERT INTO[dbo].[tblTheDocGia]([maDocGia],[hoVaTenDocGia],[ngaySinh],[diaChi],[email],[maLoaiDocGia],[ngayLapThe],[hanSuDung]) VALUES('DG00001',N'Trần Thảo Nguyên','1998-03-19',N'Bến Cầu-Tây Ninh','123@gmail.com','Loai002','2018-5-5',5)
go																												
INSERT INTO[dbo].[tblTheDocGia]([maDocGia],[hoVaTenDocGia],[ngaySinh],[diaChi],[email],[maLoaiDocGia],[ngayLapThe],[hanSuDung]) VALUES('DG00002',N'Hoàng Văn Khải','1999-1-2',N'Đắk Lắk','456@gmail.com','Loai001','2019-2-1',5)
GO																												
INSERT INTO[dbo].[tblTheDocGia]([maDocGia],[hoVaTenDocGia],[ngaySinh],[diaChi],[email],[maLoaiDocGia],[ngayLapThe],[hanSuDung]) VALUES('DG00003',N'Đăng Văn Đi','1998-11-11',N'xx-Đắk Lắk','789@gmail.com','Loai001','2019-3-1',5)
GO																												
INSERT INTO[dbo].[tblTheDocGia]([maDocGia],[hoVaTenDocGia],[ngaySinh],[diaChi],[email],[maLoaiDocGia],[ngayLapThe],[hanSuDung]) VALUES('DG00004',N'Trương Văn Việt','1998-11-11',N'XX-Bình Phướng','101112@gmail.com','Loai002','2019-4-1',5)
GO																												
INSERT INTO[dbo].[tblTheDocGia]([maDocGia],[hoVaTenDocGia],[ngaySinh],[diaChi],[email],[maLoaiDocGia],[ngayLapThe],[hanSuDung]) VALUES('DG00005',N'Ngô Việt Cường','1998-11-12',N'xx-Quảng Bình','131415@gmail.com','Loai002','2019-5-1',5)
GO																												
INSERT INTO[dbo].[tblTheDocGia]([maDocGia],[hoVaTenDocGia],[ngaySinh],[diaChi],[email],[maLoaiDocGia],[ngayLapThe],[hanSuDung]) VALUES('DG00006',N'Phạ Kim Thành','1998-9-13',N'xx-HCM','161718@gmail.com','Loai001','2019-6-1',5)
Go
select * from[dbo].[tblTheDocGia]
DELETE FROM [dbo].[tblTheDocGia] WHERE [maDocGia] = 'DG00010'

UPDATE [dbo].[tblTheDocGia]  SET [hoVaTenDocGia] = 'Nguyển Văn B', [ngaySinh] = '2015-01-02', [diaChi] = '12345@gmail.com', [email] = 'HCM', [maLoaiDocGia] = 'Loai001', [ngayLapThe] ='2019-6-1', [hanSuDung]=7 WHERE[maDocGia] = 'DG00010'

select * from [dbo].[tblLoaiDocGia]

CREATE TABLE [dbo].[tblTheLoai](
	[maTheLoai] [varchar](7) primary key,
	[tenTheLoai] [nvarchar](50) NOT NULL
	)
	GO

INSERT INTO[dbo].[tblTheLoai]([maTheLoai],[tenTheLoai]) VALUES('ThLo001',N'A')
GO
INSERT INTO[dbo].[tblTheLoai]([maTheLoai],[tenTheLoai]) VALUES('ThLo002',N'B')
GO
INSERT INTO[dbo].[tblTheLoai]([maTheLoai],[tenTheLoai]) VALUES('ThLo003',N'C')
GO
select * from [dbo].[tblTheLoai]

CREATE TABLE [dbo].[tblSach](
	[maSach] [varchar](7) primary key,
	[TenSach] [nvarchar](50) NOT NULL,
	[ngayNhap] datetime2(7),
	[tacGia] [nvarchar](50), 
	[nhaXuatBan] [nvarchar](50) NOT NULL, 
	[maTheLoai] [varchar](7) FOREIGN KEY REFERENCES [dbo].[tblTheLoai] ([maTheLoai]) ,
	[namXuatBan] datetime2(7),
	[triGia] int
	)
	GO
	CREATE TABLE [dbo].[tblQuyDinh](
	[maQuyDinh] [varchar](7) primary key,
	[doTuoiToiThieu] int NOT NULL ,
	[doTuoiToiDa] int NOT NULL,
	[khoangCachNamXuatBan] int NOT NULL,
	[soSachMuonToiDa] int NOT NULL,
	[soNgayMuonToiDa] int NOT NULL	
	)
	GO
	INSERT INTO[dbo].[tblQuyDinh]([maQuyDinh],[doTuoiToiThieu],[doTuoiToiDa],[khoangCachNamXuatBan],[soSachMuonToiDa],[soNgayMuonToiDa] ) VALUES('QD00001',18,	55,8,5,4)
	GO
		
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00001',N'Nhập môn công nghệ phần mềm','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00002',N'Pham nhân tu tiên','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00003',N'Làm giàu','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00004',N'Thức sớm','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00005',N'Người triều châu','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00006',N'Người triều tiên','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00007',N'Người dân tộc','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
INSERT INTO[dbo].[tblSach]([maSach],[TenSach],[ngayNhap],[tacGia],[nhaXuatBan],[maTheLoai],[namXuatBan],[triGia]) VALUES('SA00008',N'Người da đỏ','1998-03-19',N'Trần Thảo Nguyên','A20_P315','ThLo002','2019-1-1',15000)
go
SELECT * FROM [dbo].[tblSach],[dbo].[tblTheLoai]
WHERE [dbo].[tblSach].[maTheLoai]=[dbo].[tblTheLoai].[maTheLoai]
GO

CREATE TABLE [dbo].[tblPhieuMuon](
	[maPhieu] [varchar](7) primary key,
	[maSach] [varchar](7) FOREIGN KEY REFERENCES [dbo].[tblSach] ([maSach]) ,
	[maDocGia] [varchar](7) FOREIGN KEY REFERENCES [dbo].[tblTheDocGia] ([maDocGia]) ,
	[ngayMuon] datetime2(7),
	[thoiHang] int
	)
	GO


INSERT INTO[dbo].[tblPhieuMuon]([maPhieu],[maSach],[maDocGia],[ngayMuon],[thoiHang]) VALUES('Mu00001','SA00001','DG00001','2019-7-1',30)
go
INSERT INTO[dbo].[tblPhieuMuon]([maPhieu],[maSach],[maDocGia],[ngayMuon],[thoiHang]) VALUES('Mu00002','SA00002','DG00003','2019-6-1',30)
go


CREATE TABLE [dbo].[tblPhieuTra](
	[maPhieu] [varchar](7) primary key,
	[maSach] [varchar](7) NOT NULL ,
	[maDocGia] [varchar](7) NOT NULL ,
	[ngayTra] datetime2(7),

	
	)
	GO
ALTER TABLE [tblPhieuTra]
 ADD CONSTRAINT fk_ten
   FOREIGN KEY ([maSach], [maDocGia])
   REFERENCES [tblTheDocGia],[tblSach] ([maSach], [maDocGia]);

--INSERT INTO[dbo].[tblPhieuTra]([maPhieu],[maSach],[maDocGia],[ngayTra]) VALUES('Tr00004','SA00002','DG00004','2019-3-1')
--go
--select * from [tblPhieuTra]
--INSERT INTO[dbo].[tblPhieuTra]([maPhieu],[maSach],[maDocGia],[ngayTra]) VALUES('Tr00001','SA00002','DG00003','2019-3-1')


SELECT * FROM [dbo].[tblPhieuMuon] LEFT JOIN  [dbo].[tblPhieuTra] 
ON [dbo].[tblPhieuMuon].maDocGia=[dbo].[tblPhieuTra].maDocGia 
and [dbo].[tblPhieuMuon].maSach=[dbo].[tblPhieuTra].maSach




select * from [tblPhieuMuon],[tblSach]