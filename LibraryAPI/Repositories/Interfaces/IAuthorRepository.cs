using LibraryAPI.Models.Entities;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Author AddAuthor(Author author);

        List<Author> GetAuthors();

        List<Author> GetAuthorsWhoHaveBooksInYear(int year, bool sortByIncrease);

        Author UpdateAuthor(Author author);

        Result DeleteAuthor(int authorId);

        Author GetAuthorById(int authorId);

        List<Author> GetAuthorsWhoBookTitleContains(string containedWord);
    }
}
