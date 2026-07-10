using System.ComponentModel.DataAnnotations;

namespace appTest.Models
{
    public class Fournisseurs
    {
        public int Id { get; set; }
        [Required]
        public string? Nom { get; set; }
    }
}