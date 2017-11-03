using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using WebApp.Models;
using System.Linq;

namespace WebApp.Test
{
    [TestClass]
    public class TestPersonsController
    {
        [TestMethod]
        public void GetAllPersons_ShouldReturnAllPersons()
        {
            var testPersons = GetAllPersons();
            var controller = new PersonsController();

            var result = controller.GetAllPersons().ToList();
            Assert.AreEqual(testPersons.Count(), result.Count());
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testPersons = GetAllPersons();
            var controller = new PersonsController();

            var result = controller.GetPerson(4) as OkNegotiatedContentResult<Person>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testPersons[3].LastName, result.Content.LastName);
            Assert.AreEqual(testPersons[3].FirstName, result.Content.FirstName);
            Assert.AreEqual(testPersons[3].Email, result.Content.Email);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new PersonsController();

            var result = controller.GetPerson(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Person> GetAllPersons()
        {
            var testPersons = new List<Person>();
            testPersons.Add(new Person { PersonID = 1, FirstName = "Fred", LastName = "Flintstone", Email = "fred.flintstone@bedrock.com" });
            testPersons.Add(new Person { PersonID = 2, FirstName = "Wilma", LastName = "Flintstone", Email = "wilma.flintstone@bedrock.com" });
            testPersons.Add(new Person { PersonID = 3, FirstName = "Barney", LastName = "Rubble", Email = "barney.rubble@bedrock.com" });
            testPersons.Add(new Person { PersonID = 4, FirstName = "Betty", LastName = "Rubble", Email = "betty.rubble@bedrock.com" });
            testPersons.Add(new Person { PersonID = 5, FirstName = "Dino", LastName = "Flintstone", Email = "dino.flintstone@bedrock.com" });

            return testPersons;
        }
    }
}
