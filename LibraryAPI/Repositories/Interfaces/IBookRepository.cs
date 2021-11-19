using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Book AddBook(Book book);

        public List<Book> GetBooks();

        public Book UpdateBook(Book book);

        public void DeleteBook(Book book);
    }
}
