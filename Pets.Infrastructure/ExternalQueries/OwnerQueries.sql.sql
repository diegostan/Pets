USE [Pets]
GO

CREATE TABLE [Owner]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [DocumentNumber] NVARCHAR(16) NOT NULL,
    [DocumentType] INT NOT NULL,
    [Email] NVARCHAR(32),
    [DateCreated] DATETIME NOT NULL,

    CONSTRAINT [PK_Owner] PRIMARY KEY([Id])
)
GO
-- Inserir Usuário
INSERT INTO 
[Owner] 
VALUES 
(NEWID(), 
'Diego', 
'Magalhaes', 
'12356875898', 
0, 
'diego@stansdk.com', 
'2021-07-07 08:38:25')
GO



SELECT *FROM [Owner]

-- Retornar por documento
SELECT TOP 1 * FROM [Owner] WHERE [DocumentNumber] = '12356875898'
-- Retornar por email
SELECT TOP 1 * FROM [Owner] WHERE [Email] = '12356875898'

-- Retornar todos pets por dono
SELECT
[Pet].[Id],
[Pet].[FirstName],
[Pet].[LastName],
[Pet].[Identifier],
[Pet].[Age]
FROM [Owner]
INNER JOIN [Pet] ON [Owner].Id = [Pet].OwnerId
WHERE [Owner].[DocumentNumber] = '12356875898'

GO