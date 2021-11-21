using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Exceptions;
using LibraryAPI.Models.Other;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        ContextDB _contextDB;
        public HumanRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public Human AddHuman(Human human)
        {
            _contextDB.Humans.Add(human);
            _contextDB.SaveChanges();
            return human;
        }

        public void DeleteHumanByFullname(string firstName, string lastName, string middleName)
        {
            var human = _contextDB.Humans.Where(h => h.FirstName == firstName && h.LastName == lastName && h.MiddleName == middleName);
            if (human.Count() == 0)
                throw new BadRequestException("Таких пользователей не существует!");
            _contextDB.Humans.RemoveRange(human.ToArray());
            _contextDB.SaveChanges();
        }

        public void DeleteHumanById(int humanId)
        {
            var human = _contextDB.Humans.FirstOrDefault(h => h.Id == humanId);
            if (human == null)
                throw new BadRequestException("Такого пользователя не существует!");
            _contextDB.Humans.Remove(human);
            _contextDB.SaveChanges();
        }

        public List<Human> GetHumans()
        {
            return _contextDB.Humans.ToList();
        }

        public Human UpdateHuman(Human human)
        {
            if (_contextDB.Humans.Count(h => h.Id == human.Id) == 0)
                throw new BadRequestException("Такого пользователя не существует!");
            _contextDB.Humans.Update(human);
            _contextDB.SaveChanges();
            return human;
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

        public void AddLibraryCard(int humanId, int bookId)
        {
            if (_contextDB.Humans.Count(h => h.Id == humanId) == 0)
                throw new BadRequestException("Такого пользователя не существует");
            if(_contextDB.Books.Count(b => b.Id == bookId) == 0)
                throw new BadRequestException("Такой книги не существует");
            _contextDB.LibraryCards.Add(new LibraryCard
            {
                BookId = bookId,
                HumanId = humanId,
                Received = DateTimeOffset.Now
            });
            _contextDB.SaveChanges();
        }

        public void DeleteLibraryCard(int humanId, int bookId)
        {
            if (_contextDB.Humans.Count(h => h.Id == humanId) == 0)
                throw new BadRequestException("Такого пользователя не существует");
            if (_contextDB.Books.Count(b => b.Id == bookId) == 0)
                throw new BadRequestException("Такой книги не существует");
            _contextDB.LibraryCards.Remove(_contextDB.LibraryCards.Where(lc => lc.BookId == bookId && lc.HumanId == humanId).FirstOrDefault());
            _contextDB.SaveChanges();
        }
    }
}
