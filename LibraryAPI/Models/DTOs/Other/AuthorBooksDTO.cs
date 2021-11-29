using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs.Other
{
    public class AuthorBooksDto
    {
        [Required(ErrorMessage = "Укажите автора!")]
        public AuthorDto Author { get; set; }
        public List<BookAndGenresDto> Books { get; set; }
    }
}
