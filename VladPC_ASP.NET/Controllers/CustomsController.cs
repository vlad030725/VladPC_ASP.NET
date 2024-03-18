using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomsController : ControllerBase
    {
        public readonly ICustomService _customService;

        public CustomsController(ICustomService customService)
        {
            _customService = customService;
        }

        // GET: api/<CustomsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomDto>>> Get()
        {
            return await Task.Run(() => _customService.GetAllCustoms());
        }

        // GET api/<CustomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomDto>> Get(int id)
        {
            return await Task.Run(() => _customService.GetCustom(id));
        }

        // POST api/<CustomsController>
        [HttpPost]
        public async Task<ActionResult<CustomDto>> Post(CustomDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _customService.CreateCustom(
                new CustomDto { 
                    IdUser = value.IdUser, 
                    IdStatus = value.IdStatus,
                    IdPromoCode = value.IdPromoCode,
                    Sum = value.Sum
                }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<CustomsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomDto>> Put(CustomDto value)
        {
            await Task.Run(() => _customService.UpdateCustom(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<CustomsController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _customService.DeleteCustom(id));
        }
    }
}
