using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IHumanRepository
    {
        Human AddHuman(Human human);

        List<Human> GetHumans();

        Human UpdateHuman(Human human);

        void DeleteHumanByFullname(string firstName, string lastName, string middleName);

        void DeleteHumanById(int humanId);

        List<LibraryCard> GetHumansBooks(int humanId);

        void AddLibraryCard(int humanId, int bookId);

        void DeleteLibraryCard(int humanId, int bookId);
    }
}
