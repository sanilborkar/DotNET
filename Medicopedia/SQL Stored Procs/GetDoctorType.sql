set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetDoctorType]
(
	@category nvarchar(20)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT UserName
	FROM dbo.Users
	WHERE UserRole = 'Doctor'
	AND Specialization = @category
	
    
END

