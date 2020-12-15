using Microsoft.EntityFrameworkCore;
using System;

namespace Ehpad.ORM
{
    public class Context : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }
        public DbSet<Vaccinate> Vaccinates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=" + Config.DB_FILE);
        }

    }
}
