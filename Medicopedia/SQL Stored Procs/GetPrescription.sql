set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[usp_GetPrescription]

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT A.QueryTitle, P.Description, U.UserName
	FROM((Query A INNER JOIN Prescription P ON A.QueryID = P.QueryId)
			INNER JOIN Users U ON  P.Prescriber=U.UserId)

end
