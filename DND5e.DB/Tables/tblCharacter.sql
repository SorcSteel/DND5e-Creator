﻿CREATE TABLE tblCharacter 
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] VARCHAR(255) NOT NULL, 
    [Name] VARCHAR(255) NULL, 
    [Race] VARCHAR(255) NULL, 
    [Level] INT NULL, 
    [Class] VARCHAR(255) NULL, 
    [Alignment] VARCHAR(255) NULL, 
    [Background] VARCHAR(255) NULL, 
    [ExperiencePoints] INT NULL, 
    [HitDie] INT NULL, 
    [MaxHp] INT NULL, 
    [CurrentHp] INT NULL, 
    [TempHp] INT NULL, 
    [Ac] INT NULL, 
    [Initiative] INT NULL, 
    [ProficiencyBonus] INT NULL, 
    [Speed] INT NULL,
)