using BackendProject.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CourseController> _logger;   

        public CourseController(AppDbContext dbContext, ILogger<CourseController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _dbContext.Courses.ToListAsync();
            return View(courses);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var courses = await _dbContext.Courses.Where(x=>x.IsDeleted==false).FirstOrDefaultAsync();
            return View(courses);
        }

        public async Task<IActionResult> SelectCategory(int? id)
        {
            var courses = await _dbContext.Courses.Where(x => x.CategoryId == id).ToListAsync();
            return View(courses);
        }
    }
}
