using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 1.2.2 - DTO класс книги
    /// </summary>
    public class BookDto
    {
        [Required(ErrorMessage = "Укажите идентификатор")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Укажите автора")]
        public AuthorDto Author { get; set; }
        [Required(ErrorMessage = "Укажите жанр")]
        public List<GenreDto> Genres { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateOfWrite { get; set; }
    }
}
