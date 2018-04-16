using Autofac;
using CatNames.Providers;
using Xunit;

namespace CatNames.Tests.IntegrationTests
{
    public class WithDependencyIntegrationFacts
    {
        [Fact]
        public void ShouldOutputCorrectlyUsingOnlineJson()
        {
            var output = Program.PrintedPetsWithDependencyInjection();
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


        [Fact]
        public void ShouldOutputCorrectlyWithOverriding()
        {
            var json = "[{\"name\":\"Kate\",\"gender\":\"Female\",\"age\":15,\"pets\":[{\"name\":\"Kitty\",\"type\":\"Cat\"}]}]";
            var overridenRequester = new StubRequester(json);

            var output = Program.PrintedPetsWithDependencyInjection(
                builder => builder.RegisterInstance(overridenRequester).As<IRequester>());

            output.AssertEqual(@"Female
  • Kitty");

        }
    }
}