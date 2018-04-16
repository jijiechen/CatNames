
using Xunit;

namespace CatNames.Tests.IntegrationTests
{
    public class ConsoleOutputFacts
    {
        [Fact]
        public void ShouldOutputCorrectlyUsingOnlineJson()
        {
            var output = Program.PrintedPetsInConsole();
            output.AssertEqual(@"Male
  • Garfield
  • Jim
  • Max
  • Tom
Female
  • Garfield
  • Simba
  • Tabby");
        }
    }
}