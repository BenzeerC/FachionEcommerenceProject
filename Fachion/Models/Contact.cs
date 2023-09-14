using System.ComponentModel.DataAnnotations;

namespace Fachion.Models
{
    public class Contact
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Contact")]
        public string Phone { get; set; }
        [Required]
        [Display(Name ="Message")]
        public string Message    { get; set; }
    }
}
