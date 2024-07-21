﻿using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class BienDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DaeAcquisation { get; set; }
        public int TypeBienId { get; set; }
        public int StructureId { get; set; }
    }
}
