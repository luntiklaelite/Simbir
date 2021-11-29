using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    /// <summary>
    /// 1.2.1 - класс человека
    /// </summary>
    public class Human : HistoryItem
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual List<LibraryCard> LibraryCards { get; set; }
    }
}
