using Assurance_Backend.DTOs;
using Assurance_Backend.Models;
using AutoMapper;

namespace Assurance_Backend
{
    public class Automapper:Profile
    {
        public Automapper()
        {
            CreateMap<Article,ArticleDto>().ReverseMap();
            CreateMap<Assureur,AssureurDto>().ReverseMap();
            CreateMap<Bien,BienDto>().ReverseMap();
            CreateMap<Compte,CompteDto>().ReverseMap();
            CreateMap<CompteBancaire,CompteBancaireDto>().ReverseMap();
            CreateMap<Contrat,ContratDto>().ReverseMap();
            CreateMap<DemandeAssurance,DemandeAssuranceDto>().ReverseMap();
            CreateMap<DemandeItem,DemandeItemDto>().ReverseMap();
            CreateMap<DemandeType,DemandeTypeDto>().ReverseMap();
            CreateMap<Devis,DevisDto>().ReverseMap();
            CreateMap<Dossier,DossierDto>().ReverseMap();
            CreateMap<DossierSinistre,DossierSinistreDto>().ReverseMap();
            CreateMap<ItemMarchandise,ItemMarchandiseDto>().ReverseMap();
            CreateMap<Marchandise, MarchandiseDto>().ReverseMap();
            CreateMap<NatureContrat,NatureContratDto>().ReverseMap();
            CreateMap<Personne,PersonneDto>().ReverseMap();
            CreateMap<PieceJointe,PieceJointeDto>().ReverseMap();
            CreateMap<Police,PoliceDto>().ReverseMap();
            CreateMap<Privilaige,PrivilaigeDto>().ReverseMap();
            CreateMap<PrivilaigeCompte,PrivilaigeCompteDto>().ReverseMap();
            CreateMap<Quittance, QuittanceDto>().ReverseMap();
            CreateMap<QuittancePrime, QuittancePrimeDto>().ReverseMap();
            CreateMap<Reglement, ReglementDto>().ReverseMap();
            CreateMap<Sinistre, SinistreDto>().ReverseMap();
            CreateMap<SinistreItem, SinistreItemDto>().ReverseMap();
            CreateMap<SinistreItemNature, SinistreItemNatureDto>().ReverseMap();
            CreateMap<Situation,SituationDto>().ReverseMap();
            CreateMap<Structure, StructureDto>().ReverseMap();
            CreateMap<TypeBien, TypeBienDto>().ReverseMap();
            CreateMap<TypeSinistre,TypeSinistreDto>().ReverseMap();
            CreateMap<TypeTransport, TypeTransportDto>().ReverseMap();
            CreateMap<TypeReglement,TypeReglementDto>().ReverseMap();





        }
    }
}
