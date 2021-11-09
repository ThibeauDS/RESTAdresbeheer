CREATE TABLE [dbo].[adres]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [straatID] INT NOT NULL, 
    [huisnummer] NVARCHAR(10) NOT NULL, 
    [busnummer] NVARCHAR(25) NULL, 
    [appartementnummer] NVARCHAR(25) NULL, 
    [postcode] INT NOT NULL, 
    [x] FLOAT NOT NULL, 
    [y] FLOAT NOT NULL,
	CONSTRAINT [FK_adres_straat] FOREIGN KEY ([straatID]) REFERENCES [dbo].[straat] ([Id])
)
