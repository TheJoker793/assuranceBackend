using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class PoliceDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateAjout { get; set; }
        
        public int PersonneId { get; set; }//ok
        public string? CinPersonne { get; set; }
        public string? PrenomPersonne { get; set; }
        public string? NomPersonne { get; set; }
        public DateTime? DateNaissancePersonne {  get; set; }
        
        public int AssureurId { get; set; }//ok
        public string? DesignationAssureur { get; set; }
        public string? AddressAssureur { get; set; }
        
        public int ContratId { get; set; }//ok
        public DateTime? DateEffet { get; set; }
        public DateTime? DateEcheance { get; set; }
        public DateTime? DateSignature { get; set; }
        public float? ExerciceContrat { get; set; }
        
        public int MarchandiseId { get; set; }//ok
        public string? CodeMarchandise {  get; set; }
        public string? NatureMarchandise { get; set; }
        
        public int ArticleId { get; set; }//ok
        public string? LibelleArticle {  get; set; }
        public string? ReferenceArticle { get; set; }
        public float? PrixArticle { get; set; }
        
        public int TypeBienId { get; set; }
        public string? LibelleTypeBien { get; set; }
    }
}
