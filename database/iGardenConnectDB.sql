USE [master]
GO
/****** Object:  Database [iGardenConnectDB]    Script Date: 19/03/2023 22:15:54 ******/
CREATE DATABASE [iGardenConnectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'iGardenConnectDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\iGardenConnectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'iGardenConnectDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\iGardenConnectDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [iGardenConnectDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [iGardenConnectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [iGardenConnectDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [iGardenConnectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [iGardenConnectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [iGardenConnectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [iGardenConnectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET RECOVERY FULL 
GO
ALTER DATABASE [iGardenConnectDB] SET  MULTI_USER 
GO
ALTER DATABASE [iGardenConnectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [iGardenConnectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [iGardenConnectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [iGardenConnectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [iGardenConnectDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [iGardenConnectDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'iGardenConnectDB', N'ON'
GO
ALTER DATABASE [iGardenConnectDB] SET QUERY_STORE = OFF
GO
USE [iGardenConnectDB]
GO
/****** Object:  Table [dbo].[ExistingGarden]    Script Date: 19/03/2023 22:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExistingGarden](
	[idGarden] [varchar](100) NOT NULL,
	[isActive] [int] NOT NULL,
 CONSTRAINT [PK_ExistingGarden] PRIMARY KEY CLUSTERED 
(
	[idGarden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garden]    Script Date: 19/03/2023 22:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garden](
	[idGarden] [varchar](100) NOT NULL,
	[name] [varchar](100) NULL,
	[watered] [smallint] NULL,
	[last_watered] [datetime] NULL,
	[idPlant] [int] NULL,
	[idUser] [int] NULL,
	[wateringDuration] [int] NULL,
 CONSTRAINT [PK_Garden] PRIMARY KEY CLUSTERED 
(
	[idGarden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GardenSensor]    Script Date: 19/03/2023 22:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GardenSensor](
	[idGarden] [varchar](100) NOT NULL,
	[idSensor] [int] NOT NULL,
	[value] [nchar](100) NULL,
	[state] [nchar](100) NULL,
 CONSTRAINT [PK_GardenSensor] PRIMARY KEY CLUSTERED 
(
	[idGarden] ASC,
	[idSensor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plant]    Script Date: 19/03/2023 22:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plant](
	[idPlant] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NULL,
	[species] [nchar](100) NULL,
	[optimalTemperature] [float] NULL,
	[soilMoisture] [float] NULL,
	[airMoisture] [float] NULL,
	[light] [float] NULL,
 CONSTRAINT [PK_Plant] PRIMARY KEY CLUSTERED 
(
	[idPlant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sensor]    Script Date: 19/03/2023 22:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sensor](
	[idSensor] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NULL,
	[type] [nchar](100) NULL,
	[brand] [nchar](100) NULL,
	[price] [nchar](100) NULL,
 CONSTRAINT [PK_sensor] PRIMARY KEY CLUSTERED 
(
	[idSensor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19/03/2023 22:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[login] [nchar](100) NULL,
	[role] [nchar](100) NULL,
	[password] [nchar](1000) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ExistingGarden] ([idGarden], [isActive]) VALUES (N'g01', 0)
INSERT [dbo].[ExistingGarden] ([idGarden], [isActive]) VALUES (N'g02', 0)
INSERT [dbo].[ExistingGarden] ([idGarden], [isActive]) VALUES (N'g03', 0)
INSERT [dbo].[ExistingGarden] ([idGarden], [isActive]) VALUES (N'g04', 0)
GO
INSERT [dbo].[Garden] ([idGarden], [name], [watered], [last_watered], [idPlant], [idUser], [wateringDuration]) VALUES (N'g01', N'Salon', 0, CAST(N'2023-03-19T22:13:04.173' AS DateTime), 7, 10, 12)
INSERT [dbo].[Garden] ([idGarden], [name], [watered], [last_watered], [idPlant], [idUser], [wateringDuration]) VALUES (N'g02', N'Cuisine', 0, CAST(N'2023-03-19T14:36:34.387' AS DateTime), 6, 10, 0)
INSERT [dbo].[Garden] ([idGarden], [name], [watered], [last_watered], [idPlant], [idUser], [wateringDuration]) VALUES (N'g03', N'Chambre', 0, CAST(N'2023-03-19T14:36:47.923' AS DateTime), 5, 10, 0)
GO
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g01', 1, N'22                                                                                                  ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g01', 2, N'42                                                                                                  ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g01', 3, N'200                                                                                                 ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g01', 4, N'65                                                                                                  ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g01', 5, N'6                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g01', 6, N'1                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g01', 7, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g02', 1, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g02', 2, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g02', 3, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g02', 4, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g02', 5, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g02', 6, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g02', 7, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g03', 1, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g03', 2, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g03', 3, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g03', 4, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g03', 5, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g03', 6, N'0                                                                                                   ', N'OFF                                                                                                 ')
INSERT [dbo].[GardenSensor] ([idGarden], [idSensor], [value], [state]) VALUES (N'g03', 7, N'0                                                                                                   ', N'OFF                                                                                                 ')
GO
SET IDENTITY_INSERT [dbo].[Plant] ON 

INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (1, N'Menthe                                                                                              ', N'Plante aromatique                                                                                   ', 25, 180, 80, 6)
INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (2, N'Corriandre                                                                                          ', N'Plante aromatique                                                                                   ', 25, 180, 80, 6)
INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (3, N'Thym                                                                                                ', N'Plante aromatique                                                                                   ', 25, 180, 80, 6)
INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (4, N'Sarriete                                                                                            ', N'Plante aromatique                                                            Plante aromatique      ', 25, 180, 80, 6)
INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (5, N'Romarin                                                                                             ', N'Plante aromatique                                                                                   ', 25, 180, 80, 6)
INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (6, N'Ciboulette                                                                                          ', N'Plante aromatique                                                                                   ', 25, 180, 80, 6)
INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (7, N'Persil                                                                                              ', N'Plante aromatique                                                                                   ', 25, 180, 80, 6)
INSERT [dbo].[Plant] ([idPlant], [name], [species], [optimalTemperature], [soilMoisture], [airMoisture], [light]) VALUES (8, N'Basilic                                                                                             ', N'Plante aromatique                                                                                   ', 25, 180, 80, 6)
SET IDENTITY_INSERT [dbo].[Plant] OFF
GO
SET IDENTITY_INSERT [dbo].[Sensor] ON 

INSERT [dbo].[Sensor] ([idSensor], [name], [type], [brand], [price]) VALUES (1, N'Température                                                                                         ', N'temperature                                                                                         ', N'GOTRONIC                                                                                            ', N'2.90€                                                                                               ')
INSERT [dbo].[Sensor] ([idSensor], [name], [type], [brand], [price]) VALUES (2, N'Humidité de l''air                                                                                   ', N'airMoisture                                                                                         ', N'GOTRONIC                                                                                            ', N'2.90€                                                                                               ')
INSERT [dbo].[Sensor] ([idSensor], [name], [type], [brand], [price]) VALUES (3, N'Humidité du sol                                                                                     ', N'soilMoisture                                                                                        ', N'lextronic                                                                                           ', N'18.60€                                                                                              ')
INSERT [dbo].[Sensor] ([idSensor], [name], [type], [brand], [price]) VALUES (4, N'Niveau d''eau                                                                                        ', N'waterlevel                                                                                          ', N'gotronic                                                                                            ', N'4.50€                                                                                               ')
INSERT [dbo].[Sensor] ([idSensor], [name], [type], [brand], [price]) VALUES (5, N'Luminosité                                                                                          ', N'luminosity                                                                                          ', N'Grove                                                                                               ', N'5€                                                                                                  ')
INSERT [dbo].[Sensor] ([idSensor], [name], [type], [brand], [price]) VALUES (6, N'Pompe                                                                                               ', N'pump                                                                                                ', N'Gotronic                                                                                            ', N'20€                                                                                                 ')
INSERT [dbo].[Sensor] ([idSensor], [name], [type], [brand], [price]) VALUES (7, N'LED                                                                                                 ', N'led                                                                                                 ', N'Gotronic                                                                                            ', N'10€                                                                                                 ')
SET IDENTITY_INSERT [dbo].[Sensor] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([idUser], [login], [role], [password]) VALUES (10, N'micheminat                                                                                          ', N'user                                                                                                ', N'$2a$10$xDEfDQdIYYmBwzFeNs7p8eIMPF4QNCHTbz6vsYSF0a5xP0As5hxkq                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            ')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Garden]  WITH CHECK ADD FOREIGN KEY([idPlant])
REFERENCES [dbo].[Plant] ([idPlant])
GO
ALTER TABLE [dbo].[Garden]  WITH CHECK ADD FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
GO
ALTER TABLE [dbo].[GardenSensor]  WITH CHECK ADD  CONSTRAINT [FK_idGarden] FOREIGN KEY([idGarden])
REFERENCES [dbo].[Garden] ([idGarden])
GO
ALTER TABLE [dbo].[GardenSensor] CHECK CONSTRAINT [FK_idGarden]
GO
ALTER TABLE [dbo].[GardenSensor]  WITH CHECK ADD  CONSTRAINT [FK_idSensor_Sensor] FOREIGN KEY([idSensor])
REFERENCES [dbo].[Sensor] ([idSensor])
GO
ALTER TABLE [dbo].[GardenSensor] CHECK CONSTRAINT [FK_idSensor_Sensor]
GO
USE [master]
GO
ALTER DATABASE [iGardenConnectDB] SET  READ_WRITE 
GO
