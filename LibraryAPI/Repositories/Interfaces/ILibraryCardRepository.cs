using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface ILibraryCardRepository
    {
        public LibraryCard AddLibraryCard(LibraryCard card);

        public List<LibraryCard> GetLibraryCards();

        public LibraryCard UpdateLibraryCard(LibraryCard card);

        public void DeleteLibraryCard(LibraryCard card);
    }
}
