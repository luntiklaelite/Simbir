SELECT 
CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName) as AuthorName,
g.Name,
COUNT(*) AS count
FROM Authors as a
JOIN Books as b ON b.AuthorId = a.Id
JOIN BookGenre as bg ON bg.BooksId = b.Id
JOIN Genres as g ON bg.GenresId = g.Id
GROUP BY CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName), g.Name
ORDER BY AuthorName