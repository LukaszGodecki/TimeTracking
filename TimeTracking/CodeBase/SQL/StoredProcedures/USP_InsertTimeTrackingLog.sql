CREATE PROCEDURE [dbo].[USP_InsertTimeTrackingLog]
	(
    @Guid VARCHAR(30)
    , @Description NVARCHAR(MAX)
    , @StartTime DateTime
	, @StartMethodTime DateTime
	, @EndTime DateTime
	, @TotalTime Decimal
	, @MethodTime Decimal
	, @Job NVARCHAR(300)
	, @JobTypeId SMALLINT
	) AS

BEGIN
		SET NOCOUNT ON;
		
			BEGIN
				INSERT INTO [dbo].[TimeTrackingLogs] ([Guid], [Description], [StartTime], [StartMethodTime], [EndTime], [TotalTime], [MethodTime], [Job], [JobTypeId])
			
				VALUES (@Guid, @Description, @StartTime, @StartMethodTime, @EndTime, @TotalTime, @MethodTime, @Job, @JobTypeId)

(SELECT  SCOPE_IDENTITY());
			END

		SET NOCOUNT OFF
	END