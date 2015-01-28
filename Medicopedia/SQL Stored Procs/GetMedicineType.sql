set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetMedicineType]
(
	@category nvarchar(20)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT MedicineName
	FROM dbo.Medicines
	WHERE Category = @category
    
END

