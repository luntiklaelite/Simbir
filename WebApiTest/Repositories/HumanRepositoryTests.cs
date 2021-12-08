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
    public class HumanRepositoryTests
    {
        [Fact]
        public void DeleteHumanByFullname_ShouldNotDelete()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var human = fixture.CreateHuman();

            var context = new SQLiteContext();
            context.Humans.Add(human);
            context.SaveChanges();

            string badMiddleName = human.MiddleName + " ";

            var repository = new HumanRepository(context);

            //Act
            var result = repository.DeleteHumanByFullname(human.FirstName, human.LastName, badMiddleName);

            //assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void AddLibraryCard_ShouldAddLibraryCard()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var book = fixture.CreateBook();
            book.Author = fixture.CreateAuthor();
            var human = fixture.CreateHuman();

            var context = new SQLiteContext();
            context.Books.Add(book);
            context.Humans.Add(human);
            context.SaveChanges();

            var repository = new HumanRepository(context);

            //Act
            repository.AddLibraryCard(human.Id, book.Id);

            //assert
            Assert.True(context.LibraryCards.Any(l => l.BookId == book.Id && l.HumanId == human.Id));
        }
    }
}
