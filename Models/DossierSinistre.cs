namespace Assurance_Backend.Models
{
    public class DossierSinistre
    {
        public int Id { get; set; }
        public DateTime DateAjout { get; set; }
        public double MontantAssurance { get; set; }
        public double MontantSinistre { get; set; }
        public string Observation {  get; set; }  
        public int SinistreId { get; set; }
        public Sinistre Sinistre { get; set; }
        public int DossierId {  get; set; }
        public Dossier Dossier { get; set; }
        public ICollection<Quittance> Quittances { get; set; }
    }
}
