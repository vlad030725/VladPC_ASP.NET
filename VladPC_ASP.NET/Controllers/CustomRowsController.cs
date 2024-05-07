using BLL.Services;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomRowsController : ControllerBase
    {
        public readonly ICustomService _customService;
        private readonly UserManager<User> _userManager;
        public CustomRowsController(ICustomService customService, UserManager<User> userManager)
        {
            _customService = customService;
            _userManager = userManager;
        }
        // GET: api/<CustomRowsController>
        [HttpGet("{idCustom}")]
        public async Task<ActionResult<IEnumerable<CustomRowDto>>> Get(int idCustom)
        {
            return await Task.Run(() => _customService.GetCustomRowsOneCustom(idCustom));
        }

        // GET api/<CustomRowsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CustomRowsController>
        [HttpPost]
        public async Task<ActionResult<CustomRowDto>> Post(CustomRowDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _customService.AddCustomRow(new CustomRowDto()
            {
                IdProduct = value.IdProduct,
                IdCustom = _userManager.GetUserAsync(HttpContext.User).Result.Id
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }


        // PUT api/<CustomRowsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomRowsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
