namespace GestionAchats.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Designation { get; set; }
        public string Unite { get; set; }
        public string Categorie { get; set; }

        public override string ToString()
        {
            return Reference + " - " + Designation;
        }
    }
}
