CREATE TABLE [dbo].[Transactions] (
    [transaction_id]      UNIQUEIDENTIFIER   NOT NULL,
    [account_id]          UNIQUEIDENTIFIER   NOT NULL,
    [date_of_transaction] DATETIME     NOT NULL,
    [amount]              DECIMAL (18) NOT NULL,
    [balance]             DECIMAL (18) NULL,
    [transaction_type_id] UNIQUEIDENTIFIER   NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([transaction_id] ASC),
    CONSTRAINT [FK_Transactions_Accounts] FOREIGN KEY ([account_id]) REFERENCES [dbo].[Accounts] ([account_id]),
    CONSTRAINT [FK_Transactions_Transaction_types] FOREIGN KEY ([transaction_type_id]) REFERENCES [dbo].[Transaction_types] ([transaction_type_id])
);

