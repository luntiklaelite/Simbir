using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs.Other
{
    public class GenreStatisticDto
    {
        public GenreDto Genre { get; set; }
        public int BooksCount { get; set; }
    }
}
