USE [iGardenConnectDB]
GO
/****** Object:  Table [dbo].[Garden]    Script Date: 08/01/2023 18:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garden](
	[idGarden] [varchar](100) NOT NULL,
	[name] [varchar](100) NULL,
	[price] [varchar](10) NULL,
	[watering_duration] [datetime] NULL,
	[watered] [smallint] NULL,
	[last_watered] [datetime] NULL,
	[idPlant] [nchar](100) NULL,
 CONSTRAINT [PK_Garden] PRIMARY KEY CLUSTERED 
(
	[idGarden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GardenSensor]    Script Date: 08/01/2023 18:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GardenSensor](
	[idGarden] [varchar](100) NOT NULL,
	[idSensor] [nchar](100) NOT NULL,
	[value] [nchar](100) NULL,
	[state] [nchar](100) NULL,
 CONSTRAINT [PK_GardenSensor] PRIMARY KEY CLUSTERED 
(
	[idGarden] ASC,
	[idSensor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plant]    Script Date: 08/01/2023 18:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plant](
	[idPlant] [nchar](100) NOT NULL,
	[name] [nchar](100) NULL,
	[species] [nchar](100) NULL,
	[watering_interval] [datetime] NULL,
 CONSTRAINT [PK_Plant] PRIMARY KEY CLUSTERED 
(
	[idPlant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sensor]    Script Date: 08/01/2023 18:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sensor](
	[idSensor] [nchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[User]    Script Date: 08/01/2023 18:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [varchar](100) NOT NULL,
	[idGarden] [varchar](100) NOT NULL,
	[name] [nchar](100) NULL,
	[username] [nchar](100) NULL,
	[login] [nchar](100) NULL,
	[role] [nchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Garden]  WITH CHECK ADD FOREIGN KEY([idPlant])
REFERENCES [dbo].[Plant] ([idPlant])
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
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_ID_Garden] FOREIGN KEY([idGarden])
REFERENCES [dbo].[Garden] ([idGarden])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_ID_Garden]
GO
