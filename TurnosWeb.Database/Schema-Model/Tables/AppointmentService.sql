CREATE TABLE [dbo].[AppointmentService]
(
	[AppointmentServiceId] INT NOT NULL,
	[AppointmentId] INT NOT NULL,
	[ServiceId] INT NOT NULL,
	[AmountCharged] MONEY NOT NULL
)
GO
ALTER TABLE [dbo].[AppointmentService] ADD CONSTRAINT [PK_AppointmentService] PRIMARY KEY CLUSTERED ([AppointmentServiceId])
GO
