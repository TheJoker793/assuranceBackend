namespace Assurance_Backend.Models
{
    public class DemandeType
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<DemandeAssurance> DemandeAssurances { get; set; }
    }
}
