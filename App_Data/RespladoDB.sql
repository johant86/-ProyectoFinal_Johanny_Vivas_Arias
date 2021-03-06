/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/2/2022 23:12:40 ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbContinuosProdEmulate]    Script Date: 25/2/2022 23:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbContinuosProdEmulate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[machineid] [int] NULL,
	[productid] [int] NULL,
	[dailyHours] [int] NOT NULL,
	[weeklyDays] [int] NOT NULL,
	[hourCost] [real] NOT NULL,
	[Months] [int] NOT NULL,
	[days] [int] NOT NULL,
	[hours] [int] NOT NULL,
	[totalProducts] [int] NOT NULL,
	[TotalTimeInRepare] [int] NOT NULL,
	[timeToRepare] [int] NOT NULL,
	[wingross] [real] NOT NULL,
	[realWin] [real] NOT NULL,
	[totalHours] [int] NOT NULL,
 CONSTRAINT [PK_tbContinuosProdEmulate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbMachine]    Script Date: 25/2/2022 23:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbMachine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[failProbability] [nvarchar](max) NULL,
	[productsPerHour] [int] NOT NULL,
	[timeToFix] [int] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_tbMachine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProducts]    Script Date: 25/2/2022 23:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProducts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[productPrice] [real] NOT NULL,
 CONSTRAINT [PK_tbProducts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220224013457_ConfigMigration', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220224014442_ConfigMigration', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220224022542_ConfigMigration', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220225052504_ConfigMigration', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220225053905_ConfigMigration', N'5.0.14')
SET IDENTITY_INSERT [dbo].[tbContinuosProdEmulate] ON 

INSERT [dbo].[tbContinuosProdEmulate] ([id], [machineid], [productid], [dailyHours], [weeklyDays], [hourCost], [Months], [days], [hours], [totalProducts], [TotalTimeInRepare], [timeToRepare], [wingross], [realWin], [totalHours]) VALUES (1, 1, 1, 8, 6, 10, 6, 0, 0, 9448600, 150, 0, 4.7243E+07, 4.723148E+07, 0)
INSERT [dbo].[tbContinuosProdEmulate] ([id], [machineid], [productid], [dailyHours], [weeklyDays], [hourCost], [Months], [days], [hours], [totalProducts], [TotalTimeInRepare], [timeToRepare], [wingross], [realWin], [totalHours]) VALUES (2, 2, 2, 8, 6, 15, 4, 0, 0, 9413900, 153, 0, 4.70695E+07, 4.705798E+07, 0)
SET IDENTITY_INSERT [dbo].[tbContinuosProdEmulate] OFF
SET IDENTITY_INSERT [dbo].[tbMachine] ON 

INSERT [dbo].[tbMachine] ([id], [name], [failProbability], [productsPerHour], [timeToFix], [status]) VALUES (1, N'MACHINE #1', N'1,0', 100, 3, 1)
INSERT [dbo].[tbMachine] ([id], [name], [failProbability], [productsPerHour], [timeToFix], [status]) VALUES (2, N'MACHINE # 2', N'0,7', 100, 3, 1)
SET IDENTITY_INSERT [dbo].[tbMachine] OFF
SET IDENTITY_INSERT [dbo].[tbProducts] ON 

INSERT [dbo].[tbProducts] ([id], [name], [productPrice]) VALUES (1, N'Clavos', 5)
INSERT [dbo].[tbProducts] ([id], [name], [productPrice]) VALUES (2, N'Tornillos', 5)
SET IDENTITY_INSERT [dbo].[tbProducts] OFF
ALTER TABLE [dbo].[tbContinuosProdEmulate]  WITH CHECK ADD  CONSTRAINT [FK_tbContinuosProdEmulate_tbMachine_machineid] FOREIGN KEY([machineid])
REFERENCES [dbo].[tbMachine] ([id])
GO
ALTER TABLE [dbo].[tbContinuosProdEmulate] CHECK CONSTRAINT [FK_tbContinuosProdEmulate_tbMachine_machineid]
GO
ALTER TABLE [dbo].[tbContinuosProdEmulate]  WITH CHECK ADD  CONSTRAINT [FK_tbContinuosProdEmulate_tbProducts_productid] FOREIGN KEY([productid])
REFERENCES [dbo].[tbProducts] ([id])
GO
ALTER TABLE [dbo].[tbContinuosProdEmulate] CHECK CONSTRAINT [FK_tbContinuosProdEmulate_tbProducts_productid]
GO
