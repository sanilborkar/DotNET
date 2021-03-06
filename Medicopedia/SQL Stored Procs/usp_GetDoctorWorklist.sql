set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetDoctorWorklist]
(
	@userId int
)
AS
BEGIN

	SET NOCOUNT ON;

	select Q.QueryID, Q.QueryTitle, Q.SymptomsInQuery, U.UserName, Q.Disease
	from ((dbo.DoctorWorklist D inner join dbo.Query Q on D.QueryID = Q.QueryID)
			inner join dbo.Users U on D.UserId = U.UserId)
	where D.ForwardedBy = @userId

END

exec [usp_GetDoctorWorklist] 9
