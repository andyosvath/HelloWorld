using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLayer;
using WebApp.Controllers;
using System.Collections.ObjectModel;

namespace HelloWorld
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            // Hello World
            Console.WriteLine("Hello World");

            // Get Persons from the WebApp WebApi
            //Console.Write("\n--- Person data from WebAPI ---");
            //RunAsync().Wait();
            //Console.Write("Press any key to continue.");
            //Console.Read();

            // Get Persons from DataLayer
            //Console.Write("\n--- Person data from DataLayer ---\n");
            //PersonReader reader = new PersonReader();
            //Collection<Person> people = reader.Execute();
            //foreach (Person p in people)
            //{
            //    Console.WriteLine(string.Format("{0} - {1}, {2}: {3}", p.Id, p.LastName, p.FirstName, p.Email));
            //}

            Console.Write("\nPress any key to continue.");
            Console.Read();
        }
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Console.WriteLine();

                // Get the persons
                IEnumerable<WebApp.Models.Person> persons;
                PersonsController personController = new PersonsController();
                persons = personController.GetAllPersons();
                foreach (WebApp.Models.Person person in persons)
                {
                    Console.WriteLine(person.PersonID + " - " + person.FirstName + " " + person.LastName + " - " + person.Email);
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
