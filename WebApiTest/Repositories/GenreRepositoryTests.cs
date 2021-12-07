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
    public class GenreRepositoryTests
    {
        [Fact]
        public void GetStatistic_ShouldReturn_GenresWithBooksCount()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var books = new List<Book> { fixture.CreateBook(), fixture.CreateBook() };
            var genre = fixture.CreateGenre();
            books.ForEach(b => b.Genres = new List<Genre> { genre });
            books.ForEach(b => b.Author = fixture.CreateAuthor());

            var context = new SQLiteContext();
            context.Books.AddRange(books);
            context.SaveChanges();

            var repository = new GenreRepository(context);

            //Act
            var result = repository.GetStatistic().FirstOrDefault();

            //assert
            Assert.Equal(books.Count(), result.BooksCount);
            Assert.Equal(result.Genre, genre);
        }

        [Fact]
        public void DeleteGenre_ShouldDeleteGenre()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var toDeleteGenre = fixture.CreateGenre();
            var genres = new List<Genre> { toDeleteGenre, fixture.CreateGenre(), fixture.CreateGenre(), fixture.CreateGenre() };

            var context = new SQLiteContext();
            context.Genres.AddRange(genres);
            context.SaveChanges();

            var repository = new GenreRepository(context);

            //Act
            repository.DeleteGenre(toDeleteGenre);

            //assert
            Assert.DoesNotContain(toDeleteGenre, context.Genres);
        }
    }
}
