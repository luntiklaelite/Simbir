using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public BookDto BookDtoByModel(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                DateOfWrite = book.DateOfWrite,
                Author = new AuthorDto
                {
                    Id = book.Author.Id,
                    FirstName = book.Author?.FirstName,
                    MiddleName = book.Author?.MiddleName,
                    LastName = book.Author?.LastName
                },
                Genres = book.Genres?.Select(s => new GenreDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList()
            };
        }

        public List<BookDto> GetAllBooks()
        {
            return _repository.GetBooks().Select(b => BookDtoByModel(b)).ToList();
        }

        public List<BookDto> GetBooksByGenreId(int genreId)
        {
            return _repository.GetBooksByGenre(genreId).Select(b => BookDtoByModel(b)).ToList();
        }

        public List<BookDto> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            return _repository.GetBooksByAuthor(firstName, lastName, middleName).Select(b => BookDtoByModel(b)).ToList();
        } 

        public virtual Result<BookDto> UpdateGenresInBook(BookDto book)
        {
            var resultRepo = _repository.UpdateGenresInBook(book.Id, book.Genres.Select(s => new Genre { Id = s.Id, Name = s.Name }).ToList());
            if (resultRepo.IsSuccess)
                return new Result<BookDto>(BookDtoByModel(resultRepo.Content));
            else
                return new Result<BookDto> { ErrorMessage = resultRepo.ErrorMessage };
        }

        public BookDto AddBook(BookDto book)
        {
            var addedBook = _repository.AddBook(new Book
            {
                Title = book.Title,
                DateOfWrite = book.DateOfWrite,
                Genres = book.Genres.Select(g => new Genre
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList(),
                Author = new Author
                {
                    Id = book.Author.Id,
                    FirstName = book.Author.FirstName,
                    MiddleName = book.Author.MiddleName,
                    LastName = book.Author.LastName
                }
            });
            return BookDtoByModel(addedBook);
        }
        public Result DeleteBook(int bookId)
        {
            return _repository.DeleteBook(bookId);
        }
    }
}
