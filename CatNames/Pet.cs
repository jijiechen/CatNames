namespace CatNames
{
    public class Pet
    {
        public string name { get; set; }
        public string type { get; set; }
    }
    
    public class PetDto
    {
        public string name { get; set; }
        public string type { get; set; }
        
        public string ownerGender { get; set; }
    }
}