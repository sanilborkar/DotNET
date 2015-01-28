set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[usp_GetSpecialistDetails]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  UserId, UserName, Specialization
	FROM dbo.Users
	where UserRole= 'Doctor'
    AND  RegistrationStatus='Registered'
    
	
    
END
