using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using LibraryAPI.Repositories.Interfaces;
using LibraryAPI.Services.Interfaces;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class HumanService : IHumanService
    {
        private readonly IHumanRepository _repository;
        public HumanService(IHumanRepository repository)
        {
            _repository = repository;
        }

        public HumanDto HumanDtoByModel(Human human)
        {
            return new HumanDto
            {
                Id = human.Id,
                FirstName = human.FirstName,
                BirthDate = human.BirthDate,
                LastName = human.LastName,
                MiddleName = human.MiddleName
            };
        }

        public Human ModelByHumanDto(HumanDto human)
        {
            return new Human
            {
                Id = human.Id,
                FirstName = human.FirstName,
                LastName = human.LastName,
                MiddleName = human.MiddleName,
                BirthDate = human.BirthDate
            };
        }

        public List<HumanDto> GetHumans()
        {
            return _repository.GetHumans().Select(h => HumanDtoByModel(h)).ToList();
        }

        public HumanDto AddHuman(HumanDto human)
        {
            var addedHuman = _repository.AddHuman(ModelByHumanDto(human));
            return HumanDtoByModel(addedHuman);
        }

        public Result<HumanDto> UpdateHuman(HumanDto human)
        {
            var updatedHuman = _repository.UpdateHuman(ModelByHumanDto(human));
            if (updatedHuman.IsSuccess)
                return new Result<HumanDto>(HumanDtoByModel(updatedHuman.Content));
            else
                return new Result<HumanDto> { ErrorMessage = updatedHuman.ErrorMessage };
        }

        public Result DeleteHumanById(int humanId)
        {
            return _repository.DeleteHumanById(humanId);
        }

        public Result DeleteHumanByFullname(string firstName, string lastName, string middleName)
        {
            return _repository.DeleteHumanByFullname(firstName, lastName, middleName);
        }

        public List<BookDto> GetHumansBooks(int humanId)
        {
            var libraryCards = _repository.GetHumansBooks(humanId);
            return libraryCards.Select(lc => new BookDto
            {
                Id = lc.Book.Id,
                Title = lc.Book.Title,
                DateOfWrite = lc.Book.DateOfWrite,
                Author = new AuthorDto
                {
                    FirstName = lc.Book.Author.FirstName,
                    LastName = lc.Book.Author.LastName,
                    MiddleName = lc.Book.Author.MiddleName,
                    Id = lc.Book.Author.Id
                },
                Genres = lc.Book.Genres?.Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()

            }).ToList();
        }

        public Result AddLibraryCard(int humanId, int bookId)
        {
            return _repository.AddLibraryCard(humanId, bookId);
        }

        public Result DeleteLibraryCard(int humanId, int bookId)
        {
            return _repository.DeleteLibraryCard(humanId, bookId);
        }
    }
}
