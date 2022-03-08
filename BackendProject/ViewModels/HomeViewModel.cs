using BackendProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }   
        public About About { get; set; }        
        public Notice Notice { get; set; }
        public List<NoticeList> NoticeList { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public Subscribe Subscribe { get; set; }
        public List<Course> Courses { get; set; }   
        public CourseTitle CourseTitle { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }

            

    }
}
