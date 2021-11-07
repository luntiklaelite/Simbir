using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <summary>
        /// 2.2.1 - Валидация, а также валидация проходит в контроллере через ModelState
        /// </summary>
        [Required(ErrorMessage = "Укажите полное имя")]
        public string Fullname { get; set; }

        /// <summary>
        /// 2.1.5 - В Library Card стоит уже нужный формат вывода, поэтому сделал здесь иной формат даты :)
        /// </summary>
        [Required(ErrorMessage = "Укажите дату рождения")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime BirthDate { get; set; }
    }
}
