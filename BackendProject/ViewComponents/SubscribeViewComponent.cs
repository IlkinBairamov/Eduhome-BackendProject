using BackendProject.DataAccessLayer;
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
        public SubscribeViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subscribe = await _dbContext.subscribes.SingleOrDefaultAsync();
            return View(subscribe);
        }
    }
}
