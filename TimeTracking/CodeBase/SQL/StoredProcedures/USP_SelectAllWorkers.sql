CREATE PROCEDURE [dbo].[USP_SelectAllWorkers]
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
			END

		SET NOCOUNT OFF
	END
GO
