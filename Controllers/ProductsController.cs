using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);

            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            try
            {
                var product = _service.Create(dto);
                return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);    
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductDto dto)
        {
            var updated = _service.Update(id, dto);

            if(!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);

            if(!deleted)
                return NotFound();

            return NoContent();
        } 
    }
}