using Microsoft.EntityFrameworkCore;
using PeopleGen.Core;
using System;
using System.Collections.Generic;

namespace PeopleGen.Dal
{
    public class PeopleDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Species> Species { get; set; }
        public PeopleDbContext() : base()
        {

        }
        public PeopleDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=192.168.1.104;Username=postgres;Password=root;Database=PeopleGen");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Species>().HasData(new List<Species>()
            {
                new Species() { SpeciesId = 1, SpeciesName = "Elf"},
                new Species() { SpeciesId = 2, SpeciesName = "Human"},
                new Species() { SpeciesId = 3, SpeciesName = "Orc"},
            });
            modelBuilder.Entity<Person>().HasData(new List<Person>()
            {
                new Person() { PersonId = 1, FirstName = "Talice", LastName = "Nenna", Age = 46, SpeciesId=1, Gender="Female",strength = 10,Dexterity = 14, Constitution = 10, Intelligence = 15, Wisdom = 18, Charisma = 18, Alignment = PeopleGen.Core.enums.Moral.Neutral +" "+  PeopleGen.Core.enums.Alignment.Neutral},

                new Person() { PersonId = 2, FirstName = "Narook", LastName = "Vunakian", Age = 20, SpeciesId=2, Gender="Male", strength = 20,Dexterity = 13, Constitution = 116, Intelligence = 11, Wisdom = 11, Charisma = 12, Alignment = PeopleGen.Core.enums.Moral.Chaotic +" "+  PeopleGen.Core.enums.Alignment.Neutral },

                new Person() { PersonId = 3, FirstName = "Denede", LastName = "FireStarter", Age = 30, SpeciesId=1, Gender="Male", strength = 10,Dexterity = 19, Constitution = 19, Intelligence = 18, Wisdom = 15, Charisma = 13, Alignment = PeopleGen.Core.enums.Moral.Chaotic +" "+  PeopleGen.Core.enums.Alignment.Neutral }

            });
        }
    }
}
