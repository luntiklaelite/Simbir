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
    public class HumanDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 2.2.1 - Валидация, а также валидация проходит в контроллере через ModelState
        /// </summary>
        [Required(ErrorMessage = "Укажите фамилию")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        /// <summary>
        /// 2.1.5 - В Library Card стоит уже нужный формат вывода, поэтому сделал здесь иной формат даты :)
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime BirthDate { get; set; }
    }
}
