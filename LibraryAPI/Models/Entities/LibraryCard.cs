using LibraryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    /// <summary>
    /// 2.1.1 - Класс полученной человеком книги
    /// </summary>
    public class LibraryCard
    {
        [Key]
        public int BookId { get; set; }
        [Key]
        public int HumanId { get; set; }
        [Required]
        public DateTimeOffset Received { get; set; }

        public virtual Human Human { get; set; }
        public virtual Book Book { get; set; }
        

    }
}
