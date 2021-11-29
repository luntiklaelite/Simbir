using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using Skreet2k.Common.Models;
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

        Result<Human> UpdateHuman(Human human);

        Result DeleteHumanByFullname(string firstName, string lastName, string middleName);

        Result DeleteHumanById(int humanId);

        List<LibraryCard> GetHumansBooks(int humanId);

        Result AddLibraryCard(int humanId, int bookId);

        Result DeleteLibraryCard(int humanId, int bookId);
    }
}
