set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[usp_SearchByDoctor]
(
	@category varchar(30)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT UserName, Specialization, Email
	FROM dbo.Users
	WHERE Specialization = @category
	AND UserRole = 'Doctor'

END

