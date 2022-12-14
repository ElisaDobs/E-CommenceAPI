USE [master]
GO
/****** Object:  Database [BetSoftwareDB]    Script Date: 2022/08/25 20:20:51 ******/
CREATE DATABASE [BetSoftwareDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BetSoftwareDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BetSoftwareDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BetSoftwareDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BetSoftwareDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BetSoftwareDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BetSoftwareDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BetSoftwareDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BetSoftwareDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BetSoftwareDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BetSoftwareDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BetSoftwareDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BetSoftwareDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BetSoftwareDB] SET  MULTI_USER 
GO
ALTER DATABASE [BetSoftwareDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BetSoftwareDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BetSoftwareDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BetSoftwareDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BetSoftwareDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BetSoftwareDB] SET QUERY_STORE = OFF
GO
USE [BetSoftwareDB]
GO
USE [BetSoftwareDB]
GO
/****** Object:  Sequence [dbo].[NumericSequence]    Script Date: 2022/08/25 20:20:51 ******/
CREATE SEQUENCE [dbo].[NumericSequence] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2022/08/25 20:20:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[ProductImage] [varchar](255) NOT NULL,
	[ProductPrice] [money] NOT NULL,
	[ProductQuantity] [int] NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy_UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 2022/08/25 20:20:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderNo] [varchar](15) NULL,
	[UserId] [int] NOT NULL,
	[DateCreated] [datetime] NULL,
	[OrderSequence] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2022/08/25 20:20:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[UserEmail] [varchar](100) NOT NULL,
	[UserPassword] [nvarchar](100) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductImage], [ProductPrice], [ProductQuantity], [DateCreated], [CreatedBy_UserId]) VALUES (1, N'Laptop', N'https://localhost:44312/Images/laptop.jpg', 4000.0000, 18, CAST(N'2022-08-23T02:47:14.677' AS DateTime), 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductImage], [ProductPrice], [ProductQuantity], [DateCreated], [CreatedBy_UserId]) VALUES (2, N'Watch', N'https://localhost:44312/Images/watch.jpg', 3000.0000, 16, CAST(N'2022-08-24T23:42:50.010' AS DateTime), 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductImage], [ProductPrice], [ProductQuantity], [DateCreated], [CreatedBy_UserId]) VALUES (3, N'Phone', N'https://localhost:44312/Images/phone.jpg', 8500.0000, 18, CAST(N'2022-08-24T23:43:27.493' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductOrder] ON 

INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (1, 3, N'Order #1', 1, CAST(N'2022-08-25T15:51:58.870' AS DateTime), 1)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (2, 1, N'Order #2', 1, CAST(N'2022-08-25T15:52:55.183' AS DateTime), 2)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (3, 2, N'Order #2', 1, CAST(N'2022-08-25T15:52:55.200' AS DateTime), 2)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (4, 1, N'Order #3', 1, CAST(N'2022-08-25T15:54:53.267' AS DateTime), 3)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (5, 3, N'Order #3', 1, CAST(N'2022-08-25T15:54:53.520' AS DateTime), 3)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (6, 3, N'Order #4', 1, CAST(N'2022-08-25T15:57:57.103' AS DateTime), 4)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (7, 2, N'Order #4', 1, CAST(N'2022-08-25T15:57:57.320' AS DateTime), 4)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (8, 3, N'Order #5', 1, CAST(N'2022-08-25T16:13:51.227' AS DateTime), 5)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (9, 2, N'Order #5', 1, CAST(N'2022-08-25T16:13:51.457' AS DateTime), 5)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (10, 1, N'Order #5', 1, CAST(N'2022-08-25T16:13:51.463' AS DateTime), 5)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (11, 1, N'Order #5', 1, CAST(N'2022-08-25T16:13:51.467' AS DateTime), 5)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (12, 1, N'Order #6', 1, CAST(N'2022-08-25T16:18:47.470' AS DateTime), 6)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (13, 1, N'Order #6', 1, CAST(N'2022-08-25T16:18:47.710' AS DateTime), 6)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (14, 3, N'Order #6', 1, CAST(N'2022-08-25T16:18:47.717' AS DateTime), 6)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (15, 2, N'Order #6', 1, CAST(N'2022-08-25T16:18:47.717' AS DateTime), 6)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (16, 2, N'Order #6', 1, CAST(N'2022-08-25T16:18:47.720' AS DateTime), 6)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (17, 2, N'Order #6', 1, CAST(N'2022-08-25T16:18:47.723' AS DateTime), 6)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (18, 1, N'Order #7', 1, CAST(N'2022-08-25T16:23:20.633' AS DateTime), 7)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (19, 1, N'Order #7', 1, CAST(N'2022-08-25T16:23:20.910' AS DateTime), 7)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (20, 2, N'Order #7', 1, CAST(N'2022-08-25T16:23:20.923' AS DateTime), 7)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (21, 2, N'Order #7', 1, CAST(N'2022-08-25T16:23:20.930' AS DateTime), 7)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (22, 3, N'Order #7', 1, CAST(N'2022-08-25T16:23:20.933' AS DateTime), 7)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (23, 3, N'Order #7', 1, CAST(N'2022-08-25T16:23:20.937' AS DateTime), 7)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (24, 1, N'Order #8', 1, CAST(N'2022-08-25T19:40:56.163' AS DateTime), 8)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (25, 1, N'Order #8', 1, CAST(N'2022-08-25T19:40:56.167' AS DateTime), 8)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (26, 2, N'Order #8', 1, CAST(N'2022-08-25T19:40:56.170' AS DateTime), 8)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (27, 2, N'Order #8', 1, CAST(N'2022-08-25T19:40:56.170' AS DateTime), 8)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (28, 3, N'Order #8', 1, CAST(N'2022-08-25T19:40:56.170' AS DateTime), 8)
INSERT [dbo].[ProductOrder] ([OrderId], [ProductId], [OrderNo], [UserId], [DateCreated], [OrderSequence]) VALUES (29, 3, N'Order #8', 1, CAST(N'2022-08-25T19:40:56.170' AS DateTime), 8)
SET IDENTITY_INSERT [dbo].[ProductOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserGuid], [UserEmail], [UserPassword], [DateCreated], [IsActive]) VALUES (1, N'9e4d217f-a1cb-4d75-8550-6a471b23c0e2', N'dbsnholeni4@gmail.com', N'test@#1', CAST(N'2022-08-23T02:31:16.610' AS DateTime), 1)
INSERT [dbo].[Users] ([UserId], [UserGuid], [UserEmail], [UserPassword], [DateCreated], [IsActive]) VALUES (2, N'8b4f2487-30c6-4f9b-963b-307581375440', N'dbsnholeni3@gmail.com', N'1', CAST(N'2022-08-24T14:20:06.457' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[ProductOrder] ADD  DEFAULT ('Order #'+CONVERT([varchar](8),NEXT VALUE FOR [dbo].[NumericSequence])) FOR [OrderNo]
GO
ALTER TABLE [dbo].[ProductOrder] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (newid()) FOR [UserGuid]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
USE [master]
GO
ALTER DATABASE [BetSoftwareDB] SET  READ_WRITE 
GO
