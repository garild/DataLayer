
SET IDENTITY_INSERT [dbo].[Topics] ON 

GO
INSERT [dbo].[Topics] ([Id], [Name], [Description], [IsActive], [CreateDate]) VALUES (1, N'Og³oszenia i Informacje ', N'Tutaj znajdziesz wszelkiego rodzaju informacje od administracji', 1, CAST(N'2017-03-27 21:06:31.143' AS DateTime))
GO
INSERT [dbo].[Topics] ([Id], [Name], [Description], [IsActive], [CreateDate]) VALUES (2, N'Tematy Ogólne ', N'Tematy ogólne oraz posty u¿ytkowników', 1, CAST(N'2017-03-27 21:07:13.310' AS DateTime))
GO
INSERT [dbo].[Topics] ([Id], [Name], [Description], [IsActive], [CreateDate]) VALUES (3, N'Kwiarenka ', N'Nie wiesz o czym pisaæ!? ', 1, CAST(N'2017-03-27 21:07:49.110' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Topics] OFF
GO
