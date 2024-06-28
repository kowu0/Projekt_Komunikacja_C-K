using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("Configurator", Schema = "Konfigurator")]
    public class Configurator
    {
        [Key] [Required]
        public int Id { get; set; }
        [Required]
        public int CpuId { get; set; }
        [Required]
        public int MotherboardId { get; set; }
        [Required]
        public int RamId { get; set; }
        [Required]
        public int GpuId { get; set; }
        [Required]
        public int CoolerId { get; set; }
        [Required]
        public int CaseId { get; set; }
        [Required]
        public int DiskId { get; set; }
        
    }
}
