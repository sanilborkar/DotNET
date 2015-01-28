USE [master]
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Medicopedia_A40')
BEGIN
CREATE DATABASE [Medicopedia_A40] ON  PRIMARY 
( NAME = N'Medicopedia_A40', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Medicopedia_A40.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Medicopedia_A40_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Medicopedia_A40_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
EXEC dbo.sp_dbcmptlevel @dbname=N'Medicopedia_A40', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Medicopedia_A40].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [Medicopedia_A40] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET ARITHABORT OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Medicopedia_A40] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Medicopedia_A40] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Medicopedia_A40] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Medicopedia_A40] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Medicopedia_A40] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Medicopedia_A40] SET  READ_WRITE 
GO
ALTER DATABASE [Medicopedia_A40] SET RECOVERY FULL 
GO
ALTER DATABASE [Medicopedia_A40] SET  MULTI_USER 
GO
ALTER DATABASE [Medicopedia_A40] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Medicopedia_A40] SET DB_CHAINING OFF 
USE [Medicopedia_A40]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Disease]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Disease](
	[DiseaseID] [int] IDENTITY(1,1) NOT NULL,
	[NameOfDisease] [nvarchar](50) NULL,
	[DescriptionOfDisease] [nvarchar](500) NULL,
	[Symptoms] [nvarchar](500) NULL,
	[CategoryOfDisease] [nvarchar](50) NULL,
 CONSTRAINT [PK_Disease] PRIMARY KEY CLUSTERED 
(
	[DiseaseID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Admin](
	[UserName] [nvarchar](50) NULL,
	[AdminName] [nvarchar](50) NULL,
	[AdminId] [int] IDENTITY(1000,1) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InsertUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_InsertUser]
(
@role nchar(10),
@name nvarchar(50),
@emailID nvarchar(50),
@password nvarchar(50),
@gender varchar(10),
@dob smalldatetime,
@areaofinterest nvarchar(50),
@licenceNo nchar(10),
@specialization nvarchar(50),
@status nvarchar(50),
@vote int,
@userId int output
)
AS
BEGIN

	SET NOCOUNT ON;

insert into dbo.Users
values(@role,@name,@emailID,@password,@gender,@dob,@areaofinterest,@licenceNo,@specialization,@status,@vote)

set @userId = @@identity

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Items]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[PositiveVotes] [int] NULL,
	[NegativeVotes] [int] NULL,
	[ItemDescription] [nvarchar](250) NULL,
	[Timestamp] [smalldatetime] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Advice](
	[AdviceID] [int] IDENTITY(1,1) NOT NULL,
	[QueryID] [int] NULL,
	[AdviceName] [nvarchar](50) NULL,
	[AdvisedBy] [int] NULL,
	[AdviceStatus] [nvarchar](50) NULL,
	[ItemId] [int] NULL,
 CONSTRAINT [PK_Advice] PRIMARY KEY CLUSTERED 
(
	[AdviceID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetMedicineType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetMedicineType]
(
	@category nvarchar(20)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT MedicineName
	FROM dbo.Medicines
	WHERE Category = @category
    
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetDoctorType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetDoctorType]
(
	@category nvarchar(20)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT UserName
	FROM dbo.Users
	WHERE UserRole = ''Doctor''
	AND Specialization = @category
	
    
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetQueryId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create PROCEDURE [dbo].[usp_GetQueryId]
(
@queryid int
)
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT QueryTitle 
from dbo.Query
where QueryID=@queryid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetDoctorDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[usp_GetDoctorDetails]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT UserID, UserName, Specialization
	FROM dbo.Users
	WHERE UserRole= ''Doctor''
	AND RegistrationStatus = ''Unregistered''
	
    
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UpdateRegistrationStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_UpdateRegistrationStatus]
(
@userid int
)
AS
BEGIN
	
	SET NOCOUNT ON;
update dbo.Users
set RegistrationStatus=''Registered''
where UserID=@userid
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_RemoveUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_RemoveUser]
(
@userid int
)
AS
BEGIN
SET NOCOUNT ON;
delete from dbo.Users
where UserID=@userid
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SearchByMedicine]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_SearchByMedicine]
(
	@category varchar(30),
	@type varchar(50)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT MedicineName, Category, MedicineInstructions
	FROM dbo.Medicines
	WHERE Category = @category
	AND MedicineName = @type

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SearchByDoctor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_SearchByDoctor]
(
	@category varchar(30)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT UserName, Specialization, Email
	FROM dbo.Users
	WHERE Specialization = @category
	AND UserRole = ''Doctor''

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetSpecialistDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[usp_GetSpecialistDetails]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  UserId, UserName, Specialization
	FROM dbo.Users
	where UserRole= ''Doctor''
    AND  RegistrationStatus=''Registered''
    
	
    
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Comments](
	[AdviceID] [int] NULL,
	[UserId] [int] NULL,
	[Comment] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicines]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Medicines](
	[MedicineID] [int] IDENTITY(1,1) NOT NULL,
	[MedicineName] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[MedicineInstructions] [nvarchar](100) NULL,
	[ItemId] [int] NULL,
 CONSTRAINT [PK_Medicines] PRIMARY KEY CLUSTERED 
(
	[MedicineID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Prescription]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Prescription](
	[PrescriptionID] [int] IDENTITY(1000,1) NOT NULL,
	[Prescriber] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[QueryId] [int] NULL,
 CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED 
(
	[PrescriptionID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetDoctorCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[usp_GetDoctorCategory]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(Specialization)
	FROM dbo.Users
	WHERE UserRole = ''Doctor''
	GROUP BY Specialization



END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DoctorWorklist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DoctorWorklist](
	[WorkListID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[QueryID] [int] NULL,
	[ForwardedBy] [int] NULL,
 CONSTRAINT [PK_DoctorWorklist] PRIMARY KEY CLUSTERED 
(
	[WorkListID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[DateOfBirth] [smalldatetime] NULL,
	[AreaOfInterest] [nvarchar](50) NULL,
	[LicenceNumber] [nchar](10) NULL,
	[Specialization] [nvarchar](50) NULL,
	[RegistrationStatus] [nvarchar](50) NULL,
	[Vote] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Query]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Query](
	[QueryID] [int] IDENTITY(1,1) NOT NULL,
	[QueryTitle] [nvarchar](50) NULL,
	[UserId] [int] NULL,
	[Disease] [nvarchar](50) NULL,
	[SymptomsInQuery] [nvarchar](250) NULL,
	[DetailsOfEarlierReport] [nvarchar](250) NULL,
	[StatusOfQuery] [nvarchar](50) NULL,
 CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED 
(
	[QueryID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetDiseaseCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[usp_GetDiseaseCategory]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(CategoryOfDisease)
	FROM dbo.Disease
	GROUP BY CategoryOfDisease


END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SearchBySymptoms]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SearchBySymptoms]
(
	@symptoms nvarchar(500)
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT NameOfDisease, DescriptionOfDisease, Symptoms
	FROM dbo.Disease
	WHERE Symptoms LIKE ''%''+@symptoms+''%''

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SearchByDisease]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_SearchByDisease]
(
	@category varchar(30),
	@type varchar(50)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT NameOfDisease, DescriptionOfDisease, Symptoms, CategoryOfDisease
	FROM dbo.Disease
	WHERE CategoryOfDisease = @category
	AND NameOfDisease = @type

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetCategory]
(
	@result bit output
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(CategoryOfDisease)
	FROM dbo.Disease
	GROUP BY CategoryOfDisease

	RETURN @result

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetDiseaseType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[usp_GetDiseaseType]
(
	@category nvarchar(20)
)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT NameOfDisease
	FROM dbo.Disease
	WHERE CategoryOfDisease = @category
    
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetTop10]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[usp_GetTop10]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT TOP 10 I.ItemID, A.AdviceName, I.ItemDescription, Q.Disease, M.MedicineName, U.UserName
	FROM (((((Items I INNER JOIN Advice A ON I.ItemID = A.AdviceID)
			 INNER JOIN Medicines M ON I.ItemID = M.MedicineID)
				INNER JOIN Query Q ON Q.QueryID = A.QueryID)
				INNER JOIN Disease D ON Q.Disease = D.NameOfDisease)
					INNER JOIN Users U ON A.AdvisedBy = U.UserID)
	ORDER BY (I.PositiveVotes - I.NegativeVotes) DESC
    
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SubmitAdvice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[usp_SubmitAdvice]
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

end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAdviceDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[usp_GetAdviceDetails]
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
    
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAdviceById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[usp_GetAdviceById]
(
@adviceId int
)
as
begin
select ItemDescription
from dbo.Advice A INNER JOIN dbo.Items I
ON A.AdviceID = I.ItemID
where A.AdviceID = @adviceId
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_PositiveVote]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[usp_PositiveVote]
(
	@itemId int
  )
AS
BEGIN
	SET NOCOUNT ON;
update dbo.Items
set PositiveVotes=PositiveVotes+1
where ItemID=@itemId
End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_NegetiveVote]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[usp_NegetiveVote]
(
	@itemId int
  )
AS
BEGIN
	SET NOCOUNT ON;
update dbo.Items
set NegativeVotes=NegativeVotes+1
where ItemID=@itemId
End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_NegativeVote]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAdviceId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[usp_GetAdviceId]
(
@adviceId int
)
as
begin
select AdviceDescription
from dbo.Advice
where AdviceID=@adviceId
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InsertPres]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [dbo].[usp_InsertPres]
(
@prescriber int,
@desc nvarchar(500),
@queryid int
)
as
begin
insert into dbo.Prescription(Prescriber,Description,QueryId)
values(@prescriber,@desc,@queryid)
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetPrescription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[usp_GetPrescription]

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT A.QueryTitle, P.Description, U.UserName
	FROM((Query A INNER JOIN Prescription P ON A.QueryID = P.QueryId)
			INNER JOIN Users U ON  P.Prescriber=U.UserId)

end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_AddComment]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[usp_AddComment]
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
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetMedicineCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[usp_GetMedicineCategory]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT DISTINCT(Category)
	FROM dbo.Medicines
	GROUP BY Category



END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_addToWorklist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_addToWorklist]
(
@userID int,
@queryID int,
@forwardedBy int
)
as
begin
insert into dbo.DoctorWorklist
values(@userID,@queryID,@forwardedBy)
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetDoctorWorklist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetDoctorWorklist]
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

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ValidateUserPassword]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE proc [dbo].[usp_ValidateUserPassword]
(
@userEmail nvarchar(50),
@password varchar(30),
@role nchar(10)
)
as
begin

select UserID, UserName, Password, UserRole, Email, Gender, DateOfBirth, AreaOfInterest, LicenceNumber, Specialization,RegistrationStatus, Vote
			from dbo.Users
			where Email = @userEmail and Password = @password and UserRole = @role
					and RegistrationStatus = ''Registered''
--	set @result = 1
--else
--	set @result = 0
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SubmitQuery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE proc [dbo].[usp_SubmitQuery]
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
end' 
END
