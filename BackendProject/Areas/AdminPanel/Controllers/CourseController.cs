using BackendProject.Areas.AdminPanel.Data;
using BackendProject.Areas.AdminPanel.Data.NewFolder;
using BackendProject.DataAccessLayer;
using BackendProject.Models;
using FrontToBack.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public CourseController(AppDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var courses = new List<Course>();
            if (User.IsInRole(RoleConstants.ModeratorRole))
            {
                var moderator = await _userManager.FindByNameAsync(User.Identity.Name);
                courses = await _dbContext.Courses.Where(x => x.IsDeleted == false && x.UserId==moderator.Id).ToListAsync();
                return View(courses);

            }
           
          courses = await _dbContext.Courses.Where(x => x.IsDeleted == false).ToListAsync();
            return View(courses);
        }
        [Authorize(RoleConstants.AdminRole)]
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

            if (course.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please choose photo");
            }

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

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var course = await _dbContext.Courses.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCourse(int? id)
        {
            if (id == null)
                return BadRequest();

            var course = await _dbContext.Courses.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (course == null)
                return NotFound();

            string pathDelete = Path.Combine(Constants.ImageFolderPath, "course", course.Image);
            if (System.IO.File.Exists(pathDelete))
            {
                System.IO.File.Delete(pathDelete);
            }

            course.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var course = await _dbContext.Courses
                .Where(x => x.Id == id && x.IsDeleted == false).Include(x => x.Category).Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (course == null)
                return NotFound();

            return View(course);
        }
       
        public async Task<IActionResult> Update(int? id)
        {
            var Categories = await _dbContext.Categories
              .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = Categories;

            if (id == null)
                return NotFound();

            var course = await _dbContext.Courses.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Course course, int categoryId)
        {
            var Categories = await _dbContext.Categories
            .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = Categories;

            if (id == null)
                return NotFound();

            if (id != course.Id)
                return BadRequest();

            var existcourse = await _dbContext.Courses.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existcourse == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(existcourse);

            if (course.Photo != null)
            {

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
                string pathDelete = Path.Combine(Constants.ImageFolderPath, "course", existcourse.Image);
                if (System.IO.File.Exists(pathDelete))
                {
                    System.IO.File.Delete(pathDelete);
                }
                var fileName = await course.Photo.GenerateFile(Constants.ImageFolderPath, "course");
                existcourse.Image = fileName;
            }

            var isExist = await _dbContext.Courses
                .AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == course.Name.ToLower() &&
                               x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This course name already exist.");
                return View();
            }
            existcourse.CategoryId = categoryId;
            existcourse.Text = course.Text;
            existcourse.Name = course.Name;
            existcourse.AboutCourse = course.AboutCourse;
            existcourse.HowToApply = course.HowToApply;
            existcourse.Certification = course.Certification;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
