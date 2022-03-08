using BackendProject.Areas.AdminPanel.Data;
using BackendProject.Areas.AdminPanel.Data.NewFolder;
using BackendProject.DataAccessLayer;
using BackendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CourseController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _dbContext.Courses.Where(x => x.IsDeleted == false).ToListAsync();
            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            var Categories = await _dbContext.Categories
             .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.ParentCategories = Categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Course course, int CategoryId)
        {
            var Categories = await _dbContext.Categories
            .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.ParentCategories = Categories;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (course == null)
                return BadRequest();

            var isExsistCourse = await _dbContext.Courses.Where(x => x.IsDeleted == false).AnyAsync(x => x.Name.ToLower() == course.Name.ToLower());
            if (isExsistCourse)
            {
                ModelState.AddModelError("Name", "This Course Already Exsist");
                return View();
            }

            if (course.Photo == null)
            {
                ModelState.AddModelError("", "Please choose photo");
                return View();
            }

            if (!course.Photo.isImage())
            {
                ModelState.AddModelError("", "Please choose correct image type");
                return View();
            }

            if (!course.Photo.IsAllowedSize(1))
            {
                ModelState.AddModelError("", "it cant be more than 1mb");
                return View();
            }

            var fileName = await course.Photo.GenerateFile(Constants.ImageFolderPath, "course");

            course.Image = fileName;
            course.CategoryId = CategoryId;
            course.IsDeleted = false;
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
