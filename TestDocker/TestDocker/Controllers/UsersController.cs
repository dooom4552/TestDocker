using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestDocker.Models;
using TestDocker.ViewsModels;

namespace TestDocker.Controllers
{
    [Authorize(Roles = "director")]
    public class UsersController : Controller
    {
        readonly UserManager<User> _userManager;
        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index() => View(_userManager.Users.ToList());
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            User userThis = await _userManager.FindByNameAsync(model.Email);
            if (userThis == null)
            {
                if (ModelState.IsValid)
                {
                    User user = new User { Email = model.Email, UserName = model.Email };


                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                return View(model);
            }
            return  Content("Такой пользователь уже существует");
        }
    }
}