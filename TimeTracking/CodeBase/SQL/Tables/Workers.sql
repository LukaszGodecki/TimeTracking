﻿CREATE TABLE [dbo].[Workers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Age] TINYINT NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Surname] NVARCHAR(100) NOT NULL,
	[Gender] BIT NOT NULL,
	[JobDescription] NVARCHAR(500) NULL
)
