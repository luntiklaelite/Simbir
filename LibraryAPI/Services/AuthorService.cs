using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public static AuthorDto AuthorDtoByModel(Author author)
        {
            return new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleName = author.MiddleName,
                Id = author.Id
            };
        }

        public static AuthorBooksDto AuthorBooksDtoByModel(Author author)
        {
            if (author == null)
                return null;
            return new AuthorBooksDto
            {
                Author = AuthorDtoByModel(author),
                Books = author.Books?.Select(b => new BookAndGenresDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    DateOfWrite = b.DateOfWrite,
                    Genres = b.Genres?.Select(g => new GenreDto
                    {
                        Id = g.Id,
                        Name = g.Name
                    }).ToList()
                }).ToList()
            };
        }

        public List<AuthorDto> GetAuthors()
        {
            return _repository.GetAuthors().Select(s => AuthorDtoByModel(s)).ToList();
        }

        public List<AuthorDto> GetAuthorsWhoHaveBooksInYear(int year, bool sortByIncrease)
        {
            return _repository.GetAuthorsWhoHaveBooksInYear(year, sortByIncrease)
                .Select(a => AuthorDtoByModel(a)).ToList();
        }

        public List<AuthorDto> GetAuthorsWhoBookTitleContains(string containedWord)
        {
            return _repository.GetAuthorsWhoBookTitleContains(containedWord)
                .Select(a => AuthorDtoByModel(a)).ToList();
        }

        public AuthorBooksDto GetBooksByAuthorId(int authorId)
        {
            var author = _repository.GetAuthorById(authorId);
            return AuthorBooksDtoByModel(author);
        }

        public AuthorBooksDto AddAuthor(AuthorBooksDto author)
        {
            var addedAuthor = _repository.AddAuthor(new Author
            {
                FirstName = author.Author.FirstName,
                MiddleName = author.Author.MiddleName,
                LastName = author.Author.LastName,
                Books = author.Books?.Select(b => new Book
                {
                    Title = b.Title,
                    DateOfWrite = b.DateOfWrite,
                }).ToList()
            });
            return AuthorBooksDtoByModel(addedAuthor);
        }

        public virtual Result DeleteAuthor(int authorId)
        {
            return _repository.DeleteAuthor(authorId);
        }
    }
}
