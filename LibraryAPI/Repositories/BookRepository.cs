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
    public class BookRepository : IBookRepository
    {
        ContextDB _contextDB;
        public BookRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public Book AddBook(Book book)
        {
            if (_contextDB.Authors.Count(a => a.Id == book.Author.Id) == 0)
                _contextDB.Authors.Add(book.Author);
            foreach(var genre in book.Genres)
            {
                if (_contextDB.Genres.Count(g => g.Id == genre.Id) == 0)
                    _contextDB.Genres.Add(genre);
            }
            _contextDB.Books.Add(book);
            _contextDB.SaveChanges();
            return book;
        }

        public void DeleteBook(int bookId)
        {
            var book = _contextDB.Books.Include(i => i.LibraryCards).FirstOrDefault(b => b.Id == bookId);
            if (book == null)
                throw new BadRequestException("Такой книги не существует!");
            if(book.LibraryCards.Count > 0)
                throw new BadRequestException("Книга находится у человека!");
            _contextDB.Books.Remove(book);
            _contextDB.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return _contextDB.Books.Include(b => b.Author).Include(b => b.Genres).ToList();
        }

        public List<Book> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            var books = _contextDB.Books.Include(i => i.Genres).Include(i => i.Author).AsQueryable();
            if (firstName != null)
                books = books.Where(h => h.Author.FirstName == firstName);
            if (lastName != null)
                books = books.Where(h => h.Author.LastName == lastName);
            if (middleName != null)
                books = books.Where(h => h.Author.MiddleName == middleName);
            return books.ToList();
        }

        public List<Book> GetBooksByGenre(int genreId)
        {
            return _contextDB.Genres.Include(g => g.Books).ThenInclude(g => g.Author).FirstOrDefault(g => g.Id == genreId).Books;
        }

        public Book UpdateGenresInBook(int bookId, List<Genre> genres)
        {
            var book = _contextDB.Books.Include(b => b.Genres).Include(b => b.Author).FirstOrDefault(b => b.Id == bookId);
            if (book == null)
                throw new BadRequestException("Такой книги не существует!");
            book.Genres.Clear();
            foreach (var genre in genres)
            {
                book.Genres.Add(_contextDB.Genres.FirstOrDefault(g => g.Id == genre.Id));
            }
            _contextDB.Books.Update(book);
            _contextDB.SaveChanges();
            return book;
        }
    }
}
