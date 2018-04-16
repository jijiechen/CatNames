
using Xunit;

namespace CatNames.Tests.IntegrationTests
{
    public class ConsoleOutputFacts
    {
        [Fact]
        public void ShouldOutputCorrectlyUsingOnlineJson()
        {
            var output = Program.PrintedPetsInConsole();
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