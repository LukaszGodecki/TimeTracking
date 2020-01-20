CREATE PROCEDURE [dbo].[USP_SelectAllTimeTrackingLogsForSelectedJob]

@Job NVARCHAR(300)
AS	

BEGIN
		SET NOCOUNT ON;
		
			BEGIN

				SELECT 
				  [ID]
				, [Guid]
				, [Description]
				, [StartTime]
				, [StartMethodTime]
				, [EndTime]
				, [TotalTime]
				, [MethodTime]
				, [Job]
				, [JobTypeId]
				FROM [dbo].[TimeTrackingLogs]
				WHERE [Job] = @Job
				
			END

		SET NOCOUNT OFF
	END