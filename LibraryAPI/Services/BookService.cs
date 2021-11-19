using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookService
    {
        

        protected IEnumerable<BookDTO> Sort(IEnumerable<BookDTO> books, string sortBy = "")
        {
            sortBy = sortBy.ToLower();
            switch (sortBy)
            {
                case "title":
                    return books.OrderBy(c => c.Title);
                //case "genre":
                //    return books.OrderBy(c => c.Genre);
                //case "author":
                //    return books.OrderBy(c => c.AuthorName);
                default:
                    return books;
            }
        }

        //public IEnumerable<BookDTO> GetAllBooks(string sortByProperty)
        //{
        //    return Sort(ContextDB.Init.Books.Select(b => b.ToDTO()), sortByProperty);
        //}

        //public IEnumerable<BookDTO> GetBookByAuthorID(int authorID, string sortByProperty = "")
        //{
        //    return Sort(ContextDB.Init.Books.Where(b => b.Author.Id == authorID).Select(b => b.ToDTO()), sortByProperty);
        //}

        //public bool AddBook(int authorID, int genreID, string bookTitle)
        //{
        //    var author = ContextDB.Init.Humans.FirstOrDefault(h => h.Id == authorID);
        //    if (author == null)
        //        return BadRequest($"Author with id {authorID} not found");

        //    var genre = ContextDB.Init.Genres.FirstOrDefault(g => g.Id == genreID);
        //    if (genre == null)
        //        return BadRequest($"Genre with id {genreID} not found");

        //    var nextID = ContextDB.Init.Books.Max(b => b.Id) + 1;
        //    ContextDB.Init.Books.Add(new Book(author) { Id = nextID, /*Genre = genre, */Title = bookTitle });
        //    return Ok();
        //}

        //public void DeleteBook(int id)
        //{
        //    ContextDB.Init.Books.RemoveAll(b => b.Id == id);
        //}
    }
}
