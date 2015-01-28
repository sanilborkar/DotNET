set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

alter PROCEDURE [dbo].[usp_GetDiseaseCategory]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(CategoryOfDisease)
	FROM dbo.Disease
	GROUP BY CategoryOfDisease


END

