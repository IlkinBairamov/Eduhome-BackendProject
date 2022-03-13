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

    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BlogController> _logger;

        public BlogController(AppDbContext dbContext, ILogger<BlogController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult>  Index(int page = 1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_dbContext.Blogs.Count() / 9);
            ViewBag.CurrentPage = page;

            var blogs = await _dbContext.Blogs.Where(x=>x.IsDeleted==false).Skip((page - 1) * 9).Take(9).ToListAsync();
            return View(blogs);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            var blogs = await _dbContext.Blogs.Where(x=>x.IsDeleted==false).FirstOrDefaultAsync();
            return View(blogs);
        }
        public async Task<IActionResult> SelectCategory(int? id)
        {
            var blogs = await _dbContext.Blogs.Where(x => x.CategoryId == id).ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Search(string searched)
        {
            var blogs = await _dbContext.Blogs
                .Where(x => x.IsDeleted == false && x.Name.ToLower().Trim().Contains(searched.ToLower().Trim()))
                .ToListAsync();

            return PartialView("_SearchedBlogPartial", blogs);
        }

    }
}
