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

-- Apagar categoria
DELETE [Category] WHERE [Id] = 'id'

-- Inserir nova categoria
INSERT INTO [Category] 
VALUES 
(NEWID(), 
'Vacina QUALQUER', 
GETDATE())

-- Retornar todas as categorias
SELECT [Id], [Description], [DateCreated] FROM [Category]