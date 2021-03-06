set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER proc [dbo].[usp_SubmitAdvice]
(
@QueryID int,
@AdvisedBy int,
@AdviceDescription nvarchar(250),
@AdviceStatus nvarchar(50)
)
as
begin

insert into Items(ItemDescription)
values(@AdviceDescription) 

declare @itemId int
select @itemId = ItemID
from Items
where ItemDescription = @AdviceDescription

	insert into Advice
	values(@QueryID, @AdviceDescription, @AdvisedBy, @AdviceStatus, @itemId)

end


exec usp_SubmitAdvice 1, 9, 'Dengue trial advice', 'Resolved'