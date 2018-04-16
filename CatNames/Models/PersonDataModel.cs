using System.Collections.Generic;

namespace CatNames.Models
{
    public class PersonDataModel
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<PetDataModel> pets { get; set; }
    }
}