USE [SAPPXML]
GO

/****** Object:  StoredProcedure [dbo].[SPR_INSERT001]    Script Date: 04/21/2013 09:55:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SPR_INSERT001]
	-- Add the parameters for the stored procedure here
	@tFile			nchar(200) = NULL	,
	@tLine			nchar(200)= NULL	,
	@tRoutine		nchar(200)	= NULL,
	@tProcess		nchar(200)	= NULL,
	@tThead			nchar(200)	= NULL,
	@tContext		nchar(200)	= NULL,
	@tSourceObject	nchar(200)	= NULL,
	@tStackId		nchar(200)	= NULL,
	@tStackLevel	nchar(200)	= NULL,
	@CData			nchar(1000)	= NULL,
	@Script			nchar(1000)	= NULL,
	@Creation		datetime	= NULL,
	@Problem		nchar(200)	= NULL,
	@tTSTwo			nchar(200)= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

BEGIN TRANSACTION

INSERT INTO [SAPPXML].[dbo].[tSScript2]
           ([tFile]					,[tLine]
           ,[tRoutine]				,[tProcess]
           ,[tThead]				,[tContext]
           ,[tSourceObject]			,[tStackId]
           ,[tStackLevel]			,[CData]
           ,[Script]				,[Creation]
           ,[Problem],				[tTSTwo])
     VALUES
           (@tFile					,@tLine			,
			@tRoutine				,@tProcess		,
			@tThead					,@tContext		, 
			@tSourceObject			,@tStackId		, 
			@tStackLevel			,@CData			, 
            @Script					,@Creation		,
			@Problem				,@tTSTwo)

IF(@@ERROR != 0)
BEGIN 
	ROLLBACK TRAN
	SELECT 'ERROR' AS 'RESPUESTA'
END
ELSE 
BEGIN 
	COMMIT TRANSACTION
	SELECT 'OK'		AS 'RESPUESTA'
END

END
GO

