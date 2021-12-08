using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название жанра")]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GenreDto dto &&
                   Id == dto.Id &&
                   Name == dto.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
