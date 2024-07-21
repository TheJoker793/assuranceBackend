namespace Assurance_Backend.Models
{
    public class ItemMarchandise
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int MarchandiseId { get; set; }
        public Marchandise Marchandise { get; set; }
    }
}
