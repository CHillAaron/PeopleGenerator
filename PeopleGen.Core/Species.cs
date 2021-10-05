using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Core
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }
        [Required]
        public string SpeciesName { get; set; }
        public List<Person> persons { get; set; } = new List<Person>();
    }
}
