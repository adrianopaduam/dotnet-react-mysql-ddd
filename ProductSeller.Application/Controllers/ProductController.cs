using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;
using ProductSeller.Infrastructure.Data.Context;
using ProductSeller.Service.Validation;

namespace ProductSeller.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IBaseService<Product> _baseProductService;

        private readonly DatabaseContext _dbContext;

        public ProductController(IBaseService<Product> baseProductService, IOptions<DatabaseContext> options)
        {
            _baseProductService = baseProductService;
            _dbContext = options.Value;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return id <= 0 ? NotFound() : Execute(() => _baseProductService.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProductService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            return product == null ? BadRequest() : Execute(() => _baseProductService.Add<ProductValidator>(product));
        }


        // POST: UserController/Edit/5
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            return product == null ? NotFound() : Execute(() => _baseProductService.Update<ProductValidator>(product));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            return Execute(() => _baseProductService.Delete(id));
        }


        private IActionResult Execute(Func<object> functionToExecute)
        {
            try
            {
                var result = functionToExecute();

                if (result == null)
                    return NotFound();

                if (result is bool)
                    return result is true ? Ok() : NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
