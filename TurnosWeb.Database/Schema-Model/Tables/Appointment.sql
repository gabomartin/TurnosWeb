CREATE TABLE [dbo].[Appointment]
(
	[AppointmentId] INT NOT NULL,
	[BarberId] INT NULL,
	[StateId] INT NOT NULL,
	[AppointmentDate] DATETIME NOT NULL,
	[ClientName] VARCHAR(50) NOT NULL,	
	[TotalCharged] MONEY NULL,
	[CreationDate] DATETIME NOT NULL,
	[ModifiedDate] DATETIME NOT NULL
)
GO
ALTER TABLE [dbo].[Appointment] ADD CONSTRAINT [PK_AppointmentId] PRIMARY KEY CLUSTERED ([AppointmentId])
GO
ALTER TABLE [dbo].[Appointment] ADD CONSTRAINT [FK_BarberId] FOREIGN KEY ([BarberId]) REFERENCES [dbo].[Barber] ([BarberId])
GO
ALTER TABLE [dbo].[Appointment] ADD CONSTRAINT [FK_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[AppointmentState] ([AppointmentStateId])
GO