using System.Collections.Generic;
namespace CsvPlayground.App.Dto
{
    public class BookDto
    {
        public string Name { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }

}