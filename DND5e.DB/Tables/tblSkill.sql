CREATE TABLE tblSkill
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CharacterId] INT NOT NULL, 
    [Name] VARCHAR(255) NULL, 
    [Proficiency] BIT NULL, 
    [Expertise] BIT NULL

)