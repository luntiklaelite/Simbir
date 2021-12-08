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

        public override bool Equals(object obj)
        {
            return obj is AuthorBooksDto dto &&
                   EqualityComparer<AuthorDto>.Default.Equals(Author, dto.Author) &&
                   Books.All(b => dto.Books.Contains(b));
                   //EqualityComparer<List<BookAndGenresDto>>.Default.Equals(Books, dto.Books);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Author, Books);
        }
    }
}
