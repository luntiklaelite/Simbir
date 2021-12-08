using AutoFixture;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using LibraryAPI.Services;
using Moq;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.Services
{
    public class AuthorServiceTests
    {
        [Fact]
        public void GetAuthors_ShouldReturn_AuthorDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var author = fixture.CreateAuthor();
            var authorDto = new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleName = author.MiddleName
            };
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock.Setup(r => r.GetAuthors()).Returns(new List<Author> { author });

            var service = new AuthorService(authorRepositoryMock.Object);

            //Act
            var result = service.GetAuthors().FirstOrDefault();

            //Assert
            Assert.Equal(result, authorDto);
        }

        [Fact]
        public void AddAuthor_ShouldReturn_AuthorBooksDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var author = fixture.CreateAuthor();
            var book = fixture.CreateBook();
            author.Books = new List<Book> { book };
            var books = new List<BookAndGenresDto>
            { 
                new BookAndGenresDto { Id = book.Id, DateOfWrite = book.DateOfWrite, Title = book.Title } 
            };
            var authorDto = new AuthorBooksDto
            {
                Author = new AuthorDto
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    MiddleName = author.MiddleName
                },
                Books = books
            };
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock.SetReturnsDefault(author);

            var service = new AuthorService(authorRepositoryMock.Object);

            //Act
            var result = service.AddAuthor(authorDto);

            //Assert
            Assert.Equal(result, authorDto);
        }
    }
}
