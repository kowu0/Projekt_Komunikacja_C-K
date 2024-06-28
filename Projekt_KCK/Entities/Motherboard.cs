using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("Motherboards", Schema = "Konfigurator")]
    public class Motherboard
    {
        [Key] [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormFactor { get; set; }
        [Required]
        [MaxLength(100)]
        public string Socket { get; set; }
        [Required]
        public int RAMSlots { get; set; }
        [Required]
        [MaxLength(100)]
        public string Chipset { get; set; }
    }
}
