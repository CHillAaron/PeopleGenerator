using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleGen.Dal.Test
{
    [TestClass]
    public class PeopleServiceTest
    {
        PeopleDbContext context {get; set; }
        PeopleService peopleService;

        [TestInitialize]
        public void Setup()
        {
            context = new PeopleDbContext();
            peopleService = new PeopleService(context);
        }
        [TestMethod]
        public void GetAllPeople()
        {
            List<Person> people = peopleService.GetAllPeople();
            Assert.AreEqual(2, people.Count);
        }

        [TestMethod]
        public void GetPersonByName()
        {
            IQueryable<Person> query = context.Persons.Where(person => person.FirstName == "Talice");
            Person talice = peopleService.GetPersonByName("Talice");
            Assert.AreEqual("Talice", talice.FirstName);
        }
        //[TestMethod]
        //public void TestAddTodoItem()
        //{
        //    Person newPerson = new Person();
        //    newPerson.FirstName = "Denede";
        //    newPerson.LastName = "Fire bringer";
        //    newPerson.Race = "Elf";
        //    newPerson.Age = 30;
        //    peopleService.AddPerson(newPerson);
        //    Assert.AreEqual(peopleService.GetAllPeople().Count, 3);
        //}

    }
}
