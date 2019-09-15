CREATE TABLE [dbo].[State]
(
	[StateId] INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] NVARCHAR (150) NOT NULL,
	[CountryId] INT,
	FOREIGN KEY (CountryId) REFERENCES Country(CountryId)
)
