USE [master]
GO

/****** Object:  Database [testefcore]    Script Date: 17/8/2018 18:41:02 ******/
CREATE DATABASE [testefcore]
GO

ALTER DATABASE [testefcore] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [testefcore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [testefcore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [testefcore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [testefcore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [testefcore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [testefcore] SET ARITHABORT OFF 
GO

ALTER DATABASE [testefcore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [testefcore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [testefcore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [testefcore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [testefcore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [testefcore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [testefcore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [testefcore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [testefcore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [testefcore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [testefcore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [testefcore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [testefcore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [testefcore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [testefcore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [testefcore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [testefcore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [testefcore] SET RECOVERY FULL 
GO

ALTER DATABASE [testefcore] SET  MULTI_USER 
GO

ALTER DATABASE [testefcore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [testefcore] SET DB_CHAINING OFF 
GO

ALTER DATABASE [testefcore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [testefcore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [testefcore] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [testefcore] SET QUERY_STORE = OFF
GO

USE [testefcore]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [testefcore] SET  READ_WRITE 
GO





USE [testefcore]
GO

/****** Object:  Table [dbo].[personas]    Script Date: 17/8/2018 18:44:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[personas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[fehca_nacimiento] [datetime] NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [testefcore]
GO

/****** Object:  Table [dbo].[movimientos]    Script Date: 17/8/2018 18:45:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movimientos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_persona] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[importe] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_movimientos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[movimientos]  WITH CHECK ADD  CONSTRAINT [FK_movimientos_persona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[personas] ([id])
GO

ALTER TABLE [dbo].[movimientos] CHECK CONSTRAINT [FK_movimientos_persona]
GO


