namespace Assurance_Backend.Models
{
    public class PrivilaigeCompte
    {
        public int Id { get; set; }
        public int PrivilaigeId { get; set; }
        public Privilaige Privilaige { get; set; }  
        public int CompteId { get; set; }
        public Compte Compte { get; set; }
    }
}
