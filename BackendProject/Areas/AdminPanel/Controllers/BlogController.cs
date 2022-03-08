using BackendProject.Areas.AdminPanel.Data;
using BackendProject.Areas.AdminPanel.Data.NewFolder;
using BackendProject.DataAccessLayer;
using BackendProject.Models;
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
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _dbContext.Blogs.Where(x => x.IsDeleted == false).ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult>  Create()
        {
            var Categories = await _dbContext.Categories
              .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.ParentCategories = Categories;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Blog blog,int CategoryId)
        {
            var Categories = await _dbContext.Categories
            .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.ParentCategories = Categories;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (blog == null)
                return BadRequest();
            
            var isExsistCategory = await _dbContext.Blogs.Where(x=>x.IsDeleted==false).AnyAsync(x => x.Name.ToLower() == blog.Name.ToLower());    
            if (isExsistCategory)
            {
                ModelState.AddModelError("Name", "This Category Already Exsist");
                return View();
            }

            if (blog.Photo == null)
            {
                ModelState.AddModelError("", "Shekil sechin.");
                return View();
            }

            if (!blog.Photo.isImage())
            {
                ModelState.AddModelError("", "Duzgun shekil formati sechin.");
                return View();
            }

            if (!blog.Photo.IsAllowedSize(1))
            {
                ModelState.AddModelError("", "1Mb-dan artiq ola bilmez.");
                return View();
            }

            var fileName = await blog.Photo.GenerateFile(Constants.ImageFolderPath,"blog");

            blog.Image = fileName;
            blog.CategoryId = CategoryId;
            blog.IsDeleted = false;
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var blog = await _dbContext.Blogs.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (blog == null)
                return NotFound();

           
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(int? id)
        {
            if (id == null)
                return BadRequest();

            var blog = await _dbContext.Blogs.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (blog == null)
                return NotFound();

            string pathDelete = Path.Combine(Constants.ImageFolderPath, "blog", blog.Image);
            if (System.IO.File.Exists(pathDelete))
            {
                System.IO.File.Delete(pathDelete);
            }

            _dbContext.Blogs.Remove(blog);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var blog = await _dbContext.Blogs
                .Where(x => x.Id == id && x.IsDeleted == false).Include(x=>x.Category).Where(x=>x.IsDeleted==false)
                .FirstOrDefaultAsync();
            if (blog == null)
                return NotFound();

            return View(blog);
        }

        public async Task<IActionResult> Update(int? id)
        {
            var Categories = await _dbContext.Categories
              .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = Categories;

            if (id == null)
                return NotFound();

            var blog = await _dbContext.Blogs.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog,int categoryId) 
        {
            var Categories = await _dbContext.Categories
            .Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = Categories;

            if (id == null)
                return NotFound();

            if (id != blog.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View();

            var existblog = await _dbContext.Blogs.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existblog == null)
                return NotFound();

            if (blog.Photo != null)
            {

                if (!blog.Photo.isImage())
                {
                    ModelState.AddModelError("", "Please choose correct image type");
                    return View();
                }

                if (!blog.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("", "it cant be more than 1mb");
                    return View();
                }
                string pathDelete = Path.Combine(Constants.ImageFolderPath,"blog", existblog.Image);
                if (System.IO.File.Exists(pathDelete))
                {
                    System.IO.File.Delete(pathDelete);
                }
                var fileName = await blog.Photo.GenerateFile(Constants.ImageFolderPath,"blog");
                existblog.Image = fileName;
            }

            var isExist = await _dbContext.Blogs
                .AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == blog.Name.ToLower() &&
                               x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This blog name already exist.");
                return View();
            }
            existblog.CategoryId = categoryId;
            existblog = blog;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
