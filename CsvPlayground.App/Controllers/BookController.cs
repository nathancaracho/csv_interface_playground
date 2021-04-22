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
        public IActionResult Import([FromBody] IEnumerable<BookDto> request) => Ok(request);


        [HttpGet]
        [Route("default.csv")]
        [Produces("text/csv")]
        public IActionResult GetCsv() => Ok(new List<BookDto> { new BookDto() });

        [HttpGet]
        [Route("example.csv")]
        [Produces("text/csv")]
        public IActionResult GetExample() =>
                Ok(new List<BookDto> {
                new BookDto{
                    Name = "Book Name",
                    Brief = "Book brief",
                    Description = "Book description",
                    Image = "https://myimage.com.br/photo",
                    Categories = new List<string>{
                        "category1",
                        "category2",
                        "category3"
                    },
                    Rules = new List<ExhibitionRule>{
                        new ExhibitionRule{
                            Code = "Code",
                            Value = "Value"
                        },
                        new ExhibitionRule{
                            Code = "Code1",
                            Value = "Value1"
                        },
                        new ExhibitionRule{
                            Code = "Code2",
                            Value = "Value2"
                        }
                    }
                }
                    }
                );
    }
}