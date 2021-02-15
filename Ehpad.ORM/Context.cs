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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonType>().HasData(new PersonType { Id = 1, Label = "Personnel" }, new PersonType { Id = 2, Label = "Résident" });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=" + Config.DB_FILE);
        }

    }
}
