set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[usp_GetDiseaseType]
(
	@category nvarchar(20)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT NameOfDisease
	FROM dbo.Disease
	WHERE CategoryOfDisease = @category
    
END

