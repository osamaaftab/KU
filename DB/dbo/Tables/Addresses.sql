CREATE TABLE [dbo].[Addresses] (
    [address_id] UNIQUEIDENTIFIER NOT NULL,
    [line_1]     NCHAR (50) NOT NULL,
    [line_2]     NCHAR (50) NOT NULL,
    [city]       NCHAR (10) NULL,
    [post_code]  NVARCHAR(10)        NULL,
    [state]      NCHAR (10) NULL,
    [country]    NCHAR (10) NULL,
    [customer_id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([address_id] ASC),
    CONSTRAINT [FK_Address_Customers] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customers] ([customer_id])

);

