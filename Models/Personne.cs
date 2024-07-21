namespace Assurance_Backend.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Cin { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int StructureId { get; set; }
        public Structure Structure { get; set; }
        public ICollection<Compte>? Comptes { get; set; }
        public ICollection<Sinistre> Sinistres { get; set; }
        public ICollection<DemandeAssurance> DemandeAssurances { get; set; }
        public ICollection<Police> Polices { get; set; }
        public ICollection<Reglement> Reglements { get; set; }
        // public ICollection<DemandeItem> DemandeItems { get; set;}
        // public ICollection<SinistreItem> SinistreItems { get; set; }

    }
}
