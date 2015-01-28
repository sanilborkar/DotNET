-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SearchByMedicine]
(
	@category varchar(30),
	@type varchar(50)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT MedicineName, Category, MedicineInstructions
	FROM dbo.Medicines
	WHERE Category = @category
	AND MedicineName = @type

END
GO

exec [usp_SearchByMedicine] 'HEART', 'Tenex'