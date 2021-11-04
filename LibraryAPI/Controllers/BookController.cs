using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// 1.4 - Контроллер книги
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 1.4.1.1 - Возвращает список книг
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BookDTO> GetAllBooks()
        {
            return ModelDB.Init.Books.Select(b => b.ToDTO());
        }

        /// <summary>
        /// 1.4.1.2 - Возвращает список книг по автору (<paramref name="authorID"/>)
        /// </summary>
        /// <param name="authorID"></param>
        /// <returns></returns>
        [HttpGet("Contains")]
        public IEnumerable<BookDTO> GetBookByAuthorID(int authorID)
        {
            return ModelDB.Init.Books.Where(b => b.Author.ID == authorID).Select(b => b.ToDTO());
        }

        /// <summary>
        /// 1.4.2 - Добавляет книгу
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public void AddBook([FromBody] BookDTO book)
        {
            var author = ModelDB.Init.Humans.FirstOrDefault(h => h.Fullname == book.AuthorName);
            var genre = ModelDB.Init.Genres.FirstOrDefault(g => g.Name == book.Genre);
            if(author != null)
                ModelDB.Init.Books.Add(new Book(author) { ID = 5, Genre = genre, Author = author, Title = book.Title });
        }

        /// <summary>
        /// 1.4.3 - Удаляет книгу
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void DeleteBook(int id)
        {
            ModelDB.Init.Books.RemoveAll(b => b.ID == id);
        }
    }
}
