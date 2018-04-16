﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatNames
{

    public class PetService
    {
        static PetDto ToDto(Pet pet, Person person)
        {
            return new PetDto()
            {
                name = pet.name,
                type = pet.type,
                ownerName = person.name
            };
        }
        
        static List<PetDto> ListPetAsDtos(Person person)
        {
            return person.pets
                .Select(pet => ToDto(pet, person))
                .ToList();
        }

        
        public static List<PetDto> ListPets(List<Person> people)
        {
            return people
                .SelectMany(ListPetAsDtos)
                .ToList();
        }
        
        public static string PrintOwner(PetDto pet)
        {
            return string.Format($"  • {pet.name}");
        }

        public static string PrintPets(List<PetDto> pets)
        {
            var groups = pets
                .Where(pet => pet.type == "Cat")
                .GroupBy(pet => pet.ownerGender);
            
            var outputBuilder = new StringBuilder();
            groups
                .OrderByDescending(group => group.Key)
                .ToList()
                .ForEach(petGroup =>
                {
                    outputBuilder.AppendLine(petGroup.Key);
                    outputBuilder.Append(string.Join(Environment.NewLine, petGroup.OrderBy(pet => pet.name).Select(PrintOwner)));
                });
            
            return outputBuilder.ToString();
        }
    }
}