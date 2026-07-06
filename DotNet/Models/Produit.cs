using System.ComponentModel.DataAnnotations;

namespace appTest.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public int Prix { get; set; }
        [Required]
        public string? Nom { get; set; }
        public int Quantite { get; set; }
    }
}
