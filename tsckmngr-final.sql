USE [TaskManager]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 07.12.2023 1:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdTeam] [int] NULL,
	[IdUser] [int] NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Otdel]    Script Date: 07.12.2023 1:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otdel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Otdel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subtask]    Script Date: 07.12.2023 1:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subtask](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[Status] [bit] NULL,
	[IdTask] [int] NULL,
 CONSTRAINT [PK_Subtask] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 07.12.2023 1:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[FinalDate] [date] NULL,
	[Description] [nvarchar](max) NULL,
	[IdUserTeam] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 07.12.2023 1:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IdLeader] [int] NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07.12.2023 1:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](11) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[IdOtdel] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTeam]    Script Date: 07.12.2023 1:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTeam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdTeam] [int] NULL,
	[IdUser] [int] NULL,
 CONSTRAINT [PK_UserTeam] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Otdel] ON 

INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (1, N'Фронтенд')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (2, N'Бэкенд')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (3, N'Дизайнер')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (4, N'Аналитик')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (5, N'Проектировщик')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (6, N'Инженер')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (7, N'Системный администратор')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (8, N'Кибербезопасность')
INSERT [dbo].[Otdel] ([ID], [Name]) VALUES (9, N'Тестировщик')
SET IDENTITY_INSERT [dbo].[Otdel] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([ID], [Name], [Status], [FinalDate], [Description], [IdUserTeam]) VALUES (1, N'Сделать оболочку', 0, CAST(N'2023-12-09' AS Date), NULL, 13)
INSERT [dbo].[Task] ([ID], [Name], [Status], [FinalDate], [Description], [IdUserTeam]) VALUES (2, N'Продумать логику', 0, CAST(N'2023-12-10' AS Date), NULL, 13)
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([ID], [Name], [IdLeader]) VALUES (1, N'Общая', NULL)
INSERT [dbo].[Team] ([ID], [Name], [IdLeader]) VALUES (2, N'Магазин одежды', 13)
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (1, N'Flectere', N'24', 2)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (2, N'Smetana', N'19', 1)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (3, N'meacute', N'9', 3)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (4, N'karman', N'cho', 4)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (5, N'p4shechka', N'pav', 5)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (6, N'romeo', N'rom', 5)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (7, N'helldem', N'dem', 6)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (8, N'pelmen', N'ram', 7)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (9, N'Orhan', N'orr', 2)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (10, N'Bugr', N'emil', 1)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (11, N's4dly', N'lexa', 8)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (12, N'larisa', N'gavr', 9)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (13, N'lidak', N'1', NULL)
INSERT [dbo].[User] ([ID], [Login], [Password], [IdOtdel]) VALUES (14, N'proshnik', N'1', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTeam] ON 

INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (1, 1, 1)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (2, 1, 2)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (3, 1, 3)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (4, 1, 4)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (5, 1, 5)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (6, 1, 6)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (7, 1, 7)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (8, 1, 8)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (9, 1, 9)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (10, 1, 10)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (11, 1, 11)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (12, 1, 12)
INSERT [dbo].[UserTeam] ([ID], [IdTeam], [IdUser]) VALUES (13, 2, 14)
SET IDENTITY_INSERT [dbo].[UserTeam] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_User_Login]    Script Date: 07.12.2023 1:22:33 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF__Task__Status__2739D489]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Team] FOREIGN KEY([IdTeam])
REFERENCES [dbo].[Team] ([ID])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Team]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_User]
GO
ALTER TABLE [dbo].[Subtask]  WITH CHECK ADD  CONSTRAINT [FK_Subtask_Task] FOREIGN KEY([IdTask])
REFERENCES [dbo].[Task] ([ID])
GO
ALTER TABLE [dbo].[Subtask] CHECK CONSTRAINT [FK_Subtask_Task]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_UserTeam] FOREIGN KEY([IdUserTeam])
REFERENCES [dbo].[UserTeam] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_UserTeam]
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_User] FOREIGN KEY([IdLeader])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Otdel] FOREIGN KEY([IdOtdel])
REFERENCES [dbo].[Otdel] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Otdel]
GO
ALTER TABLE [dbo].[UserTeam]  WITH CHECK ADD  CONSTRAINT [FK_UserTeam_Team] FOREIGN KEY([IdTeam])
REFERENCES [dbo].[Team] ([ID])
GO
ALTER TABLE [dbo].[UserTeam] CHECK CONSTRAINT [FK_UserTeam_Team]
GO
ALTER TABLE [dbo].[UserTeam]  WITH CHECK ADD  CONSTRAINT [FK_UserTeam_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserTeam] CHECK CONSTRAINT [FK_UserTeam_User]
GO
