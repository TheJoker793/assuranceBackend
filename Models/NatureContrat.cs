namespace Assurance_Backend.Models
{
    public class NatureContrat
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<Contrat> Contrats { get; set; }
    }
}
