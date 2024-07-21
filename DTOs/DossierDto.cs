namespace Assurance_Backend.DTOs
{
    public class DossierDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Reference { get; set; }
        public DateTime DateDeclaration { get; set; }
        public string Motif { get; set; }
        public DateTime DateAjout { get; set; }
        public float MontantExpertise { get; set; }
        public float MontantIdemniser { get; set; }
    }
}
