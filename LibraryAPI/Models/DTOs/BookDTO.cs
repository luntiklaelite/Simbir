using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 1.2.2 - DTO класс книги
    /// </summary>
    public class BookDTO
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
    }
}
