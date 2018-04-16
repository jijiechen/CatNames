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
        
        public static List<PetDto> ListPetAsDtos(Person person)
        {
            return person.pets
                .Select(pet => ToDto(pet, person))
                .ToList();
        }
    }
}