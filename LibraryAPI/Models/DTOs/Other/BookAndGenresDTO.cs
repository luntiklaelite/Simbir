using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs.Other
{
    public class BookAndGenresDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название книги!")]
        public string Title { get; set; }
        public List<GenreDTO> Genres { get; set; }
    }
}
