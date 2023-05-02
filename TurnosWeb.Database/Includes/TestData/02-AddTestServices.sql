SET IDENTITY_INSERT [dbo].[Service] ON

INSERT INTO [dbo].[Service](ServiceId, Description, Cost, IsActive) VALUES
(1, 'Corte de pelo', 1500, 1),
(2, 'Corte de barba', 900, 1),
(3, 'Corte de pelo y barba', 2000, 1),
(4, 'Tintura', 1600, 1)

SET IDENTITY_INSERT [dbo].[Service] OFF