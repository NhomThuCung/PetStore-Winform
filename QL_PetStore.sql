CREATE DATABASE QL_PetStore
GO
USE QL_PetStore
GO
ALTER DATABASE QL_PetStore SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE QL_PetStore SET ANSI_NULLS OFF 
GO
ALTER DATABASE QL_PetStore SET ANSI_PADDING OFF 
GO
ALTER DATABASE QL_PetStore SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE QL_PetStore SET ARITHABORT OFF 
GO
ALTER DATABASE QL_PetStore SET AUTO_CLOSE OFF 
GO
ALTER DATABASE QL_PetStore SET AUTO_SHRINK OFF 
GO
ALTER DATABASE QL_PetStore SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE QL_PetStore SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE QL_PetStore SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE QL_PetStore SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE QL_PetStore SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE QL_PetStore SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE QL_PetStore SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE QL_PetStore SET  ENABLE_BROKER 
GO
ALTER DATABASE QL_PetStore SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE QL_PetStore SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE QL_PetStore SET TRUSTWORTHY OFF 
GO
ALTER DATABASE QL_PetStore SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE QL_PetStore SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE QL_PetStore SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE QL_PetStore SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE QL_PetStore SET RECOVERY FULL 
GO
ALTER DATABASE QL_PetStore SET  MULTI_USER 
GO
ALTER DATABASE QL_PetStore SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE QL_PetStore SET DB_CHAINING OFF 
GO
ALTER DATABASE QL_PetStore SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE QL_PetStore SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE QL_PetStore SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QL_PetStore', N'ON'
GO
ALTER DATABASE QL_PetStore SET QUERY_STORE = OFF
GO
USE QL_PetStore
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAdmin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[CMND] [varchar](50) NULL,
	[NgaySinh] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[CreateDate] [date] NULL,
	[MaQuyen] [int] NOT NULL,
	[TienLuong] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giong](
	[MaLoai] [int] NOT NULL,
	[MaGiong] [int] IDENTITY(1,1) NOT NULL,
	[TenGiong] [nvarchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_Giong] PRIMARY KEY CLUSTERED 
(
	[MaGiong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuCung](
	[MaTC] [int] IDENTITY(1,1) NOT NULL,
	[TenTC] [nvarchar](50) NULL,
	[GiaBan] [decimal](18, 0) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[Anh] [nvarchar](max) NULL,
	[NgayCapNhat] [date] NULL,
	[SoLuongTon] [int] NULL,
	[MaGiong] [int] NULL,
	[MaLoai] [int] NULL,
	[Moi] [bit] NULL,
 CONSTRAINT [PK_ThuCung] PRIMARY KEY CLUSTERED 
(
	[MaTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NULL,
	[CreatedDate] [date] NULL,
	[MaKH] [int] NULL,
	[NguoiNhan] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[SoDT] [varchar](20) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[TongTien] [decimal](18, 0) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDH] [int] NOT NULL,
	[MaTC] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[NgaySinh] [date] NULL,
	[CreatedDate] [date] NULL,	
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
--Cập nhập tổng tiền trong bảng chi tiết đơn hàng
CREATE TRIGGER CapNhapThanhTien
on ChiTietDonHang
for insert, update
as
	update ChiTietDonHang
	set THANHTIEN =(select ThuCung.GiaBan * ChiTietDonHang.SoLuong from ThuCung where ChiTietDonHang.MaTC = ThuCung.MaTC )
	where MaDH = (select MaDH from inserted)
go

/*====================================================================================*/
--Cập nhập tổng tiền trong bảng đơn hàng
CREATE TRIGGER CapNhapTongTien4
on DonHang
for insert, update
as
	update DonHang
	set TongTien = (select sum(ThanhTien) from ChiTietDonHang where MaDH = (select MaDH from inserted))
	where MaDH = (select MaDH from inserted)
go

/*====================================================================================*/
--Cập nhập tổng tiền trong bảng chi tiết đơn hàng
create trigger CapNhapTongTien
on ChiTietDonHang
for insert
as
	update DonHang
	set TongTien = (select sum(ThanhTien) from ChiTietDonHang where MaDH = (select MaDH from inserted))
	where MaDH = (select MaDH from inserted)
go
--Cập nhập tổng tiền trong bảng chi tiết đơn hàng
CREATE TRIGGER CapNhapTongTien3
ON ChiTietDonHang 
FOR DELETE
AS
	UPDATE DonHang
	set TongTien = (select sum(ThanhTien) from ChiTietDonHang where MaDH = (select MaDH from deleted))
	where MaDH = (select MaDH from deleted)
GO
--Cập nhập tổng tiền trong bảng chi tiết đơn hàng
create trigger CapNhapTongTien2
on ChiTietDonHang
after update
as
	update DonHang
	set TongTien = TongTien + (select sum(ThanhTien) from inserted where MaDH = DonHang.MaDH) 
					- (select sum(ThanhTien) from deleted where MaDH = DonHang.MaDH) 
	from DonHang join deleted on DonHang.MaDH = deleted.MaDH
go

/*====================================================================================*/
--Cập nhập số lượng thú cưng trong bảng thú cưng
CREATE TRIGGER CapNhapSoLuongThuCung
ON ChiTietDonHang 
FOR INSERT
AS
	UPDATE ThuCung
	set SoLuongTon = (ThuCung.SoLuongTon - (SELECT SoLuong FROM inserted))
	where MaTC = (select MaTC from inserted)
GO
--Cập nhập số lượng thú cưng trong bảng thú cưng
CREATE TRIGGER CapNhapSoLuongThuCung3
ON ChiTietDonHang 
FOR update
AS
	UPDATE ThuCung
	set SoLuongTon = ThuCung.SoLuongTon - (SELECT SoLuong FROM inserted where MaTC = ThuCung.MaTC) 
					+ (SELECT SoLuong FROM deleted where MaTC = ThuCung.MaTC)
	from ThuCung join deleted on ThuCung.MaTC = deleted.MaTC
GO
--Cập nhập số lượng thú cưng trong bảng thú cưng
CREATE TRIGGER CapNhapSoLuongThuCung2
ON ChiTietDonHang 
FOR DELETE
AS
	UPDATE ThuCung
	set SoLuongTon = (ThuCung.SoLuongTon + (SELECT SoLuong FROM deleted))
	where MaTC = (select MaTC from deleted)
GO

/*====================================================================================*/
--Cập nhập tiền lương trong bảng nhân viên
CREATE TRIGGER CapNhapTienLuong
ON DonHang 
FOR INSERT
AS

	UPDATE UserAdmin
	set TienLuong = (TienLuong + ((SELECT COUNT(inserted.MaDH) FROM inserted where inserted.ID = UserAdmin.ID)*20000))
	where ID = (select ID from inserted)
GO
--Cập nhập tiền lương trong bảng nhân viên
CREATE TRIGGER CapNhapTienLuong2
ON DonHang 
FOR DELETE
AS

	UPDATE UserAdmin
	set TienLuong = (TienLuong - ((SELECT COUNT(deleted.MaDH) FROM deleted where deleted.ID = UserAdmin.ID)*20000))
	where ID = (select ID from deleted)
GO
--Cập nhập tiền lương trong bảng nhân viên
CREATE TRIGGER CapNhapTienLuong3
ON DonHang 
FOR update
AS
	UPDATE UserAdmin
	set TienLuong = TienLuong + ((SELECT COUNT(inserted.MaDH) FROM inserted where inserted.ID = UserAdmin.ID)*20000)
					- ((SELECT COUNT(deleted.MaDH) FROM deleted where deleted.ID = UserAdmin.ID)*20000)
	from UserAdmin join deleted on UserAdmin.ID = deleted.ID
GO



/*===========================Mã Hash = 123=========================================================*/
SET IDENTITY_INSERT [dbo].[UserAdmin] ON
INSERT [dbo].[UserAdmin] ([ID], [UserName], [Password], [Name], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong]) 
VALUES (1, N'admin', N'202cb962ac59075b964b07152d234b70', N'Đinh Phát Tài','3009930872', CAST(N'2001-09-30T23:51:19.487' AS DateTime),
N'Ấp 3 Long Cang, Cần Đước, Long An', N'phattai30092001@gmail.com', N'0359975249', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 1 , CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[UserAdmin] ([ID], [UserName], [Password], [Name], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong])
VALUES (2, N'nhanvien1', N'202cb962ac59075b964b07152d234b70', N'Nguyễn Thị Ánh','8247517810', CAST(N'2001-10-04T23:51:19.487' AS DateTime),
N'Ấp 1 Long Cang, Cần Đước, Long An', N'nguyenthia@gmail.com', N'0114226111', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 2 , CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[UserAdmin] ([ID], [UserName], [Password], [Name], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong])
VALUES (3, N'nhanvien2', N'202cb962ac59075b964b07152d234b70', N'Trần Văn Hoàng','2100393548', CAST(N'2001-10-04T23:51:19.487' AS DateTime),
N'Ấp 2 Long Cang, Cần Đước, Long An', N'tranvanf@gmail.com', N'0199493953', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 2 , CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[UserAdmin] ([ID], [UserName], [Password], [Name], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong])
VALUES (4, N'nhanvien3', N'202cb962ac59075b964b07152d234b70', N'Trương Hoàng Chiêu','6036139097', CAST(N'2001-10-04T23:51:19.487' AS DateTime),
N'Ấp 4 Long Cang, Cần Đước, Long An', N'truonghoangc@gmail.com', N'0306602466', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 2 , CAST(3000000 AS Decimal(18, 0)))

SET IDENTITY_INSERT [dbo].[UserAdmin] OFF

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (1, N'Quản Lý')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (2, N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[Loai] ON 
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (1, N'Chó')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (2, N'Mèo')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (3, N'Chim')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (4, N'Hamster')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (5, N'Cá')
SET IDENTITY_INSERT [dbo].[Loai] OFF

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[Giong] ON 
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (1,
1, 
N'Chó Husky',
N'Chó Husky là một giống chó tuyết có nguồn gốc từ Sibir, Nga.
Husky có vẻ đẹp quyến rũ, thân hình dũng mãnh, sức khỏe dẻo dai phi thường.
Là giống chó hiền lành, rất tình cảm, hay tò mò, ưa vận động, rất thích người và đặc biệt thân thiện với trẻ em. 
Ở Việt Nam, chó Husky rất được yêu thích và được săn đón bởi đông đảo những người yêu chó.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (1,
2,
N'Chó Corgi',
N'Chó Corgi là một giống chó nhỏ, chân ngắn nhưng thân dài, đuôi cụt và một đôi tai lớn.
Corgi có vẻ ngoài đáng yêu, cặp mông hình trái tim tạo nên nét quyến rũ và đã tạo nên cơn sốt ngắm mông Corgi.  
Là giống chó rất thông minh, biết vâng lời, có bản năng bảo vệ, rất tận tâm với chủ và thân thiện với trẻ em. 
Chúng rất điềm tĩnh, trung thành và đáng yêu, song rất cảnh giác trước người lạ.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (1,
3,
N'Chó Golden Retriever',
N'Chó Golden Retriever là một giống chó săn thượng hạng đến từ Scotland.
Golden có bộ lông vàng mượt khá sang trọng, khuôn mặt thường xuyên cười vui vẻ, tuy nhiên, lúc buồn lại tỏ vẻ đáng thương rõ ràng.
Là giống chó rất thông minh, dễ huấn luyện, luôn biết cách làm hài lòng chủ nhân và thích vui chơi cùng mọi người.
Golden rất điềm tĩnh, hiền lành và tình cảm, lại rất nhanh nhẹn và năng động.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (1,
4,
N'Chó Pit Bull',
N'Chó Bull hay còn gọi với tên tiếng Anh là American Pit Bull Terrier hay Pit Bull hoặc Dog
Pit Bull Terrier American là một giống chó có nguồn gốc từ Mỹ. Đây là một giống chó có
kích cỡ trung bình đến lớn có nguồn gốc từ dòng chó chọi')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (1,
5,
N'Chó Pug',
N'Pug,
hay thường được gọi là chó mặt xệ, là giống chó thuộc nhóm chó cảnh có nguồn gốc từ Trung Quốc,
chúng có một khuôn mặt nhăn, mõm ngắn, và đuôi xoăn. Giống chó này có bộ lông mịn, bóng, có nhiều màu sắc nhưng phổ biến nhất là màu đen và nâu vàng.
Cơ thể của Pug nhỏ gọn hình vuông với các cơ bắp rất phát triển.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (2,
6,
N'Mèo Anh lông ngắn',
N'Mèo Anh lông ngắn là một giống mèo cảnh có nguồn gốc từ Anh.
Chúng sở hữu một thân hình vô cùng mập mạp đáng yêu, nổi bật với khuôn mặt tròn và bộ lông màu xám xanh cổ điển và một cái đuôi to.
Tính cách của chúng tuy khá lười biếng tuy nhiên lại phù hợp với những người bận rộn không có quá nhiều thời gian và không đòi hỏi chủ nhân của chúng phải chải chuốt vệ sinh thường xuyên.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (2,
7,
N'Mèo Nga lông dài',
N'Mèo Nga lông dài thực chất có nguồn gốc là giống mèo Angora Turkish, có xuất xứ từ Thổ Nhĩ Kỳ.
Mèo Nga sở hữu bộ lông dài trắng muốt như tuyết tuyệt đẹp, tuy nhiên không xù, thân hình nhỏ gọn, thanh thoát và quý phái.
Tính tình thông minh, linh hoạt, quấn chủ và hiền lành, mèo Nga được xem như loại mèo toàn diện nhất.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (2,
8,
N'Mèo Exotic',
N'Mèo lông ngắn Ba Tư hay còn gọi là mèo Exotic hay còn gọi là mèo Ba Tư mặt tịt là giống mèo có nguồn gốc tại Mỹ,
được phát triển trên cơ sở phiên bản của giống mèo Ba Tư. Chúng là giống khá nổi tiếng, đáng yêu và được nhiều người hâm hộ, đặc biệt là nữ giới')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (2,
9,
N'Mèo Ai Cập',
N'Mèo Sphinx hay còn gọi là mèo không lông Sphinx hay còn được biết đến là mèo Canada hoặc mèo Mexico không lông là
một giống mèo được phát triển vào thập niên 1960 với đặc điểm là thân thể trần trụi, không có sợi lông nào. Giống mèo này được coi là một trong những
giống mèo xấu nhất thế giới nhưng lại có giá rất đắt.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (3,
10,
N'Chim họa mi',
N'Có tên khoa học là Garrulux Canorus, chim Họa Mi thường sinh sống ở các khu rừng, vườn cây,
 công viên,… Loài chim cảnh Việt Nam này khá nhỏ bé, chỉ ngang hoặc bé hơn chim Sơn Ca nhưng 
 bù lại chúng là một trong các loại chim hót hay nhất. Bởi vậy mà người ta thường ví các ca sĩ có giọng hát cao là những chú chim họa mi.') 
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (3,
11,
N'Chim vàng anh',
N'Chim Vàng Anh luôn nổi bật với màu lông vàng rực. Chim mái và chim trống sẽ có ánh màu khác nhau đôi chút.
Chim Vàng Anh cũng thuộc các loại chim sâu ở Việt Nam nên thường được nuôi để diệt sâu và trang trí.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (3,
12,
N'Chim sơn ca',
N'Sơn ca hay Sơn ca phương Đông là một loài chim thuộc Họ Sơn ca. Loài này sinh sống ở Nam Á và Đông Nam Á.
 Giống như các loài sơn ca khác, nó được tìm thấy trong khu vực đồng cỏ thưa - thường gần các thuỷ vực - nơi nó ăn hạt và côn trùng.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (3,
13,
N'Chim chào mào',
N'Chào mào là một loài chim thuộc bộ Sẻ phân bố ở châu Á. Nó là một thành viên của họ Chào mào.
Nó là một loài động vật ăn quả thường trú được tìm thấy chủ yếu ở châu Á nhiệt đới. Nó đã được đưa bởi con người 
vào nhiều khu vực nhiệt đới trên thế giới, nơi các quần thể đã tự hình thành. Nó ăn trái cây và côn trùng nhỏ.') 
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (4,
14,
N'Chuột Hamster',
N'Chuột Hamster không phải thuộc loài họ chuột thông thường (họ Chuột) như chuột cống, 
chuột nhắt, chuột đồng... mang nhiều mầm bệnh. Mà chúng thuộc họ Cricetidae, sinh sống ngoài tự nhiên, thường đào hang và có hai túi má để dự trữ thức ăn. ')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (5,
15,
N'Cá ba đuôi',
N'Là loài cá cảnh đẹp thuộc họ cá Chép. Loại cá này dễ thích nghi với điều kiện sống trong bể nuôi
từ kích cỡ nhỏ đến to, hòn non bộ, bể cạn, bể kính…Điểm đặc biệt của cá 3 đuôi là loại cá cảnh nước ngọt dễ nuôi.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (5,
16,
N'Cá chép Nhật(Koi)',
N'Cá Koi là loài cá chép lai tạo, có quan hệ họ hàng gần với cá vàng và được nuôi để làm cảnh.
Cá Koi được cho là loại cá kiểng đẹp dễ nuôi mang lại may mắn, thể hiện triển vọng tương lai và
cơ hội về tài chính. Hồ cá Koi sinh trưởng càng nhiều thì may mắn tiền tài càng sinh sôi.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (5,
17,
N'Cá bảy màu',
N'Cá bảy màu là một trong những loại cá cảnh nước ngọt phổ biến nhất thế giới. Nó là một thành viên nhỏ của họ
Cá khổng tước và giống như các thành viên khác của họ cá này, chúng là dạng cá đẻ trứng thai.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [MoTa]) VALUES (5,
18,
N'Cá Đuôi kiếm',
N'Cá đuôi kiếm là loại cá cảnh với thân hình nhỏ và bầu bĩnh con trống là những con có kỳ trên lưng (vây lưng) dài rất đẹp, 
Cá đuôi kiếm mái thì hầu như quanh năm suốt tháng bụng to tròn vì chúng mang thai và đẻ một cách liên tục')
SET IDENTITY_INSERT [dbo].[Giong] OFF
/*====================================================================================*/

/*====================================================================================*/

SET IDENTITY_INSERT [dbo].[ThuCung] ON 
INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (1,
N'Cá ba đuôi ngũ sắc Loại 1 ', CAST(120000 AS Decimal(18, 0)), N'Nếu bạn đang muốn tìm mua một chú cá Ba Đuôi Ngũ Sắc đẹp,
lộng lẫy mà vẫn chưa tìm được cửa hàng bán cá cảnh đẹp tại TPHCM, thì cửa hàng cá cảnh Trung Tín là địa chỉ
đáng tin cậy để bạn chọn mua. Ngoài cá loại cá cảnh thì cửa hàng hiện đang bán rất nhiều mặc hàng khác nhau
phục vụ cho việc thiết kế một hồ cá cảnh sinh động nhất.',
N'CaBaDuoi_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 15, 5,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (2,
N'Cá ba đuôi ngũ sắc Loại 2', CAST(100000 AS Decimal(18, 0)), N'Nếu bạn đang muốn tìm mua một chú cá Ba Đuôi Ngũ Sắc đẹp,
lộng lẫy mà vẫn chưa tìm được cửa hàng bán cá cảnh đẹp tại TPHCM, thì cửa hàng cá cảnh Trung Tín là địa chỉ
đáng tin cậy để bạn chọn mua. Ngoài cá loại cá cảnh thì cửa hàng hiện đang bán rất nhiều mặc hàng khác nhau
phục vụ cho việc thiết kế một hồ cá cảnh sinh động nhất.',
N'CaBaDuoi_2.png', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 15, 5,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (3,
N'Cá bảy màu', CAST(100000 AS Decimal(18, 0)), N' Là một trong những loài cá cảnh đẹp và phổ biến nhất thế giới, cá bảy màu thu hút người nhìn bởi màu sắc
sặc sỡ cùng nhiều thông tin thú vị xoay quanh nó. Vậy bạn có biết loại cá bảy màu nào hiện nay được người chơi ưa chuộng nhất chưa, hôm nay Trung Tín sẽ giới thiệu
đến bạn một loại cá bảy màu đẹp nhất đang được bày bán tại cửa hàng của chúng tôi đó chính là cá Bảy Màu Tai To.',
N'CaBayMau_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 17, 5,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (4,
N'Cá đuôi kiếm', CAST(500000 AS Decimal(18, 0)), N'Cá đuôi kiếm – Loại cá cảnh phổ biến dễ nuôi dễ chăm sóc
Là loại cá cảnh rất phổ biến nó là loại cá cảnh phổ biến đến mức gần như ai chơi cá cảnh đều đã từng nuôi qua loại này
Cá đuôi kiếm rất dễ nuôi và dễ chăm sóc chúng đẻ rất nhiều nếu ở trong môi trường nước ổn đinh'
,N'CaDuoiKiem_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 18, 5,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (5,
N'Cá Koi Loại 1', CAST(1550000 AS Decimal(18, 0)), N'Cá Koi có nguồn gốc từ Trung Á sau  đó phát triển mạnh, phổ biến tại Trung Quốc và Nhật Bản. 
Vào năm 1950, các chuyên gia sinh học người Nhật được cử đến Trung tâm khoa học Kỹ thuật của trường Đại học Chicago để học hỏi kinh nghiệm và
lai tạo thành công dòng cá Koi. Cá Koi được người Nhật tạo ra có màu sắc vô cùng cuốn hút và có giá thành khá cao. Ban đầu dòng cá Koi khi được
tạo ra được đặt tên là Nishikigoi, mãi đến thế kỷ 19 mới chính thức được đổi tên thành cá Koi.'
,N'CaKoi_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 16, 5,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (6,
N'Cá Koi Loại 2', CAST(1200000 AS Decimal(18, 0)), N'Cá Koi có nguồn gốc từ Trung Á sau  đó phát triển mạnh, phổ biến tại Trung Quốc và Nhật Bản. 
Vào năm 1950, các chuyên gia sinh học người Nhật được cử đến Trung tâm khoa học Kỹ thuật của trường Đại học Chicago để học hỏi kinh nghiệm và
lai tạo thành công dòng cá Koi. Cá Koi được người Nhật tạo ra có màu sắc vô cùng cuốn hút và có giá thành khá cao. Ban đầu dòng cá Koi khi được
tạo ra được đặt tên là Nishikigoi, mãi đến thế kỷ 19 mới chính thức được đổi tên thành cá Koi.'
,N'CaKoi_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 16, 5,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (7,
N'Chim Chào Mào Loại 1', CAST(750000 AS Decimal(18, 0)), N'CChim Chào Mào là loài chim đang ngày càng được lựa chọn nhiều để làm chim cảnh bởi tập tính sinh sống
của chúng phù hợp với điều kiện sống ở nước ta. Cùng với đó là ngoại hình khá bắt mắt và giọng hót rất hay của loài chim cảnh này cũng khiến người chơi thích
thú. Chim Chào Mào cũng rất thân thiện với người nuôi nếu như người nuôi hiểu rõ về tập tính, kỹ thuật và cách chăm sóc chúng.'
,N'ChimChaoMao_1.png', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 13, 3,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (8,
N'Chim Chào Mào Loại 2', CAST(500000 AS Decimal(18, 0)), N'CChim Chào Mào là loài chim đang ngày càng được lựa chọn nhiều để làm chim cảnh bởi tập tính sinh sống
của chúng phù hợp với điều kiện sống ở nước ta. Cùng với đó là ngoại hình khá bắt mắt và giọng hót rất hay của loài chim cảnh này cũng khiến người chơi thích
thú. Chim Chào Mào cũng rất thân thiện với người nuôi nếu như người nuôi hiểu rõ về tập tính, kỹ thuật và cách chăm sóc chúng.'
,N'ChimChaoMao_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 13, 3,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (9,
N'Chim Hoạ Mi Loại 1', CAST(650000 AS Decimal(18, 0)), N'Chim Họa Mi được nhiều người mệnh danh là loài chim có giọng hót tuyệt vời nhất trong tất cả các loài chim rừng.
Cũng chính vì thế mà người nghệ sĩ nào có tông giọng tốt, hát hay đều được so sánh với chim họa mi.'
,N'ChimHoaMi_1.png', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 10, 3,1)
INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (10,
N'Chim Hoạ Mi Loại 2', CAST(500000 AS Decimal(18, 0)), N'Chim Họa Mi được nhiều người mệnh danh là loài chim có giọng hót tuyệt vời nhất
trong tất cả các loài chim rừng. Cũng chính vì thế mà người nghệ sĩ nào có tông giọng tốt, hát hay đều được so sánh với chim họa mi.'
,N'ChimHoaMi_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 10, 3,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (11,
N'Chim Sơn Ca', CAST(500000 AS Decimal(18, 0)), N'Chim sơn ca là một trong những loài chim cảnh, được yêu thích nhất tại Việt Nam hiện nay.
Trước khi có ý định nuôi 1 chú chim sơn ca, các bạn nên tìm hiểu rõ về đặc điểm và đặc tính của chúng.'
,N'ChimSonCa_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 12, 3,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (12,
N'Chim Vàng Anh Loại 1', CAST(1660000 AS Decimal(18, 0)), N'Trước khi tìm hiểu chim vàng anh ăn gì thì bạn cần biết được nguồn gốc xuất xứ và đặc điểm của loài
chim này. Vàng anh tên hay còn được gọi là chim hoàng anh, đây là loài duy nhất thuộc họ Vàng anh, bộ sẻ, sinh sống chủ yếu ở khu vực ôn đới của Bắc bán cầu.
Loài chim này có tập tính di cư, mùa hè nó sẽ di cư đến những khu vực Châu Âu và Châu Á, mùa đông nó sẽ di cư đến khu vực nhiệt đới.'
,N'ChimVangAnh_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 11, 3,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (13,
N'Chim Vàng Anh Loại 2', CAST(1500000 AS Decimal(18, 0)), N'Trước khi tìm hiểu chim vàng anh ăn gì thì bạn cần biết được nguồn gốc xuất xứ và đặc điểm của loài
chim này. Vàng anh tên hay còn được gọi là chim hoàng anh, đây là loài duy nhất thuộc họ Vàng anh, bộ sẻ, sinh sống chủ yếu ở khu vực ôn đới của Bắc bán cầu.
Loài chim này có tập tính di cư, mùa hè nó sẽ di cư đến những khu vực Châu Âu và Châu Á, mùa đông nó sẽ di cư đến khu vực nhiệt đới.'
,N'ChimVangAnh_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 11, 3,1)


INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (14,
N'Chó Corgi Loại 1', CAST(8550000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
rãi và Việt Nam cũng không ngoại lệ.'
,N'ChoCogri.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 2, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (15,
N'Chó Corgi Loại 2', CAST(7000000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
rãi và Việt Nam cũng không ngoại lệ.'
,N'ChoCorgi_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 2, 1,1)
INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (16,
N'Chó Corgi Loại 3', CAST(6350000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
rãi và Việt Nam cũng không ngoại lệ.'
,N'ChoCorgi_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 2, 1,1)
INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (17,
N'Chó Corgi Thuần Chủng', CAST(12000000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
rãi và Việt Nam cũng không ngoại lệ.'
,N'ChoCorgi_6.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 2, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (18,
N'Chó Golden Loại 1', CAST(12500000 AS Decimal(18, 0)), N'Hiện nay trên thị trường, có rất nhiều trại chó chuyên về giống Golden Retriever thuần chủng.
Những chú chó Golden sinh tại Việt Nam có mức giá rất hợp lý, dao động từ 6-8 triệu/ con. Rất nhiều người nuôi tỏ ra hài lòng với mức giá này. 
Bởi chỉ với vài triệu họ có thể sở hữu được một chú chó cực kỳ thông minh, trung thành, thân thiện.'
,N'ChoGoldenRetriever_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 3, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (19,
N'Chó Golden Thuần Chủng', CAST(14500000 AS Decimal(18, 0)), N'Hiện nay trên thị trường, có rất nhiều trại chó chuyên về giống Golden Retriever thuần chủng.
Những chú chó Golden sinh tại Việt Nam có mức giá rất hợp lý, dao động từ 6-8 triệu/ con. Rất nhiều người nuôi tỏ ra hài lòng với mức giá này. 
Bởi chỉ với vài triệu họ có thể sở hữu được một chú chó cực kỳ thông minh, trung thành, thân thiện.'
,N'ChoGoldenRetriever_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 3, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (20,
N'Chó Husky Loại 1', CAST(7500000 AS Decimal(18, 0)), N'Chó Husky tên quốc tế là Siberian Husky hay chó Husky Sibir là giống chó nhà được phát triển bởi bộ tộc 
Chukchi hơn 3000 năm trước và hoàn toàn không phải lai giữa chó và Sói.
Người Chukchi đã sử dụng chó Husky để kéo xe trượt tuyết và họ xem chúng như một thành viên trong gia đình. Do đó chúng còn được 
gọi là chó tuyết trắng, chó bạch tuyết hay chó kéo xe tuyết.'
,N'ChoHusky_6.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 1, 1,1)


INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (21,
N'Chó Husky Xám', CAST(8900000 AS Decimal(18, 0)), N'Chó Husky tên quốc tế là Siberian Husky hay chó Husky Sibir là giống chó nhà được phát triển bởi bộ tộc 
Chukchi hơn 3000 năm trước và hoàn toàn không phải lai giữa chó và Sói.
Người Chukchi đã sử dụng chó Husky để kéo xe trượt tuyết và họ xem chúng như một thành viên trong gia đình. Do đó chúng còn được 
gọi là chó tuyết trắng, chó bạch tuyết hay chó kéo xe tuyết.'
,N'ChoHusky1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 1, 1,1)


INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (22,
N'Chó Husky Thuần Chủng', CAST(12500000 AS Decimal(18, 0)), N'Chó Husky tên quốc tế là Siberian Husky hay chó Husky Sibir là giống chó nhà được phát triển bởi bộ tộc 
Chukchi hơn 3000 năm trước và hoàn toàn không phải lai giữa chó và Sói.
Người Chukchi đã sử dụng chó Husky để kéo xe trượt tuyết và họ xem chúng như một thành viên trong gia đình. Do đó chúng còn được 
gọi là chó tuyết trắng, chó bạch tuyết hay chó kéo xe tuyết.'
,N'ChoHusky2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 1, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (23,
N'Chó Pit Bull America', CAST(85000000 AS Decimal(18, 0)), N'Thực tế đã xảy ra rất nhiều vụ tai nạn do chó Pitbull gây ra khiến đa phần người Việt “tẩy chay” chúng.
Tuy nhiên vẫn có rất nhiều người chọn nuôi Pitbull bởi đam mê và bởi họ biết một sự thật rằng, mọi người đang đánh đồng, hiểu sai về người bạn này.'
,N'ChoPitBull_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 4, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (24,
N'Chó Pit Bull Loại 1', CAST(65000000 AS Decimal(18, 0)), N'Thực tế đã xảy ra rất nhiều vụ tai nạn do chó Pitbull gây ra khiến đa phần người Việt “tẩy chay” chúng.
Tuy nhiên vẫn có rất nhiều người chọn nuôi Pitbull bởi đam mê và bởi họ biết một sự thật rằng, mọi người đang đánh đồng, hiểu sai về người bạn này.'
,N'ChoPitBull_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 4, 1,1)


INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (25,
N'Chó Pug Thuần Chủng', CAST(6000000 AS Decimal(18, 0)), N'Chó Pug mặt xệ là giống cảnh khuyển có lịch sử lâu đời. Xuất xứ của chúng đến nay vẫn chưa có câu trả lời
chính xác. Khả năng cao nhất, Pug đã có mặt từ thời nhà Hán – Trung Quốc vào khoảng năm 200 TCN. Khi ấy, Pug được coi là giống thú cảnh quý tộc, có cuộc sống xa hoa bởi chủ yếu được hoàng thân, quốc thích Trung Quốc nuôi dưỡng.'
,N'ChoPug_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 5, 1,1)


INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (26,
N'Chó Pug Con', CAST(4000000 AS Decimal(18, 0)), N'Chó Pug mặt xệ là giống cảnh khuyển có lịch sử lâu đời. Xuất xứ của chúng đến nay vẫn chưa có câu trả lời
chính xác. Khả năng cao nhất, Pug đã có mặt từ thời nhà Hán – Trung Quốc vào khoảng năm 200 TCN. Khi ấy, Pug được coi là giống thú cảnh quý tộc, có cuộc sống xa hoa bởi chủ yếu được hoàng thân, quốc thích Trung Quốc nuôi dưỡng.'
,N'ChoPug_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 5, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (27,
N'Chó Pug Loại 1', CAST(3500000 AS Decimal(18, 0)), N'Chó Pug mặt xệ là giống cảnh khuyển có lịch sử lâu đời. Xuất xứ của chúng đến nay vẫn chưa có câu trả lời
chính xác. Khả năng cao nhất, Pug đã có mặt từ thời nhà Hán – Trung Quốc vào khoảng năm 200 TCN. Khi ấy, Pug được coi là giống thú cảnh quý tộc, có cuộc sống xa hoa bởi chủ yếu được hoàng thân, quốc thích Trung Quốc nuôi dưỡng.'
,N'ChoPug_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 5, 1,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (28,
N'Chuột Hamster', CAST(350000 AS Decimal(18, 0)), N'Chuột Hamster hiện nay có khoảng 26 loài, tuy nhiên giống chuột được biết đến nhiều nhất là chuột Hamster
Syria. Chúng được phát hiện lần đầu vào năm 1839 bởi một nhà động vật học người Anh tên là George Robert Waterhouse, ông đã đặt tên loài chuột kỳ lạ này là
Mesocricetus auratus, có nghĩa là lông vàng.'
,N'ChuotHamster_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 14, 4,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (29,
N'Mèo Ai Cập Loại 1', CAST(45000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
,N'MeoAiCap_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 9, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (30,
N'Mèo Ai Cập Mắt Vàng', CAST(170000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
,N'MeoAiCap_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 9, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (31,
N'Mèo Ai Cập Mắt Vàng 2', CAST(112000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
,N'MeoAiCap_3.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 9, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (32,
N'Mèo Ai Cập', CAST(40000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
,N'MeoAiCap_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 9, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (33,
N'Mèo Ai Cập Chuẩn', CAST(135000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
,N'MeoAiCap_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 9, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (34,
N'Mèo Anh Long Ngắn Thuần Chủng', CAST(7500000 AS Decimal(18, 0)), N'Mèo Anh là giống mèo phổ biến có nguồn gốc từ nước Anh. Xuất hiên từ nhưng
năm cuối thế kỉ 19 và trải qua một khoảng thời gian dài lai tạo để có những đặc tính tốt nhất. Hiện nay chúng đã được nuôi rất phổ biến trong các gia đình trên khắp thế giới, Việt Nam cũng không ngoại lệ.
Có hai dòng mèo Anh phố biến nhất là Anh lông ngắn (ALN) và Anh lông dài (ALD).'
,N'MeoAnhLongNgan_3.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 6, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (35,
N'Mèo Anh Long Ngắn Loại 1', CAST(6000000 AS Decimal(18, 0)), N'Mèo Anh là giống mèo phổ biến có nguồn gốc từ nước Anh. Xuất hiên từ nhưng
năm cuối thế kỉ 19 và trải qua một khoảng thời gian dài lai tạo để có những đặc tính tốt nhất. Hiện nay chúng đã được nuôi rất phổ biến trong các gia đình trên khắp thế giới, Việt Nam cũng không ngoại lệ.
Có hai dòng mèo Anh phố biến nhất là Anh lông ngắn (ALN) và Anh lông dài (ALD).'
,N'MeoAnhLongNgan_4.png', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 6, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (36,
N'Mèo Anh Long Ngắn', CAST(5500000 AS Decimal(18, 0)), N'Mèo Anh là giống mèo phổ biến có nguồn gốc từ nước Anh. Xuất hiên từ nhưng
năm cuối thế kỉ 19 và trải qua một khoảng thời gian dài lai tạo để có những đặc tính tốt nhất. Hiện nay chúng đã được nuôi rất phổ biến trong các gia đình trên khắp thế giới, Việt Nam cũng không ngoại lệ.
Có hai dòng mèo Anh phố biến nhất là Anh lông ngắn (ALN) và Anh lông dài (ALD).'
,N'MeoAnhLongNgan_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 6, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (37,
N'Mèo Exotic', CAST(9000000 AS Decimal(18, 0)), N'Bạn yêu thích một chú Mèo Ba Tư sang trọng nhưng lại không có đủ thời gian săn sóc kĩ lưỡng cho bộ lông 
của chúng? Hãy thử làm bạn với mèo Exotic là giống mèo còn khá mới, có nguồn gốc từ Ba Tư thuần chủng lai với mèo Mỹ lông ngắn vào những năm 1950. 
Do có khuôn mặt, thân hình, tính cách và cả các bệnh di truyền giống hệt mèo Ba Tư nên giới yêu mèo thường gọi mèo Exotic là mèo Ba Tư lông ngắn.'
,N'MeoExotic_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 8, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (38,
N'Mèo Nga Long Dài Thuần Chủng', CAST(5200000 AS Decimal(18, 0)), N'Đúng với tên gọi của mình, mèo Nga thuần chủng có xuất xứ từ đất nước Russian 
nhưng điều đặc biệt làm nên vẻ hấp dẫn của giống loài này không chỉ dừng lại ở đấy.
Vào cuối thế kỉ 19, người ta tìm thấy loài mèo này tại nước Nga với thân hình nhỏ bé, bộ lông ngắn ôm sát và màu sắc rất riêng biệt.
mèo nga mắt 2 màuTại 1 cuộc triển lãm thường niên dành cho loài mèo được tổ chức vào năm 1875.'
,N'MeoNgaLongDai_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 7, 2,1)

INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [NgayCapNhat], [SoLuongTon], [MaGiong], [MaLoai], [Moi]) VALUES (39,
N'Mèo Nga Long Dài', CAST(2400000 AS Decimal(18, 0)), N'Đúng với tên gọi của mình, mèo Nga thuần chủng có xuất xứ từ đất nước Russian 
nhưng điều đặc biệt làm nên vẻ hấp dẫn của giống loài này không chỉ dừng lại ở đấy.
Vào cuối thế kỉ 19, người ta tìm thấy loài mèo này tại nước Nga với thân hình nhỏ bé, bộ lông ngắn ôm sát và màu sắc rất riêng biệt.
mèo nga mắt 2 màuTại 1 cuộc triển lãm thường niên dành cho loài mèo được tổ chức vào năm 1875.'
,N'MeoNgaLongDai_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), 100, 7, 2,1)
SET IDENTITY_INSERT [dbo].[ThuCung] OFF

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[DonHang] ON 
INSERT [dbo].[DonHang] ([MaDH], [ID], [CreatedDate], [MaKH], [NguoiNhan], [Email], [SoDT], [DiaChi], [TongTien], [Status]) VALUES (1, 2,
CAST(N'2021-12-01T23:51:19.487' AS DateTime), 2, N'Nguyễn Văn Dao', N'nguyenvandao@gmail.com', N'0425343423', N'Ấp 3 Long Cang, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[DonHang] ([MaDH], [ID], [CreatedDate], [MaKH], [NguoiNhan], [Email], [SoDT], [DiaChi], [TongTien], [Status]) VALUES (2, 2,
CAST(N'2021-12-02T23:51:19.487' AS DateTime), 1, N'Nguyễn Văn Cảnh', N'nguyenvanccanh@gmail.com', N'0417237280', N'Ấp 11 Long Định, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[DonHang] ([MaDH], [ID], [CreatedDate], [MaKH], [NguoiNhan], [Email], [SoDT], [DiaChi], [TongTien], [Status]) VALUES (3, 3,
CAST(N'2021-12-03T23:51:19.487' AS DateTime), 3, N'Nguyễn Thị Anh', N'nguyenthianh@gmail.com', N'0132003781', N'Ấp 11 Long Định, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[DonHang] ([MaDH], [ID], [CreatedDate], [MaKH], [NguoiNhan], [Email], [SoDT], [DiaChi], [TongTien], [Status]) VALUES (4, 4,
CAST(N'2021-12-04T23:51:19.487' AS DateTime), 4, N'Trần Hoàng Anh', N'tranvananh@gmail.com', N'0870063999', N'Ấp 11 Long Định, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 1)

SET IDENTITY_INSERT [dbo].[DonHang] OFF

/*====================================================================================*/
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (1, 1, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (1, 12, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (1, 17, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (2, 2, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (2, 4, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (2, 13, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (2, 7, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (3, 16, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (3, 15, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (3, 10, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (3, 11, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (4, 12, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (4, 13, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (4, 1, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (4, 2, 5, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (4, 16, 5, CAST(25000000 AS Decimal(18, 0)))

/*================================Mã Hash = 123456 ====================================================*/

SET IDENTITY_INSERT [dbo].[KhachHang] ON 
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (1,
N'Nguyễn Văn Cảnh', N'nguyenvanc', N'e10adc3949ba59abbe56e057f20f883e', N'nguyenvanc@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0981234567', N'Nam', CAST(N'1987-10-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (2,
N'Nguyễn Văn Dao', N'nguyenvand', N'e10adc3949ba59abbe56e057f20f883e', N'nguyenvand@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0429333883', N'Nam', CAST(N'1980-11-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (3,
N'Nguyễn Thị Anh', N'nguyenthia', N'e10adc3949ba59abbe56e057f20f883e', N'nguyenthia@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0226998718', N'Nữ', CAST(N'1995-01-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (4,
N'Nguyễn Trần Hoàng', N'nguyentranhoang', N'e10adc3949ba59abbe56e057f20f883e', N'nguyentranhoang@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0227254554', N'Nam', CAST(N'1994-02-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [DiaChi], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (5,
N'Trần Hoàng Anh', N'tranhoanganh', N'e10adc3949ba59abbe56e057f20f883e', N'tranhoanganh@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0995245398', N'Nam', CAST(N'1993-03-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[KhachHang] OFF


/*====================================================================================*/
--Đặt lại mật khẩu nhân viên
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DatLaiMatKhau]
@ID int
AS
BEGIN
	UPDATE dbo.UserAdmin
	SET
	     --Mật khẩu là 123
	    dbo.UserAdmin.Password = N'202cb962ac59075b964b07152d234b70' -- varchar
	WHERE dbo.UserAdmin.ID = @ID
END
GO

/*====================================================================================*/
--Đổi mật khẩu nhân viên
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DoiMatKhau]
@ID int,
@matkhaumoi varchar(1000)
AS
BEGIN
	UPDATE dbo.UserAdmin
	SET
	    dbo.UserAdmin.Password = @matkhaumoi
	WHERE dbo.UserAdmin.ID = @ID
END
GO

/*====================================================================================*/
--Lấy thông tin gắn vào panelHome
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayThongTinTong]
@manv int,
@thang int,
@nam int
AS
BEGIN
	DECLARE @thucung int = 0
	DECLARE @donhang int = 0
	DECLARE @khachhang int = 0
	DECLARE @doanhthu float = 0
	DECLARE @quyen int
	
	SELECT @quyen = dbo.UserAdmin.MaQuyen FROM dbo.UserAdmin WHERE dbo.UserAdmin.ID = @manv

	SELECT @thucung = count(dbo.ThuCung.MaTC) FROM dbo.ThuCung

	IF (@quyen=1) 
	BEGIN 
		SELECT @donhang = count(dbo.DonHang.MaDH) FROM dbo.DonHang WHERE month(dbo.DonHang.CreatedDate) = @thang AND year(dbo.DonHang.CreatedDate) = @nam
		SELECT @khachhang = count(dbo.KhachHang.MaKH) FROM dbo.KhachHang
		SELECT @doanhthu= (sum(dbo.DonHang.TongTien)) FROM dbo.DonHang WHERE dbo.DonHang.Status = 'True'
		AND month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam
	END 
	ELSE 
	BEGIN 
		SELECT @donhang = count(dbo.DonHang.MaDH) FROM dbo.DonHang WHERE month(dbo.DonHang.CreatedDate)=@thang 
				AND dbo.DonHang.ID = @manv AND year(dbo.DonHang.CreatedDate) = @nam
		SELECT @khachhang = count(dbo.KhachHang.MaKH) FROM dbo.KhachHang
		SELECT @doanhthu=(sum(dbo.DonHang.TongTien)) FROM dbo.DonHang WHERE dbo.DonHang.Status = 'True'
		AND month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam AND dbo.DonHang.ID = @manv
	END 
		
	SELECT @thucung AS [SoThuCung], @donhang AS [SoHoaDon], @khachhang AS [SoKhachHang], iif(@doanhthu>=0,@doanhthu,0) AS [DoanhThu]
END
GO

/*====================================================================================*/
--Lấy doanh thú gắn vào panelHome
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_BaoCaoDoanhThuCuaHang]
@maNV int,
@thang int,
@nam int
AS
BEGIN
	DECLARE @quyen int
	SELECT @quyen = dbo.UserAdmin.MaQuyen FROM dbo.UserAdmin WHERE dbo.UserAdmin.ID = @manv
	IF (@quyen=1) 
	BEGIN
		SELECT dbo.DonHang.CreatedDate AS [NgayBan], sum((dbo.DonHang.TongTien)) AS [DoanhThu] FROM dbo.DonHang 
		WHERE month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam AND dbo.DonHang.Status = 'True'
		GROUP BY dbo.DonHang.CreatedDate
	END
	ELSE 
	BEGIN 
		SELECT dbo.DonHang.CreatedDate AS [NgayBan], sum((dbo.DonHang.TongTien)) AS [DoanhThu] FROM dbo.DonHang 
		WHERE month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam AND dbo.DonHang.ID = @manv AND dbo.DonHang.Status = 'True'
		GROUP BY dbo.DonHang.CreatedDate
	END 
END
GO

/*====================================================================================*/
--Thống kê doanh thu
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ThongKeDoanhThuCuaHang]
@frmdate date,
@todate date
AS
BEGIN
	BEGIN
		SELECT dbo.DonHang.CreatedDate AS [NgayBan], sum((dbo.DonHang.TongTien)) AS [DoanhThu] FROM dbo.DonHang 
		WHERE dbo.DonHang.CreatedDate >= @frmdate AND dbo.DonHang.CreatedDate <= @todate AND dbo.DonHang.Status = 'True'
		GROUP BY dbo.DonHang.CreatedDate
	END
END
GO

/*====================================================================================*/
--Thống kê doanh thu
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ThongKeDonHang]
@frmdate date,
@todate date
AS 
BEGIN
	BEGIN
		SELECT top 10 dbo.DonHang.MaDH , dbo.DonHang.CreatedDate, sum(dbo.ChiTietDonHang.SoLuong) AS [SoLuongBan], sum((dbo.ChiTietDonHang.ThanhTien)) AS [DoanhThu] 
		FROM dbo.DonHang, dbo.ChiTietDonHang
		WHERE dbo.DonHang.MaDH = dbo.ChiTietDonHang.MaDH AND dbo.DonHang.CreatedDate >= @frmdate 
			AND dbo.DonHang.CreatedDate <= @todate AND dbo.DonHang.Status = 'True'
		GROUP BY dbo.DonHang.MaDH , dbo.DonHang.CreatedDate
		ORDER BY [DoanhThu] DESC;
	END
END
GO

/*====================================================================================*/
--Thống kê doanh thu
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ThongKeThuCungBanChay]
@frmdate date,
@todate date
AS
BEGIN
	BEGIN
		SELECT TOP 10 dbo.ThuCung.MaTC, dbo.ThuCung.TenTC, dbo.ThuCung.GiaBan, sum(dbo.ChiTietDonHang.SoLuong) AS [SoLuongBan], dbo.ThuCung.SoLuongTon 
		FROM dbo.ThuCung, dbo.ChiTietDonHang, dbo.DonHang
		WHERE dbo.ThuCung.MaTC=dbo.ChiTietDonHang.MaTC AND dbo.DonHang.MaDH=dbo.ChiTietDonHang.MaDH 
			AND dbo.DonHang.CreatedDate >= @frmdate AND dbo.DonHang.CreatedDate <= @todate AND dbo.DonHang.Status = 'True'
		GROUP BY dbo.ThuCung.MaTC, dbo.ThuCung.TenTC, dbo.ThuCung.GiaBan, dbo.ThuCung.SoLuongTon
		ORDER BY [SoLuongBan] DESC;
	END
END
GO

/*====================================================================================*/

ALTER TABLE [dbo].[UserAdmin]  WITH CHECK ADD  CONSTRAINT [FK_UserAdmin_PhanQuyen] FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[PhanQuyen] ([MaQuyen])
GO

ALTER TABLE [dbo].[UserAdmin] CHECK CONSTRAINT [FK_UserAdmin_PhanQuyen]
GO

ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_UserAdmin] FOREIGN KEY([ID])
REFERENCES [dbo].[UserAdmin] ([ID])
GO

ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_UserAdmin]
GO

ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_ThuCung] FOREIGN KEY([MaTC])
REFERENCES [dbo].[ThuCung] ([MaTC])
GO

ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_ThuCung]
GO

ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO

ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO

ALTER TABLE [dbo].[Giong]  WITH CHECK ADD  CONSTRAINT [FK_Giong_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO

ALTER TABLE [dbo].[Giong] CHECK CONSTRAINT [FK_Giong_Loai]
GO

ALTER TABLE [dbo].[ThuCung]  WITH CHECK ADD  CONSTRAINT [FK_ThuCung_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO

ALTER TABLE [dbo].[ThuCung] CHECK CONSTRAINT [FK_ThuCung_Loai]
GO

ALTER TABLE [dbo].[ThuCung]  WITH CHECK ADD CONSTRAINT [FK_ThuCung_Gionggggg] FOREIGN KEY([MaGiong])
REFERENCES [dbo].[Giong] ([MaGiong])
GO

ALTER TABLE [dbo].[ThuCung] CHECK CONSTRAINT [FK_ThuCung_Gionggggg]
GO

ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO

ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO

-------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------BACKUP--------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------

--BACKUP DATABASE QL_PetStore
--TO DISK = 'C:\backupsql\Test_FULL.bak'
--WITH INIT

---- Thêm một bản ghi mới 
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (1, 3, 5, CAST(25000000 AS Decimal(18, 0)))

--BACKUP LOG QL_PetStore 
--TO DISK = 'C:\backupsql\Test_TRAN.trn'
--WITH INIT

---- Thêm một bản ghi mới 
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (1, 4, 5, CAST(25000000 AS Decimal(18, 0)))

---- Thời điểm t3: Log Backup
--BACKUP LOG QL_PetStore 
--TO DISK = 'C:\backupsql\Test_TRAN.trn'

---- Thêm một bản ghi mới 
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (1, 6, 5, CAST(25000000 AS Decimal(18, 0)))

---- Thời điểm t4: Differential backup
--BACKUP DATABASE QL_PetStore 
--TO DISK = 'C:\backupsql\Test_DIFF.bak' 
--WITH INIT, DIFFERENTIAL

---- Thời điểm t5: Log Backup
--BACKUP LOG QL_PetStore 
--TO DISK = 'C:\backupsql\Test_TRAN.trn' 
--WITH INIT

---- Thêm một bản ghi mới 
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [SoLuong], [ThanhTien]) VALUES (1, 8, 5, CAST(25000000 AS Decimal(18, 0)))

---- Giả sử sau đó xảy ra sự cố, ta mô phỏng sự việc này bằng cách xóa CSDL:

----Khôi phục
---- Bước 1: Khôi phục từ bản Full Backup 
--RESTORE DATABASE QL_PetStore 
--FROM DISK = 'C:\backupsql\Test_FULL.bak' 
--WITH NORECOVERY   
---- Bước 2: Khôi phục từ bản Differential Backup 
--RESTORE DATABASE QL_PetStore 
--FROM DISK = 'C:\backupsql\Test_DIFF.bak' 
--WITH NORECOVERY  
---- Bước 3: Khôi phục từ các bản Log Backup kể từ sau lần Diferential Backup gần nhất 

--RESTORE DATABASE QL_PetStore 
--FROM DISK = 'C:\backupsql\Test_TRAN.trn' 
--WITH FILE = 1, NORECOVERY

--RESTORE DATABASE QL_PetStore 
--FROM DISK = 'C:\backupsql\Test_TRAN.trn'
--WITH FILE=2, RECOVERY

