using BackendProject.DataAccessLayer;
using BackendProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {

        private readonly AppDbContext _dbContext;
        public SidebarViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var category = await _dbContext.Categories.ToListAsync();
            var blog = await _dbContext.Blogs.OrderByDescending(x=>x.Created).Take(count).ToListAsync();
            var tag = await _dbContext.Tags.ToListAsync();

            return View(new SidebarViewModel
            { 
                Blogs=blog,
                Categories=category, 
                Tags=tag
            });
        }

        
    }
}
