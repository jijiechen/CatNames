using System;
using System.Collections.Immutable;
using System.Net;
using Autofac;
using Autofac.Core;
using CatNames.Providers;

namespace CatNames
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrintedPetsInConsole());
            Console.WriteLine(PrintedPetsWithDependencyInjection());
        }

        public static string PrintedPetsInConsole()
        {
            var fetcher = new JsonFetcher(new WebRequester());

            var people = new PeopleService(fetcher).GetPeople();
            var pets = PetService.ListPets(people);
            var printedPets = PetService.PrintPets(pets);
            return printedPets;
        }
        
        public static string PrintedPetsWithDependencyInjection(Action<ContainerBuilder> configureSerices = null)
        {
            var buidler = new ContainerBuilder();
            
            buidler.RegisterType<WebRequester>().As<IRequester>().SingleInstance();
            buidler.RegisterType<JsonFetcher>();
            buidler.RegisterType<PeopleService>();
            configureSerices?.Invoke(buidler);

            using (var container = buidler.Build())
            {

                var people = container.Resolve<PeopleService>().GetPeople();
                var pets = PetService.ListPets(people);
                var printedPets = PetService.PrintPets(pets);
                return printedPets;
            }
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
