using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class GenreService
    {
        IGenreRepository _repository;
        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public static Genre ModelByDTO(GenreDTO genre)
        {
            return new Genre
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static GenreDTO DTOByModel(Genre genre)
        {
            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public List<GenreDTO> GetGenres()
        {
            return _repository.GetGenres().Select(g => DTOByModel(g)).ToList();
        }

        public GenreDTO AddGenre(GenreDTO genre)
        {
            return DTOByModel(_repository.AddGenre(ModelByDTO(genre)));
        }

        public List<GenreStatisticDTO> GetStatistic()
        {
            return _repository.GetStatistic().Select(s => new GenreStatisticDTO
            {
                BooksCount = s.BooksCount,
                Genre = DTOByModel(s.Genre)
            }).ToList();
        }
    }
}
