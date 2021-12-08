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
    public class AuthorRepositoryTests
    {
        [Fact]
        public void GetAuthorsWhoHaveBooksInYear_ShouldReturn_AuthorWithBookInYear()
        {
            //Arrange
            const int year = 2000;
            const bool sortByIncrease = true;
            var fixture = new Fixture().WithoutCircular();
            var book = fixture.CreateBook();
            book.DateOfWrite = new DateTime(year, 1, 1);

            var context = new SQLiteContext();
            context.Books.Add(book);
            context.Authors.Add(fixture.Build<Author>().With(p => p.Books, new List<Book> { book }).Create());
            context.SaveChanges();

            var repository = new AuthorRepository(context);

            //Act
            var result = repository.GetAuthorsWhoHaveBooksInYear(year, sortByIncrease).FirstOrDefault().Books;

            //assert
            Assert.Contains(book, result);
        }

        [Fact]
        public void DeleteAuthor_IsSuccess_False()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var book = fixture.CreateBook();
            var author = fixture.Build<Author>().With(p => p.Books, new List<Book> { book }).Create();

            var context = new SQLiteContext();
            context.Books.Add(book);
            context.Authors.Add(author);
            context.SaveChanges();

            var repository = new AuthorRepository(context);

            //Act
            var result = repository.DeleteAuthor(author.Id);

            //assert
            Assert.False(result.IsSuccess);
        }
    }
}
