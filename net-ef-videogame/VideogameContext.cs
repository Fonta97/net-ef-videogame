using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class VideogameContext : DbContext
    {

        public DbSet<Videogame> videogames { get; set; }
        public DbSet<Software_House> software_houses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-MyVideogames;Integrated Security=True;Trust Server Certificate=True");
        }

    }
}