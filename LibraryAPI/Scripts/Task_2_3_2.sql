SELECT
CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName) as AuthorName,
b.Title,
dbo.GET_STRING_GENRES_BY_BOOK_ID(b.Id) as Genres
FROM Authors as a
JOIN Books as b ON b.AuthorId = a.Id
WHERE a.Id = 1