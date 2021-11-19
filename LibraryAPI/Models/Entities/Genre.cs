using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    /// <summary>
    /// Класс жанра
    /// </summary>
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
