using BLL.Services;
using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VladPC_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        public readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        // GET: api/<CompaniesController>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> Get()
        {
            return await Task.Run(() => _companyService.GetCompanies());
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CompanyDto>> Get(int id)
        {
            return await Task.Run(() => _companyService.GetCompany(id));
        }

        // POST api/<CompaniesController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CompanyDto>> Post(CompanyDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _companyService.CreateCompany(new CompanyDto()
            {
                Name = value.Name
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CompanyDto>> Put(CompanyDto value)
        {
            await Task.Run(() => _companyService.UpdateCompany(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async void Delete(int id)
        {
            await Task.Run(() => _companyService.DeleteCompany(id));
        }
    }
}
