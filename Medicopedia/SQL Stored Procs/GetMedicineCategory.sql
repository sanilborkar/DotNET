set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[usp_GetMedicineCategory]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(Category)
	FROM dbo.Medicines
	GROUP BY Category



END

