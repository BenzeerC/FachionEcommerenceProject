using System.ComponentModel.DataAnnotations;

namespace Fachion.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Enter Full Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = " Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = " Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Contact")]
        public string Phone { get; set; }

        public int RoleId { get; set; }
    }
}
