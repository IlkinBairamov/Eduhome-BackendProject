using BackendProject.Areas.AdminPanel.Data;
using BackendProject.Areas.AdminPanel.Data.NewFolder;
using BackendProject.DataAccessLayer;
using BackendProject.Models;
using BackendProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class EventController : Controller
    {
        private readonly AppDbContext _dbContext;

        public EventController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _dbContext.Events.Include(x=>x.EventTeachers).ThenInclude(x=>x.Teacher).Where(x => x.IsDeleted == false).ToListAsync();
            return View(events);
        }

        public IActionResult Create()
        {
            EventViewModel eventViewModel = new EventViewModel()
            {
               Categories= _dbContext.Categories.Where(x => x.IsDeleted == false).ToList(),
               Teachers= _dbContext.Teachers.Where(x => x.IsDeleted == false).ToList(),
        };
            return View(eventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (eventViewModel == null)
                return BadRequest();

            if (eventViewModel.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please choose photo");
            }

            var isExsistEvent = await _dbContext.Events.Where(x => x.IsDeleted == false).AnyAsync(x => x.Title.ToLower() == eventViewModel.Event.Title.ToLower());
            if (isExsistEvent)
            {
                ModelState.AddModelError("Name", "This Event Already Exsist");
                return View();
            }

            if (eventViewModel.Photo == null)
            {
                ModelState.AddModelError("", "Please choose photo");
                return View();
            }

            if (!eventViewModel.Photo.isImage())
            {
                ModelState.AddModelError("", "Please choose correct image type");
                return View();
            }

            if (!eventViewModel.Photo.IsAllowedSize(1))
            {
                ModelState.AddModelError("", "it cant be more than 1mb");
                return View();
            }

            var fileName = await eventViewModel.Photo.GenerateFile(Constants.ImageFolderPath, "event");

            eventViewModel.Event.Image = fileName;
            eventViewModel.Event.IsDeleted = false;
            eventViewModel.Event.EventTeachers = new List<EventTeacher>();
            foreach (var id in eventViewModel.TeacherId)
            {
                EventTeacher eventTeacher = new EventTeacher()
                {
                    Event = eventViewModel.Event,
                    TeacherId=id
                };
                eventViewModel.Event.EventTeachers.Add(eventTeacher);
            }

            await _dbContext.Events.AddAsync(eventViewModel.Event);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
