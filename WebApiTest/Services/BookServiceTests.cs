using AutoFixture;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
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
    public class BookServiceTests
    {
        [Fact]
        public void GetBooks_ShouldReturn_BookDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var book = fixture.CreateBook();
            book.Author = fixture.CreateAuthor();
            var bookDto = new BookDto
            {
                Id = book.Id,
                DateOfWrite = book.DateOfWrite,
                Title = book.Title,
                Author = new AuthorDto
                {
                    Id = book.Author.Id,
                    FirstName = book.Author.FirstName,
                    LastName = book.Author.LastName,
                    MiddleName = book.Author.MiddleName
                }
            };
            var repositoryMock = new Mock<IBookRepository>();
            repositoryMock.Setup(r => r.GetBooks()).Returns(new List<Book> { book });

            var service = new BookService(repositoryMock.Object);

            //Act
            var result = service.GetAllBooks().FirstOrDefault();

            //Assert
            Assert.Equal(result, bookDto);
        }

        [Fact]
        public void GetBooksByAuthor_ShouldReturn_BooksByAuthorDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var book = fixture.CreateBook();
            book.Author = fixture.CreateAuthor();
            var bookDto = new BookDto
            {
                Id = book.Id,
                DateOfWrite = book.DateOfWrite,
                Title = book.Title,
                Author = new AuthorDto
                {
                    Id = book.Author.Id,
                    FirstName = book.Author.FirstName,
                    LastName = book.Author.LastName,
                    MiddleName = book.Author.MiddleName
                }
            };
            var repositoryMock = new Mock<IBookRepository>();
            repositoryMock
                .Setup(r => r.GetBooksByAuthor(book.Author.FirstName, book.Author.LastName, book.Author.MiddleName))
                .Returns(new List<Book> { book });

            var service = new BookService(repositoryMock.Object);

            //Act
            var result = service.GetBooksByAuthor(book.Author.FirstName, book.Author.LastName, book.Author.MiddleName).FirstOrDefault();

            //Assert
            Assert.Equal(result, bookDto);
        }
    }
}
