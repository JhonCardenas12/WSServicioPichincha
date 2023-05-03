USE [master]
GO
/****** Object:  Database [Pichincha]    Script Date: 3/05/2023 9:13:21 a. m. ******/
CREATE DATABASE [Pichincha]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pichincha', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Pichincha.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pichincha_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Pichincha_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Pichincha] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pichincha].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pichincha] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pichincha] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pichincha] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pichincha] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pichincha] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pichincha] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pichincha] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pichincha] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pichincha] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pichincha] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pichincha] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pichincha] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pichincha] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pichincha] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pichincha] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pichincha] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pichincha] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pichincha] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pichincha] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pichincha] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pichincha] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pichincha] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pichincha] SET RECOVERY FULL 
GO
ALTER DATABASE [Pichincha] SET  MULTI_USER 
GO
ALTER DATABASE [Pichincha] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pichincha] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pichincha] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pichincha] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pichincha] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pichincha] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Pichincha', N'ON'
GO
ALTER DATABASE [Pichincha] SET QUERY_STORE = OFF
GO
USE [Pichincha]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 3/05/2023 9:13:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[PersonaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 3/05/2023 9:13:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[CuentaId] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[SaldoInicial] [money] NOT NULL,
	[Estado] [bit] NOT NULL,
	[ClienteId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 3/05/2023 9:13:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[MovimientosId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[Valor] [money] NOT NULL,
	[Saldo] [money] NOT NULL,
	[CuentaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MovimientosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 3/05/2023 9:13:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [varchar](15) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([ClienteId], [Contraseña], [Estado], [PersonaId]) VALUES (1, 3242323, 1, 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Contraseña], [Estado], [PersonaId]) VALUES (2, 1234, 1, 2)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Contraseña], [Estado], [PersonaId]) VALUES (3, 5678, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 
GO
INSERT [dbo].[Cuenta] ([CuentaId], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (1, 3242342, N'Ahorros', 1100.0000, 1, 1)
GO
INSERT [dbo].[Cuenta] ([CuentaId], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (2, 478758, N'Ahorro', 2000.0000, 1, 2)
GO
INSERT [dbo].[Cuenta] ([CuentaId], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (3, 585545, N'Corriente', 1000.0000, 1, 2)
GO
INSERT [dbo].[Cuenta] ([CuentaId], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (4, 225487, N'Corriente', 100.0000, 1, 3)
GO
INSERT [dbo].[Cuenta] ([CuentaId], [Numero], [Tipo], [SaldoInicial], [Estado], [ClienteId]) VALUES (5, 496825, N'Ahorros', 540.0000, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 
GO
INSERT [dbo].[Movimientos] ([MovimientosId], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (15, CAST(N'2023-05-03T04:05:10.290' AS DateTime), N'Retiro de 1100', -1100.0000, 0.0000, 1)
GO
INSERT [dbo].[Movimientos] ([MovimientosId], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (16, CAST(N'2023-05-03T04:05:10.290' AS DateTime), N'Deposito de 600', 600.0000, 600.0000, 1)
GO
INSERT [dbo].[Movimientos] ([MovimientosId], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (17, CAST(N'2023-05-03T04:05:10.290' AS DateTime), N'Deposito de 20', 20.0000, 560.0000, 5)
GO
INSERT [dbo].[Movimientos] ([MovimientosId], [Fecha], [Tipo], [Valor], [Saldo], [CuentaId]) VALUES (18, CAST(N'2023-05-03T04:05:10.290' AS DateTime), N'Retiro de 100', -100.0000, 460.0000, 5)
GO
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 
GO
INSERT [dbo].[Persona] ([PersonaId], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'Jhon Cardenas', N'Masculino', 27, N'1016083400', N'carrera 104 # 24-32', 322132)
GO
INSERT [dbo].[Persona] ([PersonaId], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'Jose Lema', N'Masculino', 40, N'1016086700', N'Otavalo sn y principal', 98254785)
GO
INSERT [dbo].[Persona] ([PersonaId], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (3, N'Marianela Montalvo', N'Masculino', 30, N'10167800', N'Amazonas y NNUU', 97548965)
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([PersonaId])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuenta]
GO
USE [master]
GO
ALTER DATABASE [Pichincha] SET  READ_WRITE 
GO
