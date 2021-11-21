using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Exceptions;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public Author GetAuthorById(int authorId)
        {
            return _contextDB.Authors.Include(i => i.Books).ThenInclude(i => i.Genres).FirstOrDefault(a => a.Id == authorId);
        }

        public Author UpdateAuthor(Author author)
        {
            _contextDB.Authors.Update(author);
            _contextDB.SaveChanges();
            return author;
        }

        public void DeleteAuthor(int authorId)
        {
            var authorQuery = _contextDB.Authors.Where(a => a.Id == authorId);
            if (authorQuery.Count() == 0)
                throw new BadRequestException("Такого автора не существует");
            authorQuery = authorQuery.Where(a => a.Books.Count == 0);
            if (authorQuery.Count() == 0)
                throw new BadRequestException("Нельзя удалить автора с книгами");
            _contextDB.Authors.Remove(authorQuery.FirstOrDefault());
            _contextDB.SaveChanges();
        }
    }
}
