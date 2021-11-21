SELECT 
CONCAT(h.FirstName, ' ', h.LastName, ' ', h.MiddleName) as HumanName,
COUNT(*) as BookCount
FROM LibraryCards as lc
JOIN Humans as h ON h.Id = lc.HumanId
GROUP BY CONCAT(h.FirstName, ' ', h.LastName, ' ', h.MiddleName)
HAVING COUNT(*) > 3