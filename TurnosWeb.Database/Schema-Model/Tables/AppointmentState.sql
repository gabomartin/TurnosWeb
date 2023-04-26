CREATE TABLE [dbo].[AppointmentState]
(
	[AppointmentStateId] INT NOT NULL PRIMARY KEY,
	[Description] VARCHAR(25) NOT NULL
)
GO
ALTER TABLE [dbo].[AppointmentState] ADD CONSTRAINT [PK_AppointmentState] PRIMARY KEY CLUSTERED ([AppointmentStateId])
GO
