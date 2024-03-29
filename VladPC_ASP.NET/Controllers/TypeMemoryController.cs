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
    public class TypeMemoryController : ControllerBase
    {
        public readonly ITypeMemoryService _typeMemoryService;
        public TypeMemoryController(ITypeMemoryService typeMemoryService)
        {
            _typeMemoryService = typeMemoryService;
        }

        // GET: api/<TypeMemoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeMemoryDto>>> Get()
        {
            return await Task.Run(() => _typeMemoryService.GetTypesMemory());
        }

        // GET api/<TypeMemoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeMemoryDto>> Get(int id)
        {
            return await Task.Run(() => _typeMemoryService.GetTypeMemory(id));
        }

        // POST api/<TypeMemoryController>
        [HttpPost]
        public async Task<ActionResult<TypeMemoryDto>> Post(TypeMemoryDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _typeMemoryService.CreateTypeMemory(new TypeMemoryDto()
            {
                Name = value.Name
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<TypeMemoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeMemoryDto>> Put(TypeMemoryDto value)
        {
            await Task.Run(() => _typeMemoryService.UpdateTypeMemory(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<TypeMemoryController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _typeMemoryService.DeleteTypeMemory(id));
        }
    }
}
