
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SearchByDisease]
(
	@category varchar(30),
	@type varchar(50)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT NameOfDisease, DescriptionOfDisease, Symptoms, CategoryOfDisease
	FROM dbo.Disease
	WHERE CategoryOfDisease = @category
	AND NameOfDisease = @type

END
GO

exec [usp_SearchByDisease] 'Heart', 'Heart Attack'