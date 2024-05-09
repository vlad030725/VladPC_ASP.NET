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

        [HttpGet("cart/{idUser}")]
        public async Task<ActionResult<IEnumerable<CustomRowDto>>> GetCart(int idUser)
        {
            return await Task.Run(() => _customService.GetCustomInCart(idUser).CustomRows);
        }

        // GET api/<CustomRowsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CustomRowsController>
        [HttpPost]
        public async Task<ActionResult<CustomRowDto>> Post(CustomRowDto customRowDto)
        {
            User usr = await GetCurrentUserAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //if (_userManager.GetUserAsync(HttpContext.User).Result == null)
            //    return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });


            CustomRowDto customRow = new CustomRowDto()
            {
                IdProduct = customRowDto.IdProduct,
                IdCustom = _customService.GetCustomInCart((int)customRowDto.IdCustom).Id,
                Price = 0,
                Count = 1
            };

            await Task.Run(() => _customService.AddCustomRow(customRow));
            return CreatedAtAction("Get", new { idCustom = customRow.IdCustom }, customRow);
        }


        // PUT api/<CustomRowsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomRowDto>> Put(CustomRowDto customRowDto)
        {
            if (_customService.GetProduct((int)customRowDto.IdProduct).Count >= customRowDto.Count && customRowDto.Count > 0)
                await Task.Run(() => _customService.UpdateCustomRow(customRowDto));
            else
                return BadRequest();
            return CreatedAtAction("Get", new { idCustom = _customService.SearchCustom(customRowDto.Id) }, customRowDto);
        }

        // DELETE api/<CustomRowsController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _customService.DeleteCustomRow(id));
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
