set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER proc [dbo].[usp_SubmitQuery]
(
--@QueryID int,
@UserId int,
@QueryTitle nvarchar(5),
@Disease nvarchar(50),
@SymptomsInQuery nvarchar(250),
@DetailsOfEarlierReport nvarchar(250),
@StatusOfQuery nvarchar(50)
)
as
begin
insert into Query(UserId,QueryTitle,Disease,SymptomsInQuery,DetailsOfEarlierReport,StatusOfQuery)
values(@UserId,@QueryTitle,@Disease,@SymptomsInQuery,@DetailsOfEarlierReport,@StatusOfQuery)
end

exec [usp_SubmitQuery] 12,'Smallpox query', 'Smallpox', 'small pox pokes', 'none', 'Pending'