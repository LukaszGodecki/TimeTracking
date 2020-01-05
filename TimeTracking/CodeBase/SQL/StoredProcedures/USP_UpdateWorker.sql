CREATE PROCEDURE [dbo].[USP_UpdateWorker] 
	  @ID INT
	, @Age TINYINT
    , @Name NVARCHAR(100)
    , @Surname NVARCHAR(100)
	, @Gender BIT
	, @JobDescription NVARCHAR(500)
 AS
	BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM [dbo].[Workers] AS [W] WHERE [W].[ID] =@ID) 
		BEGIN
		UPDATE [dbo].[Workers]
			SET [Age] = ISNULL(@Age,[Age])
			, [Name] = ISNULL(@Name, [Name])
			, [Surname] = ISNULL(@Surname, [Surname])
			, [Gender] = ISNULL(@Gender, [Gender])
			, [JobDescription] = ISNULL(@JobDescription, [JobDescription])
		WHERE [ID] = @ID
		END 			
	SET NOCOUNT OFF
	END
GO
