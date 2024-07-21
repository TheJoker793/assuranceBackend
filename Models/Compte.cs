namespace Assurance_Backend.Models
{
    public class Compte
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
        public int PersonneId { get; set; }
        public Personne Personne { get; set; }
        public ICollection<PrivilaigeCompte> PrivilaigeComptes { get; set; }
    }
}
