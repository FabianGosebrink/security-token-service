using System.ComponentModel.DataAnnotations;

namespace StsServerIdentity.Models
{
    public class AdminViewModel
    {
        [Required]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
