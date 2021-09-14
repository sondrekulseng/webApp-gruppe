using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gruppeProsjekt.Models
{
    public class DB : DbContext
    {
        // Opprett database
        public DB(DbContextOptions<DB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Database tabeller
        public DbSet<Strekning> Strekninger { get; set; }

        public DbSet<Bestilling> Bestillinger { get; set; }
    }
}
