using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class ReglementDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DateRemise { get; set; }
        public int SituationId { get; set; }
        public int CompteBancaireId { get; set; }
        public int DevisId { get; set; }
        public int PersonneId { get; set; }
    }
}
