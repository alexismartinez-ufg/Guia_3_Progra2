USE [master]
GO
/****** Object:  Database [GestionUsuarios]    Script Date: 10/3/2024 12:00:31 ******/
CREATE DATABASE [GestionUsuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestionUsuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GestionUsuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestionUsuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GestionUsuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GestionUsuarios] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestionUsuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestionUsuarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestionUsuarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestionUsuarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestionUsuarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestionUsuarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestionUsuarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestionUsuarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestionUsuarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestionUsuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestionUsuarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestionUsuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestionUsuarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestionUsuarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestionUsuarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestionUsuarios] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GestionUsuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestionUsuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestionUsuarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestionUsuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestionUsuarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestionUsuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestionUsuarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestionUsuarios] SET RECOVERY FULL 
GO
ALTER DATABASE [GestionUsuarios] SET  MULTI_USER 
GO
ALTER DATABASE [GestionUsuarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestionUsuarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestionUsuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestionUsuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestionUsuarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestionUsuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GestionUsuarios', N'ON'
GO
ALTER DATABASE [GestionUsuarios] SET QUERY_STORE = OFF
GO
USE [GestionUsuarios]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 10/3/2024 12:00:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[PaisId] [int] IDENTITY(1,1) NOT NULL,
	[NombrePais] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 10/3/2024 12:00:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[rl_id] [int] IDENTITY(1,1) NOT NULL,
	[rl_nombre] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rl_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles_usuarios]    Script Date: 10/3/2024 12:00:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles_usuarios](
	[rlu_id] [int] IDENTITY(1,1) NOT NULL,
	[rlu_usr_id] [int] NULL,
	[rlu_rl_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[rlu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 10/3/2024 12:00:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[usr_id] [int] IDENTITY(1,1) NOT NULL,
	[usr_nombre] [varchar](45) NOT NULL,
	[usr_apellido] [varchar](45) NOT NULL,
	[usr_email] [varchar](150) NOT NULL,
	[PaisId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[usr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Paises] ON 

INSERT [dbo].[Paises] ([PaisId], [NombrePais]) VALUES (1, N'El Salvador')
INSERT [dbo].[Paises] ([PaisId], [NombrePais]) VALUES (2, N'Guatemala')
INSERT [dbo].[Paises] ([PaisId], [NombrePais]) VALUES (3, N'Estados Unidos')
INSERT [dbo].[Paises] ([PaisId], [NombrePais]) VALUES (4, N'Colombia')
INSERT [dbo].[Paises] ([PaisId], [NombrePais]) VALUES (5, N'Argentina')
INSERT [dbo].[Paises] ([PaisId], [NombrePais]) VALUES (6, N'España')
INSERT [dbo].[Paises] ([PaisId], [NombrePais]) VALUES (7, N'Francia')
SET IDENTITY_INSERT [dbo].[Paises] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 

INSERT [dbo].[roles] ([rl_id], [rl_nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[roles] ([rl_id], [rl_nombre]) VALUES (2, N'Editor')
INSERT [dbo].[roles] ([rl_id], [rl_nombre]) VALUES (3, N'Publicador')
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([usr_id], [usr_nombre], [usr_apellido], [usr_email], [PaisId]) VALUES (6, N'Armando', N'NH', N'armando@mail.com', 2)
INSERT [dbo].[usuarios] ([usr_id], [usr_nombre], [usr_apellido], [usr_email], [PaisId]) VALUES (7, N'Vanessa', N'AP', N'vane@mail.com', 2)
INSERT [dbo].[usuarios] ([usr_id], [usr_nombre], [usr_apellido], [usr_email], [PaisId]) VALUES (8, N'Karla', N'AW', N'karla@mail.com', 2)
INSERT [dbo].[usuarios] ([usr_id], [usr_nombre], [usr_apellido], [usr_email], [PaisId]) VALUES (9, N'Alberto', N'ER', N'alberto@mail.com', 2)
INSERT [dbo].[usuarios] ([usr_id], [usr_nombre], [usr_apellido], [usr_email], [PaisId]) VALUES (10, N'Alexis', N'Martínez', N'Alexis@mail.com', 2)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
ALTER TABLE [dbo].[roles_usuarios]  WITH CHECK ADD  CONSTRAINT [fk_Roles] FOREIGN KEY([rlu_rl_id])
REFERENCES [dbo].[roles] ([rl_id])
GO
ALTER TABLE [dbo].[roles_usuarios] CHECK CONSTRAINT [fk_Roles]
GO
ALTER TABLE [dbo].[roles_usuarios]  WITH CHECK ADD  CONSTRAINT [fk_Usuario] FOREIGN KEY([rlu_usr_id])
REFERENCES [dbo].[usuarios] ([usr_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[roles_usuarios] CHECK CONSTRAINT [fk_Usuario]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Pais] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Paises] ([PaisId])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [fk_Usuario_Pais]
GO
USE [master]
GO
ALTER DATABASE [GestionUsuarios] SET  READ_WRITE 
GO
