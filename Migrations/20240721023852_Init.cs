using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assurance_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assureurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assureurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompteBancaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteBancaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemandeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeclaration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontantExpertise = table.Column<float>(type: "real", nullable: false),
                    MontantIdemniser = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NatureContrats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureContrats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilaiges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilaiges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuittancePrimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuittancePrimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SinistreItemNatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinistreItemNatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Situations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeBiens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DureeVie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBiens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeSinistres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSinistres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTransports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTransports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEffet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSignature = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exercice = table.Column<float>(type: "real", nullable: false),
                    NatureContratId = table.Column<int>(type: "int", nullable: false),
                    QuittancePrimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrats_NatureContrats_NatureContratId",
                        column: x => x.NatureContratId,
                        principalTable: "NatureContrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrats_QuittancePrimes_QuittancePrimeId",
                        column: x => x.QuittancePrimeId,
                        principalTable: "QuittancePrimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnes_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaeAcquisation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeBienId = table.Column<int>(type: "int", nullable: false),
                    StructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biens_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Biens_TypeBiens_TypeBienId",
                        column: x => x.TypeBienId,
                        principalTable: "TypeBiens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marchandises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTransportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marchandises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marchandises_TypeTransports_TypeTransportId",
                        column: x => x.TypeTransportId,
                        principalTable: "TypeTransports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comptes_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandeAssurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEffet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DemandeTypeId = table.Column<int>(type: "int", nullable: false),
                    QuittancePrimeId = table.Column<int>(type: "int", nullable: false),
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeAssurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeAssurances_DemandeTypes_DemandeTypeId",
                        column: x => x.DemandeTypeId,
                        principalTable: "DemandeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandeAssurances_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandeAssurances_QuittancePrimes_QuittancePrimeId",
                        column: x => x.QuittancePrimeId,
                        principalTable: "QuittancePrimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reglements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRemise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SituationId = table.Column<int>(type: "int", nullable: false),
                    CompteBancaireId = table.Column<int>(type: "int", nullable: false),
                    DevisId = table.Column<int>(type: "int", nullable: false),
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reglements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reglements_CompteBancaires_CompteBancaireId",
                        column: x => x.CompteBancaireId,
                        principalTable: "CompteBancaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reglements_Devises_DevisId",
                        column: x => x.DevisId,
                        principalTable: "Devises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reglements_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reglements_Situations_SituationId",
                        column: x => x.SituationId,
                        principalTable: "Situations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sinistres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantExpertise = table.Column<float>(type: "real", nullable: false),
                    MontantIndemniser = table.Column<float>(type: "real", nullable: false),
                    DateSinistre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegatMateriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lieux = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeSinistreId = table.Column<int>(type: "int", nullable: false),
                    SituationId = table.Column<int>(type: "int", nullable: false),
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinistres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinistres_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sinistres_Situations_SituationId",
                        column: x => x.SituationId,
                        principalTable: "Situations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sinistres_TypeSinistres_TypeSinistreId",
                        column: x => x.TypeSinistreId,
                        principalTable: "TypeSinistres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEffet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Origine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateExpedition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomNavire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomChauffeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomCompanie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdZone = table.Column<int>(type: "int", nullable: false),
                    BienId = table.Column<int>(type: "int", nullable: false),
                    MarchandseId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeItems_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DemandeItems_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandeItems_Marchandises_MarchandseId",
                        column: x => x.MarchandseId,
                        principalTable: "Marchandises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemMarchandises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarchandiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMarchandises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMarchandises_Marchandises_MarchandiseId",
                        column: x => x.MarchandiseId,
                        principalTable: "Marchandises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonneId = table.Column<int>(type: "int", nullable: false),
                    AssureurId = table.Column<int>(type: "int", nullable: false),
                    ContratId = table.Column<int>(type: "int", nullable: false),
                    MarchandiseId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TypeBienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polices_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polices_Assureurs_AssureurId",
                        column: x => x.AssureurId,
                        principalTable: "Assureurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polices_Contrats_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polices_Marchandises_MarchandiseId",
                        column: x => x.MarchandiseId,
                        principalTable: "Marchandises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polices_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polices_TypeBiens_TypeBienId",
                        column: x => x.TypeBienId,
                        principalTable: "TypeBiens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivilaigeComptes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivilaigeId = table.Column<int>(type: "int", nullable: false),
                    CompteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilaigeComptes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivilaigeComptes_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivilaigeComptes_Privilaiges_PrivilaigeId",
                        column: x => x.PrivilaigeId,
                        principalTable: "Privilaiges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DossierSinistres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontantAssurance = table.Column<double>(type: "float", nullable: false),
                    MontantSinistre = table.Column<double>(type: "float", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinistreId = table.Column<int>(type: "int", nullable: false),
                    DossierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierSinistres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierSinistres_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DossierSinistres_Sinistres_SinistreId",
                        column: x => x.SinistreId,
                        principalTable: "Sinistres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PieceJointes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinistreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceJointes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PieceJointes_Sinistres_SinistreId",
                        column: x => x.SinistreId,
                        principalTable: "Sinistres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinistreItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    SinistreItemNatureId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    BienId = table.Column<int>(type: "int", nullable: false),
                    PoliceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinistreItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinistreItems_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinistreItems_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinistreItems_Polices_PoliceId",
                        column: x => x.PoliceId,
                        principalTable: "Polices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinistreItems_SinistreItemNatures_SinistreItemNatureId",
                        column: x => x.SinistreItemNatureId,
                        principalTable: "SinistreItemNatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quittances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<float>(type: "real", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSignature = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DevisId = table.Column<int>(type: "int", nullable: false),
                    DossierSinistreId = table.Column<int>(type: "int", nullable: false),
                    AssureurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quittances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quittances_Assureurs_AssureurId",
                        column: x => x.AssureurId,
                        principalTable: "Assureurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quittances_Devises_DevisId",
                        column: x => x.DevisId,
                        principalTable: "Devises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quittances_DossierSinistres_DossierSinistreId",
                        column: x => x.DossierSinistreId,
                        principalTable: "DossierSinistres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biens_StructureId",
                table: "Biens",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_TypeBienId",
                table: "Biens",
                column: "TypeBienId");

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_PersonneId",
                table: "Comptes",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_NatureContratId",
                table: "Contrats",
                column: "NatureContratId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_QuittancePrimeId",
                table: "Contrats",
                column: "QuittancePrimeId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeAssurances_DemandeTypeId",
                table: "DemandeAssurances",
                column: "DemandeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeAssurances_PersonneId",
                table: "DemandeAssurances",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeAssurances_QuittancePrimeId",
                table: "DemandeAssurances",
                column: "QuittancePrimeId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeItems_ArticleId",
                table: "DemandeItems",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeItems_BienId",
                table: "DemandeItems",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeItems_MarchandseId",
                table: "DemandeItems",
                column: "MarchandseId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierSinistres_DossierId",
                table: "DossierSinistres",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierSinistres_SinistreId",
                table: "DossierSinistres",
                column: "SinistreId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMarchandises_MarchandiseId",
                table: "ItemMarchandises",
                column: "MarchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Marchandises_TypeTransportId",
                table: "Marchandises",
                column: "TypeTransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_StructureId",
                table: "Personnes",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceJointes_SinistreId",
                table: "PieceJointes",
                column: "SinistreId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_ArticleId",
                table: "Polices",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_AssureurId",
                table: "Polices",
                column: "AssureurId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_ContratId",
                table: "Polices",
                column: "ContratId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_MarchandiseId",
                table: "Polices",
                column: "MarchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_PersonneId",
                table: "Polices",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Polices_TypeBienId",
                table: "Polices",
                column: "TypeBienId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivilaigeComptes_CompteId",
                table: "PrivilaigeComptes",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivilaigeComptes_PrivilaigeId",
                table: "PrivilaigeComptes",
                column: "PrivilaigeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quittances_AssureurId",
                table: "Quittances",
                column: "AssureurId");

            migrationBuilder.CreateIndex(
                name: "IX_Quittances_DevisId",
                table: "Quittances",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_Quittances_DossierSinistreId",
                table: "Quittances",
                column: "DossierSinistreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglements_CompteBancaireId",
                table: "Reglements",
                column: "CompteBancaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglements_DevisId",
                table: "Reglements",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglements_PersonneId",
                table: "Reglements",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglements_SituationId",
                table: "Reglements",
                column: "SituationId");

            migrationBuilder.CreateIndex(
                name: "IX_SinistreItems_ArticleId",
                table: "SinistreItems",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SinistreItems_BienId",
                table: "SinistreItems",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_SinistreItems_PoliceId",
                table: "SinistreItems",
                column: "PoliceId");

            migrationBuilder.CreateIndex(
                name: "IX_SinistreItems_SinistreItemNatureId",
                table: "SinistreItems",
                column: "SinistreItemNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinistres_PersonneId",
                table: "Sinistres",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinistres_SituationId",
                table: "Sinistres",
                column: "SituationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinistres_TypeSinistreId",
                table: "Sinistres",
                column: "TypeSinistreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandeAssurances");

            migrationBuilder.DropTable(
                name: "DemandeItems");

            migrationBuilder.DropTable(
                name: "ItemMarchandises");

            migrationBuilder.DropTable(
                name: "PieceJointes");

            migrationBuilder.DropTable(
                name: "PrivilaigeComptes");

            migrationBuilder.DropTable(
                name: "Quittances");

            migrationBuilder.DropTable(
                name: "Reglements");

            migrationBuilder.DropTable(
                name: "SinistreItems");

            migrationBuilder.DropTable(
                name: "DemandeTypes");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "Privilaiges");

            migrationBuilder.DropTable(
                name: "DossierSinistres");

            migrationBuilder.DropTable(
                name: "CompteBancaires");

            migrationBuilder.DropTable(
                name: "Devises");

            migrationBuilder.DropTable(
                name: "Biens");

            migrationBuilder.DropTable(
                name: "Polices");

            migrationBuilder.DropTable(
                name: "SinistreItemNatures");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Sinistres");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Assureurs");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Marchandises");

            migrationBuilder.DropTable(
                name: "TypeBiens");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Situations");

            migrationBuilder.DropTable(
                name: "TypeSinistres");

            migrationBuilder.DropTable(
                name: "NatureContrats");

            migrationBuilder.DropTable(
                name: "QuittancePrimes");

            migrationBuilder.DropTable(
                name: "TypeTransports");

            migrationBuilder.DropTable(
                name: "Structures");
        }
    }
}
