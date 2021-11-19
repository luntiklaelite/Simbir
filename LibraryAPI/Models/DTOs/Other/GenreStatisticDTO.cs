using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs.Other
{
    public class GenreStatisticDTO
    {
        public GenreDTO Genre { get; set; }
        public int BooksCount { get; set; }
    }
}
