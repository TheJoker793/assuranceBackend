namespace Assurance_Backend.Models
{
    public class DemandeAssurance
    {  
        public int Id { get; set; }
        public string Reference {get; set;}
        public DateTime DateDemande { get; set;}
        public DateTime DateEffet { get; set; }
        public int DemandeTypeId { get; set;}
        public DemandeType DemandeType { get; set;}
        public int QuittancePrimeId { get; set; }
        public QuittancePrime QuittancePrime { get; set; }
        public int PersonneId { get; set; }
        public Personne Personne { get; set; }
        //public ICollection<DemandeItem> DemandeItems { get; set; }



    }
}
