using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public Author AddAuthor(Author author);

        public List<Author> GetAuthors();

        public Author UpdateAuthor(Author author);

        public void DeleteAuthor(Author author);
    }
}
