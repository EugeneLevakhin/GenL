using Microsoft.AspNetCore.Mvc;
using GenL.Business.Services.Abstract;
using GenL.Presentation.Models.Users;

namespace GenL.Presentation.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            var usersViewModel = new UsersViewModel(users);

            return View(usersViewModel);
        }
    }
}