using System;
using System.Collections.Generic;
using System.Linq;
using CatNames.Models;

namespace CatNames.Services
{

    public class PetService
    {
        static Pet ToPet(PetDataModel petDataModel, PersonDataModel personDataModel)
        {
            return new Pet()
            {
                name = petDataModel.name,
                type = petDataModel.type,
                ownerGender = personDataModel.gender
            };
        }
        
        static List<Pet> ListPets(PersonDataModel personDataModel)
        {
            return (personDataModel.pets ?? new List<PetDataModel>())
                .Select(pet => ToPet(pet, personDataModel))
                .ToList();
        }

        
        public static List<Pet> ListPets(List<PersonDataModel> people)
        {
            return people
                .SelectMany(ListPets)
                .ToList();
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
                        string.Join(Environment.NewLine, 
                            petGroup
                            .OrderBy(pet => pet.name)
                            .Select(pet => pet.ToString())));
                });
            
            return String.Join(Environment.NewLine, groupedItems);
        }
    }
}