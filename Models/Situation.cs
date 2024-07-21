namespace Assurance_Backend.Models
{
    public class Situation
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<Sinistre> Sinistres { get; set; }
        public ICollection<Reglement> Reglements { get; set; }

    }
}
