set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

create procedure [dbo].[usp_NegativeVote]
(
	@itemId int
  )
AS
BEGIN
	SET NOCOUNT ON;
update dbo.Items
set NegativeVotes=NegativeVotes+1
where ItemID=@itemId
End
