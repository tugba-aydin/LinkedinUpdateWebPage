SET IDENTITY_INSERT [dbo].[Contacts] ON
INSERT INTO [dbo].[Contacts] ([Id], [PhoneNumber], [PhoneNumberType], [Address], [Birthday], [UserId]) VALUES (1, N'123456', N'İş', N'Sivas', N'1994-12-09 00:00:00', 1)
INSERT INTO [dbo].[Contacts] ([Id], [PhoneNumber], [PhoneNumberType], [Address], [Birthday], [UserId]) VALUES (2, N'0539288292', N'Mobil', N'İstanbul', N'1993-08-30 06:50:34', 2)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
