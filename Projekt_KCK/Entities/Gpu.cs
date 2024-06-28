using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("Gpus", Schema = "Konfigurator")]
    public class Gpu
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int MemorySize { get; set; }
        [Required]
        [MaxLength(100)]
        public string MemoryType { get; set; }
        [Required]
        public float CoreClock { get; set; }
    }
}
