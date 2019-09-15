CREATE TABLE [dbo].[Visit]
(
	[VisitId] INT NOT NULL IDENTITY PRIMARY KEY,
	[Date] DATETIME NOT NULL DEFAULT (GETDATE()),	
	[Net] INT,
	[VisitTotal] DECIMAL,
	[Description] NVARCHAR(500),
	[SalePersonId] int,
	FOREIGN KEY ([SalePersonId]) REFERENCES SalePerson([SalePersonId]),
	[ClientId] int,
	FOREIGN KEY ([ClientId]) REFERENCES Client([ClientId]),
)
