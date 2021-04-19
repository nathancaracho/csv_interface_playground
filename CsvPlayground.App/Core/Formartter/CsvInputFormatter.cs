using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvPlayground.App.Dto;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using TinyCsvParser;

namespace CsvPlayground.App.Core.Formatter
{
    public class CsvInputFormatter : TextInputFormatter
    {
        public CsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"

            };
            using var reader = new StreamReader(context.HttpContext.Request.Body, encoding);

            using var csv = new CsvReader(reader, config);
            var records = (IList)Activator.CreateInstance(context.ModelType);

            while (csv.Read())
                records.Add(csv.GetRecord(context.ModelType.GetGenericArguments()[0]));
            return InputFormatterResult.SuccessAsync(records);
        }
    }


}