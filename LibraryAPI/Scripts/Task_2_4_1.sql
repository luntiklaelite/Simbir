SELECT 
CONCAT(h.FirstName, ' ', h.LastName, ' ', h.MiddleName) as HumanName,
b.Title,
DATEDIFF(day, lc.Received, SYSDATETIMEOFFSET()) as DaysGone
FROM LibraryCards as lc
JOIN Humans as h ON h.Id = lc.HumanId
JOIN Books as b ON b.Id = lc.BookId
WHERE DATEDIFF(day, lc.Received, SYSDATETIMEOFFSET()) > 14