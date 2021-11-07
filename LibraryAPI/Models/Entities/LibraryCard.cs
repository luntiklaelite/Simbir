using LibraryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    /// <summary>
    /// 2.1.1 - Класс полученной человеком книги
    /// </summary>
    public class LibraryCard
    {
        public int ID { get; set; }
        public virtual Human Human { get; set; }
        public virtual Book Book { get; set; }
        public DateTimeOffset Received { get; set; }

        public LibraryCardDTO ToDTO()
        {
            return new LibraryCardDTO { Human = Human.ToDTO(), Book = Book.ToDTO(), Received = Received };
        }
    }
}
