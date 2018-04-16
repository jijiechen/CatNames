using System;
using System.Collections.Generic;
using CatNames.Models;
using CatNames.Services;
using Xunit;

namespace CatNames.Tests
{
    public class PetServiceFacts
    {
        [Fact]
        public void ShouldPrintPet()
        {
            var pet = new Pet
            {
                name = "Docy",
                type = "Cat"
            };
            
            Assert.Equal("  • Docy", pet.ToString());
        }
        
        
        [Fact]
        public void ShouldPrintPetOwnerGender()
        {
            var pets = new List<Pet>()
            {
                new Pet

                {
                    name = "Docy",
                    ownerGender = "Female",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Female" + Environment.NewLine + "  • Docy", PetService.PrintPets(pets));
        }     
        
        
        [Fact]
        public void ShouldPrintMultiplePetsInalphabeticalOrderWithSameOwnerGender()
        {
            var pets = new List<Pet>()
            {
                new Pet

                {
                    name = "Docy",
                    ownerGender = "Female",
                    type = "Cat"
                },
                new Pet
                {
                    name = "Amy",
                    ownerGender = "Female",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Female" + Environment.NewLine + "  • Amy"
                         + Environment.NewLine + "  • Docy", PetService.PrintPets(pets));
        }
                
        [Fact]
        public void ShouldPrintMultiplePetsWithDifferentOwnerGenders()
        {
            var pets = new List<Pet>()
            {
                new Pet

                {
                    name = "Docy",
                    ownerGender = "Female",
                    type = "Cat"
                },
                new Pet
                {
                    name = "Amy",
                    ownerGender = "Male",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Male" + Environment.NewLine + "  • Amy"
                         + Environment.NewLine
                         + "Female" + Environment.NewLine + "  • Docy", PetService.PrintPets(pets));
        }
             
        [Fact]
        public void ShouldPrintMultiplePetsFromPeople()
        {
            var people = new List<PersonDataModel>()
            {
                new PersonDataModel()
                {
                    name = "Jim",
                    gender = "Male",
                    age = 18,
                    pets = new List<PetDataModel>()
                    {
                        new PetDataModel

                        {
                            name = "Docy",
                            type = "Cat"
                        },
                        new PetDataModel
                        {
                            name = "Amy",
                            type = "Dog"
                        }
                    }
                },
                new PersonDataModel()
                {
                    name = "Kite",
                    gender = "Female",
                    age = 18,
                    pets = new List<PetDataModel>()
                    {
                        new PetDataModel

                        {
                            name = "Mow",
                            type = "Cat"
                        }
                    }
                }
            };

            var pets = PetService.ListPets(people);
            Assert.Equal("Male" + Environment.NewLine + "  • Docy"
                         + Environment.NewLine 
                         + "Female" + Environment.NewLine + "  • Mow", PetService.PrintPets(pets));
        }
                     
        [Fact]
        public void ShouldOnlyPrintCats()
        {
            var pet = new List<Pet>()
            {
                new Pet

                {
                    name = "Docy",
                    ownerGender = "Female",
                    type = "Cat"
                },
                new Pet
                {
                    name = "Amy",
                    ownerGender = "Male",
                    type = "Dog"
                },
                new Pet
                {
                    name = "Mow",
                    ownerGender = "Male",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Male" + Environment.NewLine + "  • Mow"
                         + Environment.NewLine 
                + "Female" + Environment.NewLine + "  • Docy", PetService.PrintPets(pet));
        }
        
        
        [Fact]
        public void ShouldListPetsFromPeople()
        {
            var people = new List<PersonDataModel>()
            {
                new PersonDataModel
                {
                    name = "Jim",
                    pets = new List<PetDataModel>
                    {
                        new PetDataModel {name = "Amy", type = "dog"}
                    }
                },
                new PersonDataModel
                {
                    name = "Kate",
                    pets = new List<PetDataModel>
                    {
                        new PetDataModel {name = "Docy", type = "cat"}
                    }
                }
            };
            

            var pets = PetService.ListPets(people);
            Assert.Equal(2, pets.Count);
            Assert.Equal("Amy", pets[0].name);
            Assert.Equal("Docy", pets[1].name);
        }
          
        [Fact]
        public void ShouldListAndIgnoreNullPetsFromPeople()
        {
            var people = new List<PersonDataModel>()
            {
                new PersonDataModel
                {
                    name = "Jim",
                    pets = null
                },
                new PersonDataModel
                {
                    name = "Kate",
                    pets = new List<PetDataModel>
                    {
                        new PetDataModel {name = "Docy", type = "cat"}
                    }
                }
            };
            

            var pets = PetService.ListPets(people);
            Assert.Equal(1, pets.Count);
            Assert.Equal("Docy", pets[0].name);
        }
        
    }
}