using BLL.Services;
using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
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
            //return await Task.Run(() => _procurementService.(id));
        }

        // POST api/<ProcurementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProcurementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProcurementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
