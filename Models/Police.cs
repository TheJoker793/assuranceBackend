namespace Assurance_Backend.Models
{
    public class Police
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateAjout { get; set; }
        public int PersonneId { get; set; }//ok
        public Personne Personne { get; set; }
        public int AssureurId { get; set; }//ok
        public Assureur Assureur {  get; set; }
        public int ContratId { get; set; }//ok
        public Contrat Contrat { get; set; }
        public int MarchandiseId { get; set; }//ok
        public Marchandise Marchandise { get; set; }
        public int ArticleId { get; set; }//ok
        public Article Article { get; set; }
        public int TypeBienId { get; set; }
        public TypeBien TypeBien { get; set; }
        public ICollection<SinistreItem> SinistreItems { get; set; }
        //public ICollection<Quittance> Quittances { get; set; }




    }
}
