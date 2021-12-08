using LibraryAPI.Models.DTOs;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Interfaces
{
    public interface IHumanService
    {
        List<HumanDto> GetHumans();
        HumanDto AddHuman(HumanDto human);
        Result<HumanDto> UpdateHuman(HumanDto human);
        Result DeleteHumanById(int humanId);
        Result DeleteHumanByFullname(string firstName, string lastName, string middleName);
        List<BookDto> GetHumansBooks(int humanId);
        Result AddLibraryCard(int humanId, int bookId);
        Result DeleteLibraryCard(int humanId, int bookId);
    }
}
