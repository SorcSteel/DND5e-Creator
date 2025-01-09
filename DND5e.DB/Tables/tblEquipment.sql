CREATE TABLE tblEquipment 
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CharacterId] INT NOT NULL, 
    [Name] VARCHAR(255) NULL, 
    [Amount] INT NULL, 
    [Description] VARCHAR(255) NULL
)