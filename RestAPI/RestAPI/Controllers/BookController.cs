using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAPI.Business;
using RestAPI.Data.VO;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            BookVO book = _bookBusiness.GetById(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] BookVO book)
        {
            if(book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Create(book));
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] BookVO book)
        {
            if(book == null)
            {
                return BadRequest();
            }

            BookVO bookUpdated = _bookBusiness.Update(book);

            if(bookUpdated == null)
            {
                return BadRequest();
            }

            return Ok(bookUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
