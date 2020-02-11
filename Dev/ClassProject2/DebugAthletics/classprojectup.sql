
CREATE TABLE [dbo].[Results](
    [ID]  INT IDENTITY(1,1) NOT NULL,
	[AthleteStats] nvarchar(120),
	[TimeEvents] DATETIME,
    
    CONSTRAINT [PK_dbo.Results] PRIMARY KEY CLUSTERED ([ID] ASC)
    
);

Create Table [dbo].[Athletes](

    [ID] INT IDENTITY(1,1) NOT NULL,
    [FName] NVARCHAR(120),
    [LName] NVARCHAR(120),
	[AthResults] INT NOT NULL,
    
    CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Athletes_dbo.Results_ID] FOREIGN KEY ([AthResults]) REFERENCES [dbo].[Results] ([ID])

);


Create Table [dbo].[Coaches](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(120) NOT NULL,
	[Password] NVARCHAR(120),
	[Athlete] INT NOT NULL,
	[AthlResult] INT NOT NULL,
	
	

	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Coaches_dbo.Athletes_ID] FOREIGN KEY ([Athlete]) REFERENCES [dbo].[Athletes] ([ID]),
	CONSTRAINT [FK_dbo.Coaches_dbo.Results_ID] FOREIGN KEY ([AthlResult]) REFERENCES [dbo].[Results] ([ID])

);


Create Table [dbo].[Users](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[AthResult] INT NOT NULL,
	[Name] NVarChar(60) NOT NULL,
	[Email] nvarchar(60) NOT NULL,
	[Password] nvarchar(60) NOT NULL,
    
   CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC),
   CONSTRAINT [FK_dbo.Users_dbo.Results_ID] FOREIGN KEY ([AthResult]) REFERENCES [dbo].[Results] ([ID])
   
);





Create Table [dbo].[Administrator](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(60),
	[Password] NVARCHAR(60),
	[UserInfo] INT NOT NULL,
	[Coach] INT NOT NULL,
	[ResultAth] INT NOT NULL,

    
     CONSTRAINT [PK_dbo.Administrator] PRIMARY KEY CLUSTERED ([ID] ASC),
	 CONSTRAINT [FK_dbo.Administrator_dbo.Users_ID] FOREIGN KEY ([UserInfo]) REFERENCES [dbo].[Users] ([ID]),
	 CONSTRAINT [FK_dbo.Administrator_dbo.Coaches_ID] FOREIGN KEY ([Coach]) REFERENCES [dbo].[Coaches] ([ID]),
	 CONSTRAINT [FK_dbo.Administrator_dbo.Results_ID] FOREIGN KEY ([ResultAth]) REFERENCES [dbo].[Results] ([ID])
);



INSERT INTO [dbo].[Results]([AthleteStats],[TimeEvents]) VALUES
('A','2008-01-01 00:00:01 '),
('B',' 2014-01-01 00:00:01' ),
('c','2019-01-01 00:00:01');




INSERT INTO [dbo].[Athletes]([FName],[LName],[AthResults]) VALUES
('David','De Gea',1),
('Paul','Pogba',3),
('Luis','Nani',2);



INSERT INTO [dbo].[Coaches]([Name],[Password],[Athlete],[AthlResult]) VALUES
('Ole', 'Ole password', 2,3),
('Jose', 'Jose password', 1,1);


INSERT INTO [dbo].[Users]([Name],[Password],[Email],[AthResult]) VALUES
('Zaid', 'Zaid password', 'zaid@gmail.com', 1),
('Paul', 'Paul password', 'Paul@gmail.com', 3);


INSERT INTO [dbo].[Administrator]([Name],[Password],[Coach],[UserInfo],[ResultAth]) VALUES
('John','password',2,1,3),
('Nancy','password',1,2,2);