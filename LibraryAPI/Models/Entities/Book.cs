using LibraryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    /// <summary>
    /// 1.2.2 - Класс книги
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Human Author { get; set; }
        public virtual Genre Genre { get; set; }

        public Book(Human author)
        {
            //хардкод до энтити
            Author = author;
            Author.WritedBooks.Add(this);
        }

        public BookDTO ToDTO()
        {
            return new BookDTO { AuthorName = Author.Fullname, Genre = Genre.Name, Title = Title };
        }
    }
}
