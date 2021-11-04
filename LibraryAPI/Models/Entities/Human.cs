using LibraryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    /// <summary>
    /// 1.2.1 - класс человека
    /// </summary>
    public class Human
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        
        public virtual List<Book> WritedBooks { get; set; }

        public Human()
        {
            WritedBooks = new List<Book>();
        }
        public HumanDTO ToDTO()
        {
            return new HumanDTO { Fullname = Fullname, BirthDate = BirthDate };
        }
    }
}
