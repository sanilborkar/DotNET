set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

Create proc [dbo].[usp_GetAdviceById]
(
@adviceId int
)
as
begin
select ItemDescription
from dbo.Advice A INNER JOIN dbo.Items I
ON A.AdviceID = I.ItemID
where A.AdviceID = @adviceId
end
