
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Description:			Table for securities that have ever been in portfolio.
--
-- ATTENTION:			Do not forget to change schema name         !!!!    
-- ================================================================================================================

CREATE TABLE [<schemaName>].[Securities](
	[ISIN]			varchar(50)		NOT NULL PRIMARY KEY,
	[Name]			varchar(80)		NULL,
	[Issuer]		varchar(100)	NULL,
	[AssetClass]	varchar(50)		NULL,
	[FaceValue]		float			NULL,
	[Currency]		varchar(10)		NULL,
	[CouponType]	varchar(50)		NULL,
	[CouponPeriod]	varchar(50)		NULL,
	[Reference]		varchar(100)	NULL,
	[MaturityDate]	date			NULL,
	[OfferDate]		date			NULL,
	[Status]		varchar(50)		NULL,
	[IssueVolume]	float			NULL,
	[IssuerSector]	varchar(50)		NULL,
	[RiskType]		varchar(50)		NULL,
)
