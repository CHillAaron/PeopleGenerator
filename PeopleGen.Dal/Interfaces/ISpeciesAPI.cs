using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Dal.Interfaces
{
    public interface ISpeciesAPI
    {
        //Task<List<string>> GetApiSpecies(string race);
        Task<string> get(string race);
    }
}
