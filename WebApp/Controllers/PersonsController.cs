using WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class PersonsController : ApiController
    {
        Person[] persons = new Person[]
        {
            new Person { PersonID = 1, FirstName = "Fred", LastName = "Flintstone", Email = "fred.flintstone@bedrock.com" },
            new Person { PersonID = 2, FirstName = "Wilma", LastName = "Flintstone", Email = "wilma.flintstone@bedrock.com" },
            new Person { PersonID = 3, FirstName = "Barney", LastName = "Rubble", Email = "barney.rubble@bedrock.com" },
            new Person { PersonID = 4, FirstName = "Betty", LastName = "Rubble", Email = "betty.rubble@bedrock.com" },
            new Person { PersonID = 5, FirstName = "Dino", LastName = "Flintstone", Email = "dino.flintstone@bedrock.com" }
        };

        public IEnumerable<Person> GetAllPersons()
        {
            return persons;
        }

        public IHttpActionResult GetPerson(int id)
        {
            var person = persons.FirstOrDefault((p) => p.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}