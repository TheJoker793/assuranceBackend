namespace Assurance_Backend.Models
{
    public class CompteBancaire
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Rib { get; set; }
        public string Cle { get; set; }
        public ICollection<Reglement> Reglements { get; set; }
    }
}
