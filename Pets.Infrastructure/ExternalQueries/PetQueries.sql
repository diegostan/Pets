USE [Pets]
GO

CREATE TABLE [Pet]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Identifier] INT NOT NULL,
    [Age] INT NOT NULL,
    [OwnerId] UNIQUEIDENTIFIER NOT NULL,
    [DateCreated] DATETIME NOT NULL,

    CONSTRAINT [PK_Pet] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Pet_OwnerDocument] FOREIGN KEY([OwnerId]) REFERENCES [Owner] ([Id])
)
GO
-- Inserir novo pet
INSERT INTO [Pet] VALUES
(NEWID(),
'Mufasa', 
'Magalhaes', 
548611, 
4, 
'3d89ea3b-e67f-4db4-880c-778f34e35602', 
GETDATE())


SELECT * FROM [Pet]

-- Retornar por id do dono
SELECT *FROM [Pet] WHERE [OwnerId] = '3d89ea3b-e67f-4db4-880c-778f34e35602'

-- Vaccine pets request
SELECT  
[Pet].[Id], 
[Pet].[FirstName],
[Pet].[LastName], 
[Pet].[Identifier], 
[Pet].[Age], 
[Owner].[FirstName] as 'OwnerFirstName', 
[Vaccine].[Description] as 'VaccineDescription', 
[Category].[Description] as 'CategoryDescription'

FROM [Pet]

INNER JOIN [Vaccine] ON [Pet].[Id] = [Vaccine].[PetId]
INNER JOIN [Category] ON [Vaccine].[CategoryId] = [Category].[ID]
INNER JOIN [Owner] ON [Pet].[OwnerId] = [Owner].[Id]
WHERE [Vaccine].[PetID] = 'd517607a-55e6-4dfd-87b2-2634f0119cca'

GO