CREATE PROCEDURE [dbo].[USP_SelectSingleJobType]

@ID INT
AS	

BEGIN
		SET NOCOUNT ON;
		
			BEGIN

				SELECT 
				  [ID]
				, [Name]
				FROM [dbo].[JobTypes]
				WHERE [ID] = @ID
				
			END

		SET NOCOUNT OFF
	END