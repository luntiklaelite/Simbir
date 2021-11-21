using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Exceptions;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        ContextDB _contextDB;
        public AuthorRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public Author AddAuthor(Author author)
        {
            _contextDB.Authors.Add(author);
            base.SetInputDate(author);
            base.SetInputDate(author.Books.ToArray());
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
            base.UpdateDateAndVersion(author);
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

        public List<Author> GetAuthorsWhoHaveBooksInYear(int year, bool sortByIncrease)
        {
            var authors = _contextDB.Authors.Where(a => a.Books.Any(b => b.DateOfWrite.Year == year));
            authors = sortByIncrease
                ? authors.OrderBy(b => b.FirstName).ThenBy(b => b.LastName).ThenBy(b => b.MiddleName)
                : authors.OrderByDescending(b => b.FirstName).ThenByDescending(b => b.LastName).ThenByDescending(b => b.MiddleName);
            return authors.ToList();
        }

        public List<Author> GetAuthorsWhoBookTitleContains(string containedWord)
        {
            return _contextDB.Authors.Where(a => a.Books.Any(b => b.Title.Contains(containedWord))).ToList();
        }
    }
}
