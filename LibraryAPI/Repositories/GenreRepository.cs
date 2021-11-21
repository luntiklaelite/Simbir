using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using LibraryAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        ContextDB _contextDB;
        public GenreRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public Genre AddGenre(Genre genre)
        {
            _contextDB.Genres.Add(genre);
            base.SetInputDate(genre);
            _contextDB.SaveChanges();
            return genre;
        }

        public void DeleteGenre(Genre genre)
        {
            _contextDB.Genres.Remove(genre);
            _contextDB.SaveChanges();
        }

        public List<Genre> GetGenres()
        {
            return _contextDB.Genres.ToList();
        }

        public List<GenreStatistic> GetStatistic()
        {
            return _contextDB.Genres.Select(g => new GenreStatistic
            {
                Genre = g,
                BooksCount = g.Books.Count
            }).ToList();
        }

        public Genre UpdateGenre(Genre genre)
        {
            _contextDB.Genres.Update(genre);
            base.UpdateDateAndVersion(genre);
            _contextDB.SaveChanges();
            return genre;
        }
    }
}
