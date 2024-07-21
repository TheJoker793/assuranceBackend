using Assurance_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Assurance_Backend
{
    public class AssuranceDbContext(DbContextOptions<AssuranceDbContext>options):DbContext(options)
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Assureur> Assureurs { get; set; }
        public DbSet<Bien> Biens { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<CompteBancaire> CompteBancaires { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<DemandeAssurance> DemandeAssurances { get; set; }
        public DbSet<DemandeItem> DemandeItems { get; set; }
        public DbSet<DemandeType> DemandeTypes { get; set; }
        public DbSet<Devis> Devises { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet <DossierSinistre> DossierSinistres { get; set; }
        public DbSet<ItemMarchandise> ItemMarchandises { get; set; }
        public DbSet<Marchandise> Marchandises { get; set; }
        public DbSet<NatureContrat> NatureContrats { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<PieceJointe> PieceJointes { get; set; }
        public DbSet<Police> Polices { get; set; }
        public DbSet<Privilaige> Privilaiges { get; set; }
        public DbSet<PrivilaigeCompte> PrivilaigeComptes { get; set; }
        public DbSet<Quittance> Quittances { get; set; }
        public DbSet<QuittancePrime> QuittancePrimes { get; set; }
        public DbSet<Reglement> Reglements { get; set; }
        public DbSet<SinistreItem> SinistreItems { get; set; }
        public DbSet <SinistreItemNature> SinistreItemNatures { get; set; }
        public DbSet<Sinistre> Sinistres { get; set; }

        public DbSet <Situation> Situations { get; set; }
        public DbSet <Structure> Structures { get; set; }
        public DbSet<TypeBien> TypeBiens { get; set; }
        public DbSet<TypeSinistre> TypeSinistres { get; set; }
        public DbSet<TypeTransport> TypeTransports { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bien>()
                 .HasOne(t => t.TypeBien)
                 .WithMany(b => b.Biens)
                 .HasForeignKey(t => t.TypeBienId);
            modelBuilder.Entity<Bien>()
                .HasOne(s => s.Structure)
                .WithMany(b => b.Biens)
                .HasForeignKey(s => s.StructureId);
            
            modelBuilder.Entity<Compte>()
                .HasOne(p=>p.Personne)
                .WithMany(c=>c.Comptes)
                .HasForeignKey(p=>p.PersonneId);

            modelBuilder.Entity<Contrat>()
                .HasOne(n=>n.NatureContrat)
                .WithMany(c=>c.Contrats)
                .HasForeignKey(n=>n.NatureContratId);
            modelBuilder.Entity<Contrat>()
                .HasOne(qp=>qp.QuittancePrime)
                .WithMany(c=>c.Contrats)
                .HasForeignKey(qp=>qp.QuittancePrimeId);

            modelBuilder.Entity<DemandeAssurance>()
                .HasOne(dt => dt.DemandeType)
                .WithMany(da => da.DemandeAssurances)
                .HasForeignKey(dt => dt.DemandeTypeId);
            modelBuilder.Entity<DemandeAssurance>()
                .HasOne(qp => qp.QuittancePrime)
                .WithMany(da => da.DemandeAssurances)
                .HasForeignKey(qp => qp.QuittancePrimeId);
            modelBuilder.Entity<DemandeAssurance>()
                .HasOne(p => p.Personne)
                .WithMany(da => da.DemandeAssurances)
                .HasForeignKey(p => p.PersonneId);

            
            modelBuilder.Entity<DemandeItem>()
                .HasOne(b => b.Bien)
                .WithMany(d => d.DemandeItems)
                .HasForeignKey(b => b.BienId);
            
            modelBuilder.Entity<DemandeItem>()
                .HasOne(m => m.Marchandise)
                .WithMany(d => d.DemandeItems)
                .HasForeignKey(m => m.MarchandseId);

            modelBuilder.Entity<DossierSinistre>()
                .HasOne(s => s.Sinistre)
                .WithMany(d => d.DossiersSinistre)
                .HasForeignKey(s => s.SinistreId);
            modelBuilder.Entity<DossierSinistre>()
                .HasOne(dos => dos.Dossier)
                .WithMany(d => d.DossierSinistres)
                .HasForeignKey(dos => dos.DossierId);

            modelBuilder.Entity<ItemMarchandise>()
                .HasOne(m => m.Marchandise)
                .WithMany(im => im.ItemMarchandises)
                .HasForeignKey(m => m.MarchandiseId);

            modelBuilder.Entity<Marchandise>()
                .HasOne(t => t.TypeTransport)
                .WithMany(m => m.Marchandises)
                .HasForeignKey(t => t.TypeTransportId);
            
            modelBuilder.Entity<Personne>()
                .HasOne(s => s.Structure)
                .WithMany(p => p.Personnes)
                .HasForeignKey(s => s.StructureId);

            modelBuilder.Entity<PieceJointe>()
                .HasOne(s => s.Sinistre)
                .WithMany(p => p.PiecesJointes)
                .HasForeignKey(s => s.SinistreId);

            modelBuilder.Entity<Police>()
                .HasOne(pers => pers.Personne)
                .WithMany(p => p.Polices)
                .HasForeignKey(pers => pers.PersonneId);
            modelBuilder.Entity<Police>()
                .HasOne(a => a.Assureur)
                .WithMany(p => p.Polices)
                .HasForeignKey(a => a.AssureurId);
            modelBuilder.Entity<Police>()
                .HasOne(c => c.Contrat)
                .WithMany(p => p.Polices)
                .HasForeignKey(c => c.ContratId);
            modelBuilder.Entity<Police>()
                .HasOne(m => m.Marchandise)
                .WithMany(p => p.Polices)
                .HasForeignKey(m => m.MarchandiseId);
            modelBuilder.Entity<Police>()
                .HasOne(c => c.Contrat)
                .WithMany(p => p.Polices)
                .HasForeignKey(c => c.ContratId);
            modelBuilder.Entity<Police>()
                .HasOne(a => a.Article)
                .WithMany(p => p.Polices)
                .HasForeignKey(a => a.ArticleId);
            modelBuilder.Entity<Police>()
                .HasOne(t => t.TypeBien)
                .WithMany(p => p.Polices)
                .HasForeignKey(t => t.TypeBienId);
            modelBuilder.Entity<PrivilaigeCompte>()
                .HasOne(p => p.Privilaige)
                .WithMany(pc => pc.PrivilaigeComptes)
                .HasForeignKey(p => p.PrivilaigeId);
            modelBuilder.Entity<PrivilaigeCompte>()
                .HasOne(c => c.Compte)
                .WithMany(pc => pc.PrivilaigeComptes)
                .HasForeignKey(c => c.CompteId);
           
            modelBuilder.Entity<Quittance>()
                .HasOne(d => d.Devis)
                .WithMany(q => q.Quittances)
                .HasForeignKey(d => d.DevisId);
            modelBuilder.Entity<Quittance>()
                .HasOne(ds => ds.DossierSinistre)
                .WithMany(q => q.Quittances)
                .HasForeignKey(ds => ds.DossierSinistreId);
            
            modelBuilder.Entity<Quittance>()
                .HasOne(a => a.Assureur)
                .WithMany(q => q.Quittances)
                .HasForeignKey(a => a.AssureurId);
            modelBuilder.Entity<Reglement>()
                .HasOne(s => s.Situation)
                .WithMany(r => r.Reglements)
                .HasForeignKey(s => s.SituationId);
            modelBuilder.Entity<Reglement>()
                .HasOne(cb => cb.CompteBancaire)
                .WithMany(r=>r.Reglements)
                .HasForeignKey(cb=>cb.CompteBancaireId);
            modelBuilder.Entity<Reglement>()
                .HasOne(d => d.Devis)
                .WithMany(r => r.Reglements)
                .HasForeignKey(d => d.DevisId);
            modelBuilder.Entity<Reglement>()
                .HasOne(p => p.Personne)
                .WithMany(r => r.Reglements)
                .HasForeignKey(p => p.PersonneId);

            modelBuilder.Entity<Sinistre>()
                .HasOne(t => t.TypeSinistre)
                .WithMany(s => s.Sinistres)
                .HasForeignKey(t => t.TypeSinistreId);
            modelBuilder.Entity<Sinistre>()
               .HasOne(st=>st.Situation)
               .WithMany(s => s.Sinistres)
               .HasForeignKey(st=>st.SituationId);
            modelBuilder.Entity<Sinistre>()
               .HasOne(p=>p.Personne)
               .WithMany(s => s.Sinistres)
               .HasForeignKey(p=>p.PersonneId);
           /* modelBuilder.Entity<Sinistre>()
               .HasOne(str => str.Structure)
               .WithMany(s => s.Sinistres)
               .HasForeignKey(str => str.StructureId);
               //.OnDelete(DeleteBehavior.NoAction); // Set ON DELETE NO ACTION
            ;*/


            
            modelBuilder.Entity<SinistreItem>()
               .HasOne(sin => sin.SinistreItemNature)
               .WithMany(si => si.SinistreItems)
               .HasForeignKey(sin => sin.SinistreItemNatureId);
            modelBuilder.Entity<SinistreItem>()
               .HasOne(a => a.Article)
               .WithMany(si => si.SinistreItems)
               .HasForeignKey(a => a.ArticleId);
            modelBuilder.Entity<SinistreItem>()
               .HasOne(b => b.Bien)
               .WithMany(si => si.SinistreItems)
               .HasForeignKey(b => b.BienId);
            

























        }

    }
}
