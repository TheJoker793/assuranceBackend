using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class PoliceDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateAjout { get; set; }
        public int PersonneId { get; set; }//ok
        public int AssureurId { get; set; }//ok
        public int ContratId { get; set; }//ok
        public int MarchandiseId { get; set; }//ok
        public int ArticleId { get; set; }//ok
        public int TypeBienId { get; set; }
    }
}
