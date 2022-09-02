using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAPI.Business;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Person person = _personBusiness.GetById(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }
            return Ok(_personBusiness.Create(person));
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
