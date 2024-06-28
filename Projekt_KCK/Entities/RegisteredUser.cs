using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_KCK.Entities
{
    [Table("RegisteredUser", Schema = "Konfigurator")]
    public class RegisteredUser
    {
        [Key]
        [Required]
        public int Id { get; set; }

       // [Required]
       // public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
