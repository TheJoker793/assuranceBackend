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
        public int QuittancePrimeId { get; set; }
    }
}
