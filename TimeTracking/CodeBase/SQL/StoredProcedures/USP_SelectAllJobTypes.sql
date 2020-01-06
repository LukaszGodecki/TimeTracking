CREATE PROCEDURE [dbo].[USP_SelectAllJobTypes]
AS	

BEGIN
		SET NOCOUNT ON;
		
			BEGIN

				SELECT 
				  [ID]
				, [Name]
				FROM [dbo].[JobTypes] 				
			END

		SET NOCOUNT OFF
	END
GO