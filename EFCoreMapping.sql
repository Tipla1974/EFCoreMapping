USE [master]
GO
/****** Object:  Database [EFCoreMapping]    Script Date: 17/09/2020 9:07:44 ******/
CREATE DATABASE [EFCoreMapping]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EFCoreMapping', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EFCoreMapping.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EFCoreMapping_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EFCoreMapping_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EFCoreMapping] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EFCoreMapping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EFCoreMapping] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EFCoreMapping] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EFCoreMapping] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EFCoreMapping] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EFCoreMapping] SET ARITHABORT OFF 
GO
ALTER DATABASE [EFCoreMapping] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EFCoreMapping] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EFCoreMapping] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EFCoreMapping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EFCoreMapping] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EFCoreMapping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EFCoreMapping] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EFCoreMapping] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EFCoreMapping] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EFCoreMapping] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EFCoreMapping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EFCoreMapping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EFCoreMapping] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EFCoreMapping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EFCoreMapping] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EFCoreMapping] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EFCoreMapping] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EFCoreMapping] SET RECOVERY FULL 
GO
ALTER DATABASE [EFCoreMapping] SET  MULTI_USER 
GO
ALTER DATABASE [EFCoreMapping] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EFCoreMapping] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EFCoreMapping] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EFCoreMapping] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EFCoreMapping] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EFCoreMapping', N'ON'
GO
ALTER DATABASE [EFCoreMapping] SET QUERY_STORE = OFF
GO
USE [EFCoreMapping]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ASSBoeken]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSBoeken](
	[BoekId] [int] IDENTITY(1,1) NOT NULL,
	[IsbnNr] [nvarchar](13) NOT NULL,
	[Titel] [nvarchar](150) NULL,
 CONSTRAINT [PK_ASSBoeken] PRIMARY KEY CLUSTERED 
(
	[BoekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ASSBoekenCursussen]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSBoekenCursussen](
	[CursusId] [int] NOT NULL,
	[BoekId] [int] NOT NULL,
	[VolgNr] [int] NOT NULL,
 CONSTRAINT [PK_ASSBoekenCursussen] PRIMARY KEY CLUSTERED 
(
	[BoekId] ASC,
	[CursusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ASSCampussen]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSCampussen](
	[CampusId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NOT NULL,
	[Straat] [nvarchar](max) NULL,
	[HuisNr] [nvarchar](max) NULL,
	[PostCd] [nvarchar](max) NULL,
	[Gemeente] [nvarchar](max) NULL,
 CONSTRAINT [PK_ASSCampussen] PRIMARY KEY CLUSTERED 
(
	[CampusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ASSCursussen]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSCursussen](
	[CursusId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ASSCursussen] PRIMARY KEY CLUSTERED 
(
	[CursusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ASSDocenten]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSDocenten](
	[DocentId] [int] IDENTITY(1,1) NOT NULL,
	[Voornaam] [nvarchar](max) NULL,
	[Familienaam] [nvarchar](max) NULL,
	[Maandwedde] [decimal](18, 2) NOT NULL,
	[InDienst] [date] NOT NULL,
	[HeeftRijbewijs] [bit] NULL,
	[Straat] [nvarchar](max) NULL,
	[HuisNr] [nvarchar](max) NULL,
	[PostCd] [nvarchar](max) NULL,
	[Gemeente] [nvarchar](max) NULL,
	[CampusId] [int] NOT NULL,
 CONSTRAINT [PK_ASSDocenten] PRIMARY KEY CLUSTERED 
(
	[DocentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campussen]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campussen](
	[CampusId] [int] IDENTITY(1,1) NOT NULL,
	[CampusNaam] [nvarchar](max) NOT NULL,
	[Straat] [nvarchar](max) NULL,
	[HuisNr] [nvarchar](max) NULL,
	[PostCd] [nvarchar](max) NULL,
	[Gemeente] [nvarchar](max) NULL,
 CONSTRAINT [PK_Campussen] PRIMARY KEY CLUSTERED 
(
	[CampusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docenten]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docenten](
	[DocentId] [int] IDENTITY(1,1) NOT NULL,
	[Voornaam] [nvarchar](20) NOT NULL,
	[Familienaam] [nvarchar](30) NOT NULL,
	[Maandwedde] [decimal](18, 4) NOT NULL,
	[HeeftRijbewijs] [bit] NULL,
	[LandCode] [nvarchar](max) NULL,
	[InDienst] [date] NOT NULL,
	[StraatThuis] [nvarchar](max) NULL,
	[HuisNrThuis] [nvarchar](max) NULL,
	[PostCdThuis] [nvarchar](max) NULL,
	[GemeenteThuis] [nvarchar](max) NULL,
	[StraatWerk] [nvarchar](max) NULL,
	[HuisNrWerk] [nvarchar](max) NULL,
	[PostCdWerk] [nvarchar](max) NULL,
	[GemeenteWerk] [nvarchar](max) NULL,
	[CampusId] [int] NOT NULL,
 CONSTRAINT [PK_Docenten] PRIMARY KEY CLUSTERED 
(
	[DocentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TPHCursussen]    Script Date: 17/09/2020 9:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPHCursussen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](max) NULL,
	[Van] [datetime2](7) NULL,
	[Tot] [datetime2](7) NULL,
	[AantalDagen] [int] NULL,
	[CursusType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TPHCursussen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ASSBoeken_IsbnNr]    Script Date: 17/09/2020 9:07:44 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ASSBoeken_IsbnNr] ON [dbo].[ASSBoeken]
(
	[IsbnNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ASSBoekenCursussen_CursusId]    Script Date: 17/09/2020 9:07:44 ******/
CREATE NONCLUSTERED INDEX [IX_ASSBoekenCursussen_CursusId] ON [dbo].[ASSBoekenCursussen]
(
	[CursusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ASSDocenten_CampusId]    Script Date: 17/09/2020 9:07:44 ******/
CREATE NONCLUSTERED INDEX [IX_ASSDocenten_CampusId] ON [dbo].[ASSDocenten]
(
	[CampusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Docenten_CampusId]    Script Date: 17/09/2020 9:07:44 ******/
CREATE NONCLUSTERED INDEX [IX_Docenten_CampusId] ON [dbo].[Docenten]
(
	[CampusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TPHCursussen] ADD  DEFAULT (N'') FOR [CursusType]
GO
ALTER TABLE [dbo].[ASSBoekenCursussen]  WITH CHECK ADD  CONSTRAINT [FK_ASSBoekenCursussen_ASSBoeken_BoekId] FOREIGN KEY([BoekId])
REFERENCES [dbo].[ASSBoeken] ([BoekId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ASSBoekenCursussen] CHECK CONSTRAINT [FK_ASSBoekenCursussen_ASSBoeken_BoekId]
GO
ALTER TABLE [dbo].[ASSBoekenCursussen]  WITH CHECK ADD  CONSTRAINT [FK_ASSBoekenCursussen_ASSCursussen_CursusId] FOREIGN KEY([CursusId])
REFERENCES [dbo].[ASSCursussen] ([CursusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ASSBoekenCursussen] CHECK CONSTRAINT [FK_ASSBoekenCursussen_ASSCursussen_CursusId]
GO
ALTER TABLE [dbo].[ASSDocenten]  WITH CHECK ADD  CONSTRAINT [FK_ASSDocenten_ASSCampussen_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[ASSCampussen] ([CampusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ASSDocenten] CHECK CONSTRAINT [FK_ASSDocenten_ASSCampussen_CampusId]
GO
ALTER TABLE [dbo].[Docenten]  WITH CHECK ADD  CONSTRAINT [FK_Docenten_Campussen_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campussen] ([CampusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Docenten] CHECK CONSTRAINT [FK_Docenten_Campussen_CampusId]
GO
USE [master]
GO
ALTER DATABASE [EFCoreMapping] SET  READ_WRITE 
GO
