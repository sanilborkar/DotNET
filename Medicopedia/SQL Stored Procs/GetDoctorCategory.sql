set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


CREATE PROCEDURE [dbo].[usp_GetDoctorCategory]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(Specialization)
	FROM dbo.Users
	WHERE UserRole = 'Doctor'
	GROUP BY Specialization



END

