SELECT g.Name, Count(*)
FROM Genres as g
JOIN BookGenre as bg ON bg.GenresId = g.Id
GROUP BY g.Name