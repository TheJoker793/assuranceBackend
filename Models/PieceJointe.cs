namespace Assurance_Backend.Models
{
    public class PieceJointe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime DateCreation { get; set; }
        public int SinistreId { get; set; }
        public Sinistre Sinistre { get; set; }
    }
}
