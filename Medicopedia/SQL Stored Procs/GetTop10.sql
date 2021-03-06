set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE [dbo].[usp_GetTop10]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT TOP 10 I.ItemID, A.AdviceName, I.ItemDescription, Q.Disease, M.MedicineName, U.UserName
	FROM (((((Items I INNER JOIN Advice A ON I.ItemID = A.AdviceID)
			 INNER JOIN Medicines M ON I.ItemID = M.MedicineID)
				INNER JOIN Query Q ON Q.QueryID = A.QueryID)
				INNER JOIN Disease D ON Q.Disease = D.NameOfDisease)
					INNER JOIN Users U ON A.AdvisedBy = U.UserID)
	ORDER BY (I.PositiveVotes - I.NegativeVotes)
    
END
