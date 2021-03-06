set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER proc [dbo].[usp_ValidateUserPassword]
(
@userEmail nvarchar(50),
@password varchar(30),
@role nchar(10)
)
as
begin

select UserID, UserName, Password, UserRole, Email, Gender, DateOfBirth, AreaOfInterest, LicenceNumber, Specialization,RegistrationStatus, Vote
			from dbo.Users
			where Email = @userEmail and Password = @password and UserRole = @role
					and RegistrationStatus = 'Registered'
--	set @result = 1
--else
--	set @result = 0
end

