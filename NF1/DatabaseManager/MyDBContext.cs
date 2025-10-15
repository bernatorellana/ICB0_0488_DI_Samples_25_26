using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class MyDBContext : DbContext
    {
        public static string DB_FILENAME { get { return "empresa.db"; } }
        public static string DB_PATH { get { return "db"; } }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlite("Filename=db/empresa.db");
            //optionBuilder.UseSqlite($"Filename={DB_PATH}/{DB_FILENAME}");

            optionBuilder.UseMySQL("Server=localhost;Database=empresa;UID=root;Password=");

        }
    }
}
