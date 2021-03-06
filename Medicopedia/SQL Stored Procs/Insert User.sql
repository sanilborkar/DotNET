set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[usp_InsertUser]
(
@role nchar(10),
@name nvarchar(50),
@emailID nvarchar(50),
@password nvarchar(50),
@gender varchar(10),
@dob smalldatetime,
@areaofinterest nvarchar(50),
@licenceNo nchar(10),
@specialization nvarchar(50),
@status nvarchar(50),
@vote int,
@userId int output
)
AS
BEGIN

	SET NOCOUNT ON;

insert into dbo.Users
values(@role,@name,@emailID,@password,@gender,@dob,@areaofinterest,@licenceNo,@specialization,@status,@vote)

set @userId = @@identity

END
