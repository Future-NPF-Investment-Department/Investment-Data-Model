
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Description:			Table for efficiency calculation results.
--
-- ATTENTION:			Do not forget to change schema name         !!!!    
-- ================================================================================================================

CREATE TABLE [<schemaName>].[Efficiency](
	[StartDate]				date			NULL,
	[EndDate]				date			NULL,
	[LifeTime]				int				NULL,
	[Level]					varchar(50)		NULL,
	[AM]					varchar(50)		NULL,
	[Fund]					varchar(50)		NULL,
	[EntityType]			varchar(50)		NULL,
	[Strategy]				varchar(50)		NULL,
	[Contract]				varchar(100)	NULL,
	[AssetClass]			varchar(50)		NULL,
	[ISIN]					varchar(50)		NULL,
	[SecurityName]			varchar(50)		NULL,
	[RiskType]				varchar(50)		NULL,
	[Income]				float			NULL,
	[AveragePortfolio]		float			NULL,
	[MWR]					float			NULL,
	[TWR]					float			NULL,
	[STD]					float			NULL,
	[Sharpe]				float			NULL,
	[IR]					float			NULL,
	[RFRate]				float			NULL,
	[NameIndex1]			varchar(50)		NULL,
	[NameIndex2]			varchar(50)		NULL,
	[NameIndex3]			varchar(50)		NULL,
	[NameIndex4]			varchar(50)		NULL,
	[NameIndex5]			varchar(50)		NULL,
	[TWRIndex1]				float			NULL,
	[TWRIndex2]				float			NULL,
	[TWRIndex3]				float			NULL,
	[TWRIndex4]				float			NULL,
	[TWRIndex5]				float			NULL,
	[STDIndex1]				float			NULL,
	[STDIndex2]				float			NULL,
	[STDIndex3]				float			NULL,
	[STDIndex4]				float			NULL,
	[STDIndex5]				float			NULL,
	[CalculationTime]		datetime2(7)	NOT NULL PRIMARY KEY
)
