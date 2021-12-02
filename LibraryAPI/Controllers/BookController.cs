using LibraryAPI.Models.DTOs;
using LibraryAPI.Services;
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
        private readonly BookService _service;
        public BookController(BookService service)
        {
            _service = service;
        }

        /// <summary>
        /// 1.4.1.1 + 2.2.2 - Возвращает список книг
        /// </summary>
        /// <param name="sortByProperty">Сортировка по свойству (author, genre, title) </param>
        /// <returns></returns>
        [HttpGet]
        public List<BookDto> GetAllBooks()
        {
            return _service.GetAllBooks();
        }

        [HttpGet("ByGenre")]
        public List<BookDto> GetBooksByGenre(int genreId)
        {
            return _service.GetBooksByGenreId(genreId);
        }

        [HttpGet("ByAuthor")]
        public List<BookDto> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            return _service.GetBooksByAuthor(firstName, lastName, middleName);
        }

        /// <summary>
        /// 1.4.2 - Добавляет книгу
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public BookDto AddBook(BookDto book)
        {
            return _service.AddBook(book);
        }

        [HttpPut]
        public IActionResult UpdateBookGenres(BookDto book)
        {
            var result = _service.UpdateGenresInBook(book);
            if (result.IsSuccess)
                return Ok(result.Content);
            else
                return BadRequest(result.ErrorMessage);
        }

        /// <summary>
        /// 1.4.3 - Удаляет книгу
        /// </summary>
        /// <param name="bookId"></param>
        [HttpDelete]
        public IActionResult DeleteBook([FromQuery] int bookId)
        {
            var result = _service.DeleteBook(bookId);
            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(result.ErrorMessage);
        }
    }
}
