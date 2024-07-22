namespace Assurance_Backend.DTOs
{
    public class ItemMarchandiseDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int MarchandiseId { get; set; }
        public string? CodeMarchandise { get; set; }
        public string? NatureMarchandise { get; set; }

    }
}
