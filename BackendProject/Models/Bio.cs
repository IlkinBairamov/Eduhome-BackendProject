using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Bio
    {
        public int Id { get; set; }

        public string Logo { get; set; }

        [StringLength(300)]
        public string FacebookUrl { get; set; }

        [StringLength(300)]
        public string PinterestUrl { get; set; }

        [StringLength(300)]
        public string LinkedinUrl { get; set; }

        [StringLength(300)]
        public string TwitterUrl { get; set; }
    }
}
