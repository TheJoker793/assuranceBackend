namespace Assurance_Backend.Models
{
    public class Assureur
    {
        public int Id { get; set; } 
        public string Designation { get; set; }
        public string Address { get; set; }
        public ICollection<Police> Polices { get; set; }
        public ICollection<Quittance> Quittances { get; set; }
    }
}
