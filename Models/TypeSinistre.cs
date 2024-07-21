namespace Assurance_Backend.Models
{
    public class TypeSinistre
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<Sinistre> Sinistres { get; set; }
    }
}
