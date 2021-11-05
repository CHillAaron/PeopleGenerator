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
        [TestMethod]
        public void GetFirstName()
        {
            string gender = "female";
            Random random = new Random();
            if (gender == "female")
            {
                Array values = Enum.GetValues(typeof(Core.enums.FirstNamesFemale));
                Core.enums.FirstNamesFemale randumEnumValue = (Core.enums.FirstNamesFemale)values.GetValue(random.Next(values.Length));
                Console.WriteLine("The female name is " + randumEnumValue.ToString());
            }
            else
            {
                Array values = Enum.GetValues(typeof(Core.enums.FirstNamesMale));
                Core.enums.FirstNamesMale randumEnumValue = (Core.enums.FirstNamesMale)values.GetValue(random.Next(values.Length));
                Console.WriteLine("The male name is " + randumEnumValue.ToString());
            }

        }
        [TestMethod]
        public void GetAttributes()
        {
            Random random = new Random();
            int i = 0;
            while(i < 80)
            {
                int statScore = random.Next(6, 19);
                Console.WriteLine( statScore);
                i++;
            }
        }
        [TestMethod]
        public void GetAlignment()
        {
            Random random = new Random();
            //Gets the moral of the character
            Array moral = Enum.GetValues(typeof(Core.enums.Moral));
            Core.enums.Moral getMoral = (Core.enums.Moral)moral.GetValue(random.Next(moral.Length));
            //Gets the Alignment of the Character
            Array alignment = Enum.GetValues(typeof(Core.enums.Alignment));
            Core.enums.Alignment getAlignment = (Core.enums.Alignment)alignment.GetValue(random.Next(alignment.Length));
            Console.WriteLine( getMoral + " " + getAlignment);
        }
        [TestMethod]
        public void GetPersonality()
        {
            Random random = new Random();
            Array mood = Enum.GetValues(typeof(Core.enums.Personality));
            Core.enums.Personality getMood = (Core.enums.Personality)mood.GetValue(random.Next(mood.Length));
            Console.WriteLine("This is the mood: " + getMood);

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
