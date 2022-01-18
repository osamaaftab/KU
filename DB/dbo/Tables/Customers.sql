CREATE TABLE [dbo].[Customers] (
    [customer_id]    UNIQUEIDENTIFIER NOT NULL,
    [customer_name]  NCHAR (50) NOT NULL,
    [customer_phone] NCHAR (10) NULL,
    [customer_email] NCHAR (50) NULL,
    [customer_dob]   NCHAR (10) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([customer_id] ASC),
);

