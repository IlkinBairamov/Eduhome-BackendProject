using BackendProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
           public DbSet<Bio> Bios { get; set; }
           public DbSet<Slider> Sliders { get; set; }   
           public DbSet<About> About { get; set; }     
           public DbSet<Notice> Notice { get; set; }     
           public DbSet<NoticeList> NoticeList { get; set; }       
           public DbSet<Testimonial> testimonials { get; set; }          
           public DbSet<Subscribe> subscribes { get; set; }          
           public DbSet<Category> Categories { get; set; }             
           public DbSet<Course> Courses { get; set; }                
           public DbSet<CourseTitle> CourseTitles { get; set; }                
           public DbSet<Teacher> Teachers { get; set; }                
           public DbSet<Event> Events { get; set; }                
           public DbSet<EventTeacher> EventTeachers { get; set; }                 
           public DbSet<Blog> Blogs { get; set; }                   
           public DbSet<Tag> Tags { get; set; }                   
    }   
}
