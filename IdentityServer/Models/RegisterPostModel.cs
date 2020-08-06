using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class RegisterPostModel
    {
        [Required]
        [StringLength(15,MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Type { get; set; }
    }
}