using Microsoft.AspNetCore.Mvc;
using QFeedmill.Shared.Models.Dto.User;
using QFeedmill.Shared.Services;

namespace QFeedMill.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet("all-users")]
        public async Task<IActionResult> UsersAsync()
        {
            var result = await _userServices.GetAllUsers();
            return View(result.Data);
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> UserDetailAsync([FromRoute] string id)
        {
            var result = await _userServices.GetUser(id);
            return View(result.Data);
        }
        [HttpGet("create-user")]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserDto request)
        {
           
            var result = await _userServices.CreateUser(request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("User");
            }
            return RedirectToAction("User");
        }

        [HttpGet("update-user/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] string id)
        {
            var result = await _userServices.GetUser(id);
            return View(result.Data);
        }

        [HttpPost("update-user/{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] string id, [FromForm] UpdateUserDto request)
        {
            var result = await _userServices.UpdateUser(id, request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("UserDetail", new { id = id });
            }
            return RedirectToAction("Users");
        }

        [HttpGet("delete-feedCategory/{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string id)
        {
            var result = await _userServices.DeleteUser(id);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Users");
            }
            return RedirectToAction("DeleteUser");
        }
    }
}
