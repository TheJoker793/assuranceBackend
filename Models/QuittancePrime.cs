namespace Assurance_Backend.Models
{
    public class QuittancePrime
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public double Montant { get; set; }
        public DateTime DateAjout { get; set; }
        public ICollection<Contrat> Contrats { get; set; }
        public ICollection <DemandeAssurance> DemandeAssurances { get; set; }
    }
}
