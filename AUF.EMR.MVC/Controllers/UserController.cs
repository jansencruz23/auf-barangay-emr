using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Domain.Models.Identity;
using AUF.EMR.MVC.Models.DetailVM;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var model = new UserVM
            {
                Users = await _userManager.GetUsersInRoleAsync("User"),
            };
            return View(model);
        }

        // GET: UserController/Profile/5
        public async Task<ActionResult> Profile(string id)
        {
            var model = new DetailUserVM
            {
                User = await _userManager.FindByIdAsync(id),
            };
            return View(model);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return RedirectToPage("/Account/Register", new { area = "Identity" });
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserVM
            {
                User = await _userManager.FindByIdAsync(id),
            };
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, EditUserVM model)
        {
            if (!id.Equals(model.User.Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = model.User.FirstName;
                user.LastName = model.User.LastName;
                user.MiddleName = model.User.MiddleName;
                user.Picture = model.User.Picture;
                user.Position = model.User.Position;
                user.Birthday = model.User.Birthday;
                user.ContactNo = model.User.ContactNo;
                user.Address = model.User.Address;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult> ResetPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new ResetPasswordVM
            {
                Id = id,
                FullName = user.FullName
            };
            return View(model);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(string id, ResetPasswordVM model)
        {
            if (!id.Equals(model.Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                var newPasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.PasswordHash = newPasswordHash;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Edit), new { id });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
