USE [master]
GO
/****** Object:  Database [ContestantDB]    Script Date: 7/11/2019 11:04:17 AM ******/
CREATE DATABASE [ContestantDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContestantDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ContestantDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContestantDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ContestantDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ContestantDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContestantDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContestantDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContestantDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContestantDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContestantDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContestantDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContestantDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContestantDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContestantDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContestantDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContestantDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContestantDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContestantDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContestantDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContestantDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContestantDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ContestantDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContestantDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContestantDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContestantDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContestantDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContestantDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContestantDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContestantDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ContestantDB] SET  MULTI_USER 
GO
ALTER DATABASE [ContestantDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContestantDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContestantDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContestantDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContestantDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContestantDB', N'ON'
GO
ALTER DATABASE [ContestantDB] SET QUERY_STORE = OFF
GO
USE [ContestantDB]
GO
/****** Object:  Table [dbo].[Contestant]    Script Date: 7/11/2019 11:04:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contestant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[IsActive] [bit] NULL,
	[DistrictId] [int] NULL,
	[Gender] [varchar](20) NULL,
	[PhotoUrl] [varchar](150) NULL,
	[Address] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContestantRating]    Script Date: 7/11/2019 11:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContestantRating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContestantId] [int] NULL,
	[Rating] [decimal](18, 0) NULL,
	[RatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 7/11/2019 11:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contestant]  WITH CHECK ADD FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([Id])
GO
ALTER TABLE [dbo].[ContestantRating]  WITH CHECK ADD FOREIGN KEY([ContestantId])
REFERENCES [dbo].[Contestant] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[SpGetContestantList]    Script Date: 7/11/2019 11:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetContestantList](@District VARCHAR(50))

AS
BEGIN
SELECT C.Id AS ContestantId,c.Firstname+' '+c.LastName AS FullName,d.Name AS District FROM dbo.Contestant AS c
INNER JOIN dbo.District AS d
ON d.Id = c.DistrictId
WHERE d.Name=@District

		 END
GO
/****** Object:  StoredProcedure [dbo].[SpGetContestantRating]    Script Date: 7/11/2019 11:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetContestantRating]

AS
BEGIN
SELECT c.Id AS ContestantId ,c.Firstname+' '+c.LastName AS FullName,c.DateOfBirth,d.Name AS District,ISNULL(AVG(cr.Rating),0.0) AS AverageRating,c.PhotoUrl FROM dbo.Contestant AS c
LEFT JOIN dbo.ContestantRating AS cr
ON cr.ContestantId = c.Id
INNER JOIN dbo.District AS d
ON d.Id = c.DistrictId
--WHERE(cr.RatedDate IS NULL) OR (cr.RatedDate BETWEEN @StartDate AND @EndDate)

GROUP BY c.Firstname + ' ' + c.LastName,
         c.Id,
         c.DateOfBirth,
         d.Name,
         c.PhotoUrl

		 END
         
GO
USE [master]
GO
ALTER DATABASE [ContestantDB] SET  READ_WRITE 
GO
