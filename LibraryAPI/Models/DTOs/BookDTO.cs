using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 1.2.2 - DTO класс книги
    /// </summary>
    public class BookDTO
    {
        [Required(ErrorMessage = "Укажите название")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Укажите автора")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Укажите жанр")]
        public string Genre { get; set; }
    }
}
