using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs.Other
{
    public class BookAndGenresDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название книги!")]
        public string Title { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateOfWrite { get; set; }
        public List<GenreDto> Genres { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BookAndGenresDto dto &&
                   Id == dto.Id &&
                   Title == dto.Title &&
                   DateOfWrite == dto.DateOfWrite &&
                   EqualityComparer<List<GenreDto>>.Default.Equals(Genres, dto.Genres);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, DateOfWrite, Genres);
        }
    }
}
