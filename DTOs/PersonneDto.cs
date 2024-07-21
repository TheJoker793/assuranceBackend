namespace Assurance_Backend.DTOs
{
    public class PersonneDto
    {
        public int Id { get; set; }
        public string Cin { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int StructureId { get; set; }
    }
}
