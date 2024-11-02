using System.ComponentModel.DataAnnotations;
namespace DTO
{
    public class LoginDTO
    {
        [Required]
        public string AccountEmail { get; set; }

        [Required]
        public string AccountPassword { get; set; }
    }
}
