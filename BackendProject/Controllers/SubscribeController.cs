using BackendProject.DataAccessLayer;
using BackendProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public SubscribeController(AppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> Subscribe(string id)
        {
            if (id == null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(id);
            if (user==null)
            {
                return BadRequest();
            }
            if (user.Subscribe)
            {
              user.Subscribe = false;
            }
            else
            {
                user.Subscribe = true;
            }
            await _userManager.UpdateAsync(user);

            return PartialView("_SubscribePartial", user);
        }
    }
}
