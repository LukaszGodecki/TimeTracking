CREATE PROCEDURE [dbo].[USP_SelectTimeTrackingGroupsLogs]

@Guid	VARCHAR(30)
,@Job	NVARCHAR(300)
,@JobTypeId	SMALLINT
AS	

BEGIN
		SET NOCOUNT ON;
		
			BEGIN

				SELECT 
				[Guid]
				, [Job]
				, [JobTypeId]
				, Count(ID) AS [Count]
				FROM [dbo].[TimeTrackingLogs]
				WHERE [Job] = ISNULL(@Job, [Job]) AND [Guid] = ISNULL(@Guid, [Guid]) AND [JobTypeId] = ISNULL(@JobTypeId, [JobTypeId])
				GROUP BY [Guid], [Job], [JobTypeId]
				
			END

		SET NOCOUNT OFF
	END