namespace Assurance_Backend.Models
{
    public class SinistreItem
    {
        public int Id { get; set; }
        public DateTime DateAjout { get; set; }
        public string Description { get; set; }
        public int Quantite { get; set; }
        public float Prix { get; set; }
        
        public int SinistreItemNatureId { get; set; }
        public SinistreItemNature SinistreItemNature { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int BienId { get; set; }
        public Bien Bien { get; set; }
        
    }
}
