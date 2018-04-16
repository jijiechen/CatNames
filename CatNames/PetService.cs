using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatNames.Models;

namespace CatNames
{

    public class PetService
    {
        static Pet ToDto(PetDataModel petDataModel, PersonDataModel personDataModel)
        {
            return new Pet()
            {
                name = petDataModel.name,
                type = petDataModel.type,
                ownerGender = personDataModel.gender
            };
        }
        
        static List<Pet> ListPetAsDtos(PersonDataModel personDataModel)
        {
            return (personDataModel.pets ?? new List<PetDataModel>())
                .Select(pet => ToDto(pet, personDataModel))
                .ToList();
        }

        
        public static List<Pet> ListPets(List<PersonDataModel> people)
        {
            return people
                .SelectMany(ListPetAsDtos)
                .ToList();
        }
        
        public static string PrintPet(Pet pet)
        {
            return string.Format($"  • {pet.name}");
        }

        public static string PrintPets(List<Pet> pets)
        {
            var groups = pets
                .Where(pet => pet.type == "Cat")
                .GroupBy(pet => pet.ownerGender);
            
            var groupedItems = groups
                .OrderByDescending(group => group.Key)
                .Select(petGroup =>
                {
                    return string.Concat(petGroup.Key, 
                        Environment.NewLine,
                        string.Join(Environment.NewLine, petGroup.OrderBy(pet => pet.name).Select(PrintPet)));
                });
            
            return String.Join(Environment.NewLine, groupedItems);
        }
    }
}