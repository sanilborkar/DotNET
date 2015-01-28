set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER proc [dbo].[usp_AddComment]
(
@AdviceId int,
@UserId int,
@Comment nvarchar(100)
)
as
begin
insert into Comments
values(@AdviceId, @UserId, @Comment)
end
