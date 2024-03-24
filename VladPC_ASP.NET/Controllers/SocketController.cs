using BLL.Services;
using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketController : ControllerBase
    {
        public readonly ISocketService _socketService;
        public SocketController(ISocketService socketService)
        {
            _socketService = socketService;
        }

        // GET: api/<SocketController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocketDto>>> Get()
        {
            return await Task.Run(() => _socketService.GetSockets());
        }

        // GET api/<SocketController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SocketDto>> Get(int id)
        {
            return await Task.Run(() => _socketService.GetSocket(id));
        }

        // POST api/<SocketController>
        [HttpPost]
        public async Task<ActionResult<SocketDto>> Post(SocketDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _socketService.CreateSocket(new SocketDto()
            {
                Name = value.Name
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<SocketController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SocketDto>> Put(SocketDto value)
        {
            await Task.Run(() => _socketService.UpdateSocket(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<SocketController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _socketService.DeleteSocket(id));
        }
    }
}
