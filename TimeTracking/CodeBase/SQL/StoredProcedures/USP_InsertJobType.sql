ALTER PROCEDURE [dbo].[USP_InsertJobType]
	(
    @Name NVARCHAR(250)
	, @ID INT output
	) AS

BEGIN
		SET NOCOUNT ON;
		
			BEGIN
				INSERT INTO [dbo].[JobTypes] ([Name])
			
				VALUES (@Name)

				SET @ID = (SELECT  SCOPE_IDENTITY());
			END

		SET NOCOUNT OFF
	END
-------------------

CREATE PROCEDURE [dbo].[USP_InsertJobType]
	(
    @Name NVARCHAR(250)
	--, @ID INT output
	) AS

BEGIN
		SET NOCOUNT ON;
		
			BEGIN
				INSERT INTO [dbo].[JobTypes] ([Name])
			
				VALUES (@Name)

				--SET @ID = 
(SELECT  SCOPE_IDENTITY());
			END

		SET NOCOUNT OFF
	END




	