CREATE TABLE [dbo].[ProductCategory] (
    [ProductId]  INT NOT NULL,
    [CategoryId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC, [CategoryId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

