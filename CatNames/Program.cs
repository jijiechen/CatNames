using System;
using System.Net;

namespace CatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var requester = new WebRequester();
            var fetcher = new JsonFetcher(requester);
            
            var peopleService = new PeopleService(fetcher);
            var people = peopleService.GetPeople();
            var pets = PetService.ListPets(people);
            var printedPets = PetService.PrintPets(pets);
                
            Console.WriteLine(printedPets);
        }
    }

    class WebRequester : IRequester
    {
        public string Request(string uri)
        {
            return new WebClient().DownloadString(uri);
        }
    }
}
