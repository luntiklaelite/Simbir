using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 1.2.1 - DTO класс человека
    /// </summary>
    public class HumanDTO
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
