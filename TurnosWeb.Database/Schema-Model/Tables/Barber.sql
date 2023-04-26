CREATE TABLE [dbo].[Barber]
(
	[BarberId] INT NOT NULL,
	[BarberName] VARCHAR(50) NOT NULL,
	[IsActive] BIT NOT NULL
)
GO
ALTER TABLE [dbo].[Barber] ADD CONSTRAINT [PK_Barber] PRIMARY KEY CLUSTERED ([BarberId])
GO
