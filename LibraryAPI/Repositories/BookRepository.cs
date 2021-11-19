using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
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
            _contextDB.Books.Add(book);
            _contextDB.SaveChanges();
            return book;
        }

        public void DeleteBook(Book book)
        {
            _contextDB.Books.Remove(book);
            _contextDB.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return _contextDB.Books.ToList();
        }

        public Book UpdateBook(Book book)
        {
            _contextDB.Books.Update(book);
            _contextDB.SaveChanges();
            return book;
        }
    }
}
