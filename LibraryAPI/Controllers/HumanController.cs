using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using LibraryAPI.Models.Exceptions;
using LibraryAPI.Services;
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
        HumanService _serivce;
        public HumanController(HumanService service)
        {
            _serivce = service;
        }

        /// <summary>
        /// 1.3.1.1 - Возвращает список всех людей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<HumanDTO> GetAllHumans()
        {
            return _serivce.GetHumans();
        }

        /// <summary>
        /// 1.3.2 - Добавляет человека
        /// </summary>
        /// <param name="human"></param>
        [HttpPost]
        public HumanDTO AddHuman([FromBody] HumanDTO human)
        {
            return _serivce.AddHuman(human);
        }

        [HttpPut]
        public IActionResult UpdateHuman([FromBody] HumanDTO human)
        {
            try
            {
                return Ok(_serivce.UpdateHuman(human));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("LibraryCards")]
        public List<BookDTO> GetHumansBooks([FromQuery] int humanId)
        {
            return _serivce.GetHumansBooks(humanId);
        }

        [HttpPost("AddLibraryCard")]
        public IActionResult AddLibraryCard(int humanId, int bookId)
        {
            try
            {
                _serivce.AddLibraryCard(humanId, bookId);
                return Ok(_serivce.GetHumansBooks(humanId));
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("DeleteLibraryCard")]
        public IActionResult DeleteLibraryCard(int humanId, int bookIdd)
        {
            try
            {
                _serivce.DeleteLibraryCard(humanId, bookIdd);
                return Ok(_serivce.GetHumansBooks(humanId));
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 1.3.3 - Удаляет человека
        /// </summary>
        /// <param name="humanId"></param>
        [HttpDelete("DeleteById")]
        public IActionResult DeleteHumanById([FromQuery] int humanId)
        {
            try
            {
                _serivce.DeleteHumanById(humanId);
                return Ok();
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteByFullName")]
        public IActionResult DeleteHumanByFullname([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string middleName)
        {
            try
            {
                _serivce.DeleteHumanByFullname(firstName, lastName, middleName);
                return Ok();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
