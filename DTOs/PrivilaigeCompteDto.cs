using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class PrivilaigeCompteDto
    {
        public int Id { get; set; }
        public int PrivilaigeId { get; set; }
        public string? LibellePrivilaige {  get; set; }
        public int? EtatPrivilaige { get; set; }
        public int CompteId { get; set; }
        public string? NumeroCompte { get; set; }
        public string? EmailCompte { get; set; }
        public string? LoginCompte { get; set; }
    }
}
