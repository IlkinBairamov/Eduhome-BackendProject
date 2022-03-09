using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }    
        public string Time { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } 
        public ICollection<EventTeacher> EventTeachers { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
    }
}
