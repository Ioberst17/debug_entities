
CREATE TABLE [dbo].[Results](
    [ID]  INT IDENTITY(1,1) NOT NULL,
	[AthleteStats] nvarchar(120),
	[TimeEvents] DATETIME,
    
    CONSTRAINT [PK_dbo.Results] PRIMARY KEY CLUSTERED ([ID] ASC)
    
);

Create Table [dbo].[Athletes](

    [ID] INT IDENTITY(1,1) NOT NULL,
    [AthResults] INT NOT NULL,
    [FName] NVARCHAR(120),
    [LName] NVARCHAR(120),
    
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





