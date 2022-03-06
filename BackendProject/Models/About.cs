using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Subtitle { get; set; }
        [Required]
        [StringLength(500)]
        public string Subtitle2 { get; set; }
        [Required]
        public string Image { get; set; }       
    }
}
