alter database NguyenThanhDatDB set single_user with rollback immediate
USE master
GO
IF EXISTS(SELECT name FROM sysdatabases WHERE name ='NguyenThanhDatDB')
DROP DATABASE NguyenThanhDatDB
go
--Văn phòng phẩm
-----------------------------------------
CREATE DATABASE NguyenThanhDatDB
GO
USE NguyenThanhDatDB
CREATE TABLE UserAccount(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL UNIQUE,
	Password VARCHAR(50) NOT NULL,
	Status BIT NULL DEFAULT 1,
	UserType tinyint
)
GO 
CREATE TABLE Category(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Metatitle VARCHAR(250) NULL,
	Name NVARCHAR(255) NULL,
	Description NTEXT NULL
)
GO
CREATE TABLE Product(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	Metatitle VARCHAR(250) NULL,
	UniqueCost DECIMAL(18,0) NULL,
	Quantity INT NULL,
	Image TEXT NULL,
	Description NTEXT NULL,
	Status BIT DEFAULT 1 NOT NULL,
	CategoryID INT FOREIGN KEY (CategoryID) REFERENCES dbo.Category(ID) NOT NULL,
	Author NVARCHAR(255) NULL,
)
CREATE TABLE Menu(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Link NVARCHAR(250) NULL,
	DisplayOrder INT NULL,
	Target VARCHAR(50) NULL,
	Status BIT NULL DEFAULT 'True'
)
------
--Chèn dữ liệu
------

INSERT INTO dbo.UserAccount (UserName, Password, UserType)
VALUES
		('admin', '21232f297a57a5a743894a0e4a801fc3',0),
		('nhanvien1', 'fcf321d09609565b7a1ce6e70f1f5056',0),
		('nhanvien2', 'df88847550ee279705c6d17ce56c61d2', 0),
		('nhanvien3', '966a34a847b0022de3d683a1e43ff4f6', 0),
		('nhanvien4', '75ec368af32c3ba04f6abae2e45558b5', 0),
		('khachhang1', 'd87607769cb8cca82dd377ed39a5dbdf', 1),
		('khachhang2', '8c5de8ab1cc0db8b958489ce5194295b', 1),
		('khachhang3', 'ff909201220b2783d04ae499c25ab58a', 1),
		('khachhang4', '5d31ca66a19626df612b808fb9fdb5c6', 1)

GO
INSERT INTO dbo.Category(Name, Metatitle)
VALUES	(N'Sách thiếu nhi', ''),
		(N'Sách văn học', ''),
		(N'Sách kĩ năng sống', ''),
		(N'Sách kinh tế', '')

GO
INSERT INTO dbo.Product(Name,Metatitle, UniqueCost, Quantity, Image, Description, CategoryID, Author)
VALUES	(N'Combo Bộ 10 Cuốn - Nhật Ký Trưởng Thành Của Đứa Trẻ Ngoan (Hộp)','', '317500', '100', '/Assets/Admin/images/book.jpg', N'', '1', N'Nhiều người dịch'),
(N'10 vạn câu hỏi vì sao - trọn bộ 5 tập','', '137500', '100', '/Assets/Admin/images/book.jpg', N'', '1', N'Nhiều nhiều tác giả'),
(N'POMath - Toán Tư Duy Cho Trẻ Em 4-6 Tuổi (Tập 1)','', '70290', '100', '/Assets/Admin/images/book.jpg', N'', '1', N'Nhiều người dịch'),
(N'Dế Mèn Phiêu Lưu Ký (Tái Bản 2019)','', '37500', '100', '/Assets/Admin/images/book.jpg', N'', '1', N'Tô Hoài')

INSERT INTO dbo.Menu(Name, Link, DisplayOrder, Target, Status)
VALUES
(N'Trang Chủ','/', 1 , '_blank','True'),
(N'Sách','/book', 2 , '_blank','True'),
(N'Truyện','/story', 3 , '_blank','True'),
(N'Văn Phòng Phẩm','/vpp', 4 , '_blank','True')