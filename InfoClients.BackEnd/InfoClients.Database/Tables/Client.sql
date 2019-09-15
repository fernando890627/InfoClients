CREATE TABLE [dbo].[Client]
(
	[ClientId] INT NOT NULL IDENTITY PRIMARY KEY,
	[Nit] NVARCHAR (150) NOT NULL,
	[FullName] NVARCHAR (150) NOT NULL,
	[Address] NVARCHAR (150) NOT NULL,
	[Phone] NVARCHAR (150) NOT NULL,
	[CityId] INT,
	[CreditLimit] INT,
	[AvailableCredit] INT,
	[VisitsPercentage] DECIMAL

)
