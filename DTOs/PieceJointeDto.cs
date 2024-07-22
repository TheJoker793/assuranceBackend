namespace Assurance_Backend.DTOs
{
    public class PieceJointeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime DateCreation { get; set; }
        public int SinistreId { get; set; }
        public string? LibelleSinistre { get; set; }
        public string? ReferenceSinistre { get; set; }

    }
}
