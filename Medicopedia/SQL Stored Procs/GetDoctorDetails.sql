set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[usp_GetDoctorDetails]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT UserID, UserName, Specialization
	FROM dbo.Users
	WHERE UserRole= 'Doctor'
	AND RegistrationStatus = 'Unregistered'
	
    
END

exec [usp_GetDoctorDetails]