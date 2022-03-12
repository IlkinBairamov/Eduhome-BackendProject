using BackendProject.DataAccessLayer;
using BackendProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SearchController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Search(string searched)
        {
            var blogs = await _dbContext.Blogs
                .Where(x => x.IsDeleted == false && x.Name.ToLower().Trim().Contains(searched.ToLower().Trim()))
                .ToListAsync();

            var courses = await _dbContext.Courses
              .Where(x => x.IsDeleted == false && x.Name.ToLower().Trim().Contains(searched.ToLower().Trim()))
              .ToListAsync();

            var events = await _dbContext.Events
             .Where(x => x.IsDeleted == false && x.Title.ToLower().Trim().Contains(searched.ToLower().Trim()))
             .ToListAsync();

            var teachers = await _dbContext.Teachers
               .Where(x => x.IsDeleted == false && x.Fullanme.ToLower().Trim().Contains(searched.ToLower().Trim()))
               .ToListAsync();

            return PartialView("_GlobalSearch", new SearchViewModel { 
                Blogs=blogs,
                Courses=courses,
                Events=events,
                Teachers=teachers
            });
        }
    }
}
