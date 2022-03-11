using BackendProject.Models;
using BackendProject.ViewModels;
using FrontToBack.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.Where(x => x.EmailConfirmed == true).ToList();
            var userVMs = new List<UserViewModel>();
            foreach (var user in users)
            {
                UserViewModel userVM = new UserViewModel
                {
                    Id = user.Id,
                    Fullname = user.Fullname,
                    Email = user.Email,
                    Username = user.UserName,
                    Isdeleted = user.Isdeleted,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault() ?? "rol yoxdu"
                };
                userVMs.Add(userVM);
            }

            return View(userVMs);
        }
        public async Task<IActionResult> Activated(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return BadRequest();
            if (user.Isdeleted)
            {
                user.Isdeleted = false;
            }
            else
            {
                user.Isdeleted = true;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeRole(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (id == null)
            {
                return BadRequest();
            }
            string role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (role == null)
            {
                return BadRequest();
            }
            ViewBag.CurrentRole = role;

            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string id, string newRole)
        {
            if (id == null && newRole == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            string oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (oldRole == null)
            {
                return BadRequest();
            }
            if (oldRole != newRole)
            {
                var result = await _userManager.AddToRoleAsync(user, newRole);
                if (!result.Succeeded)
                {

                    ModelState.AddModelError("", "some exist problems");

                }
                var deleteRole = await _userManager.RemoveFromRoleAsync(user, oldRole);
                if (deleteRole.Succeeded)
                {
                    ModelState.AddModelError("", "some exist problems");
                }
                await _userManager.UpdateAsync(user);

            }

            return RedirectToAction(nameof(Index));

        }

        public IActionResult ChangePassword(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return BadRequest();
            }
            var CheckCurrentPass = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (CheckCurrentPass == false)
            {
                ModelState.AddModelError("CurrentPassword", "Sifreni duzgun daxil edin");
            }
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
