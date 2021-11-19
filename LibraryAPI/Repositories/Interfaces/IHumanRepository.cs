using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IHumanRepository
    {
        public Human AddHuman(Human humaan);

        public List<Human> GetHumans();

        public Human UpdateHuman(Human human);

        public void DeleteHuman(Human human);
    }
}
