using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs.Other
{
    public class AuthorBooksDTO
    {
        [Required(ErrorMessage = "Укажите автора!")]
        public AuthorDTO Author { get; set; }
        public List<BookAndGenresDTO> Books { get; set; }
    }
}
