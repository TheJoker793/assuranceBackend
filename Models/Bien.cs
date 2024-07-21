namespace Assurance_Backend.Models
{
    public class Bien
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DaeAcquisation { get; set; }
        public int TypeBienId { get; set; }
        public TypeBien TypeBien { get; set; }
        public int StructureId { get; set; }
        public Structure Structure { get; set; }
        public ICollection<SinistreItem> SinistreItems { get; set; }
        public ICollection<DemandeItem> DemandeItems { get; set;}
    }
}
