
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using CsvPlayground.App.Core.Converter;

namespace CsvPlayground.App.Dto
{
    public class BookDto
    {
        [Name("name")]
        public string Name { get; set; }
        [Name("brief")]
        public string Brief { get; set; }
        [Name("description")]
        public string Description { get; set; }
        [Name("image")]
        public string Image { get; set; }

        [Name("categories")]
        [TypeConverter(typeof(SlugListConverter))]
        public IEnumerable<string> Categories { get; set; }

        [Name("rules")]
        [TypeConverter(typeof(ExhibitionRuleListConverter))]
        public IEnumerable<ExhibitionRule> Rules { get; set; }

    }

    public class ExhibitionRule
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }

}