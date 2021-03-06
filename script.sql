USE [master]
GO
/****** Object:  Database [kanbandb]    Script Date: 3/26/2020 9:37:42 AM ******/
CREATE DATABASE [kanbandb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kanbandb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\kanbandb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kanbandb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\kanbandb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [kanbandb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kanbandb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kanbandb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kanbandb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kanbandb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kanbandb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kanbandb] SET ARITHABORT OFF 
GO
ALTER DATABASE [kanbandb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kanbandb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kanbandb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kanbandb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kanbandb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kanbandb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kanbandb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kanbandb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kanbandb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kanbandb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kanbandb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kanbandb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kanbandb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kanbandb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kanbandb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kanbandb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kanbandb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kanbandb] SET RECOVERY FULL 
GO
ALTER DATABASE [kanbandb] SET  MULTI_USER 
GO
ALTER DATABASE [kanbandb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kanbandb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kanbandb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kanbandb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kanbandb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'kanbandb', N'ON'
GO
ALTER DATABASE [kanbandb] SET QUERY_STORE = OFF
GO
USE [kanbandb]
GO
/****** Object:  Table [dbo].[Checklist]    Script Date: 3/26/2020 9:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Checklist](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[TaskId] [int] NULL,
 CONSTRAINT [PK_ThingsTodo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/26/2020 9:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[List]    Script Date: 3/26/2020 9:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IndexList] [float] NULL,
 CONSTRAINT [PK_TaskListToDo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 3/26/2020 9:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[OwnerId] [int] NULL,
	[StartDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[Priority] [int] NULL,
	[AssignedEmployeeId] [int] NULL,
	[IndexTask] [float] NULL,
	[ListId] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TodoItem]    Script Date: 3/26/2020 9:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ChecklistId] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Checklist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Checklist] ON 

INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (1, N'Implement API .', 5)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (2, N'Implement Design .', 5)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (38, N'todo checklist', 56)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (39, N'todo checklist', 57)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (40, N'todo checklist', 58)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (41, N'todo checklist', 59)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (42, N'todo checklist', 60)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (43, N'todo checklist', 61)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (44, N'todo checklist', 62)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (45, N'todo checklist', 63)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (46, N'todo checklist', 64)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (47, N'todo checklist', 65)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (48, N'todo checklist', 66)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (49, N'Implementation', 67)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (50, N'Design DB', 67)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (52, N'asdsadsad', 5)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (53, N'sadsadsa', 75)
INSERT [dbo].[Checklist] ([Id], [Name], [TaskId]) VALUES (55, N'123123', 22)
SET IDENTITY_INSERT [dbo].[Checklist] OFF
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (1, N'John')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (2, N'San')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (3, N'Vu')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (4, N'Nhan')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (5, N'Duy')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (6, N'Cuong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (7, N'Tinh')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (8, N'Thinh')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (9, N'Luu')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (10, N'Cong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (11, N'Trong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (12, N'Truong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (13, N'Ki')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (14, N'Khang')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (15, N'Chien')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (16, N'Nhat')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (17, N'Dinh')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (18, N'Thang')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (19, N'Loi')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (20, N'Huyen')
SET IDENTITY_INSERT [dbo].[List] ON 

INSERT [dbo].[List] ([Id], [Name], [IndexList]) VALUES (1, N'Backlog', 2.5)
INSERT [dbo].[List] ([Id], [Name], [IndexList]) VALUES (2, N'Resolved', 2)
INSERT [dbo].[List] ([Id], [Name], [IndexList]) VALUES (3, N'Closed', 3)
SET IDENTITY_INSERT [dbo].[List] OFF
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (1, N'Create Report on Customer Feedback', 1, CAST(N'2016-05-06T00:00:00.000' AS DateTime), NULL, 2, 2, 1, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (3, N'Refund Request Template', 2, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), 2, 4, 6.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (4, N'Overtime Approval Guidelines', 2, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), 2, 12, 2.25, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (5, N'Refund Request Template ', 1, CAST(N'2016-05-13T00:00:00.000' AS DateTime), CAST(N'2020-03-27T09:52:00.000' AS DateTime), 2, 5, 0.6875, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (6, N'Overtime Approval Guidelines', 2, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), 2, 7, 2.25, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (7, N'Submit Overtime Request Forms', 1, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), 2, 2, 3.09375, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (10, N'lisk task work today', 1, CAST(N'2020-03-18T16:59:59.353' AS DateTime), CAST(N'2020-03-28T09:59:00.000' AS DateTime), NULL, 2, 7.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (12, N'Submit Customer Follow Up Plan Feedback', 1, CAST(N'2020-03-18T17:51:12.273' AS DateTime), NULL, 2, 5, 0.125, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (15, N'new', 1, CAST(N'2020-03-19T09:20:27.610' AS DateTime), NULL, NULL, 2, 3.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (17, N'qwewqeqweqweqwe', 1, CAST(N'2020-03-19T09:24:54.667' AS DateTime), NULL, NULL, 2, 4.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (18, N'taks test', 1, CAST(N'2020-03-03T09:26:53.837' AS DateTime), CAST(N'2020-04-01T02:26:00.000' AS DateTime), NULL, 8, 2.796875, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (21, N'test 123', 1, CAST(N'2020-03-19T16:11:02.207' AS DateTime), CAST(N'2020-03-28T09:10:00.000' AS DateTime), NULL, 2, 1.375, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (22, N'an com chuw', 1, CAST(N'2020-03-20T10:12:52.897' AS DateTime), CAST(N'2020-03-21T03:12:00.000' AS DateTime), NULL, 2, 0.875, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (23, N'new test today', 1, CAST(N'2020-03-20T10:14:54.983' AS DateTime), CAST(N'2020-03-27T03:14:00.000' AS DateTime), NULL, 2, 5.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (24, N'them moi task da edit', 14, CAST(N'2020-03-23T17:33:02.377' AS DateTime), CAST(N'2020-04-02T10:32:00.000' AS DateTime), NULL, 12, 3.25, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (56, N'test 123345456', 1, CAST(N'2020-03-25T14:46:19.710' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (57, N'test 123345456', 1, CAST(N'2020-03-25T14:46:35.223' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (58, N'test 123345456', 1, CAST(N'2020-03-25T14:49:21.567' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (59, N'test 123345456', 1, CAST(N'2020-03-25T14:49:26.760' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (60, N'test 123345456', 1, CAST(N'2020-03-25T14:49:54.923' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (61, N'test 123345456', 1, CAST(N'2020-03-25T14:49:55.073' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (62, N'test 123345456', 1, CAST(N'2020-03-25T14:50:13.410' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (63, N'test 123345456', 1, CAST(N'2020-03-25T14:51:05.467' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (64, N'test 123345456', 1, CAST(N'2020-03-25T14:51:12.260' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (65, N'test 123345456', 1, CAST(N'2020-03-25T14:52:14.607' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (66, N'test 123345456', 1, CAST(N'2020-03-25T14:55:09.807' AS DateTime), CAST(N'2020-03-28T07:45:00.000' AS DateTime), NULL, 2, 8.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (67, N'Test task', 5, CAST(N'2020-03-25T15:03:00.440' AS DateTime), CAST(N'2020-03-26T08:01:00.000' AS DateTime), NULL, 5, 9.75, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (75, N'fg ggsdg dg ', 1, CAST(N'2020-03-25T16:43:50.440' AS DateTime), NULL, NULL, 2, 4.25, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (77, N'safasdgadgh ad', 1, CAST(N'2020-03-25T16:59:29.437' AS DateTime), CAST(N'2020-03-28T09:59:00.000' AS DateTime), NULL, 2, 5.25, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (78, N'test 222', 1, CAST(N'2020-03-25T17:38:39.330' AS DateTime), NULL, NULL, 2, 7.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (79, N'test 333', 1, CAST(N'2020-03-25T17:41:50.897' AS DateTime), NULL, NULL, 2, 8.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (80, N'test 444', 1, CAST(N'2020-03-25T17:44:21.900' AS DateTime), NULL, NULL, 2, 9.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (81, N'test 555', 1, CAST(N'2020-03-25T17:45:28.390' AS DateTime), NULL, NULL, 2, 10.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (82, N'test 555', 1, CAST(N'2020-03-25T17:46:03.897' AS DateTime), NULL, NULL, 2, 10.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (83, N'test 666', 1, CAST(N'2020-03-25T17:46:44.477' AS DateTime), NULL, NULL, 2, 11.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [Priority], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (84, N'777', 4, CAST(N'2020-03-25T17:55:37.530' AS DateTime), NULL, NULL, 3, 12.5, 3)
SET IDENTITY_INSERT [dbo].[Task] OFF
SET IDENTITY_INSERT [dbo].[TodoItem] ON 

INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (1, N'Create Employee .', 1, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (2, N'Edit Employee', 1, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (3, N'UI-Create Employee', 2, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (4, N'UI-Edit Employee', 2, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (19, N'item', NULL, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (27, N'item 1', 38, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (28, N'item 2', 38, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (29, N'item 1', 39, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (30, N'item 2', 39, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (31, N'item 1', 40, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (32, N'item 2', 40, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (33, N'item 1', 41, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (34, N'item 2', 41, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (35, N'item 1', 42, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (36, N'item 2', 42, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (37, N'item 1', 43, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (38, N'item 2', 43, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (39, N'item 1', 44, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (40, N'item 2', 44, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (41, N'item 1', 45, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (42, N'item 2', 45, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (43, N'item 1', 46, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (44, N'item 2', 46, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (45, N'item 1', 47, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (46, N'item 2', 47, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (47, N'item 1', 48, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (48, N'item 2', 48, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (49, N'Design layout', 49, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (50, N'Implement API', 49, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (51, N'Add table', 50, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (53, N'asdasdasd', 52, 1)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (55, N'dasdasdsaddasdsad', 53, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (56, N'asdasdasd', 53, NULL)
INSERT [dbo].[TodoItem] ([Id], [Name], [ChecklistId], [IsActive]) VALUES (58, N'mgkgj', 55, NULL)
SET IDENTITY_INSERT [dbo].[TodoItem] OFF
ALTER TABLE [dbo].[Checklist]  WITH CHECK ADD  CONSTRAINT [FK_ThingsTodo_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Checklist] CHECK CONSTRAINT [FK_ThingsTodo_Task]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([AssignedEmployeeId])
REFERENCES [dbo].[Employee] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Employee]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Owner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Owner]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskList] FOREIGN KEY([ListId])
REFERENCES [dbo].[List] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TaskList]
GO
ALTER TABLE [dbo].[TodoItem]  WITH CHECK ADD  CONSTRAINT [FK_Checklist_ThingsTodo] FOREIGN KEY([ChecklistId])
REFERENCES [dbo].[Checklist] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TodoItem] CHECK CONSTRAINT [FK_Checklist_ThingsTodo]
GO
USE [master]
GO
ALTER DATABASE [kanbandb] SET  READ_WRITE 
GO
