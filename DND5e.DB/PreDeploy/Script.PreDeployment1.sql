/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS tblAbilityScore
DROP TABLE IF EXISTS tblCharacter
DROP TABLE IF EXISTS tblEquipment
DROP TABLE IF EXISTS tblFeat
DROP TABLE IF EXISTS tblPersonality
DROP TABLE IF EXISTS tblSave
DROP TABLE IF EXISTS tblSkill
DROP TABLE IF EXISTS tblSpell
DROP TABLE IF EXISTS tblUser