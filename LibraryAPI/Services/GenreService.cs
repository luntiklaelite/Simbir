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
        private readonly IGenreRepository _repository;
        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public static Genre ModelByDto(GenreDto genre)
        {
            return new Genre
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static GenreDto DtoByModel(Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public List<GenreDto> GetGenres()
        {
            return _repository.GetGenres().Select(g => DtoByModel(g)).ToList();
        }

        public GenreDto AddGenre(GenreDto genre)
        {
            return DtoByModel(_repository.AddGenre(ModelByDto(genre)));
        }

        public List<GenreStatisticDto> GetStatistic()
        {
            return _repository.GetStatistic().Select(s => new GenreStatisticDto
            {
                BooksCount = s.BooksCount,
                Genre = DtoByModel(s.Genre)
            }).ToList();
        }
    }
}
