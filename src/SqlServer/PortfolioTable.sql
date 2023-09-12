
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Description:			Table for net assets values.
--
-- ATTENTION:			Do not forget to change schema name         !!!!    
-- ================================================================================================================

CREATE TABLE [<schemaName>].[Potfolio](
	[Date]						date				NOT NULL,
	[AmName]					varchar(50)			NOT NULL,
	[FundName]					varchar(100)		NULL,
	[EntityType]				varchar(50)			NOT NULL,
	[Strategy]					varchar(50)			NOT NULL,
	[Contract]					varchar(100)		NOT NULL,
	[AssetClass]				varchar(50)			NOT NULL,
	[AssetType]					varchar(50)			NOT NULL,
	[Emitent]					varchar(150)		NULL,
	[INN]						varchar(50)			NULL,
	[RegNumber]					varchar(100)		NOT NULL,
	[ISIN]						varchar(50)			NOT NULL,
	[ShortName]					varchar(200)		NULL,
	[FullName]					varchar(300)		NULL,
	[RiskType]					varchar(50)			NOT NULL,
	[Notional]					float				NULL,
	[Currency]					varchar(10)			NULL,
	[Amount]					float				NULL,
	[NetValue]					float				NULL,
	[AccruedInterest]			float				NULL,
	[FullValue]					float				NOT NULL,
	[DepositExpirationDate]		date				NULL,
	[CurrentRate]				float				NULL,
	[RateType]					varchar(100)		NULL,
	[InstrumentBestRating]		varchar(50)			NULL,
	[InstrumentRatingAgency]	varchar(200)		NULL,
	[EmitentBestRating]			varchar(50)			NULL,
	[EmitentRatingAgency]		varchar(200)		NULL,
	[AccountingMethod]			varchar(50)			NULL,
	[PriceFixation]				varchar(50)			NOT NULL,
	[UseRealPricing]			bit					NOT NULL,
	[UseFairPricing]			bit					NOT NULL,
	[LoadTime]					datetime2(7)		NOT NULL PRIMARY KEY,
	[SourceFile]				varchar(100)		NOT NULL,
	[SourcePricing]				varchar(50)			NOT NULL,
)