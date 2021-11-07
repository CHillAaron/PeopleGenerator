using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleGen.Web
{
    public class CityViewModel
    {
        [Required]
        public string CityName { get; set; }
        [Required]
        public string TypeOfRule { get; set; }
        [Required]
        public string Location { get; set; }
        //[Required]
        //public string Ideology { get; set; }
        //Population
        public List<Person> persons { get; set; } = new List<Person>();
    }
}
