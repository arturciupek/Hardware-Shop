CREATE TABLE [dbo].[Customers] (
    [CustomerId] INT           IDENTITY (2, 2) NOT NULL,
    [CName]      VARCHAR (100) NULL,
    [Phone]      VARCHAR (15)  NULL,
    [Email]      VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [ProductName] VARCHAR (100)   NULL,
    [Category]    VARCHAR (50)    NULL,
    [Quantity]    INT             NULL,
    [Price]       DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

CREATE TABLE [dbo].[Sales] (
    [SaleID]       INT             IDENTITY (3, 3) NOT NULL,
    [CustomerID]   INT             NULL,
    [CustomerName] VARCHAR (50)    NULL,
    [ProductID]    INT             NULL,
    [ProductName]  VARCHAR (50)    NULL,
    [QuantitySold] INT             NULL,
    [TotalAmount]  DECIMAL (10, 2) NULL,
    [SaleDate]     DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([SaleID] ASC),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerId]),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);