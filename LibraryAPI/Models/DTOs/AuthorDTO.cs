using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Укажите фамилию")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AuthorDto dto &&
                   Id == dto.Id &&
                   FirstName == dto.FirstName &&
                   LastName == dto.LastName &&
                   MiddleName == dto.MiddleName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, MiddleName);
        }
    }
}
