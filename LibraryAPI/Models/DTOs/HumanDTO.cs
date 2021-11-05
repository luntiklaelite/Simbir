using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 1.2.1 - DTO класс человека
    /// </summary>
    public class HumanDTO
    {
        public string Fullname { get; set; }

        /// <summary>
        /// 2.1.5 - В Library Card стоит уже нужный формат вывода, поэтому сделал здесь иной формат даты :)
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime BirthDate { get; set; }
    }
}
