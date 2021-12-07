using LibraryAPI;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest
{
    public class SQLiteContext : ContextDB
    {
        public SQLiteContext() : 
            base(new DbContextOptionsBuilder<ContextDB>()
                .UseSqlite(CreateInMemoryDatabase()).Options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }
}
