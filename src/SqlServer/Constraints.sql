
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Description:			Constraints for Portfolio, Flows, Securities and Reports tables.
--
-- ATTENTION:			Do not forget to change schema name         !!!!    
-- ================================================================================================================

ALTER TABLE [<schemaName>].[Portfolio]
ADD CONSTRAINT [<FK_Name>] FOREIGN KEY (SourceFile) REFERENCES [<schemaName>].[Reports] (FileName) ON DELETE CASCADE
GO

ALTER TABLE [<schemaName>].[Portfolio]
ADD CONSTRAINT [<FK_Name>] FOREIGN KEY (ISIN) REFERENCES [<schemaName>].[Securities] (ISIN) ON DELETE NO ACTION
GO

ALTER TABLE [<schemaName>].[Flows]
ADD CONSTRAINT [<FK_Name>] FOREIGN KEY (SourceFile) REFERENCES [<schemaName>].[Reports] (FileName) ON DELETE CASCADE
GO

ALTER TABLE [<schemaName>].[Flows]
ADD CONSTRAINT [<FK_Name>] FOREIGN KEY (ISIN) REFERENCES [<schemaName>].[Securities] (ISIN) ON DELETE NO ACTION
GO