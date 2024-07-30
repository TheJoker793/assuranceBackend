namespace Assurance_Backend.Models
{
    public class Reglement
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DateRemise { get; set;}
        public int SituationId { get; set; }
        public Situation Situation { get; set; }
        public int CompteBancaireId { get; set; }
        public CompteBancaire CompteBancaire { get; set; }
       
        public int PersonneId { get; set; }
        public Personne Personne { get; set;}
        public int TypeReglementId { get; set; }
        public TypeReglement TypeReglement { get; set; }
        


    }
}
