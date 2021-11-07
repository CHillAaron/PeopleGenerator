using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleGen.Core
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }

        //Ability stats
        //[Required]
        public int Strength { get; set; }
        //[Required]
        public int Dexterity { get; set; }
        //[Required]
        public int Constitution { get; set; }
        //[Required]
        public int Intelligence { get; set; }
        //[Required]
        public int Wisdom { get; set; }
        //[Required]
        public int Charisma { get; set; }
        //Chariteristics
        //[Required]
        public string Alignment { get; set; }
        [Required]
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
        public int CityId { get; set; }
        public Civilization City { get; set; }

    }
}
