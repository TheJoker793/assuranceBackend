namespace Assurance_Backend.Models
{
    public class Sinistre
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public float MontantExpertise { get; set; }
        public float MontantIndemniser { get; set; }
        public DateTime DateSinistre { get; set; }
        public DateTime DateAjout { get; set; }
        public string DegatMateriel {  get; set; }
        public string Cause { get; set; }
        public string Lieux { get; set; }
        public string Objet {  get; set; }
        public DateTime DateValidation { get; set; }
        public int TypeSinistreId { get; set; }//ok
        public TypeSinistre TypeSinistre { get; set; }
        public int SituationId { get; set; }
        public Situation Situation { get; set; }
        public int PersonneId {  get; set; }
        public Personne Personne { get; set; }
        public ICollection<DossierSinistre> DossiersSinistre { get; set; }
        public ICollection<PieceJointe> PiecesJointes { get; set; }
        //public ICollection<SinistreItem> SinistreItems { get; set; }


    }
}
