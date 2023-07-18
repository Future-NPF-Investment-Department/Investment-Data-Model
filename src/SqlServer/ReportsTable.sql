
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Create date:			26.04.2023
-- Description:			Returns int (1 or -1) representation of flow direction based on flow string representation.
-- Execution example:	SELECT * FROM [asrm_data].[idep].[Reports] 
-- ================================================================================================================

CREATE TABLE [idep].[Reports] (
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

INSERT INTO [idep].[Reports]
VALUES ('Region Trust', 'Undefined', 'Undefined', '1900-01-01', 0,'RealPrices', 'Portfolio', '1900-01-01 00:00:00.0000000')