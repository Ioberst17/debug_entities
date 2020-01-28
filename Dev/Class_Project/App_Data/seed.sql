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
