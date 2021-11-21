using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookService
    {
        IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public BookDTO BookDTOByModel(Book book)
        {
            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                DateOfWrite = book.DateOfWrite,
                Author = new AuthorDTO
                {
                    Id = book.Author.Id,
                    FirstName = book.Author?.FirstName,
                    MiddleName = book.Author?.MiddleName,
                    LastName = book.Author?.LastName
                },
                Genres = book.Genres?.Select(s => new GenreDTO
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList()
            };
        }

        public List<BookDTO> GetAllBooks()
        {
            return _repository.GetBooks().Select(b => BookDTOByModel(b)).ToList();
        }

        public List<BookDTO> GetBooksByGenreId(int genreId)
        {
            return _repository.GetBooksByGenre(genreId).Select(b => BookDTOByModel(b)).ToList();
        }

        public List<BookDTO> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            return _repository.GetBooksByAuthor(firstName, lastName, middleName).Select(b => BookDTOByModel(b)).ToList();
        } 

        public BookDTO UpdateGenresInBook(BookDTO book)
        {
            return BookDTOByModel(_repository.UpdateGenresInBook(book.Id, book.Genres.Select(s => new Genre { Id = s.Id, Name = s.Name }).ToList()));
        }

        public BookDTO AddBook(BookDTO book)
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
            return BookDTOByModel(addedBook);
        }
        public void DeleteBook(int bookId)
        {
            _repository.DeleteBook(bookId);
        }
    }
}
