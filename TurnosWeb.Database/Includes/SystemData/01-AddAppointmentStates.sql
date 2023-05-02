SET IDENTITY_INSERT [dbo].[AppointmentState] ON

INSERT INTO [dbo].[AppointmentState](AppointmentStateId, Description) VALUES
(1, 'Programmed'),
(2, 'On course'),
(3, 'Finished'),
(4, 'Cancelled')

SET IDENTITY_INSERT [dbo].[AppointmentState] OFF


