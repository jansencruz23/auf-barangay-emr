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
    
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Policy = "Admin")]
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var model = new UserVM
            {
                Users = await _userManager.GetUsersInRoleAsync("User"),
            };
            return View(model);
        }

        [Authorize(Policy = "Admin")]
        // GET: UserController/Profile/5
        public async Task<ActionResult> Profile(string id)
        {
            var model = new DetailUserVM
            {
                User = await _userManager.FindByIdAsync(id),
            };
            return View(model);
        }

        [Authorize(Policy = "Admin")]
        // GET: UserController/Create
        public ActionResult Create()
        {
            return RedirectToPage("/Account/Register", new { area = "Identity" });
        }

        [Authorize(Policy = "Admin")]
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
        [Authorize(Policy = "Admin")]
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
                user.Position = model.User.Position;
                user.Birthday = model.User.Birthday;
                user.ContactNo = model.User.ContactNo;
                user.Address = model.User.Address;

                if (model.PictureFile != null && model.PictureFile.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await model.PictureFile.CopyToAsync(memoryStream);
                    byte[] logoBytes = memoryStream.ToArray();

                    user.Picture = logoBytes;
                }

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
        [Authorize(Policy = "Admin")]
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
        [Authorize(Policy = "Admin")]
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

        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> AdminChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View();
            }

            var model = new ChangePasswordVM
            {

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AdminChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    model.ErrorMessage = error.Description;
                }
                
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [Authorize(Policy = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                await _userManager.DeleteAsync(user);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [Authorize(Policy = "User")]
        public async Task<ActionResult> UserProfile()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                return View(user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Invalid", "Error");
            }
        }
    }
}
