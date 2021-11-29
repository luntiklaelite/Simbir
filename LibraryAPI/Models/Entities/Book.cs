using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    /// <summary>
    /// 1.2.2 - Класс книги
    /// </summary>
    public class Book : HistoryItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime DateOfWrite { get; set; }

        [Required]
        public virtual Author Author { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<LibraryCard> LibraryCards { get; set; }
    }
}
