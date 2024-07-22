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
        /*Attributs pour sinistre */
        public string? LibelleSinistre { get; set; }
        public string? ReferenceSinistre { get; set; }
        public string? DescriptionSinistre { get; set; }
        public float? MontantExpertiseSinistre { get; set; }
        public float? MontantIndemniserSinistre { get; set; }
        public DateTime? DateSinistre { get; set; }
        public DateTime? DateAjoutSinistre { get; set; }
        public string? DegatMaterielSinistre { get; set; }
        public string? CauseSinistre { get; set; }
        public string? LieuSinistre { get; set; }
        public string? ObjetSinistre { get; set; }
        public DateTime? DateValidationSinistre { get; set; }

        public int DossierId { get; set; }
        public string? LibelleDossier { get; set; }
        public string? ReferenceDossiser { get; set; }
        public DateTime? DateDeclarationDossiser { get; set; }
        public string? MotifDossier { get; set; }
        public DateTime? DateAjoutDossier { get; set; }
        public float? MontantExpertiseDossier { get; set; }
        public float? MontantIdemniserDossier {get;set;}
    }
}
