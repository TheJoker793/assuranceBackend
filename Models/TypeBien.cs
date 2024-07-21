namespace Assurance_Backend.Models
{
    public class TypeBien
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int DureeVie { get; set; }
        public ICollection<Bien> Biens { get; set; }
        public ICollection<Police> Polices { get; set; }
    }
}
