using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public List<AuthorDto> GetAuthors()
        {
            return _authorService.GetAuthors();
        }

        [HttpGet("WritedBooksInYear")]
        public List<AuthorDto> GetAuthorsWhoHaveBooksInYear(int year, bool sortByIncrease = true)
        {
            return _authorService.GetAuthorsWhoHaveBooksInYear(year, sortByIncrease);
        }

        [HttpGet("BookTitleContains")]
        public List<AuthorDto> GetAuthorsWhoBookTitleContains(string containedWord)
        {
            return _authorService.GetAuthorsWhoBookTitleContains(containedWord);
        }

        [HttpGet("WithBooks")]
        public AuthorBooksDto GetAuthorWithBooks([FromQuery] int authorId)
        {
            return _authorService.GetBooksByAuthorId(authorId);
        }

        [HttpPost]
        public AuthorBooksDto AddAuthor([FromBody] AuthorBooksDto author)
        {
            return _authorService.AddAuthor(author);
        }

        [HttpDelete]
        public IActionResult DeleteAuthor([FromQuery] int authorId)
        {
            var result = _authorService.DeleteAuthor(authorId);
            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(result.ErrorMessage);
        }
    }
}
