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
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            return await Task.Run(() => _productService.GetAllProducts());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            return await Task.Run(() => _productService.GetProduct(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(ProductDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _productService.CreateProduct(new ProductDto()
            {
                Name = value.Name,
                Price = value.Price,
                Count = value.Count,
                IdCompany = value.IdCompany,
                IdTypeProduct = value.IdTypeProduct,
                IdTypeMemory = value.IdTypeMemory,
                CountCores = value.CountCores,
                CountStreams = value.CountStreams,
                Frequency = value.Frequency,
                IdSocket = value.IdSocket,
                IdFormFactor = value.IdFormFactor
            }));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(ProductDto value)
        {
            await Task.Run(() => _productService.UpdateProduct(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await Task.Run(() => _productService.DeleteProduct(id));
        }
    }
}
