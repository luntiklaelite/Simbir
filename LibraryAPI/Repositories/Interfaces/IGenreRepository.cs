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
        public Genre AddGenre(Genre genre);

        public List<Genre> GetGenres();

        public Genre UpdateGenre(Genre genre);

        public void DeleteGenre(Genre genre);

        public List<GenreStatistic> GetStatistic();
    }
}
