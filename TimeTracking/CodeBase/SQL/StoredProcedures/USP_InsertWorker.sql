ALTER PROCEDURE [dbo].[USP_InsertWorker]
	(
    @Age TINYINT
    , @Name NVARCHAR(100)
    , @Surname NVARCHAR(100)
	, @Gender BIT
	, @JobDescription NVARCHAR(500)
	, @ID INT output
	) AS

BEGIN
		SET NOCOUNT ON;
		
			BEGIN
				INSERT INTO [dbo].[Workers] ([Age], [Name], [Surname], [Gender], [JobDescription])
			
				VALUES (@Age, @Name, @Surname, @Gender, @JobDescription)

				SET @ID = (SELECT  SCOPE_IDENTITY());
			END

		SET NOCOUNT OFF
	END
GO
-----------------------
CREATE PROCEDURE [dbo].[USP_InsertWorker]
	(
    @Age TINYINT
    , @Name NVARCHAR(100)
    , @Surname NVARCHAR(100)
	, @Gender BIT
	, @JobDescription NVARCHAR(500)
	--, @ID INT output
	) AS

BEGIN
		SET NOCOUNT ON;
		
			BEGIN
				INSERT INTO [dbo].[Workers] ([Age], [Name], [Surname], [Gender], [JobDescription])
			
				VALUES (@Age, @Name, @Surname, @Gender, @JobDescription)

				--SET @ID = 
(SELECT  SCOPE_IDENTITY());
			END

		SET NOCOUNT OFF
	END
GO
