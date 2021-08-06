USE [Pets]
GO

CREATE TABLE [Category]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Description] NVARCHAR(50) NOT NULL,
    [DateCreated] DATETIME NOT NULL,

    CONSTRAINT [PK_Category] PRIMARY KEY([Id])    
)
GO