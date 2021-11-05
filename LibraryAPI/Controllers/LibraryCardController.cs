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
        private readonly ILogger<HumanController> _logger;

        public LibraryCardController(ILogger<HumanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<LibraryCardDTO> GetAllCards()
        {
            return ModelDB.Init.LibraryCards.Select(l => l.ToDTO());
        }

        /// <summary>
        /// 2.1.4 - Метод, добавляющий запись о взятой книге
        /// </summary>
        /// <param name="humanID"></param>
        /// <param name="bookID"></param>
        /// <param name="received"></param>
        [HttpPost]
        public IActionResult AddCard(int humanID, int bookID, DateTimeOffset received)
        {
            var human = ModelDB.Init.Humans.FirstOrDefault(h => h.ID == humanID);
            if (human == null)
                ModelState.AddModelError("humanID", "Bad humanID");
            var book = ModelDB.Init.Books.FirstOrDefault(b => b.ID == bookID);
            if (book == null)
                ModelState.AddModelError("bookID", "Bad bookID");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ModelDB.Init.LibraryCards.Add(new LibraryCard { Book = book, Human = human, Received = received });
            return Ok();
        }
    }
}
