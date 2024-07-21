using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class DemandeAssuranceDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime DateDemande { get; set; }
        public DateTime DateEffet { get; set; }
        public int DemandeTypeId { get; set; }
        public int QuittancePrimeId { get; set; }
        public int PersonneId { get; set; }
    }
}
