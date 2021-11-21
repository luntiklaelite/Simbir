using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using LibraryAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class HumanService
    {
        IHumanRepository _repository;
        public HumanService(IHumanRepository repository)
        {
            _repository = repository;
        }

        public HumanDTO HumanDTOByModel(Human human)
        {
            return new HumanDTO
            {
                Id = human.Id,
                FirstName = human.FirstName,
                BirthDate = human.BirthDate,
                LastName = human.LastName,
                MiddleName = human.MiddleName
            };
        }

        public Human ModelByHumanDTO(HumanDTO human)
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

        public List<HumanDTO> GetHumans()
        {
            return _repository.GetHumans().Select(h => HumanDTOByModel(h)).ToList();
        }

        public HumanDTO AddHuman(HumanDTO human)
        {
            var addedHuman = _repository.AddHuman(ModelByHumanDTO(human));
            return HumanDTOByModel(addedHuman);
        }

        public HumanDTO UpdateHuman(HumanDTO human)
        {
            var updatedHuman = _repository.UpdateHuman(ModelByHumanDTO(human));
            return HumanDTOByModel(updatedHuman);
        }

        public void DeleteHumanById(int humanId)
        {
            _repository.DeleteHumanById(humanId);
        }

        public void DeleteHumanByFullname(string firstName, string lastName, string middleName)
        {
            _repository.DeleteHumanByFullname(firstName, lastName, middleName);
        }

        public List<BookDTO> GetHumansBooks(int humanId)
        {
            var libraryCards = _repository.GetHumansBooks(humanId);
            return libraryCards.Select(lc => new BookDTO
            {
                Id = lc.Book.Id,
                Title = lc.Book.Title,
                DateOfWrite = lc.Book.DateOfWrite,
                Author = new AuthorDTO
                {
                    FirstName = lc.Book.Author.FirstName,
                    LastName = lc.Book.Author.LastName,
                    MiddleName = lc.Book.Author.MiddleName,
                    Id = lc.Book.Author.Id
                },
                Genres = lc.Book.Genres?.Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()

            }).ToList();
        }

        public void AddLibraryCard(int humanId, int bookId)
        {
            _repository.AddLibraryCard(humanId, bookId);
        }

        public void DeleteLibraryCard(int humanId, int bookId)
        {
            _repository.DeleteLibraryCard(humanId, bookId);
        }
    }
}
