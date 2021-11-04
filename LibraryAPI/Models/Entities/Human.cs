using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    public class Human
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
