namespace Assurance_Backend.Models
{
    public class DemandeItem
    {
        public int Id { get; set; }
        public DateTime DateEffet { get; set; }
        public string Origine { get; set; }
        public string Destination { get; set; }
        public DateTime DateExpedition { get; set; }
        public string NomNavire { get; set; }
        public string NomChauffeur { get; set; }
        public string NomCompanie { get; set; }
        public string Matricule { get; set;}
        public int IdZone { get; set; }
        public int BienId { get; set; }//ok
        public Bien Bien { get; set; }
        
        public int MarchandseId { get; set; }//ok
        public Marchandise Marchandise { get; set; }

    }
}
