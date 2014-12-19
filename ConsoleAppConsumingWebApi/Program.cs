using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ConsoleAppConsumingWebApi
{
    class Program 
    {
        public class Category
        {
            public int CategoryID { get; set; }
            public int CategoryName { get; set; }
            public virtual Show show { get; set; }
        }

        public class Show
        {
            public int Id { get; set; }

            public string FirstName  { get; set; }
            public string BackgoroundImage { get; set; }

            public virtual ICollection<Category> categories { get; set; }
        }

        static IEnumerable<Show> getAllPeople()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response =
                client.GetAsync("http://localhost:57772/api/show/").Result;
            client.Dispose();

            return response.Content.ReadAsAsync<IEnumerable<Show>>().Result;
        }

        static Show getShow(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response =
                client.GetAsync("http://localhost:57772/api/show/" + id).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<Show>().Result;
        }

        static Show AddShow(Show newShow)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57772/");
            var response = client.PostAsJsonAsync("api/show", newShow).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<Show>().Result;
        }

        static bool UpdateShow(Show newShow)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57772/");
            var response = client.PutAsJsonAsync("api/show/", newShow).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<bool>().Result;
        }

        static void DeleteShow(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57772/");
            var relativeUri = "api/show/" + id.ToString();
            var response = client.DeleteAsync(relativeUri).Result;
            client.Dispose();
        }

        //public static void PrintJsonExamples()
        //{
        //    // WRITE ALL PEOPLE TO CONSOLE (JSON):
        //    Console.WriteLine("Retreive All The People:");
        //    JArray people = getAllPeople();
        //    foreach (var person in people)
        //    {
        //        Console.WriteLine(person);
        //    }

        //    // WRITE A SPECIFIC PERSON TO CONSOLE (JSON):
        //    Console.WriteLine(Environment.NewLine + "Retreive a Show by ID:");
        //    JObject singleShow = getShow(2);
        //    Console.WriteLine(singleShow);

        //    // ADD NEW PERSON, THEN WRITE TO CONSOLE (JSON):
        //    Console.WriteLine(Environment.NewLine + "Add a new Show and return the new object:");
        //    JObject newShow = AddShow("Atten", "John");
        //    Console.WriteLine(newShow);

        //    // UPDATE AN EXISTING PERSON, THEN WRITE TO CONSOLE (JSON):
        //    Console.WriteLine(Environment.NewLine + "Update an existing Show and return a boolean:");

        //    // Pretend we already had a person's data:
        //    JObject personToUpdate = getShow(2);
        //    string newBackgoroundImage = "Richards";

        //    Console.WriteLine("Update Last Name of " + personToUpdate + "to " + newBackgoroundImage);

        //    // Pretend we don't already know the Id:
        //    int id = personToUpdate.Value<int>("Id");
        //    string FirstName  = personToUpdate.Value<string>("FirstName ");
        //    string BackgoroundImage = personToUpdate.Value<string>("BackgoroundImage");

        //    if (UpdateShow(id, newBackgoroundImage, FirstName ))
        //    {
        //        Console.WriteLine(Environment.NewLine + "Updated person:");
        //        Console.WriteLine(getShow(id));
        //    }

        //    // DELETE AN EXISTING PERSON BY ID:
        //    Console.WriteLine(Environment.NewLine + "Delete person object:");
        //    Program.DeleteShow(5);

        //    // WRITE THE UPDATED LIST TO THE CONSOLE:
        //    {
        //        // WRITE ALL PEOPLE TO CONSOLE
        //        Console.WriteLine("Retreive All The People using classes:");
        //        people = Program.getAllPeople();
        //        foreach (var person in people)
        //        {
        //            Console.WriteLine(person);
        //        }
        //    }

        //    Console.Read();
        //}

        //public static void PrintClassExamples()
        //{
        //    string personOutputString = "id: {0};  BackgoroundImage: {1}, ShowName : {2}";

        //    // WRITE ALL PEOPLE TO CONSOLE
        //    Console.WriteLine("Retreive All The People using classes:");
        //    IEnumerable<Show> people = Program.getAllPeople();
        //    foreach (var person in people)
        //    {
        //        Console.WriteLine(personOutputString, person.Id, person.BackgoroundImage, person.ShowName );
        //    }

        //    // WRITE A SPECIFIC PERSON TO CONSOLE:
        //    Console.WriteLine(Environment.NewLine
        //        + "Retreive a Show object by ID:");

        //    Show singleShow = Program.getShow(2);
        //    Console.WriteLine(personOutputString, singleShow.Id,
        //        singleShow.BackgoroundImage, singleShow.ShowName );

        //    // ADD NEW PERSON, THEN WRITE TO CONSOLE:
        //    Console.WriteLine(Environment.NewLine
        //        + "Add a new Show object and return the new object:");

        //    Show newShow = new Show { BackgoroundImage = "Orangi", ShowName  = "Ali" };
        //    newShow = AddShow(newShow);
        //    Console.WriteLine(personOutputString, newShow.Id,
        //        newShow.BackgoroundImage, newShow.ShowName );

        //    // UPDATE AN EXISTING PERSON, THEN WRITE TO CONSOLE:
        //    Console.WriteLine(Environment.NewLine
        //        + "Update an existing Show object:");

        //    // Pretend we already had a person's data:
        //    Show personToUpdate = getShow(2);
        //    string newBackgoroundImage = "Richards";

        //    Console.WriteLine("Updating Last Name of "
        //        + personToUpdate.BackgoroundImage + " to " + newBackgoroundImage);
        //    personToUpdate.BackgoroundImage = newBackgoroundImage;

        //    if (Program.UpdateShow(personToUpdate))
        //    {
        //        Console.WriteLine(Environment.NewLine + "Updated person object:");
        //        Show updatedShow = getShow(2);
        //        Console.WriteLine(personOutputString, updatedShow.Id,
        //            updatedShow.BackgoroundImage, updatedShow.ShowName );
        //    }

        //    // DELETE AN EXISTING PERSON BY ID:
        //    Console.WriteLine(Environment.NewLine + "Delete person object:");

        //    Program.DeleteShow(5);

        //    // WRITE THE UPDATED LIST TO THE CONSOLE:
        //    {
        //        Console.WriteLine("Retreive All The People using classes:");
        //        people = Program.getAllPeople();
        //        foreach (var person in people)
        //        {
        //            Console.WriteLine(personOutputString, person.Id,
        //                person.BackgoroundImage, person.ShowName );
        //        }
        //    }

        //    Console.Read();
        //}


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Cars", getAllPeople());
        }
   
        
        
        static void Main(string[] args)
        {

            ClassBasedExamples.PrintClassExamples();

        }


    }
}
