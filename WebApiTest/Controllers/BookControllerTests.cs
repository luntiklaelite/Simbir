using AutoFixture;
using LibraryAPI.Controllers;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Services;
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
    public class BookControllerTests
    {
        [Fact]
        public void UpdateBookGenres_BadResult()
        {
            //Arrange
            Fixture fixture = new Fixture().WithoutCircular();
            var bookDto = fixture.CreateBookDto();
            var serviceMock = new Mock<BookService>(null);
            serviceMock.SetReturnsDefault(new Result<BookDto> { ErrorMessage = "error" });

            var controller = new BookController(serviceMock.Object);

            //Act
            var result = controller.UpdateBookGenres(bookDto);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateBookGenres_OkResult()
        {
            //Arrange
            Fixture fixture = new Fixture().WithoutCircular();
            var bookDto = fixture.CreateBookDto();
            var serviceMock = new Mock<BookService>(null);
            //serviceMock.Setup(p => p.UpdateGenresInBook(bookDto)).Returns(new Result<BookDto>());
            serviceMock.SetReturnsDefault(new Result<BookDto>());

            var controller = new BookController(serviceMock.Object);

            //Act
            var result = controller.UpdateBookGenres(bookDto);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
