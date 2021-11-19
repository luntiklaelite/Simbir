using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Other
{
    public class GenreStatistic
    {
        public Genre Genre { get; set; }
        public int BooksCount { get; set; }
    }
}
