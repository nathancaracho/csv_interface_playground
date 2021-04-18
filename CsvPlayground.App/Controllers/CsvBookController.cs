using System;
using System.Collections.Generic;
using CsvPlayground.App.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CsvPlayground.App.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost]
        [Route("import")]
        public IActionResult Import([FromBody]List<BookDto> request)
        {
            Console.Write(request.ToString());
            return Ok();
        }

        [HttpGet]
        [Route("data.csv")]
        [Produces("text/csv")]
        public IActionResult GetCsv()
        {
            return Ok(new List<BookDto> { new BookDto { Name = "teste" } });
        }
    }
}