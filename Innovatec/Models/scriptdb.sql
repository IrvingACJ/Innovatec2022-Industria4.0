USE [master]
GO
/****** Object:  Database [SistemaI4]    Script Date: 12/05/2022 02:52:33 p. m. ******/
CREATE DATABASE [SistemaI4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaI4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SistemaI4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaI4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SistemaI4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SistemaI4] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaI4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaI4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaI4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaI4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaI4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaI4] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaI4] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SistemaI4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaI4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaI4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaI4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaI4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaI4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaI4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaI4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaI4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SistemaI4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaI4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaI4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaI4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaI4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaI4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaI4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaI4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SistemaI4] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaI4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaI4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaI4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaI4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaI4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaI4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SistemaI4] SET QUERY_STORE = OFF
GO
USE [SistemaI4]
GO
/****** Object:  User [Python]    Script Date: 12/05/2022 02:52:33 p. m. ******/
CREATE USER [Python] FOR LOGIN [Python] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Python]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Python]
GO
/****** Object:  Schema [itninnova]    Script Date: 12/05/2022 02:52:33 p. m. ******/
CREATE SCHEMA [itninnova]
GO
/****** Object:  Schema [SysfacWeiser1]    Script Date: 12/05/2022 02:52:33 p. m. ******/
CREATE SCHEMA [SysfacWeiser1]
GO
/****** Object:  Table [dbo].[tBasculas]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tBasculas](
	[ID_Bascula] [varchar](25) NOT NULL,
	[Descripcion] [varchar](250) NULL,
 CONSTRAINT [PK_tBasculas] PRIMARY KEY CLUSTERED 
(
	[ID_Bascula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tBOM]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tBOM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Producto] [varchar](25) NULL,
	[ID_Componente] [varchar](25) NULL,
	[Cantidad] [decimal](18, 7) NULL,
 CONSTRAINT [PK_tBOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tComponentes]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tComponentes](
	[ID_Componente] [varchar](25) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[PesoUnitarioGramos] [decimal](18, 7) NULL,
	[Minimo] [decimal](18, 7) NULL,
	[Maximo] [decimal](18, 7) NULL,
	[Imagen] [image] NULL,
 CONSTRAINT [PK_tComponentes] PRIMARY KEY CLUSTERED 
(
	[ID_Componente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tInventario]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tInventario](
	[ID_Componente] [varchar](25) NULL,
	[ID_Bascula] [varchar](25) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tLineasComponentesBasculas]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLineasComponentesBasculas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Linea] [varchar](25) NULL,
	[ID_Componente] [varchar](25) NULL,
	[ID_Bascula] [varchar](25) NULL,
	[Cantidad] [int] NULL,
	[Minimo] [int] NULL,
	[Maximo] [int] NULL,
 CONSTRAINT [PK_tIneasComponentesBasculas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tLineasProduccion]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLineasProduccion](
	[ID_Linea] [varchar](25) NOT NULL,
	[Descripcion] [varchar](25) NULL,
 CONSTRAINT [PK_tLineasProduccion] PRIMARY KEY CLUSTERED 
(
	[ID_Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProductos]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProductos](
	[ID_Producto] [varchar](25) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Imagen] [image] NULL,
 CONSTRAINT [PK_tProductos] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUsuarios]    Script Date: 12/05/2022 02:52:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUsuarios](
	[ID_Usuario] [varchar](250) NOT NULL,
	[Nombre] [varchar](250) NULL,
	[EMail] [varchar](250) NULL,
 CONSTRAINT [PK_tUsuarios] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tBasculas] ([ID_Bascula], [Descripcion]) VALUES (N'0xb827ebeab6ff2324', N'Almacen:Active')
GO
INSERT [dbo].[tBasculas] ([ID_Bascula], [Descripcion]) VALUES (N'0xb827ebeab6ff56', N'Almacen:Active')
GO
INSERT [dbo].[tComponentes] ([ID_Componente], [Descripcion], [PesoUnitarioGramos], [Minimo], [Maximo], [Imagen]) VALUES (N'1', N'Componente_1', CAST(32.0000000 AS Decimal(18, 7)), CAST(2.0000000 AS Decimal(18, 7)), CAST(12.0000000 AS Decimal(18, 7)), NULL)
GO
INSERT [dbo].[tComponentes] ([ID_Componente], [Descripcion], [PesoUnitarioGramos], [Minimo], [Maximo], [Imagen]) VALUES (N'2', N'Componente_2', CAST(100.0000000 AS Decimal(18, 7)), CAST(2.0000000 AS Decimal(18, 7)), CAST(100.0000000 AS Decimal(18, 7)), NULL)
GO
SET IDENTITY_INSERT [dbo].[tLineasComponentesBasculas] ON 
GO
INSERT [dbo].[tLineasComponentesBasculas] ([ID], [ID_Linea], [ID_Componente], [ID_Bascula], [Cantidad], [Minimo], [Maximo]) VALUES (4, N'2', N'1', N'0xb827ebeab6ff56', 6, 6, 12)
GO
INSERT [dbo].[tLineasComponentesBasculas] ([ID], [ID_Linea], [ID_Componente], [ID_Bascula], [Cantidad], [Minimo], [Maximo]) VALUES (5, N'1', N'1', N'0xb827ebeab6ff2324', 5, 3, 12)
GO
SET IDENTITY_INSERT [dbo].[tLineasComponentesBasculas] OFF
GO
INSERT [dbo].[tLineasProduccion] ([ID_Linea], [Descripcion]) VALUES (N'1', N'Linea_1')
GO
INSERT [dbo].[tLineasProduccion] ([ID_Linea], [Descripcion]) VALUES (N'2', N'Linea_2')
GO
ALTER TABLE [dbo].[tBOM]  WITH CHECK ADD  CONSTRAINT [FK_tBOM_tComponentes] FOREIGN KEY([ID_Componente])
REFERENCES [dbo].[tComponentes] ([ID_Componente])
GO
ALTER TABLE [dbo].[tBOM] CHECK CONSTRAINT [FK_tBOM_tComponentes]
GO
ALTER TABLE [dbo].[tBOM]  WITH CHECK ADD  CONSTRAINT [FK_tBOM_tProductos] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[tProductos] ([ID_Producto])
GO
ALTER TABLE [dbo].[tBOM] CHECK CONSTRAINT [FK_tBOM_tProductos]
GO
ALTER TABLE [dbo].[tLineasComponentesBasculas]  WITH CHECK ADD  CONSTRAINT [FK_tLineasComponentesBasculas_tBasculas] FOREIGN KEY([ID_Bascula])
REFERENCES [dbo].[tBasculas] ([ID_Bascula])
GO
ALTER TABLE [dbo].[tLineasComponentesBasculas] CHECK CONSTRAINT [FK_tLineasComponentesBasculas_tBasculas]
GO
ALTER TABLE [dbo].[tLineasComponentesBasculas]  WITH CHECK ADD  CONSTRAINT [FK_tLineasComponentesBasculas_tComponentes] FOREIGN KEY([ID_Componente])
REFERENCES [dbo].[tComponentes] ([ID_Componente])
GO
ALTER TABLE [dbo].[tLineasComponentesBasculas] CHECK CONSTRAINT [FK_tLineasComponentesBasculas_tComponentes]
GO
ALTER TABLE [dbo].[tLineasComponentesBasculas]  WITH CHECK ADD  CONSTRAINT [FK_tLineasComponentesBasculas_tLineasProduccion] FOREIGN KEY([ID_Linea])
REFERENCES [dbo].[tLineasProduccion] ([ID_Linea])
GO
ALTER TABLE [dbo].[tLineasComponentesBasculas] CHECK CONSTRAINT [FK_tLineasComponentesBasculas_tLineasProduccion]
GO
USE [master]
GO
ALTER DATABASE [SistemaI4] SET  READ_WRITE 
GO
