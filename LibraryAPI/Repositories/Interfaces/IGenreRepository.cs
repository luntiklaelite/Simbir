using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Genre AddGenre(Genre genre);

        List<Genre> GetGenres();

        Genre UpdateGenre(Genre genre);

        void DeleteGenre(Genre genre);

        List<GenreStatistic> GetStatistic();
    }
}
