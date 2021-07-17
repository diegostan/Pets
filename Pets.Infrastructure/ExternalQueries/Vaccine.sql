USE [Pets]
GO

CREATE TABLE [Vaccine]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Description] NVARCHAR(50) NOT NULL,
    [CategoryId] UNIQUEIDENTIFIER NOT NULL,
    [PetId] UNIQUEIDENTIFIER NOT NULL,
    [DateCreated] DATETIME NOT NULL,

    CONSTRAINT [PK_Vaccine] PRIMARY KEY([Id]),  
    CONSTRAINT [FK_VACCINE_Category] FOREIGN KEY([CategoryId]) REFERENCES [Category] ([Id]),
    CONSTRAINT [FK_VACCINE_Pet] FOREIGN KEY([PetId]) REFERENCES [Pet] ([Id])
)
GO
-- Inserir nova vacina
INSERT INTO [Vaccine]  
VALUES 
(NEWID(), 
'Vacina aplicada', 
'8c3a2bc7-fa43-4609-9b9e-c7821fd8f679', 
'd517607a-55e6-4dfd-87b2-2634f0119cca', 
GETDATE())

SELECT [Id], [Description], [CategoryId], [PetId], [DateCreated]
FROM [Vaccine]