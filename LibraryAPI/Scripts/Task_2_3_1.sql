SELECT 
b.Title as BookTitle,
CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName) as AuthorName,
dbo.GET_STRING_GENRES_BY_BOOK_ID(b.Id) as Genres
FROM LibraryCards as lc
JOIN Books as b ON lc.BookId = b.Id
JOIN Authors as a ON b.AuthorId = a.Id
WHERE HumanId = 1