SET IDENTITY_INSERT [dbo].[Barber] ON

INSERT INTO [dbo].[Barber](BarberId, BarberName, IsActive) VALUES
(1, 'Juan', 1),
(2, 'Rafa', 1),
(3, 'Mike', 1),
(4, 'Adolfo', 1)

SET IDENTITY_INSERT [dbo].[Barber] OFF

