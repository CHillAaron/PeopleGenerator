using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Dal.Interfaces
{
    public interface ISpeciesAPI
    {
        Task<string> get(string race);
    }
}
