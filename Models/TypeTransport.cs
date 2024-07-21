namespace Assurance_Backend.Models
{
    public class TypeTransport
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<Marchandise> Marchandises { get; set; }
    }
}
