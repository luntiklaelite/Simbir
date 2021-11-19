using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        ContextDB _contextDB;
        public AuthorRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public Author AddAuthor(Author author)
        {
            _contextDB.Authors.Add(author);
            _contextDB.SaveChanges();
            return author;
        }

        public List<Author> GetAuthors()
        {
            return _contextDB.Authors.ToList();
        }

        public Author UpdateAuthor(Author author)
        {
            _contextDB.Authors.Update(author);
            _contextDB.SaveChanges();
            return author;
        }

        public void DeleteAuthor(Author author)
        {
            _contextDB.Authors.Remove(author);
            _contextDB.SaveChanges();
        }
    }
}
