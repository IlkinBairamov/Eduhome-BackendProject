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
    public class EventController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EventController> _logger;

        public EventController(AppDbContext dbContext, ILogger<EventController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var events = _dbContext.Events.ToList();
            return View(events);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var existEvent = await _dbContext.Events.Include(x => x.EventTeachers).ThenInclude(x => x.Teacher).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            return View(existEvent);
        }


        public async Task<IActionResult> SelectCategory(int? id)
        {
            var events = await _dbContext.Events.Where(x => x.CategoryId == id).ToListAsync();
            return View(events);
        }
    }
}
