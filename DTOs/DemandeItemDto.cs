using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class DemandeItemDto
    {
        public int Id { get; set; }
        public DateTime DateEffet { get; set; }
        public string Origine { get; set; }
        public string Destination { get; set; }
        public DateTime DateExpedition { get; set; }
        public string NomNavire { get; set; }
        public string NomChauffeur { get; set; }
        public string NomCompanie { get; set; }
        public string Matricule { get; set; }
        public int IdZone { get; set; }
        public int BienId { get; set; }//ok
        public string? CodeBien { get; set; }
        public DateTime? DateAquisationBien { get; set; }
        public int MarchandseId { get; set; }//ok
        public string? CodeMarchandise { get; set; }
        public string? NatureMarchandise { get; set;}
    }
}
