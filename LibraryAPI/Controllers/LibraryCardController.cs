using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// 2.1.2 - Контроллер, отвечающий за взятые книги
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LibraryCardController : ControllerBase
    {
        public LibraryCardController()
        {
        }

        //[HttpGet]
        //public IEnumerable<LibraryCardDTO> GetAllCards()
        //{
        //    return ContextDB.Init.LibraryCards.Select(l => l.ToDTO());
        //}

        /// <summary>
        /// 2.1.4 - Метод, добавляющий запись о взятой книге
        /// </summary>
        /// <param name="humanID"></param>
        /// <param name="bookID"></param>
        /// <param name="received"></param>
        //[HttpPost]
        //public IActionResult AddCard(int humanID, int bookID, DateTimeOffset received)
        //{
        //    var human = ContextDB.Init.Humans.FirstOrDefault(h => h.Id == humanID);
        //    if (human == null)
        //        ModelState.AddModelError("humanID", $"Human with id {humanID} not found");
        //    var book = ContextDB.Init.Books.FirstOrDefault(b => b.Id == bookID);
        //    if (book == null)
        //        ModelState.AddModelError("bookID", $"Book with id {bookID} not found)");
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var nextID = ContextDB.Init.LibraryCards.Max(b => b.Id) + 1;
        //    ContextDB.Init.LibraryCards.Add(new LibraryCard { Id = nextID, Book = book, Human = human, Received = received });
        //    return Ok();
        //}
    }
}
