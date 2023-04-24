USE [Api]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 24-04-2023 11:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 24-04-2023 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ContactNumber] [nvarchar](50) NOT NULL,
	[Salary] [decimal](18, 0) NOT NULL,
	[Designation] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsDeleated] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([DepartmentId], [Name], [CreatedAt], [IsDeleted]) VALUES (1, N'CE', CAST(N'2023-04-24T20:12:40.050' AS DateTime), 0)
GO
INSERT [dbo].[Department] ([DepartmentId], [Name], [CreatedAt], [IsDeleted]) VALUES (2, N'EC', CAST(N'2023-04-24T20:13:05.567' AS DateTime), 0)
GO
INSERT [dbo].[Department] ([DepartmentId], [Name], [CreatedAt], [IsDeleted]) VALUES (3, N'IT', CAST(N'2023-04-24T20:13:10.630' AS DateTime), 0)
GO
INSERT [dbo].[Department] ([DepartmentId], [Name], [CreatedAt], [IsDeleted]) VALUES (4, N'string', CAST(N'2023-04-24T21:28:33.233' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [Email], [Password], [ContactNumber], [Salary], [Designation], [DepartmentId], [CreatedAt], [IsDeleated]) VALUES (1, N'A', N'B', N'ab@gmail.com', N'test@123', N'9518526542', CAST(10000 AS Decimal(18, 0)), N'SE', 1, CAST(N'2023-04-24T20:59:06.157' AS DateTime), 0)
GO
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [Email], [Password], [ContactNumber], [Salary], [Designation], [DepartmentId], [CreatedAt], [IsDeleated]) VALUES (2, N'C', N'D', N'cd@gmail.com', N'test@123', N'9518526542', CAST(20000 AS Decimal(18, 0)), N'SD 1', 2, CAST(N'2023-04-24T20:59:56.583' AS DateTime), 0)
GO
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [Email], [Password], [ContactNumber], [Salary], [Designation], [DepartmentId], [CreatedAt], [IsDeleated]) VALUES (3, N'E', N'F', N'ef@gmail.com', N'test@123', N'1234567890', CAST(123456 AS Decimal(18, 0)), N'SD', 1, CAST(N'2023-04-24T21:38:03.487' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
