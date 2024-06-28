using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("PowerSupplies", Schema = "Konfigurator")]
    public class Psu
    {
        [Key] [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Power { get; set; }
        [Required]
        [MaxLength(100)]
        public string EfficiencyRating { get; set; }       
        [Required]
        [MaxLength(100)]
        public string FormFactor { get; set; }
    }
}
