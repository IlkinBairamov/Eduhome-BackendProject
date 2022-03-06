using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [Required]
        public string Fullanme { get; set; }

        [Required]
        public string Position { get; set; }

        [StringLength(300)]
        public string FacebookUrl { get; set; } = "https://www.Facebook.com/";

        [StringLength(300)]
        public string PinterestUrl { get; set; } = "https://www.pinterest.com/";

        [StringLength(300)]
        public string LinkedinUrl { get; set; } = "https://www.linkedin.com/";

        [StringLength(300)]
        public string TwitterUrl { get; set; } = "https://www.twitter.com/";

        [StringLength(500)]
        public string AboutMe { get; set; }

        [StringLength(200)]
        public string Degree { get; set; }

        [StringLength(200)]
        public string EXPERIENCE { get; set; }

        [StringLength(200)]
        public string HOBBIES { get; set; }

        [StringLength(200)]
        public string FACULTY { get; set; }

        [Required]
        [StringLength(200)]
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }

        [Required]
        public int Language { get; set; }

        [Required]
        public int TeamLeader { get; set; }

        [Required]
        public int Development { get; set; }

        [Required]
        public int Design { get; set; } 

        [Required]
        public int Innovation { get; set; }

        [Required]
        public int Communication { get; set; }

        public ICollection<EventTeacher> EventTeachers { get; set; }
            
    }
}
