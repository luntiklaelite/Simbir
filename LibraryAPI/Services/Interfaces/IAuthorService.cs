using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorDto> GetAuthors();
        List<AuthorDto> GetAuthorsWhoHaveBooksInYear(int year, bool sortByIncrease);
        List<AuthorDto> GetAuthorsWhoBookTitleContains(string containedWord);
        AuthorBooksDto GetBooksByAuthorId(int authorId);
        AuthorBooksDto AddAuthor(AuthorBooksDto author);
        Result DeleteAuthor(int authorId);
    }
}
