using AutoFixture;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.Repositories
{
    public class BookRepositoryTests
    {
        [Fact]
        public void GetBooksByAuthor_ShouldReturn_BookByAuthor()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var book = fixture.CreateBook();
            var author = fixture.CreateAuthor();
            author.Books = new List<Book> { book };

            var context = new SQLiteContext();
            context.Books.Add(book);
            context.Authors.Add(author);
            context.SaveChanges();

            var repository = new BookRepository(context);
            //Act
            var result = repository.GetBooksByAuthor(author.FirstName, author.LastName, author.MiddleName);

            //assert
            Assert.Contains(book, result);
        }

        [Fact]
        public void AddBook_ShouldAdd_BookAndGenres()
        {
            //Arrange
            const int bookCount = 1;
            const int genresCount = 1;

            var fixture = new Fixture().WithoutCircular();
            var author = fixture.CreateAuthor();
            var genres = new List<Genre> { fixture.CreateGenre() };
            var book = fixture.Build<Book>().With(p => p.Author, author).With(p => p.Genres, genres).Create();

            var context = new SQLiteContext();
            context.Authors.Add(author);
            context.SaveChanges();

            var repository = new BookRepository(context);

            //Act
            var result = repository.AddBook(book);

            //assert
            Assert.Equal(context.Books.Count(), bookCount);
            Assert.Equal(context.Genres.Count(), genresCount);
        }
    }
}
