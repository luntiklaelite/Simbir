using AutoFixture;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using LibraryAPI.Repositories.Interfaces;
using LibraryAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.Services
{
    public class GenreServiceTests
    {
        [Fact]
        public void GetStatistic_ShouldReturn_GenreStatisticDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var statistic = new GenreStatistic
            {
                BooksCount = 1,
                Genre = fixture.CreateGenre()
            };
            var statisticDto = new GenreStatisticDto
            {
                BooksCount = statistic.BooksCount,
                Genre = new GenreDto
                {
                    Id = statistic.Genre.Id,
                    Name = statistic.Genre.Name
                }
            };
            var repositoryMock = new Mock<IGenreRepository>();
            repositoryMock.Setup(r => r.GetStatistic()).Returns(new List<GenreStatistic> { statistic });

            var service = new GenreService(repositoryMock.Object);

            //Act
            var result = service.GetStatistic().FirstOrDefault();

            //Assert
            Assert.Equal(result, statisticDto);
        }

        [Fact]
        public void GetGenres_ShouldReturn_GenresDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var genre = fixture.CreateGenre();
            var genreDto = new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
            var repositoryMock = new Mock<IGenreRepository>();
            repositoryMock.Setup(r => r.GetGenres()).Returns(new List<Genre> { genre });

            var service = new GenreService(repositoryMock.Object);

            //Act
            var result = service.GetGenres().FirstOrDefault();

            //Assert
            Assert.Equal(result, genreDto);
        }
    }
}
