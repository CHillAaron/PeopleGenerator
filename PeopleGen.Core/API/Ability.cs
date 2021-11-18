using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Core.API
{
    class Ability
    {
        public List<Ability_Score> Ability_Score { get; set; }
        public int Bonus { get; set; }
    }
}
