using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
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
        //private BookService _service;
        //public BookController(BookService service)
        //{
        //    _service = service;
        //}

        ///// <summary>
        ///// 1.4.1.1 + 2.2.2 - Возвращает список книг
        ///// </summary>
        ///// <param name="sortByProperty">Сортировка по свойству (author, genre, title) </param>
        ///// <returns></returns>
        //[HttpGet]
        //public IEnumerable<BookDTO> GetAllBooks([FromQuery] string sortByProperty)
        //{
        //    return _service.GetAllBooks(sortByProperty);
        //}

        ///// <summary>
        ///// 1.4.1.2 - Возвращает список книг по автору (<paramref name="authorID"/>)
        ///// </summary>
        ///// <param name="authorID"></param>
        ///// <param name="sortByProperty">Сортировка по свойству (author, genre, title)</param>
        ///// <returns></returns>
        //[HttpGet("ByAuthorID")]
        //public IEnumerable<BookDTO> GetBookByAuthorID([FromQuery] int authorID, [FromQuery] string sortByProperty = "")
        //{
        //    return _service.GetBookByAuthorID(authorID, sortByProperty);
        //}

        ///// <summary>
        ///// 1.4.2 - Добавляет книгу
        ///// </summary>
        ///// <param name="book"></param>
        //[HttpPost]
        //public IActionResult AddBook(int authorID, int genreID, string bookTitle)
        //{
        //    //TODO: сделать добавление через модель
        //    var author = ContextDB.Init.Humans.FirstOrDefault(h => h.Id == authorID);
        //    if (author == null)
        //        return BadRequest($"Author with id {authorID} not found");

        //    var genre = ContextDB.Init.Genres.FirstOrDefault(g => g.Id == genreID);
        //    if (genre == null)
        //        return BadRequest($"Genre with id {genreID} not found");

        //    var nextID = ContextDB.Init.Books.Max(b => b.Id) + 1;
        //    //ContextDB.Init.Books.Add(new Book(author) { Id = nextID, /*Genre = genre, */Title = bookTitle });
        //    return Ok();
        //}

        ///// <summary>
        ///// 1.4.3 - Удаляет книгу
        ///// </summary>
        ///// <param name="id"></param>
        //[HttpDelete]
        //public void DeleteBook([FromQuery] int id)
        //{
        //    _service.DeleteBook(id);
        //}
    }
}
