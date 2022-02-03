using System;
using System.ComponentModel.DataAnnotations;

namespace m5.Models
{
    public class FormResponse
    {
        [Key]
        [Required]
        public int FormID { get; set; }

        [Required(ErrorMessage ="Enter the movie title")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Enter the year of the movie published")]
        public string Year { get; set; }

        [Required(ErrorMessage ="Enter the name of the director")]
        public string Director { get; set; }

        [Required(ErrorMessage ="Enter the movie rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //Build Foreign Key Relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
