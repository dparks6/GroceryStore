USE [master]
GO
/****** Object:  Database [GroceryStoreDB]    Script Date: 11/11/2024 5:14:29 PM ******/
CREATE DATABASE [GroceryStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GroceryStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\GroceryStoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'GroceryStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\GroceryStoreDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GroceryStoreDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GroceryStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GroceryStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GroceryStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GroceryStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GroceryStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GroceryStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GroceryStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [GroceryStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GroceryStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GroceryStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GroceryStoreDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GroceryStoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GroceryStoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GroceryStoreDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [GroceryStoreDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GroceryStoreDB]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 11/11/2024 5:14:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[LoginTimestamp] [datetime] NOT NULL,
	[LogoutTimestamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/11/2024 5:14:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordHash] [varchar](256) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Logins] ADD  DEFAULT (getdate()) FOR [LoginTimestamp]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Logins]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [GroceryStoreDB] SET  READ_WRITE 
GO
