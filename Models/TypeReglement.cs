﻿namespace Assurance_Backend.Models
{
    public class TypeReglement
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ICollection<Reglement> Reglements { get; set; }
    }
}