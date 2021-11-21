using LibraryAPI.Models.Entities;
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

        Author UpdateAuthor(Author author);

        void DeleteAuthor(int authorId);

        Author GetAuthorById(int authorId);
    }
}
