
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Description:			Table for flows.
--
-- ATTENTION:			Do not forget to change schema name         !!!!    
-- ================================================================================================================

CREATE TABLE [<schemaName>].[Flows](
	[FlowId]			bigint			NULL,
	[AmName]			varchar(50)		NOT NULL,
	[FundName]			varchar(100)	NOT NULL,
	[EntityType]		varchar(50)		NOT NULL,
	[Strategy]			varchar(50)		NOT NULL,
	[Contract]			varchar(100)	NOT NULL,
	[AssetClass]		varchar(50)		NOT NULL,
	[AssetType]			varchar(50)		NOT NULL,
	[AssetName]			varchar(200)	NOT NULL,
	[RsNumber]			varchar(250)	NOT NULL,
	[RegNumber]			varchar(250)	NOT NULL,
	[ISIN]				varchar(50)		NOT NULL,
	[RiskType]			varchar(50)		NOT NULL,
	[OperationDate]		date			NULL,
	[PayDate]			date			NOT NULL,
	[TransType]			varchar(50)		NOT NULL,
	[NetValue]			float			NULL,
	[AccruedInterest]	float			NULL,
	[FullValue]			float			NOT NULL,
	[Amount]			float			NULL,
	[Comission]			float			NULL,
	[BrokerComission]	float			NULL,
	[Comment]			varchar(max)	NULL,
	[LoadTime]			datetime2(7)	NOT NULL PRIMARY KEY,
	[SourceFile]		varchar(100)	NOT NULL
)