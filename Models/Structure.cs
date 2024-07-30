namespace Assurance_Backend.Models
{
    public class Structure
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Designation { get; set; }
        public ICollection<Personne>Personnes { get; set; }
        public ICollection<Bien> Biens { get; set; }
        
    }
}
