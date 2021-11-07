using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Core
{
    public class Civilization
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required] 
        public string TypeOfRule { get; set; }
        [Required]
        public string Location { get; set; }
        //[Required]
        public string Ideology { get; set; }
        //Population
        public List<Person> Population { get; set; } = new List<Person>();

        //Businesses
        //public List<Business> business { get; set; } = new List<Business>();
        //

    }
}
