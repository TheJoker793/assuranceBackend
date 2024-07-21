using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class DossierSinistreDto
    {
        public int Id { get; set; }
        public DateTime DateAjout { get; set; }
        public double MontantAssurance { get; set; }
        public double MontantSinistre { get; set; }
        public string Observation { get; set; }
        public int SinistreId { get; set; }
        public int DossierId { get; set; }
    }
}
