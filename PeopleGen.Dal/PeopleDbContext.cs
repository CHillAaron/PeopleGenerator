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
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Civilization> Civilization { get; set; }
        public DbSet<Business> Business { get; set; }
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
                new Species() { SpeciesId = 4, SpeciesName = "Dwarf"},
                new Species() { SpeciesId = 5, SpeciesName = "Goliath"},
                new Species() { SpeciesId = 6, SpeciesName = "Kenku"},
            });
            //modelBuilder.Entity<Person>().HasData(new List<Person>()
            //{
            //    new Person() { PersonId = 1, FirstName = "Talice", LastName = "Nenna", Age = 46, SpeciesId=1, Gender="Female",Strength = 10,Dexterity = 14, Constitution = 10, Intelligence = 15, Wisdom = 18, Charisma = 18, Alignment = PeopleGen.Core.enums.Moral.Neutral +" "+  PeopleGen.Core.enums.Alignment.Neutral},

            //    new Person() { PersonId = 2, FirstName = "Narook", LastName = "Vunakian", Age = 20, SpeciesId=2, Gender="Male", Strength = 20,Dexterity = 13, Constitution = 116, Intelligence = 11, Wisdom = 11, Charisma = 12, Alignment = PeopleGen.Core.enums.Moral.Chaotic +" "+  PeopleGen.Core.enums.Alignment.Neutral },

            //    new Person() { PersonId = 3, FirstName = "Denede", LastName = "FireStarter", Age = 30, SpeciesId=1, Gender="Male", Strength = 10,Dexterity = 19, Constitution = 19, Intelligence = 18, Wisdom = 15, Charisma = 13, Alignment = PeopleGen.Core.enums.Moral.Chaotic +" "+  PeopleGen.Core.enums.Alignment.Neutral }

            //});
            _ = modelBuilder.Entity<Inventory>().HasData(new List<Inventory>()
            {
                new Inventory() { InventoryId = 1, InventoryName = "Sickle" , InventoryType = "Weapon", Price="50", MoneyType= "Copper"},
                new Inventory() { InventoryId = 2, InventoryName = "Shortbow", InventoryType = "Weapon", Price="75", MoneyType= "Copper"},
                new Inventory() { InventoryId = 3, InventoryName = "Greatsword", InventoryType = "Weapon", Price="150", MoneyType= "Copper"},
                new Inventory() { InventoryId = 4, InventoryName = "Battleaxe", InventoryType = "Weapon", Price="65", MoneyType= "Copper"},
                new Inventory() { InventoryId = 5, InventoryName = "Longsword", InventoryType = "Weapon", Price="5", MoneyType= "Copper"},
                new Inventory() { InventoryId = 6, InventoryName = "padded", InventoryType = "Armor", Price="150", MoneyType= "Copper"},
                new Inventory() { InventoryId = 7, InventoryName = "Studded leather", InventoryType = "Armor", Price="510", MoneyType= "Copper"},
                new Inventory() { InventoryId = 8, InventoryName = "Half Plate", InventoryType = "Armor", Price="1550", MoneyType= "Copper"},
                new Inventory() { InventoryId = 9, InventoryName = "Plate", InventoryType = "Armor", Price="15510", MoneyType= "Copper"},
                new Inventory() { InventoryId = 10, InventoryName = "shield", InventoryType = "Armor", Price="100", MoneyType= "Copper"},
                new Inventory() { InventoryId =11, InventoryName = "Ration", InventoryType = "General", Price="5", MoneyType= "Copper"},
                new Inventory() { InventoryId = 12, InventoryName = "Disquise Kit", InventoryType = "General", Price="500", MoneyType= "Copper"},
                new Inventory() { InventoryId = 13, InventoryName = "Play card", InventoryType = "General", Price="150", MoneyType= "Copper"},
                new Inventory() { InventoryId = 14, InventoryName = "Flute", InventoryType = "General", Price="75", MoneyType= "Copper"},
                new Inventory() { InventoryId = 15, InventoryName = "Horse", InventoryType = "General", Price="1500", MoneyType= "Copper"}

            });
        }
    }
}
