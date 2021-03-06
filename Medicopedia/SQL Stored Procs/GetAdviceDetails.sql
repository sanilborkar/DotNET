set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[usp_GetAdviceDetails]
(
	@adviceid int
)
AS
BEGIN
	SET NOCOUNT ON;
        SELECT A.AdviceName, I.PositiveVotes, I.NegativeVotes, C.Comment
	    FROM ((Items I INNER JOIN Advice A ON I.ItemID = A.ItemID)
                INNER JOIN Comments C ON I.ItemID = C.AdviceID )
	    WHERE  I.ItemId = @adviceid
    
END

exec usp_GetAdviceDetails 1