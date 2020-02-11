Create Table [dbo].[Users](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVarChar(60) NOT NULL,
	[Email] nvarchar(60) NOT NULL,
	[Password] nvarchar(60) NOT NULL,

   CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC),
);

Create Table [dbo].[Teams](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(120) NOT NULL,

	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC),
);

Create Table [dbo].[Coaches](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(120) NOT NULL,
	[Password] NVARCHAR(120),
	[UserInfo] INT NOT NULL,
	[TeamID] Int not Null,

	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Coaches_dbo.Users_ID] FOREIGN KEY ([UserInfo]) REFERENCES [dbo].[Users]([ID]),
	CONSTRAINT [FK_dbo.Coaches_dbo.Teams_ID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams]([ID]),
);

Create Table [dbo].[Administrators](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(60),
	[Password] NVARCHAR(60),
	[UserInfo] INT NOT NULL,


     CONSTRAINT [PK_dbo.Administrators] PRIMARY KEY CLUSTERED ([ID] ASC),
	 CONSTRAINT [FK_dbo.Administrators_dbo.Users_ID] FOREIGN KEY ([UserInfo]) REFERENCES [dbo].[Users] ([ID]),
);

Create Table [dbo].[Athletes](

    [ID] INT IDENTITY(1,1) NOT NULL,
    [FName] NVARCHAR(120),
    [LName] NVARCHAR(120),
	[Gender] NVARCHAR(120),
	[Picture] NVARCHAR(120),
	[CoachID] INT NOT NULL,
	[TeamID] Int not Null,

    CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Athletes_dbo.Coaches_ID] FOREIGN KEY ([CoachID]) REFERENCES [dbo].[Coaches] ([ID]),
	CONSTRAINT [FK_dbo.Athletes_dbo.Teams_ID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams]([ID]),
);

CREATE TABLE [dbo].[Results](
    [ID]  INT IDENTITY(1,1) NOT NULL,
	[AthleteID] INT NOT NULL,
	[TimeEvents] DATETIME,
	[Location] nvarchar(120),
	[Place] Int NOT NULL,
	[Distance/Miles] INT NOT NULL,
	[SwimResult] time,

    CONSTRAINT [PK_dbo.Results] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Results_dbo.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([ID])
);


INSERT INTO [dbo].[Users]([Name],[Password],[Email]) VALUES
('Zaid', 'Zaidpassword1!', 'zaid@gmail.com'),
('Paul', 'Paulpassword1!', 'Paul@gmail.com');

INSERT INTO [dbo].[Teams]([Name]) VALUES
('Central High'),
('Tolarian Community College');

INSERT INTO [dbo].[Coaches]([Name],[Password],[UserInfo],[TeamID]) VALUES
('Ole', 'Ole password',1,1),
('Jose', 'Jose password',2,2);

INSERT INTO [dbo].[Administrators]([Name],[Password],[UserInfo]) VALUES
('John','password',1),
('Nancy','password2',2);

INSERT INTO [dbo].[Athletes]([FName],[LName],[Gender],[Picture],[CoachID],[TeamID]) VALUES
('David','De Gea','Male','David.jpg',1,1),
('Paul','Pogba','Male', Null, 2,2),
('Luis','Nani','Male', 'Luis.jpg', 2,2);

INSERT INTO [dbo].[Results]([AthleteID],[TimeEvents],[Location],[Place],[Distance/Miles],[SwimResult]) VALUES
(1,'2008-01-01 05:30:00','Salem, Oregon',1, 15, '00:05:12'),
(1,'2008-01-01 05:30:00','Salem, Oregon',1, 15, '00:03:12'),
(2,'2014-01-01 02:30:00','Salem, Oregon',2, 15, '00:15:32'),
(3,'2019-01-01 12:00:00','Salem, Oregon',3, 15, '00:25:52');