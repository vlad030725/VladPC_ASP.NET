using DomainModel;
using Interfaces.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [ApiController]
    [EnableCors]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)//, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
        }

        [HttpPost]
        [Route("api/account/register")]
        //[AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewDto model)
        {
            if (ModelState.IsValid)
            {
                User user = new() { UserName = model.Login, PasswordHash = model.Password };

                // Добавление нового пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Установка роли User
                    await _userManager.AddToRoleAsync(user, "user");
                    // Установка куки
                    await _signInManager.SignInAsync(user, false);
                    return Ok(new { message = "Добавлен новый пользователь: " + user.UserName });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);
            
            }
        }

        [HttpPost]
        [Route("api/account/login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
                
                if (result.Succeeded)
                {
                    User? userIzBazi = await _userManager.GetUserAsync(HttpContext.User);
                    IEnumerable<string> roles = await _userManager.GetRolesAsync(userIzBazi);
                    string? userRole = roles.FirstOrDefault();
                    //return Ok(new { message = "Выполнен вход", userName = model.Email, userRole });
                    UserDto user = new UserDto()
                    {
                        Id = userIzBazi.Id,
                        UserName = model.Login,
                        Password = model.Password,
                        Role = userRole
                    };
                    return Ok(new { message = "Выполнен вход", user });
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);
            }
        }

        [HttpPost]
        [Route("api/account/logoff")]
        public async Task<IActionResult> LogOff()
        {
            User usr = await GetCurrentUserAsync();
            if (usr == null)
            {
                return Unauthorized(new { message = "Сначала выполните вход" });
            }
            // Удаление куки
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Выполнен выход", userName = usr.UserName });
        }

        [HttpGet]
        [Route("api/account/isauthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            User userIzBazi = await GetCurrentUserAsync();
            if (userIzBazi == null)
            {
                return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
            }
            IEnumerable<string> roles = await _userManager.GetRolesAsync(userIzBazi);
            string? userRole = roles.FirstOrDefault();
            UserDto user = new UserDto()
            {
                Id = userIzBazi.Id,
                UserName = userIzBazi.UserName,
                Role = userRole
            };
            return Ok(new { message = "Сессия активна", user });
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
