CREATE TABLE [dbo].[Transaction_types] (
    [transaction_type_id] UNIQUEIDENTIFIER NOT NULL,
    [transaction_code]    NCHAR (10) NOT NULL,
    [transaction_label]   NCHAR (10) NOT NULL,
    CONSTRAINT [PK_Transaction_types] PRIMARY KEY CLUSTERED ([transaction_type_id] ASC)
);

