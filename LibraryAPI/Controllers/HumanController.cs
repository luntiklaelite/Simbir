using LibraryAPI.Models.DTOs;
using LibraryAPI.Services;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// 1.3 - Контроллер человвека
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _serivce;
        public HumanController(IHumanService service)
        {
            _serivce = service;
        }

        /// <summary>
        /// 1.3.1.1 - Возвращает список всех людей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<HumanDto> GetAllHumans()
        {
            return _serivce.GetHumans();
        }

        /// <summary>
        /// 1.3.2 - Добавляет человека
        /// </summary>
        /// <param name="human"></param>
        [HttpPost]
        public HumanDto AddHuman([FromBody] HumanDto human)
        {
            return _serivce.AddHuman(human);
        }

        [HttpPut]
        public IActionResult UpdateHuman([FromBody] HumanDto human)
        {
            var result = _serivce.UpdateHuman(human);
            if (result.IsSuccess)
                return Ok(result.Content);
            else
                return BadRequest(result.ErrorMessage);
        }
        [HttpGet("LibraryCards")]
        public List<BookDto> GetHumansBooks([FromQuery] int humanId)
        {
            return _serivce.GetHumansBooks(humanId);
        }

        [HttpPost("AddLibraryCard")]
        public IActionResult AddLibraryCard(int humanId, int bookId)
        {
            var result = _serivce.AddLibraryCard(humanId, bookId);
            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(result.ErrorMessage);
        }

        [HttpPost("DeleteLibraryCard")]
        public IActionResult DeleteLibraryCard(int humanId, int bookIdd)
        {
            var result = _serivce.DeleteLibraryCard(humanId, bookIdd);
            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(result.ErrorMessage);
        }

        /// <summary>
        /// 1.3.3 - Удаляет человека
        /// </summary>
        /// <param name="humanId"></param>
        [HttpDelete("DeleteById")]
        public IActionResult DeleteHumanById([FromQuery] int humanId)
        {
            var result = _serivce.DeleteHumanById(humanId);
            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("DeleteByFullName")]
        public IActionResult DeleteHumanByFullname([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string middleName)
        {
            var result = _serivce.DeleteHumanByFullname(firstName, lastName, middleName);
            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(result.ErrorMessage);
        }
    }
}
