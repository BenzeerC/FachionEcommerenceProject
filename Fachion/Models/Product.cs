﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Fachion.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Category name")]
        public int Cid { get; set; }

        [Display(Name = "Category name")]
        public string Cname { get; set; }
        [NotMapped]
        public int Qty { get; set; }
        [NotMapped]
        public int CartId { get; set; }
    }
}
