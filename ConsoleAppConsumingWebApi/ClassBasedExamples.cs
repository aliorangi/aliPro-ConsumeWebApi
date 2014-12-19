using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add the following using statements:
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ConsoleAppConsumingWebApi
{
    class ClassBasedExamples
    {
        public static void PrintClassExamples()
        {
            string showOutputString = "id: {0};  BackGroundImagePath: {1}, ShowName : {2}";

            Console.WriteLine("Display all shows by calling WebApi Method GetAllShows:");
            IEnumerable<Show> show = ClassBasedExamples.getAllShows();

            IEnumerable<Category> Category = ClassBasedExamples.getAllCategories();


            foreach (var sh in show)
            {
                Console.WriteLine(showOutputString, sh.Id, sh.BackGroundImagePath, sh.ShowName);
            }


            string categoryOutputString = " CategoryName : {0} , CategoryId : {1}";
            foreach (var ca in Category)
            {
                Console.WriteLine(categoryOutputString, ca.CategoryId, ca.CategoryName);
            }
            

            Console.WriteLine(Environment.NewLine
                + "Display a Show object by ID:");

            Show showSel = ClassBasedExamples.getShowData(3);
            Console.WriteLine(showOutputString, showSel.Id,
                showSel.BackGroundImagePath, showSel.ShowName);

            
            // Using Method CreateShow 
            Console.WriteLine(Environment.NewLine
                + "Create a new Show object and return the new object:");

            Show newShow= new Show { BackGroundImagePath = "c:\\Video\\AboutA Boy.jpg", ShowName = "About A Boy" };
            newShow = CreateShow(newShow);
            Console.WriteLine(showOutputString, newShow.Id,
                newShow.BackGroundImagePath, newShow.ShowName);


            // DELETE AN EXISTING Show BY ID:
            Console.WriteLine(Environment.NewLine + "Delete a show object:");
            ClassBasedExamples.DeleteShow(5);


            Console.Read();
        }
     

        static IEnumerable<Show> getAllShows()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response =
                client.GetAsync("http://localhost:57772/api/show/").Result;
            client.Dispose();

            return response.Content.ReadAsAsync<IEnumerable<Show>>().Result;
        }

        static Show getShowData(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response =
                client.GetAsync("http://localhost:57772/api/show/" + id).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<Show>().Result;
        }

        static Show CreateShow(Show newPerson)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57772/");
            var response = client.PostAsJsonAsync("api/show", newPerson).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<Show>().Result;
        }

        static void DeleteShow(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57772/");
            var relativeUri = "api/show/" + id.ToString();
            var response = client.DeleteAsync(relativeUri).Result;
            client.Dispose();
        }

        static IEnumerable<Category> getAllCategories()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response =
                client.GetAsync("http://localhost:57772/api/category/").Result;
            client.Dispose();

            return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
        }




    }
}
