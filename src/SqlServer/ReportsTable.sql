
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Description:			Table for csv reports loaded to the context. Reports are primarily portfolio reports and
--						flows reports. Each report has one-to-many relation with corresponding rows in Portfolio 
--						and Flows tables.
--
-- ATTENTION:			Do not forget to change schema name         !!!!    
-- ================================================================================================================

CREATE TABLE [<schemaName>].[Reports] (
    [Provider]		  varchar(50)		not null,
	[FileName]		  varchar(100)		not null   primary key,
	[FullPath]		  varchar(250)		not null,
	[ReportDate]	  date				not null,
	[RecordsNumber]   int				not null,
	[PricingType]	  varchar(50)		not null,
	[Destination]	  varchar(50)		not null,
	[LoadTime]		  datetime2			not null
);
GO

-- dummy value inserted
INSERT INTO [<schemaName>].[Reports]
VALUES ('Region Trust', 'Undefined', 'Undefined', '1900-01-01', 0,'RealPrices', 'Portfolio', '1900-01-01 00:00:00.0000000')