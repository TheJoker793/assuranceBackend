namespace Assurance_Backend.Models
{
    public class SinistreItemNature
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<SinistreItem> SinistreItems { get; set; }

    }
}
