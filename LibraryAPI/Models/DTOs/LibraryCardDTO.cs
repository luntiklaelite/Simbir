using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 2.1.1 - DTO класс полученной человеком книги
    /// </summary>
    public class LibraryCardDto
    {
        [Required(ErrorMessage = "Укажите человека, взявшего книгу")]
        public HumanDto Human { get; set; }
        [Required(ErrorMessage = "Укажите книгу")]
        public BookDto Book { get; set; }
        [Required(ErrorMessage = "Укажите дату получения книги")]
        public DateTimeOffset Received { get; set; }

        public override bool Equals(object obj)
        {
            return obj is LibraryCardDto dto &&
                   EqualityComparer<HumanDto>.Default.Equals(Human, dto.Human) &&
                   EqualityComparer<BookDto>.Default.Equals(Book, dto.Book) &&
                   Received.Equals(dto.Received);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Human, Book, Received);
        }
    }
}
