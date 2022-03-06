using BackendProject.DataAccessLayer;
using BackendProject.Models;
using BackendProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult>  Index()
        {
            var sliders =  await _dbContext.Sliders.ToListAsync();
            var about =  await _dbContext.About.SingleOrDefaultAsync();
            var notice = await _dbContext.Notice.SingleOrDefaultAsync();
            var noticeList = await _dbContext.NoticeList.ToListAsync();
            var testimonialsList = await _dbContext.testimonials.ToListAsync();
            var subscribe = await _dbContext.subscribes.SingleOrDefaultAsync();
            var course = await _dbContext.Courses.Take(3).ToListAsync();
            var courseTitle = await _dbContext.CourseTitles.SingleOrDefaultAsync();
            var events = await _dbContext.Events.Take(4).ToListAsync();

            return View(new HomeViewModel
            {
                Sliders=sliders,
                About=about,
                Notice=notice,
                NoticeList=noticeList,
                Testimonials=testimonialsList,
                Subscribe=subscribe,
                Courses=course,
                CourseTitle=courseTitle,
                Events=events
                
            });
        }


     
    }
}
