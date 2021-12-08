using AutoFixture;
using LibraryAPI.Controllers;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
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
    public class AuthorContollerTests
    {
        [Fact]
        public void GetAuthors_BadResult()
        {
            //Arrange
            int authorId = 0;
            var serviceMock = new Mock<IAuthorService>();
            serviceMock.Setup(r => r.DeleteAuthor(authorId)).Returns(new Result { ErrorMessage = "error" });

            var controller = new AuthorController(serviceMock.Object);

            //Act
            var result = controller.DeleteAuthor(authorId);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteAuthor_OkResult()
        {
            //Arrange
            int authorId = 0;
            var serviceMock = new Mock<IAuthorService>();
            serviceMock.Setup(r => r.DeleteAuthor(authorId)).Returns(new Result());

            var controller = new AuthorController(serviceMock.Object);

            //Act
            var result = controller.DeleteAuthor(authorId);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
