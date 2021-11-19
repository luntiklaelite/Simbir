using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
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
        //public HumanController()
        //{
        //}

        ///// <summary>
        ///// 1.3.1.1 - Возвращает список всех людей
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public IEnumerable<HumanDTO> GetAllHumans()
        //{
        //    return ContextDB.Init.Humans.Select(h => h.ToDTO());
        //}

        ///// <summary>
        ///// 1.3.1.2 - Возвращает список авторов
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("Authors")]
        //public IEnumerable<HumanDTO> GetAuthors()
        //{
        //    return ContextDB.Init.Humans.Where(h => h.WritedBooks.Count > 0).Select(h => h.ToDTO());
        //}

        ///// <summary>
        ///// 1.3.1.3 - Возвращает список людей, в имени которых содержится <paramref name="filter"/>
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("Contains")]
        //public IEnumerable<HumanDTO> GetHumanByName([FromQuery] string filter = "")
        //{
        //    return ContextDB.Init.Humans.Where(h => h.Fullname.Contains(filter)).Select(h => h.ToDTO());
        //}

        ///// <summary>
        ///// 1.3.2 - Добавляет человека
        ///// </summary>
        ///// <param name="human"></param>
        //[HttpPost]
        //public void AddHuman([FromBody] HumanDTO human)
        //{
        //    var nextID = ContextDB.Init.Humans.Max(h => h.Id) + 1;
        //    ContextDB.Init.Humans.Add(new Human { Id = nextID, Fullname = human.FullName, BirthDate = human.BirthDate });
        //}

        ///// <summary>
        ///// 1.3.3 - Удаляет человека
        ///// </summary>
        ///// <param name="id"></param>
        //[HttpDelete]
        //public void DeleteHuman([FromQuery] int id)
        //{
        //    ContextDB.Init.Humans.RemoveAll(h => h.Id == id);
        //}
    }
}
