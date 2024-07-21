namespace Assurance_Backend.Models
{
    public class Devis
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection <Quittance> Quittances { get; set; }
        public ICollection<Reglement> Reglements { get; set; }
    }
}
