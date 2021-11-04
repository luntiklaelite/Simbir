using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI
{
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
                new Book { ID = 1, Title = "Ландыш", Author = Humans[0], Genre = Genres[0] },
                new Book { ID = 2, Title = "Евгений Онегин", Author = Humans[3], Genre = Genres[1] },
                new Book { ID = 3, Title = "Хам", Author = Humans[1], Genre = Genres[2] },
                new Book { ID = 2, Title = "Дубровский", Author = Humans[3], Genre = Genres[3] }
            };
        }

        public List<Human> Humans { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Book> Books { get; set; }
    }
}
