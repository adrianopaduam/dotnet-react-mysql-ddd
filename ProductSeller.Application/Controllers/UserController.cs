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
    public class UserController : ControllerBase
    {
        private readonly IBaseService<User> _baseUserService;

        private readonly DatabaseContext _dbContext;

        public UserController(IBaseService<User> baseUserService, IOptions<DatabaseContext> options)
        {
            _baseUserService = baseUserService;
            _dbContext = options.Value;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            return Execute(() => _baseUserService.Add<UserValidator>(user));
        }


        // POST: UserController/Edit/5
        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UserValidator>(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            return Execute(() => _baseUserService.Delete(id));
        }


        private IActionResult Execute(Func<object> functionToExecute)
        {
            try
            {
                var result = functionToExecute();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
