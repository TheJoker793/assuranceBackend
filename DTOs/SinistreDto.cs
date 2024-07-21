using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class SinistreDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public float MontantExpertise { get; set; }
        public float MontantIndemniser { get; set; }
        public DateTime DateSinistre { get; set; }
        public DateTime DateAjout { get; set; }
        public string DegatMateriel { get; set; }
        public string Cause { get; set; }
        public string Lieux { get; set; }
        public string Objet { get; set; }
        public DateTime DateValidation { get; set; }
        public int TypeSinistreId { get; set; }//ok
        public int SituationId { get; set; }
        public int PersonneId { get; set; }
    }
}
