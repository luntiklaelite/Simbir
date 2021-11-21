USE [SimbirLibrary]
GO

/****** Object:  UserDefinedFunction [dbo].[GET_STRING_GENRES_BY_BOOK_ID]    Script Date: 17.11.2021 21:15:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GET_STRING_GENRES_BY_BOOK_ID]
(
	@book_id INT
)
RETURNS varchar(8000)
AS
BEGIN
	DECLARE @Genres varchar(8000)
	SELECT @Genres = COALESCE(@Genres + ', ', '') + Name
	FROM Genres
	JOIN BookGenre as bg ON bg.GenresId = Genres.Id
	WHERE @book_id = bg.BooksId

	RETURN COALESCE(@Genres, 'No genres')

END
GO


