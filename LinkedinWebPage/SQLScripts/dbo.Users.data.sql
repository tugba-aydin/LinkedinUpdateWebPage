SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Photo], [Name], [Surname], [EmailAddress], [Password], [Position], [Country], [City]) VALUES (1, N'https://localhost:44346/Resources\Images\profile.jpg', N'Tuğba', N'Aydın', N'tugba.aydinn.94@gmail.com', NULL, N'Junior Software Developer', N'Türkiye', N'Sivas')
INSERT INTO [dbo].[Users] ([Id], [Photo], [Name], [Surname], [EmailAddress], [Password], [Position], [Country], [City]) VALUES (2, N'https://localhost:44346/Resources\Images\1517608193292.jpg', N'Aykut', N'Yakan', N'aykutyakan@gmail.com', NULL, N'Senior Software Developer', N'Türkiye', N'İstanbul')
SET IDENTITY_INSERT [dbo].[Users] OFF
