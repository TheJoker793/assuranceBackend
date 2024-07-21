﻿using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class QuittanceDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public float Montant { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateSignature { get; set; }
        public int DevisId { get; set; }
        public int DossierSinistreId { get; set; }
        public int AssureurId { get; set; }
    }
}