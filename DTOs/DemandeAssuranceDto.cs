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
        public string? LibelleDemandeType { get; set; }

        public int QuittancePrimeId { get; set; }
        public string? LibelleQuittancePrime {  get; set; }
        public double? MontantQuittancePrime { get; set; }
        public DateTime? DateAjoutQuittancePrime { get; set; }

        public int PersonneId { get; set; }
        public string? Cin {  get; set; }
        public string? NomPersonne { get; set; }
        public string? PrenomPersonne { get; set; }
        public DateTime? DateNAissancePersonne { get; set; }
    }
}
