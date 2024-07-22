using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class CompteDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PersonneId { get; set; }
        public string? CinPersonne {  get; set; }
        public string? PrenomPersonne { get; set; }
        public string? NomPersonne { get; set; }
        public DateTime? DateNaissancePersonne {  get; set; } 
    }
}
