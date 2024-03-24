using BLL.Services;
using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormFactorController : ControllerBase
    {
        public readonly IFormFactorService _formFactorService;
        public FormFactorController(IFormFactorService formFactorService)
        {
            _formFactorService = formFactorService;
        }

        // GET: api/<FormFactorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormFactorDto>>> Get()
        {
            return await Task.Run(() => _formFactorService.GetFormFactors());
        }

        // GET api/<FormFactorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormFactorDto>> Get(int id)
        {
            return await Task.Run(() => _formFactorService.GetFormFactor(id));
        }

        // POST api/<FormFactorController>
        [HttpPost]
        public async Task<ActionResult<FormFactorDto>> Post(FormFactorDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _formFactorService.CreateFormFactor(new FormFactorDto()
            {
                Name = value.Name
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<FormFactorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FormFactorDto>> Put(FormFactorDto value)
        {
            await Task.Run(() => _formFactorService.UpdateFormFactor(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<FormFactorController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _formFactorService.DeleteFormFactor(id));
        }
    }
}
