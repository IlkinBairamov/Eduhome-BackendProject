using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class EventTeacher
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsDelete { get; set; }
    }
}
