namespace CatNames
{
    public class Pet
    {
        public string name { get; set; }
        public string type { get; set; }
    }
    
    public class PetDto
    {
        public string owner { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}