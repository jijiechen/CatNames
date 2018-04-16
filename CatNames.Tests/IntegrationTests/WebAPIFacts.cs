using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CatNames.Tests.IntegrationTests
{
    public class WebAPIFacts
    {
        [Fact]
        public void ShouldAbleToPrintViaWebInterface()
        {
            var port = 3000;
            new Thread(() => Program.PrintedPetsInWebAPI(port)).Start();
            Thread.Sleep(2000);   // wait for the web server
            
            var output = new WebClient().DownloadString("http://localhost:" + port);
            
            Assert.Equal(@"Male
  • Garfield
  • Jim
  • Max
  • Tom
Female
  • Garfield
  • Simba
  • Tabby", output);
        }
    }
}