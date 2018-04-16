﻿using System;
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
        
        
        [Fact]
        public void ShouldPrintPetOwnerGender()
        {
            var pet = new List<PetDto>()
            {
                new PetDto

                {
                    name = "Docy",
                    owner = "Kate",
                    gender = "Female",
                    type = "Cat"
                }
            };
            
            Assert.Equal("Female" + Environment.NewLine + "  • Kate", PetService.PrintPets(pet));
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
        
        
        [Fact]
        public void ShouldListPetsInalphabeticalOrder()
        {
            var people = new List<Person>()
            {
                new Person
                {
                    name = "Jim",
                    pets = new List<Pet>
                    {
                        new Pet {name = "Lovely", type = "dog"}
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
            
            Assert.Equal("Docy", pets[0].name);
            Assert.Equal("Kate", pets[0].owner);
            
            Assert.Equal("Lovely", pets[1].name);
            Assert.Equal("Jim", pets[1].owner);
        }
    }
}