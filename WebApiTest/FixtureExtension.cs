using AutoFixture;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest
{
    public static class FixtureExtension
    {
        public static Fixture WithoutCircular(this Fixture fixture)
        {
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
                .ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }

        public static Book CreateBook(this Fixture fixture) 
            => fixture.Build<Book>().Without(p => p.Author).Without(p => p.LibraryCards).Without(p => p.Genres).Create();

        public static Author CreateAuthor(this Fixture fixture)
            => fixture.Build<Author>().Without(p => p.Books).Create();

        public static Genre CreateGenre(this Fixture fixture)
            => fixture.Build<Genre>().Without(p => p.Books).Create();

        public static Human CreateHuman(this Fixture fixture)
            => fixture.Build<Human>().Without(p => p.LibraryCards).Create();

        public static BookDto CreateBookDto(this Fixture fixture)
            => fixture.Build<BookDto>().Without(p => p.Author).Without(p => p.Genres).Create();

        public static GenreDto CreateGenreDto(this Fixture fixture)
            => fixture.Build<GenreDto>().Create();

        public static HumanDto CreateHumanDto(this Fixture fixture)
            => fixture.Build<HumanDto>().Create();
    }
}
