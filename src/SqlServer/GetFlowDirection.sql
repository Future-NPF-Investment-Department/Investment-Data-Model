
-- ================================================================================================================
-- Author:				Kirill Nestrugin
-- Create date:			03.03.2022
-- Description:			Returns int (1 or -1) representation of flow direction based on flow string representation.
-- Execution example:	SELECT [<schemaName>].[GetFlowDirection]('CashInflow') AS [FlowDirection]
-- ATTENTION:			Do not forget change schema name
-- ================================================================================================================


CREATE FUNCTION [schemaName].[GetFlowDirection] (@TransitionType varchar(50)) RETURNS FLOAT AS
BEGIN
	DECLARE @retval FLOAT
	SELECT @retval = CASE	
						WHEN @TransitionType = 'CashInflow'				THEN 1.0 
						WHEN @TransitionType = 'SecuritiesArrival'		THEN 1.0   
						WHEN @TransitionType = 'SecuritiesPurchase'		THEN 1.0   
						WHEN @TransitionType = 'CurrencyPurchase'		THEN 1.0   
						WHEN @TransitionType = 'RepoPurchase'			THEN 1.0    
						WHEN @TransitionType = 'MPBOpen'				THEN 1.0   
						WHEN @TransitionType = 'DepositOpen'			THEN 1.0    
						WHEN @TransitionType = 'OtherCashInflow'		THEN 1.0  
						WHEN @TransitionType = 'CashOutflow'			THEN -1.0 
						WHEN @TransitionType = 'SecuritiesWithdrawal'	THEN -1.0 
						WHEN @TransitionType = 'SecuritiesSale'			THEN -1.0 
						WHEN @TransitionType = 'CurrencySale'			THEN -1.0 
						WHEN @TransitionType = 'Dividends'				THEN -1.0 
						WHEN @TransitionType = 'CouponPayment'			THEN -1.0 
						WHEN @TransitionType = 'NominalPayment'			THEN -1.0 
						WHEN @TransitionType = 'RepoSale'				THEN -1.0 
						WHEN @TransitionType = 'MPBClosure'				THEN -1.0 
						WHEN @TransitionType = 'DepositClosure'			THEN -1.0 
						WHEN @TransitionType = 'InterestPayment'		THEN -1.0 
						WHEN @TransitionType = 'OtherCashOutflow'		THEN -1.0 
																		ELSE 0.0 
					END
	RETURN @retval
END