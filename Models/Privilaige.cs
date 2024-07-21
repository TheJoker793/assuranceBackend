namespace Assurance_Backend.Models
{
    public class Privilaige
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int Etat { get; set; }
        public ICollection<PrivilaigeCompte> PrivilaigeComptes { get; set; }

    }
}
