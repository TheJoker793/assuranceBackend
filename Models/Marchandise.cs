namespace Assurance_Backend.Models
{
    public class Marchandise
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string Nature { get; set; }
       
        public int TypeTransportId {  get; set; }
        public TypeTransport TypeTransport { get; set; }
        public ICollection<Police> Polices { get; set; }
        public ICollection<DemandeItem> DemandeItems { get; set; }
        public ICollection<ItemMarchandise> ItemMarchandises { get; set; }

    }
}
