using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        ContextDB _contextDB;
        public LibraryCardRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public LibraryCard AddLibraryCard(LibraryCard card)
        {
            _contextDB.LibraryCards.Add(card);
            _contextDB.SaveChanges();
            return card;
        }

        public void DeleteLibraryCard(LibraryCard card)
        {
            _contextDB.LibraryCards.Remove(card);
            _contextDB.SaveChanges();
        }

        public List<LibraryCard> GetLibraryCards()
        {
            return _contextDB.LibraryCards.ToList();
        }

        public LibraryCard UpdateLibraryCard(LibraryCard card)
        {
            _contextDB.LibraryCards.Update(card);
            _contextDB.SaveChanges();
            return card;
        }
    }
}
