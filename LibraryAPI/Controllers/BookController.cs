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
        public BookController()
        {
        }

        [NonAction]
        protected IEnumerable<BookDTO> Sort(IEnumerable<BookDTO> books, string sortBy)
        {
            sortBy = sortBy.ToLower();
            switch (sortBy)
            {
                case "title":
                    return books.OrderBy(c => c.Title);
                case "genre":
                    return books.OrderBy(c => c.Genre);
                case "author":
                    return books.OrderBy(c => c.AuthorName);
                default:
                    return books;
            }
        }

        /// <summary>
        /// 1.4.1.1 + 2.2.2 - Возвращает список книг
        /// </summary>
        /// <param name="sortByProperty">Сортировка по свойству (author, genre, title) </param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BookDTO> GetAllBooks([FromQuery] string sortByProperty = "")
        {
            return Sort(ModelDB.Init.Books.Select(b => b.ToDTO()), sortByProperty);
        }

        /// <summary>
        /// 1.4.1.2 - Возвращает список книг по автору (<paramref name="authorID"/>)
        /// </summary>
        /// <param name="authorID"></param>
        /// <param name="sortByProperty">Сортировка по свойству (author, genre, title)</param>
        /// <returns></returns>
        [HttpGet("ByAuthorID")]
        public IEnumerable<BookDTO> GetBookByAuthorID([FromQuery] int authorID, [FromQuery] string sortByProperty = "")
        {
            return Sort(ModelDB.Init.Books.Where(b => b.Author.Id == authorID).Select(b => b.ToDTO()), sortByProperty);
        }

        /// <summary>
        /// 1.4.2 - Добавляет книгу
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public IActionResult AddBook(int authorID, int genreID, string bookTitle)
        {
            //TODO: сделать добавление через модель
            var author = ModelDB.Init.Humans.FirstOrDefault(h => h.Id == authorID);
            if (author == null)
                return BadRequest($"Author with id {authorID} not found");

            var genre = ModelDB.Init.Genres.FirstOrDefault(g => g.Id == genreID);
            if (genre == null)
                return BadRequest($"Genre with id {genreID} not found");

            var nextID = ModelDB.Init.Books.Max(b => b.Id) + 1;
            ModelDB.Init.Books.Add(new Book(author) { Id = nextID, Genre = genre, Title = bookTitle });
            return Ok();
        }

        /// <summary>
        /// 1.4.3 - Удаляет книгу
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void DeleteBook([FromQuery] int id)
        {
            ModelDB.Init.Books.RemoveAll(b => b.Id == id);
        }
    }
}
