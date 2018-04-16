using System;
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
                .OrderBy(pet => pet.name)
                .ToList();
        }
        
        public static string PrintOwner(PetDto pet)
        {
            return string.Format($"  • {pet.ownerName}");
        }

        public static string PrintPets(List<PetDto> pets)
        {
            var groups = pets.GroupBy(pet => pet.ownerGender);
            
            var outputBuilder = new StringBuilder();
            groups.ToList()
                .ForEach(petGroup =>
                {
                    outputBuilder.AppendLine(petGroup.Key);
                    outputBuilder.Append(string.Join(Environment.NewLine, petGroup.Select(PrintOwner)));
                });
            
            return outputBuilder.ToString();
        }
    }
}