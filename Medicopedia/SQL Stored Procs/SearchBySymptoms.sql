
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE [dbo].[usp_SearchBySymptoms]
(
	@symptoms nvarchar(500)
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT NameOfDisease, DescriptionOfDisease, Symptoms
	FROM dbo.Disease
	WHERE Symptoms LIKE '%'+@symptoms+'%'

END
GO

exec [dbo].[usp_SearchBySymptoms] 'Eye pain,Swelling of the eyes , Redness in the eyes , Yellow, green or watery discharge from the eyes which collects overnight and crusts over the eye '