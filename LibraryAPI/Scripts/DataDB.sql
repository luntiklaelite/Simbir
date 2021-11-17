USE [SimbirLibrary]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [MiddleName]) VALUES (1, N'Пушкин', N'Александр', N'Сергеевич')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [MiddleName]) VALUES (2, N'Есенин', N'Сергей', N'Александрович')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [MiddleName]) VALUES (3, N'Толстой', N'Лев', N'Николаевич')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [AuthorId]) VALUES (1, N'Евгений Онегин', 1)
INSERT [dbo].[Books] ([Id], [Title], [AuthorId]) VALUES (2, N'Дубровский', 1)
INSERT [dbo].[Books] ([Id], [Title], [AuthorId]) VALUES (3, N'Черный человек', 2)
INSERT [dbo].[Books] ([Id], [Title], [AuthorId]) VALUES (4, N'Страна негодяев', 2)
INSERT [dbo].[Books] ([Id], [Title], [AuthorId]) VALUES (5, N'Анна Каренина', 3)
INSERT [dbo].[Books] ([Id], [Title], [AuthorId]) VALUES (6, N'Война и мир', 3)
INSERT [dbo].[Books] ([Id], [Title], [AuthorId]) VALUES (7, N'Евгений Онегин', 2)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Эпопея')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Роман')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Ода')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Повесть')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Рассказ')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (6, N'Сказка')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (7, N'Басня')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (8, N'Элегия')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (9, N'Комедия')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10, N'Трагедия')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (11, N'Детектив')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (12, N'Фантастика')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (13, N'Фэнтези')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (14, N'Приключения')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (4, 1)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (1, 2)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (2, 2)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (6, 2)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (2, 3)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (5, 4)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (2, 10)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (3, 10)
INSERT [dbo].[BookGenre] ([BooksId], [GenresId]) VALUES (4, 14)
GO
SET IDENTITY_INSERT [dbo].[Humans] ON 

INSERT [dbo].[Humans] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate]) VALUES (1, N'Косуля', N'Виталий', N'Маркович', CAST(N'1970-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Humans] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate]) VALUES (2, N'Кизяк', N'Вениамин', N'Олегович', CAST(N'1963-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Humans] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate]) VALUES (3, N'Морда', N'Ирина', N'Васильевна', CAST(N'1999-12-20T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Humans] OFF
GO
INSERT [dbo].[LibraryCards] ([BookId], [HumanId], [Received]) VALUES (1, 1, CAST(N'2021-11-16T00:00:00.0000000+04:00' AS DateTimeOffset))
INSERT [dbo].[LibraryCards] ([BookId], [HumanId], [Received]) VALUES (2, 1, CAST(N'2021-11-17T00:00:00.0000000+04:00' AS DateTimeOffset))
INSERT [dbo].[LibraryCards] ([BookId], [HumanId], [Received]) VALUES (4, 1, CAST(N'2021-03-01T00:00:00.0000000+04:00' AS DateTimeOffset))
INSERT [dbo].[LibraryCards] ([BookId], [HumanId], [Received]) VALUES (4, 2, CAST(N'2021-11-17T00:00:00.0000000+04:00' AS DateTimeOffset))
GO
