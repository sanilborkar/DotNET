set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[usp_RemoveUser]
(
@userid int
)
AS
BEGIN
SET NOCOUNT ON;
delete from dbo.Users
where UserID=@userid
END

