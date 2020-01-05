CREATE PROCEDURE [dbo].[USP_SelectSingleWorker]

@ID INT
AS	

BEGIN
		SET NOCOUNT ON;
		
			BEGIN

				SELECT 
				  [ID]
				, [Name]
				, [Surname]
				, [Age]
				, [Gender]
				, [JobDescription]
				FROM [dbo].[Workers]
				WHERE [ID] = @ID
				
			END

		SET NOCOUNT OFF
	END
GO
