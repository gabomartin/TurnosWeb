CREATE TABLE [dbo].[Service]
(
	[ServiceId] INT IDENTITY(1,1),
	[Description] VARCHAR(255) NOT NULL,
	[Cost] MONEY NOT NULL,
	[IsActive] BIT NOT NULL
)
GO
ALTER TABLE [dbo].[Service] ADD CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED ([ServiceId])
GO
