using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual Human Author { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
