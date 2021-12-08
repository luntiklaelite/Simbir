using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Interfaces
{
    public interface IGenreService
    {
        List<GenreDto> GetGenres();
        GenreDto AddGenre(GenreDto genre);
        List<GenreStatisticDto> GetStatistic();
    }
}
