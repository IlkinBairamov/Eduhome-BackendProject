using BackendProject.DataAccessLayer;
using BackendProject.Models;
using BackendProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.ViewComponents
{

    public class SubscribeViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public SubscribeViewComponent(AppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var subscribe = await _dbContext.subscribes.SingleOrDefaultAsync();
            return View(new SubscribeViewModel
            {
                user = user,
                subscribe=subscribe
            }); 
        }
    }
}
