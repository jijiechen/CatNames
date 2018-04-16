using System;
using System.Net;
using CatNames.Providers;

namespace CatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var fetcher = new JsonFetcher(new WebRequester());

            var people = new PeopleService(fetcher).GetPeople();
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
