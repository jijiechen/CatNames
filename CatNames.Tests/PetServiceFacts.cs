using System;
using System.Collections.Generic;
using Xunit;

namespace CatNames.Tests
{
    public class PetServiceFacts
    {
        [Fact]
        public void ShouldPrintPet()
        {
            var pet = new PetDto
            {
                name = "Docy",
                ownerName = "Kate",
                type = "Cat"
            };
            
            Assert.Equal("  • Docy", PetService.PrintOwner(pet));
        }
        
        
        [Fact]
        public void ShouldPrintPetOwnerGender()
        {
            var pet = new List<PetDto>()
            {
                new PetDto

                {
                    name = "Docy",
                    ownerName = "Kate",
                    ownerGender = "Female",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Female" + Environment.NewLine + "  • Docy", PetService.PrintPets(pet));
        }     
        
        
        [Fact]
        public void ShouldPrintMultiplePetsInalphabeticalOrderWithSameOwnerGender()
        {
            var pet = new List<PetDto>()
            {
                new PetDto

                {
                    name = "Docy",
                    ownerName = "Kate",
                    ownerGender = "Female",
                    type = "Cat"
                },
                new PetDto
                {
                    name = "Amy",
                    ownerName = "Mary",
                    ownerGender = "Female",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Female" + Environment.NewLine + "  • Amy"
                         + Environment.NewLine + "  • Docy", PetService.PrintPets(pet));
        }
                
        [Fact]
        public void ShouldPrintMultiplePetsWithDifferentOwnerGenders()
        {
            var pet = new List<PetDto>()
            {
                new PetDto

                {
                    name = "Docy",
                    ownerName = "Kate",
                    ownerGender = "Female",
                    type = "Cat"
                },
                new PetDto
                {
                    name = "Amy",
                    ownerName = "Jim",
                    ownerGender = "Male",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Male" + Environment.NewLine + "  • Amy"
                         + "Female" + Environment.NewLine + "  • Docy", PetService.PrintPets(pet));
        }
                     
        [Fact]
        public void ShouldOnlyPrintCats()
        {
            var pet = new List<PetDto>()
            {
                new PetDto

                {
                    name = "Docy",
                    ownerName = "Kate",
                    ownerGender = "Female",
                    type = "Cat"
                },
                new PetDto
                {
                    name = "Amy",
                    ownerName = "Jim",
                    ownerGender = "Male",
                    type = "Dog"
                },
                new PetDto
                {
                    name = "Mow",
                    ownerName = "David",
                    ownerGender = "Male",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Male" + Environment.NewLine + "  • Mow"
                + "Female" + Environment.NewLine + "  • Docy", PetService.PrintPets(pet));
        }
        
        
        [Fact]
        public void ShouldListPetsWithPeople()
        {
            var people = new List<Person>()
            {
                new Person
                {
                    name = "Jim",
                    pets = new List<Pet>
                    {
                        new Pet {name = "Amy", type = "dog"}
                    }
                },
                new Person
                {
                    name = "Kate",
                    pets = new List<Pet>
                    {
                        new Pet {name = "Docy", type = "cat"}
                    }
                }
            };
            

            var pets = PetService.ListPets(people);
            Assert.Equal(2, pets.Count);
            Assert.Equal("Amy", pets[0].name);
            Assert.Equal("Docy", pets[1].name);
        }
        
    }
}