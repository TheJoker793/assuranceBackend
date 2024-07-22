using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class ReglementDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DateRemise { get; set; }
        public int SituationId { get; set; }
        public string? LibelleSituation { get; set; }
        
        public int CompteBancaireId { get; set; }
        public string? LibelleCompteBancaire {  get; set; }
        public string? RibCompteBancaire { get; set; }
        public string? CleCompteBancaire { get; set; }

        public int DevisId { get; set; }
        public string? LibelleDevis {  get; set; }


        public int PersonneId { get; set; }
        public string? CinPersonne {  get; set; }
        public string? PrenomPersonne {  get; set; }
        public string? NomPersonne { get; set; }

    }
}
