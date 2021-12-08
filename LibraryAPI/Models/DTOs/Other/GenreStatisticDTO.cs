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

        public override bool Equals(object obj)
        {
            return obj is GenreStatisticDto dto &&
                   EqualityComparer<GenreDto>.Default.Equals(Genre, dto.Genre) &&
                   BooksCount == dto.BooksCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Genre, BooksCount);
        }
    }
}
