using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI
{
    /// <summary>
    /// 1.2.3 - Класс модели "базы данных"
    /// </summary>
    public class ModelDB
    {
        private static ModelDB _init = null;
        public static ModelDB Init
        {
            get
            {
                return _init ??= new ModelDB();
            }
        }

        public ModelDB()
        {
            //хардкод до внедрения entity :)
            Humans = new List<Human>
            {
                new Human { ID = 1, Fullname = "Косуля Виталий Маркович", BirthDate = new DateTime(1970, 1, 1) },
                new Human { ID = 2, Fullname = "Кизяк Вениамин Олегович", BirthDate = new DateTime(1969, 3, 4) },
                new Human { ID = 3, Fullname = "Морда Ирина Васильевна", BirthDate = new DateTime(1999, 7, 7) },
                new Human { ID = 4, Fullname = "Пушкин Александр Сергеевич", BirthDate = new DateTime(1800, 1, 1) }
            };
            Genres = new List<Genre>
            {
                new Genre { ID = 1, Name = "Фантастика" },
                new Genre { ID = 2, Name = "Романтика" },
                new Genre { ID = 3, Name = "Боевик" },
                new Genre { ID = 4, Name = "Роман" }
            };
            Books = new List<Book>
            {
                new Book(Humans[0]) { ID = 1, Title = "Ландыш", Genre = Genres[0] },
                new Book(Humans[3]) { ID = 2, Title = "Евгений Онегин", Genre = Genres[1] },
                new Book(Humans[1]) { ID = 3, Title = "Хам", Genre = Genres[2] },
                new Book(Humans[3]) { ID = 2, Title = "Дубровский", Genre = Genres[3] }
            };
        }

        public List<Human> Humans { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Book> Books { get; set; }
    }
}
