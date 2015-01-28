
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetCategory]
(
	@result bit output
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(CategoryOfDisease)
	FROM dbo.Disease
	GROUP BY CategoryOfDisease

	RETURN @result

END
GO
