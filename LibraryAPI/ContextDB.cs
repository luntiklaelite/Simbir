using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI
{
    /// <summary>
    /// 1.2.3 - Класс контекста базы данных
    /// </summary>
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryCard>().HasKey(u => new { u.BookId, u.HumanId });
            modelBuilder.Entity<Author>().HasMany(b => b.Books).WithOne(b => b.Author);
        }

        public virtual DbSet<Human> Humans { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        /// <summary>
        /// 2.1.4 - Список, хранящий полученные человеком книги
        /// </summary>
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}
