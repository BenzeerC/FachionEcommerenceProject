using System.ComponentModel.DataAnnotations;

namespace Fachion.Models
{
    public class Category
    {

        [Key]
        public int Cid { get; set; }
        [Required]
        public string Cname { get; set; }
    }
}
