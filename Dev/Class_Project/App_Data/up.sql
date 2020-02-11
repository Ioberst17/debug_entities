CREATE TABLE [dbo].[Coaches] (
  [CoachID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(120) NOT NULL,
  [Password] NVARCHAR(120),
  [Name] nvarchar(255)
)
GO

CREATE TABLE [dbo].[Teams] (
  [TeamID] int PRIMARY KEY IDENTITY(1, 1),
  [CoachID] int,
  [Name] nvarchar(255)
)
GO

CREATE TABLE [dbo].[Event] (
  [EventID] int PRIMARY KEY IDENTITY(1, 1),
  [AthleteID] int,
  [Location] nvarchar(255),
  [Date] datetime
)
GO

CREATE TABLE [dbo].[Athlete] (
  [AthleteID] int PRIMARY KEY IDENTITY(1, 1),
  [TeamID] int,
  [FName] nvarchar(255),
  [LName] nvarchar(255),
  [Gender] nvarchar(255)
)
GO

CREATE TABLE [dbo].[Result] (
  [ResultID] int PRIMARY KEY IDENTITY(1, 1),
  [EventID] int,
  [AthleteID] int,
  [Time] nvarchar(255),
  [Distance] nvarchar(255)
)
GO

Create Table [dbo].[Administrator](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(60),
	[Password] NVARCHAR(60),
	[UserInfo] INT NOT NULL,
	[Coach] INT NOT NULL,
	[ResultAth] INT NOT NULL,
);

Create Table [dbo].[Users](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[AthResult] INT NOT NULL,
	[Name] NVarChar(60) NOT NULL,
	[Email] nvarchar(60) NOT NULL,
	[Password] nvarchar(60) NOT NULL,
);