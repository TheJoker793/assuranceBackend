namespace Assurance_Backend.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Reference { get; set; }
        public float Prix { get; set; }
        public ICollection<DemandeItem> DemandeItems { get; set;}
        public ICollection<Police> Polices { get; set;}
        public ICollection<SinistreItem> SinistreItems { get; set;}
    }
}
