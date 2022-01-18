CREATE TABLE [dbo].[Accounts] (
    [account_id]      UNIQUEIDENTIFIER   NOT NULL,
    [customer_id]     UNIQUEIDENTIFIER   NOT NULL,
    [account_name]    NCHAR (10)   NOT NULL,
    [date_opned]      DATETIME     NOT NULL,
    [date_closed]     DATETIME     NULL,
    [current_balance] DECIMAL (18) NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([account_id] ASC),
    CONSTRAINT [FK_Accounts_Customers] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customers] ([customer_id])
);

