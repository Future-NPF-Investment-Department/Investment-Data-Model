
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Create date:			26.04.2023
-- Description:			Returns int (1 or -1) representation of flow direction based on flow string representation.
-- Execution example:	SELECT * FROM [asrm_data].[idep].[Reports] 
-- ================================================================================================================

CREATE TABLE [idep].[Reports] (
    [FileName]    NVARCHAR (450) NOT NULL,
    [Provider]    NVARCHAR (MAX) NOT NULL,
    [FullPath]    NVARCHAR (MAX) NOT NULL,
    [ReportDate]  DATETIME2 (7)  NOT NULL,
    [PricingType] NVARCHAR (MAX) NOT NULL,
    [Destination] NVARCHAR (MAX) NOT NULL
);