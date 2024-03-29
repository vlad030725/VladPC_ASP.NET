using Microsoft.AspNetCore.Mvc;
using Interfaces.DTO;
using Interfaces.Services;
using Interfaces.DTO;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            return await Task.Run(() => _userService.GetUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            return await Task.Run(() => _userService.GetUser(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(UserDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _userService.CreateUser(new UserDto() { 
                Name = value.Name, 
                Login = value.Login, 
                Password = value.Password
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Put(UserDto value)
        {
            await Task.Run(() => _userService.UpdateUser(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _userService.DeleteUser(id));
        }
    }
}
