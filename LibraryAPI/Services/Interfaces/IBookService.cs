using LibraryAPI.Models.DTOs;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAllBooks();
        List<BookDto> GetBooksByGenreId(int genreId);
        List<BookDto> GetBooksByAuthor(string firstName, string lastName, string middleName);
        Result<BookDto> UpdateGenresInBook(BookDto book);
        BookDto AddBook(BookDto book);
        Result DeleteBook(int bookId);
    }
}
