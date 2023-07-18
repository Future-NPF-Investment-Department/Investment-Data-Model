CREATE TABLE [idep].[PriceFixations] (
    [FundName]              VARCHAR (100)	NOT NULL,
    [FixationDate]          DATE			NOT NULL,
    [Start]                 DATE			NOT NULL,
    [End]					DATE,
	CONSTRAINT PK_PriceFixations PRIMARY KEY ([FundName], [FixationDate])
);


