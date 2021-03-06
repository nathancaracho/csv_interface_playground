using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace CsvPlayground.App.Core.Formatter
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        private readonly CsvConfiguration _config = new(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ";"
        };
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var writer = new StringWriter();
            using var csv = new CsvWriter(writer, _config);
            csv.WriteRecords((IList)context.Object);
            csv.Flush();
            await context.HttpContext.Response.WriteAsync(writer.ToString(), selectedEncoding);
        }
    }
}