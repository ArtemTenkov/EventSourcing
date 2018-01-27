CREATE TABLE [dbo].[Transaction]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [MerchantId] UNIQUEIDENTIFIER NOT NULL, 
    [BuyerId] UNIQUEIDENTIFIER NOT NULL, 
    [Amount] DECIMAL NOT NULL, 
    [TransactionDateTime] DATETIME NOT NULL, 
    [TransactionStatusCode] CHAR(2) NOT NULL DEFAULT 'PR',
	CONSTRAINT FK_MerchantId FOREIGN KEY (MerchantId) REFERENCES [dbo].[User](Id),
	CONSTRAINT FK_BuyerId FOREIGN KEY (BuyerId) REFERENCES [dbo].[User](Id)
)
