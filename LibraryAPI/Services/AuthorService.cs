using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class AuthorService
    {
        IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public static AuthorDTO AuthorDTOByModel(Author author)
        {
            return new AuthorDTO
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleName = author.MiddleName,
                Id = author.Id
            };
        }

        public static AuthorBooksDTO AuthorBooksDTOByModel(Author author)
        {
            if (author == null)
                return null;
            return new AuthorBooksDTO
            {
                Author = AuthorDTOByModel(author),
                Books = author.Books?.Select(b => new BookAndGenresDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    DateOfWrite = b.DateOfWrite,
                    Genres = b.Genres?.Select(g => new GenreDTO
                    {
                        Id = g.Id,
                        Name = g.Name
                    }).ToList()
                }).ToList()
            };
        }

        public List<AuthorDTO> GetAuthors()
        {
            return _repository.GetAuthors().Select(s => AuthorDTOByModel(s)).ToList();
        }

        public List<AuthorDTO> GetAuthorsWhoHaveBooksInYear(int year, bool sortByIncrease)
        {
            return _repository.GetAuthorsWhoHaveBooksInYear(year, sortByIncrease)
                .Select(a => AuthorDTOByModel(a)).ToList();
        }

        public List<AuthorDTO> GetAuthorsWhoBookTitleContains(string containedWord)
        {
            return _repository.GetAuthorsWhoBookTitleContains(containedWord)
                .Select(a => AuthorDTOByModel(a)).ToList();
        }

        public AuthorBooksDTO GetBooksByAuthorId(int authorId)
        {
            var author = _repository.GetAuthorById(authorId);
            return AuthorBooksDTOByModel(author);
        }

        public AuthorBooksDTO AddAuthor(AuthorBooksDTO author)
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
            return AuthorBooksDTOByModel(addedAuthor);
        }

        public void DeleteAuthor(int authorId)
        {
            _repository.DeleteAuthor(authorId);
        }
    }
}
