using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class CustomsController : ControllerBase
    {
        public readonly ICustomService _customService;

        public CustomsController(ICustomService customService)
        {
            _customService = customService;
        }

        // GET: api/<CustomsController>
        [HttpGet("history/{idUser}")]
        public async Task<ActionResult<IEnumerable<CustomDto>>> GetHistory(int idUser)
        {
            return await Task.Run(() => _customService.GetCustomHistory(idUser).OrderByDescending(i => i.Id).ToList());
        }

        // GET api/<CustomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomDto>> Get(int id)
        {
            return await Task.Run(() => _customService.GetCustom(id));
        }
        [HttpGet("user/{idUser}")]
        public async Task<ActionResult<CustomDto>> GetInCart(int idUser)
        {
            return await Task.Run(() => _customService.GetCustomInCart(idUser));
        }

        // POST api/<CustomsController>
        [HttpPost]
        public async Task<ActionResult<CustomDto>> Post(CustomDto custom)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _customService.CreateCustom(
                new CustomDto { 
                    IdUser = custom.IdUser, 
                    IdStatus = custom.IdStatus,
                    IdPromoCode = custom.IdPromoCode,
                    Sum = custom.Sum
                }));
            return CreatedAtAction("Get", new { Id = custom.Id }, custom);
        }

        // PUT api/<CustomsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomDto>> Put(CustomDto custom)
        {
            await Task.Run(() => _customService.MakeCustom((int)custom.IdUser));
            return CreatedAtAction("Get", new { Id = custom.Id }, custom);
        }

        // DELETE api/<CustomsController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _customService.DeleteCustom(id));
        }
    }
}
