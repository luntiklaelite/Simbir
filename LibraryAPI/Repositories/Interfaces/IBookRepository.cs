using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        List<Book> GetBooks();
        Book UpdateGenresInBook(int bookId, List<Genre> genres);
        void DeleteBook(int bookId);
        List<Book> GetBooksByGenre(int genreId);
        List<Book> GetBooksByAuthor(string firstName, string lastName, string middleName);
    }
}
