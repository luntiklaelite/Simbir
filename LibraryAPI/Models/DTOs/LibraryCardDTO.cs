using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 2.1.1 - DTO класс полученной человеком книги
    /// </summary>
    public class LibraryCardDTO
    {
        public HumanDTO Human { get; set; }
        public BookDTO Book { get; set; }
        public DateTimeOffset Received { get; set; }
    }
}
