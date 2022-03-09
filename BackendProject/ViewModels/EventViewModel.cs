using BackendProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }    
        public List<Teacher> Teachers { get; set; }      
        public List<Category> Categories { get; set; }
      
        public List<int> TeacherId { get; set; }
        public IFormFile Photo { get; set; }

    }
}
