namespace Assurance_Backend.DTOs
{
    public class QuittancePrimeDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public double Montant { get; set; }
        public DateTime DateAjout { get; set; }
    }
}
