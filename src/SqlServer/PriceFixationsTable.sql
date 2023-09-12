
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Description:			Table for price fixation periods.  e.g. the period from February to October 2022 was 
--                      notable for price fixing in the securities market. 
--
-- ATTENTION:			Do not forget to change schema name         !!!!    
-- ================================================================================================================

CREATE TABLE [<schemaName>].[PriceFixations] (
    [FundName]              VARCHAR (100)	NOT NULL,
    [FixationDate]          DATE			NOT NULL,
    [Start]                 DATE			NOT NULL,
    [End]					DATE,
	CONSTRAINT PK_PriceFixations PRIMARY KEY ([FundName], [FixationDate])
);


