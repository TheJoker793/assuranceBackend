using System.ComponentModel.DataAnnotations.Schema;

namespace Assurance_Backend.Models
{
    public class Quittance
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public float Montant { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateSignature { get; set; }
        public int DevisId { get; set; }
        public Devis Devis { get; set; }
        public int DossierSinistreId { get; set; }
        public required DossierSinistre DossierSinistre { get; set; }
        public int AssureurId { get; set; }
        public Assureur Assureur { get; set; }
        //public int PoliceId {  get; set; }
        //[ForeignKey("PoliceId")]

        //public Police Police { get; set; }
        //public int ReglementId { get; set; }
        //public Reglement Reglement { get; set; }

    }
}
