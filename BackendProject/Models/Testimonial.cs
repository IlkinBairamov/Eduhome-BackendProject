using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
