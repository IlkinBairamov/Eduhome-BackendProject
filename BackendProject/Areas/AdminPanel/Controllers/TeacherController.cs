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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TeacherController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var teacher = await _dbContext.Teachers.Where(x => x.IsDeleted == false).ToListAsync();
            return View(teacher);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
          
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (teacher == null)
                return BadRequest();

            if (teacher.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please choose photo");
            }

            var isExsistTeacher = await _dbContext.Teachers.Where(x => x.IsDeleted == false).AnyAsync(x => x.Fullanme.ToLower() == teacher.Fullanme.ToLower());
            if (isExsistTeacher)
            {
                ModelState.AddModelError("Name", "This Teacher Already Exsist");
                return View();
            }

            if (teacher.Photo == null)
            {
                ModelState.AddModelError("", "Please choose photo");
                return View();
            }

            if (!teacher.Photo.isImage())
            {
                ModelState.AddModelError("", "Please choose correct image type");
                return View();
            }

            if (!teacher.Photo.IsAllowedSize(1))
            {
                ModelState.AddModelError("", "it cant be more than 1mb");
                return View();
            }

            var fileName = await teacher.Photo.GenerateFile(Constants.ImageFolderPath, "teacher");

            teacher.Image = fileName;
            teacher.IsDeleted = false;
            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var teacher = await _dbContext.Teachers
                .Where(x => x.Id == id && x.IsDeleted == false).Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var teacher = await _dbContext.Teachers.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteTeacher(int? id)
        {
            if (id == null)
                return BadRequest();

            var teacher = await _dbContext.Teachers.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (teacher == null)
                return NotFound();

            string pathDelete = Path.Combine(Constants.ImageFolderPath, "teacher", teacher.Image);
            if (System.IO.File.Exists(pathDelete))
            {
                System.IO.File.Delete(pathDelete);
            }

            teacher.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var teacher = await _dbContext.Teachers.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Teacher teacher)
        {
            

            if (id == null)
                return NotFound();

            if (id != teacher.Id)
                return BadRequest();

            var existTeacher = await _dbContext.Teachers.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existTeacher == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(existTeacher);

            if (teacher.Photo != null)
            {

                if (!teacher.Photo.isImage())
                {
                    ModelState.AddModelError("", "Please choose correct image type");
                    return View();
                }

                if (!teacher.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("", "it cant be more than 1mb");
                    return View();
                }
                string pathDelete = Path.Combine(Constants.ImageFolderPath, "teacher", existTeacher.Image);
                if (System.IO.File.Exists(pathDelete))
                {
                    System.IO.File.Delete(pathDelete);
                }
                var fileName = await teacher.Photo.GenerateFile(Constants.ImageFolderPath, "teacher");
                existTeacher.Image = fileName;
            }

            var isExist = await _dbContext.Teachers
                .AnyAsync(x => x.IsDeleted == false && x.Fullanme.ToLower() == teacher.Fullanme.ToLower() &&
                               x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This teacher already exist.");
                return View();
            }
         
            existTeacher.Fullanme = teacher.Fullanme;
            existTeacher.Position = teacher.Position;
            existTeacher.AboutMe = teacher.AboutMe;
            existTeacher.Degree = teacher.Degree;
            existTeacher.EXPERIENCE = teacher.EXPERIENCE;
            existTeacher.HOBBIES = teacher.HOBBIES;
            existTeacher.FACULTY = teacher.FACULTY;
            existTeacher.Language = teacher.Language;
            existTeacher.TeamLeader = teacher.TeamLeader;
            existTeacher.Design = teacher.Design;
            existTeacher.Innovation = teacher.Innovation;
            existTeacher.Communication = teacher.Communication;
            existTeacher.Mail = teacher.Mail;
            existTeacher.Phone = teacher.Phone;
            existTeacher.Skype = teacher.Skype;
           

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
