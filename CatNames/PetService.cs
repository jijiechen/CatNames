using System.Collections.Generic;
using System.Linq;

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
                owner = person.name
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
            return string.Format($"  • {pet.owner}");
        }
    }
}