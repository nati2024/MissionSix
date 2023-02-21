using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MissionSix.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }
        public bool Edited { get; set; }
        [Required(ErrorMessage ="Hey! Should I watch this or what?")]
        public string Rating { get; set; }
        public string Lent { get; set; }


        //Build Foreign Key Relationship

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
