﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTOs
{
    /// <summary>
    /// 2.1.1 - DTO класс полученной человеком книги
    /// </summary>
    public class LibraryCardDTO
    {
        [Required(ErrorMessage = "Укажите человека, взявшего книгу")]
        public HumanDTO Human { get; set; }
        [Required(ErrorMessage = "Укажите книгу")]
        public BookDTO Book { get; set; }
        [Required(ErrorMessage = "Укажите дату получения книги")]
        public DateTimeOffset Received { get; set; }
    }
}
