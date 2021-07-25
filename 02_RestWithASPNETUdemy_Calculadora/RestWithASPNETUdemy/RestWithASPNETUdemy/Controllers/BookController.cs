using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Business;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")] // Versão da API
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")] //Ajuste do caminho + versão
    public class BookController : Controller
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
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var book = _bookBusiness.FindById(Id);

            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _bookBusiness.Delete(Id);
            return NoContent();
        }

    }
}