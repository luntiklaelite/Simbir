using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreService;
        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public List<GenreDto> GetAllGenres()
        {
            return _genreService.GetGenres();
        }

        [HttpPost]
        public GenreDto AddGenre(GenreDto genre)
        {
            return _genreService.AddGenre(genre);
        }

        [HttpGet("Statistic")]
        public List<GenreStatisticDto> GetStatistic()
        {
            return _genreService.GetStatistic();
        }
    }
}
