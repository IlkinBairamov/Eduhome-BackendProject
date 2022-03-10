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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CourseController> _logger;

        public TeacherController(AppDbContext dbContext, ILogger<CourseController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult>  Index()
        {
            var teachers = await _dbContext.Teachers.ToListAsync();
            return View(teachers);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var teachers = await _dbContext.Teachers.Where(x => x.IsDeleted == false).FirstOrDefaultAsync();
            return View(teachers);
        }
    }
}
