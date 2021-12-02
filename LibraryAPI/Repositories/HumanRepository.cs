using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Other;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class HumanRepository : BaseRepository, IHumanRepository
    {
        private readonly ContextDB _contextDB;
        public HumanRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public Human AddHuman(Human human)
        {
            _contextDB.Humans.Add(human);
            base.SetInputDate(human);
            _contextDB.SaveChanges();
            return human;
        }

        public Result DeleteHumanByFullname(string firstName, string lastName, string middleName)
        {
            var human = _contextDB.Humans.Where(h => h.FirstName == firstName && h.LastName == lastName && h.MiddleName == middleName);
            if (human.Count() == 0)
                return new Result { ErrorMessage = "Таких пользователей не существует!" };
            _contextDB.Humans.RemoveRange(human.ToArray());
            _contextDB.SaveChanges();
            return new Result();
        }

        public Result DeleteHumanById(int humanId)
        {
            var human = _contextDB.Humans.FirstOrDefault(h => h.Id == humanId);
            if (human == null)
                return new Result { ErrorMessage = "Такого пользователя не существует!" };
            _contextDB.Humans.Remove(human);
            _contextDB.SaveChanges();
            return new Result();
        }

        public List<Human> GetHumans()
        {
            return _contextDB.Humans.ToList();
        }

        public Result<Human> UpdateHuman(Human human)
        {
            if (_contextDB.Humans.Count(h => h.Id == human.Id) == 0)
                return new Result<Human> { ErrorMessage = "Такого пользователя не существует!" };
            _contextDB.Humans.Update(human);
            base.UpdateDateAndVersion(human);
            _contextDB.SaveChanges();
            return new Result<Human>(human);
        }

        public List<LibraryCard> GetHumansBooks(int humanId)
        {
            var human = _contextDB.Humans
                .Include(i => i.LibraryCards)
                    .ThenInclude(i => i.Book)
                        .ThenInclude(i => i.Genres)
                .Include(i => i.LibraryCards)
                    .ThenInclude(i => i.Book.Author)
                .FirstOrDefault(h => h.Id == humanId);
            return human.LibraryCards;
        }

        public Result AddLibraryCard(int humanId, int bookId)
        {
            if (_contextDB.Humans.Count(h => h.Id == humanId) == 0)
                return new Result { ErrorMessage = "Такого пользователя не существует" };
            if(_contextDB.Books.Count(b => b.Id == bookId) == 0)
                return new Result { ErrorMessage = "Такой книги не существует" };
            _contextDB.LibraryCards.Add(new LibraryCard
            {
                BookId = bookId,
                HumanId = humanId,
                Received = DateTimeOffset.Now
            });
            _contextDB.SaveChanges();
            return new Result();
        }

        public Result DeleteLibraryCard(int humanId, int bookId)
        {
            if (_contextDB.Humans.Count(h => h.Id == humanId) == 0)
                return new Result{ ErrorMessage = "Такого пользователя не существует" };
            if (_contextDB.Books.Count(b => b.Id == bookId) == 0)
                return new Result{ ErrorMessage = "Такой книги не существует" };
            _contextDB.LibraryCards.Remove(_contextDB.LibraryCards.Where(lc => lc.BookId == bookId && lc.HumanId == humanId).FirstOrDefault());
            _contextDB.SaveChanges();
            return new Result();
        }
    }
}
