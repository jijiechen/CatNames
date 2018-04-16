using Xunit;

namespace CatNames.Tests.IntegrationTests
{
    public static class AssertOutputEqual
    {
        public static void AssertEqual(this string output, string expected)
        {
            output = output.Replace("\r", "");
            expected = expected.Replace("\r", "");
            
            Assert.Equal(expected, output);
        }
    }
}