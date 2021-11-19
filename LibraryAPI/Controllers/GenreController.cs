using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        GenreService _genreService;
        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public List<GenreDTO> GetAllGenres()
        {
            return _genreService.GetGenres();
        }

        [HttpPost]
        public GenreDTO AddGenre(GenreDTO genre)
        {
            return _genreService.AddGenre(genre);
        }

        [HttpGet("Statistic")]
        public List<GenreStatisticDTO> GetStatistic()
        {
            return _genreService.GetStatistic();
        }
    }
}
