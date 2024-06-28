using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("Cpus", Schema = "Konfigurator")]
    public class Cpu
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Cores { get; set; }
        [Required]
        public float ClockSpeed { get; set; }
        [Required]
        [MaxLength (100)]
        public string Socket { get; set; }
    }
}
