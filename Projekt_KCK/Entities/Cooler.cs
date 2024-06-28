using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("Coolers", Schema = "Konfigurator")]
    public class Cooler
    {
        [Key] [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }
        [Required]
        public int FanSize { get; set; }
        [Required]
        public int MaxRPM { get; set; }
    }
}
