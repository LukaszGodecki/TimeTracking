CREATE TABLE [dbo].[TimeTrackingLogs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Guid]	VARCHAR(30)	NOT NULL,
	[Description]	NVARCHAR(MAX)	NOT NULL,
	[StartTime]	DateTime	NULL,
	[StartMethodTime]	DateTime	NULL,
	[EndTime]	DateTime	NOT NULL,
	[TotalTime]	Decimal	NULL,
	[MethodTime]	Decimal	NULL,
	[Job]	NVARCHAR(300)	NOT NULL,
	[JobTypeId]	SMALLINT	NOT NULL, 
    CONSTRAINT [FK_TimeTrackingLogs_JobTypes] FOREIGN KEY ([JobTypeId]) REFERENCES [dbo].[JobTypes]([Id])
)
