using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
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

        public void DeleteHuman(Human human)
        {
            _contextDB.Humans.Remove(human);
            _contextDB.SaveChanges();
        }

        public List<Human> GetHumans()
        {
            return _contextDB.Humans.ToList();
        }

        public Human UpdateHuman(Human human)
        {
            _contextDB.Humans.Update(human);
            _contextDB.SaveChanges();
            return human;
        }
    }
}
