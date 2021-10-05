using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Dal
{
    public class PeopleService
    {
        private PeopleDbContext _context { get;}
        PeopleDbContext serviceDbContext = new PeopleDbContext();
        public PeopleService(PeopleDbContext context)
        {
            this._context = context;
        }

        public List<Person> GetAllPeople()
        {
            return this._context.Persons.ToList();
        }
        public Person GetPersonByName(string name)
        {
            return  this._context.Persons.Where(person => person.FirstName == name).FirstOrDefault();
        }
        public Person GetPersonById(int id)
        {
            {
                return this._context.Persons.Where(person => person.PersonId == id).FirstOrDefault();
            }
        }
        public void AddPerson(Person newPerson)
        {
            serviceDbContext.Persons.Add(newPerson);
            serviceDbContext.SaveChanges();
        }
    }
}
