using Assurance_Backend.Models;

namespace Assurance_Backend.DTOs
{
    public class SinistreItemDto
    {
        public int Id { get; set; }
        public DateTime DateAjout { get; set; }
        public string Description { get; set; }
        public int Quantite { get; set; }
        public float Prix { get; set; }
        public int SinistreItemNatureId { get; set; }
        /*Attributs snistre item nature*/
        public string? LibelleSinistreItemNature {  get; set; }
        
        public int ArticleId { get; set; }
        /*Attributs article*/
        public string? LibelleArticle {  get; set; }
        public string? ReferenceArticle { get; set; }
        public float? PrixArticle {  get; set; }
        
        public int BienId { get; set; }
        /*Attributs bien*/

        public string? CodeBien {  get; set; }

    }
}
