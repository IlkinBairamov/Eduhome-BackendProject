﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Subscribe
    {
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string Title { get; set; }
        [Required]
        [StringLength(400)]
        public string Text { get; set; }
    }
}
