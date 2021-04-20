using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvPlayground.App.Core.Converter
{
    public class SlugListConverter : TypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) =>
            text
                ?.Split(',')
                ?.Where(slug => !string.IsNullOrWhiteSpace(slug))
                ?.ToList()
            ?? Enumerable.Empty<string>();

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) =>
            value is null
                ? string.Empty
                : string.Join(',', (IEnumerable<string>)value);

    }
}