/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Country]([Name]) VALUES('United States')
INSERT INTO [dbo].[Country]([Name]) VALUES('Colombia')
INSERT INTO [dbo].[Country]([Name]) VALUES('Mexico')
GO

INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('California',1)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Florida',1)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Texas',1)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Nevada',1)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Antioquia',2)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Cundinamarca',2)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Atlantico',2)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Valle',2)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Durango',3)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Zacatecas',3)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Veracruz',3)
INSERT INTO [dbo].[State] ([Name],[CountryId]) VALUES('Jalisco',3)
GO

INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Los Ángeles',1)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('San Diego',1)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Miami',2)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Orlando',2)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Houston',3)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('California',3)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Las Vegas',4)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Carson Ciy',4)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Medellín',5)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Rionegro',5)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Bogotá',6)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Soacha',6)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Barranquilla',7)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Soledad',7)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Cali',8)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Buga',8)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Cuencamé',9)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Nuevo Ideal',9)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Zacatecas',10)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Guadalupe',10)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Veracruz',11)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Córdoba',11)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Guadalajara',12)
INSERT INTO [dbo].City ([Name],[StateId]) VALUES('Puerto Vallarta',12)
GO