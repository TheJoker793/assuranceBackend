using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class PrivilaigeCompteDto
    {
        public int Id { get; set; }
        public int PrivilaigeId { get; set; }
        public int CompteId { get; set; }
    }
}
