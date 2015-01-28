
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_GetPersonalizationDetails
AS
BEGIN

	SET NOCOUNT ON;

	SELECT BackColor, LeftPaneColor, LogoColor
	FROM dbo.Personalization

END
GO

exec usp_GetPersonalizationDetails