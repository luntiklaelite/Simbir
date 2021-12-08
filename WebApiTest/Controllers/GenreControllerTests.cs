using AutoFixture;
using LibraryAPI.Controllers;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Services;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.Controllers
{
    public class GenreControllerTests
    {
        [Fact]
        public void GetStatistic_SholdReturn_GenreStatisticDto()
        {
            //Arrange
            Fixture fixture = new Fixture().WithoutCircular();
            var statistic = new GenreStatisticDto
            {
                BooksCount = 2,
                Genre = fixture.CreateGenreDto()
            };
            var serviceMock = new Mock<IGenreService>();
            serviceMock.Setup(p => p.GetStatistic()).Returns(new List<GenreStatisticDto> { statistic });

            var controller = new GenreController(serviceMock.Object);

            //Act
            var result = controller.GetStatistic().FirstOrDefault();

            //Assert
            Assert.Equal(statistic, result);
        }

        [Fact]
        public void GetAllGenres_SholdReturn_GenreDto()
        {
            //Arrange
            Fixture fixture = new Fixture().WithoutCircular();
            var genre = fixture.CreateGenreDto();
            var serviceMock = new Mock<IGenreService>();
            serviceMock.Setup(p => p.GetGenres()).Returns(new List<GenreDto> { genre });

            var controller = new GenreController(serviceMock.Object);

            //Act
            var result = controller.GetAllGenres().FirstOrDefault();

            //Assert
            Assert.Equal(genre, result);
        }
    }
}
