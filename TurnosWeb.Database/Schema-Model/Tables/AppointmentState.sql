CREATE TABLE [dbo].[AppointmentState]
(
	[AppointmentStateId] INT IDENTITY(1,1),
	[Description] VARCHAR(25) NOT NULL
)
GO
ALTER TABLE [dbo].[AppointmentState] ADD CONSTRAINT [PK_AppointmentState] PRIMARY KEY CLUSTERED ([AppointmentStateId])
GO
