using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("Cases", Schema = "Konfigurator")]
    public class Case
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        [Required]
        [MaxLength(50)]
        public string FormFactor { get; set; }
        [Required]
        public int MaxGPULength { get; set; }
        [Required]
        public int MaxCPUCoolerHeight { get; set; }
    }
}
