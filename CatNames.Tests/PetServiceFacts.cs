using System.Collections.Generic;
using Xunit;

namespace CatNames.Tests
{
    public class PetServiceFacts
    {
        [Fact]
        public void ShouldPrintPetOwner()
        {
            var pet = new PetDto
            {
                name = "Docy",
                owner = "Kate",
                type = "Cat"
            };
            
            Assert.Equal("  • Kate", PetService.PrintOwner(pet));
        }
    }
}