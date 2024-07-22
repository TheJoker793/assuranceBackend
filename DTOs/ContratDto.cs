using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class ContratDto
    {
        public int Id { get; set; }
        public DateTime DateEffet { get; set; }
        public DateTime DateEcheance { get; set; }
        public DateTime DateSignature { get; set; }
        public float Exercice { get; set; }
        public int NatureContratId { get; set; }
        public string? LibelleNatureContrat {  get; set; }
        public int QuittancePrimeId { get; set; }
        public string? LibelleQuittancePrime { get; set; }
        public double ? MontantQuittancePrime { get; set; }
        public DateTime? DateAjoutQuittancePrime { get; set; } 

    }
}
