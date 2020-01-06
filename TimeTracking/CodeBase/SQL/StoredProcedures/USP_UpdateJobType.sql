CREATE PROCEDURE [dbo].[USP_UpdateJobType] 
	  @ID INT
    , @Name NVARCHAR(250)
 AS
	BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM [dbo].[JobTypes] AS [JT] WHERE [JT].[ID] =@ID) 
		BEGIN
		UPDATE [dbo].[JobTypes]
			SET [Name] = ISNULL(@Name, [Name])
		WHERE [ID] = @ID
		END 			
	SET NOCOUNT OFF
	END
GO