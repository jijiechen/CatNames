using System;
using System.Net;
using System.Text;
using Autofac;
using CatNames.Providers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CatNames
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console application mode:");
            Console.WriteLine(PrintedPetsInConsole());
            
            Console.WriteLine();
            Console.WriteLine("Console application with dependency injection enabled:");
            Console.WriteLine(PrintedPetsWithDependencyInjection());
            
            Console.WriteLine();
            var httpPort = 5000;
            Console.WriteLine("Starting a web server at http://localhost:" + httpPort);
            PrintedPetsInWebAPI(httpPort);
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

        public static void PrintedPetsInWebAPI(int httpPort)
        {
            WebHost.Start(
                    "http://localhost:" + httpPort,
                    async ctx =>
                    {
                        ctx.Response.ContentType = "text/plain; charset=utf-8";
                        await ctx.Response.WriteAsync(PrintedPetsInConsole(), Encoding.UTF8);
                    })
                .WaitForShutdown();
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
