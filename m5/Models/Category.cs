using System;
using System.ComponentModel.DataAnnotations;

namespace m5.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string Categoryname { get; set; }
    }
}
