using BLL.Services;
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
    public class TypeProductController : ControllerBase
    {
        public readonly ITypeProductService _typeProductService;
        public TypeProductController(ITypeProductService typeProductService)
        {
            _typeProductService = typeProductService;
        }
        // GET: api/<TypeProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeProductDto>>> Get()
        {
            return await Task.Run(() => _typeProductService.GetTypesProduct());
        }

        // GET api/<TypeProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeProductDto>> Get(int id)
        {
            return await Task.Run(() => _typeProductService.GetTypeProduct(id));
        }

        // POST api/<TypeProductController>
        [HttpPost]
        public async Task<ActionResult<TypeProductDto>> Post(TypeProductDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _typeProductService.CreateTypeProduct(new TypeProductDto()
            {
                Name = value.Name
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<TypeProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeProductDto>> Put(TypeProductDto value)
        {
            await Task.Run(() => _typeProductService.UpdateTypeProduct(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<TypeProductController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _typeProductService.DeleteTypeProduct(id));
        }
    }
}
