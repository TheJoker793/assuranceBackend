namespace Assurance_Backend.Models
{
    public class Contrat
    {
        public int Id { get; set; }
        public DateTime DateEffet { get; set; }
        public DateTime DateEcheance { get; set; }
        public DateTime DateSignature { get; set; }
        public float Exercice { get; set; }
        public int NatureContratId {  get; set; }
        public NatureContrat NatureContrat { get; set; }
        public int QuittancePrimeId { get; set; }
        public QuittancePrime QuittancePrime { get; set; }
        public ICollection<Police> Polices { get; set; }


    }
}
