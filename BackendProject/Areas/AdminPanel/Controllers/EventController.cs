using BackendProject.Areas.AdminPanel.Data;
using BackendProject.Areas.AdminPanel.Data.NewFolder;
using BackendProject.DataAccessLayer;
using BackendProject.Models;
using BackendProject.ViewModels;
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
            eventViewModel.Categories = _dbContext.Categories.Where(x => x.IsDeleted == false).ToList();
            eventViewModel.Teachers = _dbContext.Teachers.Where(x => x.IsDeleted == false).ToList();

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

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var events = await _dbContext.Events
                .Where(x => x.Id == id && x.IsDeleted == false).Include(x => x.Category).Where(x=>x.IsDeleted==false)
                .Include(y=>y.EventTeachers).ThenInclude(y=>y.Teacher)
                .FirstOrDefaultAsync();
            if (events == null)
                return NotFound();

            return View(events);
        }

        public async Task<IActionResult> Deletee(int? id)
        {
            if (id == null)
                return BadRequest();

            var events = await _dbContext.Events.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (events == null)
                return NotFound();

            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Deletee")]
        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (id == null)
                return BadRequest();

            var events = await _dbContext.Events.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (events == null)
                return NotFound();

            string pathDelete = Path.Combine(Constants.ImageFolderPath, "event", events.Image);
            if (System.IO.File.Exists(pathDelete))
            {
                System.IO.File.Delete(pathDelete);
            }

            events.IsDeleted = true;
            var eventTeacher = await _dbContext.EventTeachers.Where(x => x.EventId == id).ToListAsync();
            foreach (var item in eventTeacher)
            {
                item.IsDelete = true;
            }
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            EventViewModel eventViewModel = new EventViewModel()
            {
                Categories = _dbContext.Categories.Where(x => x.IsDeleted == false).ToList(),
                Teachers = _dbContext.Teachers.Where(x => x.IsDeleted == false).ToList(),
                Event = await _dbContext.Events.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync(),
                SelectedTeacher = _dbContext.EventTeachers.Where(x => x.IsDelete == false && x.EventId == id).ToList()

            };
            return View(eventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, EventViewModel eventViewModel)
        {
            eventViewModel.Categories = _dbContext.Categories.Where(x => x.IsDeleted == false).ToList();
            eventViewModel.Teachers = _dbContext.Teachers.Where(x => x.IsDeleted == false).ToList();
            eventViewModel.Event = await _dbContext.Events.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            eventViewModel.SelectedTeacher = _dbContext.EventTeachers.Where(x => x.IsDelete == false && x.EventId == id).ToList();
            if (id == null)
                return NotFound();
            var existEvent = await _dbContext.Events.Where(x => x.IsDeleted == false && x.Id == id).Include(x=>x.EventTeachers).FirstOrDefaultAsync();
            if (id != existEvent.Id)
                return BadRequest();

            var removeTeacher = existEvent.EventTeachers.Where(x => !eventViewModel.TeacherId.Contains(x.Id)).ToList();
            foreach (var item in eventViewModel.TeacherId)
            {
                EventTeacher eventTeacher = new EventTeacher()
                {
                    Event = eventViewModel.Event,
                    TeacherId = item
                };
                eventViewModel.Event.EventTeachers.Add(eventTeacher);
            }
            foreach (var item in removeTeacher)
            {
                _dbContext.EventTeachers.Remove(item);
            };


            if (existEvent == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(eventViewModel);

            if (eventViewModel.Photo != null)
            {

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
                string pathDelete = Path.Combine(Constants.ImageFolderPath, "event", existEvent.Image);
                if (System.IO.File.Exists(pathDelete))
                {
                    System.IO.File.Delete(pathDelete);
                }
                var fileName = await eventViewModel.Photo.GenerateFile(Constants.ImageFolderPath, "event");
                existEvent.Image = fileName;
            }

            var isExist = await _dbContext.Events
                .AnyAsync(x => x.IsDeleted == false && x.Title.ToLower() == eventViewModel.Event.Title.ToLower() &&
                               x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This event already exist.");
                return View();
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
