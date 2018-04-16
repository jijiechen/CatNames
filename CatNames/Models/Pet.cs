namespace CatNames.Models
{
    public class Pet
    {
        public string name { get; set; }
        public string type { get; set; }
        
        public string ownerGender { get; set; }

        public override string ToString()
        {
            return string.Format($"  • {this.name}");
        }
    }
}