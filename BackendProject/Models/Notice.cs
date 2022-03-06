using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Notice
    {
        public int Id { get; set; }
        [Required]
        public string LeftTitle { get; set; }
        [Required]
        [StringLength(300)]
        public string RightTitle { get; set; }  
        [Required]
        [StringLength(300)]
        public string VideoUrl { get; set; }    
    }
}
