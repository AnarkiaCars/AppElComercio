USE [master]
GO

/****** Object:  Database [DBTemplate]    Script Date: 7/04/2017 03:18:59 ******/
CREATE DATABASE [DBTemplate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBTemplate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DBTemplate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBTemplate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DBTemplate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [DBTemplate] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBTemplate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DBTemplate] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DBTemplate] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DBTemplate] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DBTemplate] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DBTemplate] SET ARITHABORT OFF 
GO

ALTER DATABASE [DBTemplate] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DBTemplate] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DBTemplate] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DBTemplate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DBTemplate] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DBTemplate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DBTemplate] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DBTemplate] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DBTemplate] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DBTemplate] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DBTemplate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DBTemplate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DBTemplate] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DBTemplate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DBTemplate] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DBTemplate] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DBTemplate] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DBTemplate] SET RECOVERY FULL 
GO

ALTER DATABASE [DBTemplate] SET  MULTI_USER 
GO

ALTER DATABASE [DBTemplate] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DBTemplate] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DBTemplate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DBTemplate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [DBTemplate] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DBTemplate] SET QUERY_STORE = OFF
GO

USE [DBTemplate]
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [DBTemplate] SET  READ_WRITE 
GO

USE [DBTemplate]
GO
/****** Object:  Table [dbo].[Bancos]    Script Date: 7/04/2017 03:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bancos](
	[BanCodigo] [int] IDENTITY(1,1) NOT NULL,
	[BanNombre] [varchar](100) NOT NULL,
	[BanDireccion] [varchar](255) NULL,
	[BarFecharegistro] [smalldatetime] NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[BanCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrdenPago]    Script Date: 7/04/2017 03:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenPago](
	[OrdCodigo] [int] IDENTITY(1,1) NOT NULL,
	[BanCodigo] [int] NOT NULL,
	[SucCodigo] [int] NOT NULL,
	[OrdMonto] [decimal](18, 8) NOT NULL,
	[OrdMoneda] [int] NOT NULL,
	[OrdEstado] [int] NULL,
	[OrdFechaPago] [smalldatetime] NULL,
 CONSTRAINT [PK_OrdenPago] PRIMARY KEY CLUSTERED 
(
	[OrdCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 7/04/2017 03:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[SucCodigo] [int] IDENTITY(1,1) NOT NULL,
	[BanCodigo] [int] NOT NULL,
	[SucNombre] [varchar](100) NOT NULL,
	[SucDireccion] [varchar](255) NULL,
	[SucFecharegistro] [smalldatetime] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[SucCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 7/04/2017 03:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos](
	[TipCodigo] [int] IDENTITY(1,1) NOT NULL,
	[TipClase] [varchar](10) NOT NULL,
	[TipVal] [varchar](20) NULL,
 CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED 
(
	[TipCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[up_ordenPago_listar]    Script Date: 7/04/2017 03:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_ordenPago_listar]
(
	@SucCodigo	INT,
	@OrdMoneda	INT
)
AS
BEGIN
	SET NOCOUNT ON

	Select OrdCodigo,
		Ban.banNombre,
		Suc.SucNombre,
		OrdMonto,
		Mon.TipVal as 'Moneda',
		Est.TipVal as 'Estado',
		OrdFechaPago 
	from ordenPago ord
	inner join Bancos Ban on Ban.BanCodigo = ord.BanCodigo
	inner join Sucursal Suc on Suc.SucCodigo = ord.SucCodigo
	inner join Tipos Mon on Mon.TipCodigo = ord.OrdMoneda
	inner join Tipos Est on Est.TipCodigo = ord.OrdEstado
	where Ord.SucCodigo = @SucCodigo
		and Ord.OrdMoneda = @OrdMoneda

	SET NOCOUNT OFF
END


GO
/****** Object:  StoredProcedure [dbo].[up_sucursales_x_banco]    Script Date: 7/04/2017 03:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_sucursales_x_banco]
(
	@BanCodigo	INT
)
AS
BEGIN
	SET NOCOUNT ON

	Select Suc.SucCodigo,
		Ban.BanNombre,
		SucNombre,
		SucDireccion,
		SucFecharegistro 
	from Sucursal Suc
	inner join Bancos Ban on Ban.BanCodigo = Suc.BanCodigo
	where Suc.BanCodigo = @BanCodigo

	SET NOCOUNT OFF
END


GO
INSERT INTO Bancos(BanNombre,BanDireccion,BarFecharegistro)
SELECT 'BCP','Callao','20160506'
UNION ALL
SELECT 'BBVA','Lima','20161210'
UNION ALL
SELECT 'Scotiabank','La Victoria','20170119'
UNION ALL
SELECT 'BanBif','San Isidro','20160330'

go

INSERT INTO Sucursal(BanCodigo,SucNombre,SucDireccion,SucFecharegistro)
SELECT 1,'BCP Callao','Av. Buenos Aires 765','20160916'
UNION ALL
SELECT 2,'BBVA Colonial','Av. Oscar R. Benavides 269','20161211'
UNION ALL
SELECT 3,'Scotiabank Tupac Amaru','Av. Iquitos 748','20170202'
UNION ALL
SELECT 4,'BanBif Navarrete','Av. Navarrete 302','20160927'

go

INSERT INTO Tipos(TipClase,TipVal)
SELECT 'TIP_MONEDA', 'Soles'
UNION ALL
SELECT 'TIP_MONEDA', 'Dolares'
UNION ALL
SELECT 'TIP_ESTOP', 'Pagada'
UNION ALL
SELECT 'TIP_ESTOP', 'Declinada'
UNION ALL
SELECT 'TIP_ESTOP', 'Fallida'
UNION ALL
SELECT 'TIP_ESTOP', 'Anulada'

go

INSERT INTO OrdenPago(BanCodigo,SucCodigo,OrdMonto,OrdMoneda,OrdEstado,OrdFechaPago)
Select 1,1,120.30,4,6,'20170301'
UNION ALL
Select 1,1,39.5,5,6,'20170312'
UNION ALL
Select 2,2,48.10,4,6,'20170215'
UNION ALL
Select 3,3,360,5,6,'20170116'
UNION ALL
Select 4,4,1800,5,6,'20170228'
UNION ALL
Select 4,4,200,4,6,'20170401'