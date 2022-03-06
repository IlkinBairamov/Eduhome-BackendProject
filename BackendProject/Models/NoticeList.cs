using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class NoticeList
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime Time { get; set; }  
    }
}
