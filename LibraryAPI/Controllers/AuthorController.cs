using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Exceptions;
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
        AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public List<AuthorDTO> GetAuthors()
        {
            return _authorService.GetAuthors();
        }

        [HttpGet("WithBooks")]
        public AuthorBooksDTO GetAuthorWithBooks([FromQuery] int authorId)
        {
            return _authorService.GetBooksByAuthorId(authorId);
        }

        [HttpPost]
        public AuthorBooksDTO AddAuthor([FromBody] AuthorBooksDTO author)
        {
            return _authorService.AddAuthor(author);
        }

        [HttpDelete]
        public IActionResult DeleteAuthor([FromQuery] int authorId)
        {
            try
            {
                _authorService.DeleteAuthor(authorId);
                return Ok();
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
