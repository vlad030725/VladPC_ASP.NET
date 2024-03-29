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
    public class ProcurementController : ControllerBase
    {
        public readonly IProcurementService _procurementService;

        public ProcurementController(IProcurementService procurementService)
        {
            _procurementService = procurementService;
        }

        // GET: api/<ProcurementController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcurementDto>>> Get()
        {
            return await Task.Run(() => _procurementService.GetAllProcurements());
        }

        // GET api/<ProcurementController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcurementDto>> Get(int id)
        {
            return await Task.Run(() => _procurementService.GetProcurement(id));
        }

        // POST api/<ProcurementController>
        [HttpPost]
        public async Task<ActionResult<ProcurementDto>> Post(ProcurementDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _procurementService.CreateProcurement(
                new ProcurementDto
                {
                    Sum = value.Sum,
                }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<ProcurementController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProcurementDto>> Put(ProcurementDto value)
        {
            await Task.Run(() => _procurementService.UpdateProcurement(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<ProcurementController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _procurementService.DeleteProcurement(id));
        }
    }
}
